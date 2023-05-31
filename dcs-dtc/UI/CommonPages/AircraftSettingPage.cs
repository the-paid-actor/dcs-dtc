using DTC.UI.Base.Controls;
using System.Windows.Forms;

namespace DTC.UI.CommonPages
{
    public class AircraftSettingPage : UserControl
    {
        public delegate void DataChanged();

        protected readonly AircraftPage _parent;

        public AircraftSettingPage(AircraftPage parent) : base()
        {
            this._parent = parent;
        }

        public AircraftSettingPage()
        {

        }

        public virtual string GetPageTitle()
        {
            return "";
        }

        public delegate void TGPCodeChangedCallback(string value);

        public Control[] MakeTGPCodeControls(int left, int top, int height, string initialValue, TGPCodeChangedCallback callback)
        {
            var labelWidth = 30;
            var cboWidth = 40;
            var padding = 5;
            var lblFirstDigit = DTCLabel.Make("1", left, top, labelWidth, height);

            left += labelWidth + padding;

            var cboSecondDigit = DTCDropDown.Make(left, top, cboWidth);
            cboSecondDigit.Items.AddRange(new object[] { 5, 6, 7 });
            cboSecondDigit.SelectedItem = int.Parse(initialValue.Substring(1, 1));

            left += cboWidth + padding;

            var cboThirdDigit = DTCDropDown.Make(left, top, cboWidth);
            cboThirdDigit.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            cboThirdDigit.SelectedItem = int.Parse(initialValue.Substring(2, 1));

            left += cboWidth + padding;

            var cboFourthDigit = DTCDropDown.Make(left, top, cboWidth);
            cboFourthDigit.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            cboFourthDigit.SelectedItem = int.Parse(initialValue.Substring(3, 1));

            cboSecondDigit.SelectedIndexChanged += (sender, args) =>
            {
                callback("1" + (int)cboSecondDigit.SelectedItem + (int)cboThirdDigit.SelectedItem + (int)cboFourthDigit.SelectedItem);
            };
            cboThirdDigit.SelectedIndexChanged += (sender, args) =>
            {
                callback("1" + (int)cboSecondDigit.SelectedItem + (int)cboThirdDigit.SelectedItem + (int)cboFourthDigit.SelectedItem);
            };
            cboFourthDigit.SelectedIndexChanged += (sender, args) =>
            {
                callback("1" + (int)cboSecondDigit.SelectedItem + (int)cboThirdDigit.SelectedItem + (int)cboFourthDigit.SelectedItem);
            };

            return new Control[] { lblFirstDigit, cboSecondDigit, cboThirdDigit, cboFourthDigit };
        }
    }
}
