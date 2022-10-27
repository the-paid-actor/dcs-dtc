using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using DTC.Models.FA18;
using DTC.Models.Base;
using DTC.Models.FA18.Upload;
using System.Windows.Forms;
using DTC.Models.DCS;
using DTC.Models.Presets;

namespace DTC.Models
{
	internal class FA18PreUploadInit : BaseBuilder
	{

		public FA18PreUploadInit(IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
		}

		public override void Build()
		{
            var lmfd = _aircraft.GetDevice("LMFD");
            /* If not on the TAC page, then press OSB 18 */
            AppendCommand(StartCondition("LMFD_NOT_TAC"));
            AppendCommand(lmfd.GetCommand("OSB-18"));
            AppendCommand(EndCondition("LMFD_NOT_TAC"));
            AppendCommand(lmfd.GetCommand("OSB-03")); /* HUD */

            var rmfd = _aircraft.GetDevice("RMFD");
            /* If not on the SUPT page, then press OSB 18 */
            AppendCommand(StartCondition("RMFD_NOT_SUPT"));
            AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(EndCondition("RMFD_NOT_SUPT"));
            /* If not on the SUPT page, then press OSB 18 */
            AppendCommand(StartCondition("RMFD_NOT_SUPT"));
            AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(EndCondition("RMFD_NOT_SUPT"));
            AppendCommand(rmfd.GetCommand("OSB-15")); /* FCS */
        }
    }

	public class FA18Upload
	{
		private int tcpPort = 42070;

		private FA18Configuration _cfg;
		private FA18Commands fa18 = new FA18Commands();

		public FA18Upload(FA18Configuration cfg)
		{
			tcpPort = Settings.TCPSendPort;

			_cfg = cfg;
		}

		public void Load()
		{
			var sb = new StringBuilder();

			var preInit = new FA18PreUploadInit(fa18, sb);
			preInit.Build();

			if (_cfg.Waypoints.EnableUpload)
			{
				var waypointBuilder = new WaypointBuilder(_cfg, fa18, sb);
				waypointBuilder.Build();
			}

			if (_cfg.Sequences.EnableUpload)
			{
				var sequenceBuilder = new SequenceBuilder(_cfg, fa18, sb);
				sequenceBuilder.Build();
			}

			if (_cfg.PrePlanned.EnableUpload)
			{
				var prePlannedBuilder = new PrePlannedBuilder(_cfg, fa18, sb);
				prePlannedBuilder.Build();
			}

			if (_cfg.CMS.EnableUpload)
			{
				var cmsBuilder = new CMSBuilder(_cfg, fa18, sb);
				cmsBuilder.Build();
			}

			if (_cfg.Radios.EnableUpload)
			{
				var radioBuilder = new RadioBuilder(_cfg, fa18, sb);
				radioBuilder.Build();
			}

			if (_cfg.Misc.EnableUpload)
			{
				var miscBuilder = new MiscBuilder(_cfg, fa18, sb);
				miscBuilder.Build();
			}

			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}

			var str = sb.ToString();

			if (str != "")
			{
				try
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
				catch (SocketException e)
				{
					MessageBox.Show("Error:" + e.ToString(), "Connection error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
