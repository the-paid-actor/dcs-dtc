using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using Microsoft.VisualBasic.Devices;
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

    private void add1(Device display, Device keyboard, string? Freq, string Btn1, string Btn2)
    {
        if (Freq != null && Freq != "")
        {
            Cmd(display.GetCommand(Btn1));
            Cmd(display.GetCommand(Btn2));
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, $"{Freq}"));
            Cmd(keyboard.GetCommand("ENTER"));
        }
    }

    private void BuildRadio(bool pilot)
    {

        var radio1 = config.Radios.Radio;

        Device display = pilot ? MFD_PLT_RIGHT : MFD_CPG_RIGHT;
        Device keyboard = pilot ? KU_PILOT : KU_CPG;

        Cmd(display.GetCommand("COM"));

        Radio6SelectedMode[] modes = new Radio6SelectedMode[6];
        if (radio1 != null && radio1.SelectedModes != null && radio1.SelectedModes.Count > 0)
        {
            foreach (var mode in radio1.SelectedModes)
            {
                if (mode.Number <= 5) modes[mode.Number] = mode;
            }
        }
        //==============================
        //======= MODE FREQ
        //==============================
        var first = true;
        for (int i = 1; i <= 5; i++) //-HF2 
        {
            if (modes[i] == null || modes[i].SelectedMode == null || modes[i].SelectedMode != RadioMode.Frequency || modes[i].SelectedFrequency == null || modes[i].SelectedFrequency == "")
            {
                continue;
            }
            if (first)
            {
                Cmd(display.GetCommand("B2"));
                first = false;
            }
            if (i == 1) //UHF
            {
                Cmd(display.GetCommand("L2"));
            }
            else if (i == 2) //VHF
            {
                Cmd(display.GetCommand("L1"));
            }
            else if (i == 3) //FM1
            {
                Cmd(display.GetCommand("L3"));
            }
            else if (i == 4) //FM2
            {
                Cmd(display.GetCommand("L4"));
            }
            else if (i == 5) //HF1
            {
                Cmd(display.GetCommand("R1"));
            }

            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, $"{modes[i].SelectedFrequency}"));
            Cmd(keyboard.GetCommand("ENTER"));
        }
        if (first == false)
        {
            Cmd(display.GetCommand("COM"));
        }


        //==============================
        //======= PRESETS
        //==============================
        Radio6Preset[] radios = new Radio6Preset[11];

        if (radio1 != null && radio1.Presets != null && radio1.Presets.Count > 0)
        {
            foreach (var preset in radio1.Presets)
            {
                if (preset.Number <= 10) radios[preset.Number] = preset;
            }
        }

        for (int i = 1; i <= 10; i++)
        {
            if (radios[i] == null)
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
            var preset = radios[i];
            if (preset == null)
            {
                continue;
            }

            if (!string.IsNullOrEmpty(preset.Name))
            {
                var name = preset.Name.ToUpper().Trim();
                var name1 = name;
                var name2 = string.Empty;

                if (name.Length >= 4 && name[3] == ' ')
                {
                    name2 = name.Substring(0, 3);
                    name1 = name.Substring(4);
                }

                Cmd(display.GetCommand("T2"));
                if (name1 != "")
                {
                    Cmd(display.GetCommand("L1"));
                    Cmd(keyboard.GetCommand("CLR"));
                    Cmd(Keyboard(keyboard, $"{name1}", 3, 8));
                    Cmd(keyboard.GetCommand("ENTER"));
                }

                if (name2 != "")
                {
                    Cmd(display.GetCommand("L2"));
                    Cmd(keyboard.GetCommand("CLR"));
                    Cmd(Keyboard(keyboard, $"{name2}", 3, 3));
                    Cmd(keyboard.GetCommand("ENTER"));
                }
            }

            add1(display, keyboard, preset.Frequencies[0], "T3", "R4");
            add1(display, keyboard, preset.Frequencies[1], "T3", "L1");
            add1(display, keyboard, preset.Frequencies[2], "T4", "L4");
            add1(display, keyboard, preset.Frequencies[3], "T4", "R4");
            add1(display, keyboard, preset.Frequencies[4], "T5", "R1");
            add1(display, keyboard, preset.Frequencies[5], "T5", "R3");
            Cmd(display.GetCommand("B6"));
        }

        //==============================
        //======= MODE PRESET
        //==============================

        Cmd(display.GetCommand("COM"));
        var lastPr = "0";
        for (int i = 1; i <= 5; i++) //-HF2 
        {
            if (modes[i] == null || modes[i].SelectedMode != RadioMode.Preset)
            {
                continue;
            }

            var btn = mapPresetNoToBtn(int.Parse(modes[i].SelectedPreset));
            if (btn == "")
            {
                continue;
            }

            if (btn != lastPr)
            {
                Cmd(display.GetCommand(btn));
            }
            lastPr = btn;


            if (i == 1) //UHF
            {
                Cmd(display.GetCommand("T2"));
            }
            else if (i == 2) //VHF
            {
                Cmd(display.GetCommand("T1"));
            }
            else if (i == 3) //FM1
            {
                Cmd(display.GetCommand("T3"));
            }
            else if (i == 4) //FM2
            {
                Cmd(display.GetCommand("T4"));
            }
            else if (i == 5) //HF
            {
                Cmd(display.GetCommand("T5"));
            }
            Cmd(display.GetCommand("B6"));
        }
    }
}

