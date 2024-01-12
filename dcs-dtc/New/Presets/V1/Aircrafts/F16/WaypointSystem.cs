using DTC.New.Presets.V1.Shared;

namespace DTC.New.Presets.V1.Aircrafts.F16;

public class WaypointSystem
{
    public List<Waypoint> Waypoints { get; set; }
    public int SteerpointStart { get; set; }
    public int SteerpointEnd { get; set; }
    public bool OverrideRange { get; set; }
    public bool EnableUploadCoordsElevation { get; set; }
    public bool EnableUploadTOS { get; set; }
    public bool EnableUpload { get; set; }
    public WaypointCaptureSettings CaptureSettings { get; set; } = new WaypointCaptureSettings();

    public WaypointSystem()
    {
        Waypoints = new List<Waypoint>();
    }
}
