using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F15E;

public partial class F15EUploader : Base.Uploader
{
    private F15EConfiguration config;

    public F15EUploader(F15EAircraft ac, F15EConfiguration cfg) : base(ac, Settings.StrikeEagleCommandDelayMs)
    {
        this.config = cfg;
    }

    public void Execute()
    {
        Cmd(SaveCockpitFrontRearState());

        this.BuildWaypoints();
        this.BuildSmartWeapons();
        this.BuildRadios();
        this.BuildMisc();
        this.BuildDisplays();

        Cmd(RestoreCockpitFrontRearState());

        Send();
    }

    private void NavigateToMainMenu(Device display)
    {
        IfNot(DisplayInMainMenu(display), display.GetCommand("PB11"), Wait());
        IfNot(DisplayInMainMenu(display), display.GetCommand("PB11"), Wait());
        If(ProgBoxed(display), display.GetCommand("PB06"), Wait());
    }

    private void InputCoordinate(Device device, string coord)
    {
        var str = coord.Replace("°", "").Replace("’", "").Replace("”", "").Replace(" ", "").Replace(".", "");
        System.Diagnostics.Debug.WriteLine(str);

        foreach (var c in str.ToCharArray())
        {
            if (c == 'N')
            {
                Cmd(device.GetCommand("SHF"));
                Cmd(device.GetCommand("D2"));
            }
            else if (c == 'S')
            {
                Cmd(device.GetCommand("SHF"));
                Cmd(device.GetCommand("D8"));
            }
            else if (c == 'E')
            {
                Cmd(device.GetCommand("SHF"));
                Cmd(device.GetCommand("D6"));
            }
            else if (c == 'W')
            {
                Cmd(device.GetCommand("SHF"));
                Cmd(device.GetCommand("D4"));
            }
            else
            {
                Cmd(device.GetCommand("D" + c.ToString()));
            }
        }
    }

    private Condition DisplayInMainMenu(Device display)
    {
        return new Condition($"DisplayInMainMenu('{display.Name}')");
    }

    private Condition ProgBoxed(Device display)
    {
        return new Condition($"ProgBoxed('{display.Name}')");
    }

    private Condition InFrontCockpit()
    {
        return new Condition("InFrontCockpit()");
    }

    private Condition InRearCockpit()
    {
        return new Condition("InRearCockpit()");
    }

    private CustomCommand SaveCockpitFrontRearState()
    {
        return new CustomCommand("SaveCockpitFrontRearState()");
    }

    private CustomCommand RestoreCockpitFrontRearState()
    {
        return new CustomCommand("RestoreCockpitFrontRearState()");
    }

    // Test function to check UFC and buttons responsiveness
    //private void Test()
    //{
    //    for (int i = 0; i < 100; i++)
    //    {
    //        Cmd(UFC_PILOT.D1);
    //        Cmd(UFC_PILOT.D2);
    //        Cmd(UFC_PILOT.D3);
    //        Cmd(UFC_PILOT.D4);
    //        Cmd(UFC_PILOT.D5);
    //        Cmd(UFC_PILOT.D6);
    //        Cmd(UFC_PILOT.D7);
    //        Cmd(UFC_PILOT.D8);
    //        Cmd(UFC_PILOT.D9);
    //        Cmd(UFC_PILOT.D0);
    //        Cmd(TestUFC(UFC_PILOT.Name, "1234567890"));
    //        Cmd(UFC_PILOT.CLR);
    //        Cmd(UFC_PILOT.CLR);
    //    }
    //}
    //private CustomCommand TestUFC(string device, string str)
    //{
    //    return new CustomCommand($"TestUFC('{device}', '{str}')");
    //}
}