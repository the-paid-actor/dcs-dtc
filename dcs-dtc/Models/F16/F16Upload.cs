using System.Text;
using DTC.Models.F16;
using DTC.Models.Base;
using DTC.Models.F16.Upload;

namespace DTC.Models
{
	public class F16Upload
	{
		private F16Configuration _cfg;
		private F16Commands f16 = new F16Commands();

		public F16Upload(F16Configuration cfg)
		{
			_cfg = cfg;
		}

		internal F16Configuration Cfg => _cfg;

		public void Load()
		{
			var sb = new StringBuilder();

			if (_cfg.Waypoints.EnableUpload)
			{
				var waypointBuilder = new WaypointBuilder(_cfg, f16, sb);
				waypointBuilder.Build();
			}

			if (_cfg.Radios.EnableUpload)
			{
				var radioBuilder = new RadioBuilder(_cfg, f16, sb);
				radioBuilder.Build();
			}

			if (_cfg.CMS.EnableUpload)
			{
				var cmsBuilder = new CMSBuilder(_cfg, f16, sb);
				cmsBuilder.Build();
			}

			if (_cfg.Misc.EnableUpload)
			{
				var miscBuilder = new MiscBuilder(_cfg, f16, sb);
				miscBuilder.Build();
			}

			if (_cfg.HARM.EnableUpload)
			{
				var harmBuilder = new HARMBuilder(_cfg, f16, sb);
				harmBuilder.Build();
			}

			if (_cfg.HTS.EnableUpload)
			{
				var htsBuilder = new HTSBuilder(_cfg, f16, sb);
				htsBuilder.Build();
			}

			if (_cfg.MFD.EnableUpload)
			{
				var mfdBuilder = new MFDBuilder(_cfg, f16, sb);
				mfdBuilder.Build();
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