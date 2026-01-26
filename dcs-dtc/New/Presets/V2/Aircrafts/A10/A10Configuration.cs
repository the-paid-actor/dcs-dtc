using DTC.New.Presets.V2.Aircrafts.A10.Systems;
using DTC.New.Presets.V2.Base;

namespace DTC.New.Presets.V2.Aircrafts.A10;

public class A10Configuration : Configuration
{

    public string Aircraft = "A10";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(A10Configuration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}
