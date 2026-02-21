using DTC.New.Presets.V2.Aircrafts.CH47F;
using DTC.New.Presets.V2.Aircrafts.CH47F.Systems;
using DTC.New.UI.Base;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.CH47F;

internal class CH47FCapture : WaypointCapture<Waypoint, WaypointSystem>
{
    private readonly CH47FPage page;
    private readonly CH47FConfiguration cfg;

    public CH47FCapture(CH47FPage page, CH47FConfiguration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        var configBefore = (CH47FConfiguration)cfg.Clone();

        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CaptureSteerpoints(WaypointCaptureData data, CH47FConfiguration cfg)
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

            CommonAddWaypoint(wpt, cfg.WaypointsCapture, cfg.Waypoints);
        }

        cfg.Waypoints.ReorderBySequence();

        page.SavePreset();
        page.GetWaypointsPage().RefreshList();
    }

    private void UploadCapture(CH47FConfiguration cfgBefore, CH47FConfiguration cfgAfter)
    {
        var cfgUpload = (CH47FConfiguration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload, true);
    }

    private static void RemoveIdenticalSteerpoints(CH47FConfiguration cfgBefore, CH47FConfiguration cfgAfter, CH47FConfiguration cfgUpload)
    {
        var wptsToRemove = new List<Waypoint>();

        foreach (var wptAfter in cfgAfter.Waypoints.Waypoints)
        {
            var wptBefore = cfgBefore.Waypoints.GetBySequence(wptAfter.Sequence);
            if (wptBefore != null)
            {
                if (cfgAfter.Waypoints.IsEqual(wptBefore, wptAfter))
                {
                    wptsToRemove.Add(wptBefore);
                }
            }
        }

        foreach (var wpt in wptsToRemove)
        {
            cfgUpload.Waypoints.Waypoints.Remove(cfgUpload.Waypoints.GetBySequence(wpt.Sequence));
        }
    }
}
