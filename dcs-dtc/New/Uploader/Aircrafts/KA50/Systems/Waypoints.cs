using DTC.New.Presets.V2.Aircrafts.KA50.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.KA50;

public partial class KA50Uploader
{
    private void BuildWaypoints(bool pilot)
    {
        if (!config.Upload.Waypoints || config.Waypoints == null || !config.Waypoints.HasWaypoints())
        {
            return;
        }

        var entries = new List<string>();
        foreach (var wpt in config.Waypoints.Waypoints
            .Where(wpt => wpt.Sequence >= WaypointSystem.FirstSteerpoint && wpt.Sequence <= WaypointSystem.LastSteerpoint)
            .OrderBy(wpt => wpt.Sequence))
        {
            var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
            if (coord == null)
            {
                continue;
            }

            var lat = coord.ToPvi800Latitude();
            var lon = coord.ToPvi800Longitude();
            var latNeg = lat.StartsWith("-") ? 1 : 0;
            var lonNeg = lon.StartsWith("-") ? 1 : 0;
            lat = lat.TrimStart('-');
            lon = lon.TrimStart('-');

            entries.Add($"EnterWaypoint({wpt.Sequence}, \"{lat}\", {latNeg}, \"{lon}\", {lonNeg})");
        }

        if (entries.Count == 0)
        {
            return;
        }

        Cmd(new CustomCommand("BeginWaypointUpload()"));
        foreach (var entry in entries)
        {
            Cmd(new CustomCommand(entry));
        }
        Cmd(new CustomCommand("EndWaypointUpload()"));
    }
}
