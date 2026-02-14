using DTC.New.Presets.V2.Aircrafts.AV8B;
using DTC.New.Presets.V2.Aircrafts.AV8B.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.AV8B.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.AV8B;
using DTC.Utilities;
using DTC.Utilities.Network;
using System.Text.RegularExpressions;

namespace DTC.New.UI.Aircrafts.AV8B;

public class AV8BPage : AircraftPage
{

    private readonly AV8BCapture capture;

    public AV8BPage(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        capture = new(this, this.Configuration);
    }

    public new AV8BConfiguration Configuration
    {
        get { return (AV8BConfiguration)preset.Configuration; }
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
        // TODO: implement AV-8B uploader integration
        this.UploadToJet(this.Configuration, pilot);
    }

    public void UploadToJet(AV8BConfiguration cfg, bool pilot)
    {
        var upload = new AV8BUploader((AV8BAircraft)this.aircraft, cfg);
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