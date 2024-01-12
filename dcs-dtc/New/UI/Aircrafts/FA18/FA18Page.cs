using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.FA18;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.FA18;

public class FA18Page : AircraftPage
{
    private FA18Capture capture;

    public FA18Page(Aircraft aircraft, Preset preset)
        : base(aircraft, preset)
    {
        this.capture = new(this, this.Configuration);
    }

    public FA18Configuration Configuration
    {
        get { return (FA18Configuration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),

            new UploadPage(this, cfg.Upload),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(this, cfg.Waypoints, null),
            new SequencePage(this, cfg.Sequences),
            new CMSPage(this, cfg.CMS),
            new RadiosPage(this, cfg.Radios),
            new FCRPage(this, cfg.FCR),
            new PrePlannedPage(this, cfg.PrePlanned),
            new HMDPage(this, cfg.HMD),
            new MiscPage(this, cfg.Misc),
        };
    }

    public override void UploadToJet()
    {
        this.UploadToJet(this.Configuration);
    }

    public void UploadToJet(FA18Configuration cfg)
    {
        var upload = new FA18Uploader((FA18Aircraft)this.aircraft, cfg);
        upload.Execute();
    }

    protected override void WaypointCaptureReceived(WaypointCaptureData data)
    {
        this.capture.CaptureReceived(data);
    }

    public PrePlannedPage GetPrePlannedPage()
    {
        return (PrePlannedPage)this.GetPageOfType<PrePlannedPage>();
    }

    public WaypointsPage<Waypoint> GetWaypointsPage()
    {
        return (WaypointsPage<Waypoint>)this.GetPageOfType<WaypointsPage<Waypoint>>();
    }
}
