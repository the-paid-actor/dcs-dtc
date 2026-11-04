using DTC.New.Presets.V2.Aircrafts.KA50.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.KA50;

public class KA50Configuration : Configuration
{
    public string Aircraft = "KA50";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(KA50Configuration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}
