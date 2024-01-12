using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.Presets.V2.Aircrafts.F16.Systems;

public class Offset
{
    public decimal Range { get; set; }
    public decimal Bearing { get; set; }
    public decimal Elevation { get; set; }
}

public class Waypoint : IWaypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string? TimeOverSteerpoint { get; set; }
    public bool Target { get; set; }

    public bool UseOA { get; set; }
    public Offset? OffsetAimpoint1 { get; set; }
    public Offset? OffsetAimpoint2 { get; set; }

    public bool UseVIP { get; set; }
    public Offset? VIPtoTGT { get; set; }
    public Offset? VIPtoPUP { get; set; }

    public bool UseVRP { get; set; }
    public Offset? TGTtoVRP { get; set; }
    public Offset? TGTtoPUP { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    public string ExtraDescription
    {
        get
        {
            var str = "";
            if (UseOA) str = str + "OA, ";
            if (UseVIP) str = str + "VIP, ";
            if (UseVRP) str = str + "VRP, ";
            if (Target) str = str + "TGT, ";
            str = str.TrimEnd(' ', ',');
            return str;
        }
    }

    [Newtonsoft.Json.JsonIgnore]
    public bool IsCoordinateBlank
    {
        get
        {
            var tmp = Latitude.Replace("N", "").Replace("S", "").Replace(".", "");
            if (int.TryParse(tmp, out int latInt))
            {
                if (latInt == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public void AutoName()
    {
        Name = "WPT " + Sequence.ToString("00");
    }
}

public class WaypointSystem : WaypointSystem<Waypoint>
{
}
