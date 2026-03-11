using DTC.New.Presets.V2.Base.Systems;
using DTC.UI.Base.Controls;
using System.ComponentModel.DataAnnotations;

namespace DTC.New.UI.Base.Systems;

public partial class Radio6Control : UserControl
{
    private Radio6 radio;
    private Radio6Conf? R1;
    private Radio6Conf? R2;
    private Radio6Conf? R3;
    private Radio6Conf? R4;
    private Radio6Conf? R5;
    private Radio6Conf? R6;
    private const int MaxRadios = 6;


    public Radio6Control()
    {
        InitializeComponent();
    }

    public void Initialize(Radio6 radio, int numOfPresets, Radio6Conf? R1, Radio6Conf? R2, Radio6Conf? R3, Radio6Conf? R4, Radio6Conf? R5, Radio6Conf? R6)
    {
        this.radio = radio;
        this.R1 = R1;
        this.R2 = R2;
        this.R3 = R3;
        this.R4 = R4;
        this.R5 = R5;
        this.R6 = R6;
        InitPresetList(numOfPresets);
    }

    public event Action PresetChanged;
    public event Action<DTCRadioTextBox> ConfigureFreqTextBox;
    public event Action<DTCDropDown> ConfigurePresetList;

    private void InitPresetList(int numOfPresets)
    {
        MakeRadio6Controls(numOfPresets);
    }

    private Radio6Conf? GetRadio(int a) => a switch
    {
        1 => R1,
        2 => R2,
        3 => R3,
        4 => R4,
        5 => R5,
        6 => R6,
        _ => null
    };

