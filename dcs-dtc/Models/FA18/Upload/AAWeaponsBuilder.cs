using DTC.Models.DCS;
using System.Text;
using System.Linq;

namespace DTC.Models.FA18.Upload
{
    class AAWeaponsBuilder : BaseBuilder
    {
        private FA18Configuration _cfg;

        public AAWeaponsBuilder(FA18Configuration cfg, FA18Commands f18, StringBuilder sb) : base(f18, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var sms = _aircraft.GetDevice("SMS");
            var hotas = _aircraft.GetDevice("HOTAS");
            var rmfd = _aircraft.GetDevice("RMFD");
            var lmfd = _aircraft.GetDevice("LMFD");

            if (_cfg.AAWeapons.AzElToBeUpdated)
                BuildAzEl(sms, lmfd, rmfd);
            if (_cfg.AAWeapons.AIM9ToBeUpdated)
                BuildAIM9(sms, lmfd, rmfd, hotas);
            if (_cfg.AAWeapons.AIM7ToBeUpdated)
                BuildAIM7(sms, lmfd, rmfd, hotas);
            if (_cfg.AAWeapons.AIM120ToBeUpdated)
                BuildAIM120(sms, lmfd, rmfd, hotas);
        }

        public void SetRadarParams(string[] table, string setting, string prefix, string osb)
        {
            var rmfd = _aircraft.GetDevice("RMFD");
            string osbKey = "OSB-" + osb;
            int TableTotal = table.Count();
            int SettingIndex = System.Array.FindIndex(table, element => element == setting);
            foreach (string s in table)
            {
                if (s != setting)
                {
                    string condition = prefix + s;
                    AppendCommand(StartCondition(condition));

                    int CurrentIndex = System.Array.FindIndex(table, element => element == s);
                    if (SettingIndex > CurrentIndex)
                    {
                        int repeat = SettingIndex - CurrentIndex;
                        for (int i = 0; i < repeat; i++)
                        {
                            AppendCommand(rmfd.GetCommand(osbKey));
                            AppendCommand(WaitShort());
                        }
                    }
                    else
                    {
                        int repeat = (TableTotal - CurrentIndex) + SettingIndex;
                        for (int i = 0; i < repeat; i++)
                        {
                            AppendCommand(rmfd.GetCommand(osbKey));
                            AppendCommand(WaitShort());
                        }
                    }
                    AppendCommand(EndCondition(condition));
                }
            }
        }

        public void BuildAzEl(Device sms, Device lmfd, Device rmfd)
        {
            AppendCommand(StartCondition("18_NOT_IN_AA"));
            AppendCommand(sms.GetCommand("AA-ModeDown"));
            AppendCommand(sms.GetCommand("AA-ModeUp"));
            AppendCommand(EndCondition("18_NOT_IN_AA"));

            AppendCommand(lmfd.GetCommand("OSB-18"));
            AppendCommand(lmfd.GetCommand("OSB-01"));

            AppendCommand(WaitLong());

            AppendCommand(StartCondition("AUTOIFF_OFF"));
            AppendCommand(lmfd.GetCommand("OSB-01"));
            AppendCommand(EndCondition("AUTOIFF_OFF"));

            if (!_cfg.AAWeapons.AIM9ToBeUpdated && !_cfg.AAWeapons.AIM7ToBeUpdated && !_cfg.AAWeapons.AIM120ToBeUpdated)
            {
                AppendCommand(sms.GetCommand("AA-ModeDown"));
                AppendCommand(sms.GetCommand("AA-ModeUp"));
                AppendCommand(Wait());

                AppendCommand(lmfd.GetCommand("OSB-03")); // HUD
                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(rmfd.GetCommand("OSB-15")); // FCS
            }else
            {
                AppendCommand(lmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(lmfd.GetCommand("OSB-03")); // HUD
            }
        }

        public void BuildAIM9(Device sms, Device lmfd, Device rmfd, Device hotas)
        {
            AppendCommand(StartCondition("18_NOT_IN_AA"));
            AppendCommand(sms.GetCommand("AA-ModeDown"));
            AppendCommand(sms.GetCommand("AA-ModeUp"));
            AppendCommand(EndCondition("18_NOT_IN_AA"));

            AppendCommand(hotas.GetCommand("Select-AIM9"));
            AppendCommand(WaitLong());

            //Create AIM9 arrays
            string[] Bars = { "1B", "2B", "4B", "6B" };
            string[] Range = { "5", "10", "20", "40", "80", "160" };
            string[] Azimuth = { "20", "40", "60", "80", "140" };
            string[] PRF = { "INTL", "MED", "HI" };
            string[] Timeout = { "2", "4", "8", "16", "32" };

            //Set Bars
            SetRadarParams(Bars, _cfg.AAWeapons.AIM9Bars, "BARS_", "06");

            //Set Range
            SetRadarParams(Range, _cfg.AAWeapons.AIM9Range, "RANGE_", "11");

            //Set Azimuth
            SetRadarParams(Azimuth, _cfg.AAWeapons.AIM9Az, "AZ_", "19");

            //Set PRF
            SetRadarParams(PRF, _cfg.AAWeapons.AIM9PRF, "PRF_", "01");

            //Set Timeout
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());
            SetRadarParams(Timeout, _cfg.AAWeapons.AIM9Timeout, "Timeout_", "10");
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            //Save settings
            AppendCommand(rmfd.GetCommand("OSB-13")); //SET
            AppendCommand(Wait());

            if (!_cfg.AAWeapons.AIM7ToBeUpdated && !_cfg.AAWeapons.AIM120ToBeUpdated)
            {
                AppendCommand(sms.GetCommand("AA-ModeDown"));
                AppendCommand(sms.GetCommand("AA-ModeUp"));
                AppendCommand(Wait());

                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(rmfd.GetCommand("OSB-15")); // FCS
            }
        }

