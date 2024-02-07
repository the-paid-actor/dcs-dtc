using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

/*
 * 01-50 Waypoints or Hazards
 * 51-99 Control Measures
 * 100-149 Targets / Threats (but on the jet are T01 through T50)
 */

public class Waypoint : IWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string? TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }

    public string PointType { get; set; }
    public string Identifier { get; set; }
    public string Free { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    public string ExtraDescription
    {
        get
        {
            var str = new string[] { Target ? "TGT" : "", Identifier, Free };
            return string.Join(", ", str.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}

public class WaypointSystem : WaypointSystem<Waypoint>
{
    public override Waypoint NewWaypoint()
    {
        var w = base.NewWaypoint();
        w.PointType = PointType.Waypoint.Code;
        w.Identifier = "WP";
        return w;
    }

    public override int GetFirstAllowedSequence()
    {
        return 1;
    }

    public override int GetLastAllowedSequence()
    {
        return 50;
    }
}

public class ControlMeasures : WaypointSystem<Waypoint>
{
    public override Waypoint NewWaypoint()
    {
        var w = base.NewWaypoint();
        w.PointType = PointType.GeneralControlMeasure.Code;
        w.Identifier = "CP";
        return w;
    }

    public override int GetFirstAllowedSequence()
    {
        return 51;
    }

    public override int GetLastAllowedSequence()
    {
        return 99;
    }
}

public class Targets : WaypointSystem<Waypoint>
{
    public override Waypoint NewWaypoint()
    {
        var w = base.NewWaypoint();
        w.PointType = PointType.Target.Code;
        w.Identifier = "TG";
        return w;
    }

    public override int GetFirstAllowedSequence()
    {
        return 1;
    }

    public override int GetLastAllowedSequence()
    {
        return 50;
    }
}