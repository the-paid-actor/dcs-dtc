using System;
using System.Text.RegularExpressions;

namespace DTC.Models.F16.Waypoints
{
    public class Offset
    {
        public float Range { get; set; }
        public float Bearing { get; set; }
        public float Elevation { get; set; }
    }

    public class Waypoint
    {
        private static Regex coordRegex = new Regex("^([N|S] \\d\\d\\.\\d\\d\\.\\d\\d\\d) ([E|W] \\d\\d\\d\\.\\d\\d\\.\\d\\d\\d)$");

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

        [Newtonsoft.Json.JsonIgnore]
        public string ExtraDescription
        {
            get
            {
                var str = "";
                if (UseOA) str = str + "OA, ";
                if (UseVIP) str = str + "VIP, ";
                if (UseVRP) str = str + "VRP, ";
                str = str.TrimEnd(' ', ',');
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
            TimeOverSteerpoint = "00:00:00";
        }

        public void SetCoordinate(string coord)
        {
            var match = coordRegex.Match(coord);
            Latitude = match.Groups[1].Value;
            Longitude = match.Groups[2].Value;
        }

        public static bool IsCoordinateValid(string coord)
        {
            var match = coordRegex.Match(coord);
            return match.Success;
        }
    }
}
