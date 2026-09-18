using DTC.New.Presets.V2.Aircrafts.F14BU.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.F14BU;

public class F14BUConfiguration : Configuration
{
    public string Aircraft = "F14BU";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(F14BUConfiguration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}
