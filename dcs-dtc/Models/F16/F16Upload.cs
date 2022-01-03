using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using DTC.Models.F16;
using DTC.Models.F16.Waypoints;
using DTC.Models.F16.MFD;
using DTC.Models.F16.Radios;
using DTC.Models.DCS;
using System.Configuration;
using DTC.Models.Base;

namespace DTC.Models
{
	public class F16Upload
	{
		private int tcpPort = 42070;

		private F16Configuration _cfg;
		private F16Commands f16 = new F16Commands();

		public F16Upload(F16Configuration cfg)
		{
			tcpPort = Settings.TCPSendPort;

			_cfg = cfg;
		}

		public void Load(bool waypoints, int wptStart, int wptEnd, bool radios, bool cms, bool mfds, bool misc)
		{
			var sb = new StringBuilder();
			if (waypoints)
			{
				BuildWaypoints(sb, wptStart, wptEnd);
			}
			if (radios)
			{
				BuildRadios(sb);
			}
			if (cms)
			{
				BuildCMS(sb);
			}

			if (misc)
			{
				BuildMisc(sb);
			}

			if (mfds)
			{
				BuildHTSHarmMFDs(sb);
			}

			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}
			var str = sb.ToString();

			if (str != "")
			{
				using (var tcpClient = new TcpClient("127.0.0.1", tcpPort))
				using (var ns = tcpClient.GetStream())
				using (var sw = new StreamWriter(ns))
				{
					var data = "[" + str + "]";
					Console.WriteLine(data);

					sw.WriteLine(data);
					sw.Flush();
				}
			}
		}

		private void BuildMisc(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			//Bingo
			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("2"));

			BuildDigits(sb, ufc, _cfg.Misc.Bingo.ToString());
			sb.Append(ufc.GetCommand("ENTR"));

			sb.Append(ufc.GetCommand("RTN"));

			//CARA
			sb.Append(ufc.GetCommand("2"));

