using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.A10;

public partial class A10Uploader
{
    private static readonly Dictionary<char, (int Button, int Presses)> UfcLetterMap = new()
    {
        ['A'] = (1, 1),
        ['B'] = (1, 2),
        ['C'] = (1, 3),
        ['D'] = (2, 1),
        ['E'] = (2, 2),
        ['F'] = (2, 3),
        ['G'] = (3, 1),
        ['H'] = (3, 2),
        ['I'] = (3, 3),
        ['J'] = (4, 1),
        ['K'] = (4, 2),
        ['L'] = (4, 3),
        ['M'] = (5, 1),
        ['N'] = (5, 2),
        ['O'] = (5, 3),
        ['P'] = (6, 1),
        ['Q'] = (6, 2),
        ['R'] = (6, 3),
        ['S'] = (7, 1),
        ['T'] = (7, 2),
        ['U'] = (7, 3),
        ['V'] = (8, 1),
        ['W'] = (8, 2),
        ['X'] = (8, 3),
        ['Y'] = (9, 1),
        ['Z'] = (9, 2),
        ['.'] = (0, 1),
    };

    private void BuildRadios()
    {
        if (!config.Upload.Radios || config.Radios == null)
            return;

        BuildRadio(config.Radios.Radio1, 1);
    }

    private void UFCstrToCmd(string str, int max)
    {
        UFCstrToCmd(str.Substring(0, Math.Min(max, str.Length)));
    }

    private void UFCstrToCmd(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        bool inLetterMode = false;
        int lastButton = -1;

        foreach (char rawChar in value.ToUpperInvariant())
        {
            if (rawChar == ' ')
            {
                continue;
            }

            if (char.IsDigit(rawChar))
            {
                if (inLetterMode)
                {
                    Cmd(UFC.LTR);
                    inLetterMode = false;
                }

                lastButton = -1;

                Cmd(UFC.GetCommand($"Btn{rawChar}"));
                continue;
            }

            if (UfcLetterMap.TryGetValue(rawChar, out var entry))
            {
                if (!inLetterMode)
                {
                    inLetterMode = true;
                    Cmd(UFC.LTR);
                    Cmd(UFC.LTR);
                }

                if (lastButton == entry.Button || rawChar == '.')
                {
                    Cmd(Wait(1000));
                }

                lastButton = entry.Button;

                for (int i = 0; i < entry.Presses; i++)
                    Cmd(UFC.GetCommand($"Btn{entry.Button}"));

                if (rawChar == '.')
                {
                    Cmd(Wait(1000));
                }

                continue;
            }
        }

        if (inLetterMode)
        {
            Cmd(UFC.LTR);
        }
    }

    private void BuildRadio(Radio radio, int type)
    {
        if (radio == null)
        {
            return;
        }

        Cmd(new CustomCommand($"NumMode()"));

        Cmd(SYS.LEFT_MFCD_B3); // COMMS
        Cmd(SYS.LEFT_MFCD_L2); // ARC210 PRESETS

        Cmd(UFC.CLR);

        var curPos = 1;
        if (radio.Presets != null && radio.Presets.Count > 0)
        {
            var presets = radio.Presets.OrderBy(x => x.Number);

            foreach (var preset in presets)
            {
                var presetNo = preset.Number;

                if (presetNo > 18)
                {
                    Cmd(SYS.LEFT_MFCD_T2); // NEXT PAGE
                    presetNo -= 18;
                    curPos = 1;
                }

                for (int a = curPos; a < presetNo; a++)
                {
                    Cmd(SYS.LEFT_MFCD_L2); // DOWN
                    curPos++;
                }

                // FREQ
                Cmd(UFC.CLR);
                UFCstrToCmd(preset.Frequency.ToString().Replace(".000", ""));
                Cmd(SYS.LEFT_MFCD_L4);

                // NAME
                if (!string.IsNullOrWhiteSpace(preset.Name))
                {
                    Cmd(UFC.CLR);
                    UFCstrToCmd(preset.Name, 12);
                    Cmd(SYS.LEFT_MFCD_L5);
                }

                //MOD
                if (decimal.Parse(preset.Frequency) <= 87.975M)
                {
                    Cmd(new CustomCommand($"SetAMFM({curPos},\"FM\")"));
                }
                else
                {
                    Cmd(new CustomCommand($"SetAMFM({curPos},\"AM\")"));
                }
            }
        }
        Cmd(UFC.CLR);
        if (radio.Mode == RadioMode.Frequency && !string.IsNullOrEmpty(radio.SelectedFrequency))
        {
            Cmd(ARC210.MAN);
            Cmd(new CustomCommand($"SetFreq({radio.SelectedFrequency})"));
        }
        else if (radio.Mode == RadioMode.Preset && !string.IsNullOrEmpty(radio.SelectedPreset))
        {
            Cmd(ARC210.PRESET);
            Cmd(new CustomCommand($"SetPreset({radio.SelectedPreset})"));

        }
    }
}

