using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base;

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
        DTC.Utilities.Network.CockpitInfoReceiver.DataReceived -= DataReceiver_DataReceived;
        DTC.Utilities.Network.CockpitInfoReceiver.Stop();
        presetNamedPipeImport.Stop();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        pnlBackground = new Panel();
        lblVersion = new Label();
        pnlContent = new Panel();
        btnKneeboard = new PictureBox();
        btnUpload = new LinkLabel();
        pnlPages = new Panel();
        panel1 = new Panel();
        breadCrumbs = new DTCBreadCrumb();
        panel2 = new Panel();
        pnlTop = new Panel();
        lblMinimize = new Label();
        lblPin = new Label();
        label1 = new Label();
        lblClose = new Label();
        tooltip = new ToolTip(components);
        pnlBackground.SuspendLayout();
        pnlContent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)btnKneeboard).BeginInit();
        pnlTop.SuspendLayout();
        SuspendLayout();
        // 
        // pnlBackground
        // 
        pnlBackground.BackgroundImage = Properties.Resources.tablet;
        pnlBackground.Controls.Add(lblVersion);
        pnlBackground.Controls.Add(pnlContent);
        pnlBackground.Dock = DockStyle.Fill;
        pnlBackground.Location = new Point(0, 0);
        pnlBackground.Name = "pnlBackground";
        pnlBackground.Size = new Size(916, 664);
        pnlBackground.TabIndex = 0;
        pnlBackground.MouseDown += pnlBackground_MouseDown;
        // 
        // lblVersion
        // 
        lblVersion.BackColor = Color.Transparent;
        lblVersion.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
        lblVersion.Location = new Point(382, 83);
        lblVersion.Name = "lblVersion";
        lblVersion.RightToLeft = RightToLeft.No;
        lblVersion.Size = new Size(151, 19);
        lblVersion.TabIndex = 1;
        lblVersion.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = Color.Black;
        pnlContent.Controls.Add(btnKneeboard);
        pnlContent.Controls.Add(btnUpload);
        pnlContent.Controls.Add(pnlPages);
        pnlContent.Controls.Add(panel1);
        pnlContent.Controls.Add(breadCrumbs);
        pnlContent.Controls.Add(panel2);
        pnlContent.Controls.Add(pnlTop);
        pnlContent.Location = new Point(72, 111);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(770, 450);
        pnlContent.TabIndex = 0;
        // 
        // btnKneeboard
        // 
        btnKneeboard.BackColor = Color.DarkGoldenrod;
        btnKneeboard.BackgroundImage = Properties.Resources.clipboard;
        btnKneeboard.BackgroundImageLayout = ImageLayout.Center;
        btnKneeboard.Cursor = Cursors.Hand;
        btnKneeboard.Location = new Point(654, 34);
        btnKneeboard.Name = "btnKneeboard";
        btnKneeboard.Size = new Size(25, 25);
        btnKneeboard.TabIndex = 2;
        btnKneeboard.TabStop = false;
        tooltip.SetToolTip(btnKneeboard, "Kneeboard");
        btnKneeboard.Click += btnKneeboard_Click;
        // 
        // btnUpload
        // 
        btnUpload.ActiveLinkColor = Color.Black;
        btnUpload.AutoSize = true;
        btnUpload.BackColor = Color.DarkGoldenrod;
        btnUpload.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
        btnUpload.LinkBehavior = LinkBehavior.HoverUnderline;
        btnUpload.LinkColor = Color.Black;
        btnUpload.Location = new Point(698, 36);
        btnUpload.Name = "btnUpload";
        btnUpload.Size = new Size(66, 20);
        btnUpload.TabIndex = 0;
        btnUpload.TabStop = true;
        btnUpload.Text = "Upload";
        btnUpload.LinkClicked += btnUpload_LinkClicked;
        // 
        // pnlPages
        // 
        pnlPages.BackColor = Color.PaleGoldenrod;
        pnlPages.Dock = DockStyle.Fill;
        pnlPages.Location = new Point(0, 62);
        pnlPages.Name = "pnlPages";
        pnlPages.Size = new Size(770, 388);
        pnlPages.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.BackColor = Color.Olive;
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 61);
        panel1.Name = "panel1";
        panel1.Size = new Size(770, 1);
        panel1.TabIndex = 0;
        // 
        // breadCrumbs
        // 
        breadCrumbs.BackColor = Color.DarkGoldenrod;
        breadCrumbs.Dock = DockStyle.Top;
        breadCrumbs.Location = new Point(0, 31);
        breadCrumbs.Name = "breadCrumbs";
        breadCrumbs.Size = new Size(770, 30);
        breadCrumbs.TabIndex = 0;
        // 
        // panel2
        // 
        panel2.BackColor = Color.DarkOliveGreen;
        panel2.Dock = DockStyle.Top;
        panel2.Location = new Point(0, 30);
        panel2.Name = "panel2";
        panel2.Size = new Size(770, 1);
        panel2.TabIndex = 1;
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.DarkKhaki;
        pnlTop.BackgroundImage = Properties.Resources._2560px_Brown_dominant__highland__ERDL_camouflage_pattern_swatch_svg;
        pnlTop.Controls.Add(lblMinimize);
        pnlTop.Controls.Add(lblPin);
        pnlTop.Controls.Add(label1);
        pnlTop.Controls.Add(lblClose);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(770, 30);
        pnlTop.TabIndex = 0;
        // 
        // lblMinimize
        // 
        lblMinimize.BackColor = Color.Transparent;
        lblMinimize.Cursor = Cursors.Hand;
        lblMinimize.Dock = DockStyle.Right;
        lblMinimize.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblMinimize.ForeColor = Color.Black;
        lblMinimize.Location = new Point(620, 0);
        lblMinimize.Name = "lblMinimize";
        lblMinimize.Size = new Size(50, 30);
        lblMinimize.TabIndex = 4;
        lblMinimize.Text = "_";
        lblMinimize.TextAlign = ContentAlignment.MiddleCenter;
        lblMinimize.Click += lblMinimize_Click;
        // 
        // lblPin
        // 
        lblPin.BackColor = Color.Transparent;
        lblPin.Cursor = Cursors.Hand;
        lblPin.Dock = DockStyle.Right;
        lblPin.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblPin.Image = Properties.Resources.pin;
        lblPin.Location = new Point(670, 0);
        lblPin.Name = "lblPin";
        lblPin.Size = new Size(50, 30);
        lblPin.TabIndex = 3;
        lblPin.TextAlign = ContentAlignment.MiddleCenter;
        lblPin.Click += lblPin_Click;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        label1.BackColor = Color.Transparent;
        label1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
        label1.ForeColor = Color.Black;
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(99, 30);
        label1.TabIndex = 0;
        label1.Text = "DCS DTC";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblClose
        // 
        lblClose.BackColor = Color.Transparent;
        lblClose.Cursor = Cursors.Hand;
        lblClose.Dock = DockStyle.Right;
        lblClose.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblClose.ForeColor = Color.Black;
        lblClose.Location = new Point(720, 0);
        lblClose.Name = "lblClose";
        lblClose.Size = new Size(50, 30);
        lblClose.TabIndex = 1;
        lblClose.Text = "X";
        lblClose.TextAlign = ContentAlignment.MiddleCenter;
        lblClose.Click += lblClose_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(1, 1, 1);
        BackgroundImageLayout = ImageLayout.Center;
        ClientSize = new Size(916, 664);
        Controls.Add(pnlBackground);
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        StartPosition = FormStartPosition.Manual;
        Text = "DTC for DCS";
        TopMost = true;
        TransparencyKey = Color.FromArgb(1, 1, 1);
        Load += MainForm_Load;
        pnlBackground.ResumeLayout(false);
        pnlContent.ResumeLayout(false);
        pnlContent.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)btnKneeboard).EndInit();
        pnlTop.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlBackground;
    private Panel pnlContent;
    private Panel pnlTop;
    private Label lblPin;
    private Label label1;
    private Label lblClose;
    private Panel pnlPages;
    private DTCBreadCrumb breadCrumbs;
    private Label lblMinimize;
    private Label lblVersion;
    private Panel panel1;
    private Panel panel2;
    private LinkLabel btnUpload;
    private ToolTip tooltip;
    private PictureBox btnKneeboard;
}