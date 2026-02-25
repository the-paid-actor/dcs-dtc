using DTC.New.Presets.V2.Aircrafts.CH47F.Systems;
using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;


namespace DTC.New.Uploader.Aircrafts.CH47F;

public partial class CH47FUploader
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

          Cmd(CDU.CLR);
          Cmd(CDU.MSN);

        if (type == 1 && radio.Mode == RadioMode.Frequency && !string.IsNullOrEmpty(radio.SelectedFrequency))
        {
            strToCmd(radio.SelectedFrequency.ToString());
            if (type == 1)
            {
                Cmd(CDU.LSK_R2);
            }
            else
            {
                Cmd(CDU.LSK_R3);
            }
        }

        if (type == 2 && radio.Mode == RadioMode.Frequency)
        {
            Cmd(ARC186.MODE_MANUAL);
        }
        if (type == 2 && radio.Mode == RadioMode.Preset)
        {
            Cmd(ARC186.MODE_PRESET);
        }

        if (type == 2 && radio.Mode == RadioMode.Frequency && !string.IsNullOrEmpty(radio.SelectedFrequency))
        {
            Cmd(new CustomCommand($"SetV3(\"" + radio.SelectedFrequency + "\")"));
        }


        var inPage = 1;

        if (radio.Presets != null && radio.Presets.Count > 0)
        {

            if (type == 1)
            {
                Cmd(CDU.LSK_L2);
            }
            else
            {
                Cmd(CDU.LSK_L3);
            }

            Cmd(CDU.LSK_L1);


            var presets = radio.Presets.OrderBy(x => x.Number);

            foreach (var preset in presets)
            {
                var presetNo = preset.Number;
                var pageNo = Math.Ceiling((decimal)presetNo / 5);
                var btn = presetNo - (int)Math.Round((pageNo - 1) * 5, 0);
                while (inPage < pageNo)
                {
                    Cmd(CDU.DOWN);
                    inPage++;
                }
                if (preset.Name != null && preset.Name.Length > 0)
                {
                    var name = preset.Name;
                    if (name.Length > 6)
                    {
                        name = name.Substring(0, 6);
                    }

                    strToCmd(name);
                    Cmd(CDU.GetCommand("LSK_L" + btn.ToString()));
                }

                strToCmd(preset.Frequency.ToString());
                Cmd(CDU.GetCommand("LSK_R" + btn.ToString()));
            }
        }


        if (radio.Mode == RadioMode.Preset && radio.SelectedPreset != null)
        {

            var presetNo = int.Parse(radio.SelectedPreset);
            var pageNo = Math.Ceiling((decimal)presetNo / 5);


            while (inPage < pageNo)
            {
                Cmd(CDU.DOWN);
                inPage++;
            }

            while (inPage > pageNo)
            {
                Cmd(CDU.UP);
                inPage--;
            }

            var btn = presetNo - (int)Math.Round((pageNo - 1) * 5, 0);
            CmdWithDelay(CDU.GetCommand("LSK_L" + btn.ToString()), 1600);
        }

    }

}

