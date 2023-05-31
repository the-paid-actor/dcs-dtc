using DTC.Models.F16.Misc;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.F16
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

            //CARA ALOW
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.CARAALOWToBeUpdated, (chk) =>
                {
                    _misc.CARAALOWToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("CARA ALOW", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.CARAALOW.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetCARAALOW(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //MSL FLOOR
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.MSLFloorToBeUpdated, (chk) =>
                {
                    _misc.MSLFloorToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("MSL Floor", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.MSLFloor.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetMSLFloor(txt.Text);
                    _parent.DataChangedCallback();
                }));
            }

            //Laser Settings
            {
                left = padding;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.LaserSettingsToBeUpdated, (chk) =>
                {
                    _misc.LaserSettingsToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Laser Settings", left, top, colWidth, rowHeight));

                //TGP Code
                {
                    left = 2 * padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("TGP Code", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.AddRange(MakeTGPCodeControls(left, top, rowHeight, _misc.TGPCode.ToString(), (txt) =>
                    {
                        _misc.SetTGPCode(txt);
                        _parent.DataChangedCallback();
                    }));
                }

                //LST Code
                {
                    left = 2 * padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("LST Code", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.AddRange(MakeTGPCodeControls(left, top, rowHeight, _misc.LSTCode.ToString(), (txt) =>
                    {
                        _misc.SetLSTCode(txt);
                        _parent.DataChangedCallback();
                    }));
                }

                //Laser Start Time
                {
                    left = 2 * padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("Laser Start Time", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, 50, rowHeight, "990", _misc.LaserStartTime.ToString(), (txt) =>
                    {
                        _misc.SetLaserStartTime(txt.Text);
                        _parent.DataChangedCallback();
                    }));
                }
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
                this.Controls.Add(DTCLabel.Make("ILS", left, top, colWidth, rowHeight));

                //Frequency
                {
                    left = 2 * padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("Frequency", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, @"000\.00", _misc.GetILSFrequency(), (txt) =>
                    {
                        txt.Text = _misc.SetILSFrequency(txt.Text);
                        _parent.DataChangedCallback();
                    }));
                }

                //Course
                {
                    left = 2 * padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("Course", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, @"990", _misc.ILSCourse.ToString(), (txt) =>
                    {
                        txt.Text = _misc.SetILSCourse(txt.Text);
                        _parent.DataChangedCallback();
                    }));
                }
            }
        }
    }
}
