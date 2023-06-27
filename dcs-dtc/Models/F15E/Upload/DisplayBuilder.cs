using DTC.Models.DCS;
using DTC.Models.F15E.Displays;
using DTC.Models.F15E.Waypoints;
using System;
using System.Collections.Generic;
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
            var flmpd = _aircraft.GetDevice("FLMPD");
            var frmpd = _aircraft.GetDevice("FRMPD");
            var mpcd = _aircraft.GetDevice("FMPCD");

            if (_cfg.Displays.Pilot.LeftMPD.FirstDisplay != Display.None)
            {
                BuildDisplay(flmpd, _cfg.Displays.Pilot.LeftMPD);
            }

            if (_cfg.Displays.Pilot.RightMPD.FirstDisplay != Display.None)
            {
                BuildDisplay(frmpd, _cfg.Displays.Pilot.RightMPD);
            }

            if (_cfg.Displays.Pilot.MPCD.FirstDisplay != Display.None)
            {
                BuildDisplay(mpcd, _cfg.Displays.Pilot.MPCD);
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

        private void SelectDisplay(Device device, Display display)
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
                AppendCommand(device.GetCommand("PB11"));
                AppendCommand(device.GetCommand("PB11"));
            }
        }
    }
}
