using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.AH64D;

public class AH64DConfiguration : Configuration
{
    public string Aircraft = "AH64D";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Control Measures")]
    public ControlMeasures ControlMeasures { get; set; } = new();

    [System("Targets")]
    public Targets Targets { get; set; } = new();

    [System("Routes")]
    public RouteSystem Routes { get; set; } = new();

    [System("TSD")]
    public TSDSystem TSD { get; set; } = new();

    [System("Laser Codes")]
    public LaserCodesSystem LaserCodes { get; set; } = new();

    [System("Radios")]
    public RadioSystem Radios { get; set; } = new();

    public override void AfterLoadFromJson()
    {
    }

    protected override Type GetConfigurationType()
    {
        return typeof(AH64DConfiguration);
    }

    public override string GetAircraftName()
    {
        return this.Aircraft;
    }
}
