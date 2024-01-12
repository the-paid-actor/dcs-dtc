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
            return FA18V1V2Loader.GetV2(s);
        }
        else if (type == typeof(F16Configuration))
        {
            return F16V1V2Loader.GetV2(s);
        }
        else if (type == typeof(F15EConfiguration))
        {
            return F15EV1V2Loader.GetV2(s);
        }
        else
        {
            throw new Exception($"Unknown configuration type {type}");
        }
    }
}
