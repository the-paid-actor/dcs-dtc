namespace DTC.New.Presets.V2.Aircrafts.F15E.Systems;

public enum DisplayUploadMode
{
    AutoSelect = 1,
    PilotAndWSO = 2,
}

public class UploadSystem
{
    public DisplayUploadMode DisplayUploadMode { get; set; } = DisplayUploadMode.AutoSelect;

    public bool RouteA { get; set; }
    public bool RouteB { get; set; }
    public bool RouteC { get; set; }
    public bool Radios { get; set; }
    public bool Displays { get; set; }
    public bool SmartWeapons { get; set; }
    public bool Misc { get; set; }
}
