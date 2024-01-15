using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildMisc()
    {
        if (!config.Upload.Misc || config.Misc == null) return;

        Cmd(UFC.RTN);
        Cmd(UFC.RTN);

        if (config.Misc.BingoToBeUpdated)
            BuildBingo();
        if (config.Misc.CARAALOWToBeUpdated)
            BuildCARA();
        if (config.Misc.MSLFloorToBeUpdated)
            BuildMSLFloor();
        if (config.Misc.LaserSettingsToBeUpdated)
            BuildLaserSettings();
        if (config.Misc.BullseyeToBeUpdated)
            BuildBullseye();
        if (config.Misc.TACANToBeUpdated)
            BuildTACAN();
        if (config.Misc.ILSToBeUpdated)
            BuildILS();
    }

    private void BuildBingo()
    {
        Cmd(UFC.LIST);
        Cmd(UFC.D2);
        Cmd(Digits(UFC, IntegerString(config.Misc.Bingo)));
        Cmd(UFC.ENTR);
        Cmd(UFC.RTN);
    }

    private void BuildCARA()
    {
        Cmd(UFC.D2);
        Cmd(Digits(UFC, IntegerString(config.Misc.CARAALOW)));
        Cmd(UFC.ENTR);
        Cmd(UFC.RTN);
    }

    private void BuildMSLFloor()
    {
        Cmd(UFC.D2);
        Cmd(UFC.DOWN);
        Cmd(Digits(UFC, IntegerString(config.Misc.MSLFloor)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);
        Cmd(UFC.RTN);
    }

    private void BuildLaserSettings()
    {
        Cmd(UFC.LIST);
        Cmd(UFC.D0);
        Cmd(UFC.D5);

        Cmd(Digits(UFC, IntegerString(config.Misc.TGPCode)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, IntegerString(config.Misc.LSTCode)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, IntegerString(config.Misc.LaserStartTime)));
        Cmd(UFC.ENTR);
        Cmd(UFC.RTN);
    }

    private void BuildBullseye()
    {
        Cmd(UFC.LIST);
        Cmd(UFC.D0);
        Cmd(UFC.D8);
        Cmd(Wait());

        If(BullseyeNotSelected(), UFC.D0);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, IntegerString(config.Misc.BullseyeWP)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);
        Cmd(UFC.RTN);
    }

    private void BuildTACAN()
    {
        Cmd(UFC.D1);
        Cmd(Digits(UFC, IntegerString(config.Misc.TACANChannel)));
        Cmd(UFC.ENTR);

        if (config.Misc.TACANBand == TACANBands.X)
        {
            If(TACANBandY(), UFC.D0, UFC.ENTR);
        }
        else
        {
            If(TACANBandX(), UFC.D0, UFC.ENTR);
        }

        If(TACANNotTR(), UFC.SEQ);
        If(TACANNotTR(), UFC.SEQ);
        Cmd(UFC.RTN);
    }

    private void BuildILS()
    {
        Cmd(UFC.D1);
        Cmd(UFC.DOWN);
        Cmd(UFC.DOWN);

        Cmd(Digits(UFC, DecimalString(config.Misc.ILSFrequency)));
        Cmd(UFC.ENTR);

        Cmd(Digits(UFC, IntegerString(config.Misc.ILSCourse)));
        Cmd(UFC.ENTR);
        Cmd(UFC.DOWN);
        Cmd(UFC.RTN);
    }

    private Condition BullseyeNotSelected()
    {
        return new Condition("BullseyeNotSelected()");
    }

    private Condition TACANBandX()
    {
        return new Condition("TACANBandX()");
    }

    private Condition TACANBandY()
    {
        return new Condition("TACANBandY()");
    }

    private Condition TACANNotTR()
    {
        return new Condition("TACANNotTR()");
    }
}