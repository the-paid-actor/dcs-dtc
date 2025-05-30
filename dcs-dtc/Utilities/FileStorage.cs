﻿using Newtonsoft.Json;

namespace DTC.Utilities;

public class FileStorage
{
    private static string storageFolder;

    public static string GetCurrentFolder()
    {
        return System.AppContext.BaseDirectory;
    }

    private static string GetStorageFolder()
    {
        if (storageFolder == null)
        {
            try
            {
                storageFolder = IniFile.ReadValue(Path.Combine(GetCurrentFolder(), "dtc.ini"), "DTC", "StorageFolder");
            }
            catch
            {
            }

            if (string.IsNullOrEmpty(storageFolder))
            {
                storageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DCS-DTC");
            }

            try
            {
                Directory.CreateDirectory(storageFolder);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to create storage folder: {storageFolder}. Check if the path is correct and that you have appropriate permissions.", ex);
            }
        }

        return storageFolder;
    }

    private static void CopyDefaultSettingsFile(string path)
    {
        var defaultSettings = Path.Combine(GetCurrentFolder(), "dtc-settings.json");
        File.Copy(defaultSettings, path);
    }

    private static string GetSettingsFilePath()
    {
        var path = GetStorageFolder();
        return Path.Combine(path, "dtc-settings.json");
    }

    private static string GetAirbasesFilePath()
    {
        var path = GetCurrentFolder();
        return Path.Combine(path, "dtc-airbases.json");
    }

    private static string GetEmittersFilePath()
    {
        var path = GetCurrentFolder();
        return Path.Combine(path, "dtc-emitters.json");
    }

    private static void WriteFile(string path, string content)
    {
        var retries = 3;
        var interval = 1000;

        while (retries > 0)
        {
            try
            {
                File.WriteAllText(path, content);
                return;
            }
            catch (IOException)
            {
                retries--;
                if (retries == 0)
                {
                    throw;
                }
                Thread.Sleep(interval);
            }
        }
    }

    public static void PersistSettingsFile(string json)
    {
        WriteFile(GetSettingsFilePath(), json);
    }

    public static string GetAircraftPresetsPath(IAircraft ac)
    {
        return Path.Combine(GetStorageFolder(), "Presets", ac.GetAircraftModelName());
    }

    public static Dictionary<string, IConfiguration> LoadPresets(IAircraft ac)
    {
        var path = GetAircraftPresetsPath(ac);
        var dic = new Dictionary<string, IConfiguration>();
        if (Directory.Exists(path))
        {
            var files = Directory.EnumerateFiles(path, "*.json");
            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var type = ac.GetAircraftConfigurationType();
                var cfg = JsonConvert.DeserializeObject(json, type);
                ((IConfiguration)cfg).AfterLoadFromJson();
                dic.Add(Path.GetFileNameWithoutExtension(file), (IConfiguration)cfg);
            }
        }
        return dic;
    }

    public static void DeletePreset(IAircraft ac, IPreset preset)
    {
        var path = Path.Combine(GetAircraftPresetsPath(ac), preset.Name + ".json");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void PersistPreset(IAircraft ac, IPreset preset)
    {
        var path = GetAircraftPresetsPath(ac);
        Directory.CreateDirectory(path);
        var json = JsonConvert.SerializeObject(preset.Configuration, Formatting.Indented, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        });
        WriteFile(Path.Combine(path, preset.Name + ".json"), json);
    }

    public static bool PresetExists(IAircraft ac, string name)
    {
        var path = GetAircraftPresetsPath(ac);
        return File.Exists(Path.Combine(path, name + ".json"));
    }

    public static void RenamePresetFile(IAircraft aircraft, IPreset preset, string oldName)
    {
        var path = GetAircraftPresetsPath(aircraft);
        if (Directory.Exists(path))
        {
            var file = Path.Combine(path, oldName + ".json");
            File.Move(file, Path.Combine(path, preset.Name + ".json"), true);
        }
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
        if (!File.Exists(path))
        {
            CopyDefaultSettingsFile(path);
        }
        return File.ReadAllText(path);
    }

    public static Theater[] LoadAirbases()
    {
        try
        {
            Theater[] list = null;
            var path = GetAirbasesFilePath();
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<Theater[]>(json);
                list = SortAirbases(list);
            }
            return list;
        }
        catch
        {
        }
        return null;
    }

    private static Theater[] SortAirbases(Theater[] list)
    {
        foreach (var theater in list)
        {
            Array.Sort(theater.Airbases, (a, b) => a.Name.CompareTo(b.Name));
        }
        Array.Sort(list, (a, b) => a.Name.CompareTo(b.Name));
        return list;
    }

    public static Emitter[] LoadEmitters()
    {
        var path = GetEmittersFilePath();
        var customPath = Path.Combine(GetStorageFolder(), "dtc-emitters.json");
        var json = File.ReadAllText(path);
        string customJson = null;
        if (File.Exists(customPath))
        {
            customJson = File.ReadAllText(customPath);
        }
        var arr = JsonConvert.DeserializeObject<Emitter[]>(json);
        if (customJson != null)
        {
            var customArr = JsonConvert.DeserializeObject<Emitter[]>(customJson);
            if (customArr != null)
            {
                var list = arr.ToList();
                list.AddRange(customArr);
                arr = list.ToArray();
            }
        }
        return arr;
    }

    public static void Save(IConfiguration cfg, string path)
    {
        var json = cfg.ToJson();
        WriteFile(path, json);
    }
}