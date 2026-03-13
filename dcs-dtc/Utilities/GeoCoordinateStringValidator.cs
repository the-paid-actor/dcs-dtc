using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DTC.Utilities;

internal static partial class GeoCoordinateStringValidator
{
    private static readonly Regex LatitudeDmsPattern = BuildRegex(@"^[NS]\s+(?:90|[0-8]?\d)°(?:[0-5]?\d)['’′](?:[0-5]?\d(?:\.\d+)?)[\""”″]$");
    private static readonly Regex LongitudeDmsPattern = BuildRegex(@"^[EW]\s+(?:180|1[0-7]\d|0?\d?\d)°(?:[0-5]?\d)['’′](?:[0-5]?\d(?:\.\d+)?)[\""”″]$");
    private static readonly Regex LatitudeDdmPattern = BuildRegex(@"^[NS]\s+(?:90|[0-8]?\d)°(?:[0-5]?\d(?:\.\d+)?)['’′]$");
    private static readonly Regex LongitudeDdmPattern = BuildRegex(@"^[EW]\s+(?:180|1[0-7]\d|0?\d?\d)°(?:[0-5]?\d(?:\.\d+)?)['’′]$");
    private static readonly Regex LatitudeDdPattern = BuildRegex(@"^[NS]\s+(?:90(?:\.0+)?|[0-8]?\d(?:\.\d+)?)°$");
    private static readonly Regex LongitudeDdPattern = BuildRegex(@"^[EW]\s+(?:180(?:\.0+)?|1[0-7]\d(?:\.\d+)?|0?\d?\d(?:\.\d+)?)°$");

    public static bool ValidateGeoCoordinateStrings(string json, out string? error)
    {
        error = null;

        JToken root;
        try
        {
            root = JToken.Parse(json);
        }
        catch (JsonException)
        {
            return true;
        }

        foreach (var token in root.DescendantsAndSelf())
        {
            if (token is not JProperty prop || prop.Value.Type != JTokenType.String)
            {
                continue;
            }

            var name = prop.Name.Trim();
            var rawValue = prop.Value.Value<string>()?.Trim();
            if (string.IsNullOrEmpty(rawValue))
            {
                continue;
            }

            if (IsLatitudeField(name) && !IsValidLatitude(rawValue))
            {
                error = BuildInvalidCoordinateMessage("Latitude", prop.Path, rawValue);
                return false;
            }

            if (IsLongitudeField(name) && !IsValidLongitude(rawValue))
            {
                error = BuildInvalidCoordinateMessage("Longitude", prop.Path, rawValue);
                return false;
            }
        }

        return true;
    }

    private static bool IsValidLatitude(string input)
    {
        return LatitudeDmsPattern.IsMatch(input)
               || LatitudeDdmPattern.IsMatch(input)
               || LatitudeDdPattern.IsMatch(input);
    }

    private static bool IsValidLongitude(string input)
    {
        return LongitudeDmsPattern.IsMatch(input)
               || LongitudeDdmPattern.IsMatch(input)
               || LongitudeDdPattern.IsMatch(input);
    }

    private static bool IsLatitudeField(string fieldName)
    {
        return fieldName.Equals("Lat", StringComparison.OrdinalIgnoreCase)
               || fieldName.Equals("Latitude", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsLongitudeField(string fieldName)
    {
        return fieldName.Equals("Lon", StringComparison.OrdinalIgnoreCase)
               || fieldName.Equals("Long", StringComparison.OrdinalIgnoreCase)
               || fieldName.Equals("Longitude", StringComparison.OrdinalIgnoreCase);
    }

    private static string BuildInvalidCoordinateMessage(string coordinateType, string path, string value)
    {
        return
            $"Invalid {coordinateType} coordinate in JSON at '{path}': '{value}'.\n\n" +
            "Use one of these UTF-8 formats:\n" +
            "DMS: N 26°31'55.51\" / E 057°08'13.75\"\n" +
            "DDM: N 26°31.9252' / E 057°08.2292'\n" +
            "DD:  N 26.532086° / E 57.137153°\n\n" +
            "Tip: apostrophe/backtick (`) is not a valid minute/second symbol. Use ' or UTF-8 symbols like ’ and \".";
    }


    private static Regex BuildRegex(string pattern)
    {
        return new Regex(pattern, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    }
}
