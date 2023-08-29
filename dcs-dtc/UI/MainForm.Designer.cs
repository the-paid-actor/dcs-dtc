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
			DTC.Utilities.DataReceiver.DataReceived -= DataReceiver_DataReceived;
			DTC.Utilities.DataReceiver.Stop();
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlPages = new System.Windows.Forms.Panel();
            this.breadCrumbs = new DTC.UI.Base.Controls.DTCBreadCrumb();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblPin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.pnlBackground.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackgroundImage = global::DTC.Properties.Resources.tablet;
            this.pnlBackground.Controls.Add(this.lblVersion);
            this.pnlBackground.Controls.Add(this.pnlContent);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(916, 664);
            this.pnlBackground.TabIndex = 0;
            this.pnlBackground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBackground_MouseDown);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(382, 83);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(151, 19);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Black;
            this.pnlContent.Controls.Add(this.pnlPages);
            this.pnlContent.Controls.Add(this.breadCrumbs);
            this.pnlContent.Controls.Add(this.pnlTop);
            this.pnlContent.Location = new System.Drawing.Point(72, 111);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(770, 450);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlPages
            // 
            this.pnlPages.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pnlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPages.Location = new System.Drawing.Point(0, 60);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(770, 390);
            this.pnlPages.TabIndex = 4;
            // 
            // breadCrumbs
            // 
            this.breadCrumbs.BackColor = System.Drawing.Color.DarkKhaki;
            this.breadCrumbs.Dock = System.Windows.Forms.DockStyle.Top;
            this.breadCrumbs.Location = new System.Drawing.Point(0, 30);
            this.breadCrumbs.Name = "breadCrumbs";
            this.breadCrumbs.Size = new System.Drawing.Size(770, 30);
            this.breadCrumbs.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnlTop.BackgroundImage = global::DTC.Properties.Resources._2560px_Brown_dominant__highland__ERDL_camouflage_pattern_swatch_svg;
            this.pnlTop.Controls.Add(this.lblMinimize);
            this.pnlTop.Controls.Add(this.lblPin);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.lblClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(770, 30);
            this.pnlTop.TabIndex = 2;
            // 
            // lblMinimize
            // 
            this.lblMinimize.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMinimize.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblMinimize.ForeColor = System.Drawing.Color.Black;
            this.lblMinimize.Location = new System.Drawing.Point(620, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(50, 30);
            this.lblMinimize.TabIndex = 4;
            this.lblMinimize.Text = "_";
            this.lblMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
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
            this.lblPin.Size = new System.Drawing.Size(50, 30);
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
            this.label1.Size = new System.Drawing.Size(99, 30);
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
            this.lblClose.Size = new System.Drawing.Size(50, 30);
            this.lblClose.TabIndex = 1;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(916, 664);
            this.Controls.Add(this.pnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DTC for DCS";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(1)))), ((int)(((byte)(1)))));
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlBackground.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
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
		private System.Windows.Forms.Panel pnlPages;
		private Base.Controls.DTCBreadCrumb breadCrumbs;
		private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblVersion;
    }
}