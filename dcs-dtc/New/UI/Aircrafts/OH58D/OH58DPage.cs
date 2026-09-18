using DTC.New.Presets.V2.Aircrafts.OH58D;
using DTC.New.Presets.V2.Aircrafts.OH58D.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.OH58D.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.OH58D;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.OH58D;

public class OH58DPage : AircraftPage
{
    private readonly OH58DCapture capture;

    public OH58DPage(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        capture = new(this, this.Configuration);
    }

    public new OH58DConfiguration Configuration
    {
        get { return (OH58DConfiguration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        if (cfg.Upload == null) cfg.Upload = new();
        if (cfg.WaypointsCapture == null) cfg.WaypointsCapture = new();
        if (cfg.Waypoints == null) cfg.Waypoints = new();
        if (cfg.Radios == null) cfg.Radios = new();

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),
            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),
            new WaypointsPage<Waypoint>(this, Configuration.Waypoints, null, nameof(Configuration.Waypoints), "Waypoints"),
            new Radios6Page(this)
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        this.UploadToJet(this.Configuration, pilot);
    }

    public void UploadToJet(OH58DConfiguration cfg, bool pilot)
    {
        var upload = new OH58DUploader((OH58DAircraft)this.aircraft, cfg);
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
