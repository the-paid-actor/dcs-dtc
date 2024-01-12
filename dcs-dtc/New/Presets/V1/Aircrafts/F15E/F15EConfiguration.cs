using DTC.Utilities;
using Newtonsoft.Json;

namespace DTC.New.Presets.V1.Aircrafts.F15E;

public class F15EConfiguration : IConfiguration
{
    public int Version { get; } = 1;

    public WaypointSystem Waypoints = new WaypointSystem();
    public RadioSystem Radios = new RadioSystem();
    public DisplaySystem Displays = new DisplaySystem();
    public MiscSystem Misc = new MiscSystem();

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

    public static F15EConfiguration FromJson(string s)
    {
        try
        {
            var cfg = JsonConvert.DeserializeObject<F15EConfiguration>(s);
            cfg.AfterLoadFromJson();
            return cfg;
        }
        catch
        {
            return null;
        }
    }

    public void AfterLoadFromJson()
    {
        if (this.Displays != null)
        {
            if (this.Displays.WSO == null) this.Displays.WSO = new WSODisplays();

            if (this.Displays.WSO.LeftMPCD == null) this.Displays.WSO.LeftMPCD = new DisplayConfig();
            if (this.Displays.WSO.LeftMPD == null) this.Displays.WSO.LeftMPD = new DisplayConfig();
            if (this.Displays.WSO.RightMPD == null) this.Displays.WSO.RightMPD = new DisplayConfig();
            if (this.Displays.WSO.RightMPCD == null) this.Displays.WSO.RightMPCD = new DisplayConfig();
        }
    }

    public static F15EConfiguration FromCompressedString(string s)
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

    public F15EConfiguration Clone()
    {
        var json = ToJson();
        var cfg = FromJson(json);
        return cfg;
    }

    IConfiguration IConfiguration.Clone()
    {
        return Clone();
    }
}
