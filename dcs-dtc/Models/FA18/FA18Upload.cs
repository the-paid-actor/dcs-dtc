using System.Text;
using DTC.Utilities;
using DTC.Models.FA18;
using DTC.Models.FA18.Upload;
using DTC.Models.DCS;

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
            AppendCommand(StartCondition("LmfdNotTac"));
            AppendCommand(lmfd.GetCommand("OSB-18"));
            AppendCommand(EndCondition("LmfdNotTac"));
            AppendCommand(lmfd.GetCommand("OSB-03")); /* HUD */

            var rmfd = _aircraft.GetDevice("RMFD");
            /* If not on the SUPT page, then press OSB 18 */
            AppendCommand(StartCondition("RmfdNotSupt"));
            AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(EndCondition("RmfdNotSupt"));
            /* If not on the SUPT page, then press OSB 18 */
            AppendCommand(StartCondition("RmfdNotSupt"));
            AppendCommand(rmfd.GetCommand("OSB-18"));
            AppendCommand(EndCondition("RmfdNotSupt"));
            AppendCommand(rmfd.GetCommand("OSB-15")); /* FCS */
        }
    }

	public class FA18Upload
	{
		private FA18Configuration _cfg;
		private FA18Commands fa18 = new FA18Commands();

		public FA18Upload(FA18Configuration cfg)
		{
			_cfg = cfg;
		}

		internal FA18Configuration Cfg => _cfg;

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
				DataSender.Send(str);
			}
		}
	}
}