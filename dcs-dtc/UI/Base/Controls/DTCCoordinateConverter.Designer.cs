namespace DTC.UI.Base.Controls
{
    partial class DTCCoordinateConverter
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
            btnOK = new DTCButton();
            txtMGRS = new DTCCoordinateTextBox2();
            dtcLabel2 = new DTCLabel();
            dtcLabel3 = new DTCLabel();
            txtLatLongDDMMMMM = new DTCCoordinateTextBox2();
            dtcLabel4 = new DTCLabel();
            txtLatLongDDMMSS = new DTCCoordinateTextBox2();
            dtcLabel5 = new DTCLabel();
            txtLatLongDDMMSSSS = new DTCCoordinateTextBox2();
            btnCancel = new DTCButton();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.DarkKhaki;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOK.Location = new Point(5, 5);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 25);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // txtMGRS
            // 
            txtMGRS.BackColor = SystemColors.Window;
            txtMGRS.ButtonVisible = false;
            txtMGRS.Coordinate = null;
            txtMGRS.Format = Utilities.CoordinateFormat.MGRSTenDigits;
            txtMGRS.Location = new Point(205, 131);
            txtMGRS.Name = "txtMGRS";
            txtMGRS.Size = new Size(215, 25);
            txtMGRS.TabIndex = 5;
            // 
            // dtcLabel2
            // 
            dtcLabel2.AutoSize = true;
            dtcLabel2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtcLabel2.Location = new Point(6, 131);
            dtcLabel2.Name = "dtcLabel2";
            dtcLabel2.Size = new Size(53, 17);
            dtcLabel2.TabIndex = 0;
            dtcLabel2.Text = "MGRS:";
            dtcLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtcLabel3
            // 
            dtcLabel3.AutoSize = true;
            dtcLabel3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtcLabel3.Location = new Point(6, 40);
            dtcLabel3.Name = "dtcLabel3";
            dtcLabel3.Size = new Size(155, 17);
            dtcLabel3.TabIndex = 0;
            dtcLabel3.Text = "Lat/Long DD.MM.MMM:";
            dtcLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLatLongDDMMMMM
            // 
            txtLatLongDDMMMMM.BackColor = SystemColors.Window;
            txtLatLongDDMMMMM.ButtonVisible = false;
            txtLatLongDDMMMMM.Coordinate = null;
            txtLatLongDDMMMMM.Format = Utilities.CoordinateFormat.DegreesMinutesThousandths;
            txtLatLongDDMMMMM.Location = new Point(205, 40);
            txtLatLongDDMMMMM.Name = "txtLatLongDDMMMMM";
            txtLatLongDDMMMMM.Size = new Size(215, 25);
            txtLatLongDDMMMMM.TabIndex = 2;
            // 
            // dtcLabel4
            // 
            dtcLabel4.AutoSize = true;
            dtcLabel4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtcLabel4.Location = new Point(6, 70);
            dtcLabel4.Name = "dtcLabel4";
            dtcLabel4.Size = new Size(140, 17);
            dtcLabel4.TabIndex = 0;
            dtcLabel4.Text = "Lat/Long DD.MM.SS:";
            dtcLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLatLongDDMMSS
            // 
            txtLatLongDDMMSS.BackColor = SystemColors.Window;
            txtLatLongDDMMSS.ButtonVisible = false;
            txtLatLongDDMMSS.Coordinate = null;
            txtLatLongDDMMSS.Format = Utilities.CoordinateFormat.DegreesMinutesSeconds;
            txtLatLongDDMMSS.Location = new Point(205, 70);
            txtLatLongDDMMSS.Name = "txtLatLongDDMMSS";
            txtLatLongDDMMSS.Size = new Size(215, 25);
            txtLatLongDDMMSS.TabIndex = 3;
            // 
            // dtcLabel5
            // 
            dtcLabel5.AutoSize = true;
            dtcLabel5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtcLabel5.Location = new Point(6, 100);
            dtcLabel5.Name = "dtcLabel5";
            dtcLabel5.Size = new Size(162, 17);
            dtcLabel5.TabIndex = 0;
            dtcLabel5.Text = "Lat/Long DD.MM.SS.SS:";
            dtcLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLatLongDDMMSSSS
            // 
            txtLatLongDDMMSSSS.BackColor = SystemColors.Window;
            txtLatLongDDMMSSSS.ButtonVisible = false;
            txtLatLongDDMMSSSS.Coordinate = null;
            txtLatLongDDMMSSSS.Format = Utilities.CoordinateFormat.DegreesMinutesSecondsHundredths;
            txtLatLongDDMMSSSS.Location = new Point(205, 100);
            txtLatLongDDMMSSSS.Name = "txtLatLongDDMMSSSS";
            txtLatLongDDMMSSSS.Size = new Size(215, 25);
            txtLatLongDDMMSSSS.TabIndex = 4;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkKhaki;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(90, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 25);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // DTCCoordinateConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(txtLatLongDDMMSSSS);
            Controls.Add(txtLatLongDDMMSS);
            Controls.Add(txtLatLongDDMMMMM);
            Controls.Add(txtMGRS);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(dtcLabel5);
            Controls.Add(dtcLabel4);
            Controls.Add(dtcLabel3);
            Controls.Add(dtcLabel2);
            Name = "DTCCoordinateConverter";
            Size = new Size(578, 486);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DTCButton btnOK;
        private DTCCoordinateTextBox2 txtMGRS;
        private DTCLabel dtcLabel2;
        private DTCLabel dtcLabel3;
        private DTCCoordinateTextBox2 txtLatLongDDMMMMM;
        private DTCLabel dtcLabel4;
        private DTCCoordinateTextBox2 txtLatLongDDMMSS;
        private DTCLabel dtcLabel5;
        private DTCCoordinateTextBox2 txtLatLongDDMMSSSS;
        private DTCButton btnCancel;
    }
}
