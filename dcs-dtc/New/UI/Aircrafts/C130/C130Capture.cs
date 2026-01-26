using DTC.New.Presets.V2.Aircrafts.C130;
using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.C130;

internal class C130Capture
{
    private readonly C130Page page;
    private readonly C130Configuration cfg;

    public C130Capture(C130Page page, C130Configuration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        foreach (var d in data.data)
        {
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToF15EFormat();
            var wpt = new Waypoint
            {
                Latitude = coord.Lat,
                Longitude = coord.Lon,
                Elevation = int.Parse(d.elevation),
                Target = d.target
            };

            wpt.Sequence = cfg.Waypoints.GetNextSequence();
            if (wpt.Sequence == 0)
            {
                wpt.Sequence = cfg.Waypoints.GetFirstAllowedSequence();
            }

            wpt.Name = wpt.Target ? $"TGT {wpt.Sequence}" : $"STPT {wpt.Sequence}";
            cfg.Waypoints.Add(wpt);
        }

        cfg.Waypoints.ReorderBySequence();
        page.SavePreset();
        page.GetWaypointsPage().RefreshList();
    }
}
