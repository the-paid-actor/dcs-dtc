using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.CH47F.Systems;

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
    public string ExtraDescription => Target ? "TGT" : "";
}

public class WaypointSystem : WaypointSystem<Waypoint>
{
    public override int GetFirstAllowedSequence()
    {
        return 1;
    }

    public override int GetLastAllowedSequence()
    {
        return 200;
    }
}
