
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.F16
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
            openFileDlg = new OpenFileDialog();
            saveFileDlg = new SaveFileDialog();
            optFile = new RadioButton();
            optClipboard = new RadioButton();
            grpLoad = new DTCGroupBox();
            chkLoadMisc = new CheckBox();
            chkLoadHTS = new CheckBox();
            chkLoadHARM = new CheckBox();
            btnLoadApply = new DTCButton();
            btnLoad = new DTCButton();
            chkLoadMFDs = new CheckBox();
            chkLoadRadios = new CheckBox();
            chkLoadCMS = new CheckBox();
            chkLoadWaypoints = new CheckBox();
            grpSave = new DTCGroupBox();
            chkSaveMisc = new CheckBox();
            chkSaveHTS = new CheckBox();
            chkSaveHARM = new CheckBox();
            btnSave = new DTCButton();
            chkSaveMFDs = new CheckBox();
            chkSaveRadios = new CheckBox();
            chkSaveCMS = new CheckBox();
            chkSaveWaypoints = new CheckBox();
            optCombatFlite = new RadioButton();
            grpLoad.SuspendLayout();
            grpSave.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDlg
            // 
            openFileDlg.FileName = "dtc.json";
            // 
            // saveFileDlg
            // 
            saveFileDlg.DefaultExt = "json";
            // 
            // optFile
            // 
            optFile.AutoSize = true;
            optFile.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optFile.Location = new Point(16, 18);
            optFile.Name = "optFile";
            optFile.Size = new Size(48, 21);
            optFile.TabIndex = 7;
            optFile.TabStop = true;
            optFile.Text = "File";
            optFile.UseVisualStyleBackColor = true;
            optFile.CheckedChanged += optFile_CheckedChanged;
            // 
            // optClipboard
            // 
            optClipboard.AutoSize = true;
            optClipboard.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optClipboard.Location = new Point(106, 18);
            optClipboard.Name = "optClipboard";
            optClipboard.Size = new Size(86, 21);
            optClipboard.TabIndex = 7;
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
            grpLoad.Controls.Add(chkLoadMisc);
            grpLoad.Controls.Add(chkLoadHTS);
            grpLoad.Controls.Add(chkLoadHARM);
            grpLoad.Controls.Add(btnLoadApply);
            grpLoad.Controls.Add(btnLoad);
            grpLoad.Controls.Add(chkLoadMFDs);
            grpLoad.Controls.Add(chkLoadRadios);
            grpLoad.Controls.Add(chkLoadCMS);
            grpLoad.Controls.Add(chkLoadWaypoints);
            grpLoad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpLoad.LabelIndent = 10;
            grpLoad.Location = new Point(16, 50);
            grpLoad.Name = "grpLoad";
            grpLoad.Size = new Size(205, 318);
            grpLoad.TabIndex = 6;
            grpLoad.TabStop = false;
            grpLoad.Text = "Load";
            grpLoad.Visible = false;
            // 
            // chkLoadMisc
            // 
            chkLoadMisc.Enabled = false;
            chkLoadMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadMisc.Location = new Point(18, 150);
            chkLoadMisc.Name = "chkLoadMisc";
            chkLoadMisc.Size = new Size(60, 25);
            chkLoadMisc.TabIndex = 1;
            chkLoadMisc.Text = "Misc";
            chkLoadMisc.UseVisualStyleBackColor = true;
            // 
            // chkLoadHTS
            // 
            chkLoadHTS.Enabled = false;
            chkLoadHTS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadHTS.Location = new Point(18, 212);
            chkLoadHTS.Name = "chkLoadHTS";
            chkLoadHTS.Size = new Size(60, 25);
            chkLoadHTS.TabIndex = 1;
            chkLoadHTS.Text = "HTS";
            chkLoadHTS.UseVisualStyleBackColor = true;
            // 
            // chkLoadHARM
            // 
            chkLoadHARM.Enabled = false;
            chkLoadHARM.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadHARM.Location = new Point(18, 181);
            chkLoadHARM.Name = "chkLoadHARM";
            chkLoadHARM.Size = new Size(76, 25);
            chkLoadHARM.TabIndex = 1;
            chkLoadHARM.Text = "HARM";
            chkLoadHARM.UseVisualStyleBackColor = true;
            // 
            // btnLoadApply
            // 
            btnLoadApply.BackColor = Color.DarkKhaki;
            btnLoadApply.Enabled = false;
            btnLoadApply.FlatAppearance.BorderSize = 0;
            btnLoadApply.FlatStyle = FlatStyle.Flat;
            btnLoadApply.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadApply.Location = new Point(18, 274);
            btnLoadApply.Name = "btnLoadApply";
            btnLoadApply.Size = new Size(120, 25);
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
            btnLoad.Location = new Point(18, 30);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(120, 25);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // chkLoadMFDs
            // 
            chkLoadMFDs.Enabled = false;
            chkLoadMFDs.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadMFDs.Location = new Point(18, 243);
            chkLoadMFDs.Name = "chkLoadMFDs";
            chkLoadMFDs.Size = new Size(71, 25);
            chkLoadMFDs.TabIndex = 0;
            chkLoadMFDs.Text = "MFDs";
            chkLoadMFDs.UseVisualStyleBackColor = true;
            // 
            // chkLoadRadios
            // 
            chkLoadRadios.Enabled = false;
            chkLoadRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadRadios.Location = new Point(18, 120);
            chkLoadRadios.Name = "chkLoadRadios";
            chkLoadRadios.Size = new Size(78, 25);
            chkLoadRadios.TabIndex = 0;
            chkLoadRadios.Text = "Radios";
            chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkLoadCMS
            // 
            chkLoadCMS.Enabled = false;
            chkLoadCMS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadCMS.Location = new Point(18, 90);
            chkLoadCMS.Name = "chkLoadCMS";
            chkLoadCMS.Size = new Size(63, 25);
            chkLoadCMS.TabIndex = 0;
            chkLoadCMS.Text = "CMS";
            chkLoadCMS.UseVisualStyleBackColor = true;
            // 
            // chkLoadWaypoints
            // 
            chkLoadWaypoints.Enabled = false;
            chkLoadWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadWaypoints.Location = new Point(18, 60);
            chkLoadWaypoints.Name = "chkLoadWaypoints";
            chkLoadWaypoints.Size = new Size(102, 25);
            chkLoadWaypoints.TabIndex = 0;
            chkLoadWaypoints.Text = "Waypoints";
            chkLoadWaypoints.UseVisualStyleBackColor = true;
            // 
            // grpSave
            // 
            grpSave.BorderColor = Color.Black;
            grpSave.BorderRadius = 5;
            grpSave.BorderWidth = 2;
            grpSave.Controls.Add(chkSaveMisc);
            grpSave.Controls.Add(chkSaveHTS);
            grpSave.Controls.Add(chkSaveHARM);
            grpSave.Controls.Add(btnSave);
            grpSave.Controls.Add(chkSaveMFDs);
            grpSave.Controls.Add(chkSaveRadios);
            grpSave.Controls.Add(chkSaveCMS);
            grpSave.Controls.Add(chkSaveWaypoints);
            grpSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpSave.LabelIndent = 10;
            grpSave.Location = new Point(243, 50);
            grpSave.Name = "grpSave";
            grpSave.Size = new Size(203, 318);
            grpSave.TabIndex = 7;
            grpSave.TabStop = false;
            grpSave.Text = "Save";
            grpSave.Visible = false;
            // 
            // chkSaveMisc
            // 
            chkSaveMisc.Checked = true;
            chkSaveMisc.CheckState = CheckState.Checked;
            chkSaveMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveMisc.Location = new Point(18, 150);
            chkSaveMisc.Name = "chkSaveMisc";
            chkSaveMisc.Size = new Size(60, 25);
            chkSaveMisc.TabIndex = 1;
            chkSaveMisc.Text = "Misc";
            chkSaveMisc.UseVisualStyleBackColor = true;
            // 
            // chkSaveHTS
            // 
            chkSaveHTS.Checked = true;
            chkSaveHTS.CheckState = CheckState.Checked;
            chkSaveHTS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveHTS.Location = new Point(18, 212);
            chkSaveHTS.Name = "chkSaveHTS";
            chkSaveHTS.Size = new Size(60, 25);
            chkSaveHTS.TabIndex = 1;
            chkSaveHTS.Text = "HTS";
            chkSaveHTS.UseVisualStyleBackColor = true;
            // 
            // chkSaveHARM
            // 
            chkSaveHARM.Checked = true;
            chkSaveHARM.CheckState = CheckState.Checked;
            chkSaveHARM.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveHARM.Location = new Point(18, 181);
            chkSaveHARM.Name = "chkSaveHARM";
            chkSaveHARM.Size = new Size(76, 25);
            chkSaveHARM.TabIndex = 1;
            chkSaveHARM.Text = "HARM";
            chkSaveHARM.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(18, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 25);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkSaveMFDs
            // 
            chkSaveMFDs.Checked = true;
            chkSaveMFDs.CheckState = CheckState.Checked;
            chkSaveMFDs.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveMFDs.Location = new Point(18, 243);
            chkSaveMFDs.Name = "chkSaveMFDs";
            chkSaveMFDs.Size = new Size(71, 25);
            chkSaveMFDs.TabIndex = 0;
            chkSaveMFDs.Text = "MFDs";
            chkSaveMFDs.UseVisualStyleBackColor = true;
            // 
            // chkSaveRadios
            // 
            chkSaveRadios.Checked = true;
            chkSaveRadios.CheckState = CheckState.Checked;
            chkSaveRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveRadios.Location = new Point(18, 120);
            chkSaveRadios.Name = "chkSaveRadios";
            chkSaveRadios.Size = new Size(78, 25);
            chkSaveRadios.TabIndex = 0;
            chkSaveRadios.Text = "Radios";
            chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveCMS
            // 
            chkSaveCMS.Checked = true;
            chkSaveCMS.CheckState = CheckState.Checked;
            chkSaveCMS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveCMS.Location = new Point(18, 90);
            chkSaveCMS.Name = "chkSaveCMS";
            chkSaveCMS.Size = new Size(63, 25);
            chkSaveCMS.TabIndex = 0;
            chkSaveCMS.Text = "CMS";
            chkSaveCMS.UseVisualStyleBackColor = true;
            // 
            // chkSaveWaypoints
            // 
            chkSaveWaypoints.Checked = true;
            chkSaveWaypoints.CheckState = CheckState.Checked;
            chkSaveWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveWaypoints.Location = new Point(18, 60);
            chkSaveWaypoints.Name = "chkSaveWaypoints";
            chkSaveWaypoints.Size = new Size(102, 25);
            chkSaveWaypoints.TabIndex = 0;
            chkSaveWaypoints.Text = "Waypoints";
            chkSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // optCombatFlite
            // 
            optCombatFlite.AutoSize = true;
            optCombatFlite.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optCombatFlite.Location = new Point(243, 18);
            optCombatFlite.Margin = new Padding(6, 8, 6, 8);
            optCombatFlite.Name = "optCombatFlite";
            optCombatFlite.Size = new Size(100, 21);
            optCombatFlite.TabIndex = 10;
            optCombatFlite.TabStop = true;
            optCombatFlite.Text = "CombatFlite";
            optCombatFlite.UseVisualStyleBackColor = true;
            // 
            // LoadSavePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(optCombatFlite);
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
        private OpenFileDialog openFileDlg;
        private SaveFileDialog saveFileDlg;
        private RadioButton optFile;
        private RadioButton optClipboard;
        private Base.Controls.DTCGroupBox grpLoad;
        private DTCButton btnLoadApply;
        private DTCButton btnLoad;
        private CheckBox chkLoadMFDs;
        private CheckBox chkLoadRadios;
        private CheckBox chkLoadCMS;
        private CheckBox chkLoadWaypoints;
        private Base.Controls.DTCGroupBox grpSave;
        private DTCButton btnSave;
        private CheckBox chkSaveMFDs;
        private CheckBox chkSaveRadios;
        private CheckBox chkSaveCMS;
        private CheckBox chkSaveWaypoints;
        private CheckBox chkLoadHARM;
        private CheckBox chkSaveHARM;
        private CheckBox chkLoadHTS;
        private CheckBox chkSaveHTS;
        private CheckBox chkLoadMisc;
        private CheckBox chkSaveMisc;
        private RadioButton optCombatFlite;
    }
}
