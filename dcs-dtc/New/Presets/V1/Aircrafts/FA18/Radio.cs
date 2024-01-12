namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class Radio
{
    public string Name { get; set; }
    public RadioType Type { get; set; }
    public RadioChannel[] Channels { get; set; }
    public RadioChannel SelectedChannel { get; set; }

    public Radio(string name, RadioType type, RadioChannel[] channels)
    {
        Name = name;
        Type = type;
        Channels = channels;
        SelectedChannel = Channels[0];
    }
}
