using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.C130;

public class C130Configuration : Configuration
{
    public string Aircraft = "C130";

    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Waypoints")]
    public WaypointSystem Waypoints { get; set; } = new();

    [System("Radios")]
     public RadioSystem Radios { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    protected override Type GetConfigurationType()
    {
        return typeof(C130Configuration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
    public override void AfterLoadFromJson()
    {
        if (Radios != null)
        {
        //    Radios.AfterLoadFromJson();
        }
        // C130 radios use 2 decimal digits (e.g. 251.00).
        // The shared radio migration helper appends a trailing 0 for legacy 2-digit values,
        // which is only valid for aircraft that use 3 decimal digits.
        // Running it here would turn 251.00 into 2510.00 after reload.

    }

}
