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

        for (var i = 0; i < LaserCodesSystem.Letters.Length; i++)
        {
            var letter = LaserCodesSystem.Letters[i];

            var left = i < 9 ? leftA : leftB;
            if (i == 9)
            {
                y = 15;
            }

            this.Controls.Add(DTCLabel.Make(letter.ToString(), left, y, 20, rowHeight));
            this.Controls.Add(DTCTextBox.Make(left + 30, y, 65, rowHeight, "0000", _laserCodes.GetCode(letter), (txt) =>
            {
                txt.Text = _laserCodes.SetCode(letter, txt.Text.Trim());
                this.SavePreset();
            }));

            y += rowHeight + 4;
        }
    }

    public override string GetPageTitle()
    {
        return "Laser Codes";
    }
}
