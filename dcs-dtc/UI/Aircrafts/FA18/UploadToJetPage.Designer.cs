
using DTC.UI.Base.Controls;

namespace DTC.UI.Aircrafts.FA18
{
    partial class UploadToJetPage
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
            cockpitUploadHelper.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadToJetPage));
            chkRadios = new CheckBox();
            chkWaypoints = new CheckBox();
            label1 = new Label();
            txtWaypointStart = new DTCTextBox();
            btnUpload = new DTCButton();
            toolTip1 = new ToolTip(components);
            chkMisc = new CheckBox();
            cbSequences = new CheckBox();
            cbPrePlanned = new CheckBox();
            cbCMS = new CheckBox();
            cbAAWeapons = new CheckBox();
            SuspendLayout();
            // 
            // chkRadios
            // 
            chkRadios.Checked = true;
            chkRadios.CheckState = CheckState.Checked;
            chkRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRadios.Location = new Point(16, 183);
            chkRadios.Margin = new Padding(4);
            chkRadios.Name = "chkRadios";
            chkRadios.Size = new Size(78, 25);
            chkRadios.TabIndex = 4;
            chkRadios.Text = "Radios";
            chkRadios.UseVisualStyleBackColor = true;
            chkRadios.CheckedChanged += chkRadios_CheckedChanged;
            // 
            // chkWaypoints
            // 
            chkWaypoints.Checked = true;
            chkWaypoints.CheckState = CheckState.Checked;
            chkWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkWaypoints.Location = new Point(16, 18);
            chkWaypoints.Margin = new Padding(4);
            chkWaypoints.Name = "chkWaypoints";
            chkWaypoints.Size = new Size(102, 25);
            chkWaypoints.TabIndex = 0;
            chkWaypoints.Text = "Waypoints";
            chkWaypoints.UseVisualStyleBackColor = true;
            chkWaypoints.CheckedChanged += chkWaypoints_CheckedChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(125, 21);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 5;
            label1.Text = "Starting at WYPT";
            toolTip1.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            label1.Click += label1_Click;
            // 
            // txtWaypointStart
            // 
            txtWaypointStart.AllowPromptAsInput = false;
            txtWaypointStart.BackColor = SystemColors.Window;
            txtWaypointStart.HidePromptOnLeave = true;
            txtWaypointStart.InsertKeyMode = InsertKeyMode.Overwrite;
            txtWaypointStart.Location = new Point(249, 18);
            txtWaypointStart.Mask = "000";
            txtWaypointStart.Name = "txtWaypointStart";
            txtWaypointStart.PromptChar = ' ';
            txtWaypointStart.Size = new Size(57, 25);
            txtWaypointStart.TabIndex = 1;
            txtWaypointStart.ValidatingType = typeof(int);
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.DarkKhaki;
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpload.Location = new Point(16, 266);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(120, 25);
            btnUpload.TabIndex = 7;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 20;
            // 
            // chkMisc
            // 
            chkMisc.Checked = true;
            chkMisc.CheckState = CheckState.Checked;
            chkMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMisc.Location = new Point(16, 216);
            chkMisc.Margin = new Padding(4);
            chkMisc.Name = "chkMisc";
            chkMisc.Size = new Size(167, 25);
            chkMisc.TabIndex = 5;
            chkMisc.Text = "Misc";
            chkMisc.UseVisualStyleBackColor = true;
            chkMisc.CheckedChanged += chkMisc_CheckedChanged;
            // 
            // cbSequences
            // 
            cbSequences.Checked = true;
            cbSequences.CheckState = CheckState.Checked;
            cbSequences.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbSequences.Location = new Point(16, 51);
            cbSequences.Margin = new Padding(4);
            cbSequences.Name = "cbSequences";
            cbSequences.Size = new Size(102, 25);
            cbSequences.TabIndex = 8;
            cbSequences.Text = "Sequences";
            cbSequences.UseVisualStyleBackColor = true;
            cbSequences.CheckedChanged += cbSequences_CheckedChanged;
            // 
            // cbPrePlanned
            // 
            cbPrePlanned.Checked = true;
            cbPrePlanned.CheckState = CheckState.Checked;
            cbPrePlanned.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbPrePlanned.Location = new Point(16, 84);
            cbPrePlanned.Margin = new Padding(4);
            cbPrePlanned.Name = "cbPrePlanned";
            cbPrePlanned.Size = new Size(201, 25);
            cbPrePlanned.TabIndex = 9;
            cbPrePlanned.Text = "Pre Planned Coordinates";
            cbPrePlanned.UseVisualStyleBackColor = true;
            cbPrePlanned.CheckedChanged += cbPrePlanned_CheckedChanged;
            // 
            // cbCMS
            // 
            cbCMS.Checked = true;
            cbCMS.CheckState = CheckState.Checked;
            cbCMS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbCMS.Location = new Point(16, 117);
            cbCMS.Margin = new Padding(4);
            cbCMS.Name = "cbCMS";
            cbCMS.Size = new Size(201, 25);
            cbCMS.TabIndex = 10;
            cbCMS.Text = "Countermeasure Programs";
            cbCMS.UseVisualStyleBackColor = true;
            cbCMS.CheckedChanged += cbCMS_CheckedChanged;
            // 
            // cbAAWeapons
            // 
            cbAAWeapons.Checked = true;
            cbAAWeapons.CheckState = CheckState.Checked;
            cbAAWeapons.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbAAWeapons.Location = new Point(16, 150);
            cbAAWeapons.Margin = new Padding(4);
            cbAAWeapons.Name = "cbAAWeapons";
            cbAAWeapons.Size = new Size(201, 25);
            cbAAWeapons.TabIndex = 11;
            cbAAWeapons.Text = "A/A Weapons";
            cbAAWeapons.UseVisualStyleBackColor = true;
            cbAAWeapons.CheckedChanged += cbAAWeapons_CheckedChanged;
            // 
            // UploadToJetPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(cbAAWeapons);
            Controls.Add(cbCMS);
            Controls.Add(cbPrePlanned);
            Controls.Add(cbSequences);
            Controls.Add(btnUpload);
            Controls.Add(txtWaypointStart);
            Controls.Add(label1);
            Controls.Add(chkMisc);
            Controls.Add(chkRadios);
            Controls.Add(chkWaypoints);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UploadToJetPage";
            Size = new Size(636, 554);
            ResumeLayout(false);
        }

        #endregion

        private CheckBox chkRadios;
        private CheckBox chkWaypoints;
        private Label label1;
        private DTCTextBox txtWaypointStart;
        private Base.Controls.DTCButton btnUpload;
        private ToolTip toolTip1;
        private CheckBox chkMisc;
        private CheckBox cbSequences;
        private CheckBox cbPrePlanned;
        private CheckBox cbCMS;
        private CheckBox cbAAWeapons;
    }
}
