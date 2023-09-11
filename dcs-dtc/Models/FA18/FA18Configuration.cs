using DTC.Utilities;
using DTC.Models.FA18.Waypoints;
using DTC.Models.FA18.Sequences;
using DTC.Models.FA18.Radios;
using DTC.Models.FA18.PrePlanned;
using DTC.Models.FA18.CMS;
using Newtonsoft.Json;
using DTC.Models.FA18.Misc;
using CoordinateSharp;
using System.Xml.Linq;
using System.Xml.XPath;


namespace DTC.Models.FA18
{
    public class FA18Configuration : IConfiguration
    {
        public WaypointSystem Waypoints = new WaypointSystem();
        public SequenceSystem Sequences = new SequenceSystem();
        public PrePlannedSystem PrePlanned = new PrePlannedSystem();
        public RadioSystem Radios = new RadioSystem();
        public CMSystem CMS = new CMSystem();
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

        public static FA18Configuration FromJson(string s)
        {
            try
            {
                var cfg = JsonConvert.DeserializeObject<FA18Configuration>(s);
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
            FixWaypointCoordinateFormat();
        }

        private void FixWaypointCoordinateFormat()
        {
            if (this.Waypoints == null) return;

            foreach (var wpt in this.Waypoints.Waypoints)
            {
                if (!wpt.Latitude.Contains("°"))
                {
                    var parts = wpt.Latitude.Split('.');
                    wpt.Latitude = $"{parts[0]}°{parts[1]}.{parts[2]}’";
                }
                if (!wpt.Longitude.Contains("°"))
                {
                    var parts = wpt.Longitude.Split('.');
                    wpt.Longitude = $"{parts[0]}°{parts[1]}.{parts[2]}’";
                }
            }
        }

        public static FA18Configuration FromCombatFlite(string file, string flightName)
        {
            var doc = XDocument.Parse(file);
            FA18Configuration cfg = new FA18Configuration
            {
                Waypoints =
                {
                    Waypoints = new List<Waypoint>()
                },
                Misc = null,
                CMS = null,
                Sequences =  null,
                Radios =null,
                PrePlanned = null
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
                    Latitude = $"{coordinate.Latitude.Position} {coordinate.Latitude.Degrees:00}°{coordinate.Latitude.DecimalMinute:00.00}’".Replace(',', '.'),
                    Longitude = $"{coordinate.Longitude.Position} {coordinate.Longitude.Degrees:000}°{coordinate.Longitude.DecimalMinute:00.00}’".Replace(',', '.'),
                    Elevation = int.Parse(xmlWaypoint.Element("Altitude")?.Value ?? "0"),
                    //Target = xmlWaypoint.Element("Target")?.Value == "Target"
                });
            }
            return cfg;
        }

        public static FA18Configuration FromCompressedString(string s)
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

        public FA18Configuration Clone()
        {
            var json = ToJson();
            var cfg = FromJson(json);
            return cfg;
        }

        public void CopyConfiguration(FA18Configuration cfg)
        {
            if (cfg.Waypoints != null)
            {
                Waypoints = cfg.Waypoints;
            }
            if (cfg.Radios != null)
            {
                Radios = cfg.Radios;
            }
            if (cfg.Misc != null)
            {
                Misc = cfg.Misc;
            }
            if (cfg.Sequences != null)
            {
                Sequences = cfg.Sequences;
            }
            if (cfg.PrePlanned != null)
            {
                PrePlanned = cfg.PrePlanned;
            }
            if (cfg.Radios != null)
            {
                Radios = cfg.Radios;
            }
            if (cfg.CMS != null)
            {
                CMS = cfg.CMS;
            }
        }
        internal static FA18Configuration FromCombatFliteXML(FA18Configuration previous, string file)
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
                //if (
                //    !double.TryParse(lat, out var dLat) ||
                //    !double.TryParse(lon, out var dLon))
                //{
                //    continue;
                //}
                float.TryParse(pos.Element("Altitude")?.Value.Replace('.', ','), out var elevation);
                var coord = new CoordinateSharp.Coordinate(dLat, dLon, new EagerLoad(false));
                lat = $"{(dLat > 0 ? 'N' : 'S')} {coord.Latitude.Degrees:00}.{coord.Latitude.DecimalMinute:00.000}";
                lon = $"{(dLon > 0 ? 'E' : 'W')} {Math.Abs(coord.Longitude.Degrees):000}.{coord.Longitude.DecimalMinute:00.000}";

                var s = coord.ToString();

                var coordStr = string.IsNullOrEmpty(lat) ? "N 00.00.000" : lat;
                coordStr = coordStr + " " + (string.IsNullOrEmpty(lon) ? "E 000.00.000" : lon);
                var wpt = new Waypoint(i);
                wpt.Name = string.IsNullOrEmpty(name) ? "" : name;
                wpt.SetCoordinate(coordStr);
                wpt.Elevation = (int)Math.Floor(elevation * feetPerMeter);

                previous.Waypoints.Waypoints.Add(wpt);

            }
            return previous;
        }
        IConfiguration IConfiguration.Clone()
        {
            return Clone();
        }
    }
}
