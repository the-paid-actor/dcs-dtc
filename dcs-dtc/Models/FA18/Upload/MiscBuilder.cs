using DTC.Models.DCS;
using System.Text;

namespace DTC.Models.FA18.Upload
{
    class MiscBuilder : BaseBuilder
    {
        private FA18Configuration _cfg;

        public MiscBuilder(FA18Configuration cfg, FA18Commands f18, StringBuilder sb) : base(f18, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");
            var ifei = _aircraft.GetDevice("IFEI");

            if (_cfg.Misc.BingoToBeUpdated)
                BuildBingo(ifei);
            if (_cfg.Misc.TACANToBeUpdated)
                BuildTACAN(ufc);
        }

        private void BuildBingo(DCS.Device ifei)
        {
            //Bingo
            AppendCommand(StartCondition("BINGO_ZERO"));
            for (var i = 0; i < _cfg.Misc.Bingo; i += 100)
            {
                AppendCommand(ifei.GetCommand("UP"));
                AppendCommand(Wait());
            }
            AppendCommand(EndCondition("BINGO_ZERO"));
        }

        private void BuildTACAN(DCS.Device ufc)
        {
            //TACAN
            AppendCommand(ufc.GetCommand("TCN"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.TACANChannel.ToString()));
            AppendCommand(ufc.GetCommand("ENT"));

            if (_cfg.Misc.TACANBand == FA18.Misc.TACANBands.X)
            {
                AppendCommand(ufc.GetCommand("Opt4"));
            }
            else
            {
                AppendCommand(ufc.GetCommand("Opt5"));
            }

            AppendCommand(ufc.GetCommand("OnOff"));
        }
    }
}
