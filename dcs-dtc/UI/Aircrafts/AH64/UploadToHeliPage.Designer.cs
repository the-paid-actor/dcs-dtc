namespace DTC.UI.Aircrafts.AH64
{
    partial class UploadToHeliPage
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
            this.btnUpload = new DTC.UI.Base.Controls.DTCButton();
            this.txtWaypointEnd = new DTC.UI.Base.Controls.DTCTextBox();
            this.txtWaypointStart = new DTC.UI.Base.Controls.DTCTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWaypoints = new System.Windows.Forms.CheckBox();
            this.chkRadios = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnUpload.Location = new System.Drawing.Point(17, 485);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(120, 51);
            this.btnUpload.TabIndex = 8;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtWaypointEnd
            // 
            this.txtWaypointEnd.AllowPromptAsInput = false;
            this.txtWaypointEnd.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointEnd.HidePromptOnLeave = true;
            this.txtWaypointEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointEnd.Location = new System.Drawing.Point(488, 29);
            this.txtWaypointEnd.Mask = "000";
            this.txtWaypointEnd.Name = "txtWaypointEnd";
            this.txtWaypointEnd.PromptChar = ' ';
            this.txtWaypointEnd.Size = new System.Drawing.Size(57, 39);
            this.txtWaypointEnd.TabIndex = 11;
            this.txtWaypointEnd.ValidatingType = typeof(int);
            // 
            // txtWaypointStart
            // 
            this.txtWaypointStart.AllowPromptAsInput = false;
            this.txtWaypointStart.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaypointStart.HidePromptOnLeave = true;
            this.txtWaypointStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtWaypointStart.Location = new System.Drawing.Point(266, 29);
            this.txtWaypointStart.Mask = "000";
            this.txtWaypointStart.Name = "txtWaypointStart";
            this.txtWaypointStart.PromptChar = ' ';
            this.txtWaypointStart.Size = new System.Drawing.Size(57, 39);
            this.txtWaypointStart.TabIndex = 10;
            this.txtWaypointStart.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(372, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 39);
            this.label2.TabIndex = 12;
            this.label2.Text = "Through";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(214, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 34);
            this.label1.TabIndex = 13;
            this.label1.Text = "Into Steerpoints";
            // 
            // chkWaypoints
            // 
            this.chkWaypoints.Checked = true;
            this.chkWaypoints.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaypoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkWaypoints.Location = new System.Drawing.Point(17, 21);
            this.chkWaypoints.Margin = new System.Windows.Forms.Padding(4);
            this.chkWaypoints.Name = "chkWaypoints";
            this.chkWaypoints.Size = new System.Drawing.Size(139, 53);
            this.chkWaypoints.TabIndex = 9;
            this.chkWaypoints.Text = "Waypoints";
            this.chkWaypoints.UseVisualStyleBackColor = true;
            this.chkWaypoints.CheckedChanged += new System.EventHandler(this.chkWaypoints_CheckedChanged);
            // 
            // chkRadios
            // 
            this.chkRadios.Checked = true;
            this.chkRadios.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRadios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkRadios.Location = new System.Drawing.Point(17, 82);
            this.chkRadios.Margin = new System.Windows.Forms.Padding(4);
            this.chkRadios.Name = "chkRadios";
            this.chkRadios.Size = new System.Drawing.Size(78, 25);
            this.chkRadios.TabIndex = 14;
            this.chkRadios.Text = "Radios";
            this.chkRadios.UseVisualStyleBackColor = true;
            this.chkRadios.CheckedChanged += new System.EventHandler(this.chkRadios_CheckedChanged);
            // 
            // UploadToJetPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.chkRadios);
            this.Controls.Add(this.txtWaypointEnd);
            this.Controls.Add(this.txtWaypointStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkWaypoints);
            this.Controls.Add(this.btnUpload);
            this.Name = "UploadToJetPage";
            this.Size = new System.Drawing.Size(636, 554);
            this.ResumeLayout(false);

        }

        #endregion

        private Base.Controls.DTCButton btnUpload;
        private Base.Controls.DTCTextBox txtWaypointEnd;
        private Base.Controls.DTCTextBox txtWaypointStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWaypoints;
        private System.Windows.Forms.CheckBox chkRadios;
    }
}
