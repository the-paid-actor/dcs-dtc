
namespace DTC.New.UI.Aircrafts.F16.Systems
{
    partial class HARMHTSPage
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
            pnlHTS = new Panel();
            pnlHARM = new Panel();
            SuspendLayout();
            // 
            // pnlHTS
            // 
            pnlHTS.Dock = DockStyle.Fill;
            pnlHTS.Location = new Point(310, 0);
            pnlHTS.Name = "pnlHTS";
            pnlHTS.Size = new Size(55, 301);
            pnlHTS.TabIndex = 0;
            // 
            // pnlHARM
            // 
            pnlHARM.Dock = DockStyle.Left;
            pnlHARM.Location = new Point(0, 0);
            pnlHARM.Name = "pnlHARM";
            pnlHARM.Size = new Size(310, 301);
            pnlHARM.TabIndex = 1;
            // 
            // HARMHTSPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(pnlHTS);
            Controls.Add(pnlHARM);
            Margin = new Padding(2);
            Name = "HARMHTSPage";
            Size = new Size(365, 301);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHTS;
        private Panel pnlHARM;
    }
}
