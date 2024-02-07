
namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

public enum RouteMode
{
    UseAll = 1,
    UseRange = 2,
    UseSpecific = 3
}

public enum RouteCode
{
    Alpha,
    Bravo,
    Delta,
    Echo,
    Hotel,
    India,
    Lima,
    Oscar,
    Romeo,
    Tango
}

public class RouteSystem
{
    public List<Route> Routes = new();

    public Route GetByCode(RouteCode code)
    {
        return Routes.Where(r => r.Code == code).FirstOrDefault();
    }
}

public class Route
{
    public RouteCode Code { get; set; }

    public RouteMode Mode { get; set; }
    public List<int>? Waypoints { get; set; }

    public bool IncludeAllWaypoints { get; set; }
    public bool IncludeAllHazards { get; set; }
    public bool IncludeAllControlMeasures { get; set; }
}
