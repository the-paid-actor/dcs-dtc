using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.FA18;

internal class FA18Capture
{
    private readonly FA18Page page;
    private readonly FA18Configuration cfg;

    public FA18Capture(FA18Page page, FA18Configuration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        if (data.resetAllPP)
        {
            page.GetPrePlannedPage().ResetAllPP();
            return;
        }

        var configBefore = (FA18Configuration)cfg.Clone();

        CapturePP(data.data, cfg, configBefore);
        CaptureSteerpoints(data, cfg);

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }

    private void CapturePP(WaypointCaptureWptData[] data, FA18Configuration cfg, FA18Configuration cfgBefore)
    {
        foreach (var d in data)
        {
            if (!d.pp) continue;
            var coord = Coordinate.FromDCS(d.latitude, d.longitude).ToHornetPreplannedFormat();
            var elevation = int.Parse(d.elevation);
            cfg.PrePlanned.Stations[d.ppStation].PP[d.ppNumber] = new PrePlannedCoordinate() { Lat = coord.Lat, Lon = coord.Lon, Elev = elevation, Enabled = true };
            cfgBefore.PrePlanned.Stations[d.ppStation].PP[d.ppNumber] = new PrePlannedCoordinate();
        }

        page.SavePreset();
        page.GetPrePlannedPage().RefreshStations();
    }

    private void CaptureSteerpoints(WaypointCaptureData data, FA18Configuration cfg)
    {
        foreach (var d in data.data)
        {
            if (d.pp) continue;
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
                    if (wpt.Sequence == 0) wpt.Sequence = 1;
                }
                else if (cfg.WaypointsCapture.NavPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap)
                {
                    wpt.Sequence = wptSystem.GetNextSequenceOfFirstGap();
                    if (wpt.Sequence == 0) wpt.Sequence = 1;
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

    private void UploadCapture(FA18Configuration cfgBefore, FA18Configuration cfgAfter)
    {
        var cfgUpload = (FA18Configuration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

        RemoveIdenticalPrePlanned(cfgBefore, cfgAfter, cfgUpload);
        RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.PrePlanned.HasAnyPPEnabled())
        {
            cfgUpload.Upload.PrePlanned = true;
        }

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload);
    }

    private static void RemoveIdenticalPrePlanned(FA18Configuration cfgBefore, FA18Configuration cfgAfter, FA18Configuration cfgUpload)
    {
        foreach (var stationKV in cfgAfter.PrePlanned.Stations)
        {
            var stationAfter = stationKV.Value;
            foreach (var ppKV in stationAfter.PP)
            {
                var ppAfter = ppKV.Value;
                var ppBefore = cfgBefore.PrePlanned.Stations[stationKV.Key].PP[ppKV.Key];
                if (ppBefore != null)
                {
                    if (ppBefore.IsEqual(ppAfter))
                    {
                        cfgUpload.PrePlanned.Stations[stationKV.Key].PP[ppKV.Key].Enabled = false;
                    }
                }
            }
        }
    }

    private static void RemoveIdenticalSteerpoints(FA18Configuration cfgBefore, FA18Configuration cfgAfter, FA18Configuration cfgUpload)
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