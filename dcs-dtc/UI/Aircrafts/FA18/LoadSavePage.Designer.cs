
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
            openFileDlg = new OpenFileDialog();
            saveFileDlg = new SaveFileDialog();
            optFile = new RadioButton();
            optClipboard = new RadioButton();
            grpLoad = new DTCGroupBox();
            chkLoadAAWeapons = new CheckBox();
            chkLoadMisc = new CheckBox();
            chkLoadPP = new CheckBox();
            chkLoadSeq = new CheckBox();
            btnLoadApply = new DTCButton();
            btnLoad = new DTCButton();
            chkLoadRadios = new CheckBox();
            chkLoadCMS = new CheckBox();
            chkLoadWaypoints = new CheckBox();
            grpSave = new DTCGroupBox();
            chkSaveAAWeapons = new CheckBox();
            chkSaveMisc = new CheckBox();
            chkSavePP = new CheckBox();
            chkSaveSeq = new CheckBox();
            btnSave = new DTCButton();
            chkSaveRadios = new CheckBox();
            chkSaveCMS = new CheckBox();
            chkSaveWaypoints = new CheckBox();
            checkBox1 = new CheckBox();
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
            optClipboard.Location = new Point(74, 18);
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
            grpLoad.Controls.Add(chkLoadAAWeapons);
            grpLoad.Controls.Add(chkLoadMisc);
            grpLoad.Controls.Add(chkLoadPP);
            grpLoad.Controls.Add(chkLoadSeq);
            grpLoad.Controls.Add(btnLoadApply);
            grpLoad.Controls.Add(btnLoad);
            grpLoad.Controls.Add(chkLoadRadios);
            grpLoad.Controls.Add(chkLoadCMS);
            grpLoad.Controls.Add(chkLoadWaypoints);
            grpLoad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpLoad.LabelIndent = 10;
            grpLoad.Location = new Point(16, 50);
            grpLoad.Name = "grpLoad";
            grpLoad.Size = new Size(205, 314);
            grpLoad.TabIndex = 6;
            grpLoad.TabStop = false;
            grpLoad.Text = "Load";
            grpLoad.Visible = false;
            // 
            // chkLoadAAWeapons
            // 
            chkLoadAAWeapons.Enabled = false;
            chkLoadAAWeapons.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadAAWeapons.Location = new Point(18, 184);
            chkLoadAAWeapons.Name = "chkLoadAAWeapons";
            chkLoadAAWeapons.Size = new Size(120, 25);
            chkLoadAAWeapons.TabIndex = 2;
            chkLoadAAWeapons.Text = "A/A Weapons";
            chkLoadAAWeapons.UseVisualStyleBackColor = true;
            chkLoadAAWeapons.CheckedChanged += chkLoadAAWeapons_CheckedChanged;
            // 
            // chkLoadMisc
            // 
            chkLoadMisc.Enabled = false;
            chkLoadMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadMisc.Location = new Point(18, 246);
            chkLoadMisc.Name = "chkLoadMisc";
            chkLoadMisc.Size = new Size(60, 25);
            chkLoadMisc.TabIndex = 1;
            chkLoadMisc.Text = "Misc";
            chkLoadMisc.UseVisualStyleBackColor = true;
            // 
            // chkLoadPP
            // 
            chkLoadPP.Enabled = false;
            chkLoadPP.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadPP.Location = new Point(18, 122);
            chkLoadPP.Name = "chkLoadPP";
            chkLoadPP.Size = new Size(142, 25);
            chkLoadPP.TabIndex = 1;
            chkLoadPP.Text = "Pre Planned";
            chkLoadPP.UseVisualStyleBackColor = true;
            chkLoadPP.CheckedChanged += chkLoadPP_CheckedChanged;
            // 
            // chkLoadSeq
            // 
            chkLoadSeq.Enabled = false;
            chkLoadSeq.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadSeq.Location = new Point(18, 91);
            chkLoadSeq.Name = "chkLoadSeq";
            chkLoadSeq.Size = new Size(120, 25);
            chkLoadSeq.TabIndex = 1;
            chkLoadSeq.Text = "Sequences";
            chkLoadSeq.UseVisualStyleBackColor = true;
            chkLoadSeq.CheckedChanged += chkLoadSeq_CheckedChanged;
            // 
            // btnLoadApply
            // 
            btnLoadApply.BackColor = Color.DarkKhaki;
            btnLoadApply.Enabled = false;
            btnLoadApply.FlatAppearance.BorderSize = 0;
            btnLoadApply.FlatStyle = FlatStyle.Flat;
            btnLoadApply.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadApply.Location = new Point(18, 277);
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
            // chkLoadRadios
            // 
            chkLoadRadios.Enabled = false;
            chkLoadRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadRadios.Location = new Point(18, 215);
            chkLoadRadios.Name = "chkLoadRadios";
            chkLoadRadios.Size = new Size(78, 25);
            chkLoadRadios.TabIndex = 0;
            chkLoadRadios.Text = "Radios";
            chkLoadRadios.UseVisualStyleBackColor = true;
            chkLoadRadios.CheckedChanged += chkLoadRadios_CheckedChanged;
            // 
            // chkLoadCMS
            // 
            chkLoadCMS.Enabled = false;
            chkLoadCMS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadCMS.Location = new Point(18, 153);
            chkLoadCMS.Name = "chkLoadCMS";
            chkLoadCMS.Size = new Size(63, 25);
            chkLoadCMS.TabIndex = 0;
            chkLoadCMS.Text = "CMS";
            chkLoadCMS.UseVisualStyleBackColor = true;
            chkLoadCMS.CheckedChanged += chkLoadCMS_CheckedChanged;
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
            grpSave.Controls.Add(chkSaveAAWeapons);
            grpSave.Controls.Add(chkSaveMisc);
            grpSave.Controls.Add(chkSavePP);
            grpSave.Controls.Add(chkSaveSeq);
            grpSave.Controls.Add(btnSave);
            grpSave.Controls.Add(chkSaveRadios);
            grpSave.Controls.Add(chkSaveCMS);
            grpSave.Controls.Add(chkSaveWaypoints);
            grpSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpSave.LabelIndent = 10;
            grpSave.Location = new Point(243, 50);
            grpSave.Name = "grpSave";
            grpSave.Size = new Size(203, 314);
            grpSave.TabIndex = 7;
            grpSave.TabStop = false;
            grpSave.Text = "Save";
            grpSave.Visible = false;
            // 
            // chkSaveAAWeapons
            // 
            chkSaveAAWeapons.Checked = true;
            chkSaveAAWeapons.CheckState = CheckState.Checked;
            chkSaveAAWeapons.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveAAWeapons.Location = new Point(18, 179);
            chkSaveAAWeapons.Name = "chkSaveAAWeapons";
            chkSaveAAWeapons.Size = new Size(120, 25);
            chkSaveAAWeapons.TabIndex = 2;
            chkSaveAAWeapons.Text = "A/A Weapons";
            chkSaveAAWeapons.UseVisualStyleBackColor = true;
            // 
            // chkSaveMisc
            // 
            chkSaveMisc.Checked = true;
            chkSaveMisc.CheckState = CheckState.Checked;
            chkSaveMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveMisc.Location = new Point(18, 240);
            chkSaveMisc.Name = "chkSaveMisc";
            chkSaveMisc.Size = new Size(60, 25);
            chkSaveMisc.TabIndex = 1;
            chkSaveMisc.Text = "Misc";
            chkSaveMisc.UseVisualStyleBackColor = true;
            // 
            // chkSavePP
            // 
            chkSavePP.Checked = true;
            chkSavePP.CheckState = CheckState.Checked;
            chkSavePP.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSavePP.Location = new Point(18, 117);
            chkSavePP.Name = "chkSavePP";
            chkSavePP.Size = new Size(120, 25);
            chkSavePP.TabIndex = 1;
            chkSavePP.Text = "Pre Planned";
            chkSavePP.UseVisualStyleBackColor = true;
            // 
            // chkSaveSeq
            // 
            chkSaveSeq.Checked = true;
            chkSaveSeq.CheckState = CheckState.Checked;
            chkSaveSeq.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveSeq.Location = new Point(18, 86);
            chkSaveSeq.Name = "chkSaveSeq";
            chkSaveSeq.Size = new Size(102, 25);
            chkSaveSeq.TabIndex = 1;
            chkSaveSeq.Text = "Sequences";
            chkSaveSeq.UseVisualStyleBackColor = true;
            chkSaveSeq.CheckedChanged += chkSaveSeq_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(18, 277);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 25);
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
            chkSaveRadios.Location = new Point(18, 210);
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
            chkSaveCMS.Location = new Point(18, 148);
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
            chkSaveWaypoints.Location = new Point(18, 55);
            chkSaveWaypoints.Name = "chkSaveWaypoints";
            chkSaveWaypoints.Size = new Size(102, 25);
            chkSaveWaypoints.TabIndex = 0;
            chkSaveWaypoints.Text = "Waypoints";
            chkSaveWaypoints.UseVisualStyleBackColor = true;
            chkSaveWaypoints.CheckedChanged += chkSaveWaypoints_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(-15, -15);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // LoadSavePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(checkBox1);
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
        private CheckBox chkLoadRadios;
        private CheckBox chkLoadCMS;
        private CheckBox chkLoadWaypoints;
        private Base.Controls.DTCGroupBox grpSave;
        private DTCButton btnSave;
        private CheckBox chkSaveRadios;
        private CheckBox chkSaveCMS;
        private CheckBox chkSaveWaypoints;
        private CheckBox chkLoadSeq;
        private CheckBox chkSaveSeq;
        private CheckBox chkLoadPP;
        private CheckBox chkSavePP;
        private CheckBox checkBox1;
        private CheckBox chkLoadMisc;
        private CheckBox chkSaveMisc;
        private CheckBox chkLoadAAWeapons;
        private CheckBox chkSaveAAWeapons;
    }
}
