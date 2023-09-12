namespace DTC.UI.Aircrafts.FA18
{
    partial class PrePlannedPage
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
            this.cbSta5 = new DTC.UI.Base.Controls.DTCCheckBox();
            this.btnOverview = new DTC.UI.Base.Controls.DTCButton();
            this.prePlannedStationControl2 = new DTC.UI.Aircrafts.FA18.CompositeControls.PrePlannedStationControl();
            this.prePlannedStationControl3 = new DTC.UI.Aircrafts.FA18.CompositeControls.PrePlannedStationControl();
            this.prePlannedStationControl7 = new DTC.UI.Aircrafts.FA18.CompositeControls.PrePlannedStationControl();
            this.prePlannedStationControl8 = new DTC.UI.Aircrafts.FA18.CompositeControls.PrePlannedStationControl();
            this.SuspendLayout();
            // 
            // cbSta5
            // 
            this.cbSta5.AutoSize = true;
            this.cbSta5.Location = new System.Drawing.Point(14, 168);
            this.cbSta5.Name = "cbSta5";
            this.cbSta5.Size = new System.Drawing.Size(188, 17);
            this.cbSta5.TabIndex = 13;
            this.cbSta5.Text = "Station 5 has Bomb/DataLink Pod";
            this.cbSta5.UseVisualStyleBackColor = true;
            this.cbSta5.CheckedChanged += new System.EventHandler(this.cbSta5_CheckedChanged);
            // 
            // btnOverview
            // 
            this.btnOverview.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnOverview.FlatAppearance.BorderSize = 0;
            this.btnOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnOverview.Location = new System.Drawing.Point(14, 355);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.Size = new System.Drawing.Size(136, 24);
            this.btnOverview.TabIndex = 12;
            this.btnOverview.Text = "Show Overview";
            this.btnOverview.UseVisualStyleBackColor = false;
            this.btnOverview.Click += new System.EventHandler(this.btnOverview_click);
            // 
            // prePlannedStationControl2
            // 
            this.prePlannedStationControl2.Location = new System.Drawing.Point(14, 17);
            this.prePlannedStationControl2.Margin = new System.Windows.Forms.Padding(0);
            this.prePlannedStationControl2.Name = "prePlannedStationControl2";
            this.prePlannedStationControl2.Size = new System.Drawing.Size(505, 68);
            this.prePlannedStationControl2.TabIndex = 14;
            // 
            // prePlannedStationControl3
            // 
            this.prePlannedStationControl3.Location = new System.Drawing.Point(14, 91);
            this.prePlannedStationControl3.Margin = new System.Windows.Forms.Padding(0);
            this.prePlannedStationControl3.Name = "prePlannedStationControl3";
            this.prePlannedStationControl3.Size = new System.Drawing.Size(505, 68);
            this.prePlannedStationControl3.TabIndex = 15;
            // 
            // prePlannedStationControl7
            // 
            this.prePlannedStationControl7.Location = new System.Drawing.Point(14, 194);
            this.prePlannedStationControl7.Margin = new System.Windows.Forms.Padding(0);
            this.prePlannedStationControl7.Name = "prePlannedStationControl7";
            this.prePlannedStationControl7.Size = new System.Drawing.Size(505, 68);
            this.prePlannedStationControl7.TabIndex = 16;
            // 
            // prePlannedStationControl8
            // 
            this.prePlannedStationControl8.Location = new System.Drawing.Point(14, 268);
            this.prePlannedStationControl8.Margin = new System.Windows.Forms.Padding(0);
            this.prePlannedStationControl8.Name = "prePlannedStationControl8";
            this.prePlannedStationControl8.Size = new System.Drawing.Size(505, 68);
            this.prePlannedStationControl8.TabIndex = 17;
            // 
            // PrePlannedPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.prePlannedStationControl8);
            this.Controls.Add(this.prePlannedStationControl7);
            this.Controls.Add(this.prePlannedStationControl3);
            this.Controls.Add(this.prePlannedStationControl2);
            this.Controls.Add(this.btnOverview);
            this.Controls.Add(this.cbSta5);
            this.Name = "PrePlannedPage";
            this.Size = new System.Drawing.Size(532, 393);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Base.Controls.DTCCheckBox cbSta5;
        private Base.Controls.DTCButton btnOverview;
        private CompositeControls.PrePlannedStationControl prePlannedStationControl2;
        private CompositeControls.PrePlannedStationControl prePlannedStationControl3;
        private CompositeControls.PrePlannedStationControl prePlannedStationControl7;
        private CompositeControls.PrePlannedStationControl prePlannedStationControl8;
    }
}
