namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    partial class WaypointEditPanel
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
            label5 = new Label();
            txtMEA = new DTC.UI.Base.Controls.DTCNumericTextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 0, 0, 0);
            label5.Size = new Size(150, 25);
            label5.TabIndex = 15;
            label5.Text = "MEA:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMEA
            // 
            txtMEA.AllowFraction = false;
            txtMEA.BackColor = SystemColors.Window;
            txtMEA.Location = new Point(163, 0);
            txtMEA.MaximumValue = new decimal(new int[] { 60000, 0, 0, 0 });
            txtMEA.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtMEA.Name = "txtMEA";
            txtMEA.Size = new Size(130, 25);
            txtMEA.TabIndex = 16;
            txtMEA.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtMEA.Value = null;
            // 
            // WaypointEditPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(txtMEA);
            Controls.Add(label5);
            Name = "WaypointEditPanel";
            Size = new Size(555, 257);
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtMEA;
    }
}
