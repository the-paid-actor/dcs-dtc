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
            if (_cfg.Misc.TGPCodeToBeUpdated)
                BuildTGP(ufc);
            if (_cfg.Misc.LSTCodeToBeUpdated)
                BuildLST(ufc);
            if (_cfg.Misc.TACANToBeUpdated)
                BuildTACAN(ufc);
        }

        private void BuildBingo(DCS.Device ifei)
        {
            //Bingo
            // AppendCommand(ifei.GetCommand("DOWN"));
            AppendCommand(StartCondition("BINGO_ZERO"));
            for (var i = 0; i < _cfg.Misc.Bingo; i += 100)
            {
                AppendCommand(ifei.GetCommand("UP"));
                AppendCommand(Wait());
            }
            AppendCommand(EndCondition("BINGO_ZERO"));
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

        private void BuildTGP(DCS.Device ufc)
        {
            // TGP
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(ufc.GetCommand("5"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.TGPCode.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("RTN"));
        }

        private void BuildLST(DCS.Device ufc)
        {
            // LST
            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("0"));
            AppendCommand(ufc.GetCommand("5"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(BuildDigits(ufc, _cfg.Misc.LSTCode.ToString()));
            AppendCommand(ufc.GetCommand("ENTR"));
            AppendCommand(ufc.GetCommand("DOWN"));

            AppendCommand(ufc.GetCommand("RTN"));
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
