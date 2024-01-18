using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    internal class RadiosPage : RadiosPageControl
    {
        public RadiosPage(FA18Page parent) : base(parent, parent.Configuration.Radios, nameof(parent.Configuration.Radios))
        {
        }

        protected override void ConfigurePresetList(DTCDropDown cbo, int radio)
        {
            for (var i = 1; i <= 20; i++)
            {
                cbo.Items.Add(i.ToString());
            }
            cbo.Items.Add("G");
        }

        protected override void ConfigureFreqTextBox(DTCRadioTextBox txt, int radio)
        {
            txt.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 30.000M, Max = 87.995M, Name = "FM" });
            txt.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 108.000M, Max = 173.975M, Name = "VHF" });
            txt.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 225.000M, Max = 399.975M, Name = "UHF" });
            txt.IntegerDigits = 3;
            txt.FractionDigits = 3;
            txt.FractionInterval = 0.005M;
        }

        protected override string GetRadioName(int radio)
        {
            return radio == 1 ? "COMM1" : "COMM2";
        }

        protected override int GetRadioPresetNumber(int radio)
        {
            return 20;
        }

        protected override bool IsRadioGuardAvailable(int radio)
        {
            return true;
        }
    }
}
