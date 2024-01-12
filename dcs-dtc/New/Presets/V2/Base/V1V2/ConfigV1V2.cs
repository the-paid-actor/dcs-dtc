using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;
using Newtonsoft.Json;

namespace DTC.New.Presets.V2.Base.V1V2;

internal class ConfigV1V2
{
    public static Configuration Convert(string s, Type type)
    {
        if (type == typeof(FA18Configuration))
        {
            var cfg = JsonConvert.DeserializeObject<V1.Aircrafts.FA18.FA18Configuration>(s);
            return FA18V1V2Loader.GetV2(cfg);
        }
        else if (type == typeof(F16Configuration))
        {
            var cfg = JsonConvert.DeserializeObject<V1.Aircrafts.F16.F16Configuration>(s);
            return F16V1V2Loader.GetV2(cfg);
        }
        else if (type == typeof(F15EConfiguration))
        {
            var cfg = JsonConvert.DeserializeObject<V1.Aircrafts.F15E.F15EConfiguration>(s);
            return F15EV1V2Loader.GetV2(cfg);
        }
        else
        {
            throw new Exception($"Unknown configuration type {type}");
        }
    }
}
