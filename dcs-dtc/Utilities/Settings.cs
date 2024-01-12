using Newtonsoft.Json;

namespace DTC.Utilities
{
    public static class Settings
    {
        private class SettingsData
        {
            public int TCPSendPort;
            public int UDPReceivePort;
            public int StrikeEagleCommandDelayMs;
            public int HornetCommandDelayMs;
            public int ViperCommandDelayMs;
            public bool AlwaysOnTop;
            public bool SkipDCSInstallCheck;
            public string LuaInstallFolderStable;
            public string LuaInstallStable;
            public string LuaInstallFolderOpenBeta;
            public string LuaInstallOpenBeta;
            public string CaptureDialogShortcut;
            public int MainWindowX;
            public int MainWindowY;
        }

        private static SettingsData currentSettings;

        public static bool LuaInstallStable
        {
            get
            {
                LoadSettings();

                if (string.IsNullOrEmpty(currentSettings.LuaInstallStable))
                {
                    return true;
                }

                return bool.Parse(currentSettings.LuaInstallStable);
            }
            set
            {
                currentSettings.LuaInstallStable = value.ToString();
                SaveSettings();
            }
        }

        public static bool LuaInstallOpenBeta
        {
            get
            {
                LoadSettings();

                if (string.IsNullOrEmpty(currentSettings.LuaInstallOpenBeta))
                {
                    return true;
                }

                return bool.Parse(currentSettings.LuaInstallOpenBeta);
            }
            set
            {
                currentSettings.LuaInstallOpenBeta = value.ToString();
                SaveSettings();
            }
        }

        public static string LuaInstallFolderStable
        {
            get
            {
                LoadSettings();
                return currentSettings.LuaInstallFolderStable;
            }
            set
            {
                currentSettings.LuaInstallFolderStable = value;
                SaveSettings();
            }
        }

        public static string LuaInstallFolderOpenBeta
        {
            get
            {
                LoadSettings();
                return currentSettings.LuaInstallFolderOpenBeta;
            }
            set
            {
                currentSettings.LuaInstallFolderOpenBeta = value;
                SaveSettings();
            }
        }

        public static bool AlwaysOnTop
        {
            get
            {
                LoadSettings();
                return currentSettings.AlwaysOnTop;
            }
            set
            {
                currentSettings.AlwaysOnTop = value;
                SaveSettings();
            }
        }

        public static bool SkipDCSInstallCheck
        {
            get
            {
                LoadSettings();
                return currentSettings.SkipDCSInstallCheck;
            }
            set
            {
                currentSettings.SkipDCSInstallCheck = value;
                SaveSettings();
            }
        }

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

        public static int StrikeEagleCommandDelayMs
        {
            get
            {
                LoadSettings();
                return currentSettings.StrikeEagleCommandDelayMs;
            }
            set
            {
                currentSettings.StrikeEagleCommandDelayMs = value;
                SaveSettings();
            }
        }

        public static int ViperCommandDelayMs
        {
            get
            {
                LoadSettings();
                return currentSettings.ViperCommandDelayMs;
            }
            set
            {
                currentSettings.ViperCommandDelayMs = value;
                SaveSettings();
            }
        }

        public static int HornetCommandDelayMs
        {
            get
            {
                LoadSettings();
                return currentSettings.HornetCommandDelayMs;
            }
            set
            {
                currentSettings.HornetCommandDelayMs = value;
                SaveSettings();
            }
        }

        public static string CaptureDialogShortcut
        {
            get
            {
                LoadSettings();
                return currentSettings.CaptureDialogShortcut;
            }
            set
            {
                currentSettings.CaptureDialogShortcut = value;
                SaveSettings();
            }
        }

        public static int MainWindowX
        {
            get
            {
                LoadSettings();
                return currentSettings.MainWindowX;
            }
            set
            {
                currentSettings.MainWindowX = value;
                SaveSettings();
            }
        }

        public static int MainWindowY
        {
            get
            {
                LoadSettings();
                return currentSettings.MainWindowY;
            }
            set
            {
                currentSettings.MainWindowY = value;
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
            }

            if (obj.TCPSendPort == 0)
            {
                obj.TCPSendPort = 43001;
            }
            if (obj.UDPReceivePort == 0)
            {
                obj.UDPReceivePort = 43000;
            }
            if (obj.StrikeEagleCommandDelayMs < 70)
            {
                obj.StrikeEagleCommandDelayMs = 70;
            }
            if (obj.ViperCommandDelayMs < 220)
            {
                obj.ViperCommandDelayMs = 220;
            }
            if (obj.HornetCommandDelayMs < 220)
            {
                obj.HornetCommandDelayMs = 220;
            }
            if (obj.CaptureDialogShortcut == null)
            {
                obj.CaptureDialogShortcut = "Ctrl+Shift+d";
            }

            currentSettings = obj;

            SaveSettings();
        }
    }
}
