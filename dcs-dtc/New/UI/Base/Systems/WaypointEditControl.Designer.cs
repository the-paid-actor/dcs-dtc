using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    partial class WaypointEditControl
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
            label3 = new Label();
            pnlTop = new Panel();
            btnCancel = new DTCButton();
            btnSave = new DTCButton();
            label1 = new Label();
            label2 = new Label();
            lblValidation = new Label();
            txtName = new DTCTextBox();
            txtCoordinate = new DTCCoordinateTextBox2();
            txtElevation = new DTCNumericTextBox();
            pnlCustomControls = new Panel();
            label4 = new Label();
            txtSequence = new DTCNumericTextBox();
            label6 = new Label();
            txtTimeOverSteerpoint = new DTCTimeTextBox();
            chkTarget = new DTCCheckBox();
            btnSearchAirbases = new DTCButton();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1, 40);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(5, 0, 0, 0);
            label3.Size = new Size(150, 25);
            label3.TabIndex = 15;
            label3.Text = "Waypoint Name:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.PaleGoldenrod;
            pnlTop.Controls.Add(btnCancel);
            pnlTop.Controls.Add(btnSave);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(588, 35);
            pnlTop.TabIndex = 25;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkKhaki;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(90, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 25);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += CancelButtonClick;
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
            btnSave.TabIndex = 7;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += SaveButtonClick;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1, 71);
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
            label2.Location = new Point(1, 102);
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
            lblValidation.BackColor = Color.PaleGoldenrod;
            lblValidation.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblValidation.ForeColor = Color.Red;
            lblValidation.Location = new Point(5, 638);
            lblValidation.Margin = new Padding(0);
            lblValidation.Name = "lblValidation";
            lblValidation.Padding = new Padding(5, 0, 0, 0);
            lblValidation.Size = new Size(578, 25);
            lblValidation.TabIndex = 28;
            lblValidation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.AllowPromptAsInput = true;
            txtName.BackColor = SystemColors.Window;
            txtName.HidePromptOnLeave = false;
            txtName.InsertKeyMode = InsertKeyMode.Default;
            txtName.Location = new Point(163, 40);
            txtName.Mask = "";
            txtName.Name = "txtName";
            txtName.PromptChar = '_';
            txtName.Size = new Size(244, 25);
            txtName.TabIndex = 1;
            txtName.ValidatingType = null;
            // 
            // txtCoordinate
            // 
            txtCoordinate.BackColor = SystemColors.Window;
            txtCoordinate.ButtonVisible = true;
            txtCoordinate.Coordinate = null;
            txtCoordinate.CoordinateConverterParent = null;
            txtCoordinate.Format = Utilities.CoordinateFormat.DegreesMinutesThousandths;
            txtCoordinate.Location = new Point(163, 71);
            txtCoordinate.Name = "txtCoordinate";
            txtCoordinate.Size = new Size(288, 25);
            txtCoordinate.TabIndex = 3;
            txtCoordinate.ElevationPasted += ElevationPasted;
            // 
            // txtElevation
            // 
            txtElevation.AllowFraction = false;
            txtElevation.BackColor = SystemColors.Window;
            txtElevation.Location = new Point(163, 102);
            txtElevation.MaximumValue = new decimal(new int[] { 25000, 0, 0, 0 });
            txtElevation.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtElevation.Name = "txtElevation";
            txtElevation.Size = new Size(130, 25);
            txtElevation.TabIndex = 5;
            txtElevation.Unit = DTCNumericTextBox.UnitEnum.Feet;
            txtElevation.Value = null;
            // 
            // pnlCustomControls
            // 
            pnlCustomControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCustomControls.Location = new Point(0, 133);
            pnlCustomControls.Name = "pnlCustomControls";
            pnlCustomControls.Size = new Size(588, 502);
            pnlCustomControls.TabIndex = 7;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(454, 40);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 0, 0, 0);
            label4.Size = new Size(81, 25);
            label4.TabIndex = 15;
            label4.Text = "Sequence:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSequence
            // 
            txtSequence.AllowFraction = false;
            txtSequence.BackColor = SystemColors.Window;
            txtSequence.Location = new Point(538, 40);
            txtSequence.MaximumValue = new decimal(new int[] { 999, 0, 0, 0 });
            txtSequence.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtSequence.Name = "txtSequence";
            txtSequence.Size = new Size(45, 25);
            txtSequence.TabIndex = 2;
            txtSequence.Unit = DTCNumericTextBox.UnitEnum.None;
            txtSequence.Value = null;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(297, 102);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Padding = new Padding(5, 0, 0, 0);
            label6.Size = new Size(160, 25);
            label6.TabIndex = 32;
            label6.Text = "Time Over Steerpoint:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTimeOverSteerpoint
            // 
            txtTimeOverSteerpoint.BackColor = SystemColors.Window;
            txtTimeOverSteerpoint.Location = new Point(457, 102);
            txtTimeOverSteerpoint.Name = "txtTimeOverSteerpoint";
            txtTimeOverSteerpoint.Size = new Size(126, 25);
            txtTimeOverSteerpoint.TabIndex = 6;
            // 
            // chkTarget
            // 
            chkTarget.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkTarget.Location = new Point(457, 72);
            chkTarget.Name = "chkTarget";
            chkTarget.Size = new Size(120, 25);
            chkTarget.TabIndex = 4;
            chkTarget.Text = "Is Target";
            chkTarget.UseVisualStyleBackColor = true;
            // 
            // btnSearchAirbases
            // 
            btnSearchAirbases.BackColor = Color.DarkKhaki;
            btnSearchAirbases.FlatAppearance.BorderSize = 0;
            btnSearchAirbases.FlatStyle = FlatStyle.Flat;
            btnSearchAirbases.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchAirbases.Location = new Point(413, 40);
            btnSearchAirbases.Name = "btnSearchAirbases";
            btnSearchAirbases.Size = new Size(38, 25);
            btnSearchAirbases.TabIndex = 9;
            btnSearchAirbases.Text = "...";
            btnSearchAirbases.UseVisualStyleBackColor = false;
            btnSearchAirbases.Click += AirbaseSearchClicked;
            // 
            // WaypointEditControl
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(btnSearchAirbases);
            Controls.Add(chkTarget);
            Controls.Add(label6);
            Controls.Add(txtTimeOverSteerpoint);
            Controls.Add(pnlCustomControls);
            Controls.Add(lblValidation);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(txtCoordinate);
            Controls.Add(txtSequence);
            Controls.Add(txtElevation);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pnlTop);
            Name = "WaypointEditControl";
            Size = new Size(588, 668);
            pnlTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlTop;
        private Label label3;
        private DTCButton btnSave;
        private Label label1;
        private Label label2;
        private DTCButton btnCancel;
        private Label label4;
        protected DTCCoordinateTextBox2 txtCoordinate;
        protected DTCTextBox txtName;
        protected DTCNumericTextBox txtElevation;
        protected Label lblValidation;
        protected Panel pnlCustomControls;
        protected DTCNumericTextBox txtSequence;
        private Label label6;
        protected DTCTimeTextBox txtTimeOverSteerpoint;
        protected DTCCheckBox chkTarget;
        private DTCButton btnSearchAirbases;
    }
}
