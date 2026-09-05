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
            chkOffset = new DTC.UI.Base.Controls.DTCCheckBox();
            radioButtonDirectCoordinates = new RadioButton();
            radioButtonRelativeDirRng = new RadioButton();
            radioButtonRelativeLatLong = new RadioButton();
            groupBoxCoordinatesMode = new GroupBox();
            labelDirection = new Label();
            txtDirection = new DTC.UI.Base.Controls.DTCNumericTextBox();
            labelRange = new Label();
            txtRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            cmbLatitudeDirection = new ComboBox();
            labelRelativeLatitude = new Label();
            txtRelativeLatitude = new DTC.UI.Base.Controls.DTCNumericTextBox();
            cmbLongitudeDirection = new ComboBox();
            labelRelativeLongitude = new Label();
            txtRelativeLongitude = new DTC.UI.Base.Controls.DTCNumericTextBox();
            groupBoxCoordinatesMode.SuspendLayout();
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
            txtMEA.AllowNegative = false;
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
            // chkOffset
            // 
            chkOffset.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkOffset.Location = new Point(402, 3);
            chkOffset.Name = "chkOffset";
            chkOffset.Size = new Size(150, 25);
            chkOffset.TabIndex = 17;
            chkOffset.Text = "Is Offset/Aim Point";
            chkOffset.UseVisualStyleBackColor = true;
            chkOffset.CheckedChanged += CoordinateModeChanged;
            // 
            // radioButtonDirectCoordinates
            // 
            radioButtonDirectCoordinates.AutoSize = true;
            radioButtonDirectCoordinates.Checked = true;
            radioButtonDirectCoordinates.Location = new Point(6, 23);
            radioButtonDirectCoordinates.Name = "radioButtonDirectCoordinates";
            radioButtonDirectCoordinates.Size = new Size(123, 19);
            radioButtonDirectCoordinates.TabIndex = 18;
            radioButtonDirectCoordinates.TabStop = true;
            radioButtonDirectCoordinates.Text = "Direct Coordinates";
            radioButtonDirectCoordinates.UseVisualStyleBackColor = true;
            radioButtonDirectCoordinates.CheckedChanged += CoordinateModeChanged;
            // 
            // radioButtonRelativeDirRng
            // 
            radioButtonRelativeDirRng.AutoSize = true;
            radioButtonRelativeDirRng.Location = new Point(6, 48);
            radioButtonRelativeDirRng.Name = "radioButtonRelativeDirRng";
            radioButtonRelativeDirRng.Size = new Size(110, 19);
            radioButtonRelativeDirRng.TabIndex = 19;
            radioButtonRelativeDirRng.Text = "Relative Dir/Rng";
            radioButtonRelativeDirRng.UseVisualStyleBackColor = true;
            radioButtonRelativeDirRng.CheckedChanged += CoordinateModeChanged;
            // 
            // radioButtonRelativeLatLong
            // 
            radioButtonRelativeLatLong.AutoSize = true;
            radioButtonRelativeLatLong.Location = new Point(6, 73);
            radioButtonRelativeLatLong.Name = "radioButtonRelativeLatLong";
            radioButtonRelativeLatLong.Size = new Size(117, 19);
            radioButtonRelativeLatLong.TabIndex = 20;
            radioButtonRelativeLatLong.Text = "Relative Lat/Long";
            radioButtonRelativeLatLong.UseVisualStyleBackColor = true;
            radioButtonRelativeLatLong.CheckedChanged += CoordinateModeChanged;
            // 
            // groupBoxCoordinatesMode
            // 
            groupBoxCoordinatesMode.Controls.Add(labelDirection);
            groupBoxCoordinatesMode.Controls.Add(txtDirection);
            groupBoxCoordinatesMode.Controls.Add(labelRange);
            groupBoxCoordinatesMode.Controls.Add(txtRange);
            groupBoxCoordinatesMode.Controls.Add(cmbLatitudeDirection);
            groupBoxCoordinatesMode.Controls.Add(labelRelativeLatitude);
            groupBoxCoordinatesMode.Controls.Add(txtRelativeLatitude);
            groupBoxCoordinatesMode.Controls.Add(cmbLongitudeDirection);
            groupBoxCoordinatesMode.Controls.Add(labelRelativeLongitude);
            groupBoxCoordinatesMode.Controls.Add(txtRelativeLongitude);
            groupBoxCoordinatesMode.Controls.Add(radioButtonRelativeLatLong);
            groupBoxCoordinatesMode.Controls.Add(radioButtonRelativeDirRng);
            groupBoxCoordinatesMode.Controls.Add(radioButtonDirectCoordinates);
            groupBoxCoordinatesMode.Location = new Point(0, 35);
            groupBoxCoordinatesMode.Name = "groupBoxCoordinatesMode";
            groupBoxCoordinatesMode.Size = new Size(555, 154);
            groupBoxCoordinatesMode.TabIndex = 21;
            groupBoxCoordinatesMode.TabStop = false;
            groupBoxCoordinatesMode.Text = "Coordinates Mode";
            // 
            // labelDirection
            // 
            labelDirection.Location = new Point(163, 11);
            labelDirection.Name = "labelDirection";
            labelDirection.Size = new Size(125, 25);
            labelDirection.TabIndex = 0;
            labelDirection.Text = "Direction:";
            labelDirection.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDirection
            // 
            txtDirection.AllowFraction = false;
            txtDirection.AllowNegative = false;
            txtDirection.BackColor = SystemColors.Window;
            txtDirection.Location = new Point(293, 11);
            txtDirection.MaximumValue = new decimal(new int[] { 359, 0, 0, 0 });
            txtDirection.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtDirection.Name = "txtDirection";
            txtDirection.Size = new Size(100, 25);
            txtDirection.TabIndex = 1;
            txtDirection.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtDirection.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // labelRange
            // 
            labelRange.Location = new Point(163, 42);
            labelRange.Name = "labelRange";
            labelRange.Size = new Size(125, 25);
            labelRange.TabIndex = 2;
            labelRange.Text = "Range:";
            labelRange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRange
            // 
            txtRange.AllowFraction = true;
            txtRange.AllowNegative = false;
            txtRange.BackColor = SystemColors.Window;
            txtRange.Location = new Point(293, 42);
            txtRange.MaximumValue = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtRange.MinimumValue = new decimal(new int[] { 1, 0, 0, 65536 });
            txtRange.Name = "txtRange";
            txtRange.Size = new Size(100, 25);
            txtRange.TabIndex = 3;
            txtRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.NauticalMile;
            txtRange.Value = new decimal(new int[] { 0, 0, 0, 65536 });
            // 
            // cmbLatitudeDirection
            // 
            cmbLatitudeDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLatitudeDirection.Items.AddRange(new object[] { "N", "S" });
            cmbLatitudeDirection.Location = new Point(293, 73);
            cmbLatitudeDirection.Name = "cmbLatitudeDirection";
            cmbLatitudeDirection.Size = new Size(35, 23);
            cmbLatitudeDirection.TabIndex = 5;
            // 
            // labelRelativeLatitude
            // 
            labelRelativeLatitude.Location = new Point(163, 73);
            labelRelativeLatitude.Name = "labelRelativeLatitude";
            labelRelativeLatitude.Size = new Size(125, 25);
            labelRelativeLatitude.TabIndex = 6;
            labelRelativeLatitude.Text = "Relative Latitude:";
            labelRelativeLatitude.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRelativeLatitude
            // 
            txtRelativeLatitude.AllowFraction = false;
            txtRelativeLatitude.AllowNegative = false;
            txtRelativeLatitude.BackColor = SystemColors.Window;
            txtRelativeLatitude.Location = new Point(333, 73);
            txtRelativeLatitude.MaximumValue = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtRelativeLatitude.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtRelativeLatitude.Name = "txtRelativeLatitude";
            txtRelativeLatitude.Size = new Size(100, 25);
            txtRelativeLatitude.TabIndex = 7;
            txtRelativeLatitude.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            txtRelativeLatitude.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbLongitudeDirection
            // 
            cmbLongitudeDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLongitudeDirection.Items.AddRange(new object[] { "E", "W" });
            cmbLongitudeDirection.Location = new Point(293, 104);
            cmbLongitudeDirection.Name = "cmbLongitudeDirection";
            cmbLongitudeDirection.Size = new Size(36, 23);
            cmbLongitudeDirection.TabIndex = 9;
            // 
            // labelRelativeLongitude
            // 
            labelRelativeLongitude.Location = new Point(163, 98);
            labelRelativeLongitude.Name = "labelRelativeLongitude";
            labelRelativeLongitude.Size = new Size(125, 25);
            labelRelativeLongitude.TabIndex = 10;
            labelRelativeLongitude.Text = "Relative Longitude:";
            labelRelativeLongitude.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRelativeLongitude
            // 
            txtRelativeLongitude.AllowFraction = false;
            txtRelativeLongitude.AllowNegative = false;
            txtRelativeLongitude.BackColor = SystemColors.Window;
            txtRelativeLongitude.Location = new Point(333, 104);
            txtRelativeLongitude.MaximumValue = new decimal(new int[] { 1215752191, 23, 0, 0 });
            txtRelativeLongitude.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtRelativeLongitude.Name = "txtRelativeLongitude";
            txtRelativeLongitude.Size = new Size(100, 25);
            txtRelativeLongitude.TabIndex = 11;
            txtRelativeLongitude.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            txtRelativeLongitude.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // WaypointEditPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(groupBoxCoordinatesMode);
            Controls.Add(chkOffset);
            Controls.Add(txtMEA);
            Controls.Add(label5);
            Name = "WaypointEditPanel";
            Size = new Size(555, 257);
            groupBoxCoordinatesMode.ResumeLayout(false);
            groupBoxCoordinatesMode.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtMEA;
        protected DTC.UI.Base.Controls.DTCCheckBox chkTarget;
        protected DTC.UI.Base.Controls.DTCCheckBox chkOffset;
        private RadioButton radioButtonDirectCoordinates;
        private RadioButton radioButtonRelativeDirRng;
        private RadioButton radioButtonRelativeLatLong;
        private GroupBox groupBoxCoordinatesMode;
        private Label labelDirection;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtDirection;
        private Label labelRange;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtRange;
        private ComboBox cmbLatitudeDirection;
        private Label labelRelativeLatitude;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtRelativeLatitude;
        private ComboBox cmbLongitudeDirection;
        private Label labelRelativeLongitude;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtRelativeLongitude;
    }
}