			BuildDigits(sb, ufc, _cfg.Misc.CARAALOW.ToString());
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("DOWN"));

			BuildDigits(sb, ufc, _cfg.Misc.MSLFloor.ToString());
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("DOWN"));

			sb.Append(ufc.GetCommand("RTN"));

			// TGP
			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("0"));
			sb.Append(ufc.GetCommand("5"));

			BuildDigits(sb, ufc, _cfg.Misc.TGPCode.ToString());
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("DOWN"));

			BuildDigits(sb, ufc, _cfg.Misc.LSTCode.ToString());
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("DOWN"));

			sb.Append(ufc.GetCommand("RTN"));

			// Bullseye
			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("0"));
			sb.Append(ufc.GetCommand("8"));
			sb.Append(Wait());

			if (_cfg.Misc.EnableBullseye)
			{
				sb.Append(StartCondition("BULLS_NOT_SELECTED"));
				sb.Append(ufc.GetCommand("0"));
				sb.Append(EndCondition("BULLS_NOT_SELECTED"));
			}
			else
			{
				sb.Append(StartCondition("BULLS_SELECTED"));
				sb.Append(ufc.GetCommand("0"));
				sb.Append(EndCondition("BULLS_SELECTED"));
			}

			sb.Append(ufc.GetCommand("RTN"));

			//TACAN / ILS
			sb.Append(ufc.GetCommand("1"));

			BuildDigits(sb, ufc, _cfg.Misc.TACANChannel.ToString());
			sb.Append(ufc.GetCommand("ENTR"));

			if (_cfg.Misc.TACANBand == F16.Misc.TACANBands.X)
			{
				sb.Append(StartCondition("TACAN_BAND_Y"));
				sb.Append(ufc.GetCommand("0"));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(EndCondition("TACAN_BAND_Y"));
			}
			else
			{
				sb.Append(StartCondition("TACAN_BAND_X"));
				sb.Append(ufc.GetCommand("0"));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(EndCondition("TACAN_BAND_X"));
			}

			sb.Append(ufc.GetCommand("DOWN"));
			sb.Append(ufc.GetCommand("DOWN"));

			BuildDigits(sb, ufc, RemoveSeparators(_cfg.Misc.GetILSFrequency()));
			sb.Append(ufc.GetCommand("ENTR"));

			BuildDigits(sb, ufc, _cfg.Misc.ILSCourse.ToString());
			sb.Append(ufc.GetCommand("ENTR"));

			sb.Append(ufc.GetCommand("DOWN"));
			sb.Append(ufc.GetCommand("RTN"));
		}

		private void BuildHTSHarmMFDs(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("8"));

			sb.Append(Wait());

			sb.Append(StartCondition("NOT_IN_AA"));

			sb.Append(ufc.GetCommand("SEQ"));
			sb.Append(StartCondition("NOT_IN_AG"));

			BuildHTSManualTable(sb);
			BuildHARM(sb);
			BuildMFD(sb);

			sb.Append(EndCondition("NOT_IN_AG"));

			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("8"));
			sb.Append(ufc.GetCommand("SEQ"));

			sb.Append(EndCondition("NOT_IN_AA"));

			sb.Append(ufc.GetCommand("RTN"));
		}

		private string StartCondition(string condition)
		{
			var str = "{'start_condition': '" + condition + "'},";
			return str.Replace("'", "\"");
		}

		private string EndCondition(string condition)
		{
			var str = "{'end_condition': '" + condition + "'},";
			return str.Replace("'", "\"");
		}

		private string Wait()
		{
			var str = "{'device':'wait', 'delay': 200},";
			return str.Replace("'", "\"");
		}

		private void BuildHTSManualTable(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("0"));
			sb.Append(Wait());

			sb.Append(StartCondition("HTS_DED"));
			
			sb.Append(ufc.GetCommand("ENTR"));

			for (var i = 0; i < 8; i++)
			{
				if (_cfg.HTS.ManualEmitters.Length > i)
				{
					BuildDigits(sb, ufc, _cfg.HTS.ManualEmitters[i].ToString());
				}
				else
				{
					sb.Append(ufc.GetCommand("0"));
				}
				sb.Append(ufc.GetCommand("ENTR"));
			}

			sb.Append(EndCondition("HTS_DED"));
			sb.Append(ufc.GetCommand("RTN"));
		}

		private void BuildHARM(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("0"));

			//sb.Append(StartCondition("NAV"));
			sb.Append(ufc.GetCommand("AG"));

			//condition
			sb.Append(StartCondition("HARM"));
			sb.Append(ufc.GetCommand("0"));

			foreach (var table in _cfg.HARM.Tables)
			{
				for (var i = 0; i < 5; i++)
				{
					if (table.Emitters.Length > i)
					{
						BuildDigits(sb, ufc, table.Emitters[i].ToString());
					}
					else
					{
						sb.Append(ufc.GetCommand("0"));
					}
					sb.Append(ufc.GetCommand("ENTR"));
					sb.Append(ufc.GetCommand("DOWN"));
				}

				sb.Append(ufc.GetCommand("INC"));
			}

			sb.Append(EndCondition("HARM"));

			sb.Append(ufc.GetCommand("AG"));
			sb.Append(ufc.GetCommand("RTN"));
		}

		private void BuildMFD(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			var hotas = f16.Devices["HOTAS"];
			var leftMFD = f16.Devices["LMFD"];
			var rightMFD = f16.Devices["RMFD"];

			for (var i = 0; i < _cfg.MFD.Configurations.Length; i++)
			{
				var config = _cfg.MFD.Configurations[i];

				if (config.Mode == Mode.AA)
				{
					sb.Append(ufc.GetCommand("AA"));
				}
				else if (config.Mode == Mode.AG)
				{
					sb.Append(ufc.GetCommand("AG"));
				}
				else if (config.Mode == Mode.DGFT)
				{
					sb.Append(hotas.GetCommand("DGFT"));
				}
				else if (config.Mode == Mode.MSL)
				{
					sb.Append(hotas.GetCommand("MSL"));
				}

				BuildMFD(sb, true, leftMFD, config.LeftMFD);
				BuildMFD(sb, false, rightMFD, config.RightMFD);

				if (config.Mode == Mode.AA)
				{
					sb.Append(ufc.GetCommand("AA"));
				}
				else if (config.Mode == Mode.AG)
				{
					sb.Append(ufc.GetCommand("AG"));
				}
				else if ((config.Mode == Mode.DGFT) || (config.Mode == Mode.MSL))
				{
					sb.Append(hotas.GetCommand("CENTER"));
				}
			}
		}

		private void BuildMFD(StringBuilder sb, bool isLeftMFD, Device d, MFDConfiguration mfdConfig)
		{
			sb.Append(d.GetCommand("OSB-14-PG1"));
			sb.Append(d.GetCommand("OSB-13-PG2"));

			sb.Append(d.GetCommand("OSB-14-PG1"));
			sb.Append(d.GetCommand("OSB-14-PG1"));
			BuildPage(sb, isLeftMFD, d, mfdConfig.Page1);
			sb.Append(d.GetCommand("OSB-13-PG2"));
			sb.Append(d.GetCommand("OSB-13-PG2"));
			BuildPage(sb, isLeftMFD, d, mfdConfig.Page2);
			sb.Append(d.GetCommand("OSB-12-PG3"));
			sb.Append(d.GetCommand("OSB-12-PG3"));
			BuildPage(sb, isLeftMFD, d, mfdConfig.Page3);

			if (mfdConfig.SelectedPage == 1)
			{
				sb.Append(d.GetCommand("OSB-14-PG1"));
			}
			else if (mfdConfig.SelectedPage == 2)
			{
				sb.Append(d.GetCommand("OSB-13-PG2"));
			}
		}

		private void BuildPage(StringBuilder sb, bool isLeftMFD, Device d, Page page)
		{
			if (page == Page.BLANK)
			{
				sb.Append(d.GetCommand("OSB-01-BLANK"));
			}
			else if (page == Page.DTE)
			{
				sb.Append(d.GetCommand("OSB-08-DTE"));
			}
			else if (page == Page.FCR)
			{
				sb.Append(d.GetCommand("OSB-20-FCR"));
			}
			else if (page == Page.FLCS)
			{
				sb.Append(d.GetCommand("OSB-10-FLCS"));
			}
			else if (page == Page.FLIR)
			{
				sb.Append(d.GetCommand("OSB-16-FLIR"));
			}
			else if (page == Page.HAD)
			{
				sb.Append(d.GetCommand("OSB-02-HAD"));

				var condition = (isLeftMFD ? "LMFD_HTS" : "RMFD_HTS");
				sb.Append(StartCondition(condition));

				BuildHTSOnMFDIfOn(sb, isLeftMFD, d);

				sb.Append(EndCondition(condition));
			}
			else if (page == Page.HSD)
			{
				sb.Append(d.GetCommand("OSB-07-HSD"));
			}
			else if (page == Page.RCCE)
			{
				sb.Append(d.GetCommand("OSB-04-RCCE"));
			}
			else if (page == Page.SMS)
			{
				sb.Append(d.GetCommand("OSB-06-SMS"));
				sb.Append(d.GetCommand("OSB-04-RCCE"));
			}
			else if (page == Page.TEST)
			{
				sb.Append(d.GetCommand("OSB-09-TEST"));
			}
			else if (page == Page.TFR)
			{
				sb.Append(d.GetCommand("OSB-17-TFR"));
			}
			else if (page == Page.TGP)
			{
				sb.Append(d.GetCommand("OSB-19-TGP"));
			}
			else if (page == Page.WPN)
			{
				sb.Append(d.GetCommand("OSB-18-WPN"));
			}
		}

		private void BuildHTSOnMFDIfOn(StringBuilder sb, bool isLeftMFD, Device d)
		{
			sb.Append(d.GetCommand("OSB-04-RCCE"));

			var subCondition = (isLeftMFD ? "LMFD_HTS_ALL_NOT_SELECTED" : "RMFD_HTS_ALL_NOT_SELECTED");
			sb.Append(StartCondition(subCondition));
			sb.Append(d.GetCommand("OSB-05"));
			sb.Append(EndCondition(subCondition));

			sb.Append(d.GetCommand("OSB-05"));

			if (_cfg.HTS.EnabledClasses[0])
				sb.Append(d.GetCommand("OSB-20-FCR"));
			if (_cfg.HTS.EnabledClasses[1])
				sb.Append(d.GetCommand("OSB-19-TGP"));
			if (_cfg.HTS.EnabledClasses[2])
				sb.Append(d.GetCommand("OSB-18-WPN"));
			if (_cfg.HTS.EnabledClasses[3])
				sb.Append(d.GetCommand("OSB-17-TFR"));
			if (_cfg.HTS.EnabledClasses[4])
				sb.Append(d.GetCommand("OSB-16-FLIR"));
			if (_cfg.HTS.EnabledClasses[5])
				sb.Append(d.GetCommand("OSB-06-SMS"));
			if (_cfg.HTS.EnabledClasses[6])
				sb.Append(d.GetCommand("OSB-07-HSD"));
			if (_cfg.HTS.EnabledClasses[7])
				sb.Append(d.GetCommand("OSB-08-DTE"));
			if (_cfg.HTS.EnabledClasses[8])
				sb.Append(d.GetCommand("OSB-09-TEST"));
			if (_cfg.HTS.EnabledClasses[9])
				sb.Append(d.GetCommand("OSB-10-FLCS"));
			if (_cfg.HTS.EnabledClasses[10])
				sb.Append(d.GetCommand("OSB-01-BLANK"));
			if (!_cfg.HTS.ManualTableEnabled)
				sb.Append(d.GetCommand("OSB-02-HAD"));

			sb.Append(d.GetCommand("OSB-04-RCCE"));
		}

		private void BuildCMS(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("7"));

			BuildDigits(sb, ufc, _cfg.CMS.ChaffBingo.ToString());
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("DOWN"));

			BuildDigits(sb, ufc, _cfg.CMS.FlareBingo.ToString());
			sb.Append(ufc.GetCommand("ENTR"));

			sb.Append(ufc.GetCommand("SEQ"));

			for (var i = 0; i < _cfg.CMS.Programs.Length; i++)
			{
				var program = _cfg.CMS.Programs[i];

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffBurstQty().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffBurstInterval().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffSalvoQty().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffSalvoInterval().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				sb.Append(ufc.GetCommand("INC"));
			}

			sb.Append(ufc.GetCommand("SEQ"));

			for (var i = 0; i < _cfg.CMS.Programs.Length; i++)
			{
				var program = _cfg.CMS.Programs[i];

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareBurstQty().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareBurstInterval().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareSalvoQty().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareSalvoInterval().ToString())));
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				sb.Append(ufc.GetCommand("INC"));
			}

			sb.Append(ufc.GetCommand("RTN"));
		}

		private void BuildRadios(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];

			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));
			BuildRadio("COM1", _cfg.Radios.COM1, sb, ufc);
			sb.Append(ufc.GetCommand("RTN"));
			BuildRadio("COM2", _cfg.Radios.COM2, sb, ufc);
		}

		private void BuildRadio(string radioCmd, Radio radio, StringBuilder sb, Device ufc)
		{
			sb.Append(ufc.GetCommand(radioCmd));
			sb.Append(ufc.GetCommand("DOWN"));
			sb.Append(ufc.GetCommand("DOWN"));

			for (var i = 0; i < radio.Channels.Length; i++)
			{
				var ch = radio.Channels[i];

				BuildDigits(sb, ufc, ch.Channel.ToString());
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				var freq = ch.GetFrequency().ToString();
				freq = DeleteLeadingZeros(RemoveSeparators(freq));

				BuildDigits(sb, ufc, freq);
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("UP"));
			}

			sb.Append(ufc.GetCommand("1"));
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("DOWN"));
			sb.Append(ufc.GetCommand("DOWN"));

			BuildDigits(sb, ufc, radio.SelectedChannel.Channel.ToString());
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("RTN"));
		}

		private string DeleteLeadingZeros(string s)
		{
			while (s.StartsWith("0"))
			{
				s = s.Remove(0, 1);
			}
			if (s == "") s = "0";
			return s;
		}

		private string RemoveSeparators(string s)
		{
			return s.Replace(",", "").Replace(".", "");
		}

		private void BuildDigits(StringBuilder sb, Device d, string s)
		{
			Console.WriteLine("Sending digits " + s);
			foreach (var c in s.ToCharArray())
			{
				sb.Append(d.GetCommand(c.ToString()));
			}
		}

		private void BuildWaypoints(StringBuilder sb, int wptStart, int wptEnd)
		{
			var wpts = _cfg.Waypoints.Waypoints;
			if (wpts.Count == 0)
			{
				return;
			}

			var wptDiff = wptEnd - wptStart + 1;

			var ufc = f16.Devices["UFC"];

			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("4"));

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
					wpt = wpts[wpts.Count-1];
				}

				if (wpt.Blank)
				{
					continue;
				}

				BuildDigits(sb, ufc, (i + wptStart).ToString());
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildCoordinate(sb, ufc, wpt.Latitude);
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildCoordinate(sb, ufc, wpt.Longitude);
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));

				BuildDigits(sb, ufc, wpt.Elevation.ToString());
				sb.Append(ufc.GetCommand("ENTR"));
				sb.Append(ufc.GetCommand("DOWN"));
				sb.Append(ufc.GetCommand("DOWN"));
			}

			sb.Append(ufc.GetCommand("1"));
			sb.Append(ufc.GetCommand("ENTR"));
			sb.Append(ufc.GetCommand("RTN"));
		}

		private void BuildCoordinate(StringBuilder sb, Device ufc, string coord)
		{
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
		}
	}
}
