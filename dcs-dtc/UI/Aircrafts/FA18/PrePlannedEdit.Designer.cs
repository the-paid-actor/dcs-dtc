
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.FA18
{
	partial class PrePlannedEdit
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidation = new System.Windows.Forms.Label();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.txtWptLatLong = new DTC.UI.Base.Controls.DTCCoordinateTextBox();
            this.txtWptElevation = new DTC.UI.Base.Controls.DTCTextBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
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
            this.lblTitle.Text = "Set Pre Planned Position";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCapture.Location = new System.Drawing.Point(427, 47);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(120, 25);
            this.btnCapture.TabIndex = 13;
            this.btnCapture.Text = "Start Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(1, 47);
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
            this.label2.Location = new System.Drawing.Point(1, 83);
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
            this.lblValidation.Location = new System.Drawing.Point(1, 114);
            this.lblValidation.Margin = new System.Windows.Forms.Padding(0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblValidation.Size = new System.Drawing.Size(548, 25);
            this.lblValidation.TabIndex = 28;
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(427, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtWptLatLong
            // 
            this.txtWptLatLong.AllowPromptAsInput = false;
            this.txtWptLatLong.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptLatLong.HidePromptOnLeave = false;
            this.txtWptLatLong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptLatLong.Location = new System.Drawing.Point(152, 47);
            this.txtWptLatLong.Format = DTC.Utilities.CoordinateFormat.DegreesMinutesSecondsHundredths;
            this.txtWptLatLong.Name = "txtWptLatLong";
            this.txtWptLatLong.PromptChar = '_';
            this.txtWptLatLong.Size = new System.Drawing.Size(270, 28);
            this.txtWptLatLong.TabIndex = 12;
            this.txtWptLatLong.ValidatingType = null;
            // 
            // txtWptElevation
            // 
            this.txtWptElevation.AllowPromptAsInput = true;
            this.txtWptElevation.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptElevation.HidePromptOnLeave = false;
            this.txtWptElevation.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptElevation.Location = new System.Drawing.Point(152, 83);
            this.txtWptElevation.Mask = "";
            this.txtWptElevation.Name = "txtWptElevation";
            this.txtWptElevation.PromptChar = '_';
            this.txtWptElevation.Size = new System.Drawing.Size(100, 28);
            this.txtWptElevation.TabIndex = 14;
            this.txtWptElevation.ValidatingType = null;
            // 
            // PrePlannedEdit
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
            this.Controls.Add(this.txtWptLatLong);
            this.Controls.Add(this.txtWptElevation);
            this.Controls.Add(this.pnlTop);
            this.Name = "PrePlannedEdit";
            this.Size = new System.Drawing.Size(558, 178);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private DTC.UI.Base.Controls.DTCCoordinateTextBox txtWptLatLong;
		private DTC.UI.Base.Controls.DTCTextBox txtWptElevation;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lblClose;
		private System.Windows.Forms.Button btnCapture;
		private Base.Controls.DTCButton btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblValidation;
	}
}
