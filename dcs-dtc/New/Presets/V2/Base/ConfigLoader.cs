using DTC.New.Presets.V2.Base.V1V2;
using DTC.Utilities;
using Newtonsoft.Json;

namespace DTC.New.Presets.V2.Base;

internal class ConfigLoader
{
    public static Dictionary<string, IConfiguration> LoadPresets(IAircraft ac)
    {
        var path = FileStorage.GetAircraftPresetsPath(ac);
        var dic = new Dictionary<string, IConfiguration>();
        if (Directory.Exists(path))
        {
            var files = Directory.EnumerateFiles(path, "*.json");
            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var type = ac.GetAircraftConfigurationType();
                var cfg = GetConfiguration(json, type);
                dic.Add(Path.GetFileNameWithoutExtension(file), (IConfiguration)cfg);
            }
        }
        return dic;
    }

    public static Configuration FromJson(string s, Type type)
    {
        try
        {
            return GetConfiguration(s, type);
        }
        catch
        {
            return null;
        }
    }

    private static Configuration GetConfiguration(string s, Type type)
    {
        dynamic dynCfg = JsonConvert.DeserializeObject(s);
        Configuration cfg;
        if ((dynCfg.Version == null || dynCfg.Version == 1) && (dynCfg.Upload == null))
        {
            cfg = ConfigV1V2.Convert(s, type);
        }
        else
        {
            cfg = (Configuration)JsonConvert.DeserializeObject(s, type);
        }
        cfg.AfterLoadFromJson();
        return cfg;
    }
}
