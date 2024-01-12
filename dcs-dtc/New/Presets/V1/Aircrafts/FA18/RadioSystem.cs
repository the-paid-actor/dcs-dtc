namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class RadioSystem
{
    public Radio COM1;
    public Radio COM2;
    public bool EnableUpload { get; set; }

    public RadioSystem()
    {
        ResetToDefaults();
    }

    public void ResetToDefaults()
    {
        var uhfChannels = new List<RadioChannel>();

        for (int i = 0; i < 20; i++)
        {
            uhfChannels.Add(new RadioChannel(RadioType.UHF, i + 1, new decimal(251.00f + i), false));
        }

        COM1 = new Radio("COM1", RadioType.UHF, uhfChannels.ToArray());

        var vhfChannels = new List<RadioChannel>();

        for (int i = 0; i < 20; i++)
        {
            vhfChannels.Add(new RadioChannel(RadioType.VHF, i + 1, new decimal(121.00f + i), false));
        }

        COM2 = new Radio("COM2", RadioType.VHF, vhfChannels.ToArray());
    }
}
