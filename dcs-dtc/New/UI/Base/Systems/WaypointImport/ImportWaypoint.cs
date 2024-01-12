using DTC.Utilities;

namespace DTC.New.UI.Base.Systems.WaypointImport;

public class ImportRoute
{
    public string Name { get; set; }
    public string Aircraft { get; set; }
    public ImportWaypoint[] Waypoints { get; set; }
}

public class ImportWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public Coordinate Coordinate { get; set; }
    public int Elevation { get; set; }
    public string TimeOverSteerpoint { get; set; }
}