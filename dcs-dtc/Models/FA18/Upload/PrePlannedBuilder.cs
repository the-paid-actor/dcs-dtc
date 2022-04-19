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

			AppendCommand(lmfd.GetCommand("OSB-18")); // MENU
			AppendCommand(lmfd.GetCommand("OSB-05")); // STORES

			if(_cfg.PrePlanned.Sta2.AnySelected) {
				var stationList = new List<PrePlannedStation> { _cfg.PrePlanned.Sta2 };
				if (_cfg.PrePlanned.Sta7.AnySelected && _cfg.PrePlanned.Sta7.stationType == _cfg.PrePlanned.Sta2.stationType) stationList.Add(_cfg.PrePlanned.Sta7);
				if (_cfg.PrePlanned.Sta3.AnySelected && _cfg.PrePlanned.Sta3.stationType == _cfg.PrePlanned.Sta2.stationType) stationList.Add(_cfg.PrePlanned.Sta3);
				if (_cfg.PrePlanned.Sta8.AnySelected && _cfg.PrePlanned.Sta8.stationType == _cfg.PrePlanned.Sta2.stationType) stationList.Insert(0, _cfg.PrePlanned.Sta8);


				AppendCommand(StartCondition(GetCondition(_cfg.PrePlanned.Sta2)));
                AppendCommand(lmfd.GetCommand("OSB-06")); // First-BTN aka Sta2
                AppendCommand(GetDsplyCommand(lmfd, _cfg.PrePlanned.Sta2.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
				foreach (PrePlannedStation station in stationList) {
                    AppendCommand(InputStation(lmfd, ufc, station));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

					doneStations.Add(station);
				}
                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(lmfd.GetCommand("OSB-06")); // First-BTN aka Sta2
				if (isJdam(_cfg.PrePlanned.Sta2)) AppendCommand(lmfd.GetCommand("OSB-06")); 
				AppendCommand(EndCondition(GetCondition(_cfg.PrePlanned.Sta2)));
            }
			if (_cfg.PrePlanned.Sta3.AnySelected && !doneStations.Contains(_cfg.PrePlanned.Sta3)) {
				var stationList = new List<PrePlannedStation> { _cfg.PrePlanned.Sta3 };
				if (_cfg.PrePlanned.Sta7.AnySelected && _cfg.PrePlanned.Sta7.stationType == _cfg.PrePlanned.Sta3.stationType) stationList.Insert(0, _cfg.PrePlanned.Sta7);
				if (_cfg.PrePlanned.Sta8.AnySelected && _cfg.PrePlanned.Sta8.stationType == _cfg.PrePlanned.Sta3.stationType) stationList.Insert(0, _cfg.PrePlanned.Sta8);

				AppendCommand(StartCondition(GetCondition(_cfg.PrePlanned.Sta3)));
				var buttonNumber = 6;
				if (_cfg.PrePlanned.Sta2.stationType != StationType.AA) buttonNumber++;
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber));

                AppendCommand(GetDsplyCommand(lmfd, _cfg.PrePlanned.Sta3.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
				foreach (PrePlannedStation station in stationList) {
                    AppendCommand(InputStation(lmfd, ufc, station));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

					doneStations.Add(station);
				}

                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				if (isJdam(_cfg.PrePlanned.Sta3)) AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				AppendCommand(EndCondition(GetCondition(_cfg.PrePlanned.Sta3)));
			}

			if (_cfg.PrePlanned.Sta7.AnySelected && !doneStations.Contains(_cfg.PrePlanned.Sta7)) {
				var stationList = new List<PrePlannedStation> { _cfg.PrePlanned.Sta7 };
				if (_cfg.PrePlanned.Sta8.AnySelected && _cfg.PrePlanned.Sta8.stationType == _cfg.PrePlanned.Sta7.stationType) stationList.Insert(0, _cfg.PrePlanned.Sta8);

				AppendCommand(StartCondition(GetCondition(_cfg.PrePlanned.Sta7)));

				var buttonNumber = 6;
				if (_cfg.PrePlanned.Station5ToConsider) buttonNumber++;
				if (_cfg.PrePlanned.Sta2.stationType != StationType.AA) buttonNumber++;
				if (_cfg.PrePlanned.Sta3.stationType != StationType.AA) buttonNumber++;
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 

                AppendCommand(GetDsplyCommand(lmfd, _cfg.PrePlanned.Sta7.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
                AppendCommand(lmfd.GetCommand("OSB-04")); // MSN
				foreach (PrePlannedStation station in stationList) {
                    AppendCommand(InputStation(lmfd, ufc, station));
                    AppendCommand(lmfd.GetCommand("OSB-13")); // STEP

					doneStations.Add(station);
				}

                AppendCommand(lmfd.GetCommand("OSB-19")); // RETURN
                AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				if (isJdam(_cfg.PrePlanned.Sta7)) AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 
				AppendCommand(EndCondition(GetCondition(_cfg.PrePlanned.Sta7)));
			}

			if (_cfg.PrePlanned.Sta8.AnySelected && !doneStations.Contains(_cfg.PrePlanned.Sta8)) {
				var station = _cfg.PrePlanned.Sta8;

				AppendCommand(StartCondition(GetCondition(_cfg.PrePlanned.Sta8)));

				var buttonNumber = 6;
				if (_cfg.PrePlanned.Station5ToConsider) buttonNumber++;
				if (_cfg.PrePlanned.Sta2.stationType != StationType.AA) buttonNumber++;
				if (_cfg.PrePlanned.Sta3.stationType != StationType.AA) buttonNumber++;
				if (_cfg.PrePlanned.Sta7.stationType != StationType.AA) buttonNumber++;
				if(buttonNumber == 10) AppendCommand(lmfd.GetCommand("OSB-10")); 
				else AppendCommand(lmfd.GetCommand("OSB-0" + buttonNumber)); 

                AppendCommand(GetDsplyCommand(lmfd, _cfg.PrePlanned.Sta8.stationType)); // JDAM/JSOW/SLAM/SLMR-DSPLY
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
				AppendCommand(EndCondition(GetCondition(_cfg.PrePlanned.Sta8)));
			}
        }

		private string InputStation(Device lmfd, Device ufc, PrePlannedStation station)
        {
			var sb = new StringBuilder();

			if(station.PP1.Enabled)
            {
                // sb.Append(lmfd.GetCommand("OSB-06")); // PP1
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
			sb.Append(BuildNumber(ufc, coord.Elev)); // Enter elevation
			sb.Append(ufc.GetCommand("ENT"));
            sb.Append(lmfd.GetCommand("OSB-14")); // TGT-UFC
            sb.Append(lmfd.GetCommand("OSB-14")); // TGT-UFC
			sb.Append(ufc.GetCommand("Opt3")); // Pos
			sb.Append(Wait());
			sb.Append(ufc.GetCommand("Opt1")); // Lat
			sb.Append(Wait());
			sb.Append(BuildCoordinate(ufc, coord.Lat));
			sb.Append(ufc.GetCommand("ENT"));
			sb.Append(ufc.GetCommand("Opt3")); // Lon
			sb.Append(Wait());
			sb.Append(BuildCoordinate(ufc, coord.Lon));
			sb.Append(ufc.GetCommand("ENT"));
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
					condition = "STA_IS_GBUTE_" + station.stationNumber;
					break;
				case StationType.GBU32:
					condition = "STA_IS_GBUTT_" + station.stationNumber;
					break;
				case StationType.GBU31:
					condition = "STA_IS_GBUTO_" + station.stationNumber;
					break;
				case StationType.JSOWA:
					condition = "STA_IS_JSOWA_" + station.stationNumber;
					break;
				case StationType.JSOWC:
					condition = "STA_IS_JSOWC_" + station.stationNumber;
					break;
				case StationType.SLAM:
					condition = "STA_IS_SLAM_" + station.stationNumber;
					break;
				case StationType.SLAMER:
					condition = "STA_IS_SLAMER_" + station.stationNumber;
					break;
            }

			return condition;
        }

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

		private string BuildNumber(Device ufc, int num)
        {
			var sb = new StringBuilder();

			foreach (var c in num.ToString().ToCharArray())
            {
				sb.Append(ufc.GetCommand(c.ToString()));
            }

			return sb.ToString();	
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
