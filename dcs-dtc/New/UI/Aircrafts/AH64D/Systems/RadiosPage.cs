using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

internal class RadiosPage : RadiosPageControl
{
    public RadiosPage(AH64DPage parent) : base(parent, parent.Configuration.Radios, nameof(parent.Configuration.Radios))
    {
    }

    protected override void ConfigurePresetList(DTCDropDown cbo, int radio)
    {
        for (var i = 1; i <= GetRadioPresetNumber(0); i++)
        {
            cbo.Items.Add(i.ToString());
        }
    }

    protected override void ConfigureFreqTextBox(DTCRadioTextBox textBox, int radio)
    {
        if (radio == 1)
        {
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 118.000M, Max = 151.975M, Name = "VHF" });
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 225.000M, Max = 399.975M, Name = "UHF" });
        }
        else
        {
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 30.000M, Max = 87.975M, Name = "FM" });
        }
        textBox.IntegerDigits = 3;
        textBox.FractionDigits = 3;
        textBox.FractionInterval = 0.005M;
    }

    protected override string GetRadioName(int radio)
    {
        return radio == 1 ? "V/UHF" : "FM";
    }

    protected override int GetRadioPresetNumber(int radio)
    {
        return 10;
    }

    protected override bool IsRadioGuardAvailable(int radio)
    {
        return false;
    }
}
