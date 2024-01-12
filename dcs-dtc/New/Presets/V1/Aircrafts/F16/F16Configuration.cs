using DTC.Utilities;
using Newtonsoft.Json;

namespace DTC.New.Presets.V1.Aircrafts.F16;

public class F16Configuration : IConfiguration
{
    public int Version { get; } = 1;

    public WaypointSystem Waypoints = new WaypointSystem();
    public RadioSystem Radios = new RadioSystem();
    public CMSystem CMS = new CMSystem();
    public MFDSystem MFD = new MFDSystem();
    public HARMSystem HARM = new HARMSystem();
    public HTSSystem HTS = new HTSSystem();
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

    public static F16Configuration FromJson(string s)
    {
        try
        {
            var cfg = JsonConvert.DeserializeObject<F16Configuration>(s);
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
        if (CMS != null)
        {
            CMS.AfterLoadFromJson();
        }
        FixWaypointCoordinateFormat();
    }

    private void FixWaypointCoordinateFormat()
    {
        if (this.Waypoints == null) return;

        foreach (var wpt in this.Waypoints.Waypoints)
        {
            if (!wpt.Latitude.Contains("°"))
            {
                var parts = wpt.Latitude.Split('.');
                wpt.Latitude = $"{parts[0]}°{parts[1]}.{parts[2]}’";
            }
            if (!wpt.Longitude.Contains("°"))
            {
                var parts = wpt.Longitude.Split('.');
                wpt.Longitude = $"{parts[0]}°{parts[1]}.{parts[2]}’";
            }
        }
    }

    public static F16Configuration FromCompressedString(string s)
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

    public F16Configuration Clone()
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
