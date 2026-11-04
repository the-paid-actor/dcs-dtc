using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.KA50.Systems;

public partial class UploadPage : AircraftSystemPage
{
    public UploadPage(KA50Page parent) : base(parent, nameof(parent.Configuration.Upload))
    {
        InitializeComponent();

        var upload = parent.Configuration.Upload;

        chkWaypoints.Checked = upload.Waypoints;
        chkWaypoints.CheckedChanged += (s, e) =>
        {
            upload.Waypoints = chkWaypoints.Checked;
            this.SavePreset();
        };

        toolTip1.SetToolTip(chkWaypoints,
            "Types steerpoints 1-6 into the PVI-800 as ППМ waypoints. " +
            "The navigation system must already be powered. " +
            "Upload selects ВВОД, enters latitude as DD°MM.M' and longitude as DDD°MM.M' (one decimal minute), then returns the PVI to РАБОТА. " +
            "The PVI does not store names or elevation. South and west coordinates are entered with a minus sign. " +
            "Hold the accelerometer reset button for 1 second to upload from the cockpit.");
    }

    public override string GetPageTitle()
    {
        return "Upload Settings";
    }
}
