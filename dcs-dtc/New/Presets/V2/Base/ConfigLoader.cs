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
            if (dynCfg.Aircraft != null)
            {
                type = GetTypeFromAircraft((string)dynCfg.Aircraft);
            }
            cfg = (Configuration)JsonConvert.DeserializeObject(s, type);
        }
        cfg.AfterLoadFromJson();
        return cfg;
    }

    private static Type GetTypeFromAircraft(string aircraft)
    {
        if (aircraft == "F16C")
        {
            return typeof(Aircrafts.F16.F16Configuration);
        }
        if (aircraft == "F15E")
        {
            return typeof(Aircrafts.F15E.F15EConfiguration);
        }
        if (aircraft == "FA18C")
        {
            return typeof(Aircrafts.FA18.FA18Configuration);
        }
        if (aircraft == "AH64D")
        {
            return typeof(Aircrafts.AH64D.AH64DConfiguration);
        }

        if (aircraft == "C130")
        {
            return typeof(Aircrafts.C130.C130Configuration);
        }

        if (aircraft == "A10")
        {
            return typeof(Aircrafts.A10.A10Configuration);
        }

        if (aircraft == "CH47F")
        {
            return typeof(Aircrafts.CH47F.CH47FConfiguration);
        }

        if (aircraft == "AV8B")
        {
            return typeof(Aircrafts.AV8B.AV8BConfiguration);
        }

        


        throw new NotImplementedException();
    }
}
