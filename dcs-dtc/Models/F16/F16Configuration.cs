using DTC.Utilities;
using DTC.Models.F16.CMS;
using DTC.Models.F16.MFD;
using DTC.Models.F16.Waypoints;
using DTC.Models.F16.Radios;
using Newtonsoft.Json;
using DTC.Models.F16.HARMHTS;
using DTC.Models.F16.Misc;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Globalization;
using System.Reflection;

namespace DTC.Models.F16
{
    public class F16Configuration : IConfiguration
    {
        public WaypointSystem Waypoints = new WaypointSystem();
        public RadioSystem Radios = new RadioSystem();
        public CMSystem CMS = new CMSystem();
        public MFDSystem MFD = new MFDSystem();
        public HARMSystem HARM = new HARMSystem();
        public HTSSystem HTS = new HTSSystem();
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

        public static F16Configuration FromJson(string s)
        {
            try
            {
                var cfg = JsonConvert.DeserializeObject<F16Configuration>(s);
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
            if (CMS != null)
            {
                CMS.AfterLoadFromJson();
            }
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
        public static F16Configuration FromCombatFlite(string file, string flightName)
        {
            var doc = XDocument.Parse(file);
            F16Configuration cfg = new F16Configuration
            {
                Waypoints =
                {
                    Waypoints = new List<Waypoint>()
                },
                Misc = null,
                Radios = null, 
                CMS = null,
                MFD = null,
                HARM = null,
                HTS = null
            };

            var flight = doc.XPathSelectElement($"//Route[Name='{flightName}']");

            if (flight == null)
                return cfg;

            foreach (var (xmlWaypoint, i) in flight.XPathSelectElements("./Waypoints/Waypoint").Select((xmlWaypoint, i) => (xmlWaypoint, i)))
            {
                var lat = double.Parse(xmlWaypoint.Element("Lat")?.Value, CultureInfo.InvariantCulture);
                var lon = double.Parse(xmlWaypoint.Element("Lon")?.Value, CultureInfo.InvariantCulture);
                var ele = double.Parse(xmlWaypoint.Element("Altitude")?.Value, CultureInfo.InvariantCulture);

                if (lat == null || lon == null)
                    continue;

                var coordinate = new CoordinateSharp.Coordinate(lat, lon);
                
                cfg.Waypoints.Waypoints.Add(new Waypoint(i)
                {
                    Name = xmlWaypoint.Element("Name")?.Value,
                    Latitude = $"{coordinate.Latitude.Position} {coordinate.Latitude.Degrees:00}°{coordinate.Latitude.DecimalMinute:00.000}’".Replace(',', '.'),
                    Longitude = $"{coordinate.Longitude.Position} {coordinate.Longitude.Degrees:000}°{coordinate.Longitude.DecimalMinute:00.000}’".Replace(',', '.'),
                    Elevation = Convert.ToInt32(ele),
                });
            }

            return cfg;
        }

        public static F16Configuration FromCompressedString(string s)
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

        public F16Configuration Clone()
        {
            var json = ToJson();
            var cfg = FromJson(json);
            return cfg;
        }

        public void CopyConfiguration(F16Configuration cfg)
        {
            if (cfg.Waypoints != null)
            {
                Waypoints = cfg.Waypoints;
            }
            if (cfg.CMS != null)
            {
                CMS = cfg.CMS;
            }
            if (cfg.Radios != null)
            {
                Radios = cfg.Radios;
            }
            if (cfg.MFD != null)
            {
                MFD = cfg.MFD;
            }
            if (cfg.HARM != null)
            {
                HARM = cfg.HARM;
            }
            if (cfg.HTS != null)
            {
                HTS = cfg.HTS;
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
