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
                    //Target = xmlWaypoint.Element("Target")?.Value == "Target"
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
