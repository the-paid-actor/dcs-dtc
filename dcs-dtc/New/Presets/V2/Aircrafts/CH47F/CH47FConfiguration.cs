using DTC.New.Presets.V2.Aircrafts.CH47F.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.CH47F;

public class CH47FConfiguration : Configuration
{
    public string Aircraft = "CH47F";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(CH47FConfiguration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}
