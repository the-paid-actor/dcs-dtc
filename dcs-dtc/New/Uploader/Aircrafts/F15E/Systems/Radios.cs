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

        StartIf(InFrontCockpit());
        {
            BuildRadios(UFC_PILOT, config.Radios);
        }
        EndIf();
        StartIf(InRearCockpit());
        {
            BuildRadios(UFC_WSO, config.Radios);
        }
        EndIf();
    }

    private void BuildRadios(Device ufc, RadioSystem radios)
    {
        BuildRadio(ufc, radios.Radio1, "PB05", "1");

        BuildRadio(ufc, radios.Radio2, "PB06", "2");

        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("MENU"));
    }

    private void BuildRadio(Device ufc, Radio radio, string pb, string radioId)
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

        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("CLR"));
        Cmd(ufc.GetCommand("MENU"));

        var isRadio1 = radioId == "1";
        var guardChannelBtn = ufc.GetCommand(isRadio1 ? "GCML" : "GCMR");

        if (radio.Mode != 0)
        {
            if (radio.Mode == RadioMode.Frequency)
            {
                If(IsRadioPresetOrFreqSelected(ufc, radioId, "preset"), guardChannelBtn);
            }
            else if (radio.Mode == RadioMode.Preset)
            {
                If(IsRadioPresetOrFreqSelected(ufc, radioId, "freq"), guardChannelBtn);
            }
        }

        if (radio.SelectedFrequency != null)
        {
            InputFrequency(ufc, radio.SelectedFrequency);
            Cmd(ufc.GetCommand(pb));
            Cmd(ufc.GetCommand("CLR"));
        }

        Cmd(ufc.GetCommand(pb));
        if (!isRadio1)
        {
            IfNot(AMSelected(ufc), ufc.GetCommand("PB09"));
        }

        if (radio.Presets != null && radio.Presets.Count > 0)
        {
            BuildRadioPresets(ufc, radio);
        }

        if (radio.SelectedPreset != null)
        {
            if (radio.SelectedPreset == "G")
            {
                Cmd(Digits(ufc, isRadio1 ? "20" : "40"));
                Cmd(ufc.GetCommand(isRadio1 ? "PRESL" : "PRESR"));
                Cmd(ufc.GetCommand("CLR"));

                Cmd(ufc.GetCommand(isRadio1 ? "PRESLCCW" : "PRESRCCW"));
            }
            else if (radio.SelectedPreset == "GV")
            {
                Cmd(Digits(ufc, "40"));
                Cmd(ufc.GetCommand("PRESR"));
                Cmd(ufc.GetCommand("CLR"));
                Cmd(ufc.GetCommand("PRESRCCW"));
                Cmd(ufc.GetCommand("PRESRCCW"));
            }
            else
            {
                Cmd(Digits(ufc, radio.SelectedPreset));
                Cmd(ufc.GetCommand(isRadio1 ? "PRESL" : "PRESR"));
                Cmd(ufc.GetCommand("CLR"));
            }
        }

        if (radio.EnableGuard)
        {
            If(IsRadioGuardEnabledDisabled(ufc, radioId, "disabled"), ufc.GetCommand("SHF"), guardChannelBtn);
        }
        else
        {
            If(IsRadioGuardEnabledDisabled(ufc, radioId, "enabled"), ufc.GetCommand("SHF"), guardChannelBtn);
        }
    }

    private void InputFrequency(Device ufc, string freq)
    {
        if (freq.Length == 6)
        {
            if (freq.EndsWith("000"))
            {
                freq = freq.Replace("000", "001");
            }
            var parts = freq.Split('.');
            Cmd(Digits(ufc, parts[0]));
            Cmd(ufc.GetCommand("DOT"));
            Cmd(Digits(ufc, parts[1]));
        }
        else
        {
            freq = freq.Replace(".", "");
            Cmd(Digits(ufc, freq));
        }
    }

    private void BuildRadioPresets(Device ufc, Radio radio)
    {
        foreach (var preset in radio.Presets)
        { 
            if (!string.IsNullOrEmpty(preset.Frequency))
            {
                Cmd(Digits(ufc, preset.Number.ToString()));
                Cmd(ufc.GetCommand("PB01"));

                InputFrequency(ufc, preset.Frequency);
                Cmd(ufc.GetCommand("PB10"));
            }
        }
    }

    private Condition AMSelected(Device ufc)
    {
        return new Condition($"AMSelected('{ufc.Name}')");
    }

    private Condition IsRadioPresetOrFreqSelected(Device ufc, string radio, string mode)
    {
        return new Condition($"IsRadioPresetOrFreqSelected('{ufc.Name}','{radio}','{mode}')");
    }

    private Condition IsRadioGuardEnabledDisabled(Device ufc, string radio, string mode)
    {
        return new Condition($"IsRadioGuardEnabledDisabled('{ufc.Name}','{radio}','{mode}')");
    }
}