using DTC.Models.F16.CMS;
using DTC.Models.F16.MFD;
using DTC.Models.F16.Waypoints;
using DTC.Models.F16.Radios;
using Newtonsoft.Json;
using DTC.Models.Base;

namespace DTC.Models.F16
{
	public class F16Configuration : IConfiguration
	{
		public WaypointSystem Waypoints = new WaypointSystem();
		public RadioSystem Radios = new RadioSystem();
		public CMSystem CMS = new CMSystem();
		public MFDSystem MFD = new MFDSystem();

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

		public static F16Configuration FromAutoSaveFile()
		{
			var str = FileStorage.LoadAutoSaveFile();
			if (str != null)
			{
				return F16Configuration.FromJson(str);
			}
			return null;
		}

		public static F16Configuration FromJson(string s)
		{
			try
			{
				var cfg = JsonConvert.DeserializeObject<F16Configuration>(s);
				return cfg;
			}
			catch
			{
				return null;
			}
		}

		public static F16Configuration FromCompressedString(string s)
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

		public F16Configuration Clone()
		{
			var json = ToJson();
			var cfg = FromJson(json);
			return cfg;
		}

		public void CopyConfiguration(F16Configuration cfg)
		{
			if (cfg.Waypoints != null)
			{
				Waypoints = cfg.Waypoints;
			}
			if (cfg.CMS != null)
			{
				CMS = cfg.CMS;
			}
			if (cfg.Radios != null)
			{
				Radios = cfg.Radios;
			}
			if (cfg.MFD != null)
			{
				MFD = cfg.MFD;
			}
		}
	}
}
