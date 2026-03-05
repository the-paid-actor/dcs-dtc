namespace DTC.New.UI.Base.Systems
{
    partial class Radio6Control
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
            pnlPresets = new Panel();
            SuspendLayout();
            // 
            // pnlPresets
            // 
            pnlPresets.AutoScroll = true;
            pnlPresets.Dock = DockStyle.Fill;
            pnlPresets.Location = new Point(0, 0);
            pnlPresets.Name = "pnlPresets";
            pnlPresets.Size = new Size(417, 423);
            pnlPresets.TabIndex = 2;
            // 
            // Radio6Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(pnlPresets);
            Name = "Radio6Control";
            Size = new Size(417, 423);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlPresets;
    }
}
