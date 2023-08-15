using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;
using CoordinateSharp;
using Newtonsoft.Json;
using DTC.Utilities;
using DTC.Models.Base;
using DTC.Models.AH64.Waypoints;
using DTC.Models.AH64.Radios;

namespace DTC.Models.AH64
{
    public class AH64Configuration : IConfiguration
    {
        public WaypointSystem Waypoints = new WaypointSystem();
        public RadioSystem Radios = new RadioSystem();
        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this);
            return json;
        }

        public string ToCompressedString()
        {
            var json = ToJson();
            return StringCompressor.CompressString(json);
        }
        public static AH64Configuration FromJson(string s)
        {
            try
            {
                var cfg = JsonConvert.DeserializeObject<AH64Configuration>(s);
                cfg.AfterLoadFromJson();
                return cfg;
            }
            catch
            {
                return null;
            }
        }
        public void AfterLoadFromJson()
        {

        }
        public static AH64Configuration FromCompressedString(string s)
        {
            try
            {
                var json = StringCompressor.DecompressString(s);
                var cfg = FromJson(json);
                return cfg;
            }
            catch
            {
                return null;
            }
        }

        public AH64Configuration Clone()
        {
            var json = ToJson();
            var cfg = FromJson(json);
            return cfg;
        }

        public void CopyConfiguration(AH64Configuration cfg)
        {
            if (cfg.Waypoints != null)
            {
                Waypoints = cfg.Waypoints;
            }
            if (cfg.Radios != null)
            {
                Radios = cfg.Radios;
            }
        }

        internal static AH64Configuration FromCombatFliteXML(AH64Configuration previous, string file)
        {
            const double feetPerMeter = 3.28084D;
            XDocument doc = new XDocument();
            doc = XDocument.Parse(file);
            previous.Waypoints.Waypoints = new List<Waypoint>();
            int i = 0;
            foreach (var el in doc.XPathSelectElements("Objects/Waypoints/Waypoint"))
            {
                ++i;
                var name = el.Element("Name")?.Value;
                if (!string.IsNullOrEmpty(name))
                {
                    var names = name.Split('\n');
                    name = names[names.Length - 1];
                }
                var pos = el.Element("Position");
                if (pos == null)
                {
                    continue;
                }

                var lat = pos.Element("Latitude")?.Value;
                var lon = pos.Element("Longitude")?.Value;
                var dLat = double.Parse(lat.Replace('.', ','));
                var dLon = double.Parse(lon.Replace('.', ','));

                float.TryParse(pos.Element("Altitude")?.Value.Replace('.', ','), out var elevation);
                var coord = new CoordinateSharp.Coordinate(dLat, dLon, new EagerLoad(false));
                lat = $"{(dLat > 0 ? 'N' : 'S')} {coord.Latitude.Degrees:00}.{coord.Latitude.DecimalMinute:00.000}";
                lon = $"{(dLon > 0 ? 'E' : 'W')} {Math.Abs(coord.Longitude.Degrees):000}.{coord.Longitude.DecimalMinute:00.000}";

                var s = coord.ToString();

                previous.Waypoints.Waypoints.Add(new Waypoint(
                    i,"WP","WP","", coord.MGRS.LongZone.ToString() + coord.MGRS.LatZone.ToString()+coord.MGRS.Digraph.ToString()+" "+coord.MGRS.Easting.ToString("00000").Substring(0,4) + " " + coord.MGRS.Northing.ToString("00000").Substring(0, 4),
                    (int)Math.Floor(elevation * feetPerMeter)
                ));

            }
            return previous;
        }
        IConfiguration IConfiguration.Clone()
        {
            return Clone();
        }
    }
}
