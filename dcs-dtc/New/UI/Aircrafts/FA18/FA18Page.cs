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

            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(this, cfg.Waypoints, null, nameof(cfg.Waypoints)),
            new SequencePage(this),
            new CMSPage(this),
            new RadiosPage(this),
            new FCRPage(this),
            new PrePlannedPage(this),
            new HMDPage(this),
            new MiscPage(this),
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
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

    internal override bool AllowCopyFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        var isToWpts = systems.Count == 1 && systems[0].PropertyName == nameof(FA18Configuration.Waypoints);

        var cfgF18 = cfg as Presets.V2.Aircrafts.FA18.FA18Configuration;
        if (cfgF18 != null && isToWpts && cfgF18.Waypoints != null)
        {
            return true;
        }
        var cfgF16 = cfg as Presets.V2.Aircrafts.F16.F16Configuration;
        if (cfgF16 != null && isToWpts && cfgF16.Waypoints != null)
        {
            return true;
        }

        var cfgF15 = cfg as Presets.V2.Aircrafts.F15E.F15EConfiguration;
        if (cfgF15 != null && isToWpts && (cfgF15.RouteA != null || cfgF15.RouteB != null || cfgF15.RouteC != null))
        {
            return true;
        }

        return false;
    }

    internal override Configuration ConvertConfigFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        var isToWpts = systems.Count == 1 && systems[0].PropertyName == nameof(FA18Configuration.Waypoints);

        var cfgResult = new FA18Configuration();
        cfgResult.ClearAllSystems();
        WaypointSystem wptSystem = null;

        if (isToWpts) wptSystem = cfgResult.Waypoints = new WaypointSystem();
        if (wptSystem == null)
        {
            return null;
        }

        var cfgF18 = cfg as Presets.V2.Aircrafts.FA18.FA18Configuration;
        if (cfgF18 != null && cfgF18.Waypoints != null)
        {
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
