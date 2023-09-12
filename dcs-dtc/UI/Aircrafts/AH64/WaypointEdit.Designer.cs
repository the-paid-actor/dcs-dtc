using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.AH64
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWptFree = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptMGRS = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptElevation = new DTC.UI.Base.Controls.DTCTextBox();
            this.lblValidation = new DTC.UI.Base.Controls.DTCLabel();
            this.dtcButton1 = new DTC.UI.Base.Controls.DTCButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtWptType = new DTC.UI.Base.Controls.DTCDropDown();
            this.txtWptIdent = new DTC.UI.Base.Controls.DTCDropDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPointType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWptFree
            // 
            this.txtWptFree.AllowPromptAsInput = true;
            this.txtWptFree.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptFree.HidePromptOnLeave = false;
            this.txtWptFree.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptFree.Location = new System.Drawing.Point(170, 149);
            this.txtWptFree.Mask = "";
            this.txtWptFree.Name = "txtWptFree";
            this.txtWptFree.PromptChar = '_';
            this.txtWptFree.Size = new System.Drawing.Size(80, 41);
            this.txtWptFree.TabIndex = 2;
            this.txtWptFree.ValidatingType = null;
            // 
            // txtWptMGRS
            // 
            this.txtWptMGRS.AllowPromptAsInput = true;
            this.txtWptMGRS.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptMGRS.HidePromptOnLeave = false;
            this.txtWptMGRS.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptMGRS.Location = new System.Drawing.Point(170, 211);
            this.txtWptMGRS.Mask = ">00 LLL 0000 0000";
            this.txtWptMGRS.Name = "txtWptMGRS";
            this.txtWptMGRS.PromptChar = '_';
            this.txtWptMGRS.Size = new System.Drawing.Size(240, 42);
            this.txtWptMGRS.TabIndex = 3;
            this.txtWptMGRS.ValidatingType = null;
            // 
            // txtWptElevation
            // 
            this.txtWptElevation.AllowPromptAsInput = true;
            this.txtWptElevation.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptElevation.HidePromptOnLeave = false;
            this.txtWptElevation.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptElevation.Location = new System.Drawing.Point(170, 259);
            this.txtWptElevation.Mask = "";
            this.txtWptElevation.Name = "txtWptElevation";
            this.txtWptElevation.PromptChar = '_';
            this.txtWptElevation.Size = new System.Drawing.Size(100, 41);
            this.txtWptElevation.TabIndex = 4;
            this.txtWptElevation.ValidatingType = null;
            // 
            // lblValidation
            // 
            this.lblValidation.AutoSize = true;
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(32, 329);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(0, 25);
            this.lblValidation.TabIndex = 5;
            // 
            // dtcButton1
            // 
            this.dtcButton1.BackColor = System.Drawing.Color.DarkKhaki;
            this.dtcButton1.FlatAppearance.BorderSize = 0;
            this.dtcButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dtcButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtcButton1.Location = new System.Drawing.Point(659, 299);
            this.dtcButton1.Name = "dtcButton1";
            this.dtcButton1.Size = new System.Drawing.Size(150, 40);
            this.dtcButton1.TabIndex = 6;
            this.dtcButton1.Text = "Save";
            this.dtcButton1.UseVisualStyleBackColor = false;
            this.dtcButton1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 55);
            this.panel1.TabIndex = 7;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblClose.Location = new System.Drawing.Point(762, 0);
            this.lblClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(75, 55);
            this.lblClose.TabIndex = 24;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(837, 55);
            this.lblTitle.TabIndex = 23;
            this.lblTitle.Text = "Add Waypoint";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWptType
            // 
            this.txtWptType.AllowDrop = true;
            this.txtWptType.DropDownHeight = 125;
            this.txtWptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtWptType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtWptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtWptType.FormattingEnabled = true;
            this.txtWptType.IntegralHeight = false;
            this.txtWptType.ItemHeight = 25;
            this.txtWptType.Location = new System.Drawing.Point(170, 103);
            this.txtWptType.Name = "txtWptType";
            this.txtWptType.Size = new System.Drawing.Size(80, 33);
            this.txtWptType.TabIndex = 8;
            // 
            // txtWptIdent
            // 
            this.txtWptIdent.AllowDrop = true;
            this.txtWptIdent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtWptIdent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtWptIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtWptIdent.FormattingEnabled = true;
            this.txtWptIdent.Location = new System.Drawing.Point(437, 109);
            this.txtWptIdent.Name = "txtWptIdent";
            this.txtWptIdent.Size = new System.Drawing.Size(80, 33);
            this.txtWptIdent.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(12, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(155, 38);
            this.label2.TabIndex = 28;
            this.label2.Text = "Elevation:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 224);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(155, 38);
            this.label1.TabIndex = 29;
            this.label1.Text = "MGRS:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(155, 38);
            this.label3.TabIndex = 30;
            this.label3.Text = "Free:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(345, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(89, 38);
            this.label4.TabIndex = 31;
            this.label4.Text = "Ident:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(155, 38);
            this.label5.TabIndex = 32;
            this.label5.Text = "Type:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPointType
            // 
            this.cboPointType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPointType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPointType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboPointType.FormattingEnabled = true;
            this.cboPointType.Location = new System.Drawing.Point(170, 58);
            this.cboPointType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboPointType.Name = "cboPointType";
            this.cboPointType.Size = new System.Drawing.Size(639, 37);
            this.cboPointType.TabIndex = 33;
            this.cboPointType.SelectedIndexChanged += new System.EventHandler(this.cboPointType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(11, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label6.Size = new System.Drawing.Size(155, 38);
            this.label6.TabIndex = 34;
            this.label6.Text = "Preset:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WaypointEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPointType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWptIdent);
            this.Controls.Add(this.txtWptType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtcButton1);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.txtWptElevation);
            this.Controls.Add(this.txtWptMGRS);
            this.Controls.Add(this.txtWptFree);
            this.Name = "WaypointEdit";
            this.Size = new System.Drawing.Size(835, 393);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DTC.UI.Base.Controls.DTCTextBox txtWptFree;
        private DTC.UI.Base.Controls.DTCTextBox txtWptMGRS;
        private DTC.UI.Base.Controls.DTCTextBox txtWptElevation;
        private DTC.UI.Base.Controls.DTCLabel lblValidation;
        private DTCButton dtcButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClose;
        private DTCDropDown txtWptType;
        private DTCDropDown txtWptIdent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPointType;
        private System.Windows.Forms.Label label6;
    }
}
