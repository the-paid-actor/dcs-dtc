using DTC.Models.F15E.Misc;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.F15E
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

            //LAW
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.CARAALOWToBeUpdated, (chk) =>
                {
                    _misc.CARAALOWToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Low Alt Warning", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.CARAALOW.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetCARAALOW(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //TACAN
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.TACANToBeUpdated, (chk) =>
                {
                    _misc.TACANToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("TACAN", left, top, colWidth, rowHeight));

                //Channel
                {
                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, 50, rowHeight, "990", _misc.TACANChannel.ToString(), (txt) =>
                    {
                        txt.Text = _misc.SetTacanChannel(txt.Text);
                        _parent.DataChangedCallback();
                    }));
                }

                //Band
                {
                    left += padding + 50;
                    var cboTacanBand = DTCDropDown.Make(left, top, 50);
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
                this.Controls.Add(DTCLabel.Make("ILS Frequency", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, @"000\.00", _misc.GetILSFrequency(), (txt) =>
                {
                    txt.Text = _misc.SetILSFrequency(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }
        }
    }
}
