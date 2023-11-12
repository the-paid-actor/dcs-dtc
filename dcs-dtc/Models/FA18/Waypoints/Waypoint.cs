using DTC.Utilities;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DTC.Models.FA18.Waypoints
{
	public class Waypoint
	{
		public int Sequence { get; set; }
		public string Name { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public int Elevation { get; set; }

		public Waypoint(int seq)
		{
			Sequence = seq;
		}

		public void AutoName()
		{
			Name = "WPT " + Sequence.ToString("00");
		}

		public bool Blank
		{
			get
			{
				CoordinateSharp.Coordinate? coordinate = GetCoordinate();
				return coordinate is not null;
			}
		}

		public CoordinateSharp.Coordinate? GetCoordinate()
		{
			return ToolsCoordinateSharp.FromString(Latitude + " " + Longitude);
		}

		public void SetCoordinate(CoordinateSharp.Coordinate? coordinate)
		{
			Latitude = Longitude = string.Empty;

			if (coordinate is not null)
			{
				Latitude = coordinate.Latitude.ToString(ToolsCoordinateSharp.CfoDdm);
				Longitude = coordinate.Longitude.ToString(ToolsCoordinateSharp.CfoDdm);
			}
		}

		public void SetCoordinate(string coord)
		{
			SetCoordinate (ToolsCoordinateSharp.FromString(coord));
		}

		public void SetCoordinate((string, string) latlon)
		{
			SetCoordinate(latlon.Item1 + " " + latlon.Item2);
		}

		public static string ToStringCoordinate(CoordinateSharp.Coordinate? c)
		{
			return ToolsCoordinateSharp.ToStringDDM(c);
		}
	}
}
