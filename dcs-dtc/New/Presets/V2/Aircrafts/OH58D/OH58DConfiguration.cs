using DTC.New.Presets.V2.Aircrafts.OH58D.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.OH58D;

public class OH58DConfiguration : Configuration
{
    public string Aircraft = "OH58D";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Radios")]
    public Radio6System Radios { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(OH58DConfiguration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}
