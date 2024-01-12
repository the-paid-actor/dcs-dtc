using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.F16;

internal class F16Capture
{
    private readonly F16Page page;
    private readonly F16Configuration cfg;

    public F16Capture(F16Page page, F16Configuration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        var configBefore = (F16Configuration)cfg.Clone();

        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CaptureSteerpoints(WaypointCaptureData data, F16Configuration cfg)
    {
        foreach (var d in data.data)
        {
            if (d.smart) continue;
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToF15EFormat();
            var wpt = new Waypoint();
            wpt.Latitude = coord.Lat;
            wpt.Longitude = coord.Lon;
            wpt.Elevation = int.Parse(d.elevation);
            wpt.Target = d.target;

            WaypointSystem wptSystem = cfg.Waypoints;

            if (!wpt.Target)
            {
                if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfList)
                {
                    wpt.Sequence = wptSystem.GetNextSequence();
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToRange)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceFromSequence(cfg.WaypointsCapture.NavPointsRangeFrom);
                }
                wpt.Name = "STPT " + wpt.Sequence;
                wptSystem.Add(wpt);
            }
            else
            {
                if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToEndOfList)
                {
                    wpt.Sequence = wptSystem.GetNextSequence();
                }
                else if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                }
                else if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToRange)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceFromSequence(cfg.WaypointsCapture.TgtPointsRangeFrom);
                }
                wpt.Name = "TGT " + wpt.Sequence;
                wptSystem.Add(wpt);
            }
        }

        cfg.Waypoints.ReorderBySequence();

        page.SavePreset();
        page.GetWaypointsPage().RefreshList();
    }

    private void UploadCapture(F16Configuration cfgBefore, F16Configuration cfgAfter)
    {
        var cfgUpload = (F16Configuration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload);
    }

    private static void RemoveIdenticalSteerpoints(F16Configuration cfgBefore, F16Configuration cfgAfter, F16Configuration cfgUpload)
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
