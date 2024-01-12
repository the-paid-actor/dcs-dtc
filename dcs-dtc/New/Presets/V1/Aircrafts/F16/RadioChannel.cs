using System.Globalization;
using System.Text.RegularExpressions;

namespace DTC.New.Presets.V1.Aircrafts.F16;

public class RadioChannel
{
    private static Regex uhfRegex = new Regex(@"^[2-3][0-9][0-9]\.?[0-9]?[0|2|5|7]?$");
    private static Regex vhfRegex = new Regex(@"^[0-1]?[0-8][0-9]\.?[0-9]?[0|2|5|7]?$");

    public RadioType Type { get; set; }
    public int Channel { get; set; }
    public decimal Frequency { get; set; }
    public bool ToBeUpdated { get; set; }

    public RadioChannel(RadioType type, int channel, decimal frequency, bool toBeUpdated)
    {
        Type = type;
        Channel = channel;
        Frequency = frequency;
        ToBeUpdated = toBeUpdated;
    }
}
