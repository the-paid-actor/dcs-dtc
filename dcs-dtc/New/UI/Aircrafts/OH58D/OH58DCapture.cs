using DTC.New.Presets.V2.Aircrafts.OH58D;
using DTC.New.Presets.V2.Aircrafts.OH58D.Systems;
using DTC.New.UI.Base;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.OH58D;

internal class OH58DCapture : WaypointCapture<Waypoint, WaypointSystem>
{
    private readonly OH58DPage page;
    private readonly OH58DConfiguration cfg;

    public OH58DCapture(OH58DPage page, OH58DConfiguration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        var configBefore = (OH58DConfiguration)cfg.Clone();

        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CaptureSteerpoints(WaypointCaptureData data, OH58DConfiguration cfg)
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

    private void UploadCapture(OH58DConfiguration cfgBefore, OH58DConfiguration cfgAfter)
    {
        var cfgUpload = (OH58DConfiguration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload, true);
    }

    private static void RemoveIdenticalSteerpoints(OH58DConfiguration cfgBefore, OH58DConfiguration cfgAfter, OH58DConfiguration cfgUpload)
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
