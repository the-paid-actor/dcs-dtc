using Newtonsoft.Json;
using System.ComponentModel;

namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

public class LaserCodesSystem
{
    private static readonly (int Min, int Max)[] AllowedCodeRanges =
    {
        (1111, 1788),
        (2111, 2888),
        (4111, 4288),
        (4311, 4488),
        (4511, 4688),
        (4711, 4888),
        (5111, 5288),
        (5311, 5488),
        (5511, 5688),
        (5711, 5888),
    };

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string A { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string B { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string C { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string D { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string E { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string F { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string G { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string H { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string I { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string J { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string K { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string L { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string M { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string N { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string P { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string Q { get; set; } = "";

    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    [DefaultValue("")]
    public string R { get; set; } = "";


    public static readonly char[] Letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R' };

    public string SetCode(char letter, string code)
    {
        code = code?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(code))
        {
            return SetCodeInternal(letter, string.Empty);
        }

        if (!code.All(char.IsDigit))
        {
            return string.Empty;
        }

        if (code.Length < 4)
        {
            return code;
        }
        if (code.Length != 4 || !int.TryParse(code, out var parsedCode) || !IsAllowedCode(parsedCode))
        {
            return string.Empty;
        }

        return SetCodeInternal(letter, code);
    }

    private static bool IsAllowedCode(int code)
    {
        return AllowedCodeRanges.Any(range => code >= range.Min && code <= range.Max);
    }

    private string SetCodeInternal(char letter, string code)
    {
        switch (letter)
        {
            case 'A': A = code; break;
            case 'B': B = code; break;
            case 'C': C = code; break;
            case 'D': D = code; break;
            case 'E': E = code; break;
            case 'F': F = code; break;
            case 'G': G = code; break;
            case 'H': H = code; break;
            case 'I': I = code; break;
            case 'J': J = code; break;
            case 'K': K = code; break;
            case 'L': L = code; break;
            case 'M': M = code; break;
            case 'N': N = code; break;
            case 'P': P = code; break;
            case 'Q': Q = code; break;
            case 'R': R = code; break;
            default: return string.Empty;
        }

        return code;
    }

    public string GetCode(char letter)
    {
        return letter switch
        {
            'A' => A,
            'B' => B,
            'C' => C,
            'D' => D,
            'E' => E,
            'F' => F,
            'G' => G,
            'H' => H,
            'I' => I,
            'J' => J,
            'K' => K,
            'L' => L,
            'M' => M,
            'N' => N,
            'P' => P,
            'Q' => Q,
            'R' => R,
            _ => string.Empty,
        };
    }
}
