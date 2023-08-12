
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.F16
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCapture = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValidation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlOA = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pnlVIP = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlVRP = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTGTtoVRPElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtTGTtoPUPRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtTGTtoVRPBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtTGTtoVRPRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtTGTtoPUPBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtTGTtoPUPElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtVIPtoPUPBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtVIPtoPUPRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtVIPtoPUPElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtVIPtoTGTBearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtVIPtoTGTElev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtVIPtoTGTRange = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.cboAirbases = new DTC.UI.Base.Controls.DTCDropDown();
            this.chkUseOA = new DTC.UI.Base.Controls.DTCCheckBox();
            this.txtTimeOverSteerpoint = new DTC.UI.Base.Controls.DTCTextBox();
            this.chkUseVRP = new DTC.UI.Base.Controls.DTCCheckBox();
            this.chkUseVIP = new DTC.UI.Base.Controls.DTCCheckBox();
            this.txtWptName = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptLatLong = new DTC.UI.Base.Controls.DTCCoordinateTextBox();
            this.txtWptElevation = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.btnCancel = new DTC.UI.Base.Controls.DTCButton();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.txtOA1Range = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtOA1Bearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtOA2Range = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtOA1Elev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtOA2Bearing = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtOA2Elev = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.pnlTop.SuspendLayout();
            this.pnlOA.SuspendLayout();
            this.pnlVIP.SuspendLayout();
            this.pnlVRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(1, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(150, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Airbases:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(1, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Waypoint Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCapture.Location = new System.Drawing.Point(463, 97);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(120, 25);
            this.btnCapture.TabIndex = 13;
            this.btnCapture.Text = "Start Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.pnlTop.Controls.Add(this.btnCancel);
            this.pnlTop.Controls.Add(this.btnSave);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(588, 35);
            this.pnlTop.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(1, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Lat/Long:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(1, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Elevation:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValidation
            // 
            this.lblValidation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidation.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(5, 638);
            this.lblValidation.Margin = new System.Windows.Forms.Padding(0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblValidation.Size = new System.Drawing.Size(578, 25);
            this.lblValidation.TabIndex = 28;
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(297, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Time Over Steerpoint:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(158, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 27;
            this.label6.Text = "Range";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(260, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "Bearing";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(362, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 25);
            this.label8.TabIndex = 27;
            this.label8.Text = "Elevation";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOA
            // 
            this.pnlOA.Controls.Add(this.label16);
            this.pnlOA.Controls.Add(this.label15);
            this.pnlOA.Controls.Add(this.label6);
            this.pnlOA.Controls.Add(this.label7);
            this.pnlOA.Controls.Add(this.label8);
            this.pnlOA.Controls.Add(this.txtOA1Range);
            this.pnlOA.Controls.Add(this.txtOA1Bearing);
            this.pnlOA.Controls.Add(this.txtOA2Range);
            this.pnlOA.Controls.Add(this.txtOA1Elev);
            this.pnlOA.Controls.Add(this.txtOA2Bearing);
            this.pnlOA.Controls.Add(this.txtOA2Elev);
            this.pnlOA.Location = new System.Drawing.Point(5, 189);
            this.pnlOA.Name = "pnlOA";
            this.pnlOA.Size = new System.Drawing.Size(578, 90);
            this.pnlOA.TabIndex = 33;
            this.pnlOA.Visible = false;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label16.Location = new System.Drawing.Point(4, 60);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(135, 25);
            this.label16.TabIndex = 27;
            this.label16.Text = "Offset Aimpoint 2";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label15.Location = new System.Drawing.Point(4, 32);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 25);
            this.label15.TabIndex = 27;
            this.label15.Text = "Offset Aimpoint 1";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVIP
            // 
            this.pnlVIP.Controls.Add(this.label18);
            this.pnlVIP.Controls.Add(this.label17);
            this.pnlVIP.Controls.Add(this.label11);
            this.pnlVIP.Controls.Add(this.label10);
            this.pnlVIP.Controls.Add(this.txtVIPtoPUPBearing);
            this.pnlVIP.Controls.Add(this.label9);
            this.pnlVIP.Controls.Add(this.txtVIPtoPUPRange);
            this.pnlVIP.Controls.Add(this.txtVIPtoPUPElev);
            this.pnlVIP.Controls.Add(this.txtVIPtoTGTBearing);
            this.pnlVIP.Controls.Add(this.txtVIPtoTGTElev);
            this.pnlVIP.Controls.Add(this.txtVIPtoTGTRange);
            this.pnlVIP.Location = new System.Drawing.Point(5, 290);
            this.pnlVIP.Name = "pnlVIP";
            this.pnlVIP.Size = new System.Drawing.Size(578, 90);
            this.pnlVIP.TabIndex = 41;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label18.Location = new System.Drawing.Point(4, 60);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 25);
            this.label18.TabIndex = 27;
            this.label18.Text = "VIP-to-PUP";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label17.Location = new System.Drawing.Point(4, 32);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 25);
            this.label17.TabIndex = 27;
            this.label17.Text = "VIP-to-TGT";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(158, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "Range";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(260, 3);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 25);
            this.label10.TabIndex = 27;
            this.label10.Text = "Bearing";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label9.Location = new System.Drawing.Point(362, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Elevation";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVRP
            // 
            this.pnlVRP.Controls.Add(this.label19);
            this.pnlVRP.Controls.Add(this.label20);
            this.pnlVRP.Controls.Add(this.label14);
            this.pnlVRP.Controls.Add(this.txtTGTtoVRPElev);
            this.pnlVRP.Controls.Add(this.label13);
            this.pnlVRP.Controls.Add(this.txtTGTtoPUPRange);
            this.pnlVRP.Controls.Add(this.label12);
            this.pnlVRP.Controls.Add(this.txtTGTtoVRPBearing);
            this.pnlVRP.Controls.Add(this.txtTGTtoVRPRange);
            this.pnlVRP.Controls.Add(this.txtTGTtoPUPBearing);
            this.pnlVRP.Controls.Add(this.txtTGTtoPUPElev);
            this.pnlVRP.Location = new System.Drawing.Point(5, 393);
            this.pnlVRP.Name = "pnlVRP";
            this.pnlVRP.Size = new System.Drawing.Size(578, 90);
            this.pnlVRP.TabIndex = 42;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label19.Location = new System.Drawing.Point(4, 32);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 25);
            this.label19.TabIndex = 27;
            this.label19.Text = "TGT-to-VRP";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label20.Location = new System.Drawing.Point(4, 60);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 25);
            this.label20.TabIndex = 27;
            this.label20.Text = "TGT-to-PUP";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(158, 3);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 25);
            this.label14.TabIndex = 27;
            this.label14.Text = "Range";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(260, 3);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 25);
            this.label13.TabIndex = 27;
            this.label13.Text = "Bearing";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(362, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 25);
            this.label12.TabIndex = 27;
            this.label12.Text = "Elevation";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTGTtoVRPElev
            // 
            this.txtTGTtoVRPElev.AllowFraction = false;
            this.txtTGTtoVRPElev.BackColor = System.Drawing.SystemColors.Window;
            this.txtTGTtoVRPElev.Location = new System.Drawing.Point(362, 31);
            this.txtTGTtoVRPElev.MaximumValue = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.txtTGTtoVRPElev.MinimumValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.txtTGTtoVRPElev.Name = "txtTGTtoVRPElev";
            this.txtTGTtoVRPElev.Size = new System.Drawing.Size(90, 25);
            this.txtTGTtoVRPElev.TabIndex = 36;
            this.txtTGTtoVRPElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtTGTtoVRPElev.Value = null;
            // 
            // txtTGTtoPUPRange
            // 
            this.txtTGTtoPUPRange.AllowFraction = false;
            this.txtTGTtoPUPRange.BackColor = System.Drawing.SystemColors.Window;
            this.txtTGTtoPUPRange.Location = new System.Drawing.Point(158, 59);
            this.txtTGTtoPUPRange.MaximumValue = new decimal(new int[] {
            486090,
            0,
            0,
            0});
            this.txtTGTtoPUPRange.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTGTtoPUPRange.Name = "txtTGTtoPUPRange";
            this.txtTGTtoPUPRange.Size = new System.Drawing.Size(90, 25);
            this.txtTGTtoPUPRange.TabIndex = 38;
            this.txtTGTtoPUPRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtTGTtoPUPRange.Value = null;
            // 
            // txtTGTtoVRPBearing
            // 
            this.txtTGTtoVRPBearing.AllowFraction = true;
            this.txtTGTtoVRPBearing.BackColor = System.Drawing.SystemColors.Window;
            this.txtTGTtoVRPBearing.Location = new System.Drawing.Point(260, 31);
            this.txtTGTtoVRPBearing.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTGTtoVRPBearing.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTGTtoVRPBearing.Name = "txtTGTtoVRPBearing";
            this.txtTGTtoVRPBearing.Size = new System.Drawing.Size(90, 25);
            this.txtTGTtoVRPBearing.TabIndex = 35;
            this.txtTGTtoVRPBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            this.txtTGTtoVRPBearing.Value = null;
            // 
            // txtTGTtoVRPRange
            // 
            this.txtTGTtoVRPRange.AllowFraction = false;
            this.txtTGTtoVRPRange.BackColor = System.Drawing.SystemColors.Window;
            this.txtTGTtoVRPRange.Location = new System.Drawing.Point(158, 31);
            this.txtTGTtoVRPRange.MaximumValue = new decimal(new int[] {
            486090,
            0,
            0,
            0});
            this.txtTGTtoVRPRange.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTGTtoVRPRange.Name = "txtTGTtoVRPRange";
            this.txtTGTtoVRPRange.Size = new System.Drawing.Size(90, 25);
            this.txtTGTtoVRPRange.TabIndex = 34;
            this.txtTGTtoVRPRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtTGTtoVRPRange.Value = null;
            // 
            // txtTGTtoPUPBearing
            // 
            this.txtTGTtoPUPBearing.AllowFraction = true;
            this.txtTGTtoPUPBearing.BackColor = System.Drawing.SystemColors.Window;
            this.txtTGTtoPUPBearing.Location = new System.Drawing.Point(260, 59);
            this.txtTGTtoPUPBearing.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTGTtoPUPBearing.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTGTtoPUPBearing.Name = "txtTGTtoPUPBearing";
            this.txtTGTtoPUPBearing.Size = new System.Drawing.Size(90, 25);
            this.txtTGTtoPUPBearing.TabIndex = 39;
            this.txtTGTtoPUPBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            this.txtTGTtoPUPBearing.Value = null;
            // 
            // txtTGTtoPUPElev
            // 
            this.txtTGTtoPUPElev.AllowFraction = false;
            this.txtTGTtoPUPElev.BackColor = System.Drawing.SystemColors.Window;
            this.txtTGTtoPUPElev.Location = new System.Drawing.Point(362, 59);
            this.txtTGTtoPUPElev.MaximumValue = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.txtTGTtoPUPElev.MinimumValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.txtTGTtoPUPElev.Name = "txtTGTtoPUPElev";
            this.txtTGTtoPUPElev.Size = new System.Drawing.Size(90, 25);
            this.txtTGTtoPUPElev.TabIndex = 40;
            this.txtTGTtoPUPElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtTGTtoPUPElev.Value = null;
            // 
            // txtVIPtoPUPBearing
            // 
            this.txtVIPtoPUPBearing.AllowFraction = true;
            this.txtVIPtoPUPBearing.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPtoPUPBearing.Location = new System.Drawing.Point(260, 59);
            this.txtVIPtoPUPBearing.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVIPtoPUPBearing.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVIPtoPUPBearing.Name = "txtVIPtoPUPBearing";
            this.txtVIPtoPUPBearing.Size = new System.Drawing.Size(90, 25);
            this.txtVIPtoPUPBearing.TabIndex = 31;
            this.txtVIPtoPUPBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            this.txtVIPtoPUPBearing.Value = null;
            // 
            // txtVIPtoPUPRange
            // 
            this.txtVIPtoPUPRange.AllowFraction = true;
            this.txtVIPtoPUPRange.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPtoPUPRange.Location = new System.Drawing.Point(158, 59);
            this.txtVIPtoPUPRange.MaximumValue = new decimal(new int[] {
            999,
            0,
            0,
            65536});
            this.txtVIPtoPUPRange.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVIPtoPUPRange.Name = "txtVIPtoPUPRange";
            this.txtVIPtoPUPRange.Size = new System.Drawing.Size(90, 25);
            this.txtVIPtoPUPRange.TabIndex = 30;
            this.txtVIPtoPUPRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.NauticalMile;
            this.txtVIPtoPUPRange.Value = null;
            // 
            // txtVIPtoPUPElev
            // 
            this.txtVIPtoPUPElev.AllowFraction = false;
            this.txtVIPtoPUPElev.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPtoPUPElev.Location = new System.Drawing.Point(362, 59);
            this.txtVIPtoPUPElev.MaximumValue = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.txtVIPtoPUPElev.MinimumValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.txtVIPtoPUPElev.Name = "txtVIPtoPUPElev";
            this.txtVIPtoPUPElev.Size = new System.Drawing.Size(90, 25);
            this.txtVIPtoPUPElev.TabIndex = 32;
            this.txtVIPtoPUPElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtVIPtoPUPElev.Value = null;
            // 
            // txtVIPtoTGTBearing
            // 
            this.txtVIPtoTGTBearing.AllowFraction = true;
            this.txtVIPtoTGTBearing.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPtoTGTBearing.Location = new System.Drawing.Point(260, 31);
            this.txtVIPtoTGTBearing.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVIPtoTGTBearing.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVIPtoTGTBearing.Name = "txtVIPtoTGTBearing";
            this.txtVIPtoTGTBearing.Size = new System.Drawing.Size(90, 25);
            this.txtVIPtoTGTBearing.TabIndex = 27;
            this.txtVIPtoTGTBearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            this.txtVIPtoTGTBearing.Value = null;
            // 
            // txtVIPtoTGTElev
            // 
            this.txtVIPtoTGTElev.AllowFraction = false;
            this.txtVIPtoTGTElev.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPtoTGTElev.Location = new System.Drawing.Point(362, 31);
            this.txtVIPtoTGTElev.MaximumValue = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.txtVIPtoTGTElev.MinimumValue = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.txtVIPtoTGTElev.Name = "txtVIPtoTGTElev";
            this.txtVIPtoTGTElev.Size = new System.Drawing.Size(90, 25);
            this.txtVIPtoTGTElev.TabIndex = 28;
            this.txtVIPtoTGTElev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtVIPtoTGTElev.Value = null;
            // 
            // txtVIPtoTGTRange
            // 
            this.txtVIPtoTGTRange.AllowFraction = true;
            this.txtVIPtoTGTRange.BackColor = System.Drawing.SystemColors.Window;
            this.txtVIPtoTGTRange.Location = new System.Drawing.Point(158, 31);
            this.txtVIPtoTGTRange.MaximumValue = new decimal(new int[] {
            999,
            0,
            0,
            65536});
            this.txtVIPtoTGTRange.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVIPtoTGTRange.Name = "txtVIPtoTGTRange";
            this.txtVIPtoTGTRange.Size = new System.Drawing.Size(90, 25);
            this.txtVIPtoTGTRange.TabIndex = 26;
            this.txtVIPtoTGTRange.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.NauticalMile;
            this.txtVIPtoTGTRange.Value = null;
            // 
            // cboAirbases
            // 
            this.cboAirbases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAirbases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAirbases.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cboAirbases.FormattingEnabled = true;
            this.cboAirbases.Location = new System.Drawing.Point(163, 36);
            this.cboAirbases.Name = "cboAirbases";
            this.cboAirbases.Size = new System.Drawing.Size(420, 24);
            this.cboAirbases.TabIndex = 31;
            this.cboAirbases.SelectedIndexChanged += new System.EventHandler(this.cboAirbases_SelectedIndexChanged);
            // 
            // chkUseOA
            // 
            this.chkUseOA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseOA.Location = new System.Drawing.Point(9, 163);
            this.chkUseOA.Name = "chkUseOA";
            this.chkUseOA.Size = new System.Drawing.Size(135, 25);
            this.chkUseOA.TabIndex = 16;
            this.chkUseOA.Text = "Offset Aimpoints";
            this.chkUseOA.UseVisualStyleBackColor = true;
            this.chkUseOA.CheckedChanged += new System.EventHandler(this.chkUseOA_CheckedChanged);
            // 
            // txtTimeOverSteerpoint
            // 
            this.txtTimeOverSteerpoint.AllowPromptAsInput = true;
            this.txtTimeOverSteerpoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtTimeOverSteerpoint.HidePromptOnLeave = false;
            this.txtTimeOverSteerpoint.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtTimeOverSteerpoint.Location = new System.Drawing.Point(463, 128);
            this.txtTimeOverSteerpoint.Mask = "00\\:00\\:00";
            this.txtTimeOverSteerpoint.Name = "txtTimeOverSteerpoint";
            this.txtTimeOverSteerpoint.PromptChar = '_';
            this.txtTimeOverSteerpoint.Size = new System.Drawing.Size(120, 25);
            this.txtTimeOverSteerpoint.TabIndex = 15;
            this.txtTimeOverSteerpoint.ValidatingType = null;
            // 
            // chkUseVRP
            // 
            this.chkUseVRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseVRP.Location = new System.Drawing.Point(320, 163);
            this.chkUseVRP.Name = "chkUseVRP";
            this.chkUseVRP.Size = new System.Drawing.Size(177, 25);
            this.chkUseVRP.TabIndex = 25;
            this.chkUseVRP.Text = "Visual Reference Point";
            this.chkUseVRP.UseVisualStyleBackColor = true;
            this.chkUseVRP.CheckedChanged += new System.EventHandler(this.chkUseVRP_CheckedChanged);
            // 
            // chkUseVIP
            // 
            this.chkUseVIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseVIP.Location = new System.Drawing.Point(158, 163);
            this.chkUseVIP.Name = "chkUseVIP";
            this.chkUseVIP.Size = new System.Drawing.Size(156, 25);
            this.chkUseVIP.TabIndex = 25;
            this.chkUseVIP.Text = "Visual Initial Point";
            this.chkUseVIP.UseVisualStyleBackColor = true;
            this.chkUseVIP.CheckedChanged += new System.EventHandler(this.chkUseVIP_CheckedChanged);
            // 
            // txtWptName
            // 
            this.txtWptName.AllowPromptAsInput = true;
            this.txtWptName.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptName.HidePromptOnLeave = false;
            this.txtWptName.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptName.Location = new System.Drawing.Point(163, 66);
            this.txtWptName.Mask = "";
            this.txtWptName.Name = "txtWptName";
            this.txtWptName.PromptChar = '_';
            this.txtWptName.Size = new System.Drawing.Size(420, 25);
            this.txtWptName.TabIndex = 11;
            this.txtWptName.ValidatingType = null;
            // 
            // txtWptLatLong
            // 
            this.txtWptLatLong.AllowPromptAsInput = false;
            this.txtWptLatLong.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptLatLong.Format = DTC.Models.Base.CoordinateFormat.DegreesMinutesThousandths;
            this.txtWptLatLong.HidePromptOnLeave = false;
            this.txtWptLatLong.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptLatLong.Location = new System.Drawing.Point(163, 97);
            this.txtWptLatLong.Name = "txtWptLatLong";
            this.txtWptLatLong.PromptChar = '_';
            this.txtWptLatLong.Size = new System.Drawing.Size(294, 25);
            this.txtWptLatLong.TabIndex = 12;
            this.txtWptLatLong.ValidatingType = null;
            // 
            // txtWptElevation
            // 
            this.txtWptElevation.AllowFraction = false;
            this.txtWptElevation.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptElevation.Location = new System.Drawing.Point(163, 128);
            this.txtWptElevation.MaximumValue = new decimal(new int[] {
            25000,
            0,
            0,
            0});
            this.txtWptElevation.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWptElevation.Name = "txtWptElevation";
            this.txtWptElevation.Size = new System.Drawing.Size(130, 25);
            this.txtWptElevation.TabIndex = 14;
            this.txtWptElevation.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtWptElevation.Value = null;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancel.Location = new System.Drawing.Point(131, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 25);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(5, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 25);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtOA1Range
            // 
            this.txtOA1Range.AllowFraction = false;
            this.txtOA1Range.BackColor = System.Drawing.SystemColors.Window;
            this.txtOA1Range.Location = new System.Drawing.Point(158, 31);
            this.txtOA1Range.MaximumValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtOA1Range.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOA1Range.Name = "txtOA1Range";
            this.txtOA1Range.Size = new System.Drawing.Size(90, 25);
            this.txtOA1Range.TabIndex = 18;
            this.txtOA1Range.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtOA1Range.Value = null;
            // 
            // txtOA1Bearing
            // 
            this.txtOA1Bearing.AllowFraction = true;
            this.txtOA1Bearing.BackColor = System.Drawing.SystemColors.Window;
            this.txtOA1Bearing.Location = new System.Drawing.Point(260, 31);
            this.txtOA1Bearing.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOA1Bearing.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOA1Bearing.Name = "txtOA1Bearing";
            this.txtOA1Bearing.Size = new System.Drawing.Size(90, 25);
            this.txtOA1Bearing.TabIndex = 19;
            this.txtOA1Bearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            this.txtOA1Bearing.Value = null;
            // 
            // txtOA2Range
            // 
            this.txtOA2Range.AllowFraction = false;
            this.txtOA2Range.BackColor = System.Drawing.SystemColors.Window;
            this.txtOA2Range.Location = new System.Drawing.Point(158, 59);
            this.txtOA2Range.MaximumValue = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtOA2Range.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOA2Range.Name = "txtOA2Range";
            this.txtOA2Range.Size = new System.Drawing.Size(90, 25);
            this.txtOA2Range.TabIndex = 22;
            this.txtOA2Range.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtOA2Range.Value = null;
            // 
            // txtOA1Elev
            // 
            this.txtOA1Elev.AllowFraction = false;
            this.txtOA1Elev.BackColor = System.Drawing.SystemColors.Window;
            this.txtOA1Elev.Location = new System.Drawing.Point(362, 31);
            this.txtOA1Elev.MaximumValue = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.txtOA1Elev.MinimumValue = new decimal(new int[] {
            1500,
            0,
            0,
            -2147483648});
            this.txtOA1Elev.Name = "txtOA1Elev";
            this.txtOA1Elev.Size = new System.Drawing.Size(90, 25);
            this.txtOA1Elev.TabIndex = 20;
            this.txtOA1Elev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtOA1Elev.Value = null;
            // 
            // txtOA2Bearing
            // 
            this.txtOA2Bearing.AllowFraction = true;
            this.txtOA2Bearing.BackColor = System.Drawing.SystemColors.Window;
            this.txtOA2Bearing.Location = new System.Drawing.Point(260, 59);
            this.txtOA2Bearing.MaximumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOA2Bearing.MinimumValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOA2Bearing.Name = "txtOA2Bearing";
            this.txtOA2Bearing.Size = new System.Drawing.Size(90, 25);
            this.txtOA2Bearing.TabIndex = 23;
            this.txtOA2Bearing.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Degree;
            this.txtOA2Bearing.Value = null;
            // 
            // txtOA2Elev
            // 
            this.txtOA2Elev.AllowFraction = false;
            this.txtOA2Elev.BackColor = System.Drawing.SystemColors.Window;
            this.txtOA2Elev.Location = new System.Drawing.Point(362, 59);
            this.txtOA2Elev.MaximumValue = new decimal(new int[] {
            80000,
            0,
            0,
            0});
            this.txtOA2Elev.MinimumValue = new decimal(new int[] {
            1500,
            0,
            0,
            -2147483648});
            this.txtOA2Elev.Name = "txtOA2Elev";
            this.txtOA2Elev.Size = new System.Drawing.Size(90, 25);
            this.txtOA2Elev.TabIndex = 24;
            this.txtOA2Elev.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.Feet;
            this.txtOA2Elev.Value = null;
            // 
            // WaypointEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.pnlVRP);
            this.Controls.Add(this.pnlVIP);
            this.Controls.Add(this.cboAirbases);
            this.Controls.Add(this.chkUseOA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTimeOverSteerpoint);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.chkUseVRP);
            this.Controls.Add(this.chkUseVIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.txtWptName);
            this.Controls.Add(this.txtWptLatLong);
            this.Controls.Add(this.txtWptElevation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlOA);
            this.Name = "WaypointEdit";
            this.Size = new System.Drawing.Size(588, 668);
            this.pnlTop.ResumeLayout(false);
            this.pnlOA.ResumeLayout(false);
            this.pnlVIP.ResumeLayout(false);
            this.pnlVRP.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		private DTC.UI.Base.Controls.DTCCoordinateTextBox txtWptLatLong;
		private System.Windows.Forms.Label label5;
		private DTC.UI.Base.Controls.DTCTextBox txtWptName;
		private DTCNumericTextBox txtWptElevation;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Button btnCapture;
		private System.Windows.Forms.Label label3;
		private Base.Controls.DTCButton btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblValidation;
		private DTCTextBox txtTimeOverSteerpoint;
		private System.Windows.Forms.Label label4;
        private DTCDropDown cboAirbases;
        private DTCButton btnCancel;
        private DTCNumericTextBox txtOA1Range;
        private DTCNumericTextBox txtOA1Bearing;
        private DTCNumericTextBox txtOA1Elev;
        private DTCNumericTextBox txtOA2Range;
        private DTCNumericTextBox txtOA2Bearing;
        private DTCNumericTextBox txtOA2Elev;
        private DTCNumericTextBox txtVIPtoTGTRange;
        private DTCNumericTextBox txtVIPtoTGTBearing;
        private DTCNumericTextBox txtVIPtoTGTElev;
        private DTCNumericTextBox txtVIPtoPUPRange;
        private DTCNumericTextBox txtVIPtoPUPBearing;
        private DTCNumericTextBox txtVIPtoPUPElev;
        private DTCNumericTextBox txtTGTtoVRPRange;
        private DTCNumericTextBox txtTGTtoPUPRange;
        private DTCNumericTextBox txtTGTtoVRPBearing;
        private DTCNumericTextBox txtTGTtoVRPElev;
        private DTCNumericTextBox txtTGTtoPUPBearing;
        private DTCNumericTextBox txtTGTtoPUPElev;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DTCCheckBox chkUseOA;
        private System.Windows.Forms.Panel pnlOA;
        private DTCCheckBox chkUseVIP;
        private DTCCheckBox chkUseVRP;
        private System.Windows.Forms.Panel pnlVIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlVRP;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
    }
}
