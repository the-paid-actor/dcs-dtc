using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    internal class RadiosPage : RadiosPageControl
    {
        public RadiosPage(F15EPage parent) : base(parent, parent.Configuration.Radios, nameof(parent.Configuration.Radios))
        {
        }

        protected override void ConfigurePresetList(DTCDropDown cbo, int radio)
        {
            var count = GetRadioPresetNumber(radio);
            for (var i = 1; i <= count; i++)
            {
                cbo.Items.Add(i.ToString());
            }
            cbo.Items.Add("G");
            if (radio == 2)
            {
                cbo.Items.Add("GV");
            }
        }

        protected override void ConfigureFreqTextBox(DTCRadioTextBox textBox, int radio)
        {
            if (radio == 2)
            {
                textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 30.000M, Max = 87.975M, Name = "FM" });
                textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 108.000M, Max = 173.975M, Name = "VHF" });
            }
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 225.000M, Max = 399.975M, Name = "UHF" });
            textBox.IntegerDigits = 3;
            textBox.FractionDigits = 3;
            textBox.FractionInterval = 0.005M;
        }

        protected override string GetRadioName(int radio)
        {
            return radio == 1 ? "MAIN" : "AUX";
        }

        protected override int GetRadioPresetNumber(int radio)
        {
            return radio == 1 ? 20 : 40;
        }

        protected override bool IsRadioGuardAvailable(int radio)
        {
            return true;
        }
    }
}
