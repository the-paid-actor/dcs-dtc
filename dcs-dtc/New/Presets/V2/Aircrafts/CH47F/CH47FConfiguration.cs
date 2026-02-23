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

    [System("Radios")]
    public Base.Systems.RadioSystem Radios { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    public override void AfterLoadFromJson()
    {
        if (Radios != null)
        {
            //Radios.AfterLoadFromJson();
        }
        // CH47F radios use 2 decimal digits (e.g. 251.00).
        // The shared radio migration helper appends a trailing 0 for legacy 2-digit values,
        // which is only valid for aircraft that use 3 decimal digits.
        // Running it here would turn 251.00 into 2510.00 after reload.
    }

    protected override Type GetConfigurationType()
    {
        return typeof(CH47FConfiguration);
    }

    public override string GetAircraftName()
    {
        return Aircraft;
    }
}
