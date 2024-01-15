using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F15E;

public partial class F15EUploader : Base.Uploader
{
    private void BuildMisc()
    {
        if (!config.Upload.Misc || config.Misc == null)
        {
            return;
        }

        if (config.Misc.BingoToBeUpdated)
        {
            BuildBingo();
        }

        if (config.Misc.CARAALOWToBeUpdated)
        {
            StartIf(InFrontCockpit());
            {
                BuildCARA(UFC_PILOT);
            }
            EndIf();
            StartIf(InRearCockpit());
            {
                BuildCARA(UFC_WSO);
            }
            EndIf();
        }

        if (config.Misc.TACANToBeUpdated)
        {
            StartIf(InFrontCockpit());
            {
                BuildTACAN(UFC_PILOT);
            }
            EndIf();
            StartIf(InRearCockpit());
            {
                BuildTACAN(UFC_WSO);
            }
            EndIf();
        }

        if (config.Misc.ILSToBeUpdated)
        {
            StartIf(InFrontCockpit());
            {
                BuildILS(UFC_PILOT);
            }
            EndIf();
            StartIf(InRearCockpit());
            {
                BuildILS(UFC_WSO);
            }
            EndIf();
        }
    }

    private void BuildBingo()
    {
        for (int i = 0; i < 140; i++)
        {
            Cmd(FLTINST.BINGO_DEC);
        }

        for (int i = 0; i < config.Misc.Bingo / 100; i++)
        {
            Cmd(FLTINST.BINGO_INC);
        }
    }

    private void BuildCARA(Device ufc)
    {
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("MENU"));

        Cmd(Digits(ufc, config.Misc.CARAALOW.ToString()));
        Cmd(ufc.GetCommand("PB01"));
    }

    private void BuildTACAN(Device ufc)
    {
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("MENU"));

        Cmd(ufc.GetCommand("PB02"));

        Cmd(Digits(ufc, config.Misc.TACANChannel.ToString()));
        Cmd(ufc.GetCommand("PB01"));

        if (config.Misc.TACANBand == TACANBands.X)
        {
            If(IsTACANBand(ufc, "Y"), ufc.GetCommand("PB01"));
        }
        else
        {
            If(IsTACANBand(ufc, "X"), ufc.GetCommand("PB01"));
        }

        If(IsTACANOff(ufc), ufc.GetCommand("PB10"));
        Cmd(ufc.GetCommand("MENU"));
    }

    private void BuildILS(Device ufc)
    {
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("MENU"));
        Cmd(ufc.GetCommand("MENU"));

        Cmd(ufc.GetCommand("PB03"));

        Cmd(Digits(ufc, RemoveSeparators(config.Misc.GetILSFrequency())));
        Cmd(ufc.GetCommand("PB03"));

        Cmd(ufc.GetCommand("MENU"));
    }

    private Condition IsTACANBand(Device ufc, string band)
    {
        return new Condition($"IsTACANBand('{ufc.Name}', '{band}')");
    }

    private Condition IsTACANOff(Device ufc)
    {
        return new Condition($"IsTACANOff('{ufc.Name}')");
    }
}

