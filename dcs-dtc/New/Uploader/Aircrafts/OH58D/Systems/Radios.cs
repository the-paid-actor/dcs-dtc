using DTC.New.Presets.V2.Base;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;
using DTC.Utilities;
using Microsoft.VisualBasic.Devices;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DTC.New.Uploader.Aircrafts.OH58D;

public partial class OH58DUploader
{
    private void BuildRadios(bool pilot)
    {
        if (!config.Upload.Radios || config.Radios == null) return;
        BuildRadio(pilot);
    }

    

    private void add1(Device display, Device keyboard, string? Freq, string Btn1, string Btn2)
    {
        if (Freq != null && Freq != "")
        {
            //Cmd(display.GetCommand(Btn1));
            //Cmd(display.GetCommand(Btn2));
            //Cmd(keyboard.GetCommand("CLR"));
            //Cmd(KeyboardCommands(keyboard, $"{Freq}"));
            //Cmd(keyboard.GetCommand("ENTER"));
        }
    }

    private void BuildRadio(bool pilot)
    {

        var radio1 = config.Radios.Radio;
        var modes = radio1.SelectedModes;

        //==============================
        //======= MODE FREQ
        //==============================
        Cmd(new CustomCommand($"ToCommsPage()"));
        for (int i = 1; i <= 4; i++)
        {
            if (i == 1) //UHF
            {
                Cmd(LineAddress.L2);
            }
            else if (i == 2) //VHF
            {
                Cmd(LineAddress.L3);
            }
            else if (i == 3) //FM1
            {
                Cmd(LineAddress.L1);
            }
            else if (i == 4) //FM2
            {
                Cmd(LineAddress.L5);
            }


            foreach (var preset in radio1.Presets)
            {
                if (preset.Number > 19) continue;
                var freq = preset.Frequencies[i - 1];
                if (freq == "") 
                {
                    continue;
                }
                Cmd(LineAddress.R1);
                strToCmd(preset.Number.ToString());
                Cmd(Keyboard.Enter);
                strToCmd(freq.Replace(".",""));
                Cmd(Keyboard.Enter);
                var name = preset.Name;
                if (name!= null && name !=  "")
                {
                    if ( name.Length>7)
                    {
                        name = name.Substring(0, 7);
                    }
                    strToCmd(name);
                }
                Cmd(Keyboard.Enter);
            }

        }





        //==============================
        //======= MODES
        //==============================

        for (int i = 0; i <= 3; i++)
        {
            if (modes[i] == null
                 || modes[i].SelectedMode == null
                 || (modes[i].SelectedMode == RadioMode.Frequency && (modes[i].SelectedFrequency == null || modes[i].SelectedFrequency == ""))
                 || (modes[i].SelectedMode != RadioMode.Frequency && (modes[i].SelectedPreset == null || modes[i].SelectedPreset == "")))
            {
                continue;
            }

            var id = 0;
            if (i == 0) //UHF
            {
                Cmd(Radios.TransSelectorSwitch2);
                id = 2;
            }
            else if (i == 1) //VHF
            {
                Cmd(Radios.TransSelectorSwitch3);
                id = 3;
            }
            else if (i == 2) //FM1
            {
                Cmd(Radios.TransSelectorSwitch1);
                id = 1;
            }
            else if (i == 3) //FM2
            {
                Cmd(Radios.TransSelectorSwitch5);
                id = 5;
            }

            if (modes[i].SelectedMode == RadioMode.Frequency)
            {
                Cmd(new CustomCommand($"setType(" + id.ToString() + ",1,0)"));
                Cmd(Radios.ChanSelectSwitchLEFT);
                strToCmd(modes[i].SelectedFrequency.Replace(".", ""));
                Cmd(Keyboard.Enter);
            }
            else if (modes[i].SelectedPreset != null || modes[i].SelectedPreset != "")
            {
                Cmd(new CustomCommand($"setType(" + id.ToString() + ",0," + modes[i].SelectedPreset + ")"));
            }


        }

    }
        
}
