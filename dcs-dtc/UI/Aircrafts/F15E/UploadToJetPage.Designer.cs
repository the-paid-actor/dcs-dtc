
using DTC.Models.Base;
using DTC.UI.Base.Controls;
using System;

namespace DTC.UI.Aircrafts.F15E
{
	partial class UploadToJetPage
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
            cockpitUploadHelper.Dispose();
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadToJetPage));
            this.chkWaypoints = new System.Windows.Forms.CheckBox();
            this.txtWaypointStart = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWaypointEnd = new DTC.UI.Base.Controls.DTCTextBox();
            this.btnUpload = new DTC.UI.Base.Controls.DTCButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkOverwriteRange = new System.Windows.Forms.CheckBox();
            this.chkDisplays = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMisc = new System.Windows.Forms.CheckBox();
            this.radDisplaysPilot = new System.Windows.Forms.RadioButton();
            this.radDisplaysWSO = new System.Windows.Forms.RadioButton();
            this.chkRadios = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkWaypoints
            // 
            this.chkWaypoints.Checked = true;
            this.chkWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkWaypoints.Location = new System.Drawing.Point(16, 18);
            this.chkWaypoints.Margin = new System.Windows.Forms.Padding(4);
            this.chkWaypoints.Name = "chkWaypoints";
            this.chkWaypoints.Size = new System.Drawing.Size(102, 25);
            this.chkWaypoints.TabIndex = 0;
            this.chkWaypoints.Text = "Waypoints";
            this.chkWaypoints.UseVisualStyleBackColor = true;
            this.chkWaypoints.CheckedChanged += new System.EventHandler(this.chkWaypoints_CheckedChanged);
            // 
            // txtWaypointStart
            // 
            this.txtWaypointStart.AllowPromptAsInput = false;
            this.txtWaypointStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointStart.HidePromptOnLeave = true;
            this.txtWaypointStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointStart.Location = new System.Drawing.Point(275, 51);
            this.txtWaypointStart.Mask = "000";
            this.txtWaypointStart.Name = "txtWaypointStart";
            this.txtWaypointStart.PromptChar = ' ';
            this.txtWaypointStart.Size = new System.Drawing.Size(57, 25);
            this.txtWaypointStart.TabIndex = 4;
            this.txtWaypointStart.ValidatingType = typeof(int);
            // 
            // txtWaypointEnd
            // 
            this.txtWaypointEnd.AllowPromptAsInput = false;
            this.txtWaypointEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointEnd.HidePromptOnLeave = true;
            this.txtWaypointEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointEnd.Location = new System.Drawing.Point(378, 51);
            this.txtWaypointEnd.Mask = "000";
            this.txtWaypointEnd.Name = "txtWaypointEnd";
            this.txtWaypointEnd.PromptChar = ' ';
            this.txtWaypointEnd.Size = new System.Drawing.Size(57, 25);
            this.txtWaypointEnd.TabIndex = 5;
            this.txtWaypointEnd.ValidatingType = typeof(int);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnUpload.Location = new System.Drawing.Point(16, 347);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(120, 25);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 20;
            // 
            // chkOverwriteRange
            // 
            this.chkOverwriteRange.Checked = true;
            this.chkOverwriteRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverwriteRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkOverwriteRange.Location = new System.Drawing.Point(39, 51);
            this.chkOverwriteRange.Margin = new System.Windows.Forms.Padding(4);
            this.chkOverwriteRange.Name = "chkOverwriteRange";
            this.chkOverwriteRange.Size = new System.Drawing.Size(234, 25);
            this.chkOverwriteRange.TabIndex = 3;
            this.chkOverwriteRange.Text = "Upload into different range from:";
            this.toolTip1.SetToolTip(this.chkOverwriteRange, resources.GetString("chkOverwriteRange.ToolTip"));
            this.chkOverwriteRange.UseVisualStyleBackColor = true;
            this.chkOverwriteRange.CheckedChanged += new System.EventHandler(this.chkOverwriteRange_CheckedChanged);
            // 
            // chkDisplays
            // 
            this.chkDisplays.Checked = true;
            this.chkDisplays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkDisplays.Location = new System.Drawing.Point(16, 150);
            this.chkDisplays.Margin = new System.Windows.Forms.Padding(4);
            this.chkDisplays.Name = "chkDisplays";
            this.chkDisplays.Size = new System.Drawing.Size(234, 25);
            this.chkDisplays.TabIndex = 32;
            this.chkDisplays.Text = "Displays";
            this.chkDisplays.UseVisualStyleBackColor = true;
            this.chkDisplays.CheckedChanged += new System.EventHandler(this.chkDisplays_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(335, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(40, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "to:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkMisc
            // 
            this.chkMisc.Checked = true;
            this.chkMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkMisc.Location = new System.Drawing.Point(16, 117);
            this.chkMisc.Margin = new System.Windows.Forms.Padding(4);
            this.chkMisc.Name = "chkMisc";
            this.chkMisc.Size = new System.Drawing.Size(234, 25);
            this.chkMisc.TabIndex = 32;
            this.chkMisc.Text = "Misc";
            this.chkMisc.UseVisualStyleBackColor = true;
            this.chkMisc.CheckedChanged += new System.EventHandler(this.chkMisc_CheckedChanged);
            // 
            // radDisplaysPilot
            // 
            this.radDisplaysPilot.AutoSize = true;
            this.radDisplaysPilot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDisplaysPilot.Location = new System.Drawing.Point(39, 182);
            this.radDisplaysPilot.Name = "radDisplaysPilot";
            this.radDisplaysPilot.Size = new System.Drawing.Size(53, 21);
            this.radDisplaysPilot.TabIndex = 33;
            this.radDisplaysPilot.TabStop = true;
            this.radDisplaysPilot.Text = "Pilot";
            this.radDisplaysPilot.UseVisualStyleBackColor = true;
            this.radDisplaysPilot.CheckedChanged += new System.EventHandler(this.radDisplaysPilot_CheckedChanged);
            // 
            // radDisplaysWSO
            // 
            this.radDisplaysWSO.AutoSize = true;
            this.radDisplaysWSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDisplaysWSO.Location = new System.Drawing.Point(39, 209);
            this.radDisplaysWSO.Name = "radDisplaysWSO";
            this.radDisplaysWSO.Size = new System.Drawing.Size(59, 21);
            this.radDisplaysWSO.TabIndex = 33;
            this.radDisplaysWSO.TabStop = true;
            this.radDisplaysWSO.Text = "WSO";
            this.radDisplaysWSO.UseVisualStyleBackColor = true;
            this.radDisplaysWSO.CheckedChanged += new System.EventHandler(this.radDisplaysWSO_CheckedChanged);
            // 
            // chkRadios
            // 
            this.chkRadios.Checked = true;
            this.chkRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkRadios.Location = new System.Drawing.Point(16, 84);
            this.chkRadios.Margin = new System.Windows.Forms.Padding(4);
            this.chkRadios.Name = "chkRadios";
            this.chkRadios.Size = new System.Drawing.Size(234, 25);
            this.chkRadios.TabIndex = 32;
            this.chkRadios.Text = "Radios";
            this.chkRadios.UseVisualStyleBackColor = true;
            this.chkRadios.CheckedChanged += new System.EventHandler(this.chkRadios_CheckedChanged);
            // 
            // UploadToJetPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.radDisplaysWSO);
            this.Controls.Add(this.radDisplaysPilot);
            this.Controls.Add(this.chkRadios);
            this.Controls.Add(this.chkMisc);
            this.Controls.Add(this.chkDisplays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkOverwriteRange);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtWaypointEnd);
            this.Controls.Add(this.txtWaypointStart);
            this.Controls.Add(this.chkWaypoints);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UploadToJetPage";
            this.Size = new System.Drawing.Size(636, 554);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox chkWaypoints;
		private DTCTextBox txtWaypointStart;
		private DTCTextBox txtWaypointEnd;
		private Base.Controls.DTCButton btnUpload;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkOverwriteRange;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDisplays;
        private System.Windows.Forms.CheckBox chkMisc;
        private System.Windows.Forms.RadioButton radDisplaysPilot;
        private System.Windows.Forms.RadioButton radDisplaysWSO;
        private System.Windows.Forms.CheckBox chkRadios;
    }
}
