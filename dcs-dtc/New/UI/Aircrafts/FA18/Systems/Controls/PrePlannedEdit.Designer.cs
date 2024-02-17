
namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
{
    partial class PrePlannedEdit
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
            label2 = new Label();
            lblValidation = new Label();
            btnSave = new DTC.UI.Base.Controls.DTCButton();
            txtWptLatLong = new DTC.UI.Base.Controls.DTCCoordinateTextBox2();
            txtWptElevation = new DTC.UI.Base.Controls.DTCNumericTextBox();
            dtcButton1 = new DTC.UI.Base.Controls.DTCButton();
            btnClear = new DTC.UI.Base.Controls.DTCButton();
            txtNotes = new DTC.UI.Base.Controls.DTCTextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1, 36);
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
            label2.Location = new Point(1, 67);
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
            lblValidation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblValidation.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblValidation.ForeColor = Color.Red;
            lblValidation.Location = new Point(5, 148);
            lblValidation.Margin = new Padding(0);
            lblValidation.Name = "lblValidation";
            lblValidation.Padding = new Padding(5, 0, 0, 0);
            lblValidation.Size = new Size(548, 25);
            lblValidation.TabIndex = 28;
            lblValidation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(5, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 25);
            btnSave.TabIndex = 16;
            btnSave.Text = "&OK";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtWptLatLong
            // 
            txtWptLatLong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWptLatLong.BackColor = SystemColors.Window;
            txtWptLatLong.ButtonVisible = true;
            txtWptLatLong.Coordinate = null;
            txtWptLatLong.CoordinateConverterParent = null;
            txtWptLatLong.Format = Utilities.CoordinateFormat.DegreesMinutesSecondsHundredths;
            txtWptLatLong.Location = new Point(151, 36);
            txtWptLatLong.Name = "txtWptLatLong";
            txtWptLatLong.Size = new Size(278, 25);
            txtWptLatLong.TabIndex = 12;
            txtWptLatLong.ElevationPasted += txtWptLatLong_ElevationPasted;
            // 
            // txtWptElevation
            // 
            txtWptElevation.AllowFraction = false;
            txtWptElevation.BackColor = SystemColors.Window;
            txtWptElevation.Location = new Point(151, 67);
            txtWptElevation.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtWptElevation.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtWptElevation.Name = "txtWptElevation";
            txtWptElevation.Size = new Size(100, 25);
            txtWptElevation.TabIndex = 14;
            txtWptElevation.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtWptElevation.Value = null;
            // 
            // dtcButton1
            // 
            dtcButton1.BackColor = Color.DarkKhaki;
            dtcButton1.FlatAppearance.BorderSize = 0;
            dtcButton1.FlatStyle = FlatStyle.Flat;
            dtcButton1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtcButton1.Location = new Point(90, 5);
            dtcButton1.Name = "dtcButton1";
            dtcButton1.Size = new Size(80, 25);
            dtcButton1.TabIndex = 16;
            dtcButton1.Text = "&Cancel";
            dtcButton1.UseVisualStyleBackColor = false;
            dtcButton1.Click += lblClose_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.DarkKhaki;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(475, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 25);
            btnClear.TabIndex = 16;
            btnClear.Text = "&Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtNotes
            // 
            txtNotes.AllowPromptAsInput = true;
            txtNotes.BackColor = SystemColors.Window;
            txtNotes.HidePromptOnLeave = false;
            txtNotes.InsertKeyMode = InsertKeyMode.Default;
            txtNotes.Location = new Point(151, 98);
            txtNotes.Mask = "";
            txtNotes.Name = "txtNotes";
            txtNotes.PromptChar = '_';
            txtNotes.Size = new Size(402, 28);
            txtNotes.TabIndex = 31;
            txtNotes.ValidatingType = null;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1, 98);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 0, 0, 0);
            label3.Size = new Size(150, 25);
            label3.TabIndex = 30;
            label3.Text = "Notes:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PrePlannedEdit
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(txtNotes);
            Controls.Add(label3);
            Controls.Add(lblValidation);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(dtcButton1);
            Controls.Add(btnSave);
            Controls.Add(txtWptLatLong);
            Controls.Add(txtWptElevation);
            Name = "PrePlannedEdit";
            Size = new Size(560, 178);
            ResumeLayout(false);
        }

        #endregion
        private DTC.UI.Base.Controls.DTCCoordinateTextBox2 txtWptLatLong;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtWptElevation;
        private DTC.UI.Base.Controls.DTCButton btnSave;
        private Label label1;
        private Label label2;
        private Label lblValidation;
        private DTC.UI.Base.Controls.DTCButton dtcButton1;
        private DTC.UI.Base.Controls.DTCButton btnClear;
        private DTC.UI.Base.Controls.DTCTextBox txtNotes;
        private Label label3;
    }
}
