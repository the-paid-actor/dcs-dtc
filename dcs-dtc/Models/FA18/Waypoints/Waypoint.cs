using DTC.Utilities;

namespace DTC.Models.FA18.Waypoints
{
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

        public void AutoName()
        {
            Name = "WPT " + Sequence.ToString("00");
        }

        public bool Blank
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

        public string GetCoordinate()
        {
            return Latitude + " " + Longitude;
        }

        public void SetCoordinate(string coord)
        {
            var match = Coordinate.DegreesMinutesHundredthsRegex.Match(coord);
            Latitude = match.Groups[1].Value;
            Longitude = match.Groups[2].Value;
        }

        public static bool IsCoordinateValid(string coord)
        {
            var match = Coordinate.DegreesMinutesHundredthsRegex.Match(coord);
            return match.Success;
        }
    }
}
