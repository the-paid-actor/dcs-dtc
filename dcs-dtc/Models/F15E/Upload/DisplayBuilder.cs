using DTC.Models.DCS;
using DTC.Models.F15E.Displays;
using System.Text;

namespace DTC.Models.F15E.Upload
{
    public class DisplayBuilder : BaseBuilder
    {
        private F15EConfiguration _cfg;

        public DisplayBuilder(F15EConfiguration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            if (_cfg.Displays.UploadMode == DisplayUploadMode.Pilot)
            {
                var frontLeftMPD = _aircraft.GetDevice("FLMPD");
                if (_cfg.Displays.Pilot.LeftMPD.FirstDisplay != Display.None)
                {
                    BuildDisplay(frontLeftMPD, _cfg.Displays.Pilot.LeftMPD);
                }

                var frontRightMPD = _aircraft.GetDevice("FRMPD");
                if (_cfg.Displays.Pilot.RightMPD.FirstDisplay != Display.None)
                {
                    BuildDisplay(frontRightMPD, _cfg.Displays.Pilot.RightMPD);
                }

                var frontMPCD = _aircraft.GetDevice("FMPCD");
                if (_cfg.Displays.Pilot.MPCD.FirstDisplay != Display.None)
                {
                    BuildDisplay(frontMPCD, _cfg.Displays.Pilot.MPCD);
                }
            }
            else if (_cfg.Displays.UploadMode == DisplayUploadMode.WSO)
            {
                AppendCommand(StartCondition("GoToRearCockpit"));
                AppendCommand(EndCondition("GoToRearCockpit"));

                var rearLeftMPCD = _aircraft.GetDevice("RLMPCD");
                if (_cfg.Displays.WSO.LeftMPCD.FirstDisplay != Display.None)
                {
                    BuildDisplay(rearLeftMPCD, _cfg.Displays.WSO.LeftMPCD);
                }

                var rearLeftMPD = _aircraft.GetDevice("RLMPD");
                if (_cfg.Displays.WSO.LeftMPD.FirstDisplay != Display.None)
                {
                    BuildDisplay(rearLeftMPD, _cfg.Displays.WSO.LeftMPD);
                }

                var rearRightMPD = _aircraft.GetDevice("RRMPD");
                if (_cfg.Displays.WSO.RightMPD.FirstDisplay != Display.None)
                {
                    BuildDisplay(rearRightMPD, _cfg.Displays.WSO.RightMPD);
                }

                var rearRightMPCD = _aircraft.GetDevice("RRMPCD");
                if (_cfg.Displays.WSO.RightMPCD.FirstDisplay != Display.None)
                {
                    BuildDisplay(rearRightMPCD, _cfg.Displays.WSO.RightMPCD);
                }
            }
        }

        private void BuildDisplay(Device device, DisplayConfig display)
        {
            AppendCommand(StartCondition("DisplayNotInMainMenu", device.Name));
            AppendCommand(device.GetCommand("PB11"));
            AppendCommand(Wait());
            AppendCommand(EndCondition("DisplayNotInMainMenu"));

            AppendCommand(StartCondition("DisplayNotInMainMenu", device.Name));
            AppendCommand(device.GetCommand("PB11"));
            AppendCommand(Wait());
            AppendCommand(EndCondition("DisplayNotInMainMenu"));

            AppendCommand(StartCondition("IsProgBoxed", device.Name));
            AppendCommand(device.GetCommand("PB06"));
            AppendCommand(Wait());
            AppendCommand(EndCondition("IsProgBoxed"));

            AppendCommand(StartCondition("NoDisplaysProgrammed", device.Name));

            AppendCommand(device.GetCommand("PB06"));

            SelectDisplay(device, display.FirstDisplay);

            if (display.SecondDisplay != Display.None)
            {
                SelectDisplay(device, display.SecondDisplay);
            }

            if (display.ThirdDisplay != Display.None)
            {
                SelectDisplay(device, display.ThirdDisplay);
            }

            if (display.FirstDisplayMode != DisplayMode.None)
            {
                NavigateToDisplayMode(device, display.FirstDisplayMode);
                SelectDisplay(device, display.FirstDisplay);
                ExitDisplayMode(device, display.FirstDisplayMode);
            }

            if (display.SecondDisplayMode != DisplayMode.None)
            {
                NavigateToDisplayMode(device, display.SecondDisplayMode);
                SelectDisplay(device, display.SecondDisplay);
                ExitDisplayMode(device, display.SecondDisplayMode);
            }

            if (display.ThirdDisplayMode != DisplayMode.None)
            {
                NavigateToDisplayMode(device, display.ThirdDisplayMode);
                SelectDisplay(device, display.ThirdDisplay);
                ExitDisplayMode(device, display.ThirdDisplayMode);
            }

            AppendCommand(device.GetCommand("PB06"));

            SelectDisplay(device, display.FirstDisplay, false);

            AppendCommand(EndCondition("NoDisplaysProgrammed"));
        }

        private void NavigateToDisplayMode(Device device, DisplayMode displayMode)
        {
            AppendCommand(device.GetCommand("PB07"));

            if (displayMode == DisplayMode.AG)
            {
                AppendCommand(device.GetCommand("PB07"));
            }
            if (displayMode == DisplayMode.NAV)
            {
                AppendCommand(device.GetCommand("PB07"));
                AppendCommand(device.GetCommand("PB07"));
            }
        }

        private void ExitDisplayMode(Device device, DisplayMode displayMode)
        {
            AppendCommand(device.GetCommand("PB07"));

            if (displayMode == DisplayMode.AG)
            {
                AppendCommand(device.GetCommand("PB07"));
            }
            if (displayMode == DisplayMode.AA)
            {
                AppendCommand(device.GetCommand("PB07"));
                AppendCommand(device.GetCommand("PB07"));
            }
        }

        private void SelectDisplay(Device device, Display display, bool returnToRoot = true)
        {
            if (display == Display.ADI)
            {
                AppendCommand(device.GetCommand("PB01"));
            }
            else if (display == Display.ARMT)
            {
                AppendCommand(device.GetCommand("PB02"));
            }
            else if (display == Display.HSI)
            {
                AppendCommand(device.GetCommand("PB03"));
            }
            else if (display == Display.TSD)
            {
                AppendCommand(device.GetCommand("PB05"));
            }
            else if (display == Display.TPOD)
            {
                AppendCommand(device.GetCommand("PB12"));
            }
            else if (display == Display.TEWS)
            {
                AppendCommand(device.GetCommand("PB13"));
            }
            else if (display == Display.AGRDR)
            {
                AppendCommand(device.GetCommand("PB14"));
            }
            else if (display == Display.AARDR)
            {
                AppendCommand(device.GetCommand("PB15"));
            }
            else if (display == Display.HUD)
            {
                AppendCommand(device.GetCommand("PB17"));
            }
            else if (display == Display.ENG)
            {
                AppendCommand(device.GetCommand("PB18"));
            }
            else if (display == Display.AGDLVRY)
            {
                AppendCommand(device.GetCommand("PB11"));
                AppendCommand(device.GetCommand("PB02"));
                if (returnToRoot)
                {
                    AppendCommand(device.GetCommand("PB11"));
                    AppendCommand(device.GetCommand("PB11"));
                }
            }
        }
    }
}
