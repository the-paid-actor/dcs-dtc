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

        private void selectWp0(Device rmfd, int i)
        {
            if (i < 140) // It might not notice on the first pass, so we go around once more
            {
                AppendCommand(StartCondition("NotAtWp0"));
                AppendCommand(rmfd.GetCommand("OSB-13"));
                AppendCommand(Wait());
                AppendCommand(EndCondition("NotAtWp0"));
                selectWp0(rmfd, i + 1);
            }
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");
            var radAlt = _aircraft.GetDevice("RadAlt");
            var rmfd = _aircraft.GetDevice("RMFD");
            var ifei = _aircraft.GetDevice("IFEI");

            if (_cfg.Misc.BingoToBeUpdated)
                BuildBingo(ifei);

            if (_cfg.Misc.ILSToBeUpdated)
                BuildILS(ufc);
            if (_cfg.Misc.TACANToBeUpdated)
                BuildTACAN(ufc);

            if (_cfg.Misc.BaroToBeUpdated ||
                _cfg.Misc.HideMapOnHSI ||
                _cfg.Misc.BullseyeToBeUpdated ||
                _cfg.Misc.BlimTac)
            {
                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(rmfd.GetCommand("OSB-02")); // HSI

                if (_cfg.Misc.HideMapOnHSI)
                    BuildHideMapOnHSI(rmfd);

                AppendCommand(rmfd.GetCommand("OSB-10")); // DATA
                AppendCommand(rmfd.GetCommand("OSB-06")); // A/C

                if (_cfg.Misc.BaroToBeUpdated)
                    BuildBaroWarn(ufc, rmfd);
                if (_cfg.Misc.BlimTac)
                    BuildTacBlim(rmfd);

                AppendCommand(rmfd.GetCommand("OSB-07")); // WYPT

                if (_cfg.Misc.BullseyeToBeUpdated)
                    BuildBullseye(rmfd);

                AppendCommand(rmfd.GetCommand("OSB-18")); // Menu
                AppendCommand(rmfd.GetCommand("OSB-18")); // Menu
                AppendCommand(rmfd.GetCommand("OSB-15")); // FCS
            }

            if (_cfg.Misc.RadarToBeUpdated)
                BuildRadarWarn(radAlt);
        }

        private void BuildHideMapOnHSI(DCS.Device rmfd)
        {
            AppendCommand(rmfd.GetCommand("OSB-03")); // MODE
            AppendCommand(StartCondition("MapBoxed"));
            AppendCommand(rmfd.GetCommand("OSB-03")); // MODE
            AppendCommand(EndCondition("MapBoxed"));
            AppendCommand(StartCondition("MapUnboxed"));
            AppendCommand(rmfd.GetCommand("OSB-01")); // SLEW
            AppendCommand(EndCondition("MapUnboxed"));
        }

        private void BuildBaroWarn(DCS.Device ufc, DCS.Device mfd)
        {
            AppendCommand(mfd.GetCommand("OSB-20")); // Baro
            AppendCommand(BuildDigits(ufc, _cfg.Misc.BaroWarn.ToString())); // Alt
            AppendCommand(ufc.GetCommand("ENT")); // Enter
        }

        private void BuildTacBlim(DCS.Device mfd)
        {
            AppendCommand(StartCondition("IsBankLimitOnNav"));
            AppendCommand(mfd.GetCommand("OSB-04")); // BLIM
            AppendCommand(EndCondition("IsBankLimitOnNav"));
        }

        private void BuildBullseye(DCS.Device rmfd)
        {
            selectWp0(rmfd, 0);
            for (var i = 0; i < _cfg.Misc.BullseyeWP; i++)
            {
                AppendCommand(rmfd.GetCommand("OSB-12"));
            }

            AppendCommand(rmfd.GetCommand("OSB-02"));
            AppendCommand(Wait());
            AppendCommand(StartCondition("NotBullseye"));
            AppendCommand(rmfd.GetCommand("OSB-02"));
            AppendCommand(EndCondition("NotBullseye"));

            for (var i = 0; i < _cfg.Misc.BullseyeWP; i++)
            {
                AppendCommand(rmfd.GetCommand("OSB-13")); // Prev Waypoint
            }
        }

        private void BuildBingo(DCS.Device ifei)
        {
            //Bingo
            AppendCommand(StartCondition("BingoIsZero"));
            for (var i = 0; i < _cfg.Misc.Bingo; i += 100)
            {
                AppendCommand(ifei.GetCommand("UP"));
                AppendCommand(Wait());
            }
            AppendCommand(EndCondition("BingoIsZero"));
        }

        private void BuildRadarWarn(DCS.Device radAlt)
        {
            if(_cfg.Misc.RadarWarn <= 5000)
            {
                AppendCommand(radAlt.GetCommand("Decrease"));
                for (var i = 0; i < 7; i++)
                {
                    AppendCommand(radAlt.GetCommand("Increase"));
                } // Reset to 0 exact
                
                // one line is ~5 steps
                // one line = 20ft while below 400
                if (_cfg.Misc.RadarWarn > 400)
                {
                    for(var i = 0; i < 5 * 20; i++)
                    {
                        AppendCommand(radAlt.GetCommand("Increase"));
                    }
                } else
                {
                    var step = (20 / 5);
                    for(var i = 0; i < (_cfg.Misc.RadarWarn / step); i++)
                    {
                        AppendCommand(radAlt.GetCommand("Increase"));
                    }
                }
                // one line = 50ft while 400 < x < 1000 
                if (_cfg.Misc.RadarWarn > 1000)
                {
                    for(var i = 0; i < 5 * 12; i++)
                    {
                        AppendCommand(radAlt.GetCommand("Increase"));
                    }
                } else
                {
                    var step = (50 / 5);
                    for(var i = 0; i < ((_cfg.Misc.RadarWarn - 400) / step); i++)
                    {
                        AppendCommand(radAlt.GetCommand("Increase"));
                    }
                }
                // one line = 500ft while 1000 < x < 5000 
                if (_cfg.Misc.RadarWarn > 1000)
                {
                    var step = (500 / 5);
                    for (var i = 0; i < ((_cfg.Misc.RadarWarn - 1000) / step); i++)
                    {
                        AppendCommand(radAlt.GetCommand("Increase"));
                    }
                }
            }
        }

        private void BuildTACAN(DCS.Device ufc)
        {
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
        }

        private void BuildILS(DCS.Device ufc)
        {
            if (_cfg.Misc.ILSChannel == 0) return;

            AppendCommand(ufc.GetCommand("ILS"));
            AppendCommand(BuildDigits(ufc, _cfg.Misc.ILSChannel.ToString()));
            AppendCommand(ufc.GetCommand("ENT"));
        }
    }
}
