
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.FA18
{
    partial class WaypointEdit
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
            cboAirbases = new ComboBox();
            label5 = new Label();
            lblTitle = new Label();
            label3 = new Label();
            btnCapture = new Button();
            btnSave = new DTCButton();
            pnlTop = new Panel();
            lblClose = new Label();
            txtWptName = new DTCTextBox();
            txtWptElevation = new DTCTextBox();
            txtWptLatLong = new DTCCoordinateTextBox2();
            label1 = new Label();
            label2 = new Label();
            lblValidation = new Label();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // cboAirbases
            // 
            cboAirbases.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAirbases.FlatStyle = FlatStyle.Flat;
            cboAirbases.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cboAirbases.FormattingEnabled = true;
            cboAirbases.Location = new Point(152, 36);
            cboAirbases.Name = "cboAirbases";
            cboAirbases.Size = new Size(395, 28);
            cboAirbases.TabIndex = 10;
            cboAirbases.SelectedIndexChanged += cboAirbases_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(1, 36);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 0, 0, 0);
            label5.Size = new Size(150, 25);
            label5.TabIndex = 14;
            label5.Text = "Airbases:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10, 0, 0, 0);
            lblTitle.Size = new Size(508, 30);
            lblTitle.TabIndex = 22;
            lblTitle.Text = "Add Waypoint";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1, 70);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 0, 0, 0);
            label3.Size = new Size(150, 25);
            label3.TabIndex = 15;
            label3.Text = "Waypoint Name:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCapture
            // 
            btnCapture.BackColor = Color.DarkKhaki;
            btnCapture.FlatAppearance.BorderSize = 0;
            btnCapture.FlatStyle = FlatStyle.Flat;
            btnCapture.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCapture.Location = new Point(427, 104);
            btnCapture.Name = "btnCapture";
            btnCapture.Size = new Size(120, 25);
            btnCapture.TabIndex = 13;
            btnCapture.Text = "Start Capture";
            btnCapture.UseVisualStyleBackColor = false;
            btnCapture.Click += btnCapture_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(429, 197);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 25);
            btnSave.TabIndex = 16;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.DarkKhaki;
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblClose);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(558, 30);
            pnlTop.TabIndex = 25;
            // 
            // lblClose
            // 
            lblClose.BackColor = Color.Transparent;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Dock = DockStyle.Right;
            lblClose.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblClose.Location = new Point(508, 0);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(50, 30);
            lblClose.TabIndex = 23;
            lblClose.Text = "X";
            lblClose.TextAlign = ContentAlignment.MiddleCenter;
            lblClose.Click += lblClose_Click;
            // 
            // txtWptName
            // 
            txtWptName.AllowPromptAsInput = true;
            txtWptName.BackColor = SystemColors.Window;
            txtWptName.HidePromptOnLeave = false;
            txtWptName.InsertKeyMode = InsertKeyMode.Default;
            txtWptName.Location = new Point(152, 70);
            txtWptName.Mask = "";
            txtWptName.Name = "txtWptName";
            txtWptName.PromptChar = '_';
            txtWptName.Size = new Size(395, 28);
            txtWptName.TabIndex = 11;
            txtWptName.ValidatingType = null;
            // 
            // txtWptElevation
            // 
            txtWptElevation.AllowPromptAsInput = true;
            txtWptElevation.BackColor = SystemColors.Window;
            txtWptElevation.HidePromptOnLeave = false;
            txtWptElevation.InsertKeyMode = InsertKeyMode.Default;
            txtWptElevation.Location = new Point(152, 138);
            txtWptElevation.Mask = "";
            txtWptElevation.Name = "txtWptElevation";
            txtWptElevation.PromptChar = '_';
            txtWptElevation.Size = new Size(100, 28);
            txtWptElevation.TabIndex = 14;
            txtWptElevation.ValidatingType = null;
            // 
            // txtWptLatLong
            // 
            txtWptLatLong.BackColor = SystemColors.Window;
            txtWptLatLong.ButtonVisible = true;
            txtWptLatLong.Coordinate = null;
            txtWptLatLong.Format = Utilities.CoordinateFormat.DegreesMinutesSeconds;
            txtWptLatLong.Location = new Point(152, 104);
            txtWptLatLong.Name = "txtWptLatLong";
            txtWptLatLong.Size = new Size(270, 28);
            txtWptLatLong.TabIndex = 12;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1, 104);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 0, 0, 0);
            label1.Size = new Size(150, 25);
            label1.TabIndex = 26;
            label1.Text = "Lat/Long:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1, 138);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 0, 0, 0);
            label2.Size = new Size(150, 25);
            label2.TabIndex = 27;
            label2.Text = "Elevation:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValidation
            // 
            lblValidation.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblValidation.ForeColor = Color.Red;
            lblValidation.Location = new Point(1, 169);
            lblValidation.Margin = new Padding(0);
            lblValidation.Name = "lblValidation";
            lblValidation.Padding = new Padding(5, 0, 0, 0);
            lblValidation.Size = new Size(548, 25);
            lblValidation.TabIndex = 28;
            lblValidation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // WaypointEdit
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblValidation);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnCapture);
            Controls.Add(txtWptName);
            Controls.Add(txtWptLatLong);
            Controls.Add(txtWptElevation);
            Controls.Add(cboAirbases);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(pnlTop);
            Name = "WaypointEdit";
            Size = new Size(558, 231);
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboAirbases;
        private DTCCoordinateTextBox2 txtWptLatLong;
        private Label label5;
        private DTCTextBox txtWptName;
        private DTCTextBox txtWptElevation;
        private Label lblTitle;
        private Panel pnlTop;
        private Label lblClose;
        private Button btnCapture;
        private Label label3;
        private Base.Controls.DTCButton btnSave;
        private Label label1;
        private Label label2;
        private Label lblValidation;
    }
}
