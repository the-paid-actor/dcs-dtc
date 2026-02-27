using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.CH47F.Systems;

public partial class UploadPage : AircraftSystemPage
{
    public UploadPage(CH47FPage parent) : base(parent, nameof(parent.Configuration.Upload))
    {
        InitializeComponent();

        var upload = parent.Configuration.Upload;

        chkWaypoints.Checked = upload.Waypoints;
        chkRadios.Checked = upload.Radios;

        chkWaypoints.CheckedChanged += (s, e) =>
        {
            upload.Waypoints = chkWaypoints.Checked;
            this.SavePreset();
        };

        chkRadios.CheckedChanged += (s, e) =>
        {
            upload.Radios = chkRadios.Checked;
            this.SavePreset();
        };
    }

    public override string GetPageTitle()
    {
        return "Upload Settings";
    }
}
