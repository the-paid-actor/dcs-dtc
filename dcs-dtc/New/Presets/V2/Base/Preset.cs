using DTC.Utilities;

namespace DTC.New.Presets.V2.Base;

public class Preset : IPreset
{
    public string Name { get; set; }
    public Configuration Configuration { get; set; }

    IConfiguration IPreset.Configuration => Configuration;

    public Preset()
    {
    }

    public Preset(string name, Configuration configuration)
    {
        Name = name;
        Configuration = configuration;
    }

    public IPreset Clone()
    {
        return new Preset(Name + " Copy", Configuration.Clone());
    }
}
