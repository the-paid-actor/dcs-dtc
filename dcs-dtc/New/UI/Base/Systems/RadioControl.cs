using DTC.New.Presets.V2.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems;

public partial class RadioControl : UserControl
{
    private Radio radio;

    public RadioControl()
    {
        InitializeComponent();
    }

    public void Initialize(Radio radio, string name, bool enableGuardCheckbox, int numOfPresets)
    {
        this.radio = radio;
        lblName.Text = name;
        InitMode();
        InitFreq();
        InitPresetList(numOfPresets);
        if (enableGuardCheckbox)
        {
            InitGuardCheckbox();
        }
    }

    public event Action PresetChanged;
    public event Action<DTCRadioTextBox> ConfigureFreqTextBox;
    public event Action<DTCDropDown> ConfigurePresetList;

    private void InitMode()
    {
        cboMode.SelectedIndex = (int)radio.Mode - 1;
        cboMode.SelectedIndexChanged += (sender, args) =>
        {
            radio.Mode = (RadioMode)(cboMode.SelectedIndex + 1);
            PresetChanged?.Invoke();
        };
    }

    private void InitFreq()
    {
        ConfigureFreqTextBox?.Invoke(txtFreq);

        if (!string.IsNullOrEmpty(radio.SelectedFrequency))
        {
            txtFreq.Text = radio.SelectedFrequency;
        }
        txtFreq.LostFocus += (sender, args) =>
        {
            radio.SelectedFrequency = txtFreq.Text;
            PresetChanged?.Invoke();
        };
    }

    private void InitPresetList(int numOfPresets)
    {
        ConfigurePresetList?.Invoke(cboPreset);

        if (radio.SelectedPreset != null)
        {
            cboPreset.SelectedIndex = cboPreset.Items.IndexOf(radio.SelectedPreset);
        }

        cboPreset.SelectedIndexChanged += (sender, args) =>
        {
            radio.SelectedPreset = cboPreset.SelectedItem.ToString();
            PresetChanged?.Invoke();
        };

        MakeRadioControls(numOfPresets);
    }

    private void InitGuardCheckbox()
    {
        chkGuard.Visible = true;
        chkGuard.Checked = radio.EnableGuard;
        chkGuard.CheckedChanged += (sender, args) =>
        {
            radio.EnableGuard = chkGuard.Checked;
            PresetChanged?.Invoke();
        };
    }

    private void MakeRadioControls(int numOfPresets)
    {
        var padding = 5;
        var top = padding;
        var left = padding;
        var rowHeight = 25;
        var tabIndex = 0;

        for (int j = 1; j <= numOfPresets; j++)
        {
            var presetNumber = j;
            pnlPresets.Controls.Add(DTCLabel.Make(presetNumber.ToString(), left + padding, top));
            var radioPreset = radio.GetPreset(presetNumber);

            var txt = new DTCRadioTextBox();
            ConfigureFreqTextBox?.Invoke(txt);
            txt.Location = new Point(left + padding + 25 + padding, top);
            txt.Size = new Size(100, rowHeight);
            txt.Text = radioPreset?.Frequency ?? "";
            txt.TabIndex = tabIndex++;
            pnlPresets.Controls.Add(txt);

            var txtLabel = new DTCTextBox();
            txtLabel.Location = new Point(left + padding + 25 + padding + 100 + padding, top);
            txtLabel.Size = new Size(100, rowHeight);
            txtLabel.Text = radioPreset?.Name ?? "";
            txtLabel.Enabled = (radioPreset != null);
            txtLabel.TabIndex = tabIndex++;
            pnlPresets.Controls.Add(txtLabel);
            top += rowHeight + padding;

            txt.TextChanged += (sender, args) =>
            {
                txtLabel.Enabled = !string.IsNullOrEmpty(txt.Text);
            };

            txt.LostFocus += (sender, args) =>
            {
                var p = radio.GetPreset(presetNumber);

                if (string.IsNullOrEmpty(txt.Text))
                {
                    if (p != null)
                    {
                        radio.RemovePreset(p);
                        txtLabel.Text = "";
                        txtLabel.Enabled = false;
                    }
                }
                else
                {
                    if (p == null)
                    {
                        p = new RadioPreset(presetNumber);
                        radio.AddPreset(p);
                        txtLabel.Enabled = true;
                    }
                    p.Frequency = txt.Text;
                }

                PresetChanged?.Invoke();
            };

            txtLabel.LostFocus += (sender, args) =>
            {
                var p = radio.GetPreset(presetNumber);
                if (p != null)
                {
                    if (string.IsNullOrEmpty(txtLabel.Text))
                    {
                        p.Name = null;
                    }
                    else
                    {
                        p.Name = txtLabel.Text;
                    }
                    PresetChanged?.Invoke();
                }
            };
        }
    }
}
