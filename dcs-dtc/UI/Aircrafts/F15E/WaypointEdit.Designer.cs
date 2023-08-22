
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.F15E
{
	partial class WaypointEdit
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidation = new System.Windows.Forms.Label();
            this.cboAirbases = new DTC.UI.Base.Controls.DTCDropDown();
            this.txtWptName = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptLatLong = new DTC.UI.Base.Controls.DTCCoordinateTextBox();
            this.txtWptElevation = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.btnCancel = new DTC.UI.Base.Controls.DTCButton();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.chkTarget = new DTC.UI.Base.Controls.DTCCheckBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(1, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Airbases:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(1, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Waypoint Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCapture.Location = new System.Drawing.Point(463, 97);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(120, 25);
            this.btnCapture.TabIndex = 13;
            this.btnCapture.Text = "Start Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pnlTop.Controls.Add(this.btnCancel);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(588, 35);
            this.pnlTop.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(1, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Lat/Long:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(1, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Elevation:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValidation
            // 
            this.lblValidation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidation.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(5, 638);
            this.lblValidation.Margin = new System.Windows.Forms.Padding(0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblValidation.Size = new System.Drawing.Size(578, 25);
            this.lblValidation.TabIndex = 28;
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboAirbases
            // 
            this.cboAirbases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAirbases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAirbases.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboAirbases.FormattingEnabled = true;
            this.cboAirbases.Location = new System.Drawing.Point(163, 36);
            this.cboAirbases.Name = "cboAirbases";
            this.cboAirbases.Size = new System.Drawing.Size(420, 24);
            this.cboAirbases.TabIndex = 31;
            this.cboAirbases.SelectedIndexChanged += new System.EventHandler(this.cboAirbases_SelectedIndexChanged);
            // 
            // txtWptName
            // 
            this.txtWptName.AllowPromptAsInput = true;
            this.txtWptName.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptName.HidePromptOnLeave = false;
            this.txtWptName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptName.Location = new System.Drawing.Point(163, 66);
            this.txtWptName.Mask = "";
            this.txtWptName.Name = "txtWptName";
            this.txtWptName.PromptChar = '_';
            this.txtWptName.Size = new System.Drawing.Size(294, 25);
            this.txtWptName.TabIndex = 11;
            this.txtWptName.ValidatingType = null;
            // 
            // txtWptLatLong
            // 
            this.txtWptLatLong.AllowPromptAsInput = false;
            this.txtWptLatLong.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptLatLong.Format = DTC.Utilities.CoordinateFormat.DegreesMinutesThousandths;
            this.txtWptLatLong.HidePromptOnLeave = false;
            this.txtWptLatLong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptLatLong.Location = new System.Drawing.Point(163, 97);
            this.txtWptLatLong.Name = "txtWptLatLong";
            this.txtWptLatLong.PromptChar = '_';
            this.txtWptLatLong.Size = new System.Drawing.Size(294, 25);
            this.txtWptLatLong.TabIndex = 12;
            this.txtWptLatLong.ValidatingType = null;
            // 
            // txtWptElevation
            // 
            this.txtWptElevation.AllowFraction = false;
            this.txtWptElevation.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptElevation.Location = new System.Drawing.Point(163, 128);
            this.txtWptElevation.MaximumValue = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.txtWptElevation.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWptElevation.Name = "txtWptElevation";
            this.txtWptElevation.Size = new System.Drawing.Size(130, 25);
            this.txtWptElevation.TabIndex = 14;
            this.txtWptElevation.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtWptElevation.Value = null;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(131, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 25);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(5, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkTarget
            // 
            this.chkTarget.AutoSize = true;
            this.chkTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkTarget.Location = new System.Drawing.Point(464, 69);
            this.chkTarget.Name = "chkTarget";
            this.chkTarget.Size = new System.Drawing.Size(69, 21);
            this.chkTarget.TabIndex = 32;
            this.chkTarget.Text = "Target";
            this.chkTarget.UseVisualStyleBackColor = true;
            // 
            // WaypointEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.chkTarget);
            this.Controls.Add(this.cboAirbases);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.txtWptName);
            this.Controls.Add(this.txtWptLatLong);
            this.Controls.Add(this.txtWptElevation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlTop);
            this.Name = "WaypointEdit";
            this.Size = new System.Drawing.Size(588, 668);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private DTC.UI.Base.Controls.DTCCoordinateTextBox txtWptLatLong;
		private System.Windows.Forms.Label label5;
		private DTC.UI.Base.Controls.DTCTextBox txtWptName;
		private DTCNumericTextBox txtWptElevation;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Button btnCapture;
		private System.Windows.Forms.Label label3;
		private Base.Controls.DTCButton btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblValidation;
        private DTCDropDown cboAirbases;
        private DTCButton btnCancel;
        private DTCCheckBox chkTarget;
    }
}
