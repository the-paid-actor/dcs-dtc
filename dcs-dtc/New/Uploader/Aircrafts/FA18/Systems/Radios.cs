using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.FA18;

public partial class FA18Uploader
{
    private void BuildRadios()
    {
        if (!config.Upload.Radios ||
            config.Radios == null)
        {
            return;
        }

        BuildRadio(1, config.Radios.Radio1, UFC.COM1, UFC.COM1INC);
        BuildRadio(2, config.Radios.Radio2, UFC.COM2, UFC.COM2INC);
    }

    private void BuildRadio(int radioId, Radio radio, Command toggleRadioCmd, Command radioIncCmd)
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

        if (radio.EnableGuard)
        {
            Cmd(toggleRadioCmd);
            If(IsRadioGuardDisabled(), UFC.OPT1);
        }

        if (radio.Presets != null && radio.Presets.Count > 0)
        {
            Cmd(toggleRadioCmd);
            foreach (var preset in radio.Presets)
            {
                Loop(30, InRadioChannel(radioId, preset.Number.ToString()), radioIncCmd);
                Cmd(Wait());
                Cmd(Wait());
                Cmd(Wait());
                Cmd(Digits(UFC, GetDigitsFromFrequency(preset.Frequency)));
                Cmd(UFC.ENT);
                Cmd(Wait());
            }
        }

        if (radio.Mode == RadioMode.Preset && radio.SelectedPreset != null)
        {
            Cmd(toggleRadioCmd);
            Loop(30, InRadioChannel(radioId, radio.SelectedPreset), radioIncCmd);
            Cmd(Wait());
            Cmd(Wait());
            Cmd(Wait());
        }
        else if (radio.Mode == RadioMode.Frequency && radio.SelectedFrequency != null)
        {
            Cmd(toggleRadioCmd);
            Loop(30, InRadioChannel(radioId, "M"), radioIncCmd);
            Cmd(Wait());
            Cmd(Wait());
            Cmd(Wait());
            Cmd(Digits(UFC, GetDigitsFromFrequency(radio.SelectedFrequency)));
            Cmd(UFC.ENT);
            Cmd(Wait());
        }
    }

    private string GetDigitsFromFrequency(string frequency)
    {
        var parts = frequency.Split('.');
        var a = parts[0];
        var b = parts[1];
        if (b.Length < 3) b += "0";
        return a + b;
    }
}
