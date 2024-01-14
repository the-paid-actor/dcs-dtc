using DTC.New.Presets.V2.Base.Systems;
using DTC.New.Uploader.Base;

namespace DTC.New.Uploader.Aircrafts.F16;

public partial class F16Uploader
{
    public void BuildRadios()
    {
        if (!config.Upload.Radios || config.Radios == null) return;

        Cmd(UFC.RTN);
        Cmd(UFC.RTN);

        BuildRadios(UFC.COM1, config.Radios.Radio1);
        BuildRadios(UFC.COM2, config.Radios.Radio2);
        Cmd(UFC.RTN);
    }

    private void BuildRadios(Command radioCmd, Radio radio)
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

        Cmd(radioCmd);

        if (radio.EnableGuard)
        {
            If(IsRadioNotBoth(), UFC.SEQ);
        }

        if (radio.Mode == RadioMode.Preset && radio.SelectedPreset != null)
        {
            Cmd(Digits(UFC, radio.SelectedPreset));
            Cmd(UFC.ENTR);
            Cmd(radioCmd);
        }
        else if (radio.Mode == RadioMode.Frequency && radio.SelectedFrequency != null)
        {
            Cmd(Digits(UFC, GetDigitsFromFrequency(radio.SelectedFrequency)));
            Cmd(UFC.ENTR);
            Cmd(radioCmd);
        }

        if (radio.Presets != null && radio.Presets.Count > 0)
        {
            Cmd(UFC.DOWN);
            Cmd(UFC.DOWN);

            foreach (var preset in radio.Presets)
            {
                Cmd(Digits(UFC, IntegerString(preset.Number)));
                Cmd(UFC.ENTR);
                Cmd(UFC.DOWN);
                Cmd(Digits(UFC, GetDigitsFromFrequency(preset.Frequency)));
                Cmd(UFC.ENTR);
                Cmd(UFC.UP);
            }
        }
    }

    private string GetDigitsFromFrequency(string frequency)
    {
        var parts = frequency.Split('.');
        var a = parts[0];
        var b = parts[1];
        return a + b;
    }
}