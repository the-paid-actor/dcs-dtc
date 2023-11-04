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

            string[] Bars = { "1B", "2B", "4B", "6B" };
            string[] Range = { "5", "10", "20", "40", "80", "160" };
            string[] Azimuth = { "20", "40", "60", "80", "140" };
            string[] PRF = { "INTL", "MED", "HI" };
            string[] AIM7PRF = { "INTL", "PDI", "MED", "HI" };
            string[] Timeout = { "2", "4", "8", "16", "32" };

            if (_cfg.AAWeapons.AzElToBeUpdated)
                BuildAzEl(sms, lmfd, rmfd);
            if (_cfg.AAWeapons.AIM9ToBeUpdated)
                BuildAIM9(sms, rmfd, hotas, Bars, Range, Azimuth, PRF, Timeout);
            if (_cfg.AAWeapons.AIM7ToBeUpdated)
                BuildAIM7(sms, rmfd, hotas, Bars, Range, Azimuth, AIM7PRF, Timeout);
            if (_cfg.AAWeapons.AIM120ToBeUpdated)
                BuildAIM120(sms, rmfd, hotas, Bars, Range, Azimuth, PRF, Timeout);
        }

        public void SetRadarParams(string condition, string[] table, string setting, string osb)
        {
            var rmfd = _aircraft.GetDevice("RMFD");
            string osbKey = "OSB-" + osb;
            int TableTotal = table.Count();
            int SettingIndex = System.Array.FindIndex(table, element => element == setting);
            for (int i = 0; i < TableTotal; i++)
            {
                
                AppendCommand(StartCondition(condition, setting));
                AppendCommand(rmfd.GetCommand(osbKey));
                AppendCommand(Wait());
                AppendCommand(EndCondition(condition));
                
            }
        }

        public void BuildAzEl(Device sms, Device lmfd, Device rmfd)
        {
            AppendCommand(sms.GetCommand("AG-ModeDown"));
            AppendCommand(sms.GetCommand("AG-ModeUp"));

            AppendCommand(sms.GetCommand("AA-ModeDown"));
            AppendCommand(sms.GetCommand("AA-ModeUp"));
            
            AppendCommand(StartCondition("LmfdNotTac"));
            AppendCommand(lmfd.GetCommand("OSB-18")); // Menu
            AppendCommand(EndCondition("LmfdNotTac"));
            AppendCommand(WaitLong());
            
            AppendCommand(lmfd.GetCommand("OSB-01")); //AZ/EL
            AppendCommand(Wait());

            AppendCommand(StartCondition("NotAutoIFF"));
            AppendCommand(lmfd.GetCommand("OSB-01")); //Auto IFF
            AppendCommand(EndCondition("NotAutoIFF"));
            AppendCommand(Wait());

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

        public void BuildAIM9(Device sms, Device rmfd, Device hotas, string[] Bars, string[] Range, string[] Azimuth, string[] PRF, string[] Timeout)
        {
            AppendCommand(hotas.GetCommand("Select-AIM9"));
            AppendCommand(WaitLong());

            AppendCommand(StartCondition("RmfdNotTac"));
            AppendCommand(rmfd.GetCommand("OSB-18")); //MENU
            AppendCommand(EndCondition("RmfdNotTac"));

            AppendCommand(rmfd.GetCommand("OSB-04")); //ATTK RDR

            //Set Bars
            SetRadarParams("RadarBars", Bars, _cfg.AAWeapons.AIM9Bars, "06");

            //Set Range
            SetRadarParams("RadarRange", Range, _cfg.AAWeapons.AIM9Range, "11");

            //Set Azimuth
            SetRadarParams("RadarAz", Azimuth, _cfg.AAWeapons.AIM9Az, "19");

            //Set PRF
            SetRadarParams("RadarPRF", PRF, _cfg.AAWeapons.AIM9PRF, "01");

            //Set Timeout
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            SetRadarParams("RadarTimeout", Timeout, _cfg.AAWeapons.AIM9Timeout, "10");

            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            //Save settings
            AppendCommand(rmfd.GetCommand("OSB-13")); //SET
            AppendCommand(WaitLong());

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

        public void BuildAIM7(Device sms, Device rmfd, Device hotas, string[] Bars, string[] Range, string[] Azimuth, string[] AIM7PRF, string[] Timeout)
        {
            AppendCommand(hotas.GetCommand("Select-AIM7"));
            AppendCommand(WaitLong());

            AppendCommand(StartCondition("RmfdNotTac"));
            AppendCommand(rmfd.GetCommand("OSB-18")); //MENU
            AppendCommand(EndCondition("RmfdNotTac"));

            AppendCommand(rmfd.GetCommand("OSB-04")); //ATTK RDR

            //Set Bars
            SetRadarParams("RadarBars", Bars, _cfg.AAWeapons.AIM7Bars, "06");

            //Set Range
            SetRadarParams("RadarRange", Range, _cfg.AAWeapons.AIM7Range, "11");

            //Set Azimuth
            SetRadarParams("RadarAz", Azimuth, _cfg.AAWeapons.AIM7Az, "19");

            //Set PRF
            SetRadarParams("RadarPRF", AIM7PRF, _cfg.AAWeapons.AIM7PRF, "01");

            //Set Timeout
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            SetRadarParams("RadarTimeout", Timeout, _cfg.AAWeapons.AIM7Timeout, "10");

            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            //Save settings
            AppendCommand(rmfd.GetCommand("OSB-13")); //SET
            AppendCommand(WaitLong());

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

        public void BuildAIM120(Device sms, Device rmfd, Device hotas, string[] Bars, string[] Range, string[] Azimuth, string[] PRF, string[] Timeout)
        {
            AppendCommand(hotas.GetCommand("Select-AIM120"));
            AppendCommand(WaitLong());

            AppendCommand(StartCondition("RmfdNotTac"));
            AppendCommand(rmfd.GetCommand("OSB-18")); //MENU
            AppendCommand(EndCondition("RmfdNotTac"));

            AppendCommand(rmfd.GetCommand("OSB-04")); //ATTK RDR

            //Set Bars
            SetRadarParams("RadarBars", Bars, _cfg.AAWeapons.AIM120Bars, "06");

            //Set Range
            SetRadarParams("RadarRange", Range, _cfg.AAWeapons.AIM120Range, "11");

            //Set Azimuth
            SetRadarParams("RadarAz", Azimuth, _cfg.AAWeapons.AIM120Az, "19");

            //Set PRF
            SetRadarParams("RadarPRF", PRF, _cfg.AAWeapons.AIM120PRF, "01");

            //Set Timeout
            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            SetRadarParams("RadarTimeout", Timeout, _cfg.AAWeapons.AIM120Timeout, "10");

            AppendCommand(rmfd.GetCommand("OSB-16")); //DATA
            AppendCommand(Wait());

            //Save settings
            AppendCommand(rmfd.GetCommand("OSB-13")); //SET
            AppendCommand(WaitLong());

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
