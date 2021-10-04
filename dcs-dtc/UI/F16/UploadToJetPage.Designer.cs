
using DTC.UI.Base.Controls;

namespace DTC.UI.F16
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
            this.chkMFDs = new System.Windows.Forms.CheckBox();
            this.chkRadios = new System.Windows.Forms.CheckBox();
            this.chkCMS = new System.Windows.Forms.CheckBox();
            this.chkWaypoints = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaypointStart = new DTC.UI.Base.Controls.DTCTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWaypointEnd = new DTC.UI.Base.Controls.DTCTextBox();
            this.btnUpload = new DTC.UI.Base.Controls.DTCButton();
            this.SuspendLayout();
            // 
            // chkMFDs
            // 
            this.chkMFDs.AutoSize = true;
            this.chkMFDs.Checked = true;
            this.chkMFDs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMFDs.Location = new System.Drawing.Point(25, 205);
            this.chkMFDs.Margin = new System.Windows.Forms.Padding(4);
            this.chkMFDs.Name = "chkMFDs";
            this.chkMFDs.Size = new System.Drawing.Size(103, 33);
            this.chkMFDs.TabIndex = 5;
            this.chkMFDs.Text = "MFDs";
            this.chkMFDs.UseVisualStyleBackColor = true;
            // 
            // chkRadios
            // 
            this.chkRadios.AutoSize = true;
            this.chkRadios.Location = new System.Drawing.Point(25, 161);
            this.chkRadios.Margin = new System.Windows.Forms.Padding(4);
            this.chkRadios.Name = "chkRadios";
            this.chkRadios.Size = new System.Drawing.Size(115, 33);
            this.chkRadios.TabIndex = 4;
            this.chkRadios.Text = "Radios";
            this.chkRadios.UseVisualStyleBackColor = true;
            // 
            // chkCMS
            // 
            this.chkCMS.AutoSize = true;
            this.chkCMS.Location = new System.Drawing.Point(25, 116);
            this.chkCMS.Margin = new System.Windows.Forms.Padding(4);
            this.chkCMS.Name = "chkCMS";
            this.chkCMS.Size = new System.Drawing.Size(92, 33);
            this.chkCMS.TabIndex = 3;
            this.chkCMS.Text = "CMS";
            this.chkCMS.UseVisualStyleBackColor = true;
            // 
            // chkWaypoints
            // 
            this.chkWaypoints.AutoSize = true;
            this.chkWaypoints.Checked = true;
            this.chkWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaypoints.Location = new System.Drawing.Point(25, 33);
            this.chkWaypoints.Margin = new System.Windows.Forms.Padding(4);
            this.chkWaypoints.Name = "chkWaypoints";
            this.chkWaypoints.Size = new System.Drawing.Size(150, 33);
            this.chkWaypoints.TabIndex = 0;
            this.chkWaypoints.Text = "Waypoints";
            this.chkWaypoints.UseVisualStyleBackColor = true;
            this.chkWaypoints.CheckedChanged += new System.EventHandler(this.chkWaypoints_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Into";
            // 
            // txtWaypointStart
            // 
            this.txtWaypointStart.AllowPromptAsInput = false;
            this.txtWaypointStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointStart.HidePromptOnLeave = true;
            this.txtWaypointStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointStart.Location = new System.Drawing.Point(101, 74);
            this.txtWaypointStart.Mask = "000";
            this.txtWaypointStart.Name = "txtWaypointStart";
            this.txtWaypointStart.PromptChar = ' ';
            this.txtWaypointStart.Size = new System.Drawing.Size(57, 26);
            this.txtWaypointStart.TabIndex = 1;
            this.txtWaypointStart.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Through";
            // 
            // txtWaypointEnd
            // 
            this.txtWaypointEnd.AllowPromptAsInput = false;
            this.txtWaypointEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointEnd.HidePromptOnLeave = true;
            this.txtWaypointEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointEnd.Location = new System.Drawing.Point(242, 73);
            this.txtWaypointEnd.Mask = "000";
            this.txtWaypointEnd.Name = "txtWaypointEnd";
            this.txtWaypointEnd.PromptChar = ' ';
            this.txtWaypointEnd.Size = new System.Drawing.Size(57, 26);
            this.txtWaypointEnd.TabIndex = 2;
            this.txtWaypointEnd.ValidatingType = typeof(int);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnUpload.Location = new System.Drawing.Point(25, 247);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(169, 42);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // UploadToJetPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtWaypointEnd);
            this.Controls.Add(this.txtWaypointStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkMFDs);
            this.Controls.Add(this.chkRadios);
            this.Controls.Add(this.chkCMS);
            this.Controls.Add(this.chkWaypoints);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UploadToJetPage";
            this.Size = new System.Drawing.Size(636, 554);
            this.ResumeLayout(false);
            this.PerformLayout();

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
	}
}
