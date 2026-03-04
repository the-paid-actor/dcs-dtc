using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    partial class Radios6PageControl
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
            radio1 = new Radio6Control();
            SuspendLayout();
            // 
            // radio1
            // 
            radio1.AutoScroll = true;
            radio1.BackColor = Color.PaleGoldenrod;
            radio1.Dock = DockStyle.Fill;
            radio1.Location = new Point(0, 0);
            radio1.Name = "radio1";
            radio1.Size = new Size(500, 500);
            radio1.TabIndex = 1;
            // 
            // Radios6PageControl
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(radio1);
            Name = "Radios6PageControl";
            Size = new Size(500, 500);
            ResumeLayout(false);
        }

        #endregion

        private Radio6Control radio1;
    }
}
