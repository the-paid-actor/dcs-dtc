using DTC.Models;
using DTC.Models.Base;
using DTC.Models.DCS;
using DTC.Models.AH64.Waypoints;
using DTC.UI.Base;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.AH64
{
    public partial class WaypointEdit : UserControl
    {
        public enum WaypointEditResult
        {
            Add = 1,
            SaveAndClose = 2,
            Close = 3
        }

        public delegate void WaypointEditCallback(WaypointEditResult result, Waypoint wpt);


        private readonly WaypointEditCallback _callback;
        private WaypointSystem _flightPlan;
        private Waypoint _waypoint = null;
        private Label label2;
        private DTC.UI.Base.Controls.DTCTextBox txtWptElevation;
        private DTC.UI.Base.Controls.DTCButton btnSave;
        private Label lblValidation;
        private Panel pnlTop;
        private Label lblClose;
        private Label lblTitle;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private DTC.UI.Base.Controls.DTCTextBox txtWptMGRS;
        private DTC.UI.Base.Controls.DTCTextBox txtWptFree;
        private DTC.UI.Base.Controls.DTCTextBox txtWptIdent;
        private DTC.UI.Base.Controls.DTCTextBox txtWptType;
        private WaypointCapture _waypointCapture;

        public WaypointEdit(WaypointSystem flightPlan, WaypointEditCallback callback)
        {
            _callback = callback;
            _flightPlan = flightPlan;
        }

        public void ShowDialog(Waypoint wpt = null)
        {
            this.Visible = true;
            this.BringToFront();
            _waypoint = wpt;

            if (wpt != null)
            {
                LoadWaypoint(wpt);
                txtWptType.Focus();
            }
            else
            {
                ResetFields();
            }
        }

        private void LoadWaypoint(Waypoint wpt)
        {
            txtWptType.Text = wpt.Type;
            txtWptIdent.Text = wpt.Ident;
            txtWptFree.Text = wpt.Free;
            txtWptMGRS.Text = wpt.Mgrs;
            txtWptElevation.Text = wpt.Elevation.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            _callback(WaypointEditResult.Close, null);
            CloseDialog();
        }

        private void CloseDialog()
        {
            _waypoint = null;

            Visible = false;
            ResetFields();
        }

        private bool ValidateFields()
        {
            lblValidation.Text = "";
            if (ValidateElevation() && ValidateMGRS()  && ValidateIdent() && ValidateType())
            {
                return true;
            }
            return false;
        }

        private bool ValidateType()
        {
            if (txtWptType.Text != "WP" && txtWptType.Text != "TG" && txtWptType.Text != "CM")
            {
                lblValidation.Text = "Invalid type";
                txtWptType.Focus();
                return false;
            }

            return true;
        }
        private bool ValidateMGRS()
        {
            if ( !Waypoint.IsMGRSValid(txtWptMGRS.Text))
            {
                lblValidation.Text = "Invalid MGRS";
                txtWptMGRS.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateElevation()
        {
            if (!Util.IsValidInt(txtWptElevation.Text))
            {
                lblValidation.Text = "Invalid elevation";
                txtWptElevation.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateIdent()
        {
            if (txtWptIdent.Text == "" || txtWptIdent.Text.Length != 3)
            {
                lblValidation.Text = "Invalid Ident";
                txtWptIdent.Focus();
                return false;
            }

            return true;
        }

        private void ResetFields()
        {
            txtWptType.Text = "WP";
            txtWptIdent.Text = "WP1";
            txtWptFree.Text = "";
            txtWptElevation.Text = "0";
            txtWptMGRS.Focus();
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtWptElevation = new DTC.UI.Base.Controls.DTCTextBox();
            this.btnSave = new DTC.UI.Base.Controls.DTCButton();
            this.lblValidation = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWptMGRS = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptFree = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptIdent = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWptType = new DTC.UI.Base.Controls.DTCTextBox();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(0, 273);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(225, 38);
            this.label2.TabIndex = 28;
            this.label2.Text = "Elevation:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWptElevation
            // 
            this.txtWptElevation.AllowPromptAsInput = true;
            this.txtWptElevation.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptElevation.HidePromptOnLeave = false;
            this.txtWptElevation.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptElevation.Location = new System.Drawing.Point(220, 268);
            this.txtWptElevation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWptElevation.Mask = "";
            this.txtWptElevation.Name = "txtWptElevation";
            this.txtWptElevation.PromptChar = '_';
            this.txtWptElevation.Size = new System.Drawing.Size(150, 43);
            this.txtWptElevation.TabIndex = 29;
            this.txtWptElevation.ValidatingType = null;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(574, 480);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 38);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // lblValidation
            // 
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(0, 635);
            this.lblValidation.Margin = new System.Windows.Forms.Padding(0);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblValidation.Size = new System.Drawing.Size(822, 38);
            this.lblValidation.TabIndex = 32;
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(771, 46);
            this.pnlTop.TabIndex = 33;
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblClose.Location = new System.Drawing.Point(696, 0);
            this.lblClose.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(75, 46);
            this.lblClose.TabIndex = 23;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblTitle.Size = new System.Drawing.Size(696, 46);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "Add Waypoint";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(0, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(225, 38);
            this.label1.TabIndex = 34;
            this.label1.Text = "Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(0, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(225, 38);
            this.label3.TabIndex = 35;
            this.label3.Text = "Ident:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(0, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(225, 38);
            this.label4.TabIndex = 36;
            this.label4.Text = "Free:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(0, 220);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(225, 38);
            this.label5.TabIndex = 37;
            this.label5.Text = "MGRS:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWptMGRS
            // 
            this.txtWptMGRS.AllowPromptAsInput = true;
            this.txtWptMGRS.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptMGRS.HidePromptOnLeave = false;
            this.txtWptMGRS.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptMGRS.Location = new System.Drawing.Point(220, 215);
            this.txtWptMGRS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWptMGRS.Mask = "";
            this.txtWptMGRS.Name = "txtWptMGRS";
            this.txtWptMGRS.PromptChar = '_';
            this.txtWptMGRS.Size = new System.Drawing.Size(534, 43);
            this.txtWptMGRS.TabIndex = 38;
            this.txtWptMGRS.ValidatingType = null;
            // 
            // txtWptFree
            // 
            this.txtWptFree.AllowPromptAsInput = true;
            this.txtWptFree.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptFree.HidePromptOnLeave = false;
            this.txtWptFree.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptFree.Location = new System.Drawing.Point(220, 162);
            this.txtWptFree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWptFree.Mask = "";
            this.txtWptFree.Name = "txtWptFree";
            this.txtWptFree.PromptChar = '_';
            this.txtWptFree.Size = new System.Drawing.Size(89, 43);
            this.txtWptFree.TabIndex = 39;
            this.txtWptFree.ValidatingType = null;
            // 
            // txtWptIdent
            // 
            this.txtWptIdent.AllowPromptAsInput = true;
            this.txtWptIdent.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptIdent.HidePromptOnLeave = false;
            this.txtWptIdent.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptIdent.Location = new System.Drawing.Point(220, 109);
            this.txtWptIdent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWptIdent.Mask = "";
            this.txtWptIdent.Name = "txtWptIdent";
            this.txtWptIdent.PromptChar = '_';
            this.txtWptIdent.Size = new System.Drawing.Size(58, 43);
            this.txtWptIdent.TabIndex = 40;
            this.txtWptIdent.ValidatingType = null;
            // 
            // txtWptType
            // 
            this.txtWptType.AllowPromptAsInput = true;
            this.txtWptType.BackColor = System.Drawing.SystemColors.Window;
            this.txtWptType.HidePromptOnLeave = false;
            this.txtWptType.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtWptType.Location = new System.Drawing.Point(220, 56);
            this.txtWptType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWptType.Mask = "";
            this.txtWptType.Name = "txtWptType";
            this.txtWptType.PromptChar = '_';
            this.txtWptType.Size = new System.Drawing.Size(58, 43);
            this.txtWptType.TabIndex = 41;
            this.txtWptType.ValidatingType = null;
            // 
            // WaypointEdit
            // 
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.txtWptType);
            this.Controls.Add(this.txtWptIdent);
            this.Controls.Add(this.txtWptFree);
            this.Controls.Add(this.txtWptMGRS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWptElevation);
            this.Controls.Add(this.label2);
            this.Name = "WaypointEdit";
            this.Size = new System.Drawing.Size(771, 528);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
