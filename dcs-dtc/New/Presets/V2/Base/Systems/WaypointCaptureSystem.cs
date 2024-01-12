namespace DTC.New.Presets.V2.Base.Systems;
public enum SteerpointCaptureMode
{
    AddToEndOfList,
    AddToEndOfFirstGap,
    AddToRange
}

public class WaypointCaptureSystem
{
    public SteerpointCaptureMode NavPointsMode { get; set; } = SteerpointCaptureMode.AddToEndOfList;
    public SteerpointCaptureMode TgtPointsMode { get; set; } = SteerpointCaptureMode.AddToEndOfList;
    public int NavPointsRangeFrom { get; set; } = 1;
    public int TgtPointsRangeFrom { get; set; } = 1;
}