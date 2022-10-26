using DTC.Models.DCS;
using DTC.Models.FA18.Waypoints;
using System.Text;

namespace DTC.Models.FA18.Upload
{
	public class WaypointBuilder : BaseBuilder
	{
		private FA18Configuration _cfg;

		public WaypointBuilder(FA18Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
			_cfg = cfg;
		}

		private void selectWp0(Device rmfd, int i)
        {
			if (i < 140) // It might not notice on the first pass, so we go around once more
			{
				AppendCommand(StartCondition("NOT_AT_WP0"));
				AppendCommand(rmfd.GetCommand("OSB-13"));
				AppendCommand(EndCondition("NOT_AT_WP0"));
				selectWp0(rmfd, i + 1);
			}
		}
		public override void Build()
		{
			var wpts = _cfg.Waypoints.Waypoints;
			var wptStart = _cfg.Waypoints.SteerpointStart;
			var wptEnd = wptStart + wpts.Count;

			if (wpts.Count == 0)
			{
				return;
			}

			var wptDiff = wptEnd - wptStart;
			
			var ufc = _aircraft.GetDevice("UFC");
			var rmfd = _aircraft.GetDevice("RMFD");
			AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
			AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
			AppendCommand(rmfd.GetCommand("OSB-02")); // HSI

			AppendCommand(rmfd.GetCommand("OSB-10")); // DATA
			AppendCommand(rmfd.GetCommand("OSB-07")); // WYPT
			AppendCommand(rmfd.GetCommand("OSB-05")); // UFC

			selectWp0(rmfd, 0);
			for (var i = 0; i< wptStart; i++)
            {
				AppendCommand(rmfd.GetCommand("OSB-12"));
			}

			for (var i = 0; i < wptDiff; i++)
			{
				Waypoint wpt;
                wpt = wpts[i];

				if (wpt.Blank)
				{
					continue;
				}
				
				AppendCommand(ufc.GetCommand("Opt1"));
				AppendCommand(Wait());
				AppendCommand(BuildCoordinate(ufc, wpt.Latitude));
				AppendCommand(ufc.GetCommand("ENT"));
				AppendCommand(WaitLong());

				AppendCommand(BuildCoordinate(ufc, wpt.Longitude));
				AppendCommand(ufc.GetCommand("ENT"));
				AppendCommand(WaitLong());

				AppendCommand(ufc.GetCommand("Opt3"));
				AppendCommand(ufc.GetCommand("Opt1"));
				AppendCommand(BuildDigits(ufc, wpt.Elevation.ToString()));
				AppendCommand(ufc.GetCommand("ENT"));
				AppendCommand(Wait());

				AppendCommand(rmfd.GetCommand("OSB-12")); // Next Waypoint
			}
			for (var i = 0; i < wptDiff; i++)
			{
				AppendCommand(rmfd.GetCommand("OSB-13")); // Prev Waypoint
			}

            AppendCommand(Wait());
			AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(Wait());
			AppendCommand(rmfd.GetCommand("OSB-18"));
			AppendCommand(rmfd.GetCommand("OSB-15"));
		}

		private string BuildCoordinate(Device ufc, string coord)
		{
			var sb = new StringBuilder();

			var latStr = RemoveSeparators(coord.Replace(" ", ""));
			var i = 0;
			var lon = false;
			var longLon = false;

			foreach (var c in latStr.ToCharArray())
			{
				if (c == 'N')
				{
					sb.Append(ufc.GetCommand("2"));
					i = 0;
				}
				else if (c == 'S')
				{
					sb.Append(ufc.GetCommand("8"));
					i = 0;
				}
				else if (c == 'E')
				{
					sb.Append(ufc.GetCommand("6"));
					i = 0;
					lon = true;	
				}
				else if (c == 'W')
				{
					sb.Append(ufc.GetCommand("4"));
					i = 0;
					lon = true;
				}
				else
				{
					if (i <= 5 || (i<= 6 && longLon)) { 
						if (!(i == 0 && c == '0' && lon))
                        {
							if(i == 0 && c == '1' && lon) longLon = true;

							sb.Append(ufc.GetCommand(c.ToString()));
							i++;
							lon = false;
						}					
							
					}
				}
			}

			return sb.ToString();
		}
	}
}
