using DTC.Utilities;

namespace DTC.New.Presets.V1.Aircrafts.F16;

public class Offset
{
    public decimal Range { get; set; }
    public decimal Bearing { get; set; }
    public decimal Elevation { get; set; }
}

public class Waypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }
    public string TimeOverSteerpoint { get; set; }

    public bool UseOA { get; set; }
    public Offset OffsetAimpoint1 { get; set; }
    public Offset OffsetAimpoint2 { get; set; }

    public bool UseVIP { get; set; }
    public Offset VIPtoTGT { get; set; }
    public Offset VIPtoPUP { get; set; }

    public bool UseVRP { get; set; }
    public Offset TGTtoVRP { get; set; }
    public Offset TGTtoPUP { get; set; }

    public Waypoint(int seq)
    {
        Sequence = seq;
        TimeOverSteerpoint = "00:00:00";
    }
}
