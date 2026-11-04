using DTC.New.Presets.V2.Aircrafts.KA50;
using DTC.New.Presets.V2.Aircrafts.KA50.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.KA50.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.KA50;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.KA50;

public class KA50Page : AircraftPage
{
    private readonly KA50Capture capture;

    public KA50Page(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        capture = new(this, this.Configuration);
    }

    public new KA50Configuration Configuration
    {
        get { return (KA50Configuration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        if (cfg.Upload == null) cfg.Upload = new();
        if (cfg.WaypointsCapture == null) cfg.WaypointsCapture = new();
        if (cfg.Waypoints == null) cfg.Waypoints = new();
        if (RoundWaypointsToTenths(cfg.Waypoints))
        {
            SavePreset();
        }

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),
            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),
            new WaypointsPage<Waypoint>(this, Configuration.Waypoints, null, nameof(Configuration.Waypoints), "Waypoints (PVI 1-6)")
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        this.UploadToJet(this.Configuration, pilot);
    }

    public void UploadToJet(KA50Configuration cfg, bool pilot)
    {
        var upload = new KA50Uploader((KA50Aircraft)this.aircraft, cfg);
        upload.Execute(pilot);
    }

    protected override void WaypointCaptureReceived(WaypointCaptureData data)
    {
        capture.CaptureReceived(data);
    }

    private static bool RoundWaypointsToTenths(WaypointSystem waypoints)
    {
        var changed = false;
        foreach (var wpt in waypoints.Waypoints)
        {
            var coord = Coordinate.FromString(wpt.Latitude, wpt.Longitude);
            if (coord == null)
            {
                continue;
            }

            var rounded = coord.ToDegreesMinutesTenths();
            if (wpt.Latitude != rounded.Lat || wpt.Longitude != rounded.Lon)
            {
                wpt.Latitude = rounded.Lat;
                wpt.Longitude = rounded.Lon;
                changed = true;
            }
        }

        return changed;
    }

    public WaypointsPage<Waypoint> GetWaypointsPage()
    {
        return (WaypointsPage<Waypoint>)this.GetPageOfType<WaypointsPage<Waypoint>>();
    }
}
