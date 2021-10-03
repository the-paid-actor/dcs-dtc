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

		public static void PersistAutoSaveFile(IConfiguration cfg)
		{
			var json = cfg.ToJson();
			File.WriteAllText(GetAutoSaveFilePath(), json);
		}

		public static string LoadFile(string path)
		{
			if (File.Exists(path))
			{
				return File.ReadAllText(path);
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
