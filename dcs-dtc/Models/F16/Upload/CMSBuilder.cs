using DTC.Models.DCS;
using System.Text;

namespace DTC.Models.F16.Upload
{
	class CMSBuilder : BaseBuilder
	{
		private F16Configuration _cfg;

		public CMSBuilder(F16Configuration cfg, F16Commands f16, StringBuilder sb) : base(f16, sb)
		{
			_cfg = cfg;
		}

		public override void Build()
		{
			var ufc = _aircraft.GetDevice("UFC");
			AppendCommand(ufc.GetCommand("RTN"));
			AppendCommand(ufc.GetCommand("RTN"));

			AppendCommand(ufc.GetCommand("LIST"));
			AppendCommand(ufc.GetCommand("7"));

			AppendCommand(BuildDigits(ufc, _cfg.CMS.ChaffBingo.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("DOWN"));

			AppendCommand(BuildDigits(ufc, _cfg.CMS.FlareBingo.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("UP"));

			AppendCommand(ufc.GetCommand("SEQ"));

			for (var i = 0; i < _cfg.CMS.Programs.Length; i++)
			{
				var program = _cfg.CMS.Programs[i];

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffBurstQty().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffBurstInterval().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffSalvoQty().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetChaffSalvoInterval().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(ufc.GetCommand("INC"));
			}

			AppendCommand(ufc.GetCommand("SEQ"));

			for (var i = 0; i < _cfg.CMS.Programs.Length; i++)
			{
				var program = _cfg.CMS.Programs[i];

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareBurstQty().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareBurstInterval().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareSalvoQty().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(RemoveSeparators(program.GetFlareSalvoInterval().ToString()))));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));

				AppendCommand(ufc.GetCommand("INC"));
			}

			AppendCommand(ufc.GetCommand("RTN"));
		}
	}
}
