using DTC.New.Presets.V2.Aircrafts.C130;
using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.C130.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.C130;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.C130;

public class C130Page : AircraftPage
{
    private readonly C130Capture capture;

    public C130Page(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        capture = new(this, this.Configuration);
    }

    public new C130Configuration Configuration
    {
        get { return (C130Configuration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {

        var cfg = Configuration;

        if (cfg.Upload == null) cfg.Upload = new();
        if (cfg.Waypoints == null) cfg.Waypoints = new();
        if (cfg.Radios == null) cfg.Radios = new();
        if (cfg.WaypointsCapture == null) cfg.WaypointsCapture = new();

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),
            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),
            new WaypointsPage<Waypoint>(this, cfg.Waypoints, null, nameof(cfg.Waypoints), "Waypoints"),
            new RadiosPage(this)
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        this.UploadToJet(this.Configuration, pilot);
    }

    public void UploadToJet(C130Configuration cfg, bool pilot)
    {
        var upload = new C130Uploader((C130Aircraft)this.aircraft, cfg);
        upload.Execute(pilot);
    }

    protected override void WaypointCaptureReceived(WaypointCaptureData data)
    {
        capture.CaptureReceived(data);
    }

    public WaypointsPage<Waypoint> GetWaypointsPage()
    {
        return (WaypointsPage<Waypoint>)this.GetPageOfType<WaypointsPage<Waypoint>>();
    }
}
