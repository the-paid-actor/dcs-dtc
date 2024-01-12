namespace DTC.UI.Base.Controls
{
    partial class DTCDividerLine
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.Olive;
            label1.Location = new Point(0, 4);
            label1.Name = "label1";
            label1.Size = new Size(100, 1);
            label1.TabIndex = 0;
            // 
            // DTCDividerLine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkKhaki;
            Controls.Add(label1);
            Name = "DTCDividerLine";
            Size = new Size(100, 9);
            TabStop = false;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}
