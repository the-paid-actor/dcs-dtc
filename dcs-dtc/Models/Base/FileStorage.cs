using DTC.Models.DCS;
using Newtonsoft.Json;
using System.IO;

namespace DTC.Models.Base
{
	public class FileStorage
	{
		private static string GetAutoSaveFilePath()
		{
			var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
			return Path.Combine(path, "dtc-autosave.json");
		}

		private static string GetSettingsFilePath()
		{
			var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
			return Path.Combine(path, "dtc-settings.json");
		}

		private static string GetAirbasesFilePath()
		{
			var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
			return Path.Combine(path, "dtc-airbases.json");
		}

		public static void PersistSettingsFile(string json)
		{
			File.WriteAllText(GetSettingsFilePath(), json);
		}

		public static void PersistAutoSaveFile(IConfiguration cfg)
		{
			var json = cfg.ToJson();
			File.WriteAllText(GetAutoSaveFilePath(), json);
		}

		public static void PersistAirbasesFile(Theater[] theaters)
		{
			var json = JsonConvert.SerializeObject(theaters);
			File.WriteAllText(GetAirbasesFilePath(), json);
		}
		

		public static string LoadFile(string path)
		{
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}
			return null;
		}

		public static string LoadSettingsFile()
		{
			var path = GetSettingsFilePath();
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}
			return null;
		}

		public static Theater[] LoadAirbases()
		{
			try
			{
				var path = GetAirbasesFilePath();
				if (File.Exists(path))
				{
					var json = File.ReadAllText(path);
					return JsonConvert.DeserializeObject<Theater[]>(json);
				}
			}
			catch
			{
			}
			return null;
		}

		public static string LoadAutoSaveFile()
		{
			var path = GetAutoSaveFilePath();
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
			}
			return null;
		}

		public static void Save(IConfiguration cfg, string path)
		{
			var json = cfg.ToJson();
			File.WriteAllText(path, json);
		}
	}
}
