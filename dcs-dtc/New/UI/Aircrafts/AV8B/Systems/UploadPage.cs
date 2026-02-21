using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.AV8B.Systems;

public partial class UploadPage : AircraftSystemPage
{
    public UploadPage(AV8BPage parent) : base(parent, nameof(parent.Configuration.Upload))
    {
        InitializeComponent();

        var upload = parent.Configuration.Upload;

        chkWaypoints.Checked = upload.Waypoints;
        chkWaypoints.CheckedChanged += (s, e) =>
        {
            upload.Waypoints = chkWaypoints.Checked;
            this.SavePreset();
        };
    }

    public override string GetPageTitle()
    {
        return "Upload Settings";
    }
}

