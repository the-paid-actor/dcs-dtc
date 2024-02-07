
namespace DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

public class PointType
{
    public static PointType Waypoint = new PointType("WP", "Waypoint");
    public static PointType Hazard = new PointType("HZ", "Hazard");
    public static PointType GeneralControlMeasure = new PointType("GC", "General Control Measure");
    public static PointType FriendlyControlMeasure = new PointType("FC", "Friendly Control Measure");
    public static PointType EnemyControlMeasure = new PointType("EC", "Enemy Control Measure");
    public static PointType Target = new PointType("TG", "Target");
    public static PointType Threat = new PointType("TH", "Threat");

    public static PointType[] NavigationPointTypes = new[]
    {
        Waypoint,
        Hazard,
        GeneralControlMeasure,
        FriendlyControlMeasure,
        EnemyControlMeasure,
        Target,
        Threat
    };

    public string Code { get; }
    public string Name { get; }

    public PointType(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}
