namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

public class LaserCodesSystem
{
    public const int MinCode = 1111;
    public const int MaxCode = 1788;

    public string A { get; set; } = "";
    public string B { get; set; } = "";
    public string C { get; set; } = "";
    public string D { get; set; } = "";
    public string E { get; set; } = "";
    public string F { get; set; } = "";
    public string G { get; set; } = "";
    public string H { get; set; } = "";
    public string I { get; set; } = "";
    public string J { get; set; } = "";
    public string K { get; set; } = "";
    public string L { get; set; } = "";
    public string M { get; set; } = "";
    public string N { get; set; } = "";
    public string P { get; set; } = "";
    public string Q { get; set; } = "";
    public string R { get; set; } = "";

    public static readonly char[] Letters = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R' };

    public string SetCode(char letter, string code)
    {
        if (string.IsNullOrEmpty(code) || code.Length != 4 || !code.All(char.IsDigit))
        {
            return "";
        }

        if (!int.TryParse(code, out var parsedCode) || parsedCode < MinCode || parsedCode > MaxCode)
        {
            return "";
        }

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
