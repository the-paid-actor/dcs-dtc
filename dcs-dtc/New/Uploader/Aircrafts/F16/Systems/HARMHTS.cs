
using DTC.New.Uploader.Base;
using DTC.Utilities;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildHARMHTS()
    {
        if (!config.Upload.HARMHTS) return;

        ResetToNavMode();

        Cmd(UFC.RTN);
        Cmd(UFC.RTN);
        Cmd(UFC.AG);

        BuildHARM();
        BuildHTSManualTable();
        BuildHTSMFD();

        ResetToNavMode();
    }

    private void BuildHTSMFD()
    {
        var s = "{" +
            $"firstPageId = {LMFD.OSB14.Id}, " +
            $"secondPageId = {LMFD.OSB13.Id}, " +
            $"thirdPageId = {LMFD.OSB12.Id}, " +
            $"leftMFDDeviceID = {LMFD.Id}, " +
            $"rightMFDDeviceID = {RMFD.Id}, " +
            $"threatButtonId = {LMFD.OSB04.Id}, " +
            $"allButtonId = {LMFD.OSB05.Id}, " +
            $"delay = {Settings.ViperCommandDelayMs * LMFD.OSB20.DelayFactor}, " +
            $"activation = {LMFD.OSB20.Activation}, " +
            $"class1 = {(config.HTS.EnabledClasses[0] ? LMFD.OSB20.Id : false)}, " +
            $"class2 = {(config.HTS.EnabledClasses[1] ? LMFD.OSB19.Id : false)}, " +
            $"class3 = {(config.HTS.EnabledClasses[2] ? LMFD.OSB18.Id : false)}, " +
            $"class4 = {(config.HTS.EnabledClasses[3] ? LMFD.OSB17.Id : false)}, " +
            $"class5 = {(config.HTS.EnabledClasses[4] ? LMFD.OSB16.Id : false)}, " +
            $"class6 = {(config.HTS.EnabledClasses[5] ? LMFD.OSB06.Id : false)}, " +
            $"class7 = {(config.HTS.EnabledClasses[6] ? LMFD.OSB07.Id : false)}, " +
            $"class8 = {(config.HTS.EnabledClasses[7] ? LMFD.OSB08.Id : false)}, " +
            $"class9 = {(config.HTS.EnabledClasses[8] ? LMFD.OSB09.Id : false)}, " +
            $"class10 = {(config.HTS.EnabledClasses[9] ? LMFD.OSB10.Id : false)}, " +
            $"class11 = {(config.HTS.EnabledClasses[10] ? LMFD.OSB01.Id : false)}, " +
            $"manual = {(!config.HTS.ManualTableEnabled ? LMFD.OSB02.Id : false)}, " +
        "}";
        Cmd(BuildHTSMFD(s));
    }

    private void BuildHTSManualTable()
    {
        var cmds = new List<ICommand>();
        cmds.Add(UFC.ENTR);

        for (var i = 0; i < 8; i++)
        {
            if (config.HTS.ManualEmitters.Length > i)
            {
                cmds.AddRange(Digits(UFC, IntegerString(config.HTS.ManualEmitters[i])));
            }
            else
            {
                cmds.Add(UFC.D0);
            }
            cmds.Add(UFC.ENTR);
        }

        Cmd(UFC.LIST);
        Cmd(UFC.D0);
        Cmd(Wait());
        If(IsHTSEnabled(), cmds.ToArray());
        Cmd(UFC.RTN);
    }

    private void BuildHARM()
    {
        var cmds = new List<ICommand>();
        cmds.Add(UFC.D0);

        foreach (var table in config.HARM.Tables)
        {
            if (!table.ToBeUpdated)
            {
                cmds.Add(UFC.INC);
                continue;
            }
            for (var i = 0; i < 5; i++)
            {
                if (table.Emitters.Length > i)
                {
                    cmds.AddRange(Digits(UFC, IntegerString(table.Emitters[i])));
                }
                else
                {
                    cmds.Add(UFC.D0);
                }
                cmds.Add(UFC.ENTR);
                cmds.Add(UFC.DOWN);
            }
            cmds.Add(UFC.INC);
        }

        Cmd(UFC.LIST);
        Cmd(UFC.D0);
        Cmd(Wait());
        If(IsHARMEnabled(), cmds.ToArray());
        Cmd(UFC.RTN);
    }
}