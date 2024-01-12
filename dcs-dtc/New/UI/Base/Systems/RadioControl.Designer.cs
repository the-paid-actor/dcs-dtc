namespace DTC.New.UI.Base.Systems
{
    partial class RadioControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSettings = new Panel();
            cboMode = new DTC.UI.Base.Controls.DTCDropDown();
            label6 = new Label();
            label2 = new Label();
            chkGuard = new CheckBox();
            lblName = new Label();
            cboPreset = new DTC.UI.Base.Controls.DTCDropDown();
            txtFreq = new DTC.UI.Base.Controls.DTCRadioTextBox();
            label1 = new Label();
            label5 = new Label();
            pnlPresets = new Panel();
            pnlSettings.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSettings
            // 
            pnlSettings.Controls.Add(cboMode);
            pnlSettings.Controls.Add(label6);
            pnlSettings.Controls.Add(label2);
            pnlSettings.Controls.Add(chkGuard);
            pnlSettings.Controls.Add(lblName);
            pnlSettings.Controls.Add(cboPreset);
            pnlSettings.Controls.Add(txtFreq);
            pnlSettings.Controls.Add(label1);
            pnlSettings.Controls.Add(label5);
            pnlSettings.Dock = DockStyle.Top;
            pnlSettings.Location = new Point(0, 0);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(417, 190);
            pnlSettings.TabIndex = 1;
            // 
            // cboMode
            // 
            cboMode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FlatStyle = FlatStyle.Flat;
            cboMode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMode.FormattingEnabled = true;
            cboMode.Items.AddRange(new object[] { "Frequency", "Preset" });
            cboMode.Location = new Point(131, 38);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(281, 24);
            cboMode.TabIndex = 0;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(5, 38);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(123, 25);
            label6.TabIndex = 37;
            label6.Text = "Mode:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(5, 157);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 36;
            label2.Text = "Presets";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkGuard
            // 
            chkGuard.Checked = true;
            chkGuard.CheckState = CheckState.Checked;
            chkGuard.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkGuard.Location = new Point(10, 128);
            chkGuard.Margin = new Padding(4);
            chkGuard.Name = "chkGuard";
            chkGuard.Size = new Size(175, 25);
            chkGuard.TabIndex = 3;
            chkGuard.Text = "Enable Guard";
            chkGuard.UseVisualStyleBackColor = true;
            chkGuard.Visible = false;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(5, 5);
            lblName.Margin = new Padding(0);
            lblName.Name = "lblName";
            lblName.Size = new Size(407, 25);
            lblName.TabIndex = 34;
            lblName.Text = "COMM1";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboPreset
            // 
            cboPreset.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPreset.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPreset.FlatStyle = FlatStyle.Flat;
            cboPreset.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboPreset.FormattingEnabled = true;
            cboPreset.Location = new Point(131, 97);
            cboPreset.Name = "cboPreset";
            cboPreset.Size = new Size(281, 24);
            cboPreset.TabIndex = 2;
            // 
            // txtFreq
            // 
            txtFreq.AllowNegative = false;
            txtFreq.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFreq.BackColor = SystemColors.Window;
            txtFreq.F16Radio = false;
            txtFreq.FractionDigits = 0;
            txtFreq.FractionInterval = new decimal(new int[] { 0, 0, 0, 0 });
            txtFreq.IntegerDigits = 0;
            txtFreq.Location = new Point(131, 67);
            txtFreq.Name = "txtFreq";
            txtFreq.Size = new Size(281, 25);
            txtFreq.TabIndex = 1;
            txtFreq.Value = null;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(5, 97);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(180, 25);
            label1.TabIndex = 15;
            label1.Text = "Selected Preset:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(5, 67);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(180, 25);
            label5.TabIndex = 15;
            label5.Text = "Selected Freq:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPresets
            // 
            pnlPresets.AutoScroll = true;
            pnlPresets.Dock = DockStyle.Fill;
            pnlPresets.Location = new Point(0, 190);
            pnlPresets.Name = "pnlPresets";
            pnlPresets.Size = new Size(417, 233);
            pnlPresets.TabIndex = 2;
            // 
            // RadioControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(pnlPresets);
            Controls.Add(pnlSettings);
            Name = "RadioControl";
            Size = new Size(417, 423);
            pnlSettings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSettings;
        private DTC.UI.Base.Controls.DTCDropDown cboMode;
        private Label label6;
        private Label label2;
        private CheckBox chkGuard;
        private Label lblName;
        private DTC.UI.Base.Controls.DTCDropDown cboPreset;
        private DTC.UI.Base.Controls.DTCRadioTextBox txtFreq;
        private Label label1;
        private Label label5;
        private Panel pnlPresets;
    }
}
