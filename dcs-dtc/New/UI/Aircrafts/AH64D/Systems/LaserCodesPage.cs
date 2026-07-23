using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

public class LaserCodesPage : AircraftSystemPage
{
    private readonly LaserCodesSystem _laserCodes;
  
    public LaserCodesPage(AH64DPage parent) : base(parent, nameof(parent.Configuration.LaserCodes))
    {
        _laserCodes = parent.Configuration.LaserCodes;

        var rowHeight = 28;
        var leftA = 15;
        var leftB = 190;
        var y = 15;
        var codeFields = new List<DTCTextBox>();

        for (var i = 0; i < LaserCodesSystem.Letters.Length; i++)
        {
            var letter = LaserCodesSystem.Letters[i];

            var left = i < 8 ? leftA : leftB;
            if (i == 8)
            {
                y = 15;
            }

            this.Controls.Add(DTCLabel.Make(letter.ToString(), left, y, 20, rowHeight));
            var codeField = DTCTextBox.Make(left + 30, y, 65, rowHeight, "0000", _laserCodes.GetCode(letter), (txt) =>
            {
                txt.Text = _laserCodes.SetCode(letter, txt.Text.Trim());
                this.SavePreset();
            });
            codeField.GotFocus += (sender, e) =>
            {
                codeField.Text = codeField.Text.Trim();
                codeField.SelectAll();
            };
            codeFields.Add(codeField);
            this.Controls.Add(codeField);

            y += rowHeight + 4;
        }

        for (var i = 0; i < codeFields.Count; i++)
        {
            var nextField = codeFields[(i + 1) % codeFields.Count];
            codeFields[i].KeyDown += (sender, e) =>
            {
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                nextField.Focus();
                nextField.SelectAll();
            };
        }
    }

    public override string GetPageTitle()
    {
        return "Laser Codes";
    }
}
