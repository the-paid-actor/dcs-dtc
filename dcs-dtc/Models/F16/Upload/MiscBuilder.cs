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
            if (_cfg.Misc.BingoToBeUpdated)
                BuildBingo(ufc);
            if (_cfg.Misc.CARAALOWToBeUpdated)
                BuildCARA(ufc);
            if (_cfg.Misc.MSLFloorToBeUpdated)
                BuildMSLFloor(ufc);
            if (_cfg.Misc.LaserSettingsToBeUpdated)
                BuildLaserSettings(ufc);
            if (_cfg.Misc.BullseyeToBeUpdated)
                BuildBullseye(ufc);
            if (_cfg.Misc.TACANToBeUpdated)
                BuildTACAN(ufc);
            if (_cfg.Misc.ILSToBeUpdated)
                BuildILS(ufc);
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

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildMSLFloor(DCS.Device ufc)
        {
            //MSLFloor
            AppendCommand(ufc.GetCommand("2"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.MSLFloor.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildLaserSettings(DCS.Device ufc)
        {
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(ufc.GetCommand("5"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.TGPCode.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.LSTCode.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.LaserStartTime.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildBullseye(DCS.Device ufc)
        {
            // Bullseye
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(ufc.GetCommand("8"));
            AppendCommand(Wait());

            AppendCommand(StartCondition("BullseyeNotSelected"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(EndCondition("BullseyeNotSelected"));

            AppendCommand(ufc.GetCommand("DOWN"));
            AppendCommand(BuildDigits(ufc, DeleteLeadingZeros(_cfg.Misc.BullseyeWP.ToString())));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildTACAN(DCS.Device ufc)
        {
            //TACAN
            AppendCommand(ufc.GetCommand("1"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.TACANChannel.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));

            if (_cfg.Misc.TACANBand == F16.Misc.TACANBands.X)
            {
                AppendCommand(StartCondition("TACANBandY"));
                AppendCommand(ufc.GetCommand("0"));
                AppendCommand(ufc.GetCommand("ENTR"));
                AppendCommand(EndCondition("TACANBandY"));
            }
            else
            {
                AppendCommand(StartCondition("TACANBandX"));
                AppendCommand(ufc.GetCommand("0"));
                AppendCommand(ufc.GetCommand("ENTR"));
                AppendCommand(EndCondition("TACANBandX"));
            }

            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildILS(DCS.Device ufc)
        {
            // ILS
            AppendCommand(ufc.GetCommand("1"));
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
