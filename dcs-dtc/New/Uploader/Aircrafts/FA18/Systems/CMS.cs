using DTC.New.Presets.V2.Aircrafts.FA18.Systems;

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

        StartIf(IsDispenserOn());
        {
            Cmd(WaitUntilDispenserOn());
            If(IsDispenserNotSelected(), LMFD.OSB08, Wait(1000));

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
}