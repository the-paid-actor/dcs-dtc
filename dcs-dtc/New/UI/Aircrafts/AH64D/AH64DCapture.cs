using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.AH64D;

internal class AH64DCapture
{
    private readonly AH64DPage page;
    private readonly AH64DConfiguration cfg;

    public AH64DCapture(AH64DPage page, AH64DConfiguration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        //var configBefore = (AH64DConfiguration)cfg.Clone();

        CaptureSteerpoints(data, cfg);

        //if (data.upload)
        //{
        //    UploadCapture(configBefore, cfg);
        //}
    }

    private void CaptureSteerpoints(WaypointCaptureData data, AH64DConfiguration cfg)
    {
        foreach (var d in data.data)
        {
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToDegreesMinutesThousandths();
            var wpt = new Waypoint();
            wpt.Latitude = coord.Lat;
            wpt.Longitude = coord.Lon;
            wpt.Elevation = int.Parse(d.elevation);
            wpt.Target = d.target;
            wpt.PointType = d.pointType;
            wpt.Identifier = d.identifier;
            wpt.Free = d.free?.ToUpper();

            if (wpt.PointType == null)
            {
                if (!wpt.Target)
                {
                    wpt.PointType = "WP";
                    wpt.Identifier = "WP";
                }
                else
                {
                    wpt.PointType = "TG";
                    wpt.Identifier = "TG";
                }
            }

            if (wpt.PointType == "WP" || wpt.PointType == "HZ")
            {
                if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfList)
                {
                    wpt.Sequence = cfg.Waypoints.GetNextSequence();
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = cfg.Waypoints.GetNextSequenceOfFirstGap();
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToRange)
                {
                    wpt.Sequence = cfg.Waypoints.GetNextSequenceFromSequence(cfg.WaypointsCapture.NavPointsRangeFrom);
                }
                wpt.Name = "STPT " + wpt.Sequence;
                cfg.Waypoints.Add(wpt);
            }
            else if (wpt.PointType == "GC" || wpt.PointType == "FC" || wpt.PointType == "EC")
            {
                wpt.Sequence = cfg.ControlMeasures.GetNextSequence();
                wpt.Name = "STPT " + wpt.Sequence;
                cfg.ControlMeasures.Add(wpt);
            }
            else if (wpt.PointType == "TG" || wpt.PointType == "TH")
            {
                if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToEndOfList)
                {
                    wpt.Sequence = cfg.Targets.GetNextSequence();
                }
                else if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = cfg.Targets.GetNextSequenceOfFirstGap();
                }
                else if (cfg.WaypointsCapture.TgtPointsMode == SteerpointCaptureMode.AddToRange)
                {
                    wpt.Sequence = cfg.Targets.GetNextSequenceFromSequence(cfg.WaypointsCapture.TgtPointsRangeFrom);
                }
                wpt.Name = "TGT " + wpt.Sequence;
                wpt.Target = true;
                cfg.Targets.Add(wpt);
            }
        }

        cfg.Waypoints.ReorderBySequence();
        cfg.ControlMeasures.ReorderBySequence();
        cfg.Targets.ReorderBySequence();

        page.SavePreset();
        page.RefreshRoutePages();
    }

    //private void UploadCapture(AH64DConfiguration cfgBefore, AH64DConfiguration cfgAfter)
    //{
    //    var cfgUpload = (AH64DConfiguration)cfgAfter.Clone();
    //    cfgUpload.Upload = new UploadSystem();

    //    RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

    //    if (cfgUpload.Waypoints.Waypoints.Count > 0)
    //    {
    //        cfgUpload.Upload.Waypoints = true;
    //    }

    //    page.UploadToJet(cfgUpload);
    //}

    //private static void RemoveIdenticalSteerpoints(AH64DConfiguration cfgBefore, AH64DConfiguration cfgAfter, AH64DConfiguration cfgUpload)
    //{
    //    var wptsToRemove = new List<Waypoint>();

    //    foreach (var wptAfter in cfgAfter.Waypoints.Waypoints)
    //    {
    //        var wptBefore = cfgBefore.Waypoints.GetBySequence(wptAfter.Sequence);
    //        if (wptBefore != null)
    //        {
    //            if (cfgAfter.Waypoints.IsEqual(wptBefore, wptAfter))
    //            {
    //                wptsToRemove.Add(wptBefore);
    //            }
    //        }
    //    }

    //    foreach (var wpt in wptsToRemove)
    //    {
    //        cfgUpload.Waypoints.Waypoints.Remove(cfgUpload.Waypoints.GetBySequence(wpt.Sequence));
    //    }
    //}
}
