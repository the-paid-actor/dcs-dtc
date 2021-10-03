
namespace DTC.UI
{
	partial class MainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pnlBackground = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.btnMFDs = new System.Windows.Forms.Button();
			this.btnRadios = new System.Windows.Forms.Button();
			this.btnCMS = new System.Windows.Forms.Button();
			this.btnWaypoints = new System.Windows.Forms.Button();
			this.btnUpload = new System.Windows.Forms.Button();
			this.btnLoadSave = new System.Windows.Forms.Button();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lblPin = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblClose = new System.Windows.Forms.Label();
			this.pnlBackground.SuspendLayout();
			this.pnlContent.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBackground
			// 
			this.pnlBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBackground.BackgroundImage")));
			this.pnlBackground.Controls.Add(this.pnlContent);
			this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBackground.Location = new System.Drawing.Point(0, 0);
			this.pnlBackground.Name = "pnlBackground";
			this.pnlBackground.Size = new System.Drawing.Size(916, 664);
			this.pnlBackground.TabIndex = 0;
			this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBackground_MouseDown);
			// 
			// pnlContent
			// 
			this.pnlContent.BackColor = System.Drawing.Color.Black;
			this.pnlContent.Controls.Add(this.pnlMain);
			this.pnlContent.Controls.Add(this.pnlLeft);
			this.pnlContent.Controls.Add(this.pnlTop);
			this.pnlContent.Location = new System.Drawing.Point(72, 111);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(770, 450);
			this.pnlContent.TabIndex = 0;
			// 
			// pnlMain
			// 
			this.pnlMain.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(182, 50);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(588, 400);
			this.pnlMain.TabIndex = 4;
			// 
			// pnlLeft
			// 
			this.pnlLeft.BackColor = System.Drawing.Color.DarkKhaki;
			this.pnlLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pnlLeft.Controls.Add(this.btnMFDs);
			this.pnlLeft.Controls.Add(this.btnRadios);
			this.pnlLeft.Controls.Add(this.btnCMS);
			this.pnlLeft.Controls.Add(this.btnWaypoints);
			this.pnlLeft.Controls.Add(this.btnUpload);
			this.pnlLeft.Controls.Add(this.btnLoadSave);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 50);
			this.pnlLeft.Margin = new System.Windows.Forms.Padding(10);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(5);
			this.pnlLeft.Size = new System.Drawing.Size(182, 400);
			this.pnlLeft.TabIndex = 3;
			// 
			// btnMFDs
			// 
			this.btnMFDs.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnMFDs.FlatAppearance.BorderSize = 0;
			this.btnMFDs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMFDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMFDs.Location = new System.Drawing.Point(5, 255);
			this.btnMFDs.Name = "btnMFDs";
			this.btnMFDs.Size = new System.Drawing.Size(172, 50);
			this.btnMFDs.TabIndex = 10;
			this.btnMFDs.TabStop = false;
			this.btnMFDs.Text = "MFDs";
			this.btnMFDs.UseVisualStyleBackColor = true;
			this.btnMFDs.Click += new System.EventHandler(this.btnMFDs_Click);
			// 
			// btnRadios
			// 
			this.btnRadios.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnRadios.FlatAppearance.BorderSize = 0;
			this.btnRadios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRadios.Location = new System.Drawing.Point(5, 205);
			this.btnRadios.Name = "btnRadios";
			this.btnRadios.Size = new System.Drawing.Size(172, 50);
			this.btnRadios.TabIndex = 9;
			this.btnRadios.TabStop = false;
			this.btnRadios.Text = "Radios";
			this.btnRadios.UseVisualStyleBackColor = true;
			this.btnRadios.Click += new System.EventHandler(this.btnRadios_Click);
			// 
			// btnCMS
			// 
			this.btnCMS.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnCMS.FlatAppearance.BorderSize = 0;
			this.btnCMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCMS.Location = new System.Drawing.Point(5, 155);
			this.btnCMS.Name = "btnCMS";
			this.btnCMS.Size = new System.Drawing.Size(172, 50);
			this.btnCMS.TabIndex = 8;
			this.btnCMS.TabStop = false;
			this.btnCMS.Text = "CMS";
			this.btnCMS.UseVisualStyleBackColor = true;
			this.btnCMS.Click += new System.EventHandler(this.btnCMS_Click);
			// 
			// btnWaypoints
			// 
			this.btnWaypoints.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnWaypoints.FlatAppearance.BorderSize = 0;
			this.btnWaypoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWaypoints.Location = new System.Drawing.Point(5, 105);
			this.btnWaypoints.Name = "btnWaypoints";
			this.btnWaypoints.Size = new System.Drawing.Size(172, 50);
			this.btnWaypoints.TabIndex = 7;
			this.btnWaypoints.TabStop = false;
			this.btnWaypoints.Text = "Waypoints";
			this.btnWaypoints.UseVisualStyleBackColor = true;
			this.btnWaypoints.Click += new System.EventHandler(this.btnWaypoints_Click);
			// 
			// btnUpload
			// 
			this.btnUpload.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnUpload.FlatAppearance.BorderSize = 0;
			this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpload.Location = new System.Drawing.Point(5, 55);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(172, 50);
			this.btnUpload.TabIndex = 6;
			this.btnUpload.TabStop = false;
			this.btnUpload.Text = "Upload to Jet";
			this.btnUpload.UseVisualStyleBackColor = true;
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// btnLoadSave
			// 
			this.btnLoadSave.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnLoadSave.FlatAppearance.BorderSize = 0;
			this.btnLoadSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoadSave.Location = new System.Drawing.Point(5, 5);
			this.btnLoadSave.Name = "btnLoadSave";
			this.btnLoadSave.Size = new System.Drawing.Size(172, 50);
			this.btnLoadSave.TabIndex = 5;
			this.btnLoadSave.TabStop = false;
			this.btnLoadSave.Text = "Load / Save";
			this.btnLoadSave.UseVisualStyleBackColor = true;
			this.btnLoadSave.Click += new System.EventHandler(this.btnLoadSave_Click);
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.DarkKhaki;
			this.pnlTop.BackgroundImage = global::DTC.Properties.Resources._2560px_Brown_dominant__highland__ERDL_camouflage_pattern_swatch_svg;
			this.pnlTop.Controls.Add(this.lblPin);
			this.pnlTop.Controls.Add(this.label1);
			this.pnlTop.Controls.Add(this.lblClose);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(770, 50);
			this.pnlTop.TabIndex = 2;
			// 
			// lblPin
			// 
			this.lblPin.BackColor = System.Drawing.Color.Transparent;
			this.lblPin.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPin.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblPin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
			this.lblPin.Image = global::DTC.Properties.Resources.pin;
			this.lblPin.Location = new System.Drawing.Point(670, 0);
			this.lblPin.Name = "lblPin";
			this.lblPin.Size = new System.Drawing.Size(50, 50);
			this.lblPin.TabIndex = 3;
			this.lblPin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblPin.Click += new System.EventHandler(this.lblPin_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(182, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "DCS DTC";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblClose
			// 
			this.lblClose.BackColor = System.Drawing.Color.Transparent;
			this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.lblClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
			this.lblClose.ForeColor = System.Drawing.Color.Black;
			this.lblClose.Location = new System.Drawing.Point(720, 0);
			this.lblClose.Name = "lblClose";
			this.lblClose.Size = new System.Drawing.Size(50, 50);
			this.lblClose.TabIndex = 1;
			this.lblClose.Text = "X";
			this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Red;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(916, 664);
			this.Controls.Add(this.pnlBackground);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Form1";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Red;
			this.pnlBackground.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlBackground;
		private System.Windows.Forms.Panel pnlContent;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lblPin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblClose;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Button btnLoadSave;
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.Button btnWaypoints;
		private System.Windows.Forms.Button btnMFDs;
		private System.Windows.Forms.Button btnRadios;
		private System.Windows.Forms.Button btnCMS;
	}
}