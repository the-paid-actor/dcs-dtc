using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using DTC.New.Presets.V2.Base.Systems;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    internal class RadiosPage : RadiosPageControl
    {
        public RadiosPage(F16Page parent) : base(parent, parent.Configuration.Radios, nameof(parent.Configuration.Radios))
        {
        }

        protected override void ConfigurePresetList(DTCDropDown cbo, int radio)
        {
            for (var i = 1; i <= 20; i++)
            {
                cbo.Items.Add(i.ToString());
            }
        }

        protected override void ConfigureFreqTextBox(DTCRadioTextBox textBox, int radio)
        {
            if (radio == 1)
            { 
                textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 225.00M, Max = 399.97M, Name = "UHF" });
                textBox.IntegerDigits = 3;
                textBox.FractionDigits = 2;
                textBox.F16Radio = true;
            }
            else
            { 
                textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 30.00M, Max = 87.97M, Name = "FM" });
                textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 108.00M, Max = 151.97M, Name = "VHF" });
                textBox.IntegerDigits = 3;
                textBox.FractionDigits = 2;
                textBox.F16Radio = true;
            }
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
            return radio == 1 ? true : false;
        }
    }
}
