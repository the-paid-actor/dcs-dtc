using DTC.New.Presets.V2.Base.Systems;
using DTC.Utilities;

namespace DTC.New.Presets.V2.Aircrafts.F15E.Systems;

public class Waypoint : IWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string? TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }
    public int MEA { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    public string ExtraDescription
    {
        get
        {
            return Target ? "TGT" : "";
        }
    }
}

public class WaypointSystem : WaypointSystem<Waypoint>
{
}
