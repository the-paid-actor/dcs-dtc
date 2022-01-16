
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaypointStart = new DTC.UI.Base.Controls.DTCTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWaypointEnd = new DTC.UI.Base.Controls.DTCTextBox();
            this.btnUpload = new DTC.UI.Base.Controls.DTCButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkMisc = new System.Windows.Forms.CheckBox();
            this.chkHARM = new System.Windows.Forms.CheckBox();
            this.chkHTS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkMFDs
            // 
            this.chkMFDs.Checked = true;
            this.chkMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkMFDs.Location = new System.Drawing.Point(16, 150);
            this.chkMFDs.Margin = new System.Windows.Forms.Padding(4);
            this.chkMFDs.Name = "chkMFDs";
            this.chkMFDs.Size = new System.Drawing.Size(323, 25);
            this.chkMFDs.TabIndex = 5;
            this.chkMFDs.Text = "MFDs (must be in NAV mode)";
            this.chkMFDs.UseVisualStyleBackColor = true;
            this.chkMFDs.CheckedChanged += new System.EventHandler(this.chkMFDs_CheckedChanged);
            // 
            // chkRadios
            // 
            this.chkRadios.Checked = true;
            this.chkRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkRadios.Location = new System.Drawing.Point(16, 84);
            this.chkRadios.Margin = new System.Windows.Forms.Padding(4);
            this.chkRadios.Name = "chkRadios";
            this.chkRadios.Size = new System.Drawing.Size(78, 25);
            this.chkRadios.TabIndex = 4;
            this.chkRadios.Text = "Radios";
            this.chkRadios.UseVisualStyleBackColor = true;
            this.chkRadios.CheckedChanged += new System.EventHandler(this.chkRadios_CheckedChanged);
            // 
            // chkCMS
            // 
            this.chkCMS.Checked = true;
            this.chkCMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkCMS.Location = new System.Drawing.Point(16, 51);
            this.chkCMS.Margin = new System.Windows.Forms.Padding(4);
            this.chkCMS.Name = "chkCMS";
            this.chkCMS.Size = new System.Drawing.Size(63, 25);
            this.chkCMS.TabIndex = 3;
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(125, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Into Steerpoints";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // txtWaypointStart
            // 
            this.txtWaypointStart.AllowPromptAsInput = false;
            this.txtWaypointStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointStart.HidePromptOnLeave = true;
            this.txtWaypointStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointStart.Location = new System.Drawing.Point(240, 18);
            this.txtWaypointStart.Mask = "000";
            this.txtWaypointStart.Name = "txtWaypointStart";
            this.txtWaypointStart.PromptChar = ' ';
            this.txtWaypointStart.Size = new System.Drawing.Size(57, 25);
            this.txtWaypointStart.TabIndex = 1;
            this.txtWaypointStart.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(303, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Through";
            // 
            // txtWaypointEnd
            // 
            this.txtWaypointEnd.AllowPromptAsInput = false;
            this.txtWaypointEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointEnd.HidePromptOnLeave = true;
            this.txtWaypointEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointEnd.Location = new System.Drawing.Point(377, 18);
            this.txtWaypointEnd.Mask = "000";
            this.txtWaypointEnd.Name = "txtWaypointEnd";
            this.txtWaypointEnd.PromptChar = ' ';
            this.txtWaypointEnd.Size = new System.Drawing.Size(57, 25);
            this.txtWaypointEnd.TabIndex = 2;
            this.txtWaypointEnd.ValidatingType = typeof(int);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnUpload.Location = new System.Drawing.Point(16, 266);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(120, 25);
            this.btnUpload.TabIndex = 7;
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
            // chkMisc
            // 
            this.chkMisc.Checked = true;
            this.chkMisc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkMisc.Location = new System.Drawing.Point(16, 117);
            this.chkMisc.Margin = new System.Windows.Forms.Padding(4);
            this.chkMisc.Name = "chkMisc";
            this.chkMisc.Size = new System.Drawing.Size(167, 25);
            this.chkMisc.TabIndex = 5;
            this.chkMisc.Text = "Misc";
            this.chkMisc.UseVisualStyleBackColor = true;
            this.chkMisc.CheckedChanged += new System.EventHandler(this.chkMisc_CheckedChanged);
            // 
            // chkHARM
            // 
            this.chkHARM.Checked = true;
            this.chkHARM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkHARM.Location = new System.Drawing.Point(16, 183);
            this.chkHARM.Margin = new System.Windows.Forms.Padding(4);
            this.chkHARM.Name = "chkHARM";
            this.chkHARM.Size = new System.Drawing.Size(323, 25);
            this.chkHARM.TabIndex = 8;
            this.chkHARM.Text = "HARM (must be in NAV mode)";
            this.chkHARM.UseVisualStyleBackColor = true;
            this.chkHARM.CheckedChanged += new System.EventHandler(this.chkHARM_CheckedChanged);
            // 
            // chkHTS
            // 
            this.chkHTS.Checked = true;
            this.chkHTS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkHTS.Location = new System.Drawing.Point(16, 216);
            this.chkHTS.Margin = new System.Windows.Forms.Padding(4);
            this.chkHTS.Name = "chkHTS";
            this.chkHTS.Size = new System.Drawing.Size(323, 25);
            this.chkHTS.TabIndex = 9;
            this.chkHTS.Text = "HTS (must be in NAV mode)";
            this.chkHTS.UseVisualStyleBackColor = true;
            this.chkHTS.CheckedChanged += new System.EventHandler(this.chkHTS_CheckedChanged);
            // 
            // UploadToJetPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.chkHTS);
            this.Controls.Add(this.chkHARM);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtWaypointEnd);
            this.Controls.Add(this.txtWaypointStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
		private System.Windows.Forms.Label label1;
		private DTCTextBox txtWaypointStart;
		private System.Windows.Forms.Label label2;
		private DTCTextBox txtWaypointEnd;
		private Base.Controls.DTCButton btnUpload;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkMisc;
        private System.Windows.Forms.CheckBox chkHARM;
        private System.Windows.Forms.CheckBox chkHTS;
    }
}
