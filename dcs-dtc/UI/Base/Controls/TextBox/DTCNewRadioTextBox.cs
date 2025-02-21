
using System.Text.RegularExpressions;

namespace DTC.UI.Base.Controls.TextBox;

internal class DTCNewRadioTextBox : DTCNewTextBox
{
    private Label freqLabel;


    public DTCNewRadioTextBox()
    {
    }

    protected override HorizontalAlignment GetTextAlignment()
    {
        return HorizontalAlignment.Right;
    }

    protected override Regex GetAllowedChars()
    {
        return new Regex("[0-9.]");
    }

    protected override int GetLabelWidth()
    {
        return 36;
    }

    protected override Label GetLabel()
    {
        if (freqLabel == null)
        {
            this.freqLabel = new Label();
            this.freqLabel.Text = "UHF";
            this.freqLabel.Click += (sender, args) =>
            {
                this.Focus();
            };
        }
        return freqLabel;
    }
}
