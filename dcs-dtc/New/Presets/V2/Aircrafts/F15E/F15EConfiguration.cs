using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.F15E;

public class F15EConfiguration : Configuration
{
    [System("Upload Settings")]
    public UploadSystem Upload { get; set; } = new();

    [System("Capture Settings")]
    public WaypointCaptureSystem WaypointsCapture { get; set; } = new();

    [System("Route A")]
    public WaypointSystem RouteA { get; set; } = new();

    [System("Route B")]
    public WaypointSystem RouteB { get; set; } = new();

    [System("Route C")]
    public WaypointSystem RouteC { get; set; } = new();

    [System("Radios")]
    public RadioSystem Radios { get; set; } = new();

    [System("Displays")]
    public DisplaySystem Displays { get; set; } = new();

    [System("Smart Weapons")]
    public SmartWeaponsSystem SmartWeapons { get; set; } = new();

    [System("Misc")]
    public MiscSystem Misc { get; set; } = new();

    public override void AfterLoadFromJson()
    {
        if (Displays != null)
        {
            if (Displays.WSO == null) Displays.WSO = new();

            if (Displays.WSO.LeftMPCD == null) Displays.WSO.LeftMPCD = new();
            if (Displays.WSO.LeftMPD == null) Displays.WSO.LeftMPD = new();
            if (Displays.WSO.RightMPD == null) Displays.WSO.RightMPD = new();
            if (Displays.WSO.RightMPCD == null) Displays.WSO.RightMPCD = new();
        }

        if (Radios != null)
        {
            if (Radios.Radio1 != null) FixRadioPreset(Radios.Radio1);
            if (Radios.Radio2 != null) FixRadioPreset(Radios.Radio2);
        }
    }

    private void FixRadioPreset(Radio radio)
    {
        if (radio.Presets == null || radio.Presets.Count == 0) return;
        if (!radio.Presets.Any(p => p.Number == 0)) return;

        foreach (var preset in radio.Presets)
        {
            preset.Number++;
        }
    }

    protected override Type GetConfigurationType()
    {
        return typeof(F15EConfiguration);
    }
}
