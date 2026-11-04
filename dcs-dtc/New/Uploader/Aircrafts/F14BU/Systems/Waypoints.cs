using DTC.New.Presets.V2.Aircrafts.F14BU.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F14BU;

public partial class F14BUUploader
{
    private void BuildWaypoints(bool pilot)
    {
        if (config.Upload.Waypoints && config.Waypoints != null && config.Waypoints.HasWaypoints())
        {
            UploadPoints(config.Waypoints, true);
        }
    }

    private static string ToLuaString(string value)
    {
        return "\"" + value
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\r", "")
            .Replace("\n", "") + "\"";
    }

    private void UploadPoints(WaypointSystem<Waypoint> wptList, bool fullSync)
    {
        if (config.Waypoints == null || !config.Waypoints.HasWaypoints())
        {
            return;
        }

        Cmd(CDNU.Clear);

        Cmd(CDNU.Idx);
        Cmd(Wait(300));
        Cmd(new CustomCommand($"FindLSKCodes()"));


        Cmd(CDNU.Dir);
        Cmd(Wait(300));
       // Cmd(new CustomCommand($"EndFlightPlan()"));


        foreach (var wpt in config.Waypoints.Waypoints)
        {
            var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
            var mgrs = coord.ToMGRSEightDigits().Replace(" ", "");
            var waypointName = string.IsNullOrEmpty(wpt.Name)
                ? ""
                : "/" + wpt.Name.Substring(0, Math.Min(5, wpt.Name.Length));
            Cmd(new CustomCommand($"EndFlightPlan({wpt.Sequence},{ToLuaString(waypointName)},{ToLuaString(mgrs)},{wpt.Elevation})"));
        }
    }
}
