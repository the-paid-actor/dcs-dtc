
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
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.optFile = new System.Windows.Forms.RadioButton();
            this.optClipboard = new System.Windows.Forms.RadioButton();
            this.grpLoad = new DTC.UI.Controls.DTCGroupBox();
            this.chkLoadTOS = new System.Windows.Forms.CheckBox();
            this.chkLoadMisc = new System.Windows.Forms.CheckBox();
            this.chkLoadHTS = new System.Windows.Forms.CheckBox();
            this.chkLoadHARM = new System.Windows.Forms.CheckBox();
            this.btnLoadApply = new DTC.UI.Base.Controls.DTCButton();
            this.btnLoad = new DTC.UI.Base.Controls.DTCButton();
            this.chkLoadMFDs = new System.Windows.Forms.CheckBox();
            this.chkLoadRadios = new System.Windows.Forms.CheckBox();
            this.chkLoadCMS = new System.Windows.Forms.CheckBox();
            this.chkLoadWaypoints = new System.Windows.Forms.CheckBox();
            this.grpSave = new DTC.UI.Controls.DTCGroupBox();
            this.chkSaveTOS = new System.Windows.Forms.CheckBox();
            this.chkSaveMisc = new System.Windows.Forms.CheckBox();
            this.chkSaveHTS = new System.Windows.Forms.CheckBox();
            this.chkSaveHARM = new System.Windows.Forms.CheckBox();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.chkSaveMFDs = new System.Windows.Forms.CheckBox();
            this.chkSaveRadios = new System.Windows.Forms.CheckBox();
            this.chkSaveCMS = new System.Windows.Forms.CheckBox();
            this.chkSaveWaypoints = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.optXML = new System.Windows.Forms.RadioButton();
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
            this.optFile.Location = new System.Drawing.Point(24, 28);
            this.optFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optFile.Name = "optFile";
            this.optFile.Size = new System.Drawing.Size(68, 29);
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
            this.optClipboard.Location = new System.Drawing.Point(111, 28);
            this.optClipboard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optClipboard.Name = "optClipboard";
            this.optClipboard.Size = new System.Drawing.Size(121, 29);
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
            this.grpLoad.Controls.Add(this.chkLoadTOS);
            this.grpLoad.Controls.Add(this.chkLoadMisc);
            this.grpLoad.Controls.Add(this.chkLoadHTS);
            this.grpLoad.Controls.Add(this.chkLoadHARM);
            this.grpLoad.Controls.Add(this.btnLoadApply);
            this.grpLoad.Controls.Add(this.btnLoad);
            this.grpLoad.Controls.Add(this.chkLoadMFDs);
            this.grpLoad.Controls.Add(this.chkLoadRadios);
            this.grpLoad.Controls.Add(this.chkLoadCMS);
            this.grpLoad.Controls.Add(this.chkLoadWaypoints);
            this.grpLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpLoad.LabelIndent = 10;
            this.grpLoad.Location = new System.Drawing.Point(24, 77);
            this.grpLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpLoad.Size = new System.Drawing.Size(308, 540);
            this.grpLoad.TabIndex = 6;
            this.grpLoad.TabStop = false;
            this.grpLoad.Text = "Load";
            this.grpLoad.Visible = false;
            // 
            // chkLoadTOS
            // 
            this.chkLoadTOS.Enabled = false;
            this.chkLoadTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadTOS.Location = new System.Drawing.Point(27, 417);
            this.chkLoadTOS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadTOS.Name = "chkLoadTOS";
            this.chkLoadTOS.Size = new System.Drawing.Size(106, 38);
            this.chkLoadTOS.TabIndex = 2;
            this.chkLoadTOS.Text = "ToS";
            this.chkLoadTOS.UseVisualStyleBackColor = true;
            // 
            // chkLoadMisc
            // 
            this.chkLoadMisc.Enabled = false;
            this.chkLoadMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadMisc.Location = new System.Drawing.Point(27, 231);
            this.chkLoadMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadMisc.Name = "chkLoadMisc";
            this.chkLoadMisc.Size = new System.Drawing.Size(90, 38);
            this.chkLoadMisc.TabIndex = 1;
            this.chkLoadMisc.Text = "Misc";
            this.chkLoadMisc.UseVisualStyleBackColor = true;
            // 
            // chkLoadHTS
            // 
            this.chkLoadHTS.Enabled = false;
            this.chkLoadHTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadHTS.Location = new System.Drawing.Point(27, 277);
            this.chkLoadHTS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadHTS.Name = "chkLoadHTS";
            this.chkLoadHTS.Size = new System.Drawing.Size(90, 38);
            this.chkLoadHTS.TabIndex = 1;
            this.chkLoadHTS.Text = "HTS";
            this.chkLoadHTS.UseVisualStyleBackColor = true;
            // 
            // chkLoadHARM
            // 
            this.chkLoadHARM.Enabled = false;
            this.chkLoadHARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadHARM.Location = new System.Drawing.Point(27, 323);
            this.chkLoadHARM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadHARM.Name = "chkLoadHARM";
            this.chkLoadHARM.Size = new System.Drawing.Size(114, 38);
            this.chkLoadHARM.TabIndex = 1;
            this.chkLoadHARM.Text = "HARM";
            this.chkLoadHARM.UseVisualStyleBackColor = true;
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
            // chkLoadMFDs
            // 
            this.chkLoadMFDs.Enabled = false;
            this.chkLoadMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadMFDs.Location = new System.Drawing.Point(27, 369);
            this.chkLoadMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadMFDs.Name = "chkLoadMFDs";
            this.chkLoadMFDs.Size = new System.Drawing.Size(106, 38);
            this.chkLoadMFDs.TabIndex = 0;
            this.chkLoadMFDs.Text = "MFDs";
            this.chkLoadMFDs.UseVisualStyleBackColor = true;
            // 
            // chkLoadRadios
            // 
            this.chkLoadRadios.Enabled = false;
            this.chkLoadRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadRadios.Location = new System.Drawing.Point(27, 185);
            this.chkLoadRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadRadios.Name = "chkLoadRadios";
            this.chkLoadRadios.Size = new System.Drawing.Size(117, 38);
            this.chkLoadRadios.TabIndex = 0;
            this.chkLoadRadios.Text = "Radios";
            this.chkLoadRadios.UseVisualStyleBackColor = true;
            // 
            // chkLoadCMS
            // 
            this.chkLoadCMS.Enabled = false;
            this.chkLoadCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkLoadCMS.Location = new System.Drawing.Point(27, 138);
            this.chkLoadCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkLoadCMS.Name = "chkLoadCMS";
            this.chkLoadCMS.Size = new System.Drawing.Size(94, 38);
            this.chkLoadCMS.TabIndex = 0;
            this.chkLoadCMS.Text = "CMS";
            this.chkLoadCMS.UseVisualStyleBackColor = true;
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
            this.grpSave.Controls.Add(this.chkSaveTOS);
            this.grpSave.Controls.Add(this.chkSaveMisc);
            this.grpSave.Controls.Add(this.chkSaveHTS);
            this.grpSave.Controls.Add(this.chkSaveHARM);
            this.grpSave.Controls.Add(this.btnSave);
            this.grpSave.Controls.Add(this.chkSaveMFDs);
            this.grpSave.Controls.Add(this.chkSaveRadios);
            this.grpSave.Controls.Add(this.chkSaveCMS);
            this.grpSave.Controls.Add(this.chkSaveWaypoints);
            this.grpSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grpSave.LabelIndent = 10;
            this.grpSave.Location = new System.Drawing.Point(364, 77);
            this.grpSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSave.Name = "grpSave";
            this.grpSave.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpSave.Size = new System.Drawing.Size(304, 540);
            this.grpSave.TabIndex = 7;
            this.grpSave.TabStop = false;
            this.grpSave.Text = "Save";
            this.grpSave.Visible = false;
            // 
            // chkSaveTOS
            // 
            this.chkSaveTOS.Checked = true;
            this.chkSaveTOS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveTOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveTOS.Location = new System.Drawing.Point(27, 417);
            this.chkSaveTOS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveTOS.Name = "chkSaveTOS";
            this.chkSaveTOS.Size = new System.Drawing.Size(106, 38);
            this.chkSaveTOS.TabIndex = 2;
            this.chkSaveTOS.Text = "ToS";
            this.chkSaveTOS.UseVisualStyleBackColor = true;
            // 
            // chkSaveMisc
            // 
            this.chkSaveMisc.Checked = true;
            this.chkSaveMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveMisc.Location = new System.Drawing.Point(27, 231);
            this.chkSaveMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveMisc.Name = "chkSaveMisc";
            this.chkSaveMisc.Size = new System.Drawing.Size(90, 38);
            this.chkSaveMisc.TabIndex = 1;
            this.chkSaveMisc.Text = "Misc";
            this.chkSaveMisc.UseVisualStyleBackColor = true;
            // 
            // chkSaveHTS
            // 
            this.chkSaveHTS.Checked = true;
            this.chkSaveHTS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveHTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveHTS.Location = new System.Drawing.Point(27, 277);
            this.chkSaveHTS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveHTS.Name = "chkSaveHTS";
            this.chkSaveHTS.Size = new System.Drawing.Size(90, 38);
            this.chkSaveHTS.TabIndex = 1;
            this.chkSaveHTS.Text = "HTS";
            this.chkSaveHTS.UseVisualStyleBackColor = true;
            // 
            // chkSaveHARM
            // 
            this.chkSaveHARM.Checked = true;
            this.chkSaveHARM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveHARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveHARM.Location = new System.Drawing.Point(27, 323);
            this.chkSaveHARM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveHARM.Name = "chkSaveHARM";
            this.chkSaveHARM.Size = new System.Drawing.Size(114, 38);
            this.chkSaveHARM.TabIndex = 1;
            this.chkSaveHARM.Text = "HARM";
            this.chkSaveHARM.UseVisualStyleBackColor = true;
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
            // chkSaveMFDs
            // 
            this.chkSaveMFDs.Checked = true;
            this.chkSaveMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveMFDs.Location = new System.Drawing.Point(27, 369);
            this.chkSaveMFDs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveMFDs.Name = "chkSaveMFDs";
            this.chkSaveMFDs.Size = new System.Drawing.Size(106, 38);
            this.chkSaveMFDs.TabIndex = 0;
            this.chkSaveMFDs.Text = "MFDs";
            this.chkSaveMFDs.UseVisualStyleBackColor = true;
            // 
            // chkSaveRadios
            // 
            this.chkSaveRadios.Checked = true;
            this.chkSaveRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveRadios.Location = new System.Drawing.Point(27, 185);
            this.chkSaveRadios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveRadios.Name = "chkSaveRadios";
            this.chkSaveRadios.Size = new System.Drawing.Size(117, 38);
            this.chkSaveRadios.TabIndex = 0;
            this.chkSaveRadios.Text = "Radios";
            this.chkSaveRadios.UseVisualStyleBackColor = true;
            // 
            // chkSaveCMS
            // 
            this.chkSaveCMS.Checked = true;
            this.chkSaveCMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkSaveCMS.Location = new System.Drawing.Point(27, 138);
            this.chkSaveCMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkSaveCMS.Name = "chkSaveCMS";
            this.chkSaveCMS.Size = new System.Drawing.Size(94, 38);
            this.chkSaveCMS.TabIndex = 0;
            this.chkSaveCMS.Text = "CMS";
            this.chkSaveCMS.UseVisualStyleBackColor = true;
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(-22, -23);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // optXML
            // 
            this.optXML.AutoSize = true;
            this.optXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optXML.Location = new System.Drawing.Point(240, 28);
            this.optXML.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optXML.Name = "optXML";
            this.optXML.Size = new System.Drawing.Size(189, 29);
            this.optXML.TabIndex = 12;
            this.optXML.TabStop = true;
            this.optXML.Text = "CombatFlite XML";
            this.optXML.UseVisualStyleBackColor = true;
            this.optXML.CheckedChanged += new System.EventHandler(this.optXML_CheckedChanged);
            // 
            // LoadSavePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.optXML);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.grpSave);
            this.Controls.Add(this.grpLoad);
            this.Controls.Add(this.optClipboard);
            this.Controls.Add(this.optFile);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoadSavePage";
            this.Size = new System.Drawing.Size(1509, 1568);
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
		private System.Windows.Forms.CheckBox chkLoadMFDs;
		private System.Windows.Forms.CheckBox chkLoadRadios;
		private System.Windows.Forms.CheckBox chkLoadCMS;
		private System.Windows.Forms.CheckBox chkLoadWaypoints;
		private Controls.DTCGroupBox grpSave;
		private DTCButton btnSave;
		private System.Windows.Forms.CheckBox chkSaveMFDs;
		private System.Windows.Forms.CheckBox chkSaveRadios;
		private System.Windows.Forms.CheckBox chkSaveCMS;
		private System.Windows.Forms.CheckBox chkSaveWaypoints;
		private System.Windows.Forms.CheckBox chkLoadHARM;
		private System.Windows.Forms.CheckBox chkSaveHARM;
		private System.Windows.Forms.CheckBox chkLoadHTS;
		private System.Windows.Forms.CheckBox chkSaveHTS;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox chkLoadMisc;
		private System.Windows.Forms.CheckBox chkSaveMisc;
        private System.Windows.Forms.CheckBox chkLoadTOS;
        private System.Windows.Forms.CheckBox chkSaveTOS;
        private System.Windows.Forms.RadioButton optXML;
    }
}
