namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class Waypoint
{
    public int Sequence { get; set; }
    public string Name { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Elevation { get; set; }

    public Waypoint(int seq)
    {
        Sequence = seq;
    }
}
