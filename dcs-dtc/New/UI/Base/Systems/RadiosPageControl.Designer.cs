using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    partial class RadiosPageControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            radio1 = new RadioControl();
            radio2 = new RadioControl();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(radio1, 0, 0);
            tableLayoutPanel1.Controls.Add(radio2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53F));
            tableLayoutPanel1.Size = new Size(500, 500);
            tableLayoutPanel1.TabIndex = 37;
            // 
            // radio1
            // 
            radio1.BackColor = Color.PaleGoldenrod;
            radio1.Dock = DockStyle.Fill;
            radio1.Location = new Point(3, 3);
            radio1.Name = "radio1";
            radio1.Size = new Size(244, 494);
            radio1.TabIndex = 0;
            // 
            // radio2
            // 
            radio2.BackColor = Color.PaleGoldenrod;
            radio2.Dock = DockStyle.Fill;
            radio2.Location = new Point(253, 3);
            radio2.Name = "radio2";
            radio2.Size = new Size(244, 494);
            radio2.TabIndex = 1;
            // 
            // RadiosPageControl
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(tableLayoutPanel1);
            Name = "RadiosPageControl";
            Size = new Size(500, 500);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private RadioControl radio1;
        private RadioControl radio2;
    }
}
