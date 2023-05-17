using DTC.Models.DCS;
using DTC.Models.F16.Waypoints;
using System.Text;

namespace DTC.Models.F16.Upload
{
	public class WaypointBuilder : BaseBuilder
	{
		private F16Configuration _cfg;

		public WaypointBuilder(F16Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
			_cfg = cfg;
		}

		public override void Build()
		{
			var wpts = _cfg.Waypoints.Waypoints;
			if (wpts.Count == 0)
			{
				return;
			}

			var wptStart = 1;
			var wptEnd = wpts.Count;

			if (_cfg.Waypoints.OverrideRange)
			{
				wptStart = _cfg.Waypoints.SteerpointStart;
				wptEnd = _cfg.Waypoints.SteerpointEnd;
			}

			var wptDiff = wptEnd - wptStart + 1;

			var ufc = _aircraft.GetDevice("UFC");

			AppendCommand(ufc.GetCommand("RTN"));
			AppendCommand(ufc.GetCommand("RTN"));
			AppendCommand(ufc.GetCommand("4"));

			for (var i = 0; i < wptDiff; i++)
			{
				Waypoint wpt;
				if (i < wpts.Count)
				{
					wpt = wpts[i];
				}
				else
				{
					//Repeats the last waypoint till it fills
					wpt = wpts[wpts.Count - 1];
				}

				AppendCommand(BuildDigits(ufc, (i + wptStart).ToString()));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));
				AppendCommand(ufc.GetCommand("DOWN"));

				if (_cfg.Waypoints.EnableUploadCoordsElevation && !wpt.IsCoordinateBlank)
				{
					AppendCommand(BuildCoordinate(ufc, wpt.Latitude));
					AppendCommand(ufc.GetCommand("ENTR"));
				}
				AppendCommand(ufc.GetCommand("DOWN"));

				if (_cfg.Waypoints.EnableUploadCoordsElevation && !wpt.IsCoordinateBlank)
				{
					AppendCommand(BuildCoordinate(ufc, wpt.Longitude));
					AppendCommand(ufc.GetCommand("ENTR"));
				}
				AppendCommand(ufc.GetCommand("DOWN"));

				if (_cfg.Waypoints.EnableUploadCoordsElevation && !wpt.IsCoordinateBlank)
				{
					AppendCommand(BuildDigits(ufc, wpt.Elevation.ToString()));
					AppendCommand(ufc.GetCommand("ENTR"));
				}
				AppendCommand(ufc.GetCommand("DOWN"));

				if (_cfg.Waypoints.EnableUploadTOS && !string.IsNullOrEmpty(wpt.TimeOverSteerpoint))
				{
					AppendCommand(BuildTimeString(ufc, wpt.TimeOverSteerpoint));
					AppendCommand(ufc.GetCommand("ENTR"));
				}
				AppendCommand(ufc.GetCommand("DOWN"));
			}

			AppendCommand(ufc.GetCommand("1"));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("RTN"));
		}

		private string BuildTimeString(Device ufc, string time)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < time.Length; i++)
			{
				if (time[i] != ':')
				{
					sb.Append(ufc.GetCommand(time[i].ToString()));
				}

			}
			return sb.ToString();
		}

		private string BuildCoordinate(Device ufc, string coord)
		{
			var sb = new StringBuilder();

			var latStr = RemoveSeparators(coord.Replace(" ", ""));

			foreach (var c in latStr.ToCharArray())
			{
				if (c == 'N')
				{
					sb.Append(ufc.GetCommand("2"));
				}
				else if (c == 'S')
				{
					sb.Append(ufc.GetCommand("8"));
				}
				else if (c == 'E')
				{
					sb.Append(ufc.GetCommand("6"));
				}
				else if (c == 'W')
				{
					sb.Append(ufc.GetCommand("4"));
				}
				else
				{
					sb.Append(ufc.GetCommand(c.ToString()));
				}
			}

			return sb.ToString();
		}
	}
}
