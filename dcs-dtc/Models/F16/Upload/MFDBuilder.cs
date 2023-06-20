using DTC.Models.DCS;
using DTC.Models.F16.MFD;
using System.Linq;
using System.Text;

namespace DTC.Models.F16.Upload
{
    class MFDBuilder : BaseBuilder
    {
        private F16Configuration _cfg;

        public MFDBuilder(F16Configuration cfg, F16Commands f16, StringBuilder sb) : base(f16, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            var ufc = _aircraft.GetDevice("UFC");

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));

            AppendCommand(Wait());

            AppendCommand(StartCondition("NotInAAMode"));

            AppendCommand(ufc.GetCommand("SEQ"));
            AppendCommand(StartCondition("NotInAGMode"));
            
            if (_cfg.MFD.Configurations.Any(c => c.ToBeUpdated))
            {
                BuildMFD();
            }

            AppendCommand(EndCondition("NotInAGMode"));

            AppendCommand(ufc.GetCommand("RTN"));
            AppendCommand(ufc.GetCommand("RTN"));

            AppendCommand(ufc.GetCommand("LIST"));
            AppendCommand(ufc.GetCommand("8"));
            AppendCommand(ufc.GetCommand("SEQ"));

            AppendCommand(EndCondition("NotInAAMode"));

