using DTC.New.Presets.V2.Aircrafts.AV8B.Systems;
using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.AV8B;

public class AV8BConfiguration : Configuration
{
    public string Aircraft = "AV8B";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(AV8BConfiguration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}



