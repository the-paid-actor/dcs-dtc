using DTC.Models.Base;

namespace DTC.Models.F15E.Waypoints
{
    public class Waypoint
    {
        public int Sequence { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Elevation { get; set; }
        public bool Target { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string ExtraDescription
        {
            get
            {
                var str = "";
                if (Target) str = str + "TGT";
                return str;
            }
        }

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

        public Waypoint(int seq)
        {
            Sequence = seq;
        }

        public string GetCoordinate()
        {
            return Latitude + " " + Longitude;
        }

        public void SetCoordinate(string coord)
        {
            var match = Coordinate.DegreesMinutesThousandthsRegex.Match(coord);
            Latitude = match.Groups[1].Value;
            Longitude = match.Groups[2].Value;
        }

        public static bool IsCoordinateValid(string coord)
        {
            var match = Coordinate.DegreesMinutesThousandthsRegex.Match(coord);
            return match.Success;
        }

        public void AutoName()
        {
            Name = (Target ? "TGT " : "WPT ") + Sequence.ToString("00");
        }
    }
}