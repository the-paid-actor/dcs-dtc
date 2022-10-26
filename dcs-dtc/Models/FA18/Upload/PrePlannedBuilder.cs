using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using DTC.Models.DCS;
using DTC.Models.FA18.PrePlanned;
using static System.Collections.Specialized.BitVector32;

namespace DTC.Models.FA18.Upload
{
    internal class PrePlannedBuilder : BaseBuilder
    {
		private FA18Configuration _cfg;

		public PrePlannedBuilder(FA18Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
			_cfg = cfg;
		}

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");
            var lmfd = _aircraft.GetDevice("LMFD");

            /* get a group of stations to be configured */
            var stationGroups = GroupStationsByPayloadType();

            AppendCommand(lmfd.GetCommand("OSB-18")); // MENU
            AppendCommand(lmfd.GetCommand("OSB-05")); // STORES
            AppendCommand(Wait());

            for (int group_no = 0; group_no < stationGroups.Count; group_no++) {
                var group = stationGroups[group_no];
                string wpnGroupSelectCmd = lmfd.GetCommand(groupNo_to_WpnTypeSelectCmd(group_no));
                var firstStation = group[0]; /* first station in group (with same type of payload) */

                AppendCommand(StartCondition(GetCondition(firstStation)));
                AppendCommand(wpnGroupSelectCmd); // Weapon group select (top row OSB)

                if (firstStation.stationType == StationType.SLAMER || firstStation.stationType == StationType.SLAM)
                {
                    bool hasAnyStp = false;
                    foreach (var sta in group)
                    {
                        if (sta.AnyStpEnabled)
                        {
                            hasAnyStp = true;
                            break;
                        }
                    }

                    if (hasAnyStp)
                    {
                        AppendCommand(lmfd.GetCommand("OSB-11")); // STP select
                        foreach (var sta in group)
                        {
                            AppendCommand(InputSteerpoints(lmfd, ufc, sta));
                            AppendCommand(lmfd.GetCommand("OSB-13")); // STEP to next station of same station type
                        }
                        AppendCommand(lmfd.GetCommand("OSB-11")); // STP deselect
                    }
                }
                
                AppendCommand(GetDsplyCommand(lmfd, firstStation.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
                foreach (var sta in group)
                {
                    AppendCommand(InputStation(lmfd, ufc, sta));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP to next station of same station type
                }
                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(wpnGroupSelectCmd); // Weapon group select (top row OSB)
                if (isJdamOrJsow(firstStation.stationType))
                    AppendCommand(wpnGroupSelectCmd); // Weapon group select (top row OSB)
                AppendCommand(EndCondition(GetCondition(firstStation)));
            }
        }

        private string InputSteerpoints(Device lmfd, Device ufc, PrePlannedStation sta)
        {
            if (!sta.AnyStpEnabled)
                return "";

            var sb = new StringBuilder();

            for (int i = 1; i <= 5; i++) {
                sb.Append(ufc.GetCommand("Opt1")); // STP1
                sb.Append(Wait());
                sb.Append(ufc.GetCommand("Opt5")); // DEL
                sb.Append(Wait());
            }

            int stpProgNumber = 1;
            foreach (var stp in sta.Steerpoints) {
                if (!stp.Enabled) continue;
                
                sb.Append(ufc.GetCommand(String.Format("Opt{0}", stpProgNumber)));
                sb.Append(Wait());

                if (stp.useCoordinate)
                {
                    sb.Append(ufc.GetCommand("Opt3")); // POSN
                    sb.Append(Wait());
                    sb.Append(ufc.GetCommand("Opt1")); // LAT
                    sb.Append(Wait());
                    sb.Append(BuildCoordinate(ufc, stp.Lat));
                    sb.Append(ufc.GetCommand("ENT"));
                    sb.Append(WaitLong());

                    sb.Append(ufc.GetCommand("Opt3")); // POSN
                    sb.Append(Wait());
                    sb.Append(ufc.GetCommand("Opt3")); // LON
                    sb.Append(Wait());
                    sb.Append(BuildCoordinate(ufc, stp.Lon));
                    sb.Append(ufc.GetCommand("ENT"));
                    sb.Append(WaitLong());

                    sb.Append(ufc.GetCommand("Opt4")); // ELEV
                    sb.Append(Wait());
                    sb.Append(ufc.GetCommand("Opt3")); // FEET
                    sb.Append(Wait());
                    sb.Append(BuildDigits(ufc, stp.Elev.ToString())); // Enter elevation
                    sb.Append(ufc.GetCommand("ENT"));
                    sb.Append(WaitLong());
                }
                else
                {
                    sb.Append(ufc.GetCommand("Opt2")); // WYPT
                    sb.Append(Wait());
                    sb.Append(BuildDigits(ufc, stp.waypointNumber.ToString())); // Enter waypoint number
                    sb.Append(ufc.GetCommand("ENT"));
                    sb.Append(WaitLong());
                }

                stpProgNumber++;
            }

            return sb.ToString();
        }

        private List<List<PrePlannedStation>> GroupStationsByPayloadType()
        {
            List<List<PrePlannedStation>> rv = new List<List<PrePlannedStation>>();

            /* station_numbers: order in which we traverse the stations -- 
             * this is the order that the different payload types are 
             * displayed at the screen OSBs */
            int[] station_numbers = new int[] { 2, 3, 7, 8 };

            /* put each station into a group with the same payload types */
            foreach (var sta_n in station_numbers)
            {
                var sta = _cfg.PrePlanned.Stations[sta_n];
                if (sta.stationType == StationType.AA)
                    continue;
                bool foundGroup = false;
                for (int group_no = 0; group_no < rv.Count; group_no++)
                {
                    var group = rv[group_no];
                    if (group[0].stationType == sta.stationType)
                    {
                        group.Add(sta);
                        foundGroup = true;
                        break;
                    }
                }

                /* If we didn't find a group with the same payload type,
                 * add a new one containing the station to be added. */
                if (!foundGroup)
                    rv.Add(new List<PrePlannedStation> { sta });
            }

            /* sort stations in each group by step order 
             * (using IComparable interface of PrePlannedStation) */
            foreach (var group in rv)
                group.Sort();

            return rv;
        }

        private string groupNo_to_WpnTypeSelectCmd(int group_no)
        {
            int btn_no = group_no + 6;
            if (_cfg.PrePlanned.Station5ToConsider && btn_no >= 8) btn_no++; /* station 5 introduces an extra option between stations 2,3 and 7,8 */
            string wpnGroupSelectCmd = String.Format("OSB-{0:00}", btn_no);  /* command name for payload type select (top row OSB) */
            return wpnGroupSelectCmd;
        }

		private string InputStation(Device lmfd, Device ufc, PrePlannedStation station)
        {
			var sb = new StringBuilder();

            bool returnToPP1 = false;
            for (int i = 1; i <= 5; i++)
            {
                if (!station.PP[i].Enabled)
                    continue;

                /* select PP if necessary */
                if (i != 1)
                {
                    sb.Append(lmfd.GetCommand(String.Format("OSB-{0:00}", 5 + i)));
                    returnToPP1 = true;
                }

                /* return to PP1 if other PP was selected */
                sb.Append(InputCoordinate(lmfd, ufc, station.PP[i]));
            }

            if (returnToPP1)
                sb.Append(lmfd.GetCommand("OSB-06")); // PP1

			return sb.ToString();
        }

		private string InputCoordinate(Device lmfd, Device ufc, PrePlannedCoordinate coord)
        {
			var sb = new StringBuilder();
            sb.Append(lmfd.GetCommand("OSB-14")); // TGT-UFC
			sb.Append(ufc.GetCommand("Opt4")); // Elev
			sb.Append(Wait());
			sb.Append(ufc.GetCommand("Opt3")); // Feet
			sb.Append(Wait());
			sb.Append(BuildDigits(ufc, coord.Elev.ToString())); // Enter elevation
			sb.Append(ufc.GetCommand("ENT"));
			sb.Append(WaitLong());
            sb.Append(lmfd.GetCommand("OSB-14")); // TGT-UFC
            sb.Append(lmfd.GetCommand("OSB-14")); // TGT-UFC
			sb.Append(ufc.GetCommand("Opt3")); // Pos
			sb.Append(Wait());
			sb.Append(ufc.GetCommand("Opt1")); // Lat
			sb.Append(Wait());
			sb.Append(BuildCoordinate(ufc, coord.Lat));
			sb.Append(ufc.GetCommand("ENT"));
			sb.Append(WaitLong());
			sb.Append(ufc.GetCommand("Opt3")); // Lon
			sb.Append(Wait());
			sb.Append(BuildCoordinate(ufc, coord.Lon));
			sb.Append(ufc.GetCommand("ENT"));
			sb.Append(WaitLong());
            sb.Append(lmfd.GetCommand("OSB-14")); // TGT-UFC
			return sb.ToString();
        }

		private string GetDsplyCommand(Device lmfd, StationType type)
        {
            switch(type)
            {
                case StationType.GBU38:
                case StationType.GBU32:
                case StationType.GBU31NP:
                case StationType.GBU31PP:
                    return lmfd.GetCommand("OSB-11");
                default:
                    return lmfd.GetCommand("OSB-12");
            }
        }

		private string GetCondition(PrePlannedStation station)
        {
			var condition = "";
            switch (station.stationType)
            {
				case StationType.GBU38:
					condition = "STA_IS_GBUTE_";
					break;
				case StationType.GBU32:
					condition = "STA_IS_GBUTT_";
					break;
				case StationType.GBU31NP:
					condition = "STA_IS_GBUTO_";
					break;
				case StationType.GBU31PP:
					condition = "STA_IS_GBUTOP_";
					break;
				case StationType.JSOWA:
					condition = "STA_IS_JSOWA_";
					break;
				case StationType.JSOWC:
					condition = "STA_IS_JSOWC_";
					break;
				case StationType.SLAM:
					condition = "STA_IS_SLAM_";
					break;
				case StationType.SLAMER:
					condition = "STA_IS_SLAMER_";
					break;
            }

			return condition + station.stationNumber;
        }

		private bool isJdamOrJsow(StationType stationType)
    {
			switch (stationType)
			{
				case StationType.GBU38:
				case StationType.GBU32:
				case StationType.GBU31NP:
				case StationType.GBU31PP:
				case StationType.JSOWA:
				case StationType.JSOWC:
					return true;
				default:
					return false;
			}
        }



		private string BuildCoordinate(Device ufc, string coord) {
            var sb = new StringBuilder();
            
			/* enter hemisphere */
			switch (coord[0]) {
				case 'N':
                    sb.Append(ufc.GetCommand("2"));
                    break;
                case 'S':
                    sb.Append(ufc.GetCommand("8"));
                    break;
                case 'E':
                    sb.Append(ufc.GetCommand("6"));
                    break;
                case 'W':
                    sb.Append(ufc.GetCommand("4"));
                    break;
            }

            /* remove everything thats not a digit */
            string digits = Regex.Replace(coord, "[^0-9]", "");

			if (digits.Length == 9)
			{
				/* If this is a 9 digit coordinate (longitude) and has a leading zero, then remove that */
				if (digits[0] == '0')
					digits = digits.Substring(1);
			}
			else if (digits.Length != 8) /* neither 9 nor 8 digits (we got an invalid input) -- this should not happen */
				throw new ApplicationException("Internal error: number of digits should be 8 or 9 -- (digits:\"" + digits + "\")");

			for (int i = 0; i < digits.Length; i++)
			{
				sb.Append(ufc.GetCommand(digits.Substring(i, 1)));
                
				/* two digits before the end we press ENT */
				if (digits.Length - 1 - i == 2)
				{
                    sb.Append(WaitLong());
                    sb.Append(ufc.GetCommand("ENT"));
                    sb.Append(WaitLong());
                }
			}
			
			return sb.ToString();
        }
    }
}
