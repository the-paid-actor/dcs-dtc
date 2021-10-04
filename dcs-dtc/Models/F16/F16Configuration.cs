using System;
using System.Collections.Generic;
using DTC.Models.F16.CMS;
using DTC.Models.F16.MFD;
using DTC.Models.F16.Waypoints;
using DTC.Models.F16.Radios;
using Newtonsoft.Json;
using DTC.Models.Base;
using System.Xml.Linq;
using System.Xml.XPath;
using CoordinateSharp;

namespace DTC.Models.F16
{
	public class F16Configuration : IConfiguration
	{
		public WaypointSystem Waypoints = new WaypointSystem();
		public RadioSystem Radios = new RadioSystem();
		public CMSystem CMS = new CMSystem();
		public MFDSystem MFD = new MFDSystem();

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

		public static F16Configuration FromAutoSaveFile()
		{
			var str = FileStorage.LoadAutoSaveFile();
			if (str != null)
			{
				return F16Configuration.FromJson(str);
			}
			return null;
		}

		public static F16Configuration FromJson(string s)
		{
			try
			{
				var cfg = JsonConvert.DeserializeObject<F16Configuration>(s);
				return cfg;
			}
			catch
			{
				return null;
			}
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
		}

        internal static F16Configuration FromCombatFliteXML(F16Configuration previous, string file)
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
                if (
                    !double.TryParse(lat, out var dLat) || 
                    !double.TryParse(lon, out var dLon))
                {
                    continue;
                }
                float.TryParse(pos.Element("Altitude")?.Value, out var elevation);
                var coord = new Coordinate(dLat, dLon);
                lat = $"{(dLat > 0 ? 'N' : 'S')} {coord.Latitude.Degrees:00}.{coord.Latitude.DecimalMinute:00.000}";
                lon = $"{(dLon > 0 ? 'E' : 'W')} {Math.Abs(coord.Longitude.Degrees):000}.{coord.Longitude.DecimalMinute:00.000}";

                var s = coord.ToString();

				previous.Waypoints.Waypoints.Add(new Waypoint(
					i,
					string.IsNullOrEmpty(name) ? "" : name,
					string.IsNullOrEmpty(lat) ? "N 00.00.000" : lat,
					string.IsNullOrEmpty(lon) ? "E 000.00.000" : lon,
					(int)Math.Floor(elevation*feetPerMeter)
                ));
                
            }
			return previous;
		}
    }
}
