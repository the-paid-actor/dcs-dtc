using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.F15E.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.F15E;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.F15E;

public class F15EPage : AircraftPage
{
    private F15ECapture capture;

    public F15EPage(Aircraft aircraft, Preset preset) : base(aircraft, preset)
    {
        this.capture = new(this, this.Configuration);
    }

    public F15EConfiguration Configuration
    {
        get { return (F15EConfiguration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),

            new UploadPage(this, Configuration.Upload),
            new WaypointCapturePage(this, Configuration.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(this, Configuration.RouteA, new WaypointEditPanel(), "Route A"),
            new WaypointsPage<Waypoint>(this, Configuration.RouteB, new WaypointEditPanel(), "Route B"),
            new WaypointsPage<Waypoint>(this, Configuration.RouteC, new WaypointEditPanel(), "Route C"),
            new RadiosPage(this, Configuration.Radios),
            new DisplaysPage(this, Configuration.Displays),
            new SmartWeaponsPage(this, Configuration.SmartWeapons),
            new MiscPage(this, Configuration.Misc)
        };
    }

    public override void UploadToJet()
    {
        this.UploadToJet(this.Configuration);
    }

    public void UploadToJet(F15EConfiguration cfg)
    {
        var upload = new F15EUploader((F15EAircraft)this.aircraft, cfg);
        upload.Execute();
    }

    protected override void WaypointCaptureReceived(WaypointCaptureData data)
    {
        this.capture.CaptureReceived(data);
    }

    public SmartWeaponsPage GetSmartWeaponsPage()
    {
        return (SmartWeaponsPage)this.GetPageOfType<SmartWeaponsPage>();
    }

    internal void RefreshRoutePages()
    {
        var pageA = (WaypointsPage<Waypoint>)this.GetPageOfTitle("Route A");
        pageA.RefreshList();

        var pageB = (WaypointsPage<Waypoint>)this.GetPageOfTitle("Route B");
        pageB.RefreshList();

        var pageC = (WaypointsPage<Waypoint>)this.GetPageOfTitle("Route C");
        pageC.RefreshList();
    }
}
