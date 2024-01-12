
namespace DTC.New.UI.Aircrafts.FA18.Systems
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
            btnOverview = new DTC.UI.Base.Controls.DTCButton();
            prePlannedStationControl2 = new Controls.PrePlannedStationControl();
            prePlannedStationControl3 = new Controls.PrePlannedStationControl();
            prePlannedStationControl7 = new Controls.PrePlannedStationControl();
            prePlannedStationControl8 = new Controls.PrePlannedStationControl();
            btnResetAllPP = new DTC.UI.Base.Controls.DTCButton();
            SuspendLayout();
            // 
            // btnOverview
            // 
            btnOverview.BackColor = Color.DarkKhaki;
            btnOverview.FlatAppearance.BorderSize = 0;
            btnOverview.FlatStyle = FlatStyle.Flat;
            btnOverview.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOverview.Location = new Point(14, 355);
            btnOverview.Name = "btnOverview";
            btnOverview.Size = new Size(136, 24);
            btnOverview.TabIndex = 12;
            btnOverview.Text = "Show Overview";
            btnOverview.UseVisualStyleBackColor = false;
            btnOverview.Click += btnOverview_click;
            // 
            // prePlannedStationControl2
            // 
            prePlannedStationControl2.BackColor = Color.PaleGoldenrod;
            prePlannedStationControl2.Location = new Point(0, 0);
            prePlannedStationControl2.Margin = new Padding(0);
            prePlannedStationControl2.Name = "prePlannedStationControl2";
            prePlannedStationControl2.Size = new Size(576, 70);
            prePlannedStationControl2.TabIndex = 14;
            // 
            // prePlannedStationControl3
            // 
            prePlannedStationControl3.BackColor = Color.PaleGoldenrod;
            prePlannedStationControl3.Location = new Point(0, 70);
            prePlannedStationControl3.Margin = new Padding(0);
            prePlannedStationControl3.Name = "prePlannedStationControl3";
            prePlannedStationControl3.Size = new Size(576, 68);
            prePlannedStationControl3.TabIndex = 15;
            // 
            // prePlannedStationControl7
            // 
            prePlannedStationControl7.BackColor = Color.PaleGoldenrod;
            prePlannedStationControl7.Location = new Point(0, 138);
            prePlannedStationControl7.Margin = new Padding(0);
            prePlannedStationControl7.Name = "prePlannedStationControl7";
            prePlannedStationControl7.Size = new Size(576, 68);
            prePlannedStationControl7.TabIndex = 16;
            // 
            // prePlannedStationControl8
            // 
            prePlannedStationControl8.BackColor = Color.PaleGoldenrod;
            prePlannedStationControl8.Location = new Point(0, 206);
            prePlannedStationControl8.Margin = new Padding(0);
            prePlannedStationControl8.Name = "prePlannedStationControl8";
            prePlannedStationControl8.Size = new Size(576, 68);
            prePlannedStationControl8.TabIndex = 17;
            // 
            // btnResetAllPP
            // 
            btnResetAllPP.BackColor = Color.DarkKhaki;
            btnResetAllPP.FlatAppearance.BorderSize = 0;
            btnResetAllPP.FlatStyle = FlatStyle.Flat;
            btnResetAllPP.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnResetAllPP.Location = new Point(156, 355);
            btnResetAllPP.Name = "btnResetAllPP";
            btnResetAllPP.Size = new Size(136, 24);
            btnResetAllPP.TabIndex = 12;
            btnResetAllPP.Text = "Reset All PP";
            btnResetAllPP.UseVisualStyleBackColor = false;
            btnResetAllPP.Click += btnResetAllPP_Click;
            // 
            // PrePlannedPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(prePlannedStationControl8);
            Controls.Add(prePlannedStationControl7);
            Controls.Add(prePlannedStationControl3);
            Controls.Add(prePlannedStationControl2);
            Controls.Add(btnResetAllPP);
            Controls.Add(btnOverview);
            Name = "PrePlannedPage";
            Size = new Size(576, 393);
            ResumeLayout(false);
        }

        #endregion
        private DTC.UI.Base.Controls.DTCButton btnOverview;
        private DTC.New.UI.Aircrafts.FA18.Systems.Controls.PrePlannedStationControl prePlannedStationControl2;
        private DTC.New.UI.Aircrafts.FA18.Systems.Controls.PrePlannedStationControl prePlannedStationControl3;
        private DTC.New.UI.Aircrafts.FA18.Systems.Controls.PrePlannedStationControl prePlannedStationControl7;
        private DTC.New.UI.Aircrafts.FA18.Systems.Controls.PrePlannedStationControl prePlannedStationControl8;
        private DTC.UI.Base.Controls.DTCButton btnResetAllPP;
    }
}
