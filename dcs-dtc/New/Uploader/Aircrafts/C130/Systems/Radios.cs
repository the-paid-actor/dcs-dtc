using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.C130;

public partial class C130Uploader
{
    private void BuildRadios()
    {
        if (!config.Upload.Radios || config.Radios == null) return;

        BuildRadio(config.Radios.Radio1, 1);
        BuildRadio(config.Radios.Radio2, 2);

    }


    private void BuildRadio(Radio radio, int type)
    {
        if (radio == null) return;

        Cmd(CNI.CLR);

        Cmd(CNI.CommTune);
        if (type == 1)
        {
            Cmd(CNI.LSK_L1);
        }
        else
        {
            Cmd(CNI.LSK_L3);
        }

        Cmd(new CustomCommand($"SetCNIPage1()"));

        if (radio.Mode == RadioMode.Frequency && !string.IsNullOrEmpty(radio.SelectedFrequency))
        {
            strToCmd(radio.SelectedFrequency.ToString());
            Cmd(CNI.LSK_L1);
        }

        if (radio.Presets != null && radio.Presets.Count > 0)
        {
            var inPage = 1;
            var presets = radio.Presets.OrderBy(x => x.Number);

            foreach (var preset in presets)
            {
                var presetNo = preset.Number;
                var pageNo = Math.Ceiling((decimal)presetNo / 4);
                while (inPage < pageNo)
                {
                    Cmd(CNI.NextPage);
                    inPage++;
                }
                if (preset.Name != null && preset.Name.Length > 0)
                {
                    var name = preset.Name;
                    if (name.Length > 5)
                    {
                        name = name.Substring(0, 5);
                    }
                    if (name.Length < 5)
                    {
                        name = name.PadRight(5, '0');
                    }

                    strToCmd(name);

                }

                Cmd(CNI.BtnSlash);
                strToCmd(preset.Frequency.ToString());

                var btn = presetNo - (int)Math.Round((pageNo - 1) * 4, 0);

                Cmd(CNI.GetCommand("LSK_L" + (btn + 1).ToString()));

            }

            if (radio.Mode == RadioMode.Preset && radio.SelectedPreset != null)
            {
                strToCmd(radio.SelectedPreset.ToString());
                Cmd(CNI.LSK_L1);
            }
        }
    }
}
