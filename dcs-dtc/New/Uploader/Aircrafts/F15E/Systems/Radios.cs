using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F15E;

public partial class F15EUploader : Base.Uploader
{
    private void BuildRadios()
    {
        if (!config.Upload.Radios || config.Radios == null)
        {
            return;
        }

        StartIf(IsInFrontCockpit());
        {
            BuildRadios(UFC_PILOT, config.Radios);
        }
        EndIf();
        StartIf(IsInRearCockpit());
        {
            BuildRadios(UFC_WSO, config.Radios);
        }
        EndIf();
    }

    private void BuildRadios(Device d, RadioSystem radios)
    {
        BuildRadio(d, radios.Radio1, "PB05");

        BuildRadio(d, radios.Radio2, "PB06");

        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("MENU"));
    }

    private void BuildRadio(Device d, Radio radio, string pb)
    {
        if (radio == null) return;

        if (!radio.EnableGuard && 
            (radio.Presets == null || radio.Presets.Count == 0) &&
            radio.SelectedFrequency == null && 
            radio.SelectedPreset == null &&
            radio.Mode == 0)
        {
            return;
        }

        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("CLR"));
        Cmd(d.GetCommand("MENU"));

        var isRadio1 = (pb == "PB05");

        if (radio.Mode != 0)
        {
            if (radio.Mode == RadioMode.Frequency)
            {
                If(IsRadioPresetOrFreqSelected(isRadio1 ? "1" : "2", "preset"), d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
            }
            else if (radio.Mode == RadioMode.Preset)
            {
                If(IsRadioPresetOrFreqSelected(isRadio1 ? "1" : "2", "freq"), d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
            }
        }

        if (radio.SelectedFrequency != null)
        {
            InputFrequency(d, radio.SelectedFrequency);
            Cmd(d.GetCommand(pb));
            Cmd(d.GetCommand("CLR"));
        }

        Cmd(d.GetCommand(pb));

        if (radio.Presets != null && radio.Presets.Count > 0)
        {
            BuildRadioPresets(d, radio);
        }

        if (radio.SelectedPreset != null)
        {
            if (radio.SelectedPreset == "G")
            {
                Cmd(Digits(d, isRadio1 ? "20" : "40"));
                Cmd(d.GetCommand(isRadio1 ? "PRESL" : "PRESR"));
                Cmd(d.GetCommand("CLR"));

                Cmd(d.GetCommand(isRadio1 ? "PRESLCCW" : "PRESRCCW"));
            }
            else if (radio.SelectedPreset == "GV")
            {
                Cmd(Digits(d, "40"));
                Cmd(d.GetCommand("PRESR"));
                Cmd(d.GetCommand("CLR"));
                Cmd(d.GetCommand("PRESRCCW"));
                Cmd(d.GetCommand("PRESRCCW"));
            }
            else
            {
                Cmd(Digits(d, radio.SelectedPreset));
                Cmd(d.GetCommand(isRadio1 ? "PRESL" : "PRESR"));
                Cmd(d.GetCommand("CLR"));
            }
        }

        if (radio.EnableGuard)
        {
            If(IsRadioGuardEnabledDisabled(isRadio1 ? "1" : "2", "disabled"), d.GetCommand("SHF"), d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
        }
        else
        {
            If(IsRadioGuardEnabledDisabled(isRadio1 ? "1" : "2", "enabled"), d.GetCommand("SHF"), d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
        }
    }

    private void InputFrequency(Device d, string freq)
    {
        if (freq.Length == 6)
        {
            if (freq.EndsWith("000"))
            {
                freq = freq.Replace("000", "001");
            }
            var parts = freq.Split('.');
            Cmd(Digits(d, parts[0]));
            Cmd(d.GetCommand("DOT"));
            Cmd(Digits(d, parts[1]));
        }
        else
        {
            freq = freq.Replace(".", "");
            Cmd(Digits(d, freq));
        }
    }

    private void BuildRadioPresets(Device d, Radio radio)
    {
        foreach (var preset in radio.Presets)
        { 
            if (!string.IsNullOrEmpty(preset.Frequency))
            {
                Cmd(Digits(d, preset.Number.ToString()));
                Cmd(d.GetCommand("PB01"));

                InputFrequency(d, preset.Frequency);
                Cmd(d.GetCommand("PB10"));
            }
        }
    }
}