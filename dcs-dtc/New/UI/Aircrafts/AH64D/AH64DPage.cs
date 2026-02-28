using DTC.New.Presets.V2.Aircrafts.AH64D;
using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.AH64D.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.AH64D;
using DTC.Utilities;
using DTC.Utilities.Network;

namespace DTC.New.UI.Aircrafts.AH64D;

public class AH64DPage : AircraftPage
{
    private AH64DCapture capture;

    public AH64DPage(Aircraft aircraft, Preset preset)
        : base(aircraft, preset)
    {
        this.capture = new(this, this.Configuration);
    }

    public AH64DConfiguration Configuration
    {
        get { return (AH64DConfiguration)preset.Configuration;}
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        if (cfg.Waypoints == null)
        {
            cfg.Waypoints = new WaypointSystem();
        }

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),

            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(
                this,
                cfg.Waypoints, 
                new WaypointEditPanel(PointType.Waypoint, PointType.Hazard), 
                nameof(cfg.Waypoints), 
                "Waypoints"),

            new WaypointsPage<Waypoint>(
                this,
                cfg.ControlMeasures,
                new WaypointEditPanel(PointType.GeneralControlMeasure, PointType.FriendlyControlMeasure, PointType.EnemyControlMeasure),
                nameof(cfg.ControlMeasures),
                "Control Measures"),

            new WaypointsPage<Waypoint>(
                this,
                cfg.Targets,
                new WaypointEditPanel(PointType.Target, PointType.Threat),
                nameof(cfg.Targets),
                "Targets"),

            new RoutePage(this),
            new TSDPage(this),
            new LaserCodesPage(this),
            new RadiosPage(this)
        };
    }

    private UploadSelection uploadSelection = new UploadSelection();

    public override void UploadToJet(bool pilot, bool cpg)
    {
        if (pilot || cpg)
        {
            if (pilot)
            {
                this.UploadToJet(this.Configuration, true);
            }
            else
            {
                this.UploadToJet(this.Configuration, false);
            }
        }
        else
        {
            uploadSelection.ApachePage = this;
            this.ShowControlAsPage(uploadSelection);
        }
    }

    public void UploadToJet(AH64DConfiguration cfg, bool pilot)
    {
        var upload = new AH64DUploader((AH64DAircraft)this.aircraft, cfg);
        upload.Execute(pilot);

        if (cfg.Upload.Kneeboard)
        {
            KneeboardSender.SendInfo(preset.Name, this.GetKneeboardInfoText());
            KneeboardSender.SendNotes(this.GetKneeboardNotesText());
        }
    }

    protected override void WaypointCaptureReceived(WaypointCaptureData data)
    {
        this.capture.CaptureReceived(data);
    }

    internal void RefreshRoutePages()
    {
        var pageA = (WaypointsPage<Waypoint>)this.GetPageOfTitle("Waypoints");
        pageA.RefreshList();

        var pageB = (WaypointsPage<Waypoint>)this.GetPageOfTitle("Control Measures");
        pageB.RefreshList();

        var pageC = (WaypointsPage<Waypoint>)this.GetPageOfTitle("Targets");
        pageC.RefreshList();
    }

    internal override bool AllowCopyFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        var isToWpts = systems.Count == 1 && systems[0].PropertyName == nameof(AH64DConfiguration.Waypoints);

        var cfgF18 = cfg as Presets.V2.Aircrafts.FA18.FA18Configuration;
        if (cfgF18 != null && isToWpts && cfgF18.Waypoints != null)
        {
            return true;
        }
        var cfgAH64D = cfg as Presets.V2.Aircrafts.AH64D.AH64DConfiguration;
        if (cfgAH64D != null && isToWpts && cfgAH64D.Waypoints != null)
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
        var isToWpts = systems.Count == 1 && systems[0].PropertyName == nameof(AH64DConfiguration.Waypoints);

        var cfgResult = new AH64DConfiguration();
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
            cfgF18.Waypoints.FixWaypointsStartingAt0();
            wptSystem.ImportWptsFromJson(cfgF18.Waypoints.ExportWptsToJson());
        }
        var cfgAH64D = cfg as Presets.V2.Aircrafts.AH64D.AH64DConfiguration;
        if (cfgAH64D != null && cfgAH64D.Waypoints != null)
        {
            wptSystem.ImportWptsFromJson(cfgAH64D.Waypoints.ExportWptsToJson());
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

    public override string GetKneeboardInfoText()
    {
        return AH64DKneeboard.GetKneeboardText(this.Configuration);
    }
}