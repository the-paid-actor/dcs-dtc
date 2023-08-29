
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.F16
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
			this.chkMFDs = new System.Windows.Forms.CheckBox();
			this.chkRadios = new System.Windows.Forms.CheckBox();
			this.chkCMS = new System.Windows.Forms.CheckBox();
			this.chkWaypoints = new System.Windows.Forms.CheckBox();
			this.txtWaypointStart = new DTC.UI.Base.Controls.DTCTextBox();
			this.txtWaypointEnd = new DTC.UI.Base.Controls.DTCTextBox();
			this.btnUpload = new DTC.UI.Base.Controls.DTCButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.chkOverwriteRange = new System.Windows.Forms.CheckBox();
			this.chkMisc = new System.Windows.Forms.CheckBox();
			this.chkHARM = new System.Windows.Forms.CheckBox();
			this.chkHTS = new System.Windows.Forms.CheckBox();
			this.chkCoordinatesElevation = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chkTimeOverSteerpoint = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkMFDs
			// 
			this.chkMFDs.Checked = true;
			this.chkMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkMFDs.Location = new System.Drawing.Point(16, 315);
			this.chkMFDs.Margin = new System.Windows.Forms.Padding(4);
			this.chkMFDs.Name = "chkMFDs";
			this.chkMFDs.Size = new System.Drawing.Size(323, 25);
			this.chkMFDs.TabIndex = 9;
			this.chkMFDs.Text = "MFDs (must be in NAV mode)";
			this.chkMFDs.UseVisualStyleBackColor = true;
			this.chkMFDs.CheckedChanged += new System.EventHandler(this.chkMFDs_CheckedChanged);
			// 
			// chkRadios
			// 
			this.chkRadios.Checked = true;
			this.chkRadios.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkRadios.Location = new System.Drawing.Point(16, 183);
			this.chkRadios.Margin = new System.Windows.Forms.Padding(4);
			this.chkRadios.Name = "chkRadios";
			this.chkRadios.Size = new System.Drawing.Size(78, 25);
			this.chkRadios.TabIndex = 7;
			this.chkRadios.Text = "Radios";
			this.chkRadios.UseVisualStyleBackColor = true;
			this.chkRadios.CheckedChanged += new System.EventHandler(this.chkRadios_CheckedChanged);
			// 
			// chkCMS
			// 
			this.chkCMS.Checked = true;
			this.chkCMS.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkCMS.Location = new System.Drawing.Point(16, 150);
			this.chkCMS.Margin = new System.Windows.Forms.Padding(4);
			this.chkCMS.Name = "chkCMS";
			this.chkCMS.Size = new System.Drawing.Size(63, 25);
			this.chkCMS.TabIndex = 6;
			this.chkCMS.Text = "CMS";
			this.chkCMS.UseVisualStyleBackColor = true;
			this.chkCMS.CheckedChanged += new System.EventHandler(this.chkCMS_CheckedChanged);
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
			this.txtWaypointStart.Location = new System.Drawing.Point(275, 117);
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
			this.txtWaypointEnd.Location = new System.Drawing.Point(378, 117);
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
			this.chkOverwriteRange.Location = new System.Drawing.Point(39, 117);
			this.chkOverwriteRange.Margin = new System.Windows.Forms.Padding(4);
			this.chkOverwriteRange.Name = "chkOverwriteRange";
			this.chkOverwriteRange.Size = new System.Drawing.Size(234, 25);
			this.chkOverwriteRange.TabIndex = 3;
			this.chkOverwriteRange.Text = "Upload into different range from:";
			this.toolTip1.SetToolTip(this.chkOverwriteRange, resources.GetString("chkOverwriteRange.ToolTip"));
			this.chkOverwriteRange.UseVisualStyleBackColor = true;
			this.chkOverwriteRange.CheckedChanged += new System.EventHandler(this.chkOverwriteRange_CheckedChanged);
			// 
			// chkMisc
			// 
			this.chkMisc.Checked = true;
			this.chkMisc.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkMisc.Location = new System.Drawing.Point(16, 216);
			this.chkMisc.Margin = new System.Windows.Forms.Padding(4);
			this.chkMisc.Name = "chkMisc";
			this.chkMisc.Size = new System.Drawing.Size(167, 25);
			this.chkMisc.TabIndex = 8;
			this.chkMisc.Text = "Misc";
			this.chkMisc.UseVisualStyleBackColor = true;
			this.chkMisc.CheckedChanged += new System.EventHandler(this.chkMisc_CheckedChanged);
			// 
			// chkHARM
			// 
			this.chkHARM.Checked = true;
			this.chkHARM.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkHARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkHARM.Location = new System.Drawing.Point(16, 249);
			this.chkHARM.Margin = new System.Windows.Forms.Padding(4);
			this.chkHARM.Name = "chkHARM";
			this.chkHARM.Size = new System.Drawing.Size(323, 25);
			this.chkHARM.TabIndex = 10;
			this.chkHARM.Text = "HARM (must be in NAV mode)";
			this.chkHARM.UseVisualStyleBackColor = true;
			this.chkHARM.CheckedChanged += new System.EventHandler(this.chkHARM_CheckedChanged);
			// 
			// chkHTS
			// 
			this.chkHTS.Checked = true;
			this.chkHTS.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkHTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkHTS.Location = new System.Drawing.Point(16, 282);
			this.chkHTS.Margin = new System.Windows.Forms.Padding(4);
			this.chkHTS.Name = "chkHTS";
			this.chkHTS.Size = new System.Drawing.Size(323, 25);
			this.chkHTS.TabIndex = 11;
			this.chkHTS.Text = "HTS (must be in NAV mode)";
			this.chkHTS.UseVisualStyleBackColor = true;
			this.chkHTS.CheckedChanged += new System.EventHandler(this.chkHTS_CheckedChanged);
			// 
			// chkCoordinatesElevation
			// 
			this.chkCoordinatesElevation.Checked = true;
			this.chkCoordinatesElevation.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCoordinatesElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkCoordinatesElevation.Location = new System.Drawing.Point(39, 51);
			this.chkCoordinatesElevation.Margin = new System.Windows.Forms.Padding(4);
			this.chkCoordinatesElevation.Name = "chkCoordinatesElevation";
			this.chkCoordinatesElevation.Size = new System.Drawing.Size(193, 25);
			this.chkCoordinatesElevation.TabIndex = 1;
			this.chkCoordinatesElevation.Text = "Coordinates and Elevation";
			this.chkCoordinatesElevation.UseVisualStyleBackColor = true;
			this.chkCoordinatesElevation.CheckedChanged += new System.EventHandler(this.chkCoordinatesElevation_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.label4.Location = new System.Drawing.Point(335, 117);
			this.label4.Margin = new System.Windows.Forms.Padding(0);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.label4.Size = new System.Drawing.Size(40, 25);
			this.label4.TabIndex = 31;
			this.label4.Text = "to:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkTimeOverSteerpoint
			// 
			this.chkTimeOverSteerpoint.Checked = true;
			this.chkTimeOverSteerpoint.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTimeOverSteerpoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.chkTimeOverSteerpoint.Location = new System.Drawing.Point(39, 84);
			this.chkTimeOverSteerpoint.Margin = new System.Windows.Forms.Padding(4);
			this.chkTimeOverSteerpoint.Name = "chkTimeOverSteerpoint";
			this.chkTimeOverSteerpoint.Size = new System.Drawing.Size(164, 25);
			this.chkTimeOverSteerpoint.TabIndex = 2;
			this.chkTimeOverSteerpoint.Text = "Time-Over-Steerpoint";
			this.chkTimeOverSteerpoint.UseVisualStyleBackColor = true;
			this.chkTimeOverSteerpoint.CheckedChanged += new System.EventHandler(this.chkTimeOverSteerpoint_CheckedChanged);
			// 
			// UploadToJetPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.Controls.Add(this.chkTimeOverSteerpoint);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkCoordinatesElevation);
			this.Controls.Add(this.chkOverwriteRange);
			this.Controls.Add(this.chkHTS);
			this.Controls.Add(this.chkHARM);
			this.Controls.Add(this.btnUpload);
			this.Controls.Add(this.txtWaypointEnd);
			this.Controls.Add(this.txtWaypointStart);
			this.Controls.Add(this.chkMisc);
			this.Controls.Add(this.chkMFDs);
			this.Controls.Add(this.chkRadios);
			this.Controls.Add(this.chkCMS);
			this.Controls.Add(this.chkWaypoints);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UploadToJetPage";
			this.Size = new System.Drawing.Size(636, 554);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox chkMFDs;
		private System.Windows.Forms.CheckBox chkRadios;
		private System.Windows.Forms.CheckBox chkCMS;
		private System.Windows.Forms.CheckBox chkWaypoints;
		private DTCTextBox txtWaypointStart;
		private DTCTextBox txtWaypointEnd;
		private Base.Controls.DTCButton btnUpload;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkMisc;
        private System.Windows.Forms.CheckBox chkHARM;
        private System.Windows.Forms.CheckBox chkHTS;
		private System.Windows.Forms.CheckBox chkOverwriteRange;
		private System.Windows.Forms.CheckBox chkCoordinatesElevation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkTimeOverSteerpoint;
	}
}
