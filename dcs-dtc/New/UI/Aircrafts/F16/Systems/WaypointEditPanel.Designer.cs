namespace DTC.New.UI.Aircrafts.F16.Systems
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
            pnlVRP = new Panel();
            label19 = new Label();
            label20 = new Label();
            label14 = new Label();
            txtTGTtoVRPElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            label13 = new Label();
            txtTGTtoPUPRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            label12 = new Label();
            txtTGTtoVRPBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtTGTtoVRPRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtTGTtoPUPBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtTGTtoPUPElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            pnlVIP = new Panel();
            label18 = new Label();
            label17 = new Label();
            label11 = new Label();
            label10 = new Label();
            txtVIPtoPUPBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            label9 = new Label();
            txtVIPtoPUPRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtVIPtoPUPElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtVIPtoTGTBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtVIPtoTGTElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtVIPtoTGTRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            chkUseOA = new DTC.UI.Base.Controls.DTCCheckBox();
            chkUseVRP = new DTC.UI.Base.Controls.DTCCheckBox();
            chkUseVIP = new DTC.UI.Base.Controls.DTCCheckBox();
            pnlOA = new Panel();
            label16 = new Label();
            label15 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtOA1Range = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtOA1Bearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtOA2Range = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtOA1Elev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtOA2Bearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtOA2Elev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            pnlVRP.SuspendLayout();
            pnlVIP.SuspendLayout();
            pnlOA.SuspendLayout();
            SuspendLayout();
            // 
            // pnlVRP
            // 
            pnlVRP.Controls.Add(label19);
            pnlVRP.Controls.Add(label20);
            pnlVRP.Controls.Add(label14);
            pnlVRP.Controls.Add(txtTGTtoVRPElev);
            pnlVRP.Controls.Add(label13);
            pnlVRP.Controls.Add(txtTGTtoPUPRange);
            pnlVRP.Controls.Add(label12);
            pnlVRP.Controls.Add(txtTGTtoVRPBearing);
            pnlVRP.Controls.Add(txtTGTtoVRPRange);
            pnlVRP.Controls.Add(txtTGTtoPUPBearing);
            pnlVRP.Controls.Add(txtTGTtoPUPElev);
            pnlVRP.Location = new Point(4, 206);
            pnlVRP.Name = "pnlVRP";
            pnlVRP.Size = new Size(578, 90);
            pnlVRP.TabIndex = 5;
            // 
            // label19
            // 
            label19.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(4, 28);
            label19.Margin = new Padding(0);
            label19.Name = "label19";
            label19.Size = new Size(88, 25);
            label19.TabIndex = 27;
            label19.Text = "TGT-to-VRP";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            label20.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(4, 56);
            label20.Margin = new Padding(0);
            label20.Name = "label20";
            label20.Size = new Size(88, 25);
            label20.TabIndex = 27;
            label20.Text = "TGT-to-PUP";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(158, -1);
            label14.Margin = new Padding(0);
            label14.Name = "label14";
            label14.Size = new Size(88, 25);
            label14.TabIndex = 27;
            label14.Text = "Range";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTGTtoVRPElev
            // 
            txtTGTtoVRPElev.AllowFraction = false;
            txtTGTtoVRPElev.BackColor = SystemColors.Window;
            txtTGTtoVRPElev.Location = new Point(362, 27);
            txtTGTtoVRPElev.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtTGTtoVRPElev.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoVRPElev.Name = "txtTGTtoVRPElev";
            txtTGTtoVRPElev.Size = new Size(90, 25);
            txtTGTtoVRPElev.TabIndex = 2;
            txtTGTtoVRPElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtTGTtoVRPElev.Value = null;
            // 
            // label13
            // 
            label13.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(260, -1);
            label13.Margin = new Padding(0);
            label13.Name = "label13";
            label13.Size = new Size(88, 25);
            label13.TabIndex = 27;
            label13.Text = "Bearing";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTGTtoPUPRange
            // 
            txtTGTtoPUPRange.AllowFraction = false;
            txtTGTtoPUPRange.BackColor = SystemColors.Window;
            txtTGTtoPUPRange.Location = new Point(158, 55);
            txtTGTtoPUPRange.MaximumValue = new decimal(new int[] { 486090, 0, 0, 0 });
            txtTGTtoPUPRange.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoPUPRange.Name = "txtTGTtoPUPRange";
            txtTGTtoPUPRange.Size = new Size(90, 25);
            txtTGTtoPUPRange.TabIndex = 3;
            txtTGTtoPUPRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtTGTtoPUPRange.Value = null;
            // 
            // label12
            // 
            label12.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(362, -1);
            label12.Margin = new Padding(0);
            label12.Name = "label12";
            label12.Size = new Size(88, 25);
            label12.TabIndex = 27;
            label12.Text = "Elevation";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTGTtoVRPBearing
            // 
            txtTGTtoVRPBearing.AllowFraction = true;
            txtTGTtoVRPBearing.BackColor = SystemColors.Window;
            txtTGTtoVRPBearing.Location = new Point(260, 27);
            txtTGTtoVRPBearing.MaximumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoVRPBearing.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoVRPBearing.Name = "txtTGTtoVRPBearing";
            txtTGTtoVRPBearing.Size = new Size(90, 25);
            txtTGTtoVRPBearing.TabIndex = 1;
            txtTGTtoVRPBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtTGTtoVRPBearing.Value = null;
            // 
            // txtTGTtoVRPRange
            // 
            txtTGTtoVRPRange.AllowFraction = false;
            txtTGTtoVRPRange.BackColor = SystemColors.Window;
            txtTGTtoVRPRange.Location = new Point(158, 27);
            txtTGTtoVRPRange.MaximumValue = new decimal(new int[] { 486090, 0, 0, 0 });
            txtTGTtoVRPRange.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoVRPRange.Name = "txtTGTtoVRPRange";
            txtTGTtoVRPRange.Size = new Size(90, 25);
            txtTGTtoVRPRange.TabIndex = 0;
            txtTGTtoVRPRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtTGTtoVRPRange.Value = null;
            // 
            // txtTGTtoPUPBearing
            // 
            txtTGTtoPUPBearing.AllowFraction = true;
            txtTGTtoPUPBearing.BackColor = SystemColors.Window;
            txtTGTtoPUPBearing.Location = new Point(260, 55);
            txtTGTtoPUPBearing.MaximumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoPUPBearing.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoPUPBearing.Name = "txtTGTtoPUPBearing";
            txtTGTtoPUPBearing.Size = new Size(90, 25);
            txtTGTtoPUPBearing.TabIndex = 4;
            txtTGTtoPUPBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtTGTtoPUPBearing.Value = null;
            // 
            // txtTGTtoPUPElev
            // 
            txtTGTtoPUPElev.AllowFraction = false;
            txtTGTtoPUPElev.BackColor = SystemColors.Window;
            txtTGTtoPUPElev.Location = new Point(362, 55);
            txtTGTtoPUPElev.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtTGTtoPUPElev.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtTGTtoPUPElev.Name = "txtTGTtoPUPElev";
            txtTGTtoPUPElev.Size = new Size(90, 25);
            txtTGTtoPUPElev.TabIndex = 5;
            txtTGTtoPUPElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtTGTtoPUPElev.Value = null;
            // 
            // pnlVIP
            // 
            pnlVIP.Controls.Add(label18);
            pnlVIP.Controls.Add(label17);
            pnlVIP.Controls.Add(label11);
            pnlVIP.Controls.Add(label10);
            pnlVIP.Controls.Add(txtVIPtoPUPBearing);
            pnlVIP.Controls.Add(label9);
            pnlVIP.Controls.Add(txtVIPtoPUPRange);
            pnlVIP.Controls.Add(txtVIPtoPUPElev);
            pnlVIP.Controls.Add(txtVIPtoTGTBearing);
            pnlVIP.Controls.Add(txtVIPtoTGTElev);
            pnlVIP.Controls.Add(txtVIPtoTGTRange);
            pnlVIP.Location = new Point(4, 117);
            pnlVIP.Name = "pnlVIP";
            pnlVIP.Size = new Size(578, 90);
            pnlVIP.TabIndex = 4;
            // 
            // label18
            // 
            label18.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(4, 56);
            label18.Margin = new Padding(0);
            label18.Name = "label18";
            label18.Size = new Size(88, 25);
            label18.TabIndex = 27;
            label18.Text = "VIP-to-PUP";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(4, 28);
            label17.Margin = new Padding(0);
            label17.Name = "label17";
            label17.Size = new Size(88, 25);
            label17.TabIndex = 27;
            label17.Text = "VIP-to-TGT";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(158, -1);
            label11.Margin = new Padding(0);
            label11.Name = "label11";
            label11.Size = new Size(88, 25);
            label11.TabIndex = 27;
            label11.Text = "Range";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(260, -1);
            label10.Margin = new Padding(0);
            label10.Name = "label10";
            label10.Size = new Size(88, 25);
            label10.TabIndex = 27;
            label10.Text = "Bearing";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVIPtoPUPBearing
            // 
            txtVIPtoPUPBearing.AllowFraction = true;
            txtVIPtoPUPBearing.BackColor = SystemColors.Window;
            txtVIPtoPUPBearing.Location = new Point(260, 55);
            txtVIPtoPUPBearing.MaximumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoPUPBearing.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoPUPBearing.Name = "txtVIPtoPUPBearing";
            txtVIPtoPUPBearing.Size = new Size(90, 25);
            txtVIPtoPUPBearing.TabIndex = 4;
            txtVIPtoPUPBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtVIPtoPUPBearing.Value = null;
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(362, -1);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Size = new Size(88, 25);
            label9.TabIndex = 27;
            label9.Text = "Elevation";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVIPtoPUPRange
            // 
            txtVIPtoPUPRange.AllowFraction = true;
            txtVIPtoPUPRange.BackColor = SystemColors.Window;
            txtVIPtoPUPRange.Location = new Point(158, 55);
            txtVIPtoPUPRange.MaximumValue = new decimal(new int[] { 999, 0, 0, 65536 });
            txtVIPtoPUPRange.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoPUPRange.Name = "txtVIPtoPUPRange";
            txtVIPtoPUPRange.Size = new Size(90, 25);
            txtVIPtoPUPRange.TabIndex = 3;
            txtVIPtoPUPRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.NauticalMile;
            txtVIPtoPUPRange.Value = null;
            // 
            // txtVIPtoPUPElev
            // 
            txtVIPtoPUPElev.AllowFraction = false;
            txtVIPtoPUPElev.BackColor = SystemColors.Window;
            txtVIPtoPUPElev.Location = new Point(362, 55);
            txtVIPtoPUPElev.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtVIPtoPUPElev.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoPUPElev.Name = "txtVIPtoPUPElev";
            txtVIPtoPUPElev.Size = new Size(90, 25);
            txtVIPtoPUPElev.TabIndex = 5;
            txtVIPtoPUPElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtVIPtoPUPElev.Value = null;
            // 
            // txtVIPtoTGTBearing
            // 
            txtVIPtoTGTBearing.AllowFraction = true;
            txtVIPtoTGTBearing.BackColor = SystemColors.Window;
            txtVIPtoTGTBearing.Location = new Point(260, 27);
            txtVIPtoTGTBearing.MaximumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoTGTBearing.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoTGTBearing.Name = "txtVIPtoTGTBearing";
            txtVIPtoTGTBearing.Size = new Size(90, 25);
            txtVIPtoTGTBearing.TabIndex = 1;
            txtVIPtoTGTBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtVIPtoTGTBearing.Value = null;
            // 
            // txtVIPtoTGTElev
            // 
            txtVIPtoTGTElev.AllowFraction = false;
            txtVIPtoTGTElev.BackColor = SystemColors.Window;
            txtVIPtoTGTElev.Location = new Point(362, 27);
            txtVIPtoTGTElev.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtVIPtoTGTElev.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoTGTElev.Name = "txtVIPtoTGTElev";
            txtVIPtoTGTElev.Size = new Size(90, 25);
            txtVIPtoTGTElev.TabIndex = 2;
            txtVIPtoTGTElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtVIPtoTGTElev.Value = null;
            // 
            // txtVIPtoTGTRange
            // 
            txtVIPtoTGTRange.AllowFraction = true;
            txtVIPtoTGTRange.BackColor = SystemColors.Window;
            txtVIPtoTGTRange.Location = new Point(158, 27);
            txtVIPtoTGTRange.MaximumValue = new decimal(new int[] { 999, 0, 0, 65536 });
            txtVIPtoTGTRange.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtVIPtoTGTRange.Name = "txtVIPtoTGTRange";
            txtVIPtoTGTRange.Size = new Size(90, 25);
            txtVIPtoTGTRange.TabIndex = 0;
            txtVIPtoTGTRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.NauticalMile;
            txtVIPtoTGTRange.Value = null;
            // 
            // chkUseOA
            // 
            chkUseOA.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkUseOA.Location = new Point(8, 3);
            chkUseOA.Name = "chkUseOA";
            chkUseOA.Size = new Size(135, 25);
            chkUseOA.TabIndex = 0;
            chkUseOA.Text = "Offset Aimpoints";
            chkUseOA.UseVisualStyleBackColor = true;
            chkUseOA.CheckedChanged += chkUseOA_CheckedChanged;
            // 
            // chkUseVRP
            // 
            chkUseVRP.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkUseVRP.Location = new Point(319, 3);
            chkUseVRP.Name = "chkUseVRP";
            chkUseVRP.Size = new Size(177, 25);
            chkUseVRP.TabIndex = 2;
            chkUseVRP.Text = "Visual Reference Point";
            chkUseVRP.UseVisualStyleBackColor = true;
            chkUseVRP.CheckedChanged += chkUseVRP_CheckedChanged;
            // 
            // chkUseVIP
            // 
            chkUseVIP.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkUseVIP.Location = new Point(157, 3);
            chkUseVIP.Name = "chkUseVIP";
            chkUseVIP.Size = new Size(156, 25);
            chkUseVIP.TabIndex = 1;
            chkUseVIP.Text = "Visual Initial Point";
            chkUseVIP.UseVisualStyleBackColor = true;
            chkUseVIP.CheckedChanged += chkUseVIP_CheckedChanged;
            // 
            // pnlOA
            // 
            pnlOA.Controls.Add(label16);
            pnlOA.Controls.Add(label15);
            pnlOA.Controls.Add(label6);
            pnlOA.Controls.Add(label7);
            pnlOA.Controls.Add(label8);
            pnlOA.Controls.Add(txtOA1Range);
            pnlOA.Controls.Add(txtOA1Bearing);
            pnlOA.Controls.Add(txtOA2Range);
            pnlOA.Controls.Add(txtOA1Elev);
            pnlOA.Controls.Add(txtOA2Bearing);
            pnlOA.Controls.Add(txtOA2Elev);
            pnlOA.Location = new Point(4, 28);
            pnlOA.Name = "pnlOA";
            pnlOA.Size = new Size(578, 90);
            pnlOA.TabIndex = 3;
            pnlOA.Visible = false;
            // 
            // label16
            // 
            label16.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(4, 56);
            label16.Margin = new Padding(0);
            label16.Name = "label16";
            label16.Size = new Size(135, 25);
            label16.TabIndex = 27;
            label16.Text = "Offset Aimpoint 2";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(4, 28);
            label15.Margin = new Padding(0);
            label15.Name = "label15";
            label15.Size = new Size(135, 25);
            label15.TabIndex = 27;
            label15.Text = "Offset Aimpoint 1";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(158, -1);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(88, 25);
            label6.TabIndex = 27;
            label6.Text = "Range";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(260, -1);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Size = new Size(88, 25);
            label7.TabIndex = 27;
            label7.Text = "Bearing";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(362, -1);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(88, 25);
            label8.TabIndex = 27;
            label8.Text = "Elevation";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOA1Range
            // 
            txtOA1Range.AllowFraction = false;
            txtOA1Range.BackColor = SystemColors.Window;
            txtOA1Range.Location = new Point(158, 27);
            txtOA1Range.MaximumValue = new decimal(new int[] { 99999, 0, 0, 0 });
            txtOA1Range.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA1Range.Name = "txtOA1Range";
            txtOA1Range.Size = new Size(90, 25);
            txtOA1Range.TabIndex = 0;
            txtOA1Range.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtOA1Range.Value = null;
            // 
            // txtOA1Bearing
            // 
            txtOA1Bearing.AllowFraction = true;
            txtOA1Bearing.BackColor = SystemColors.Window;
            txtOA1Bearing.Location = new Point(260, 27);
            txtOA1Bearing.MaximumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA1Bearing.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA1Bearing.Name = "txtOA1Bearing";
            txtOA1Bearing.Size = new Size(90, 25);
            txtOA1Bearing.TabIndex = 1;
            txtOA1Bearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtOA1Bearing.Value = null;
            // 
            // txtOA2Range
            // 
            txtOA2Range.AllowFraction = false;
            txtOA2Range.BackColor = SystemColors.Window;
            txtOA2Range.Location = new Point(158, 55);
            txtOA2Range.MaximumValue = new decimal(new int[] { 99999, 0, 0, 0 });
            txtOA2Range.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA2Range.Name = "txtOA2Range";
            txtOA2Range.Size = new Size(90, 25);
            txtOA2Range.TabIndex = 3;
            txtOA2Range.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtOA2Range.Value = null;
            // 
            // txtOA1Elev
            // 
            txtOA1Elev.AllowFraction = false;
            txtOA1Elev.BackColor = SystemColors.Window;
            txtOA1Elev.Location = new Point(362, 27);
            txtOA1Elev.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtOA1Elev.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA1Elev.Name = "txtOA1Elev";
            txtOA1Elev.Size = new Size(90, 25);
            txtOA1Elev.TabIndex = 2;
            txtOA1Elev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtOA1Elev.Value = null;
            // 
            // txtOA2Bearing
            // 
            txtOA2Bearing.AllowFraction = true;
            txtOA2Bearing.BackColor = SystemColors.Window;
            txtOA2Bearing.Location = new Point(260, 55);
            txtOA2Bearing.MaximumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA2Bearing.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA2Bearing.Name = "txtOA2Bearing";
            txtOA2Bearing.Size = new Size(90, 25);
            txtOA2Bearing.TabIndex = 4;
            txtOA2Bearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            txtOA2Bearing.Value = null;
            // 
            // txtOA2Elev
            // 
            txtOA2Elev.AllowFraction = false;
            txtOA2Elev.BackColor = SystemColors.Window;
            txtOA2Elev.Location = new Point(362, 55);
            txtOA2Elev.MaximumValue = new decimal(new int[] { 80000, 0, 0, 0 });
            txtOA2Elev.MinimumValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOA2Elev.Name = "txtOA2Elev";
            txtOA2Elev.Size = new Size(90, 25);
            txtOA2Elev.TabIndex = 5;
            txtOA2Elev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            txtOA2Elev.Value = null;
            // 
            // WaypointEditPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(pnlVRP);
            Controls.Add(pnlVIP);
            Controls.Add(chkUseOA);
            Controls.Add(chkUseVRP);
            Controls.Add(chkUseVIP);
            Controls.Add(pnlOA);
            Name = "WaypointEditPanel";
            Size = new Size(588, 440);
            pnlVRP.ResumeLayout(false);
            pnlVIP.ResumeLayout(false);
            pnlOA.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlVRP;
        private Label label19;
        private Label label20;
        private Label label14;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtTGTtoVRPElev;
        private Label label13;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtTGTtoPUPRange;
        private Label label12;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtTGTtoVRPBearing;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtTGTtoVRPRange;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtTGTtoPUPBearing;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtTGTtoPUPElev;
        private Panel pnlVIP;
        private Label label18;
        private Label label17;
        private Label label11;
        private Label label10;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtVIPtoPUPBearing;
        private Label label9;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtVIPtoPUPRange;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtVIPtoPUPElev;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtVIPtoTGTBearing;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtVIPtoTGTElev;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtVIPtoTGTRange;
        private DTC.UI.Base.Controls.DTCCheckBox chkUseOA;
        private DTC.UI.Base.Controls.DTCCheckBox chkUseVRP;
        private DTC.UI.Base.Controls.DTCCheckBox chkUseVIP;
        private Panel pnlOA;
        private Label label16;
        private Label label15;
        private Label label6;
        private Label label7;
        private Label label8;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtOA1Range;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtOA1Bearing;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtOA2Range;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtOA1Elev;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtOA2Bearing;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtOA2Elev;
    }
}
