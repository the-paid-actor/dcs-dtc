namespace DTC.Utilities
{
    public class Airbase
    {
        public readonly string Name;
        public readonly string Latitude;
        public readonly string Longitude;
        public readonly int Elevation;

        public Airbase(string name, string latitude, string longitude, int elevation)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
        }
    }
}
