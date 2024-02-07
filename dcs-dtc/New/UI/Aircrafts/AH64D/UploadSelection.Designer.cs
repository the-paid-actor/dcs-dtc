namespace DTC.New.UI.Aircrafts.AH64D
{
    partial class UploadSelection
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
            btnPilot = new DTC.UI.Base.Controls.DTCButton();
            btnGunner = new DTC.UI.Base.Controls.DTCButton();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnPilot
            // 
            btnPilot.Anchor = AnchorStyles.None;
            btnPilot.BackColor = Color.DarkKhaki;
            btnPilot.FlatAppearance.BorderSize = 0;
            btnPilot.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnPilot.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnPilot.FlatStyle = FlatStyle.Flat;
            btnPilot.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnPilot.Location = new Point(40, 140);
            btnPilot.Name = "btnPilot";
            btnPilot.Size = new Size(150, 40);
            btnPilot.TabIndex = 0;
            btnPilot.Text = "Pilot Seat";
            btnPilot.UseVisualStyleBackColor = false;
            btnPilot.Click += btnPilot_Click;
            // 
            // btnGunner
            // 
            btnGunner.Anchor = AnchorStyles.None;
            btnGunner.BackColor = Color.DarkKhaki;
            btnGunner.FlatAppearance.BorderSize = 0;
            btnGunner.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnGunner.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnGunner.FlatStyle = FlatStyle.Flat;
            btnGunner.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnGunner.Location = new Point(210, 140);
            btnGunner.Name = "btnGunner";
            btnGunner.Size = new Size(150, 40);
            btnGunner.TabIndex = 0;
            btnGunner.Text = "Gunner Seat";
            btnGunner.UseVisualStyleBackColor = false;
            btnGunner.Click += btnGunner_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 203);
            label1.Name = "label1";
            label1.Size = new Size(400, 103);
            label1.TabIndex = 1;
            label1.Text = "WARNING\r\nIn multiplayer, make sure you select the station you are currently seated in. Selecting the wrong station can have unintended consequences.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UploadSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(btnGunner);
            Controls.Add(btnPilot);
            Name = "UploadSelection";
            Size = new Size(400, 400);
            ResumeLayout(false);
        }

        #endregion

        private DTC.UI.Base.Controls.DTCButton btnPilot;
        private DTC.UI.Base.Controls.DTCButton btnGunner;
        private Label label1;
    }
}
