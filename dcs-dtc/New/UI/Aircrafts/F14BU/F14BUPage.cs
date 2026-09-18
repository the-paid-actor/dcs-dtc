using DTC.New.Presets.V2.Aircrafts.F14BU;
using DTC.New.Presets.V2.Aircrafts.F14BU.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.F14BU.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.F14BU;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.F14BU;

public class F14BUPage : AircraftPage
{
    private readonly F14BUCapture capture;

    public F14BUPage(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        capture = new(this, this.Configuration);
    }

    public new F14BUConfiguration Configuration
    {
        get { return (F14BUConfiguration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        if (cfg.Upload == null) cfg.Upload = new();
        if (cfg.WaypointsCapture == null) cfg.WaypointsCapture = new();
        if (cfg.Waypoints == null) cfg.Waypoints = new();

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),
            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),
            new WaypointsPage<Waypoint>(this, Configuration.Waypoints, null, nameof(Configuration.Waypoints), "Waypoints")
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        this.UploadToJet(this.Configuration, pilot);
    }

    public void UploadToJet(F14BUConfiguration cfg, bool pilot)
    {
        var upload = new F14BUUploader((F14BUAircraft)this.aircraft, cfg);
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