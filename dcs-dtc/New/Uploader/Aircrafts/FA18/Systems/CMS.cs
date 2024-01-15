using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.Globalization;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private void BuildCMS()
    {
        if (!config.Upload.CMS ||
            config.CMS == null)
        {
            return;
        }

        SetLeftMFDTac();
        Cmd(LMFD.OSB17); // EW

        If(EWHudNotBoxed(), LMFD.OSB14);

        StartIf(DispenserOn());
        {
            Cmd(WaitUntilDispenserOn());
            If(DispenserNotSelected(), LMFD.OSB08, Wait(1000));

            Cmd(LMFD.OSB09); // ARM

            for (var i = 0; i < config.CMS.Programs.Length; i++)
            {
                var program = config.CMS.Programs[i];
                if (!program.ToBeUpdated) continue;

                Cmd(SelectDispenserProgram(program.Number));
                Cmd(SetDispenser("chaff", LMFD.OSB05, program.ChaffQty));
                Cmd(SetDispenser("flare", LMFD.OSB04, program.FlareQty));
                Cmd(SetDispenser("repeat", LMFD.OSB14, program.Repeat));
                Cmd(SetDispenser("interval", LMFD.OSB15, program.Interval));
                Cmd(LMFD.OSB19); //Save
            }

            Cmd(SelectDispenserProgram(config.CMS.SelectedProgram));
            Wait();

            Cmd(LMFD.OSB09); //Return

            if (config.CMS.Mode != null && config.CMS.Mode != CMSMode.Unchanged)
            {
                var mode = "STBY";
                if (config.CMS.Mode == CMSMode.Manual)
                {
                    mode = "MAN ";
                }
                else if (config.CMS.Mode == CMSMode.SemiAuto)
                {
                    mode = "S/A ";
                }
                else if (config.CMS.Mode == CMSMode.Auto)
                {
                    mode = "AUTO";
                }
                Loop(InDispenserMode(mode), LMFD.OSB19, Wait());
            }
        }
        EndIf();
    }

    private Condition DispenserOn()
    {
        return new Condition($"DispenserOn()");
    }

    private CustomCommand WaitUntilDispenserOn()
    {
        return new CustomCommand($"WaitUntilDispenserOn()");
    }

    private Condition DispenserNotSelected()
    {
        return new Condition($"DispenserNotSelected()");
    }

    private Condition InDispenserMode(string mode)
    {
        return new Condition($"InDispenserMode('{mode}')");
    }

    private Condition EWHudNotBoxed()
    {
        return new Condition($"EWHudNotBoxed()");
    }

    private CustomCommand SelectDispenserProgram(int program)
    {
        var btn = LMFD.OSB20;
        var delay = (Settings.HornetCommandDelayMs * btn.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var postDelay = (Settings.HornetCommandDelayMs * btn.PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"SelectDispenserProgram({program}, {LMFD.Id}, {btn.Id}, {delay}, {btn.Activation}, {postDelay})");
    }

    private CustomCommand SetDispenser(string type, Command selectBtn, decimal qty)
    {
        var qtyStr = qty.ToString(CultureInfo.InvariantCulture);
        var inc = LMFD.OSB12;
        var dec = LMFD.OSB13;
        var delay = (Settings.HornetCommandDelayMs * inc.DelayFactor).ToString(CultureInfo.InvariantCulture);
        var postDelay = (Settings.HornetCommandDelayMs * inc.PostDelayFactor).ToString(CultureInfo.InvariantCulture);
        return new CustomCommand($"SetDispenser('{type}', {qtyStr}, {LMFD.Id}, {selectBtn.Id}, {inc.Id}, {dec.Id}, {delay}, {inc.Activation}, {postDelay})");
    }
}