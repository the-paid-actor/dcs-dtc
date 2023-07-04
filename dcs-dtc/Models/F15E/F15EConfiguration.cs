using DTC.Models.Base;
using DTC.Models.F15E.Displays;
using DTC.Models.F15E.Misc;
using DTC.Models.F15E.Waypoints;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DTC.Models.F15E
{
    public class F15EConfiguration : IConfiguration
    {
        public WaypointSystem Waypoints = new WaypointSystem();
        public DisplaySystem Displays = new DisplaySystem();
        public MiscSystem Misc = new MiscSystem();

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

        public static F15EConfiguration FromJson(string s)
        {
            try
            {
                var cfg = JsonConvert.DeserializeObject<F15EConfiguration>(s);
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

        public static F15EConfiguration FromCompressedString(string s)
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

        public static F15EConfiguration FromCombatFlite(string file, string flightName)
        {
            var doc = XDocument.Parse(file);
            F15EConfiguration cfg = new F15EConfiguration
            {
                Waypoints =
                {
                    Waypoints = new List<Waypoint>()
                },
                Displays = null,
                Misc = null
            };

            var flight = doc.XPathSelectElement($"//Route[Name='{flightName}']");
            if (flight == null)
                return cfg;

            int counter = 0;
            foreach (var xmlWaypoint in flight.XPathSelectElements("./Waypoints/Waypoint"))
            {
                ++counter;
                if (counter == 1)
                    continue;

                string lat = xmlWaypoint.Element("Lat")?.Value.Replace('.', ',');
                string lon = xmlWaypoint.Element("Lon")?.Value.Replace('.', ',');
                if (lat == null || lon == null)
                    continue;

                var coordinate = new CoordinateSharp.Coordinate(double.Parse(lat), double.Parse(lon));
                cfg.Waypoints.Waypoints.Add(new Waypoint(counter - 1)
                {
                    Name = xmlWaypoint.Element("Name")?.Value,
                    Latitude = $"{coordinate.Latitude.Position} {coordinate.Latitude.Degrees:00}°{coordinate.Latitude.DecimalMinute:00.000}’".Replace(',', '.'),
                    Longitude = $"{coordinate.Longitude.Position} {coordinate.Longitude.Degrees:000}°{coordinate.Longitude.DecimalMinute:00.000}’".Replace(',', '.'),
                    Elevation = int.Parse(xmlWaypoint.Element("Altitude")?.Value ?? "0"),
                    Target = xmlWaypoint.Element("Target")?.Value == "Target"
                });
            }

            return cfg;
        }

        public F15EConfiguration Clone()
        {
            var json = ToJson();
            var cfg = FromJson(json);
            return cfg;
        }

        public void CopyConfiguration(F15EConfiguration cfg)
        {
            if (cfg.Waypoints != null)
            {
                Waypoints = cfg.Waypoints;
            }
            if (cfg.Displays != null)
            {
                Displays = cfg.Displays;
            }
            if (cfg.Misc != null)
            {
                Misc = cfg.Misc;
            }
        }

        IConfiguration IConfiguration.Clone()
        {
            return Clone();
        }
    }
}