    private void MakeRadio6Controls(int numOfPresets)
    {
        var configuredRadios = Enumerable.Range(1, MaxRadios)
           .Select(index => new { Index = index, Config = GetRadio(index) })
           .Where(x => x.Config is { Visible: true })
           .Select(x => new { x.Index, Config = x.Config! })
           .ToList();

        var padding = 5;
        var top = padding;

        var rowHeight = 25;
        var tabIndex = 0;

        var left = padding;


        //---------------
        var lblMode = DTCLabel.Make("Mode", left + padding, top + rowHeight + padding);
        pnlPresets.Controls.Add(lblMode);
        var lblMode2 = DTCLabel.Make("Selected Freq", left + padding, top + (rowHeight + padding) * 2);
        pnlPresets.Controls.Add(lblMode2);
        var lblMode3 = DTCLabel.Make("Selected Preset", left + padding, top + (rowHeight + padding) * 3 + 4);
        pnlPresets.Controls.Add(lblMode3);
        //---------------


        left = 140;
        foreach (var configuredRadio in configuredRadios)
        {

            var radioIndex = configuredRadio.Index;
            var r = configuredRadio.Config;
            if (r.VisibleMode == false)
            {
                continue;
            }

            var selectedMode = radio.GetSelectedMode(radioIndex);

            var txtA = new DTCDropDown();
            txtA.Width = 60;
            txtA.Items.Add("Freq");
            txtA.Items.Add("Preset");

            txtA.SelectedIndex = selectedMode.SelectedMode == RadioMode.Preset ? 1 : 0;
            txtA.Location = new Point(left + padding, top + rowHeight + padding);
            txtA.TabIndex = tabIndex++;
            pnlPresets.Controls.Add(txtA);

            var txtF = new DTCRadioTextBox(false);
            ConfigureFreqTextBox?.Invoke(txtF);
            txtF.Location = new Point(left + padding, top + (rowHeight + padding) * 2);
            ConfigureFrequencyInput(txtF, r);
            txtF.Text = selectedMode.SelectedFrequency;
            txtF.TabIndex = tabIndex++;

            pnlPresets.Controls.Add(txtF);


            var txtC = new DTCDropDown();
            txtC.Width = 60;
            txtC.Items.Add("");
            for (var x = 1; x <= numOfPresets; x++)
            {
                txtC.Items.Add(x.ToString());
            }

            var selectedPreset = selectedMode.SelectedPreset;

            if (txtC.Items.Contains(selectedPreset))
            {
                txtC.SelectedItem = selectedPreset;
            }
            else
            {
                txtC.SelectedIndex = 0;
            }

            txtC.Location = new Point(left + padding, top + (rowHeight + padding) * 3 + padding - 1);
            txtC.TabIndex = tabIndex++;
            pnlPresets.Controls.Add(txtC);

            txtA.SelectedIndexChanged += (sender, args) =>
            {
                var mode = txtA.SelectedIndex == 1 ? RadioMode.Preset : RadioMode.Frequency;
                radio.SetSelectedMode(radioIndex, mode);
                PresetChanged?.Invoke();
            };

            txtF.LostFocus += (sender, args) =>
            {
                radio.SetSelectedFrequency(radioIndex, txtF.Text);
                PresetChanged?.Invoke();
            };

            txtC.SelectedIndexChanged += (sender, args) =>
            {
                radio.SetSelectedPreset(radioIndex, txtC.SelectedItem?.ToString());
                PresetChanged?.Invoke();
            };

            left += 65;
        }


        left = 140;


        top += (rowHeight + padding) * 4;


        foreach (var configuredRadio in configuredRadios)
        {

            var r = configuredRadio.Config;

            var lbl = DTCLabel.Make(r.Name, left + padding, top);
            lbl.Width = 60;
            lbl.AutoSize = false;
            lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            pnlPresets.Controls.Add(lbl);
            left += 65;
        }

        top += rowHeight;

        for (int j = 1; j <= numOfPresets; j++)
        {
            left = padding;
            var presetNumber = j;
            pnlPresets.Controls.Add(DTCLabel.Make(presetNumber.ToString(), left + padding, top));
            var radioPreset = radio.GetPreset(j);

            var txtLabel = new DTCTextBox();
            txtLabel.Location = new Point(left + padding + 25 + padding, top);
            txtLabel.Size = new Size(100, rowHeight);
            txtLabel.Text = radioPreset?.Name ?? "";
            txtLabel.Enabled = (radioPreset != null);
            txtLabel.TabIndex = tabIndex++;
            pnlPresets.Controls.Add(txtLabel);

            left += 35;

            var txtFrequencies = new List<DTCRadioTextBox>();

            foreach (var configuredRadio in configuredRadios)
            {

                var r = configuredRadio.Config;

                var txt = new DTCRadioTextBox(false);
                ConfigureFreqTextBox?.Invoke(txt);
                txt.Location = new Point(left + padding + 25 + padding + 65 * configuredRadio.Index + padding, top);
                ConfigureFrequencyInput(txt, r);
                //txt.Text = radio.SelectedFrequencies?.ElementAtOrDefault(configuredRadio.Index - 1) ?? string.Empty;
                txt.Text = radioPreset?.Frequencies?.ElementAtOrDefault(configuredRadio.Index - 1) ?? string.Empty;
                txt.TabIndex = tabIndex++;

                pnlPresets.Controls.Add(txt);

                txtFrequencies.Add(txt);

                txt.TextChanged += (sender, args) =>
                {
                    txtLabel.Enabled = txtFrequencies.Any(f => !string.IsNullOrWhiteSpace(f.Text));
                };

                txt.LostFocus += (sender, args) =>
                {
                    SaveRadio6Preset(presetNumber, txtLabel, txtFrequencies);
                };
            }

            top += rowHeight + padding;

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


    private static void ConfigureFrequencyInput(DTCRadioTextBox textBox, Radio6Conf radioConfiguration)
    {
        textBox.IntegerDigits = radioConfiguration.IntegerDigits;
        textBox.FractionDigits = radioConfiguration.FractionDigits;
        textBox.FractionInterval = radioConfiguration.FractionInterval;


        if (radioConfiguration.IsUHF())
        {
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 225.000M, Max = 399.975M, Name = "UHF" });
        }
        else if (radioConfiguration.IsVHF())
        {
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 118.000M, Max = 151.975M, Name = "VHF" });
        }
        else if (radioConfiguration.IsFM())
        {
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 30.000M, Max = 87.975M, Name = "FM" });
        }
        else if (radioConfiguration.IsHF())
        {
            textBox.AllowedRanges.Add(new DTCRadioTextBox.FrequencyBand { Min = 3.000M, Max = 29.999M, Name = "HM" });
        }
    }

    private void SaveRadio6Preset(int presetNumber, DTCTextBox txtLabel, List<DTCRadioTextBox> txtFrequencies)
    {
        var values = txtFrequencies
            .Select(f => f.Text?.Trim() ?? string.Empty)
            .ToList();

        var hasAny = values.Any(v => !string.IsNullOrEmpty(v));
        var p = radio.GetPreset(presetNumber);

        if (!hasAny)
        {
            if (p != null)
            {
                radio.RemovePreset(p);
                txtLabel.Text = string.Empty;
                txtLabel.Enabled = false;
            }

            PresetChanged?.Invoke();
            return;
        }

        if (p == null)
        {
            p = new Radio6Preset(presetNumber);
            radio.AddPreset(p);
        }

        p.Frequencies = values;
        p.Name = string.IsNullOrWhiteSpace(txtLabel.Text) ? null : txtLabel.Text;
        txtLabel.Enabled = true;

        PresetChanged?.Invoke();
    }


}
