
using DTC.Models.Base;
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.FA18
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
            this.chkRadios = new System.Windows.Forms.CheckBox();
            this.chkWaypoints = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaypointStart = new DTC.UI.Base.Controls.DTCTextBox();
            this.btnUpload = new DTC.UI.Base.Controls.DTCButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkMisc = new System.Windows.Forms.CheckBox();
            this.cbSequences = new System.Windows.Forms.CheckBox();
            this.cbPrePlanned = new System.Windows.Forms.CheckBox();
            this.cbCMS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkRadios
            // 
            this.chkRadios.Checked = true;
            this.chkRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkRadios.Location = new System.Drawing.Point(16, 150);
            this.chkRadios.Margin = new System.Windows.Forms.Padding(4);
            this.chkRadios.Name = "chkRadios";
            this.chkRadios.Size = new System.Drawing.Size(78, 25);
            this.chkRadios.TabIndex = 4;
            this.chkRadios.Text = "Radios";
            this.chkRadios.UseVisualStyleBackColor = true;
            this.chkRadios.CheckedChanged += new System.EventHandler(this.chkRadios_CheckedChanged);
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
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Starting at WYPT";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtWaypointStart
            // 
            this.txtWaypointStart.AllowPromptAsInput = false;
            this.txtWaypointStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointStart.HidePromptOnLeave = true;
            this.txtWaypointStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointStart.Location = new System.Drawing.Point(249, 18);
            this.txtWaypointStart.Mask = "000";
            this.txtWaypointStart.Name = "txtWaypointStart";
            this.txtWaypointStart.PromptChar = ' ';
            this.txtWaypointStart.Size = new System.Drawing.Size(57, 25);
            this.txtWaypointStart.TabIndex = 1;
            this.txtWaypointStart.ValidatingType = typeof(int);
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
            this.chkMisc.Location = new System.Drawing.Point(16, 183);
            this.chkMisc.Margin = new System.Windows.Forms.Padding(4);
            this.chkMisc.Name = "chkMisc";
            this.chkMisc.Size = new System.Drawing.Size(167, 25);
            this.chkMisc.TabIndex = 5;
            this.chkMisc.Text = "Misc";
            this.chkMisc.UseVisualStyleBackColor = true;
            this.chkMisc.CheckedChanged += new System.EventHandler(this.chkMisc_CheckedChanged);
            // 
            // cbSequences
            // 
            this.cbSequences.Checked = true;
            this.cbSequences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSequences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbSequences.Location = new System.Drawing.Point(16, 51);
            this.cbSequences.Margin = new System.Windows.Forms.Padding(4);
            this.cbSequences.Name = "cbSequences";
            this.cbSequences.Size = new System.Drawing.Size(102, 25);
            this.cbSequences.TabIndex = 8;
            this.cbSequences.Text = "Sequences";
            this.cbSequences.UseVisualStyleBackColor = true;
            this.cbSequences.CheckedChanged += new System.EventHandler(this.cbSequences_CheckedChanged);
            // 
            // cbPrePlanned
            // 
            this.cbPrePlanned.Checked = true;
            this.cbPrePlanned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrePlanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPrePlanned.Location = new System.Drawing.Point(16, 84);
            this.cbPrePlanned.Margin = new System.Windows.Forms.Padding(4);
            this.cbPrePlanned.Name = "cbPrePlanned";
            this.cbPrePlanned.Size = new System.Drawing.Size(201, 25);
            this.cbPrePlanned.TabIndex = 9;
            this.cbPrePlanned.Text = "Pre Planned Coordinates";
            this.cbPrePlanned.UseVisualStyleBackColor = true;
            this.cbPrePlanned.CheckedChanged += new System.EventHandler(this.cbPrePlanned_CheckedChanged);
            // 
            // cbCMS
            // 
            this.cbCMS.Checked = true;
            this.cbCMS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbCMS.Location = new System.Drawing.Point(16, 117);
            this.cbCMS.Margin = new System.Windows.Forms.Padding(4);
            this.cbCMS.Name = "cbCMS";
            this.cbCMS.Size = new System.Drawing.Size(201, 25);
            this.cbCMS.TabIndex = 10;
            this.cbCMS.Text = "Countermeasure Programs";
            this.cbCMS.UseVisualStyleBackColor = true;
            this.cbCMS.CheckedChanged += new System.EventHandler(this.cbCMS_CheckedChanged);
            // 
            // UploadToJetPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.cbCMS);
            this.Controls.Add(this.cbPrePlanned);
            this.Controls.Add(this.cbSequences);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtWaypointStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkMisc);
            this.Controls.Add(this.chkRadios);
            this.Controls.Add(this.chkWaypoints);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UploadToJetPage";
            this.Size = new System.Drawing.Size(636, 554);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox chkRadios;
		private System.Windows.Forms.CheckBox chkWaypoints;
		private System.Windows.Forms.Label label1;
		private DTCTextBox txtWaypointStart;
		private Base.Controls.DTCButton btnUpload;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkMisc;
        private System.Windows.Forms.CheckBox cbSequences;
        private System.Windows.Forms.CheckBox cbPrePlanned;
        private System.Windows.Forms.CheckBox cbCMS;
    }
}
