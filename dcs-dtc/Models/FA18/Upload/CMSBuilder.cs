using DTC.Models.DCS;
using System.Text;

namespace DTC.Models.FA18.Upload
{
	class CMSBuilder : BaseBuilder
	{
		private FA18Configuration _cfg;

		public CMSBuilder(FA18Configuration cfg, FA18Commands f18, StringBuilder sb) : base(f18, sb)
		{
			_cfg = cfg;
		}

		public override void Build()
		{
			var lmfd = _aircraft.GetDevice("LMFD");
			var cmds = _aircraft.GetDevice("CMDS");

			AppendCommand(cmds.GetCommand("ON"));
			AppendCommand(WaitVeryLong());

			AppendCommand(lmfd.GetCommand("OSB-18")); // Menu
			AppendCommand(lmfd.GetCommand("OSB-17")); // EW

			AppendCommand(lmfd.GetCommand("OSB-08")); // ALE-47
			AppendCommand(lmfd.GetCommand("OSB-09")); // ARM

			for (var i = 0; i < _cfg.CMS.Programs.Length; i++)
            {
				if (_cfg.CMS.Programs[i].ToBeUpdated)
				{
					var prg = _cfg.CMS.Programs[i];
					var defaultPrg = _cfg.CMS.getDefaults()[i];

                    AppendCommand(lmfd.GetCommand("OSB-05")); // Chaff
                    AppendCommand(Wait());
					AdjustQty(lmfd, prg.ChaffQty, defaultPrg.ChaffQty);
                    AppendCommand(lmfd.GetCommand("OSB-05")); // Chaff

                    AppendCommand(lmfd.GetCommand("OSB-04")); // Flare
                    AppendCommand(Wait());
					AdjustQty(lmfd, prg.FlareQty, defaultPrg.FlareQty);
                    AppendCommand(lmfd.GetCommand("OSB-04")); // Flare

                    AppendCommand(lmfd.GetCommand("OSB-14")); // Rpt
                    AppendCommand(Wait());
					AdjustQty(lmfd, prg.Repeat, defaultPrg.Repeat);
                    AppendCommand(lmfd.GetCommand("OSB-14")); // Rpt

                    AppendCommand(lmfd.GetCommand("OSB-15")); // Interval
                    AppendCommand(Wait());
					AdjustInterval(lmfd, prg.Interval, defaultPrg.Interval);
                    AppendCommand(lmfd.GetCommand("OSB-15")); // Interval
				}

				AppendCommand(lmfd.GetCommand("OSB-19")); // Save
				AppendCommand(lmfd.GetCommand("OSB-20")); // Step
            }
            AppendCommand(lmfd.GetCommand("OSB-09")); // RTN
            AppendCommand(lmfd.GetCommand("OSB-18")); // MENU
            AppendCommand(lmfd.GetCommand("OSB-03")); // HUD
		}

		private void AdjustQty(Device lmfd,int target, int defaultValue)
        {
            if(target != defaultValue)
            {
                if (target > defaultValue)
                {
                    for (var s = 0; s < target - defaultValue; s++)
                    {
                        AppendCommand(lmfd.GetCommand("OSB-12")); // Up
                    }
                } else
                {
                    for (var s = 0; s < defaultValue - target; s++)
                    {
                        AppendCommand(lmfd.GetCommand("OSB-13")); // Down
                    }

                }
            }
        }

		private void AdjustInterval(Device lmfd,decimal target, decimal defaultValue)
        {
            if(target != defaultValue)
            {
                if (target > defaultValue)
                {
                    for (var s = 0; s < (target - defaultValue)/(decimal)0.25; s++)
                    {
                        AppendCommand(lmfd.GetCommand("OSB-12")); // Up
                    }
                } else
                {
                    for (var s = 0; s < (defaultValue - target)/(decimal)0.25; s++)
                    {
                        AppendCommand(lmfd.GetCommand("OSB-13")); // Down
                    }

                }
            }
        }
	}
}
