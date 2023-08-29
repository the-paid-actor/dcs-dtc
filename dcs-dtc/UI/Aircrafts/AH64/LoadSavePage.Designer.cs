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
            this.optFile = new System.Windows.Forms.RadioButton();
            this.optClipboard = new System.Windows.Forms.RadioButton();
            this.grpLoad = new DTC.UI.Base.Controls.DTCGroupBox();
            this.btnLoadApply = new DTC.UI.Base.Controls.DTCButton();
            this.btnLoad = new DTC.UI.Base.Controls.DTCButton();
            this.chkLoadRadios = new System.Windows.Forms.CheckBox();
            this.chkLoadWaypoints = new System.Windows.Forms.CheckBox();
            this.grpSave = new DTC.UI.Base.Controls.DTCGroupBox();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.chkSaveRadios = new System.Windows.Forms.CheckBox();
            this.chkSaveWaypoints = new System.Windows.Forms.CheckBox();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.optXML = new System.Windows.Forms.RadioButton();
            this.grpLoad.SuspendLayout();
            this.grpSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // optFile
            // 
            this.optFile.AutoSize = true;
            this.optFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optFile.Location = new System.Drawing.Point(24, 23);
            this.optFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(68, 29);
            this.optFile.TabIndex = 8;
            this.optFile.TabStop = true;
            this.optFile.Text = "File";
            this.optFile.UseVisualStyleBackColor = true;
            this.optFile.CheckedChanged += new System.EventHandler(this.optFile_CheckedChanged);
            // 
            // optClipboard
            // 
            this.optClipboard.AutoSize = true;
            this.optClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optClipboard.Location = new System.Drawing.Point(129, 23);
            this.optClipboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optClipboard.Name = "optClipboard";
            this.optClipboard.Size = new System.Drawing.Size(121, 29);
            this.optClipboard.TabIndex = 9;
            this.optClipboard.TabStop = true;
            this.optClipboard.Text = "Clipboard";
            this.optClipboard.UseVisualStyleBackColor = true;
            this.optClipboard.CheckedChanged += new System.EventHandler(this.optClipboard_CheckedChanged);
            // 
            // grpLoad
            // 
            this.grpLoad.BorderColor = System.Drawing.Color.Black;
            this.grpLoad.BorderRadius = 5;
            this.grpLoad.BorderWidth = 2;
            this.grpLoad.Controls.Add(this.btnLoadApply);
            this.grpLoad.Controls.Add(this.btnLoad);
            this.grpLoad.Controls.Add(this.chkLoadRadios);
            this.grpLoad.Controls.Add(this.chkLoadWaypoints);
            this.grpLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpLoad.LabelIndent = 10;
            this.grpLoad.Location = new System.Drawing.Point(24, 83);
            this.grpLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLoad.Size = new System.Drawing.Size(308, 540);
            this.grpLoad.TabIndex = 10;
            this.grpLoad.TabStop = false;
            this.grpLoad.Text = "Load";
            this.grpLoad.Visible = false;
            // 
            // btnLoadApply
            // 
            this.btnLoadApply.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnLoadApply.Enabled = false;
            this.btnLoadApply.FlatAppearance.BorderSize = 0;
            this.btnLoadApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoadApply.Location = new System.Drawing.Point(27, 478);
            this.btnLoadApply.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadApply.Name = "btnLoadApply";
            this.btnLoadApply.Size = new System.Drawing.Size(180, 38);
            this.btnLoadApply.TabIndex = 0;
            this.btnLoadApply.Text = "Apply";
            this.btnLoadApply.UseVisualStyleBackColor = false;
            this.btnLoadApply.Click += new System.EventHandler(this.btnLoadApply_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoad.Location = new System.Drawing.Point(27, 46);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(180, 38);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkLoadRadios
            // 
            this.chkLoadRadios.Enabled = false;
            this.chkLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadRadios.Location = new System.Drawing.Point(24, 138);
            this.chkLoadRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadRadios.Name = "chkLoadRadios";
            this.chkLoadRadios.Size = new System.Drawing.Size(117, 38);
            this.chkLoadRadios.TabIndex = 0;
            this.chkLoadRadios.Text = "Radios";
            this.chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkLoadWaypoints
            // 
            this.chkLoadWaypoints.Enabled = false;
            this.chkLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadWaypoints.Location = new System.Drawing.Point(27, 92);
            this.chkLoadWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadWaypoints.Name = "chkLoadWaypoints";
            this.chkLoadWaypoints.Size = new System.Drawing.Size(153, 38);
            this.chkLoadWaypoints.TabIndex = 0;
            this.chkLoadWaypoints.Text = "Waypoints";
            this.chkLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // grpSave
            // 
            this.grpSave.BorderColor = System.Drawing.Color.Black;
            this.grpSave.BorderRadius = 5;
            this.grpSave.BorderWidth = 2;
            this.grpSave.Controls.Add(this.btnSave);
            this.grpSave.Controls.Add(this.chkSaveRadios);
            this.grpSave.Controls.Add(this.chkSaveWaypoints);
            this.grpSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpSave.LabelIndent = 10;
            this.grpSave.Location = new System.Drawing.Point(340, 83);
            this.grpSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSave.Name = "grpSave";
            this.grpSave.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSave.Size = new System.Drawing.Size(304, 540);
            this.grpSave.TabIndex = 8;
            this.grpSave.TabStop = false;
            this.grpSave.Text = "Save";
            this.grpSave.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(27, 478);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkSaveRadios
            // 
            this.chkSaveRadios.Checked = true;
            this.chkSaveRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveRadios.Location = new System.Drawing.Point(27, 138);
            this.chkSaveRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveRadios.Name = "chkSaveRadios";
            this.chkSaveRadios.Size = new System.Drawing.Size(117, 38);
            this.chkSaveRadios.TabIndex = 0;
            this.chkSaveRadios.Text = "Radios";
            this.chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveWaypoints
            // 
            this.chkSaveWaypoints.Checked = true;
            this.chkSaveWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveWaypoints.Location = new System.Drawing.Point(27, 92);
            this.chkSaveWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveWaypoints.Name = "chkSaveWaypoints";
            this.chkSaveWaypoints.Size = new System.Drawing.Size(153, 38);
            this.chkSaveWaypoints.TabIndex = 0;
            this.chkSaveWaypoints.Text = "Waypoints";
            this.chkSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.DefaultExt = "json";
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "dtc.json";
            // 
            // optXML
            // 
            this.optXML.AutoSize = true;
            this.optXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optXML.Location = new System.Drawing.Point(277, 23);
            this.optXML.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optXML.Name = "optXML";
            this.optXML.Size = new System.Drawing.Size(189, 29);
            this.optXML.TabIndex = 11;
            this.optXML.TabStop = true;
            this.optXML.Text = "CombatFlite XML";
            this.optXML.UseVisualStyleBackColor = true;
            this.optXML.CheckedChanged += new System.EventHandler(this.optXML_CheckedChanged);
            // 
            // LoadSavePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.optXML);
            this.Controls.Add(this.grpSave);
            this.Controls.Add(this.grpLoad);
            this.Controls.Add(this.optClipboard);
            this.Controls.Add(this.optFile);
            this.Name = "LoadSavePage";
            this.Size = new System.Drawing.Size(1509, 1568);
            this.grpLoad.ResumeLayout(false);
            this.grpSave.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optFile;
        private System.Windows.Forms.RadioButton optClipboard;
        private Base.Controls.DTCGroupBox grpLoad;
        private Base.Controls.DTCButton btnLoadApply;
        private Base.Controls.DTCButton btnLoad;
        private System.Windows.Forms.CheckBox chkLoadRadios;
        private System.Windows.Forms.CheckBox chkLoadWaypoints;
        private Base.Controls.DTCGroupBox grpSave;
        private Base.Controls.DTCButton btnSave;
        private System.Windows.Forms.CheckBox chkSaveRadios;
        private System.Windows.Forms.CheckBox chkSaveWaypoints;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.RadioButton optXML;
    }
}