            AppendCommand(ufc.GetCommand("RTN"));
        }             

        private void BuildMFD()
        {
            var ufc = _aircraft.GetDevice("UFC");
            var hotas = _aircraft.GetDevice("HOTAS");
            var leftMFD = _aircraft.GetDevice("LMFD");
            var rightMFD = _aircraft.GetDevice("RMFD");

            for (var i = 0; i < _cfg.MFD.Configurations.Length; i++)
            {
                var config = _cfg.MFD.Configurations[i];

                if (!config.ToBeUpdated) 
                    continue;
                if (config.Mode == Mode.AA)
                {
                    AppendCommand(ufc.GetCommand("AA"));
                }
                else if (config.Mode == Mode.AG)
                {
                    AppendCommand(ufc.GetCommand("AG"));
                }
                else if (config.Mode == Mode.DGFT)
                {
                    AppendCommand(hotas.GetCommand("DGFT"));
                }
                else if (config.Mode == Mode.MSL)
                {
                    AppendCommand(hotas.GetCommand("MSL"));
                }

                BuildMFD(true, leftMFD, config.LeftMFD);
                BuildMFD(false, rightMFD, config.RightMFD);

                if (config.Mode == Mode.AA)
                {
                    AppendCommand(ufc.GetCommand("AA"));
                }
                else if (config.Mode == Mode.AG)
                {
                    AppendCommand(ufc.GetCommand("AG"));
                }
                else if ((config.Mode == Mode.DGFT) || (config.Mode == Mode.MSL))
                {
                    AppendCommand(hotas.GetCommand("CENTER"));
                }
            }
        }

        private void BuildMFD(bool isLeftMFD, Device d, MFDConfiguration mfdConfig)
        {
            AppendCommand(d.GetCommand("OSB-14-PG1"));
            AppendCommand(d.GetCommand("OSB-13-PG2"));

            AppendCommand(d.GetCommand("OSB-14-PG1"));
            AppendCommand(d.GetCommand("OSB-14-PG1"));
            BuildPage(isLeftMFD, d, mfdConfig.Page1);
            AppendCommand(d.GetCommand("OSB-13-PG2"));
            AppendCommand(d.GetCommand("OSB-13-PG2"));
            BuildPage(isLeftMFD, d, mfdConfig.Page2);
            AppendCommand(d.GetCommand("OSB-12-PG3"));
            AppendCommand(d.GetCommand("OSB-12-PG3"));
            BuildPage(isLeftMFD, d, mfdConfig.Page3);

            if (mfdConfig.SelectedPage == 1)
            {
                AppendCommand(d.GetCommand("OSB-14-PG1"));
            }
            else if (mfdConfig.SelectedPage == 2)
            {
                AppendCommand(d.GetCommand("OSB-13-PG2"));
            }
        }

        private void BuildPage(bool isLeftMFD, Device d, Page page)
        {
            if (page == Page.BLANK)
            {
                AppendCommand(d.GetCommand("OSB-01-BLANK"));
            }
            else if (page == Page.DTE)
            {
                AppendCommand(d.GetCommand("OSB-08-DTE"));
            }
            else if (page == Page.FCR)
            {
                AppendCommand(d.GetCommand("OSB-20-FCR"));
            }
            else if (page == Page.FLCS)
            {
                AppendCommand(d.GetCommand("OSB-10-FLCS"));
            }
            else if (page == Page.FLIR)
            {
                AppendCommand(d.GetCommand("OSB-16-FLIR"));
            }
            else if (page == Page.HAD)
            {
                AppendCommand(d.GetCommand("OSB-02-HAD"));
                AppendCommand(StartCondition("HTSOnMFD", isLeftMFD ? "left" : "right"));
                BuildHTSOnMFDIfOn(isLeftMFD, d);
                AppendCommand(EndCondition("HTSOnMFD"));
            }
            else if (page == Page.HSD)
            {
                AppendCommand(d.GetCommand("OSB-07-HSD"));
            }
            else if (page == Page.RCCE)
            {
                AppendCommand(d.GetCommand("OSB-04-RCCE"));
            }
            else if (page == Page.SMS)
            {
                AppendCommand(d.GetCommand("OSB-06-SMS"));
                AppendCommand(d.GetCommand("OSB-04-RCCE"));
            }
            else if (page == Page.TEST)
            {
                AppendCommand(d.GetCommand("OSB-09-TEST"));
            }
            else if (page == Page.TFR)
            {
                AppendCommand(d.GetCommand("OSB-17-TFR"));
            }
            else if (page == Page.TGP)
            {
                AppendCommand(d.GetCommand("OSB-19-TGP"));
            }
            else if (page == Page.WPN)
            {
                AppendCommand(d.GetCommand("OSB-18-WPN"));
            }
        }

        private void BuildHTSOnMFDIfOn(bool isLeftMFD, Device d)
        {
            AppendCommand(d.GetCommand("OSB-04-RCCE"));

            AppendCommand(StartCondition("HTSAllNotSelected", isLeftMFD ? "left" : "right"));
            AppendCommand(d.GetCommand("OSB-05"));
            AppendCommand(EndCondition("HTSAllNotSelected"));

            AppendCommand(d.GetCommand("OSB-05"));

            if (_cfg.HTS.EnabledClasses[0])
                AppendCommand(d.GetCommand("OSB-20-FCR"));
            if (_cfg.HTS.EnabledClasses[1])
                AppendCommand(d.GetCommand("OSB-19-TGP"));
            if (_cfg.HTS.EnabledClasses[2])
                AppendCommand(d.GetCommand("OSB-18-WPN"));
            if (_cfg.HTS.EnabledClasses[3])
                AppendCommand(d.GetCommand("OSB-17-TFR"));
            if (_cfg.HTS.EnabledClasses[4])
                AppendCommand(d.GetCommand("OSB-16-FLIR"));
            if (_cfg.HTS.EnabledClasses[5])
                AppendCommand(d.GetCommand("OSB-06-SMS"));
            if (_cfg.HTS.EnabledClasses[6])
                AppendCommand(d.GetCommand("OSB-07-HSD"));
            if (_cfg.HTS.EnabledClasses[7])
                AppendCommand(d.GetCommand("OSB-08-DTE"));
            if (_cfg.HTS.EnabledClasses[8])
                AppendCommand(d.GetCommand("OSB-09-TEST"));
            if (_cfg.HTS.EnabledClasses[9])
                AppendCommand(d.GetCommand("OSB-10-FLCS"));
            if (_cfg.HTS.EnabledClasses[10])
                AppendCommand(d.GetCommand("OSB-01-BLANK"));
            if (!_cfg.HTS.ManualTableEnabled)
                AppendCommand(d.GetCommand("OSB-02-HAD"));

            AppendCommand(d.GetCommand("OSB-04-RCCE"));
        }
    }
}
