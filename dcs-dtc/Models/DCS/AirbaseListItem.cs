namespace DTC.Models.DCS;

public class AirbaseListItem
{
    public string Theatre;
    public string Airbase;
    public string Latitude;
    public string Longitude;
    public int Elevation;

    public AirbaseListItem(string theatre, string airbase, string latitude, string longitude, int elevation)
    {
        Theatre = theatre;
        Airbase = airbase;
        Latitude = latitude;
        Longitude = longitude;
        Elevation = elevation;
    }

    public override string ToString()
    {
        return $"{Theatre} - {Airbase}";
    }
}
