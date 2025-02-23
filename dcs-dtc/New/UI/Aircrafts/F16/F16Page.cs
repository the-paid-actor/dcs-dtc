using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.New.Uploader.Aircrafts.F16;
using DTC.Utilities;
using DTC.Utilities.Network;

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
        get { return (F16Configuration)preset.Configuration; }
    }

    protected override AircraftSystemPage[] GetPages(IConfiguration configuration)
    {
        var cfg = Configuration;

        if (cfg.Upload == null) cfg.Upload = new();
        if (cfg.WaypointsCapture == null) cfg.WaypointsCapture = new();
        if (cfg.Waypoints == null) cfg.Waypoints = new();
        if (cfg.CMS == null) cfg.CMS = new();
        if (cfg.Radios == null) cfg.Radios = new();
        if (cfg.MFD == null) cfg.MFD = new();
        if (cfg.HARM == null) cfg.HARM = new();
        if (cfg.HTS == null) cfg.HTS = new();
        if (cfg.Datalink == null) cfg.Datalink = new();
        if (cfg.Misc == null) cfg.Misc = new();

        return new AircraftSystemPage[]
        {
            new LoadSavePage(this),
            new AircraftSystemPage.Divider(),

            new UploadPage(this),
            new WaypointCapturePage(this, cfg.WaypointsCapture),
            new AircraftSystemPage.Divider(),

            new WaypointsPage<Waypoint>(this, cfg.Waypoints, new WaypointEditPanel(cfg.Waypoints, this), nameof(cfg.Waypoints), "Steerpoints"),
            new CMSPage(this),
            new RadiosPage(this),
            new MFDPage(this),
            new HARMHTSPage(this),
            new DatalinkPage(this),
            new MiscPage(this),
        };
    }

    public override void UploadToJet(bool pilot, bool cpg)
    {
        this.UploadToJet(this.Configuration);
    }

    public void UploadToJet(F16Configuration cfg)
    {
        var upload = new F16Uploader((F16Aircraft)this.aircraft, cfg);
        upload.Execute();

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

    public WaypointsPage<Waypoint> GetWaypointsPage()
    {
        return (WaypointsPage<Waypoint>)this.GetPageOfType<WaypointsPage<Waypoint>>();
    }

    internal override bool AllowCopyFromClipboard(Configuration cfg, List<ConfigurationSystem> systems)
    {
        var isToWpts = systems.Count == 1 && systems[0].PropertyName == nameof(F16Configuration.Waypoints);

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
        var isToWpts = systems.Count == 1 && systems[0].PropertyName == nameof(F16Configuration.Waypoints);

        var cfgResult = new F16Configuration();
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

    public override string GetKneeboardInfoText()
    {
        return F16Kneeboard.GetKneeboardText(this.Configuration);
    }
}