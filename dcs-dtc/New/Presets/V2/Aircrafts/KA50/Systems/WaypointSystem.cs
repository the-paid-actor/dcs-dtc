using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.KA50.Systems;

public class Waypoint : IWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string? TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    public string ExtraDescription => "";
}

public class WaypointSystem : WaypointSystem<Waypoint>
{
    public const int FirstSteerpoint = 1;
    public const int LastSteerpoint = 6;

    public override int GetFirstAllowedSequence()
    {
        return FirstSteerpoint;
    }

    public override int GetLastAllowedSequence()
    {
        return LastSteerpoint;
    }
}
