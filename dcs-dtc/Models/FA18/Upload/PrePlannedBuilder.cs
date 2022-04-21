using System.Collections.Generic;
using System.Text;
using DTC.Models.DCS;
using DTC.Models.FA18.PrePlanned;

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
			var doneStations = new List<PrePlannedStation>();
			var sta2 = _cfg.PrePlanned.Sta2;
			var sta3 = _cfg.PrePlanned.Sta3;
			var sta7 = _cfg.PrePlanned.Sta7;
			var sta8 = _cfg.PrePlanned.Sta8;

			AppendCommand(lmfd.GetCommand("OSB-18")); // MENU
			AppendCommand(lmfd.GetCommand("OSB-05")); // STORES

			if(sta2.AnySelected) {
				var stationList = new List<PrePlannedStation> { sta2 };
				if (hasSameWeapon(sta8, sta2)) stationList.Insert(0, sta8);
				if (hasSameWeapon(sta7, sta2)) stationList.Add(sta7);
				if (hasSameWeapon(sta3, sta2)) stationList.Add(sta3);

				AppendCommand(StartCondition(GetCondition(sta2)));
                AppendCommand(lmfd.GetCommand("OSB-06")); // First-BTN aka Sta2
                AppendCommand(GetDsplyCommand(lmfd, sta2.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
				foreach (PrePlannedStation station in stationList) {
                    AppendCommand(InputStation(lmfd, ufc, station));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

					doneStations.Add(station);
				}
                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(lmfd.GetCommand("OSB-06")); // First-BTN aka Sta2
				if (isJdam(sta2)) AppendCommand(lmfd.GetCommand("OSB-06")); 
				AppendCommand(EndCondition(GetCondition(sta2)));
            }
			if (sta3.AnySelected && !doneStations.Contains(sta3)) {
				var stationList = new List<PrePlannedStation> { sta3 };
				if (hasSameWeapon(sta7, sta3)) stationList.Insert(0, sta7);
				if (hasSameWeapon(sta8, sta3)) stationList.Insert(0, sta8);

				AppendCommand(StartCondition(GetCondition(sta3)));
				var buttonNumber = 6;
				if (sta2.stationType != StationType.AA) buttonNumber++;
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber));

                AppendCommand(GetDsplyCommand(lmfd, sta3.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
				foreach (PrePlannedStation station in stationList) {
                    AppendCommand(InputStation(lmfd, ufc, station));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

					doneStations.Add(station);
				}

                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				if (isJdam(sta3)) AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				AppendCommand(EndCondition(GetCondition(sta3)));
			}

			if (sta7.AnySelected && !doneStations.Contains(sta7)) {
				var stationList = new List<PrePlannedStation> { sta7 };
				if (hasSameWeapon(sta8, sta7)) stationList.Insert(0, sta8);

				AppendCommand(StartCondition(GetCondition(sta7)));

				var buttonNumber = 6;
				if (_cfg.PrePlanned.Station5ToConsider) buttonNumber++;
				if (sta2.stationType != StationType.AA) buttonNumber++;
				if (sta3.stationType != StationType.AA && sta3.stationType != sta2.stationType) buttonNumber++;
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 

                AppendCommand(GetDsplyCommand(lmfd, sta7.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
				foreach (PrePlannedStation station in stationList) {
                    AppendCommand(InputStation(lmfd, ufc, station));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

					doneStations.Add(station);
				}

                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				if (isJdam(sta7)) AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				AppendCommand(EndCondition(GetCondition(sta7)));
			}

			if (sta8.AnySelected && !doneStations.Contains(sta8)) {
				var station = sta8;

				AppendCommand(StartCondition(GetCondition(sta8)));

				var buttonNumber = 6;
				if (_cfg.PrePlanned.Station5ToConsider) buttonNumber++;
				if (sta2.stationType != StationType.AA) buttonNumber++;
				if (sta3.stationType != StationType.AA && sta3.stationType != sta2.stationType) buttonNumber++;
				if (sta7.stationType != StationType.AA && 
					sta7.stationType != sta2.stationType && 
					sta7.stationType != sta3.stationType) buttonNumber++;
				if(buttonNumber == 10) AppendCommand(lmfd.GetCommand("OSB-10")); 
				else AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 

                AppendCommand(GetDsplyCommand(lmfd, sta8.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
                AppendCommand(InputStation(lmfd, ufc, station));
                AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

                doneStations.Add(station);

                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
				if(buttonNumber == 10) AppendCommand(lmfd.GetCommand("OSB-10")); 
				else AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				if (isJdam(station))
                {
                    if(buttonNumber == 10) AppendCommand(lmfd.GetCommand("OSB-10")); 
                    else AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
                }
				AppendCommand(EndCondition(GetCondition(sta8)));
			}
        }

		private bool hasSameWeapon(PrePlannedStation sta, PrePlannedStation reference)
        {
			return (sta.AnySelected && sta.stationType == reference.stationType);
        }

		private string InputStation(Device lmfd, Device ufc, PrePlannedStation station)
        {
			var sb = new StringBuilder();

			if(station.PP1.Enabled)
            {
				sb.Append(InputCoordinate(lmfd, ufc, station.PP1));
            }
			if(station.PP2.Enabled)
            {
                sb.Append(lmfd.GetCommand("OSB-07")); // PP2
				sb.Append(InputCoordinate(lmfd, ufc, station.PP2));
                sb.Append(lmfd.GetCommand("OSB-06")); // PP1
            }
			if(station.PP3.Enabled)
            {
                sb.Append(lmfd.GetCommand("OSB-08")); // PP3
				sb.Append(InputCoordinate(lmfd, ufc, station.PP3));
                sb.Append(lmfd.GetCommand("OSB-06")); // PP1
            }
			if(station.PP4.Enabled)
            {
                sb.Append(lmfd.GetCommand("OSB-09")); // PP4
				sb.Append(InputCoordinate(lmfd, ufc, station.PP4));
                sb.Append(lmfd.GetCommand("OSB-06")); // PP1
            }
			if(station.PP5.Enabled)
            {
                sb.Append(lmfd.GetCommand("OSB-10")); // PP5
				sb.Append(InputCoordinate(lmfd, ufc, station.PP5));
                sb.Append(lmfd.GetCommand("OSB-06")); // PP1
            }

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
			var dsplyCommand = "";
            switch(type)
            {
                case StationType.GBU38:
                    dsplyCommand = lmfd.GetCommand("OSB-11");
                    break;
                case StationType.GBU32:
                    dsplyCommand = lmfd.GetCommand("OSB-11");
                    break;
                case StationType.GBU31:
                    dsplyCommand = lmfd.GetCommand("OSB-11");
                    break;
                default:
                    dsplyCommand = lmfd.GetCommand("OSB-12");
                    break;
            }
			return dsplyCommand;
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
				case StationType.GBU31:
					condition = "STA_IS_GBUTO_";
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

		// Name is only slightly misleading as it will return true also for JSOWs.
		// The reason behind this is that both JDAM and JSOW display the same behaviour when deselecting.
		private bool isJdam(PrePlannedStation station)
        {
			switch (station.stationType)
			{
				case StationType.GBU38: return true;
				case StationType.GBU32: return true;
				case StationType.GBU31: return true;
				case StationType.JSOWA: return true;
				case StationType.JSOWC: return true;
				default: return false;
			}
        }

		private string BuildCoordinate(Device ufc, string coord)
		{
			var sb = new StringBuilder();

			var latStr = RemoveSeparators(coord.Replace(" ", ""));
			var i = 0;
			var lon = false;

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
                    if (!(i == 0 && c == '0' && lon))
                    {
                        sb.Append(ufc.GetCommand(c.ToString()));
                        i++;
                        lon = false;
                    }					
					if(i == 6) {
						sb.Append(Wait());
						sb.Append(ufc.GetCommand("ENT"));
					}
							
				}
			}
			return sb.ToString();
		}
    }
}
