using DTC.Models.DCS;
using System.Text;

namespace DTC.Models.F15E.Upload
{
    class MiscBuilder : BaseBuilder
    {
        private F15EConfiguration _cfg;

        public MiscBuilder(F15EConfiguration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            if (_cfg.Misc.BingoToBeUpdated)
                BuildBingo();
            if (_cfg.Misc.CARAALOWToBeUpdated)
                BuildCARA();
            if (_cfg.Misc.TACANToBeUpdated)
                BuildTACAN();
            if (_cfg.Misc.ILSToBeUpdated)
                BuildILS();
        }

        private void BuildBingo()
        {
            var d = _aircraft.GetDevice("FLTINST");

            for (int i = 0; i < 140; i++)
            {
                AppendCommand(d.GetCommand("BingoDecrease"));
            }

            for (int i = 0; i < _cfg.Misc.Bingo / 100; i++)
            {
                AppendCommand(d.GetCommand("BingoIncrease"));
            }
        }

        private void BuildCARA()
        {
            var ufc = _aircraft.GetDevice("UFC_PILOT");
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("MENU"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.CARAALOW.ToString()));
            AppendCommand(ufc.GetCommand("PB1"));
        }

        private void BuildTACAN()
        {
            var ufc = _aircraft.GetDevice("UFC_PILOT");
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("MENU"));
            
            AppendCommand(ufc.GetCommand("PB2"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.TACANChannel.ToString()));
            AppendCommand(ufc.GetCommand("PB1"));

            if (_cfg.Misc.TACANBand == Misc.TACANBands.X)
            {
                AppendCommand(StartCondition("IsTACANBand", "Y"));
                AppendCommand(ufc.GetCommand("PB1"));
                AppendCommand(EndCondition("IsTACANBand"));
            }
            else
            {
                AppendCommand(StartCondition("IsTACANBand", "X"));
                AppendCommand(ufc.GetCommand("PB1"));
                AppendCommand(EndCondition("IsTACANBand"));
            }

            AppendCommand(ufc.GetCommand("PB10"));
            AppendCommand(ufc.GetCommand("MENU"));
        }

        private void BuildILS()
        {
            var ufc = _aircraft.GetDevice("UFC_PILOT");
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("CLR"));
            AppendCommand(ufc.GetCommand("MENU"));
            AppendCommand(ufc.GetCommand("MENU"));

            AppendCommand(ufc.GetCommand("PB3"));

            AppendCommand(BuildDigits(ufc, RemoveSeparators(_cfg.Misc.GetILSFrequency())));
            AppendCommand(ufc.GetCommand("PB3"));

            AppendCommand(ufc.GetCommand("MENU"));
        }
    }
}
