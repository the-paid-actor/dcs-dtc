using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.UI.Aircrafts.A10.Systems
{
    internal class RadiosPage : RadiosPageControl
    {
        public RadiosPage(A10Page parent) : base(parent, parent.Configuration.Radios, nameof(parent.Configuration.Radios))
        {
        }

        protected override void ConfigurePresetList(DTCDropDown cbo, int radio)
        {
            for (var i = 1; i <= GetRadioPresetNumber(0); i++)
            {
                cbo.Items.Add(i.ToString());
            }
        }

        protected override void ConfigureFreqTextBox(DTCRadioTextBox txt, int radio)
        {
            txt.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 225.000M, Max = 399.975M, Name = "UHF" });
            txt.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 108.000M, Max = 173.975M, Name = "VHF" });
            txt.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 30.000M, Max = 87.975M, Name = "FM" });
            txt.IntegerDigits = 3;
            txt.FractionDigits = 3;
            txt.FractionInterval = 0.025M;
        }

        protected override string GetRadioName(int radio)
        {
            return "UHF/VHF/FM";
        }

        protected override int GetRadioPresetNumber(int radio)
        {
            return 30;
        }

        protected override bool IsRadioGuardAvailable(int radio)
        {
            return false;
        }

        protected override bool IsRadioVisible(int radio)
        {
            return radio == 1;
        }
    }
}
