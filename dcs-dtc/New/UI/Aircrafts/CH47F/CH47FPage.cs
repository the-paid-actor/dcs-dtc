using DTC.New.Presets.V2.Aircrafts.CH47F;
using DTC.New.Presets.V2.Aircrafts.CH47F.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.CH47F.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.CH47F;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.CH47F;

public class CH47FPage : AircraftPage
{
    private readonly CH47FCapture capture;

    public CH47FPage(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        capture = new(this, this.Configuration);
    }

    public new CH47FConfiguration Configuration
    {
        get { return (CH47FConfiguration)preset.Configuration; }
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

    public void UploadToJet(CH47FConfiguration cfg, bool pilot)
    {
        var upload = new CH47FUploader((CH47FAircraft)this.aircraft, cfg);
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
