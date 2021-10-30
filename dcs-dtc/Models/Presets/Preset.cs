using DTC.Models.Base;

namespace DTC.Models.Presets
{
	public class Preset
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

		public Preset Clone()
		{
			return new Preset(Name + " Copy", Configuration.Clone());
		}
	}
}
