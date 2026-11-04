using DTC.New.Presets.V2.Aircrafts.KA50;
using DTC.New.Presets.V2.Aircrafts.KA50.Systems;
using DTC.New.UI.Base;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.KA50;

internal class KA50Capture : WaypointCapture<Waypoint, WaypointSystem>
{
    private readonly KA50Page page;
    private readonly KA50Configuration cfg;

    public KA50Capture(KA50Page page, KA50Configuration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        var configBefore = (KA50Configuration)cfg.Clone();

        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CaptureSteerpoints(WaypointCaptureData data, KA50Configuration cfg)
    {
        foreach (var d in data.data)
        {
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToDegreesMinutesTenths();
            var wpt = new Waypoint
            {
                Latitude = coord.Lat,
                Longitude = coord.Lon,
                Elevation = int.Parse(d.elevation),
                Target = false
            };

            WaypointSystem wptSystem = cfg.Waypoints;

            CommonAddWaypoint(wpt, cfg.WaypointsCapture, wptSystem);
        }

        cfg.Waypoints.Waypoints.RemoveAll(wpt =>
            wpt.Sequence < WaypointSystem.FirstSteerpoint || wpt.Sequence > WaypointSystem.LastSteerpoint);
        cfg.Waypoints.ReorderBySequence();

        page.SavePreset();
        page.GetWaypointsPage().RefreshList();
    }

    private void UploadCapture(KA50Configuration cfgBefore, KA50Configuration cfgAfter)
    {
        var cfgUpload = (KA50Configuration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload, true);
    }

    private static void RemoveIdenticalSteerpoints(KA50Configuration cfgBefore, KA50Configuration cfgAfter, KA50Configuration cfgUpload)
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
