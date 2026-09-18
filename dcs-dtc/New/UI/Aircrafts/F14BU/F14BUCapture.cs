using DTC.New.Presets.V2.Aircrafts.F14BU;
using DTC.New.Presets.V2.Aircrafts.F14BU.Systems;
using DTC.New.UI.Base;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.F14BU;

internal class F14BUCapture : WaypointCapture<Waypoint, WaypointSystem>
{
    private readonly F14BUPage page;
    private readonly F14BUConfiguration cfg;

    public F14BUCapture(F14BUPage page, F14BUConfiguration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        var configBefore = (F14BUConfiguration)cfg.Clone();

        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CaptureSteerpoints(WaypointCaptureData data, F14BUConfiguration cfg)
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

            WaypointSystem wptSystem = cfg.Waypoints;

            CommonAddWaypoint(wpt, cfg.WaypointsCapture, wptSystem);
        }

        cfg.Waypoints.ReorderBySequence();

        page.SavePreset();
        page.GetWaypointsPage().RefreshList();
    }

    private void UploadCapture(F14BUConfiguration cfgBefore, F14BUConfiguration cfgAfter)
    {
        var cfgUpload = (F14BUConfiguration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload, true);
    }

    private static void RemoveIdenticalSteerpoints(F14BUConfiguration cfgBefore, F14BUConfiguration cfgAfter, F14BUConfiguration cfgUpload)
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
