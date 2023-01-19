using DTC.Models.FA18.Misc;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System.Collections.Generic;

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

            //Bingo
            {
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BingoToBeUpdated, (chk) =>
                {
                    _misc.BingoToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Bingo", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.Bingo.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetBingo(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //Bullseye
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BullseyeToBeUpdated, (chk) =>
                {
                    _misc.BullseyeToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Enable Bullseye", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, 30, rowHeight, "00", _misc.BullseyeWP.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetBullseyeWP(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //Baro ALT
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BaroToBeUpdated, (chk) =>
                {
                    _misc.BaroToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Baro ALT", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.BaroWarn.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetBaro(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //Radar ALT
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.RadarToBeUpdated, (chk) =>
                {
                    _misc.RadarToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Radar ALT", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.RadarWarn.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetRadar(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //Tactical AP bank-limit
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BlimTac, (chk) =>
                {
                    _misc.BlimTac = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Tactical AP bank-limit", left, top, colWidth, rowHeight));
            }

            //TACAN
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight, _misc.TACANToBeUpdated, (chk) =>
                {
                    _misc.TACANToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                //Channel
                {
                    left += padding + chkWidth;
                    this.Controls.Add(DTCLabel.Make("TACAN Channel", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "990", _misc.TACANChannel.ToString(), (txt) =>
                    {
                        txt.Text = _misc.SetTacanChannel(txt.Text);
                        _parent.DataChangedCallback();
                    }));
                }

                //Band
                {
                    left = 2 * padding + chkWidth;
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
                }
            }

            //ILS
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.ILSToBeUpdated, (chk) =>
                {
                    _misc.ILSToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("ILS Channel", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                var items = new List<string>() { "" };
                for (var i = 1; i <= 20; i++)
                {
                    items.Add(i.ToString());
                }

                var cboIls = DTCDropDown.Make(left, top, colWidth);
                cboIls.Items.AddRange(items.ToArray());
                cboIls.SelectedItem = _misc.ILSChannel == 0 ? "" : _misc.ILSChannel.ToString();
                cboIls.SelectedIndexChanged += (sender, args) =>
                {
                    _misc.ILSChannel = cboIls.SelectedItem.ToString() != "" ? int.Parse(cboIls.SelectedItem.ToString()) : 0;
                    _parent.DataChangedCallback();
                };
                this.Controls.Add(cboIls);
            }

            //Map on HSI
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.HideMapOnHSI, (chk) =>
                {
                    _misc.HideMapOnHSI = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Hide MAP on HSI", left, top, colWidth, rowHeight));
                txt.Text = _misc.SetBingo(txt.Text);
                _parent.DataChangedCallback();
            }

            //UFC IFF
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.UFCIFFToBeUpdated, (chk) =>
                {
                    _misc.UFCIFFToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }))

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("UFC: IFF-ON", left, top, colWidth, rowHeight));
            }

            //UFC Datalink
            {
                left = padding;
                top += padding + rowHeight;
                var chkUpdateUFCDL = new DTCCheckBox();
                chkUpdateUFCDL.RelatedTo = "UFCIFF";
                chkUpdateUFCDL.Checked = _misc.UFCDLToBeUpdated;
                chkUpdateUFCDL.CheckedChanged += chk_OnChange;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.UFCDLToBeUpdated, (chk) =>
                {
                    _misc.UFCDLToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }))

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("UFC: Datalink L4/L16-ON", left, top, colWidth, rowHeight));
            }
            
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
                case "Baro":
                    _misc.BaroToBeUpdated = chk.Checked;
                    break;
                case "Radar":
                    _misc.RadarToBeUpdated = chk.Checked;
                    break;
                case "BLIM":
                    _misc.BlimTac = chk.Checked;
                    break;
                case "TACAN":
                    _misc.TACANToBeUpdated = chk.Checked;
                    break;
                case "UFCIFF":
                    _misc.UFCIFFToBeUpdated = chk.Checked;
                    break;
                case "UFCDL":
                    _misc.UFCDLToBeUpdated = chk.Checked;
                    break;
            }
        }
    }
}
