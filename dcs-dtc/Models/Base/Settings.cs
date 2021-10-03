using Newtonsoft.Json;

namespace DTC.Models.Base
{
	public static class Settings
	{
		private class SettingsData
		{
			public int TCPSendPort;
			public int UDPReceivePort;
			public int CommandDelayMs;
		}

		private static SettingsData currentSettings;

		public static int TCPSendPort
		{
			get
			{
				LoadSettings();
				return currentSettings.TCPSendPort;
			}
			set
			{
				currentSettings.TCPSendPort = value;
				SaveSettings();
			}
		}

		public static int UDPReceivePort
		{
			get
			{
				LoadSettings();
				return currentSettings.UDPReceivePort;
			}
			set
			{
				currentSettings.UDPReceivePort = value;
				SaveSettings();
			}
		}

		public static int CommandDelayMs
		{
			get
			{
				LoadSettings();
				return currentSettings.CommandDelayMs;
			}
			set
			{
				currentSettings.CommandDelayMs = value;
				SaveSettings();
			}
		}

		private static void SaveSettings()
		{
			var json = JsonConvert.SerializeObject(currentSettings);
			FileStorage.PersistSettingsFile(json);
		}

		private static void LoadSettings()
		{
			if (currentSettings != null) {
				return;
			}

			var json = FileStorage.LoadSettingsFile();
			SettingsData obj = null;
			try
			{
				obj = JsonConvert.DeserializeObject<SettingsData>(json);
			}
			catch {}

			if (obj == null)
			{
				obj = new SettingsData();
				obj.TCPSendPort = 43001;
				obj.UDPReceivePort = 43000;
				obj.CommandDelayMs = 100;
			}

			currentSettings = obj;
		}
	}
}
