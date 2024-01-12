namespace DTC.New.Presets.V1.Aircrafts.FA18;

public class PrePlannedCoordinate
{
    public string Lat { get; set; }
    public string Lon { get; set; }
    public int Elev { get; set; }
    public bool Enabled { get; set; }

    public PrePlannedCoordinate()
    {
        Lat = "";
        Lon = "";
        Elev = 0;
        Enabled = false;
    }
}
