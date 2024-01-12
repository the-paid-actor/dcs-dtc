namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class RadioChannel
{
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
