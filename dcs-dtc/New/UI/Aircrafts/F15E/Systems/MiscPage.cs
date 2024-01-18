using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    public partial class MiscPage : AircraftSystemPage
    {
        private MiscSystem misc;

        public override string GetPageTitle()
        {
            return "Misc";
        }

        public MiscPage(F15EPage parent) : base(parent, nameof(parent.Configuration.Misc))
        {
            InitializeComponent();

            this.misc = parent.Configuration.Misc;

            var padding = 10;
            var rowHeight = 25;
            var colWidth = 150;
            var chkWidth = 15;

            var left = padding;
            var top = padding;

            //Bingo
            {
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, this.misc.BingoToBeUpdated, (chk) =>
                {
                    this.misc.BingoToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Bingo", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", this.misc.Bingo.ToString(), (txt) =>
                {
                    txt.Text = this.misc.SetBingo(txt.Text);
                    this.SavePreset();
                }));
            }

            //LAW
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, this.misc.CARAALOWToBeUpdated, (chk) =>
                {
                    this.misc.CARAALOWToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Low Alt Warning", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", this.misc.CARAALOW.ToString(), (txt) =>
                {
                    txt.Text = this.misc.SetCARAALOW(txt.Text);
                    this.SavePreset();
                }));
            }

            //TACAN
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, this.misc.TACANToBeUpdated, (chk) =>
                {
                    this.misc.TACANToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("TACAN", left, top, colWidth, rowHeight));

                //Channel
                {
                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, 50, rowHeight, "990", this.misc.TACANChannel.ToString(), (txt) =>
                    {
                        txt.Text = this.misc.SetTacanChannel(txt.Text);
                        this.SavePreset();
                    }));
                }

                //Band
                {
                    left += padding + 50;
                    var cboTacanBand = DTCDropDown.Make(left, top, 50);
                    cboTacanBand.Items.AddRange(new string[] { "X", "Y" });
                    cboTacanBand.SelectedIndex = (this.misc.TACANBand == TACANBands.X ? 0 : 1);
                    cboTacanBand.SelectedIndexChanged += (sender, args) =>
                    {
                        this.misc.TACANBand = (cboTacanBand.SelectedIndex == 0 ? TACANBands.X : TACANBands.Y);
                        this.SavePreset();
                    };
                    this.Controls.Add(cboTacanBand);
                }
            }

            //ILS
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, this.misc.ILSToBeUpdated, (chk) =>
                {
                    this.misc.ILSToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("ILS Frequency", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, @"000\.00", this.misc.GetILSFrequency(), (txt) =>
                {
                    txt.Text = this.misc.SetILSFrequency(txt.Text);
                    this.SavePreset();
                }));
            }
        }
    }
}
