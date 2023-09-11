
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.F15E
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
            chkLoadRadios = new CheckBox();
            chkLoadMisc = new CheckBox();
            chkLoadDisplays = new CheckBox();
            btnLoadApply = new DTCButton();
            btnLoad = new DTCButton();
            chkLoadWaypoints = new CheckBox();
            grpSave = new DTCGroupBox();
            chkSaveRadios = new CheckBox();
            chkSaveMisc = new CheckBox();
            chkSaveDisplays = new CheckBox();
            btnSave = new DTCButton();
            chkSaveWaypoints = new CheckBox();
            checkBox1 = new CheckBox();
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
            optFile.Location = new Point(24, 28);
            optFile.Margin = new Padding(4, 5, 4, 5);
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
            optClipboard.Location = new Point(111, 28);
            optClipboard.Margin = new Padding(4, 5, 4, 5);
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
            grpLoad.Controls.Add(chkLoadRadios);
            grpLoad.Controls.Add(chkLoadMisc);
            grpLoad.Controls.Add(chkLoadDisplays);
            grpLoad.Controls.Add(btnLoadApply);
            grpLoad.Controls.Add(btnLoad);
            grpLoad.Controls.Add(chkLoadWaypoints);
            grpLoad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpLoad.LabelIndent = 10;
            grpLoad.Location = new Point(24, 77);
            grpLoad.Margin = new Padding(4, 5, 4, 5);
            grpLoad.Name = "grpLoad";
            grpLoad.Padding = new Padding(4, 5, 4, 5);
            grpLoad.Size = new Size(216, 286);
            grpLoad.TabIndex = 6;
            grpLoad.TabStop = false;
            grpLoad.Text = "Load";
            grpLoad.Visible = false;
            // 
            // chkLoadRadios
            // 
            chkLoadRadios.Enabled = false;
            chkLoadRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadRadios.Location = new Point(27, 105);
            chkLoadRadios.Name = "chkLoadRadios";
            chkLoadRadios.Size = new Size(102, 25);
            chkLoadRadios.TabIndex = 1;
            chkLoadRadios.Text = "Radios";
            chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkLoadMisc
            // 
            chkLoadMisc.Enabled = false;
            chkLoadMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadMisc.Location = new Point(27, 136);
            chkLoadMisc.Name = "chkLoadMisc";
            chkLoadMisc.Size = new Size(102, 25);
            chkLoadMisc.TabIndex = 1;
            chkLoadMisc.Text = "Misc";
            chkLoadMisc.UseVisualStyleBackColor = true;
            // 
            // chkLoadDisplays
            // 
            chkLoadDisplays.Enabled = false;
            chkLoadDisplays.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadDisplays.Location = new Point(27, 167);
            chkLoadDisplays.Name = "chkLoadDisplays";
            chkLoadDisplays.Size = new Size(102, 25);
            chkLoadDisplays.TabIndex = 1;
            chkLoadDisplays.Text = "Displays";
            chkLoadDisplays.UseVisualStyleBackColor = true;
            // 
            // btnLoadApply
            // 
            btnLoadApply.BackColor = Color.DarkKhaki;
            btnLoadApply.Enabled = false;
            btnLoadApply.FlatAppearance.BorderSize = 0;
            btnLoadApply.FlatStyle = FlatStyle.Flat;
            btnLoadApply.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadApply.Location = new Point(27, 225);
            btnLoadApply.Margin = new Padding(4, 5, 4, 5);
            btnLoadApply.Name = "btnLoadApply";
            btnLoadApply.Size = new Size(161, 34);
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
            btnLoad.Location = new Point(27, 26);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(161, 36);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // chkLoadWaypoints
            // 
            chkLoadWaypoints.Enabled = false;
            chkLoadWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkLoadWaypoints.Location = new Point(27, 69);
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
            grpSave.Controls.Add(chkSaveRadios);
            grpSave.Controls.Add(chkSaveMisc);
            grpSave.Controls.Add(chkSaveDisplays);
            grpSave.Controls.Add(btnSave);
            grpSave.Controls.Add(chkSaveWaypoints);
            grpSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            grpSave.LabelIndent = 10;
            grpSave.Location = new Point(272, 77);
            grpSave.Margin = new Padding(4, 5, 4, 5);
            grpSave.Name = "grpSave";
            grpSave.Padding = new Padding(4, 5, 4, 5);
            grpSave.Size = new Size(199, 286);
            grpSave.TabIndex = 7;
            grpSave.TabStop = false;
            grpSave.Text = "Save";
            grpSave.Visible = false;
            grpSave.Enter += grpSave_Enter;
            // 
            // chkSaveRadios
            // 
            chkSaveRadios.Checked = true;
            chkSaveRadios.CheckState = CheckState.Checked;
            chkSaveRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveRadios.Location = new Point(27, 105);
            chkSaveRadios.Name = "chkSaveRadios";
            chkSaveRadios.Size = new Size(102, 25);
            chkSaveRadios.TabIndex = 1;
            chkSaveRadios.Text = "Radios";
            chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveMisc
            // 
            chkSaveMisc.Checked = true;
            chkSaveMisc.CheckState = CheckState.Checked;
            chkSaveMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveMisc.Location = new Point(27, 136);
            chkSaveMisc.Name = "chkSaveMisc";
            chkSaveMisc.Size = new Size(102, 25);
            chkSaveMisc.TabIndex = 1;
            chkSaveMisc.Text = "Misc";
            chkSaveMisc.UseVisualStyleBackColor = true;
            // 
            // chkSaveDisplays
            // 
            chkSaveDisplays.Checked = true;
            chkSaveDisplays.CheckState = CheckState.Checked;
            chkSaveDisplays.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveDisplays.Location = new Point(27, 160);
            chkSaveDisplays.Margin = new Padding(4, 5, 4, 5);
            chkSaveDisplays.Name = "chkSaveDisplays";
            chkSaveDisplays.Size = new Size(153, 38);
            chkSaveDisplays.TabIndex = 1;
            chkSaveDisplays.Text = "Displays";
            chkSaveDisplays.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(27, 422);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 38);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkSaveWaypoints
            // 
            chkSaveWaypoints.Checked = true;
            chkSaveWaypoints.CheckState = CheckState.Checked;
            chkSaveWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSaveWaypoints.Location = new Point(27, 69);
            chkSaveWaypoints.Margin = new Padding(4, 5, 4, 5);
            chkSaveWaypoints.Name = "chkSaveWaypoints";
            chkSaveWaypoints.Size = new Size(153, 38);
            chkSaveWaypoints.TabIndex = 0;
            chkSaveWaypoints.Text = "Waypoints";
            chkSaveWaypoints.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(-22, -23);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(92, 23);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // optCombatFlite
            // 
            optCombatFlite.AutoSize = true;
            optCombatFlite.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optCombatFlite.Location = new Point(242, 28);
            optCombatFlite.Margin = new Padding(6, 8, 6, 8);
            optCombatFlite.Name = "optCombatFlite";
            optCombatFlite.Size = new Size(100, 21);
            optCombatFlite.TabIndex = 9;
            optCombatFlite.TabStop = true;
            optCombatFlite.Text = "CombatFlite";
            optCombatFlite.UseVisualStyleBackColor = true;
            optCombatFlite.CheckedChanged += optCombatFlite_CheckedChanged;
            // 
            // LoadSavePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(optCombatFlite);
            Controls.Add(checkBox1);
            Controls.Add(grpSave);
            Controls.Add(grpLoad);
            Controls.Add(optClipboard);
            Controls.Add(optFile);
            Margin = new Padding(4, 5, 4, 5);
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
        private CheckBox chkLoadWaypoints;
        private Base.Controls.DTCGroupBox grpSave;
        private DTCButton btnSave;
        private CheckBox chkSaveWaypoints;
        private CheckBox checkBox1;
        private CheckBox chkLoadDisplays;
        private CheckBox chkSaveDisplays;
        private CheckBox chkLoadMisc;
        private CheckBox chkSaveMisc;
        private RadioButton optCombatFlite;
        private CheckBox chkLoadRadios;
        private CheckBox chkSaveRadios;

    }
}
