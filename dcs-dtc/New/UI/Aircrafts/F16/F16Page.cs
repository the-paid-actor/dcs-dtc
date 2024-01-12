using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.F16;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.F16;

public class F16Page : AircraftPage
{
    private F16Capture capture;

    public F16Page(Aircraft aircraft, Preset preset)
        : base(aircraft, preset)
    {
        this.capture = new(this, this.Configuration);
    }

    public F16Configuration Configuration
    {
        get { return (F16Configuration)preset.Configuration;}
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        if (cfg.Waypoints == null)
        {
            cfg.Waypoints = new WaypointSystem();
        }
        if (cfg.Datalink == null)
        {
            cfg.Datalink = new DatalinkSystem();
        }

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),

            new UploadPage(this, cfg.Upload),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(this, cfg.Waypoints, new WaypointEditPanel(cfg.Waypoints, this), "Steerpoints"),
            new CMSPage(this, cfg.CMS),
            new RadiosPage(this, cfg.Radios),
            new MFDPage(this, cfg.MFD),
            new HARMHTSPage(this, cfg.HARM, cfg.HTS),
            new DatalinkPage(this, cfg.Datalink),
            new MiscPage(this, cfg.Misc),
        };
    }

    public override void UploadToJet()
    {
        this.UploadToJet(this.Configuration);
    }

    public void UploadToJet(F16Configuration cfg)
    {
        var upload = new F16Uploader((F16Aircraft)this.aircraft, cfg);
        upload.Execute();
    }

    protected override void WaypointCaptureReceived(WaypointCaptureData data)
    {
        this.capture.CaptureReceived(data);
    }

    public WaypointsPage<Waypoint> GetWaypointsPage()
    {
        return (WaypointsPage<Waypoint>)this.GetPageOfType<WaypointsPage<Waypoint>>();
    }
}