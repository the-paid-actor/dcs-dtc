namespace DTC.UI.Aircrafts.AH64
{
    partial class LoadSavePage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            optFile = new RadioButton();
            optClipboard = new RadioButton();
            grpLoad = new Base.Controls.DTCGroupBox();
            btnLoadApply = new Base.Controls.DTCButton();
            btnLoad = new Base.Controls.DTCButton();
            chkLoadRadios = new CheckBox();
            chkLoadWaypoints = new CheckBox();
            grpSave = new Base.Controls.DTCGroupBox();
            btnSave = new Base.Controls.DTCButton();
            chkSaveRadios = new CheckBox();
            chkSaveWaypoints = new CheckBox();
            saveFileDlg = new SaveFileDialog();
            openFileDlg = new OpenFileDialog();
            optXML = new RadioButton();
            grpLoad.SuspendLayout();
            grpSave.SuspendLayout();
            SuspendLayout();
            // 
            // optFile
            // 
            optFile.AutoSize = true;
            optFile.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optFile.Location = new Point(24, 23);
            optFile.Margin = new Padding(4, 5, 4, 5);
            optFile.Name = "optFile";
            optFile.Size = new Size(48, 21);
            optFile.TabIndex = 8;
            optFile.TabStop = true;
            optFile.Text = "File";
            optFile.UseVisualStyleBackColor = true;
            optFile.CheckedChanged += optFile_CheckedChanged;
            // 
            // optClipboard
            // 
            optClipboard.AutoSize = true;
            optClipboard.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optClipboard.Location = new Point(129, 23);
            optClipboard.Margin = new Padding(4, 5, 4, 5);
            optClipboard.Name = "optClipboard";
            optClipboard.Size = new Size(86, 21);
            optClipboard.TabIndex = 9;
            optClipboard.TabStop = true;
            optClipboard.Text = "Clipboard";
            optClipboard.UseVisualStyleBackColor = true;
            optClipboard.CheckedChanged += optClipboard_CheckedChanged;
            // 
            // grpLoad
            // 
            grpLoad.BorderColor = Color.Black;
            grpLoad.BorderRadius = 5;
            grpLoad.BorderWidth = 2;
            grpLoad.Controls.Add(btnLoadApply);
            grpLoad.Controls.Add(btnLoad);
            grpLoad.Controls.Add(chkLoadRadios);
            grpLoad.Controls.Add(chkLoadWaypoints);
            grpLoad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpLoad.LabelIndent = 10;
            grpLoad.Location = new Point(24, 83);
            grpLoad.Margin = new Padding(4, 5, 4, 5);
            grpLoad.Name = "grpLoad";
            grpLoad.Padding = new Padding(4, 5, 4, 5);
            grpLoad.Size = new Size(212, 293);
            grpLoad.TabIndex = 10;
            grpLoad.TabStop = false;
            grpLoad.Text = "Load";
            grpLoad.Visible = false;
            // 
            // btnLoadApply
            // 
            btnLoadApply.BackColor = Color.DarkKhaki;
            btnLoadApply.Enabled = false;
            btnLoadApply.FlatAppearance.BorderSize = 0;
            btnLoadApply.FlatStyle = FlatStyle.Flat;
            btnLoadApply.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadApply.Location = new Point(11, 194);
            btnLoadApply.Margin = new Padding(4, 5, 4, 5);
            btnLoadApply.Name = "btnLoadApply";
            btnLoadApply.Size = new Size(180, 38);
            btnLoadApply.TabIndex = 0;
            btnLoadApply.Text = "Apply";
            btnLoadApply.UseVisualStyleBackColor = false;
            btnLoadApply.Click += btnLoadApply_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.DarkKhaki;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoad.Location = new Point(11, 44);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(180, 38);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // chkLoadRadios
            // 
            chkLoadRadios.Enabled = false;
            chkLoadRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadRadios.Location = new Point(27, 128);
            chkLoadRadios.Margin = new Padding(4, 5, 4, 5);
            chkLoadRadios.Name = "chkLoadRadios";
            chkLoadRadios.Size = new Size(117, 38);
            chkLoadRadios.TabIndex = 0;
            chkLoadRadios.Text = "Radios";
            chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkLoadWaypoints
            // 
            chkLoadWaypoints.Enabled = false;
            chkLoadWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadWaypoints.Location = new Point(27, 92);
            chkLoadWaypoints.Margin = new Padding(4, 5, 4, 5);
            chkLoadWaypoints.Name = "chkLoadWaypoints";
            chkLoadWaypoints.Size = new Size(153, 38);
            chkLoadWaypoints.TabIndex = 0;
            chkLoadWaypoints.Text = "Waypoints";
            chkLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // grpSave
            // 
            grpSave.BorderColor = Color.Black;
            grpSave.BorderRadius = 5;
            grpSave.BorderWidth = 2;
            grpSave.Controls.Add(btnSave);
            grpSave.Controls.Add(chkSaveRadios);
            grpSave.Controls.Add(chkSaveWaypoints);
            grpSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpSave.LabelIndent = 10;
            grpSave.Location = new Point(294, 83);
            grpSave.Margin = new Padding(4, 5, 4, 5);
            grpSave.Name = "grpSave";
            grpSave.Padding = new Padding(4, 5, 4, 5);
            grpSave.Size = new Size(216, 293);
            grpSave.TabIndex = 8;
            grpSave.TabStop = false;
            grpSave.Text = "Save";
            grpSave.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(17, 194);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkSaveRadios
            // 
            chkSaveRadios.Checked = true;
            chkSaveRadios.CheckState = CheckState.Checked;
            chkSaveRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveRadios.Location = new Point(27, 128);
            chkSaveRadios.Margin = new Padding(4, 5, 4, 5);
            chkSaveRadios.Name = "chkSaveRadios";
            chkSaveRadios.Size = new Size(117, 38);
            chkSaveRadios.TabIndex = 0;
            chkSaveRadios.Text = "Radios";
            chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveWaypoints
            // 
            chkSaveWaypoints.Checked = true;
            chkSaveWaypoints.CheckState = CheckState.Checked;
            chkSaveWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveWaypoints.Location = new Point(27, 92);
            chkSaveWaypoints.Margin = new Padding(4, 5, 4, 5);
            chkSaveWaypoints.Name = "chkSaveWaypoints";
            chkSaveWaypoints.Size = new Size(153, 38);
            chkSaveWaypoints.TabIndex = 0;
            chkSaveWaypoints.Text = "Waypoints";
            chkSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // saveFileDlg
            // 
            saveFileDlg.DefaultExt = "json";
            // 
            // openFileDlg
            // 
            openFileDlg.FileName = "dtc.json";
            // 
            // optXML
            // 
            optXML.AutoSize = true;
            optXML.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optXML.Location = new Point(277, 23);
            optXML.Margin = new Padding(4, 5, 4, 5);
            optXML.Name = "optXML";
            optXML.Size = new Size(132, 21);
            optXML.TabIndex = 11;
            optXML.TabStop = true;
            optXML.Text = "CombatFlite XML";
            optXML.UseVisualStyleBackColor = true;
            optXML.CheckedChanged += optXML_CheckedChanged;
            // 
            // LoadSavePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(optXML);
            Controls.Add(grpSave);
            Controls.Add(grpLoad);
            Controls.Add(optClipboard);
            Controls.Add(optFile);
            Name = "LoadSavePage";
            Size = new Size(1006, 1019);
            grpLoad.ResumeLayout(false);
            grpSave.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton optFile;
        private RadioButton optClipboard;
        private Base.Controls.DTCGroupBox grpLoad;
        private Base.Controls.DTCButton btnLoadApply;
        private Base.Controls.DTCButton btnLoad;
        private CheckBox chkLoadRadios;
        private CheckBox chkLoadWaypoints;
        private Base.Controls.DTCGroupBox grpSave;
        private Base.Controls.DTCButton btnSave;
        private CheckBox chkSaveRadios;
        private CheckBox chkSaveWaypoints;
        private SaveFileDialog saveFileDlg;
        private OpenFileDialog openFileDlg;
        private RadioButton optXML;
    }
}
