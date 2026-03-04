using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

internal class Radios6Page : Radios6PageControl
{
    public Radios6Page(AH64DPage parent) : base(parent,
        parent.Configuration.Radios,
        nameof(parent.Configuration.Radios),
        new Radio6Conf { Type = RadioType.UHF, Name = "UHF" },
        new Radio6Conf { Type = RadioType.VHF, Name = "VHF" },
        new Radio6Conf { Type = RadioType.FM, Name = "FM1" },
        new Radio6Conf { Type = RadioType.FM, Name = "FM2" },
        new Radio6Conf { Type = RadioType.HF, Name = "HF1" },
        new Radio6Conf { Type = RadioType.HF, Name = "HF2", VisibleMode = false }
        )
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
    }

    protected override string GetRadioName(int radio)
    {
        return "";
    }

    protected override int GetRadioPresetNumber(int radio)
    {
        return 10;
    }

    private void InitializeComponent()
    {

    }

    protected override bool IsRadioGuardAvailable(int radio)
    {
        return false;
    }
}
