namespace DTC.New.Presets.V2.Base.Systems;

public class WaypointsOnClipboard<T> where T : class, IWaypoint, new()
{
    public List<T> WaypointsOnClipboardList = new();
}
