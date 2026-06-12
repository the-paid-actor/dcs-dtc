namespace DTC.New.Presets.V2.Aircrafts.C130.Systems;

public class RouteSystem
{
    public Route Route { get; set; } = new();
}

public enum RouteMode
{
    UseAll = 1,
    UseRange = 2,
    UseSpecific = 3
}

public class Route
{
    public RouteMode Mode { get; set; }
    public List<int>? Waypoints { get; set; }
}
