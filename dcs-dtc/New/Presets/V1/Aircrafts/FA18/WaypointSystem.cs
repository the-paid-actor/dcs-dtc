using DTC.New.Presets.V1.Shared;

namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class WaypointSystem
{
    public List<Waypoint> Waypoints { get; set; }
    public int SteerpointStart { get; set; }
    public bool EnableUpload { get; set; }
    public WaypointCaptureSettings CaptureSettings { get; set; } = new WaypointCaptureSettings();

    public WaypointSystem()
    {
        Waypoints = new List<Waypoint>();
        SteerpointStart = 0;
    }
}
