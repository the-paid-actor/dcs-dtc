
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.FA18
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.optFile = new System.Windows.Forms.RadioButton();
            this.optClipboard = new System.Windows.Forms.RadioButton();
            this.grpLoad = new DTC.UI.Controls.DTCGroupBox();
            this.chkLoadMisc = new System.Windows.Forms.CheckBox();
            this.chkLoadPP = new System.Windows.Forms.CheckBox();
            this.chkLoadSeq = new System.Windows.Forms.CheckBox();
            this.btnLoadApply = new DTC.UI.Base.Controls.DTCButton();
            this.btnLoad = new DTC.UI.Base.Controls.DTCButton();
            this.chkLoadRadios = new System.Windows.Forms.CheckBox();
            this.chkLoadCMS = new System.Windows.Forms.CheckBox();
            this.chkLoadWaypoints = new System.Windows.Forms.CheckBox();
            this.grpSave = new DTC.UI.Controls.DTCGroupBox();
            this.chkSaveMisc = new System.Windows.Forms.CheckBox();
            this.chkSavePP = new System.Windows.Forms.CheckBox();
            this.chkSaveSeq = new System.Windows.Forms.CheckBox();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.chkSaveRadios = new System.Windows.Forms.CheckBox();
            this.chkSaveCMS = new System.Windows.Forms.CheckBox();
            this.chkSaveWaypoints = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.grpLoad.SuspendLayout();
            this.grpSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDlg
            // 
            this.openFileDlg.FileName = "dtc.json";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.DefaultExt = "json";
            // 
            // optFile
            // 
            this.optFile.AutoSize = true;
            this.optFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optFile.Location = new System.Drawing.Point(16, 18);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(48, 21);
            this.optFile.TabIndex = 7;
            this.optFile.TabStop = true;
            this.optFile.Text = "File";
            this.optFile.UseVisualStyleBackColor = true;
            this.optFile.CheckedChanged += new System.EventHandler(this.optFile_CheckedChanged);
            // 
            // optClipboard
            // 
            this.optClipboard.AutoSize = true;
            this.optClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optClipboard.Location = new System.Drawing.Point(74, 18);
            this.optClipboard.Name = "optClipboard";
            this.optClipboard.Size = new System.Drawing.Size(86, 21);
            this.optClipboard.TabIndex = 7;
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
            this.grpLoad.Controls.Add(this.chkLoadMisc);
            this.grpLoad.Controls.Add(this.chkLoadPP);
            this.grpLoad.Controls.Add(this.chkLoadSeq);
            this.grpLoad.Controls.Add(this.btnLoadApply);
            this.grpLoad.Controls.Add(this.btnLoad);
            this.grpLoad.Controls.Add(this.chkLoadRadios);
            this.grpLoad.Controls.Add(this.chkLoadCMS);
            this.grpLoad.Controls.Add(this.chkLoadWaypoints);
            this.grpLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpLoad.LabelIndent = 10;
            this.grpLoad.Location = new System.Drawing.Point(16, 50);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Size = new System.Drawing.Size(205, 314);
            this.grpLoad.TabIndex = 6;
            this.grpLoad.TabStop = false;
            this.grpLoad.Text = "Load";
            this.grpLoad.Visible = false;
            // 
            // chkLoadMisc
            // 
            this.chkLoadMisc.Enabled = false;
            this.chkLoadMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadMisc.Location = new System.Drawing.Point(18, 150);
            this.chkLoadMisc.Name = "chkLoadMisc";
            this.chkLoadMisc.Size = new System.Drawing.Size(60, 25);
            this.chkLoadMisc.TabIndex = 1;
            this.chkLoadMisc.Text = "Misc";
            this.chkLoadMisc.UseVisualStyleBackColor = true;
            // 
            // chkLoadPP
            // 
            this.chkLoadPP.Enabled = false;
            this.chkLoadPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadPP.Location = new System.Drawing.Point(18, 180);
            this.chkLoadPP.Name = "chkLoadPP";
            this.chkLoadPP.Size = new System.Drawing.Size(142, 25);
            this.chkLoadPP.TabIndex = 1;
            this.chkLoadPP.Text = "Pre Planned";
            this.chkLoadPP.UseVisualStyleBackColor = true;
            // 
            // chkLoadSeq
            // 
            this.chkLoadSeq.Enabled = false;
            this.chkLoadSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadSeq.Location = new System.Drawing.Point(18, 210);
            this.chkLoadSeq.Name = "chkLoadSeq";
            this.chkLoadSeq.Size = new System.Drawing.Size(120, 25);
            this.chkLoadSeq.TabIndex = 1;
            this.chkLoadSeq.Text = "Sequences";
            this.chkLoadSeq.UseVisualStyleBackColor = true;
            // 
            // btnLoadApply
            // 
            this.btnLoadApply.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnLoadApply.Enabled = false;
            this.btnLoadApply.FlatAppearance.BorderSize = 0;
            this.btnLoadApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLoadApply.Location = new System.Drawing.Point(18, 270);
            this.btnLoadApply.Name = "btnLoadApply";
            this.btnLoadApply.Size = new System.Drawing.Size(120, 25);
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
            this.btnLoad.Location = new System.Drawing.Point(18, 30);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 25);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkLoadRadios
            // 
            this.chkLoadRadios.Enabled = false;
            this.chkLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadRadios.Location = new System.Drawing.Point(18, 120);
            this.chkLoadRadios.Name = "chkLoadRadios";
            this.chkLoadRadios.Size = new System.Drawing.Size(78, 25);
            this.chkLoadRadios.TabIndex = 0;
            this.chkLoadRadios.Text = "Radios";
            this.chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkLoadCMS
            // 
            this.chkLoadCMS.Enabled = false;
            this.chkLoadCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadCMS.Location = new System.Drawing.Point(18, 90);
            this.chkLoadCMS.Name = "chkLoadCMS";
            this.chkLoadCMS.Size = new System.Drawing.Size(63, 25);
            this.chkLoadCMS.TabIndex = 0;
            this.chkLoadCMS.Text = "CMS";
            this.chkLoadCMS.UseVisualStyleBackColor = true;
            // 
            // chkLoadWaypoints
            // 
            this.chkLoadWaypoints.Enabled = false;
            this.chkLoadWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadWaypoints.Location = new System.Drawing.Point(18, 60);
            this.chkLoadWaypoints.Name = "chkLoadWaypoints";
            this.chkLoadWaypoints.Size = new System.Drawing.Size(102, 25);
            this.chkLoadWaypoints.TabIndex = 0;
            this.chkLoadWaypoints.Text = "Waypoints";
            this.chkLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // grpSave
            // 
            this.grpSave.BorderColor = System.Drawing.Color.Black;
            this.grpSave.BorderRadius = 5;
            this.grpSave.BorderWidth = 2;
            this.grpSave.Controls.Add(this.chkSaveMisc);
            this.grpSave.Controls.Add(this.chkSavePP);
            this.grpSave.Controls.Add(this.chkSaveSeq);
            this.grpSave.Controls.Add(this.btnSave);
            this.grpSave.Controls.Add(this.chkSaveRadios);
            this.grpSave.Controls.Add(this.chkSaveCMS);
            this.grpSave.Controls.Add(this.chkSaveWaypoints);
            this.grpSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpSave.LabelIndent = 10;
            this.grpSave.Location = new System.Drawing.Point(243, 50);
            this.grpSave.Name = "grpSave";
            this.grpSave.Size = new System.Drawing.Size(203, 314);
            this.grpSave.TabIndex = 7;
            this.grpSave.TabStop = false;
            this.grpSave.Text = "Save";
            this.grpSave.Visible = false;
            // 
            // chkSaveMisc
            // 
            this.chkSaveMisc.Checked = true;
            this.chkSaveMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveMisc.Location = new System.Drawing.Point(18, 150);
            this.chkSaveMisc.Name = "chkSaveMisc";
            this.chkSaveMisc.Size = new System.Drawing.Size(60, 25);
            this.chkSaveMisc.TabIndex = 1;
            this.chkSaveMisc.Text = "Misc";
            this.chkSaveMisc.UseVisualStyleBackColor = true;
            // 
            // chkSavePP
            // 
            this.chkSavePP.Checked = true;
            this.chkSavePP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSavePP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSavePP.Location = new System.Drawing.Point(18, 180);
            this.chkSavePP.Name = "chkSavePP";
            this.chkSavePP.Size = new System.Drawing.Size(120, 25);
            this.chkSavePP.TabIndex = 1;
            this.chkSavePP.Text = "Pre Planned";
            this.chkSavePP.UseVisualStyleBackColor = true;
            // 
            // chkSaveSeq
            // 
            this.chkSaveSeq.Checked = true;
            this.chkSaveSeq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveSeq.Location = new System.Drawing.Point(18, 210);
            this.chkSaveSeq.Name = "chkSaveSeq";
            this.chkSaveSeq.Size = new System.Drawing.Size(102, 25);
            this.chkSaveSeq.TabIndex = 1;
            this.chkSaveSeq.Text = "Sequences";
            this.chkSaveSeq.UseVisualStyleBackColor = true;
            this.chkSaveSeq.CheckedChanged += new System.EventHandler(this.chkSaveSeq_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(18, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 25);
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
            this.chkSaveRadios.Location = new System.Drawing.Point(18, 120);
            this.chkSaveRadios.Name = "chkSaveRadios";
            this.chkSaveRadios.Size = new System.Drawing.Size(78, 25);
            this.chkSaveRadios.TabIndex = 0;
            this.chkSaveRadios.Text = "Radios";
            this.chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveCMS
            // 
            this.chkSaveCMS.Checked = true;
            this.chkSaveCMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveCMS.Location = new System.Drawing.Point(18, 90);
            this.chkSaveCMS.Name = "chkSaveCMS";
            this.chkSaveCMS.Size = new System.Drawing.Size(63, 25);
            this.chkSaveCMS.TabIndex = 0;
            this.chkSaveCMS.Text = "CMS";
            this.chkSaveCMS.UseVisualStyleBackColor = true;
            // 
            // chkSaveWaypoints
            // 
            this.chkSaveWaypoints.Checked = true;
            this.chkSaveWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveWaypoints.Location = new System.Drawing.Point(18, 60);
            this.chkSaveWaypoints.Name = "chkSaveWaypoints";
            this.chkSaveWaypoints.Size = new System.Drawing.Size(102, 25);
            this.chkSaveWaypoints.TabIndex = 0;
            this.chkSaveWaypoints.Text = "Waypoints";
            this.chkSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(-15, -15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // LoadSavePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.grpSave);
            this.Controls.Add(this.grpLoad);
            this.Controls.Add(this.optClipboard);
            this.Controls.Add(this.optFile);
            this.Name = "LoadSavePage";
            this.Size = new System.Drawing.Size(1006, 1019);
            this.grpLoad.ResumeLayout(false);
            this.grpSave.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.RadioButton optFile;
        private System.Windows.Forms.RadioButton optClipboard;
        private Controls.DTCGroupBox grpLoad;
        private DTCButton btnLoadApply;
        private DTCButton btnLoad;
        private System.Windows.Forms.CheckBox chkLoadRadios;
        private System.Windows.Forms.CheckBox chkLoadCMS;
        private System.Windows.Forms.CheckBox chkLoadWaypoints;
        private Controls.DTCGroupBox grpSave;
        private DTCButton btnSave;
        private System.Windows.Forms.CheckBox chkSaveRadios;
        private System.Windows.Forms.CheckBox chkSaveCMS;
        private System.Windows.Forms.CheckBox chkSaveWaypoints;
        private System.Windows.Forms.CheckBox chkLoadSeq;
        private System.Windows.Forms.CheckBox chkSaveSeq;
        private System.Windows.Forms.CheckBox chkLoadPP;
        private System.Windows.Forms.CheckBox chkSavePP;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkLoadMisc;
        private System.Windows.Forms.CheckBox chkSaveMisc;
    }
}
