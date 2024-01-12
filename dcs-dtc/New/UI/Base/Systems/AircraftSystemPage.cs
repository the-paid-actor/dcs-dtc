using DTC.New.UI.Base.Pages;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    public class AircraftSystemPage : UserControl
    {
        public class Divider : AircraftSystemPage
        {
            public override bool IsDivider()
            {
                return true;
            }
        }

        public delegate void DataChanged();

        protected readonly AircraftPage parent;

        public AircraftSystemPage()
        {
        }

        public AircraftSystemPage(AircraftPage parent) : base()
        {
            this.parent = parent;
        }

        public virtual string GetPageTitle()
        {
            return "";
        }

        public virtual bool IsDivider()
        {
            return false;
        }

        protected void SavePreset()
        {
            this.parent.SavePreset();
        }

        public delegate void TGPCodeChangedCallback(string value);

        public Control[] MakeTGPCodeControls(int left, int top, int height, string initialValue, TGPCodeChangedCallback callback)
        {
            var cboWidth = 40;
            var padding = 5;

            var cboFirstDigit = DTCDropDown.Make(left, top, cboWidth);
            cboFirstDigit.Items.AddRange(new object[] { 1, 2 });
            cboFirstDigit.SelectedItem = int.Parse(initialValue.Substring(0, 1));

            left += cboWidth + padding;

            var cboSecondDigit = DTCDropDown.Make(left, top, cboWidth);
            cboSecondDigit.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            cboSecondDigit.SelectedItem = int.Parse(initialValue.Substring(1, 1));

            left += cboWidth + padding;

            var cboThirdDigit = DTCDropDown.Make(left, top, cboWidth);
            cboThirdDigit.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            cboThirdDigit.SelectedItem = int.Parse(initialValue.Substring(2, 1));

            left += cboWidth + padding;

            var cboFourthDigit = DTCDropDown.Make(left, top, cboWidth);
            cboFourthDigit.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            cboFourthDigit.SelectedItem = int.Parse(initialValue.Substring(3, 1));

            void changed(object sender, EventArgs args)
            {
                callback(cboFirstDigit.SelectedItem.ToString() + 
                    cboSecondDigit.SelectedItem.ToString() + 
                    cboThirdDigit.SelectedItem.ToString() + 
                    cboFourthDigit.SelectedItem.ToString());
            }

            cboFirstDigit.SelectedIndexChanged += changed;
            cboSecondDigit.SelectedIndexChanged += changed;
            cboThirdDigit.SelectedIndexChanged += changed;
            cboFourthDigit.SelectedIndexChanged += changed;

            return new Control[] { cboFirstDigit, cboSecondDigit, cboThirdDigit, cboFourthDigit };
        }

        public virtual void Shown()
        {
        }
    }
}