        public void BuildAIM7(Device sms, Device lmfd, Device rmfd, Device hotas)
        {
            AppendCommand(StartCondition("18_NOT_IN_AA"));
            AppendCommand(sms.GetCommand("AA-ModeDown"));
            AppendCommand(sms.GetCommand("AA-ModeUp"));
            AppendCommand(EndCondition("18_NOT_IN_AA"));

            AppendCommand(hotas.GetCommand("Select-AIM7"));
            AppendCommand(WaitLong());

            //Create AIM7 arrays
            string[] Bars = { "1B", "2B", "4B", "6B" };
            string[] Range = { "5", "10", "20", "40", "80", "160" };
            string[] Azimuth = { "20", "40", "60", "80", "140" };
            string[] PRF = { "INTL", "PDI", "MED", "HI" };
            string[] Timeout = { "2", "4", "8", "16", "32" };

            //Set Bars
            SetRadarParams(Bars, _cfg.AAWeapons.AIM7Bars, "BARS_", "06");

            //Set Range
            SetRadarParams(Range, _cfg.AAWeapons.AIM7Range, "RANGE_", "11");

            //Set Azimuth
            SetRadarParams(Azimuth, _cfg.AAWeapons.AIM7Az, "AZ_", "19");

            //Set PRF
            SetRadarParams(PRF, _cfg.AAWeapons.AIM7PRF, "PRF_", "01");

            //Set Timeout
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());
            SetRadarParams(Timeout, _cfg.AAWeapons.AIM7Timeout, "Timeout_", "10");
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            //Save settings
            AppendCommand(rmfd.GetCommand("OSB-13")); //SET
            AppendCommand(Wait());

            if (!_cfg.AAWeapons.AIM120ToBeUpdated)
            {
                AppendCommand(sms.GetCommand("AA-ModeDown"));
                AppendCommand(sms.GetCommand("AA-ModeUp"));
                AppendCommand(Wait());

                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
                AppendCommand(Wait());
                AppendCommand(rmfd.GetCommand("OSB-15")); // FCS
            }
        }

        public void BuildAIM120(Device sms, Device lmfd, Device rmfd, Device hotas)
        {
            AppendCommand(StartCondition("18_NOT_IN_AA"));
            AppendCommand(sms.GetCommand("AA-ModeDown"));
            AppendCommand(sms.GetCommand("AA-ModeUp"));
            AppendCommand(EndCondition("18_NOT_IN_AA"));

            AppendCommand(hotas.GetCommand("Select-AIM120"));
            AppendCommand(WaitLong());

            //Create AIM120 arrays
            string[] Bars = { "1B", "2B", "4B", "6B" };
            string[] Range = { "5", "10", "20", "40", "80", "160" };
            string[] Azimuth = { "20", "40", "60", "80", "140" };
            string[] PRF = { "INTL", "MED", "HI" };
            string[] Timeout = { "2", "4", "8", "16", "32" };

            //Set Bars
            SetRadarParams(Bars, _cfg.AAWeapons.AIM120Bars, "BARS_", "06");

            //Set Range
            SetRadarParams(Range, _cfg.AAWeapons.AIM120Range, "RANGE_", "11");

            //Set Azimuth
            SetRadarParams(Azimuth, _cfg.AAWeapons.AIM120Az, "AZ_", "19");

            //Set PRF
            SetRadarParams(PRF, _cfg.AAWeapons.AIM120PRF, "PRF_", "01");

            //Set Timeout
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());
            SetRadarParams(Timeout, _cfg.AAWeapons.AIM120Timeout, "Timeout_", "10");
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            //Save settings
            AppendCommand(rmfd.GetCommand("OSB-13")); //SET
            AppendCommand(Wait());

            AppendCommand(sms.GetCommand("AA-ModeDown"));
            AppendCommand(sms.GetCommand("AA-ModeUp"));
            AppendCommand(Wait());

            AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
            AppendCommand(Wait());
            AppendCommand(rmfd.GetCommand("OSB-18")); // MENU
            AppendCommand(Wait());
            AppendCommand(rmfd.GetCommand("OSB-15")); // FCS
        }
    }
}
