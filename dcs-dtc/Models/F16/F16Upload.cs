using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using DTC.Models.F16;
using DTC.Models.Base;
using DTC.Models.F16.Upload;

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

		public void Load()
		{
			var sb = new StringBuilder();

			var waypointBuilder = new WaypointBuilder(_cfg, f16, sb);
			var radioBuilder = new RadioBuilder(_cfg, f16, sb);
			var cmsBuilder = new CMSBuilder(_cfg, f16, sb);
			var miscBuilder = new MiscBuilder(_cfg, f16, sb);
			var mfdBuilder = new MFDBuilder(_cfg, f16, sb);

			if (_cfg.Waypoints.EnableUpload)
			{
				waypointBuilder.Build();
			}

			if (_cfg.Radios.EnableUpload)
			{
				radioBuilder.Build();
			}

			if (_cfg.CMS.EnableUpload)
			{
				cmsBuilder.Build();
			}

			if (_cfg.Misc.EnableUpload)
			{
				miscBuilder.Build();
			}

			if (_cfg.MFD.EnableUpload)
			{
				mfdBuilder.Build();
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
	}
}
