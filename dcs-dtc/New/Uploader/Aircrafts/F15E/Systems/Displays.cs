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

        IfElse(InFrontCockpit(), null, new[] { GoToRearCockpit() });

        StartIf(InFrontCockpit());
        {
            Cmd(GoToFrontCockpit());
            ConfigureFrontDisplays();
        }
        EndIf();

        if (config.Upload.DisplayUploadMode == DisplayUploadMode.PilotAndWSO)
        {
            Cmd(GoToRearCockpit());
        }

        Cmd(Wait(1000));

        StartIf(InRearCockpit());
        {
            Cmd(GoToRearCockpit());
            ConfigureRearDisplays();
        }
        EndIf();
    }

    private void ConfigureFrontDisplays()
    {
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

    private void ConfigureRearDisplays()
    {
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

    private void BuildDisplay(Device display, DisplayConfig config)
    {
        NavigateToMainMenu(display);

        StartIf(NoDisplaysProgrammed(display));
        {
            Cmd(display.GetCommand("PB06"));

            SelectDisplay(display, config.FirstDisplay);

            if (config.SecondDisplay != Display.None)
            {
                SelectDisplay(display, config.SecondDisplay);
            }

            if (config.ThirdDisplay != Display.None)
            {
                SelectDisplay(display, config.ThirdDisplay);
            }

            if (config.FirstDisplayMode != DisplayMode.None)
            {
                NavigateToDisplayMode(display, config.FirstDisplayMode);
                SelectDisplay(display, config.FirstDisplay);
                ExitDisplayMode(display, config.FirstDisplayMode);
            }

            if (config.SecondDisplayMode != DisplayMode.None)
            {
                NavigateToDisplayMode(display, config.SecondDisplayMode);
                SelectDisplay(display, config.SecondDisplay);
                ExitDisplayMode(display, config.SecondDisplayMode);
            }

            if (config.ThirdDisplayMode != DisplayMode.None)
            {
                NavigateToDisplayMode(display, config.ThirdDisplayMode);
                SelectDisplay(display, config.ThirdDisplay);
                ExitDisplayMode(display, config.ThirdDisplayMode);
            }

            Cmd(display.GetCommand("PB06"));

            SelectDisplay(display, config.FirstDisplay, false);
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

    private Condition NoDisplaysProgrammed(Device display)
    {
        return new Condition($"NoDisplaysProgrammed('{display.Name}')");
    }

    private CustomCommand GoToFrontCockpit()
    {
        return new CustomCommand("GoToFrontCockpit()");
    }

    private CustomCommand GoToRearCockpit()
    {
        return new CustomCommand("GoToRearCockpit()");
    }
}