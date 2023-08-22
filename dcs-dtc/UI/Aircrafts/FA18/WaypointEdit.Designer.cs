
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.FA18
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
            this.cboAirbases = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.txtWptName = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptElevation = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptLatLong = new DTC.UI.Base.Controls.DTCCoordinateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidation = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboAirbases
            // 
            this.cboAirbases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAirbases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAirbases.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboAirbases.FormattingEnabled = true;
            this.cboAirbases.Location = new System.Drawing.Point(152, 36);
            this.cboAirbases.Name = "cboAirbases";
            this.cboAirbases.Size = new System.Drawing.Size(395, 28);
            this.cboAirbases.TabIndex = 10;
            this.cboAirbases.SelectedIndexChanged += new System.EventHandler(this.cboAirbases_SelectedIndexChanged);
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
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(508, 30);
            this.lblTitle.TabIndex = 22;
            this.lblTitle.Text = "Add Waypoint";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(1, 70);
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
            this.btnCapture.Location = new System.Drawing.Point(427, 104);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(120, 25);
            this.btnCapture.TabIndex = 13;
            this.btnCapture.Text = "Start Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(429, 197);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(558, 30);
            this.pnlTop.TabIndex = 25;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblClose.Location = new System.Drawing.Point(508, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(50, 30);
            this.lblClose.TabIndex = 23;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // txtWptName
            // 
            this.txtWptName.AllowPromptAsInput = true;
            this.txtWptName.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptName.HidePromptOnLeave = false;
            this.txtWptName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptName.Location = new System.Drawing.Point(152, 70);
            this.txtWptName.Mask = "";
            this.txtWptName.Name = "txtWptName";
            this.txtWptName.PromptChar = '_';
            this.txtWptName.Size = new System.Drawing.Size(395, 28);
            this.txtWptName.TabIndex = 11;
            this.txtWptName.ValidatingType = null;
            // 
            // txtWptElevation
            // 
            this.txtWptElevation.AllowPromptAsInput = true;
            this.txtWptElevation.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptElevation.HidePromptOnLeave = false;
            this.txtWptElevation.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptElevation.Location = new System.Drawing.Point(152, 138);
            this.txtWptElevation.Mask = "";
            this.txtWptElevation.Name = "txtWptElevation";
            this.txtWptElevation.PromptChar = '_';
            this.txtWptElevation.Size = new System.Drawing.Size(100, 28);
            this.txtWptElevation.TabIndex = 14;
            this.txtWptElevation.ValidatingType = null;
            // 
            // txtWptLatLong
            // 
            this.txtWptLatLong.AllowPromptAsInput = false;
            this.txtWptLatLong.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptLatLong.HidePromptOnLeave = false;
            this.txtWptLatLong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptLatLong.Location = new System.Drawing.Point(152, 104);
            this.txtWptLatLong.Format = DTC.Utilities.CoordinateFormat.DegreesMinutesHundredths;
            this.txtWptLatLong.Name = "txtWptLatLong";
            this.txtWptLatLong.PromptChar = '_';
            this.txtWptLatLong.Size = new System.Drawing.Size(270, 28);
            this.txtWptLatLong.TabIndex = 12;
            this.txtWptLatLong.ValidatingType = null;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(1, 104);
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
            this.label2.Location = new System.Drawing.Point(1, 138);
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
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(1, 169);
            this.lblValidation.Margin = new System.Windows.Forms.Padding(0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblValidation.Size = new System.Drawing.Size(548, 25);
            this.lblValidation.TabIndex = 28;
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaypointEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.txtWptName);
            this.Controls.Add(this.txtWptLatLong);
            this.Controls.Add(this.txtWptElevation);
            this.Controls.Add(this.cboAirbases);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlTop);
            this.Name = "WaypointEdit";
            this.Size = new System.Drawing.Size(558, 231);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboAirbases;
		private DTC.UI.Base.Controls.DTCCoordinateTextBox txtWptLatLong;
		private System.Windows.Forms.Label label5;
		private DTC.UI.Base.Controls.DTCTextBox txtWptName;
		private DTC.UI.Base.Controls.DTCTextBox txtWptElevation;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lblClose;
		private System.Windows.Forms.Button btnCapture;
		private System.Windows.Forms.Label label3;
		private Base.Controls.DTCButton btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblValidation;
	}
}
