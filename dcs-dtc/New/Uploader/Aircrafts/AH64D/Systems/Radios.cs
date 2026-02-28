using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DTC.New.Uploader.Aircrafts.AH64D;

public partial class AH64DUploader
{
    private void BuildRadios(bool pilot)
    {
        if (!config.Upload.Radios || config.Radios == null) return;

        //BuildRadio(config.Radios.Radio1, pilot);
        BuildRadio(pilot);
    }

    private string mapPresetNoToBtn(int no)
    {
        if (no == 1) return "L1";
        if (no == 2) return "L2";
        if (no == 3) return "L3";
        if (no == 4) return "L4";
        if (no == 5) return "L5";
        if (no == 6) return "R1";
        if (no == 7) return "R2";
        if (no == 8) return "R3";
        if (no == 9) return "R4";
        if (no == 10) return "R5";


        return "";
    }

    private void BuildRadio(bool pilot)
    {

        var radio1 = config.Radios.Radio1;
        var radio2 = config.Radios.Radio2;

        var pre1 = 0;
        var pre2 = 0;
        if (radio1.Mode == RadioMode.Preset && radio1.SelectedPreset != null)
        {
            pre1 = int.Parse(radio1.SelectedPreset);
        }
        if (radio2.Mode == RadioMode.Preset && radio2.SelectedPreset != null)
        {
            pre2 = int.Parse(radio2.SelectedPreset);
        }

        Device display = pilot ? MFD_PLT_RIGHT : MFD_CPG_RIGHT;
        Device keyboard = pilot ? KU_PILOT : KU_CPG;

        Cmd(display.GetCommand("COM"));


        RadioPreset[,] radios = new RadioPreset[11, 2];

        if (radio1 != null && radio1.Presets.Count > 0)
        {
            foreach (var preset in radio1.Presets)
            {
                if (preset.Number<=10) radios[preset.Number, 0] = preset;
            }
        }
        if (radio2 != null && radio2.Presets.Count > 0)
        {
            foreach (var preset in radio2.Presets)
            {
                if (preset.Number <= 10) radios[preset.Number, 1] = preset;
            }
        }


        var freqType = "";
        for (int i = 1; i <= 10; i++)
        {
            if (radios[i, 0] == null && radios[i, 1] == null)
            {
                continue;
            }
            var btn = mapPresetNoToBtn(i);
            if (btn == "")
            {
                continue;
            }

            Cmd(display.GetCommand(btn));
            Cmd(display.GetCommand("B6"));
            var hasName = false;
            for (var j = 0; j <= 1; j++)
            {
                var preset = radios[i, j];

                if (preset == null)
                {
                    continue;
                }


                if (preset.Name != null & preset.Name != "" && hasName == false)
                {
                    var name = preset.Name.ToUpper().Trim();
                    var name1 = name;
                    var name2 = string.Empty;

                    if (name.Length >= 4 && name[3] == ' ')
                    {
                        name2 = name.Substring(0, 3);     // pirmi 3 simboliai
                        name1 = name.Substring(4);        // nuo 5 simbolio iki galo
                    }

                    Cmd(display.GetCommand("T2"));
                    if (name1 != "")
                    {
                        Cmd(display.GetCommand("L1"));
                        Cmd(keyboard.GetCommand("CLR"));
                        Cmd(Keyboard(keyboard, $"{name1}"));
                        Cmd(keyboard.GetCommand("ENTER"));
                    }

                    if (name2 != "")
                    {
                        Cmd(display.GetCommand("L2"));
                        Cmd(keyboard.GetCommand("CLR"));
                        Cmd(Keyboard(keyboard, $"{name2}"));
                        Cmd(keyboard.GetCommand("ENTER"));
                    }
                    hasName = true;
                }

                freqType = RadioPreset.GetFreqType(preset.Frequency);

                if (freqType == "FM")
                {
                    Cmd(display.GetCommand("T4"));
                    Cmd(display.GetCommand("L4"));
                }
                else if (freqType == "UHF")
                {
                    Cmd(display.GetCommand("T3"));
                    Cmd(display.GetCommand("R4"));
                }
                else if (freqType == "VHF")
                {
                    Cmd(display.GetCommand("T3"));
                    Cmd(display.GetCommand("L1"));
                }
                else
                {
                    continue;
                }

                Cmd(keyboard.GetCommand("CLR"));
                Cmd(Keyboard(keyboard, $"{preset.Frequency}"));
                Cmd(keyboard.GetCommand("ENTER"));

            }

            if (i == pre2)
            {
                Cmd(display.GetCommand("B6"));
                Cmd(display.GetCommand("T3"));
                Cmd(display.GetCommand("B6"));
            }

            if (i == pre1)
            {

                if (freqType == "UHF")
                {
                    Cmd(display.GetCommand("T2"));
                }
                else
                {
                    Cmd(display.GetCommand("T1"));
                }
                Cmd(display.GetCommand("B6"));
            }

            Cmd(display.GetCommand("COM"));
        }

        var man1 = (radio1.Mode == RadioMode.Frequency && !string.IsNullOrEmpty(radio1.SelectedFrequency));
        var man2 = (radio2.Mode == RadioMode.Frequency && !string.IsNullOrEmpty(radio2.SelectedFrequency));

        if (man1 || man2)
        {
            Cmd(display.GetCommand("B2"));
        }
        if (man1)
        {
            if (RadioPreset.GetFreqType(radio1.SelectedFrequency) == "UHF")
            {
                Cmd(display.GetCommand("L2"));
            }
            else
            {
                Cmd(display.GetCommand("L1"));
            }

            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, $"{radio1.SelectedFrequency}"));
            Cmd(keyboard.GetCommand("ENTER"));

        }

        if (man2)
        {
            Cmd(display.GetCommand("L3"));
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, $"{radio2.SelectedFrequency}"));
            Cmd(keyboard.GetCommand("ENTER"));
        }

    }
}

