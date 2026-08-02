using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DTCCodeGenerator;

[Generator]
public class SourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Collect additional files that end with .json and transform them into SourceFile instances
        var jsonFiles = context.AdditionalTextsProvider
            .Where(at => at.Path.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            .Select((additionalText, cancellationToken) =>
            {
                var content = additionalText.GetText(cancellationToken)?.ToString();
                if (string.IsNullOrEmpty(content))
                    return null;

                var assembly = "dcs-dtc";
                var ns = "DTC";
                return new SourceFile(additionalText.Path, assembly, ns, content);
            })
            .Where(sf => sf is not null)!;

        // Register a source output for each parsed SourceFile
        context.RegisterSourceOutput(jsonFiles, (spc, sourceFile) =>
        {
            try
            {
                spc.AddSource(sourceFile.FileName, Generator.Generate(sourceFile));
            }
            catch (Exception ex)
            {
                var descriptor = new DiagnosticDescriptor(
                    "DTCGEN001",
                    "Generator error",
                    ex.ToString(),
                    "DTCCodeGenerator",
                    DiagnosticSeverity.Warning,
                    true);

                spc.ReportDiagnostic(Diagnostic.Create(descriptor, Location.None));
            }
        });
    }
}

static class Extensions
{
    public static string FormatClassName(this string input)
    {
        return ToPascalCase(input).Replace("settings", "Settings");
    }

    public static string FormatPropertyName(this string input)
    {
        var underscore = "_";
        var tmp = input
            .Replace(".", underscore)
            .Replace("$", underscore);

        if (tmp[0].Equals(underscore))
            tmp.Replace(underscore, string.Empty);

        return ToPascalCase(tmp);
    }

    private static string ToPascalCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        if (input.Length == 1)
            return input.ToUpper();

        return string.Concat(input[0].ToString().ToUpper(), input.Substring(1));
    }
}

static class Generator
{
    public static SourceText Generate(SourceFile sourceFile)
    {
        var stringBuilder = new StringBuilder($@"
                // <mapper-source-generated />
                // <generated-at '{DateTime.UtcNow}' />

                using System.Diagnostics.CodeAnalysis;
                using DTC.New.Uploader.Base;

                namespace {sourceFile.Namespace}
                {{
                    [ExcludeFromCodeCoverage]
                    public partial class {sourceFile.ClassName}
                    {{
                ");

        foreach (var item in sourceFile.SourceClasses)
        {
            var key = item.Key;
            stringBuilder.Append($"public {key.FormatPropertyName()}Device {key.FormatPropertyName()}{{ get; set; }} = new {key.FormatPropertyName()}Device();");
            BuildConfigClass(item, stringBuilder, 1);
        }

        stringBuilder.Append("}");
        stringBuilder.Append("}");

        var tree = CSharpSyntaxTree.ParseText(stringBuilder.ToString());

        Debug.WriteLine($"End generating sources for '{sourceFile.ClassName}' class. Success!");
        return SourceText.From(tree.GetRoot().NormalizeWhitespace().ToFullString(), Encoding.UTF8);
    }

    private static void BuildConfigClass(KeyValuePair<string, object> classInfo, StringBuilder stringBuilder, int level)
    {
        var interf = (level == 1 ? "Device" : "Command");
        var className = classInfo.Key.FormatClassName() + interf;
        stringBuilder.Append("[ExcludeFromCodeCoverage]");
        stringBuilder.Append($"public class {className} : {interf}");
        stringBuilder.Append("{");

        if (level == 1)
        {
            stringBuilder.Append($"public {className}()");
            stringBuilder.Append("{");
            foreach (var item in (Dictionary<string, object>)classInfo.Value)
            {
                if (item.Value is Dictionary<string, object>)
                {
                    stringBuilder.Append($"this.{item.Key.FormatPropertyName()} = new {item.Key}Command(this);");
                }
            }
            stringBuilder.Append("}");
            stringBuilder.Append("public override string Name { get; } = \"" + classInfo.Key.FormatClassName() + "\";");
        }
        else
        {
            stringBuilder.Append($"public {className}(Device device) : base(device)");
            stringBuilder.Append("{");
            stringBuilder.Append("}");
        }

        foreach (var item in (Dictionary<string, object>)classInfo.Value)
        {
            var propName = item.Key.FormatPropertyName();

            if (item.Value is Dictionary<string, object>)
            {
                stringBuilder.Append($"public {item.Key}Command {propName} {{ get; }}");
                BuildConfigClass(item, stringBuilder, level + 1);
            }
            else
            {
                var propType = "int";
                var value = item.Value.ToString();
                if (propName == "DelayFactor" || propName == "PostDelayFactor" || propName == "Activation")
                {
                    propType = "decimal";
                    value += "M";
                }

                stringBuilder.Append($"public override {propType} {propName} {{ get; }} = {value};");
            }
        }

        stringBuilder.Append("}");
    }

    private static string GetPropertyTypeName(JsonElement value)
    {
        return value.ValueKind switch
        {
            JsonValueKind.Number => "float",
            JsonValueKind.True or JsonValueKind.False => "bool",
            _ => "string",
        };
    }
}

class SourceFile
{
    private string path;
    private string assemblyName;
    private string ns;
    private Dictionary<string, object> content;

    public IList<KeyValuePair<string, object>> MainProperties => this.content
        .Where(dict => !(dict.Value is Dictionary<string, object>))
        .ToList();

    public IList<KeyValuePair<string, object>> SourceClasses => this.content.Except(MainProperties)
        .ToList();

    public string ClassName => FormatClassName(Path.GetFileNameWithoutExtension(this.path));

    public string FileName => $"{ClassName}.cs";

    public string Namespace
    {
        get
        {
            var pathParts = this.path.Split(Path.DirectorySeparatorChar).Where(item => !string.IsNullOrWhiteSpace(item)).ToArray();
            var startIndex = -1;
            var endIndex = -1;
            for (var i = 0; i < pathParts.Length; i++)
            {
                if (pathParts[i] == assemblyName && pathParts[i+1] != assemblyName)
                {
                    startIndex = i + 1;
                }
            }
            for (var i = 0; i < pathParts.Length; i++)
            {
                if (pathParts[i] == Path.GetFileName(this.path))
                {
                    endIndex = i - 1;
                }
            }

            var namespaceName = string.Empty;
            for (var i = startIndex; i <= endIndex; i++)
            {
                namespaceName += $".{pathParts[i].Trim()}";
            }

            return $"{this.ns}{namespaceName}";
        }
    }

    public SourceFile(string path, string assemblyName, string ns, string content)
    {
        this.path = path;
        this.assemblyName = assemblyName;
        this.ns = ns;
        this.content = Deserialize(content);
    }

    private string FormatClassName(string className)
    {
        var originName = className.Split('.').Where(item => !string.IsNullOrWhiteSpace(item)).First();
        return originName.FormatClassName();
    }

    private Dictionary<string, object> Deserialize(string content)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        var configValues = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(content, jsonSerializerOptions);
        var result = new Dictionary<string, object>();

        if (configValues is null)
            return result;

        foreach (var configValue in configValues)
        {
            if (configValue.Value.ValueKind is JsonValueKind.Object)
            {
                result.Add(configValue.Key, Deserialize(configValue.Value.ToString()));
            }
            else
            {
                result.Add(configValue.Key, configValue.Value);
            }
        }

        return result;
    }
}
