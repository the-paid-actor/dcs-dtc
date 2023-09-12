using DTC.Models.DCS;
using System.Text;

namespace DTC.Models.F15E.Upload
{
    class RadioBuilder : BaseBuilder
    {
        private F15EConfiguration _cfg;

        public RadioBuilder(F15EConfiguration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
        {
            _cfg = cfg;
        }

        public override void Build()
        {
            if (_cfg.Radios.EnableUpload)
                BuildRadios();
        }

        private void BuildRadios()
        {
            var d = _aircraft.GetDevice("UFC_PILOT");

            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("MENU"));

            BuildRadio(d, _cfg.Radios.Radio1, "PB5");

            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("MENU"));

            BuildRadio(d, _cfg.Radios.Radio2, "PB6");

            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("CLR"));
            AppendCommand(d.GetCommand("MENU"));
        }

        private void BuildRadio(Device d, Radios.Radio radio, string pb)
        {
            var isRadio1 = (pb == "PB5");

            if (radio.Mode == Radios.RadioMode.Frequency)
            {
                AppendCommand(StartCondition("IsRadioPresetOrFreqSelected", isRadio1 ? "1" : "2", "preset"));
                AppendCommand(d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
                AppendCommand(EndCondition("IsRadioPresetOrFreqSelected"));
            }
            if (radio.Mode == Radios.RadioMode.Preset)
            {
                AppendCommand(StartCondition("IsRadioPresetOrFreqSelected", isRadio1 ? "1" : "2", "freq"));
                AppendCommand(d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
                AppendCommand(EndCondition("IsRadioPresetOrFreqSelected"));
            }

            if (radio.SelectedFrequency != null)
            {
                InputFrequency(d, radio.SelectedFrequency);
                AppendCommand(d.GetCommand(pb));
                AppendCommand(d.GetCommand("CLR"));
            }

            AppendCommand(d.GetCommand(pb));

            BuildRadioPresets(d, radio);

            if (radio.SelectedPreset == "G")
            {
                AppendCommand(BuildDigits(d, "1"));
                AppendCommand(d.GetCommand(isRadio1 ? "PRESL" : "PRESR"));
                AppendCommand(d.GetCommand("CLR"));

                AppendCommand(d.GetCommand(isRadio1 ? "PRESLCCW" : "PRESRCCW"));
                if (!isRadio1)
                {
                    AppendCommand(d.GetCommand("PRESRCCW"));
                }
            }
            else if (radio.SelectedPreset == "GV")
            {
                AppendCommand(BuildDigits(d, "1"));
                AppendCommand(d.GetCommand("PRESR"));
                AppendCommand(d.GetCommand("CLR"));
                AppendCommand(d.GetCommand("PRESRCCW"));
            }
            else
            {
                AppendCommand(BuildDigits(d, radio.SelectedPreset));
                AppendCommand(d.GetCommand(isRadio1 ? "PRESL" : "PRESR"));
                AppendCommand(d.GetCommand("CLR"));
            }

            if (radio.EnableGuard)
            {
                AppendCommand(StartCondition("IsRadioGuardEnabledDisabled", isRadio1 ? "1" : "2", "disabled"));
                AppendCommand(d.GetCommand("SHF"));
                AppendCommand(d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
                AppendCommand(EndCondition("IsRadioGuardEnabledDisabled"));
            }
            else
            {
                AppendCommand(StartCondition("IsRadioGuardEnabledDisabled", isRadio1 ? "1" : "2", "enabled"));
                AppendCommand(d.GetCommand("SHF"));
                AppendCommand(d.GetCommand(isRadio1 ? "GCML" : "GCMR"));
                AppendCommand(EndCondition("IsRadioGuardEnabledDisabled"));
            }
        }

        private void BuildRadioPresets(Device d, Radios.Radio radio)
        {
            for (int i = 0; i < radio.Frequencies.Length; i++)
            {
                var freq = radio.Frequencies[i];
                if (!string.IsNullOrEmpty(freq))
                {
                    var preset = (i + 1).ToString();
                    AppendCommand(BuildDigits(d, preset));
                    AppendCommand(d.GetCommand("PB1"));

                    InputFrequency(d, freq);
                    AppendCommand(d.GetCommand("PB10"));
                }
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
                AppendCommand(BuildDigits(d, parts[0]));
                AppendCommand(d.GetCommand("."));
                AppendCommand(BuildDigits(d, parts[1]));
            }
            else
            {
                freq = freq.Replace(".", "");
                AppendCommand(BuildDigits(d, freq));
            }
        }
    }
}
