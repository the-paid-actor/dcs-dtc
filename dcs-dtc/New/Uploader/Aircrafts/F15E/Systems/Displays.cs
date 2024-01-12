using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F15E;

public partial class F15EUploader : Base.Uploader
{
    private void BuildDisplays()
    {
        if (!config.Upload.Displays || config.Displays == null)
        {
            return;
        }

        if (config.Upload.DisplayUploadMode == DisplayUploadMode.PilotAndWSO)
        {
            Cmd(GoToFrontCockpit());
        }

        Cmd(Wait(1000));

        IfElse(IsInFrontCockpit(), null, new[] { GoToRearCockpit() });

        StartIf(IsInFrontCockpit());
        {
            Cmd(GoToFrontCockpit());
            if (config.Displays.Pilot.LeftMPD.FirstDisplay != Display.None)
            {
                BuildDisplay(FLMPD, config.Displays.Pilot.LeftMPD);
            }

            if (config.Displays.Pilot.RightMPD.FirstDisplay != Display.None)
            {
                BuildDisplay(FRMPD, config.Displays.Pilot.RightMPD);
            }

            if (config.Displays.Pilot.MPCD.FirstDisplay != Display.None)
            {
                BuildDisplay(FMPCD, config.Displays.Pilot.MPCD);
            }
        }
        EndIf();

        if (config.Upload.DisplayUploadMode == DisplayUploadMode.PilotAndWSO)
        {
            Cmd(GoToRearCockpit());
        }

        Cmd(Wait(1000));

        StartIf(IsInRearCockpit());
        {
            Cmd(GoToRearCockpit());
            if (config.Displays.WSO.LeftMPCD.FirstDisplay != Display.None)
            {
                BuildDisplay(RLMPCD, config.Displays.WSO.LeftMPCD);
            }

            if (config.Displays.WSO.LeftMPD.FirstDisplay != Display.None)
            {
                BuildDisplay(RLMPD, config.Displays.WSO.LeftMPD);
            }

            if (config.Displays.WSO.RightMPD.FirstDisplay != Display.None)
            {
                BuildDisplay(RRMPD, config.Displays.WSO.RightMPD);
            }

            if (config.Displays.WSO.RightMPCD.FirstDisplay != Display.None)
            {
                BuildDisplay(RRMPCD, config.Displays.WSO.RightMPCD);
            }
        }
        EndIf();
    }

    private void BuildDisplay(Device device, DisplayConfig display)
    {
        If(DisplayNotInMainMenu(device.Name), device.GetCommand("PB11"), Wait());
        If(DisplayNotInMainMenu(device.Name), device.GetCommand("PB11"), Wait());
        If(IsProgBoxed(device.Name), device.GetCommand("PB06"), Wait());

        StartIf(NoDisplaysProgrammed(device.Name));
        {
            Cmd(device.GetCommand("PB06"));

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

            Cmd(device.GetCommand("PB06"));

            SelectDisplay(device, display.FirstDisplay, false);
        }
        EndIf();
    }

    private void NavigateToDisplayMode(Device device, DisplayMode displayMode)
    {
        Cmd(device.GetCommand("PB07"));

        if (displayMode == DisplayMode.AG)
        {
            Cmd(device.GetCommand("PB07"));
        }
        if (displayMode == DisplayMode.NAV)
        {
            Cmd(device.GetCommand("PB07"));
            Cmd(device.GetCommand("PB07"));
        }
    }

    private void ExitDisplayMode(Device device, DisplayMode displayMode)
    {
        Cmd(device.GetCommand("PB07"));

        if (displayMode == DisplayMode.AG)
        {
            Cmd(device.GetCommand("PB07"));
        }
        if (displayMode == DisplayMode.AA)
        {
            Cmd(device.GetCommand("PB07"));
            Cmd(device.GetCommand("PB07"));
        }
    }

    private void SelectDisplay(Device device, Display display, bool returnToRoot = true)
    {
        if (display == Display.ADI)
        {
            Cmd(device.GetCommand("PB01"));
        }
        else if (display == Display.ARMT)
        {
            Cmd(device.GetCommand("PB02"));
        }
        else if (display == Display.HSI)
        {
            Cmd(device.GetCommand("PB03"));
        }
        else if (display == Display.TF)
        {
            Cmd(device.GetCommand("PB04"));
        }
        else if (display == Display.TSD)
        {
            Cmd(device.GetCommand("PB05"));
        }
        else if (display == Display.TPOD)
        {
            Cmd(device.GetCommand("PB12"));
        }
        else if (display == Display.TEWS)
        {
            Cmd(device.GetCommand("PB13"));
        }
        else if (display == Display.AGRDR)
        {
            Cmd(device.GetCommand("PB14"));
        }
        else if (display == Display.AARDR)
        {
            Cmd(device.GetCommand("PB15"));
        }
        else if (display == Display.HUD)
        {
            Cmd(device.GetCommand("PB17"));
        }
        else if (display == Display.ENG)
        {
            Cmd(device.GetCommand("PB18"));
        }
        else if (display == Display.AGDLVRY)
        {
            Cmd(device.GetCommand("PB11"));
            Cmd(device.GetCommand("PB02"));
            if (returnToRoot)
            {
                Cmd(device.GetCommand("PB11"));
                Cmd(device.GetCommand("PB11"));
            }
        }
        else if (display == Display.SMART)
        {
            Cmd(device.GetCommand("PB11"));
            Cmd(device.GetCommand("PB14"));
            if (returnToRoot)
            {
                Cmd(device.GetCommand("PB11"));
                Cmd(device.GetCommand("PB11"));
            }
        }
    }
}