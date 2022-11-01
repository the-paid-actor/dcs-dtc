using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DTC.Models.AH64.Waypoints
{
    public class Waypoint
    {
        private static Regex MGRSRegex = new Regex("^(\\d{2}\\s*[A-Z]\\s*[A-Z]{2}\\s*\\d{4}\\s*\\d{4})$"); //MGRS format like 40 RDR 5123 6456

        public int Sequence { get; set; }
        public string Type { get; set; }
        public string Ident { get; set; }
        public string Free { get; set; }
        public string Mgrs { get; set; }
        public int Elevation { get; set; }

        public Waypoint(int seq, string type, string ident, string free, string mgrs,int elevation)
        {
            Sequence = seq;
            Type = type;
            Ident = ident;
            Free = free;
            Mgrs = mgrs;
            Elevation = elevation;
        }

        public static Waypoint FromStrings(string type, string ident, string free, string mgrs, string elevation)
        {
            var match = MGRSRegex.Match(mgrs);
            var wpt = new Waypoint(0, type, ident, free, mgrs, int.Parse(elevation));
            return wpt;
        }

        public static bool IsMGRSValid(string mgrs)
        {
            var match = MGRSRegex.Match(mgrs);
            return match.Success;
        }
    }
}