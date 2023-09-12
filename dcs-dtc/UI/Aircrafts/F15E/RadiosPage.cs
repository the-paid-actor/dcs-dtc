using DTC.Models.F15E.Radios;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F15E
{
    public partial class RadiosPage : AircraftSettingPage
    {
        public RadiosPage(AircraftPage parent, RadioSystem radioSystem) : base(parent)
        {
            InitializeComponent();

            if (radioSystem.Radio1 == null) radioSystem.Radio1 = new Radio();
            if (radioSystem.Radio2 == null) radioSystem.Radio2 = new Radio();

            ConfigureRadioField(txtRadio1Freq);
            ConfigureRadioField(txtRadio2Freq);

            cboRadio1Mode.SelectedIndex = (int)radioSystem.Radio1.Mode - 1;
            cboRadio1Mode.SelectedIndexChanged += (sender, args) =>
            {
                radioSystem.Radio1.Mode = (RadioMode)(cboRadio1Mode.SelectedIndex+1);
                _parent.DataChangedCallback();
            };

            cboRadio2Mode.SelectedIndex = (int)radioSystem.Radio2.Mode - 1;
            cboRadio2Mode.SelectedIndexChanged += (sender, args) =>
            {
                radioSystem.Radio2.Mode = (RadioMode)(cboRadio2Mode.SelectedIndex+1);
                _parent.DataChangedCallback();
            };

            txtRadio1Freq.Text = radioSystem.Radio1.SelectedFrequency;
            txtRadio1Freq.LostFocus += (sender, args) =>
            {
                radioSystem.Radio1.SelectedFrequency = txtRadio1Freq.Text;
                _parent.DataChangedCallback();
            };

            txtRadio2Freq.Text = radioSystem.Radio2.SelectedFrequency;
            txtRadio2Freq.LostFocus += (sender, args) =>
            {
                radioSystem.Radio2.SelectedFrequency = txtRadio2Freq.Text;
                _parent.DataChangedCallback();
            };

            cboRadio1Preset.SelectedItem = radioSystem.Radio1.SelectedPreset;
            cboRadio1Preset.SelectedIndexChanged += (sender, args) =>
            {
                radioSystem.Radio1.SelectedPreset = cboRadio1Preset.SelectedItem.ToString();
                _parent.DataChangedCallback();
            };

            cboRadio2Preset.SelectedItem = radioSystem.Radio2.SelectedPreset;
            cboRadio2Preset.SelectedIndexChanged += (sender, args) =>
            {
                radioSystem.Radio2.SelectedPreset = cboRadio2Preset.SelectedItem.ToString();
                _parent.DataChangedCallback();
            };

            chkRadio1Guard.Checked = radioSystem.Radio1.EnableGuard;
            chkRadio1Guard.CheckedChanged += (sender, args) =>
            {
                radioSystem.Radio1.EnableGuard = chkRadio1Guard.Checked;
                _parent.DataChangedCallback();
            };

            chkRadio2Guard.Checked = radioSystem.Radio2.EnableGuard;
            chkRadio2Guard.CheckedChanged += (sender, args) =>
            {
                radioSystem.Radio2.EnableGuard = chkRadio2Guard.Checked;
                _parent.DataChangedCallback();
            };

            MakeRadioPresets(radioSystem);
        }

        private void MakeRadioPresets(RadioSystem radioSystem)
        {
            var padding = 5;
            var top = padding;
            var left = padding;
            var rowHeight = 25;

            MakeRadioControls(padding, top, left, rowHeight, radioSystem.Radio1, pnlPresets1, 4);

            left = padding;

            MakeRadioControls(padding, top, left, rowHeight, radioSystem.Radio2, pnlPresets2, 27);
        }

        private void MakeRadioControls(int padding, int top, int left, int rowHeight, Radio radio, Control parent, int tabIndex)
        {
            for (int i = 0; i < 20; i++)
            {
                var idx = i;
                parent.Controls.Add(DTCLabel.Make((i + 1).ToString(), left + padding, top));
                var txt = MakeTextBox(left + padding + 25 + padding, top, 100, rowHeight, radio.Frequencies[idx], (textBox) =>
                {
                    if (textBox.Text == "")
                        radio.Frequencies[idx] = null;
                    else
                        radio.Frequencies[idx] = textBox.Text;

                    _parent.DataChangedCallback();
                });
                txt.TabIndex = tabIndex + i;
                parent.Controls.Add(txt);

                top += rowHeight + padding;
            }
        }

        private DTCRadioTextBox MakeTextBox(int left, int top, int width, int height, string value, DTCRadioTextBox.TextBoxChangedCallback callback)
        {
            var textBox = new DTCRadioTextBox();
            ConfigureRadioField(textBox);
            textBox.Left = left;
            textBox.Top = top;
            textBox.Width = width;
            textBox.Height = height;
            textBox.Text = value;
            textBox.LostFocus += (sender, args) =>
            {
                callback(textBox);
            };
            return textBox;
        }

        private static void ConfigureRadioField(DTCRadioTextBox textBox)
        {
            textBox.AllowedRanges.Add(new Base.Controls.DTCRadioTextBox.FrequencyBand { Min = 30.000M, Max = 87.995M, Name = "FM" });
            textBox.AllowedRanges.Add(new Base.Controls.DTCRadioTextBox.FrequencyBand { Min = 108.000M, Max = 173.975M, Name = "VHF" });
            textBox.AllowedRanges.Add(new Base.Controls.DTCRadioTextBox.FrequencyBand { Min = 225.000M, Max = 399.975M, Name = "UHF" });
            textBox.IntegerDigits = 3;
            textBox.FractionDigits = 3;
            textBox.FractionInterval = 0.005M;
        }

        public override string GetPageTitle()
        {
            return "Radios";
        }
    }
}
