
using DTC.Models.Base;
using DTC.UI.Base.Controls;
using System;

namespace DTC.UI.CommonPages
{
	partial class WaypointCapturePage
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
            this.components = new System.ComponentModel.Container();
            this.txtOverwriteFrom = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.radAppend = new System.Windows.Forms.RadioButton();
            this.radOverwrite = new System.Windows.Forms.RadioButton();
            this.lblOverwriteFrom = new System.Windows.Forms.Label();
            this.txtOverwriteUntil = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.chkUpload = new System.Windows.Forms.CheckBox();
            this.radSourceAll = new System.Windows.Forms.RadioButton();
            this.radSourceRange = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSourceRangeFrom = new System.Windows.Forms.Label();
            this.txtSourceRangeUntil = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtSourceRangeFrom = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtDestRouteFrom = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.txtDestRouteUntil = new DTC.UI.Base.Controls.DTCNumericTextBox();
            this.lblDestRouteFrom = new System.Windows.Forms.Label();
            this.radDestRoute = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDestination = new System.Windows.Forms.Panel();
            this.lblDestRouteUntil = new System.Windows.Forms.Label();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.lblSourceRangeUntil = new System.Windows.Forms.Label();
            this.lblOverwriteUntil = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlDestination.SuspendLayout();
            this.pnlSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOverwriteFrom
            // 
            this.txtOverwriteFrom.AllowFraction = false;
            this.txtOverwriteFrom.BackColor = System.Drawing.SystemColors.Window;
            this.txtOverwriteFrom.Enabled = false;
            this.txtOverwriteFrom.Location = new System.Drawing.Point(96, 68);
            this.txtOverwriteFrom.MaximumValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtOverwriteFrom.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOverwriteFrom.Name = "txtOverwriteFrom";
            this.txtOverwriteFrom.Size = new System.Drawing.Size(57, 25);
            this.txtOverwriteFrom.TabIndex = 4;
            this.txtOverwriteFrom.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            this.txtOverwriteFrom.Value = null;
            this.txtOverwriteFrom.TextBoxChanged += new DTC.UI.Base.Controls.DTCNumericTextBox.TextBoxChangedCallback(this.txtOverwriteFrom_TextBoxChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 100;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 20;
            // 
            // radAppend
            // 
            this.radAppend.AutoSize = true;
            this.radAppend.Checked = true;
            this.radAppend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAppend.Location = new System.Drawing.Point(16, 17);
            this.radAppend.Name = "radAppend";
            this.radAppend.Size = new System.Drawing.Size(171, 21);
            this.radAppend.TabIndex = 33;
            this.radAppend.TabStop = true;
            this.radAppend.Text = "Append to waypoint list";
            this.radAppend.UseVisualStyleBackColor = true;
            this.radAppend.CheckedChanged += new System.EventHandler(this.radAppend_CheckedChanged);
            // 
            // radOverwrite
            // 
            this.radOverwrite.AutoSize = true;
            this.radOverwrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radOverwrite.Location = new System.Drawing.Point(16, 44);
            this.radOverwrite.Name = "radOverwrite";
            this.radOverwrite.Size = new System.Drawing.Size(131, 21);
            this.radOverwrite.TabIndex = 33;
            this.radOverwrite.Text = "Overwrite range:";
            this.radOverwrite.UseVisualStyleBackColor = true;
            this.radOverwrite.CheckedChanged += new System.EventHandler(this.radOverwrite_CheckedChanged);
            // 
            // lblOverwriteFrom
            // 
            this.lblOverwriteFrom.Enabled = false;
            this.lblOverwriteFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblOverwriteFrom.Location = new System.Drawing.Point(43, 68);
            this.lblOverwriteFrom.Margin = new System.Windows.Forms.Padding(0);
            this.lblOverwriteFrom.Name = "lblOverwriteFrom";
            this.lblOverwriteFrom.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblOverwriteFrom.Size = new System.Drawing.Size(51, 25);
            this.lblOverwriteFrom.TabIndex = 31;
            this.lblOverwriteFrom.Text = "From:";
            this.lblOverwriteFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOverwriteUntil
            // 
            this.txtOverwriteUntil.AllowFraction = false;
            this.txtOverwriteUntil.BackColor = System.Drawing.SystemColors.Window;
            this.txtOverwriteUntil.Enabled = false;
            this.txtOverwriteUntil.Location = new System.Drawing.Point(228, 68);
            this.txtOverwriteUntil.MaximumValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtOverwriteUntil.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOverwriteUntil.Name = "txtOverwriteUntil";
            this.txtOverwriteUntil.Size = new System.Drawing.Size(57, 25);
            this.txtOverwriteUntil.TabIndex = 4;
            this.txtOverwriteUntil.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            this.txtOverwriteUntil.Value = null;
            this.txtOverwriteUntil.TextBoxChanged += new DTC.UI.Base.Controls.DTCNumericTextBox.TextBoxChangedCallback(this.txtOverwriteUntil_TextBoxChanged);
            // 
            // chkUpload
            // 
            this.chkUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkUpload.Location = new System.Drawing.Point(16, 127);
            this.chkUpload.Margin = new System.Windows.Forms.Padding(4);
            this.chkUpload.Name = "chkUpload";
            this.chkUpload.Size = new System.Drawing.Size(234, 25);
            this.chkUpload.TabIndex = 32;
            this.chkUpload.Text = "Upload to Jet";
            this.chkUpload.UseVisualStyleBackColor = true;
            this.chkUpload.Visible = false;
            // 
            // radSourceAll
            // 
            this.radSourceAll.AutoSize = true;
            this.radSourceAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSourceAll.Location = new System.Drawing.Point(36, 28);
            this.radSourceAll.Name = "radSourceAll";
            this.radSourceAll.Size = new System.Drawing.Size(107, 21);
            this.radSourceAll.TabIndex = 33;
            this.radSourceAll.TabStop = true;
            this.radSourceAll.Text = "All waypoints";
            this.radSourceAll.UseVisualStyleBackColor = true;
            // 
            // radSourceRange
            // 
            this.radSourceRange.AutoSize = true;
            this.radSourceRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSourceRange.Location = new System.Drawing.Point(36, 55);
            this.radSourceRange.Name = "radSourceRange";
            this.radSourceRange.Size = new System.Drawing.Size(72, 21);
            this.radSourceRange.TabIndex = 33;
            this.radSourceRange.TabStop = true;
            this.radSourceRange.Text = "Range:";
            this.radSourceRange.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Source:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 37;
            this.label4.Text = "Destination:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSourceRangeFrom
            // 
            this.lblSourceRangeFrom.Enabled = false;
            this.lblSourceRangeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSourceRangeFrom.Location = new System.Drawing.Point(66, 82);
            this.lblSourceRangeFrom.Margin = new System.Windows.Forms.Padding(0);
            this.lblSourceRangeFrom.Name = "lblSourceRangeFrom";
            this.lblSourceRangeFrom.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSourceRangeFrom.Size = new System.Drawing.Size(51, 25);
            this.lblSourceRangeFrom.TabIndex = 41;
            this.lblSourceRangeFrom.Text = "From:";
            this.lblSourceRangeFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSourceRangeUntil
            // 
            this.txtSourceRangeUntil.AllowFraction = false;
            this.txtSourceRangeUntil.BackColor = System.Drawing.SystemColors.Window;
            this.txtSourceRangeUntil.Enabled = false;
            this.txtSourceRangeUntil.Location = new System.Drawing.Point(255, 82);
            this.txtSourceRangeUntil.MaximumValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtSourceRangeUntil.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSourceRangeUntil.Name = "txtSourceRangeUntil";
            this.txtSourceRangeUntil.Size = new System.Drawing.Size(57, 25);
            this.txtSourceRangeUntil.TabIndex = 39;
            this.txtSourceRangeUntil.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            this.txtSourceRangeUntil.Value = null;
            // 
            // txtSourceRangeFrom
            // 
            this.txtSourceRangeFrom.AllowFraction = false;
            this.txtSourceRangeFrom.BackColor = System.Drawing.SystemColors.Window;
            this.txtSourceRangeFrom.Enabled = false;
            this.txtSourceRangeFrom.Location = new System.Drawing.Point(120, 82);
            this.txtSourceRangeFrom.MaximumValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtSourceRangeFrom.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSourceRangeFrom.Name = "txtSourceRangeFrom";
            this.txtSourceRangeFrom.Size = new System.Drawing.Size(57, 25);
            this.txtSourceRangeFrom.TabIndex = 40;
            this.txtSourceRangeFrom.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            this.txtSourceRangeFrom.Value = null;
            // 
            // txtDestRouteFrom
            // 
            this.txtDestRouteFrom.AllowFraction = false;
            this.txtDestRouteFrom.BackColor = System.Drawing.SystemColors.Window;
            this.txtDestRouteFrom.Location = new System.Drawing.Point(119, 60);
            this.txtDestRouteFrom.MaximumValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtDestRouteFrom.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDestRouteFrom.Name = "txtDestRouteFrom";
            this.txtDestRouteFrom.Size = new System.Drawing.Size(57, 25);
            this.txtDestRouteFrom.TabIndex = 40;
            this.txtDestRouteFrom.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            this.txtDestRouteFrom.Value = null;
            // 
            // txtDestRouteUntil
            // 
            this.txtDestRouteUntil.AllowFraction = false;
            this.txtDestRouteUntil.BackColor = System.Drawing.SystemColors.Window;
            this.txtDestRouteUntil.Location = new System.Drawing.Point(255, 60);
            this.txtDestRouteUntil.MaximumValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtDestRouteUntil.MinimumValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDestRouteUntil.Name = "txtDestRouteUntil";
            this.txtDestRouteUntil.Size = new System.Drawing.Size(57, 25);
            this.txtDestRouteUntil.TabIndex = 39;
            this.txtDestRouteUntil.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            this.txtDestRouteUntil.Value = null;
            // 
            // lblDestRouteFrom
            // 
            this.lblDestRouteFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDestRouteFrom.Location = new System.Drawing.Point(65, 60);
            this.lblDestRouteFrom.Margin = new System.Windows.Forms.Padding(0);
            this.lblDestRouteFrom.Name = "lblDestRouteFrom";
            this.lblDestRouteFrom.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDestRouteFrom.Size = new System.Drawing.Size(51, 25);
            this.lblDestRouteFrom.TabIndex = 41;
            this.lblDestRouteFrom.Text = "From:";
            this.lblDestRouteFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radDestRoute
            // 
            this.radDestRoute.AutoSize = true;
            this.radDestRoute.Checked = true;
            this.radDestRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDestRoute.Location = new System.Drawing.Point(32, 28);
            this.radDestRoute.Name = "radDestRoute";
            this.radDestRoute.Size = new System.Drawing.Size(77, 21);
            this.radDestRoute.TabIndex = 33;
            this.radDestRoute.TabStop = true;
            this.radDestRoute.Text = "Route A";
            this.radDestRoute.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlDestination);
            this.panel1.Controls.Add(this.pnlSource);
            this.panel1.Location = new System.Drawing.Point(46, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 251);
            this.panel1.TabIndex = 43;
            this.panel1.Visible = false;
            // 
            // pnlDestination
            // 
            this.pnlDestination.Controls.Add(this.label4);
            this.pnlDestination.Controls.Add(this.txtDestRouteFrom);
            this.pnlDestination.Controls.Add(this.lblDestRouteUntil);
            this.pnlDestination.Controls.Add(this.lblDestRouteFrom);
            this.pnlDestination.Controls.Add(this.txtDestRouteUntil);
            this.pnlDestination.Controls.Add(this.radDestRoute);
            this.pnlDestination.Enabled = false;
            this.pnlDestination.Location = new System.Drawing.Point(0, 121);
            this.pnlDestination.Name = "pnlDestination";
            this.pnlDestination.Size = new System.Drawing.Size(552, 100);
            this.pnlDestination.TabIndex = 43;
            // 
            // lblDestRouteUntil
            // 
            this.lblDestRouteUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDestRouteUntil.Location = new System.Drawing.Point(191, 60);
            this.lblDestRouteUntil.Margin = new System.Windows.Forms.Padding(0);
            this.lblDestRouteUntil.Name = "lblDestRouteUntil";
            this.lblDestRouteUntil.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblDestRouteUntil.Size = new System.Drawing.Size(51, 25);
            this.lblDestRouteUntil.TabIndex = 41;
            this.lblDestRouteUntil.Text = "Until:";
            this.lblDestRouteUntil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.label3);
            this.pnlSource.Controls.Add(this.txtSourceRangeFrom);
            this.pnlSource.Controls.Add(this.radSourceAll);
            this.pnlSource.Controls.Add(this.txtSourceRangeUntil);
            this.pnlSource.Controls.Add(this.radSourceRange);
            this.pnlSource.Controls.Add(this.lblSourceRangeUntil);
            this.pnlSource.Controls.Add(this.lblSourceRangeFrom);
            this.pnlSource.Enabled = false;
            this.pnlSource.Location = new System.Drawing.Point(0, 0);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Size = new System.Drawing.Size(334, 115);
            this.pnlSource.TabIndex = 43;
            // 
            // lblSourceRangeUntil
            // 
            this.lblSourceRangeUntil.Enabled = false;
            this.lblSourceRangeUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSourceRangeUntil.Location = new System.Drawing.Point(191, 82);
            this.lblSourceRangeUntil.Margin = new System.Windows.Forms.Padding(0);
            this.lblSourceRangeUntil.Name = "lblSourceRangeUntil";
            this.lblSourceRangeUntil.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSourceRangeUntil.Size = new System.Drawing.Size(51, 25);
            this.lblSourceRangeUntil.TabIndex = 41;
            this.lblSourceRangeUntil.Text = "Until:";
            this.lblSourceRangeUntil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverwriteUntil
            // 
            this.lblOverwriteUntil.Enabled = false;
            this.lblOverwriteUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblOverwriteUntil.Location = new System.Drawing.Point(163, 68);
            this.lblOverwriteUntil.Margin = new System.Windows.Forms.Padding(0);
            this.lblOverwriteUntil.Name = "lblOverwriteUntil";
            this.lblOverwriteUntil.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblOverwriteUntil.Size = new System.Drawing.Size(51, 25);
            this.lblOverwriteUntil.TabIndex = 31;
            this.lblOverwriteUntil.Text = "Until:";
            this.lblOverwriteUntil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaypointCapturePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.txtOverwriteUntil);
            this.Controls.Add(this.txtOverwriteFrom);
            this.Controls.Add(this.lblOverwriteUntil);
            this.Controls.Add(this.lblOverwriteFrom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radOverwrite);
            this.Controls.Add(this.radAppend);
            this.Controls.Add(this.chkUpload);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WaypointCapturePage";
            this.Size = new System.Drawing.Size(616, 454);
            this.panel1.ResumeLayout(false);
            this.pnlDestination.ResumeLayout(false);
            this.pnlDestination.PerformLayout();
            this.pnlSource.ResumeLayout(false);
            this.pnlSource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private DTCNumericTextBox txtOverwriteFrom;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton radAppend;
        private System.Windows.Forms.RadioButton radOverwrite;
        private System.Windows.Forms.Label lblOverwriteFrom;
        private DTCNumericTextBox txtOverwriteUntil;
        private System.Windows.Forms.CheckBox chkUpload;
        private System.Windows.Forms.RadioButton radSourceAll;
        private System.Windows.Forms.RadioButton radSourceRange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSourceRangeFrom;
        private DTCNumericTextBox txtSourceRangeUntil;
        private DTCNumericTextBox txtSourceRangeFrom;
        private DTCNumericTextBox txtDestRouteFrom;
        private DTCNumericTextBox txtDestRouteUntil;
        private System.Windows.Forms.Label lblDestRouteFrom;
        private System.Windows.Forms.RadioButton radDestRoute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDestination;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.Label lblDestRouteUntil;
        private System.Windows.Forms.Label lblSourceRangeUntil;
        private System.Windows.Forms.Label lblOverwriteUntil;
    }
}
