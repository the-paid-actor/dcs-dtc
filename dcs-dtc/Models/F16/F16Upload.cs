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

        internal F16Configuration Cfg => _cfg;

        public void Load(bool waypoints, int wptStart, int wptEnd, bool radios, bool cms, bool mfds)
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
			if (mfds)
			{
				BuildMFD(sb);
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

				BuildMFD(sb, leftMFD, config.LeftMFD);
				BuildMFD(sb, rightMFD, config.RightMFD);

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

		private void BuildMFD(StringBuilder sb, Device d, MFDConfiguration mfdConfig)
		{
			sb.Append(d.GetCommand("OSB-14-PG1"));
			sb.Append(d.GetCommand("OSB-13-PG2"));

			sb.Append(d.GetCommand("OSB-14-PG1"));
			sb.Append(d.GetCommand("OSB-14-PG1"));
			BuildPage(sb, d, mfdConfig.Page1);
			sb.Append(d.GetCommand("OSB-13-PG2"));
			sb.Append(d.GetCommand("OSB-13-PG2"));
			BuildPage(sb, d, mfdConfig.Page2);
			sb.Append(d.GetCommand("OSB-12-PG3"));
			sb.Append(d.GetCommand("OSB-12-PG3"));
			BuildPage(sb, d, mfdConfig.Page3);

			if (mfdConfig.SelectedPage == 1)
			{
				sb.Append(d.GetCommand("OSB-14-PG1"));
			}
			else if (mfdConfig.SelectedPage == 2)
			{
				sb.Append(d.GetCommand("OSB-13-PG2"));
			}
		}

		private void BuildPage(StringBuilder sb, Device d, Page page)
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

		private void BuildCMS(StringBuilder sb)
		{
			var ufc = f16.Devices["UFC"];
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));

			sb.Append(ufc.GetCommand("LIST"));
			sb.Append(ufc.GetCommand("7"));

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

			var ufc = f16.Devices["UFC"];
			Waypoint wpt = null;

			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("RTN"));
			sb.Append(ufc.GetCommand("4"));

			for (var i = wptStart-1; i < wptEnd; i++)
			{
				if (i < wpts.Count)
				{
					wpt = wpts[i];
				}

				BuildDigits(sb, ufc, (i + 1).ToString());
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
