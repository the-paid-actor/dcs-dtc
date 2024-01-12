using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using System.Drawing.Printing;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class MiscPage : AircraftSystemPage
    {
        private MiscSystem _misc;

        public override string GetPageTitle()
        {
            return "Misc";
        }

        public MiscPage(FA18Page parent, MiscSystem misc) : base(parent)
        {
            _misc = misc;
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
                left = margin;
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

            //Baro ALT
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BaroToBeUpdated, (chk) =>
                {
                    _misc.BaroToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Baro ALT", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.BaroWarn.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetBaro(txt.Text);
                    this.SavePreset();
                }));
            }

            //Radar ALT
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.RadarToBeUpdated, (chk) =>
                {
                    _misc.RadarToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Radar ALT", left, top, colWidth, rowHeight));

                left += padding + colWidth;
                this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "99990", _misc.RadarWarn.ToString(), (txt) =>
                {
                    txt.Text = _misc.SetRadar(txt.Text);
                    this.SavePreset();
                }));
            }

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
            }

            //Tactical AP bank-limit
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.BlimTac, (chk) =>
                {
                    _misc.BlimTac = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Tactical AP bank-limit", left, top, colWidth, rowHeight));
            }

            //TACAN
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight, _misc.TACANToBeUpdated, (chk) =>
                {
                    _misc.TACANToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                //Channel
                {
                    left = margin + padding + chkWidth;
                    this.Controls.Add(DTCLabel.Make("TACAN Channel", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    this.Controls.Add(DTCTextBox.Make(left, top, colWidth, rowHeight, "990", _misc.TACANChannel.ToString(), (txt) =>
                    {
                        txt.Text = _misc.SetTacanChannel(txt.Text);
                        this.SavePreset();
                    }));
                }

                //Band
                {
                    left = margin + padding + chkWidth;
                    top += padding + rowHeight;
                    this.Controls.Add(DTCLabel.Make("TACAN Band", left, top, colWidth, rowHeight));

                    left += padding + colWidth;
                    var cboTacanBand = DTCDropDown.Make(left, top, colWidth);
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
                    this.SavePreset();
                };
                this.Controls.Add(cboIls);
            }

            //Map on HSI
            {
                left = margin;
                top += padding + rowHeight;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, _misc.HideMapOnHSI, (chk) =>
                {
                    _misc.HideMapOnHSI = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make("Hide MAP on HSI", left, top, colWidth, rowHeight));
            }
        }
    }
}
