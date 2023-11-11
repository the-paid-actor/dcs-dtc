using DTC.Utilities;
using System.Text.RegularExpressions;

namespace DTC.Models.FA18.Waypoints
{
    public class Waypoint
    {
        public static Regex CoordinateRegex { get; private set; } = Coordinate.DegreesMinutesTenThousandthsRegex;
		public static CoordinateFormat CoordinateFormat { get; private set; } = CoordinateFormat.DegreesMinutesTenThousandths;
		public static string CoordinateMask { get; private set; } = Coordinate.DegreesMinutesTenThousandthsMask;

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
            var match = CoordinateRegex.Match(coord);
            Latitude = match.Groups[1].Value;
            Longitude = match.Groups[2].Value;
        }

        public void SetCoordinate((string, string) latlon)
        {
            Latitude = latlon.Item1;
            Longitude = latlon.Item2;
        }

        public static bool IsCoordinateValid(string coord)
        {
            var match = CoordinateRegex.Match(coord);
            return match.Success;
        }
    }
}
