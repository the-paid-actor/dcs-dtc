using DTC.Models.FA18.Misc;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
    public partial class MiscPage : AircraftSettingPage
    {
        private MiscSystem _misc;

        public override string GetPageTitle()
        {
            return "Misc";
        }

        public MiscPage(AircraftPage parent, MiscSystem misc) : base(parent)
        {
            _misc = misc;
            InitializeComponent();

            var padding = 5;
            var rowHeight = 25;
            var colWidth = 150;
            var chkWidth = 15;

            var left = padding;
            var top = padding;

            var chkUpdateBingo = new DTCCheckBox();
            chkUpdateBingo.RelatedTo = "Bingo";
            chkUpdateBingo.Checked = _misc.BingoToBeUpdated;
            chkUpdateBingo.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateBingo, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("Bingo", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(MakeTextBox(left, top, colWidth, rowHeight, "99990", _misc.Bingo.ToString(), (txt) =>
            {
                txt.Text = _misc.SetBingo(txt.Text);
                _parent.DataChangedCallback();
            }));

            left = padding;
            top += padding + rowHeight;
            var chkUpdateBulleye = new DTCCheckBox();
            chkUpdateBulleye.RelatedTo = "Bulleye";
            chkUpdateBulleye.Checked = _misc.BullseyeToBeUpdated;
            chkUpdateBulleye.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateBulleye, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("Enable Bullseye", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            var txtBullseye = MakeTextBox(left + 25, top, 30, rowHeight, "00", _misc.BullseyeWP.ToString(), (txt) =>
            {
                txt.Text = _misc.SetBullseyeWP(txt.Text);
                _parent.DataChangedCallback();
            });
            txtBullseye.Enabled = _misc.EnableBullseye;
            this.Controls.Add(txtBullseye);

            var chkBullseye = new CheckBox();
            chkBullseye.Left = left;
            chkBullseye.Top = top;
            chkBullseye.AutoSize = false;
            chkBullseye.Height = rowHeight;
            chkBullseye.Width = 25;
            chkBullseye.Checked = _misc.EnableBullseye;
            chkBullseye.CheckedChanged += (sender, args) =>
            {
                _misc.EnableBullseye = chkBullseye.Checked;
                txtBullseye.Enabled = _misc.EnableBullseye;
            };
            this.Controls.Add(chkBullseye);

            left = padding;
            top += padding + rowHeight;
            var chkUpdateCARAALOW = new DTCCheckBox();
            chkUpdateCARAALOW.RelatedTo = "CARAALOW";
            chkUpdateCARAALOW.Checked = _misc.CARAALOWToBeUpdated;
            chkUpdateCARAALOW.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateCARAALOW, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("CARA ALOW", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(MakeTextBox(left, top, colWidth, rowHeight, "99990", _misc.CARAALOW.ToString(), (txt) =>
            {
                txt.Text = _misc.SetCARAALOW(txt.Text);
                _parent.DataChangedCallback();
            }));

            left = padding;
            top += padding + rowHeight;
            var chkUpdateMSLFloor = new DTCCheckBox();
            chkUpdateMSLFloor.RelatedTo = "MSLFloor";
            chkUpdateMSLFloor.Checked = _misc.MSLFloorToBeUpdated;
            chkUpdateMSLFloor.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateMSLFloor, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("MSL Floor", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(MakeTextBox(left, top, colWidth, rowHeight, "99990", _misc.MSLFloor.ToString(), (txt) =>
            {
                txt.Text = _misc.SetMSLFloor(txt.Text);
                _parent.DataChangedCallback();
            }));

            left = padding;
            top += padding + rowHeight;
            var chkUpdateTGP = new DTCCheckBox();
            chkUpdateTGP.RelatedTo = "TGP";
            chkUpdateTGP.Checked = _misc.TGPCodeToBeUpdated;
            chkUpdateTGP.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateTGP, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("TGP Code", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.AddRange(MakeTGPCodeControls(left, top, rowHeight, _misc.TGPCode.ToString(), (txt) =>
            {
                _misc.SetTGPCode(txt);
            }));

            left = padding;
            top += padding + rowHeight;
            var chkUpdateLST = new DTCCheckBox();
            chkUpdateLST.RelatedTo = "LST";
            chkUpdateLST.Checked = _misc.LSTCodeToBeUpdated;
            chkUpdateLST.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateLST, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("LST Code", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.AddRange(MakeTGPCodeControls(left, top, rowHeight, _misc.LSTCode.ToString(), (txt) =>
            {
                _misc.SetLSTCode(txt);
            }));

            left = padding;
            top += padding + rowHeight;
            var chkUpdateTACAN = new DTCCheckBox();
            chkUpdateTACAN.RelatedTo = "TACAN";
            chkUpdateTACAN.Checked = _misc.TACANToBeUpdated;
            chkUpdateTACAN.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateTACAN, left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("TACAN Channel", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(MakeTextBox(left, top, colWidth, rowHeight, "990", _misc.TACANChannel.ToString(), (txt) =>
            {
                txt.Text = _misc.SetTacanChannel(txt.Text);
                _parent.DataChangedCallback();
            }));

            left = 2*padding + chkWidth;
            top += padding + rowHeight;
            this.Controls.Add(DTCLabel.Make("TACAN Band", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            var cboTacanBand = DTCDropDown.Make(left, top, colWidth);
            cboTacanBand.Items.AddRange(new string[] { "X", "Y" });
            cboTacanBand.SelectedIndex = (_misc.TACANBand == TACANBands.X ? 0 : 1);
            cboTacanBand.SelectedIndexChanged += (sender, args) =>
            {
                _misc.TACANBand = (cboTacanBand.SelectedIndex == 0 ? TACANBands.X : TACANBands.Y);
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboTacanBand);

            left = padding;
            top += padding + rowHeight;
            var chkUpdateILS = new DTCCheckBox();
            chkUpdateILS.RelatedTo = "ILS";
            chkUpdateILS.Checked = _misc.ILSToBeUpdated;
            chkUpdateILS.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateILS, left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("ILS Frequency", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(MakeTextBox(left, top, colWidth, rowHeight, @"000\.00", _misc.GetILSFrequency(), (txt) =>
            {
                txt.Text = _misc.SetILSFrequency(txt.Text);
                _parent.DataChangedCallback();
            }));

            left = 2*padding + chkWidth;
            top += padding + rowHeight;

            this.Controls.Add(DTCLabel.Make("ILS Course", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(MakeTextBox(left, top, colWidth, rowHeight, @"990", _misc.ILSCourse.ToString(), (txt) =>
            {
                txt.Text = _misc.SetILSCourse(txt.Text);
                _parent.DataChangedCallback();
            }));
        }

        private delegate void TextBoxChangedCallback(DTCTextBox txt);

        private DTCTextBox MakeTextBox(int left, int top, int width, int height, string mask, string initialValue, TextBoxChangedCallback callback)
        {
            var txt = DTCTextBox.Make(left, top, width, height);
            txt.Mask = mask;
            txt.Text = initialValue;
            txt.HidePromptOnLeave = true;
            txt.AllowPromptAsInput = false;
            txt.PromptChar = ' ';
            txt.Tag = callback;
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            txt.LostFocus += (sender, args) =>
            {
                callback(txt);
            };
            return txt;
        }

        private delegate void TGPCodeChangedCallback(string value);

        private Control[] MakeTGPCodeControls(int left, int top, int height, string initialValue, TGPCodeChangedCallback callback)
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
        private void chk_OnChange(object sender, EventArgs e)
        {
            var chk = ((DTCCheckBox)sender);
            switch (chk.RelatedTo)
            {
                case "Bingo":
                    _misc.BingoToBeUpdated = chk.Checked;
                    break;
                case "Bulleye":
                    _misc.BullseyeToBeUpdated = chk.Checked;
                    break;
                case "CARAALOW":
                    _misc.CARAALOWToBeUpdated = chk.Checked;
                    break;
                case "MSLFloor":
                    _misc.MSLFloorToBeUpdated = chk.Checked;
                    break;
                case "TGP":
                    _misc.TGPCodeToBeUpdated = chk.Checked;
                    break;
                case "LST":
                    _misc.LSTCodeToBeUpdated = chk.Checked;
                    break;
                case "TACAN":
                    _misc.TACANToBeUpdated = chk.Checked;
                    break;
                case "ILS":
                    _misc.ILSToBeUpdated = chk.Checked;
                    break;
            }
            _parent.DataChangedCallback();
        }
    }
}
