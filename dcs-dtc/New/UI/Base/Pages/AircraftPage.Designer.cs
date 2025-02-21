namespace DTC.New.UI.Base.Pages;

partial class AircraftPage
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
        DTC.Utilities.Network.WaypointCaptureReceiver.DataReceived -= DataReceiver2_DataReceived;
        uploadHelper.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlMain = new Panel();
        pnlLeft = new Panel();
        panel1 = new Panel();
        SuspendLayout();
        // 
        // pnlMain
        // 
        pnlMain.BackColor = Color.PaleGoldenrod;
        pnlMain.Dock = DockStyle.Fill;
        pnlMain.Location = new Point(183, 0);
        pnlMain.Name = "pnlMain";
        pnlMain.Size = new Size(563, 684);
        pnlMain.TabIndex = 6;
        // 
        // pnlLeft
        // 
        pnlLeft.AutoScroll = true;
        pnlLeft.BackColor = Color.DarkKhaki;
        pnlLeft.BackgroundImageLayout = ImageLayout.Stretch;
        pnlLeft.Dock = DockStyle.Left;
        pnlLeft.Location = new Point(0, 0);
        pnlLeft.Margin = new Padding(10);
        pnlLeft.Name = "pnlLeft";
        pnlLeft.Padding = new Padding(5);
        pnlLeft.Size = new Size(182, 684);
        pnlLeft.TabIndex = 5;
        // 
        // panel1
        // 
        panel1.BackColor = Color.Olive;
        panel1.Dock = DockStyle.Left;
        panel1.Location = new Point(182, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(1, 684);
        panel1.TabIndex = 0;
        // 
        // AircraftPage
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        Controls.Add(pnlMain);
        Controls.Add(panel1);
        Controls.Add(pnlLeft);
        Name = "AircraftPage";
        Size = new Size(746, 684);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlMain;
    private System.Windows.Forms.Panel pnlLeft;
    private Panel panel1;
}