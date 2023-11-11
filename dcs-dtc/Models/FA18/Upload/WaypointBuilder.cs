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
                AppendCommand(StartCondition("NotAtWp0"));
                AppendCommand(rmfd.GetCommand("OSB-13"));
                AppendCommand(EndCondition("NotAtWp0"));
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
            for (var i = 0; i < wptStart; i++)
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

            AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(rmfd.GetCommand("OSB-15"));
        }

        private string BuildCoordinateOld(Device ufc, string coord)
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
                    if (i <= 5 || (i <= 6 && longLon))
                    {
                        if (!(i == 0 && c == '0' && lon))
                        {
                            if (i == 0 && c == '1' && lon) longLon = true;

                            sb.Append(ufc.GetCommand(c.ToString()));
                            i++;
                            lon = false;
                        }

                    }
                }
            }

            return sb.ToString();
        }

		private string BuildCoordinate(Device ufc, string coord)
		{
			// FG - rework to add the option of precise coordinate input
			/*
			 * Input of coordinates varies in precise mode if the aircraft is in DCML on SEC
			 * This here will only work in DCML, as it is the default mode in DCS, and there no efficient way to check which mode the aircraft is in
			 * 
			 * DCML
			 *	Not PRECISE :
			 *		N123456 > ENT
			 *		E1234567 > ENT
			 *		Warning, in not PRECISE, only 6 digits for longitude if first one is 0 : E012345 > ENT
			 *		
			 *	PRECISE : N1234 > ENT > 5678
			 *	
			 * SEC (not used here information only)
			 *	Not PRECISE : N123456 > ENT
			 *	PRECISE : N123456 > ENT > 78
			*/
			//

			StringBuilder sb = new StringBuilder();

			string sInputCleaned = RemoveSeparators(coord.Replace(" ", ""));
			if (sInputCleaned.Length < 1) // we only require the hemisphere or meridian side, for the rest we will remplace any missing digit by 0
				throw new Exception($"Input coordinate string is incorrect {coord}");

			// hemisphere
			int iLongitudeOffset = 0; // one more digit for longitudes
			char c = sInputCleaned[0];
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
				iLongitudeOffset = 1;
			}
			else if (c == 'W')
			{
				sb.Append(ufc.GetCommand("4"));
				iLongitudeOffset = 1;
			}
			else
			{
				throw new Exception($"Input coordinate string is incorrect {coord}");
			}

			BuildCoordinate_NotPreciseDigits(ufc, sInputCleaned.Substring(1, sInputCleaned.Length - 1), iLongitudeOffset, sb);
			BuildCoordinate_PreciseDigits(ufc, sInputCleaned.Substring(1, sInputCleaned.Length - 1), iLongitudeOffset, sb);

			Console.WriteLine(sb.ToString());
			return sb.ToString();
		}

		private void BuildCoordinate_NotPreciseDigits(Device ufc, string sInputCleanedDigits, int iLongitudeOffset, StringBuilder sb)
		{
			sb.Append(StartCondition("IsPreciseNotSelected"));

			int iStartOffset = 0;
			if (sInputCleanedDigits.Length > 1 && sInputCleanedDigits[0] == '0' && iLongitudeOffset > 0)
				iStartOffset = 1; // ignore first 0 for longitude  if not precise

			// first 4 or 5 digits
			for (int i = 0 + iStartOffset; i < 4 + iLongitudeOffset; i++)
			{
				BuildCoordinate_AddDigit(ufc, sInputCleanedDigits, i, sb);
			}

			// not precise, add 2 more digits
			for (int i = 4 + iLongitudeOffset; i < 6 + iLongitudeOffset; i++)
			{
				BuildCoordinate_AddDigit(ufc, sInputCleanedDigits, i, sb);
			}
			sb.Append(EndCondition("IsPreciseNotSelected"));
		}

		private void BuildCoordinate_PreciseDigits(Device ufc, string sInputCleanedDigits, int iLongitudeOffset, StringBuilder sb)
		{
			sb.Append(StartCondition("IsPreciseSelected"));
			// first 4 or 5 digits
			for (int i = 0; i < 4 + iLongitudeOffset; i++)
			{
				BuildCoordinate_AddDigit(ufc, sInputCleanedDigits, i, sb);
			}

			// enter and add 4 more digits
			sb.Append(ufc.GetCommand("ENT"));
			for (int i = 4 + iLongitudeOffset; i < 8 + iLongitudeOffset; i++)
			{
				BuildCoordinate_AddDigit(ufc, sInputCleanedDigits, i, sb);
			}
			sb.Append(EndCondition("IsPreciseSelected"));
		}

		private void BuildCoordinate_AddDigit(Device ufc, string sInputCleaned, int iInputPosition, StringBuilder sb)
		{
			char c = '0';
			if (!string.IsNullOrEmpty(sInputCleaned) && iInputPosition < sInputCleaned.Length)
			{
				c = sInputCleaned[iInputPosition];
			}

			if (c < 48 || c > 57)
				throw new Exception($"Input coordinate string is incorrect {sInputCleaned}");

			sb.Append(ufc.GetCommand(c.ToString()));
		}
	}
}
