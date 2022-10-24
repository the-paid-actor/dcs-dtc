using DTC.Models.FA18.Waypoints;
using DTC.Models.FA18.Sequences;
using DTC.Models.FA18.Radios;
using DTC.Models.FA18.PrePlanned;
using DTC.Models.FA18.CMS;
using Newtonsoft.Json;
using DTC.Models.Base;
using DTC.Models.FA18.Misc;

namespace DTC.Models.FA18
{
	public class FA18Configuration : IConfiguration
	{
		public WaypointSystem Waypoints = new WaypointSystem();
		public SequenceSystem Sequences = new SequenceSystem();
		public PrePlannedSystem PrePlanned = new PrePlannedSystem();
		public RadioSystem Radios = new RadioSystem();
		public CMSystem CMS = new CMSystem();
		public MiscSystem Misc = new MiscSystem();

		public string ToJson()
		{
			var json = JsonConvert.SerializeObject(this);
			return json;
		}

		public string ToCompressedString()
		{
			var json = ToJson();
			return StringCompressor.CompressString(json);
		}

		public static FA18Configuration FromJson(string s)
		{
			try
			{
				var cfg = JsonConvert.DeserializeObject<FA18Configuration>(s);
				cfg.AfterLoadFromJson();
				return cfg;
			}
			catch
			{
				return null;
			}
		}

		public void AfterLoadFromJson()
		{
		}

		public static FA18Configuration FromCompressedString(string s)
		{
			try
			{
				var json = StringCompressor.DecompressString(s);
				var cfg = FromJson(json);
				return cfg;
			}
			catch
			{
				return null;
			}
		}

		public FA18Configuration Clone()
		{
			var json = ToJson();
			var cfg = FromJson(json);
			return cfg;
		}

		public void CopyConfiguration(FA18Configuration cfg)
		{
			if (cfg.Waypoints != null)
			{
				Waypoints = cfg.Waypoints;
			}
			if (cfg.Radios != null)
			{
				Radios = cfg.Radios;
			}
			if (cfg.Misc != null)
			{
				Misc = cfg.Misc;
			}
			if (cfg.Sequences != null)
			{
				Sequences = cfg.Sequences;
			}
			if (cfg.PrePlanned != null)
			{
				PrePlanned = cfg.PrePlanned;
			}
			if (cfg.Radios != null)
			{
				Radios = cfg.Radios;
			}
			if (cfg.CMS != null)
			{
				CMS = cfg.CMS;
			}
		}

		IConfiguration IConfiguration.Clone()
		{
			return Clone();
		}
	}
}
