using DTC.Models.DCS;
using System.Text;

namespace DTC.Models.F16.Upload
{
	class MiscBuilder : BaseBuilder
	{
		private F16Configuration _cfg;

		public MiscBuilder(F16Configuration cfg, F16Commands f16, StringBuilder sb) : base(f16, sb)
		{
			_cfg = cfg;
		}

		public override void Build()
		{
			var ufc = _aircraft.GetDevice("UFC");
			AppendCommand(ufc.GetCommand("RTN"));
			AppendCommand(ufc.GetCommand("RTN"));

			BuildBingo(ufc);
			BuildCARA(ufc);
			BuildTGP(ufc);
			BuildBullseye(ufc);
			BuildTACANILS(ufc);
		}

		private void BuildBingo(DCS.Device ufc)
		{
			//Bingo
			AppendCommand(ufc.GetCommand("LIST"));
			AppendCommand(ufc.GetCommand("2"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.Bingo.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));

			AppendCommand(ufc.GetCommand("RTN"));
		}

		private void BuildCARA(DCS.Device ufc)
		{
			//CARA
			AppendCommand(ufc.GetCommand("2"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.CARAALOW.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("DOWN"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.MSLFloor.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("DOWN"));

			AppendCommand(ufc.GetCommand("RTN"));
		}

		private void BuildTGP(DCS.Device ufc)
		{
			// TGP
			AppendCommand(ufc.GetCommand("LIST"));
			AppendCommand(ufc.GetCommand("0"));
			AppendCommand(ufc.GetCommand("5"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.TGPCode.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("DOWN"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.LSTCode.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));
			AppendCommand(ufc.GetCommand("DOWN"));

			AppendCommand(ufc.GetCommand("RTN"));
		}

		private void BuildBullseye(DCS.Device ufc)
		{
			// Bullseye
			AppendCommand(ufc.GetCommand("LIST"));
			AppendCommand(ufc.GetCommand("0"));
			AppendCommand(ufc.GetCommand("8"));
			AppendCommand(Wait());

			if (_cfg.Misc.EnableBullseye)
			{
				AppendCommand(StartCondition("BULLS_NOT_SELECTED"));
				AppendCommand(ufc.GetCommand("0"));
				AppendCommand(EndCondition("BULLS_NOT_SELECTED"));

				AppendCommand(ufc.GetCommand("DOWN"));
				AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(_cfg.Misc.BullseyeWP.ToString())));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(ufc.GetCommand("DOWN"));
			}
			else
			{
				AppendCommand(StartCondition("BULLS_SELECTED"));
				AppendCommand(ufc.GetCommand("0"));
				AppendCommand(EndCondition("BULLS_SELECTED"));
			}

			AppendCommand(ufc.GetCommand("RTN"));
		}

		private void BuildTACANILS(DCS.Device ufc)
		{
			//TACAN / ILS
			AppendCommand(ufc.GetCommand("1"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.TACANChannel.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));

			if (_cfg.Misc.TACANBand == F16.Misc.TACANBands.X)
			{
				AppendCommand(StartCondition("TACAN_BAND_Y"));
				AppendCommand(ufc.GetCommand("0"));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(EndCondition("TACAN_BAND_Y"));
			}
			else
			{
				AppendCommand(StartCondition("TACAN_BAND_X"));
				AppendCommand(ufc.GetCommand("0"));
				AppendCommand(ufc.GetCommand("ENTR"));
				AppendCommand(EndCondition("TACAN_BAND_X"));
			}

			AppendCommand(ufc.GetCommand("DOWN"));
			AppendCommand(ufc.GetCommand("DOWN"));

			AppendCommand(BuildDigits(ufc, RemoveSeparators(_cfg.Misc.GetILSFrequency())));
			AppendCommand(ufc.GetCommand("ENTR"));

			AppendCommand(BuildDigits(ufc, _cfg.Misc.ILSCourse.ToString()));
			AppendCommand(ufc.GetCommand("ENTR"));

			AppendCommand(ufc.GetCommand("DOWN"));
			AppendCommand(ufc.GetCommand("RTN"));
		}
	}
}
