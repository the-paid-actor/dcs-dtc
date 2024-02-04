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

    public new F15EConfiguration Configuration
    {
        get { return (F15EConfiguration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),

            new UploadPage(this),
            new WaypointCapturePage(this, Configuration.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(this, Configuration.RouteA, new WaypointEditPanel(), nameof(Configuration.RouteA), "Route A"),
            new WaypointsPage<Waypoint>(this, Configuration.RouteB, new WaypointEditPanel(), nameof(Configuration.RouteB), "Route B"),
            new WaypointsPage<Waypoint>(this, Configuration.RouteC, new WaypointEditPanel(), nameof(Configuration.RouteC), "Route C"),
            new RadiosPage(this),
            new DisplaysPage(this),
            new SmartWeaponsPage(this),
            new MiscPage(this)
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

    internal override bool AllowCopyFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        var isToRoute = systems.Count == 1 &&
                (systems[0].PropertyName == nameof(F15EConfiguration.RouteA) ||
                systems[0].PropertyName == nameof(F15EConfiguration.RouteB) ||
                systems[0].PropertyName == nameof(F15EConfiguration.RouteC));

        var cfgF18 = cfg as Presets.V2.Aircrafts.FA18.FA18Configuration;
        if (cfgF18 != null && isToRoute && cfgF18.Waypoints != null)
        {
            return true;
        }
        var cfgF16 = cfg as Presets.V2.Aircrafts.F16.F16Configuration;
        if (cfgF16 != null && isToRoute && cfgF16.Waypoints != null)
        {
            return true;
        }

        var cfgF15 = cfg as Presets.V2.Aircrafts.F15E.F15EConfiguration;
        if (cfgF15 != null && isToRoute && (cfgF15.RouteA != null || cfgF15.RouteB != null || cfgF15.RouteC != null))
        {
            return true;
        }

        return false;
    }

    internal override Configuration ConvertConfigFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        var isToRouteA = systems.Count == 1 && systems[0].PropertyName == nameof(F15EConfiguration.RouteA);
        var isToRouteB = systems.Count == 1 && systems[0].PropertyName == nameof(F15EConfiguration.RouteB);
        var isToRouteC = systems.Count == 1 && systems[0].PropertyName == nameof(F15EConfiguration.RouteC);
        
        var cfgResult = new F15EConfiguration();
        cfgResult.ClearAllSystems();
        WaypointSystem wptSystem = null;

        if (isToRouteA) wptSystem = cfgResult.RouteA = new WaypointSystem();
        if (isToRouteB) wptSystem = cfgResult.RouteB = new WaypointSystem();
        if (isToRouteC) wptSystem = cfgResult.RouteC = new WaypointSystem();

        if (wptSystem == null)
        {
            return null;
        }

        var cfgF18 = cfg as Presets.V2.Aircrafts.FA18.FA18Configuration;
        if (cfgF18 != null && cfgF18.Waypoints != null)
        {
            cfgF18.Waypoints.FixWaypointsStartingAt0();
            wptSystem.ImportWptsFromJson(cfgF18.Waypoints.ExportWptsToJson());
        }
        var cfgF16 = cfg as Presets.V2.Aircrafts.F16.F16Configuration;
        if (cfgF16 != null && cfgF16.Waypoints != null)
        {
            wptSystem.ImportWptsFromJson(cfgF16.Waypoints.ExportWptsToJson());
        }
        var cfgF15 = cfg as Presets.V2.Aircrafts.F15E.F15EConfiguration;
        if (cfgF15 != null && (cfgF15.RouteA != null || cfgF15.RouteB != null || cfgF15.RouteC != null))
        {
            if (cfgF15.RouteA != null)
            {
                wptSystem.ImportWptsFromJson(cfgF15.RouteA.ExportWptsToJson());
            }
            if (cfgF15.RouteB != null)
            {
                wptSystem.ImportWptsFromJson(cfgF15.RouteB.ExportWptsToJson());
            }
            if (cfgF15.RouteC != null)
            {
                wptSystem.ImportWptsFromJson(cfgF15.RouteC.ExportWptsToJson());
            }
        }

        return cfgResult;
    }
}
