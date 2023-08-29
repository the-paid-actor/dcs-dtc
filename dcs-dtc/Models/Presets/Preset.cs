using DTC.Utilities;

namespace DTC.Models.Presets
{
    public class Preset : IPreset
    {
        public string Name { get; set; }
        public IConfiguration Configuration { get; set; }

        public Preset()
        {

        }

        public Preset(string name, IConfiguration configuration)
        {
            Name = name;
            Configuration = configuration;
        }

        public IPreset Clone()
        {
            return new Preset(Name + " Copy", Configuration.Clone());
        }
    }
}
