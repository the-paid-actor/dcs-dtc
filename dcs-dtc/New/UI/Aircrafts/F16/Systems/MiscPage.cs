using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class MiscPage : AircraftSystemPage
    {
        private MiscSystem _misc;

        public override string GetPageTitle()
        {
            return "Misc";
        }

        public MiscPage(F16Page parent) : base(parent, nameof(parent.Configuration.Misc))
        {
            _misc = parent.Configuration.Misc;
            InitializeComponent();

            var margin = 15;
            var padding = 5;
            var rowHeight = 25;
            var colWidth = 150;
            var chkWidth = 15;

            var left = margin;
            var top = margin;

            //Bingo
            {
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BingoToBeUpdated, (chk) =>
                {
                    _misc.BingoToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Bingo", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.Bingo.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetBingo(txt.Text);
                    this.SavePreset();
                }));
            }

            //Bullseye
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BullseyeToBeUpdated, (chk) =>
                {
                    _misc.BullseyeToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Enable Bullseye", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, 30, rowHeight, "00", _misc.BullseyeWP.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetBullseyeWP(txt.Text);
                    this.SavePreset();
                }));
            }

            //CARA ALOW
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.CARAALOWToBeUpdated, (chk) =>
                {
                    _misc.CARAALOWToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("CARA ALOW", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.CARAALOW.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetCARAALOW(txt.Text);
                    this.SavePreset();
                }));
            }

            //MSL FLOOR
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.MSLFloorToBeUpdated, (chk) =>
                {
                    _misc.MSLFloorToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("MSL Floor", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.MSLFloor.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetMSLFloor(txt.Text);
                    this.SavePreset();
                }));
            }

            //Laser Settings
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.LaserSettingsToBeUpdated, (chk) =>
                {
                    _misc.LaserSettingsToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Laser Settings", left, top, colWidth, rowHeight));

                //TGP Code
                {
                    left = margin + padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("TGP Code", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.AddRange(MakeTGPCodeControls(left, top, rowHeight, _misc.TGPCode.ToString(), (txt) =>
                    {
                        _misc.SetTGPCode(txt);
                        this.SavePreset();
                    }));
                }

                //LST Code
                {
                    left = margin + padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("LST Code", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.AddRange(MakeTGPCodeControls(left, top, rowHeight, _misc.LSTCode.ToString(), (txt) =>
                    {
                        _misc.SetLSTCode(txt);
                        this.SavePreset();
                    }));
                }

                //Laser Start Time
                {
                    left = margin + padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("Laser Start Time", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, 50, rowHeight, "990", _misc.LaserStartTime.ToString(), (txt) =>
                    {
                        _misc.SetLaserStartTime(txt.Text);
                        this.SavePreset();
                    }));
                }
            }

            //TACAN
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.TACANToBeUpdated, (chk) =>
                {
                    _misc.TACANToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("TACAN", left, top, colWidth, rowHeight));

                //Channel
                {
                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, 50, rowHeight, "990", _misc.TACANChannel.ToString(), (txt) =>
                    {
                        txt.Text = _misc.SetTacanChannel(txt.Text);
                        this.SavePreset();
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
                        this.SavePreset();
                    };
                    this.Controls.Add(cboTacanBand);
                }
            }

            //ILS
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.ILSToBeUpdated, (chk) =>
                {
                    _misc.ILSToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("ILS", left, top, colWidth, rowHeight));

                //Frequency
                {
                    left = margin + padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("Frequency", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, @"000\.00", _misc.GetILSFrequency(), (txt) =>
                    {
                        txt.Text = _misc.SetILSFrequency(txt.Text);
                        this.SavePreset();
                    }));
                }

                //Course
                {
                    left = margin + padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("Course", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, @"990", _misc.ILSCourse.ToString(), (txt) =>
                    {
                        txt.Text = _misc.SetILSCourse(txt.Text);
                        this.SavePreset();
                    }));
                }
            }
        }
    }
}
