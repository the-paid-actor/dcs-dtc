using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

public partial class UploadPage : AircraftSystemPage
{
    public UploadPage(AH64DPage parent) : base(parent, nameof(parent.Configuration.Upload))
    {
        InitializeComponent();

        var upload = parent.Configuration.Upload;


        chkRadios.Checked = upload.Radios;
        chkRadios.CheckedChanged += (s, e) =>
        {
            upload.Radios = chkRadios.Checked;
            this.SavePreset();
        };

        chkWaypoints.Checked = upload.Waypoints;
        chkWaypoints.CheckedChanged += (s, e) =>
        {
            upload.Waypoints = chkWaypoints.Checked;
            this.SavePreset();
        };

        chkClearWaypoints.Checked = upload.DeleteWaypoints;
        chkClearWaypoints.CheckedChanged += (s, e) =>
        {
            upload.DeleteWaypoints = chkClearWaypoints.Checked;
            this.SavePreset();
        };

        chkControlMeasures.Checked = upload.ControlMeasures;
        chkControlMeasures.CheckedChanged += (s, e) =>
        {
            upload.ControlMeasures = chkControlMeasures.Checked;
            this.SavePreset();
        };

        chkClearControlMeasures.Checked = upload.DeleteControlMeasures;
        chkClearControlMeasures.CheckedChanged += (s, e) =>
        {
            upload.DeleteControlMeasures = chkClearControlMeasures.Checked;
            this.SavePreset();
        };

        chkTargets.Checked = upload.Targets;
        chkTargets.CheckedChanged += (s, e) =>
        {
            upload.Targets = chkTargets.Checked;
            this.SavePreset();
        };

        chkClearTargets.Checked = upload.DeleteTargets;
        chkClearTargets.CheckedChanged += (s, e) =>
        {
            upload.DeleteTargets = chkClearTargets.Checked;
            this.SavePreset();
        };

        chkRoutes.Checked = upload.Routes;
        chkRoutes.CheckedChanged += (s, e) =>
        {
            upload.Routes = chkRoutes.Checked;
            this.SavePreset();
        };

        chkTSD.Checked = upload.TSD;
        chkTSD.CheckedChanged += (s, e) =>
        {
            upload.TSD = chkTSD.Checked;
            this.SavePreset();
        };

        chkKneeboard.Checked = upload.Kneeboard;
        chkKneeboard.CheckedChanged += (s, e) =>
        {
            upload.Kneeboard = chkKneeboard.Checked;
            this.SavePreset();
        };

        chkLaserCodes.Checked = upload.LaserCodes;
        chkLaserCodes.CheckedChanged += (s, e) =>
        {
            upload.LaserCodes = chkLaserCodes.Checked;
            this.SavePreset();
        };
    }

    public override string GetPageTitle()
    {
        return "Upload Settings";
    }
}
