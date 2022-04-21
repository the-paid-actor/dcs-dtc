using System;
using System.Text.RegularExpressions;

namespace DTC.Models.FA18.Waypoints
{
	public class Waypoint
	{
		private static Regex coordRegex = new Regex("^([N|S] \\d\\d\\.\\d\\d\\.\\d\\d) ([E|W] \\d\\d\\d\\.\\d\\d\\.\\d\\d)$");

		public int Sequence { get; set; }
		public string Name { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public int Elevation { get; set; }

		public bool Blank {
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

		public Waypoint(int seq, string name, string latitude, string longitude, int elevation)
		{
			Sequence = seq;
			Name = name;
			Latitude = latitude;
			Longitude = longitude;
			Elevation = elevation;
		}

		public static Waypoint FromStrings(string name, string coord, string elevation)
		{
			var match = coordRegex.Match(coord);
			var wpt = new Waypoint(0, name, match.Groups[1].Value, match.Groups[2].Value, int.Parse(elevation));
			return wpt;
		}

		public static bool IsCoordinateValid(string coord)
		{
			var match = coordRegex.Match(coord);
			return match.Success;
		}
	}
}
