using DTC.New.Presets.V2.Aircrafts.AV8B;
using DTC.New.Presets.V2.Aircrafts.AV8B.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;
using DTC.Utilities.Network;
using System.Collections.Generic;

namespace DTC.New.UI.Aircrafts.AV8B;

internal class AV8BCapture
{
    private readonly AV8BPage page;
    private readonly AV8BConfiguration cfg;

    public AV8BCapture(AV8BPage page, AV8BConfiguration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {

        var configBefore = (AV8BConfiguration)cfg.Clone();

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



           /* wpt.Sequence = cfg.Waypoints.GetNextSequence();
            if (wpt.Sequence == 0)
            {
                wpt.Sequence = cfg.Waypoints.GetFirstAllowedSequence();
            }

            wpt.Name = wpt.Target ? $"TGT {wpt.Sequence}" : $"STPT {wpt.Sequence}";
            cfg.Waypoints.Add(wpt);
           */
        }

        cfg.Waypoints.ReorderBySequence();
        page.SavePreset();
        page.GetWaypointsPage().RefreshList();

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }


    }
    private void UploadCapture(AV8BConfiguration cfgBefore, AV8BConfiguration cfgAfter)
    {
        var cfgUpload = (AV8BConfiguration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        //RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload, true);
    }

    /* private static void RemoveIdenticalSteerpoints(AV8BConfiguration cfgBefore, AV8BConfiguration cfgAfter, AV8BConfiguration cfgUpload)
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
    */
}
