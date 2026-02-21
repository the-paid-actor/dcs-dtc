using DTC.New.Presets.V2.Aircrafts.A10;
using DTC.New.Presets.V2.Aircrafts.A10.Systems;
using DTC.Utilities;
using DTC.Utilities.Network;
using System.Collections.Generic;


namespace DTC.New.UI.Aircrafts.A10;

internal class A10Capture
{
    private readonly A10Page page;
    private readonly A10Configuration cfg;

    public A10Capture(A10Page page, A10Configuration cfg)
    {
        this.page = page;
        this.cfg = cfg;
    }

    public void CaptureReceived(WaypointCaptureData data)
    {
        var configBefore = (A10Configuration)cfg.Clone();

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

        if (data.upload)
        {
            UploadCapture(configBefore, cfg);
        }
    }
    private void UploadCapture(A10Configuration cfgBefore, A10Configuration cfgAfter)
    {  
        var cfgUpload = (A10Configuration)cfgAfter.Clone();
        cfgUpload.Upload = new UploadSystem();

       // RemoveIdenticalSteerpoints(cfgBefore, cfgAfter, cfgUpload);

        if (cfgUpload.Waypoints.Waypoints.Count > 0)
        {
            cfgUpload.Upload.Waypoints = true;
        }

        page.UploadToJet(cfgUpload, true);
    }
}
