namespace DTC.UI.Aircrafts.FA18.CompositeControls
{
    partial class SteerPointEditControl
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
            this.dtcDropDown1 = new DTC.UI.Base.Controls.DTCDropDown();
            this.cbEnable = new DTC.UI.Base.Controls.DTCCheckBox();
            this.txtCoord = new DTC.UI.Base.Controls.DTCCoordinateTextBox();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.txtAlt = new DTC.UI.Base.Controls.DTCTextBox();
            this.btnCapture = new DTC.UI.Base.Controls.DTCButton();
            this.SuspendLayout();
            // 
            // dtcDropDown1
            // 
            this.dtcDropDown1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtcDropDown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dtcDropDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtcDropDown1.FormattingEnabled = true;
            this.dtcDropDown1.Items.AddRange(new object[] {
            "Lat/Lon/Elev",
            "Waypoint"});
            this.dtcDropDown1.Location = new System.Drawing.Point(24, 3);
            this.dtcDropDown1.Name = "dtcDropDown1";
            this.dtcDropDown1.Size = new System.Drawing.Size(121, 24);
            this.dtcDropDown1.TabIndex = 2;
            this.dtcDropDown1.SelectedIndexChanged += new System.EventHandler(this.dtcDropDown1_SelectedIndexChanged);
            // 
            // cbEnable
            // 
            this.cbEnable.AutoSize = true;
            this.cbEnable.Location = new System.Drawing.Point(3, 8);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(15, 14);
            this.cbEnable.TabIndex = 1;
            this.cbEnable.UseVisualStyleBackColor = true;
            // 
            // txtCoord
            // 
            this.txtCoord.AllowPromptAsInput = true;
            this.txtCoord.BackColor = System.Drawing.SystemColors.Window;
            this.txtCoord.HidePromptOnLeave = false;
            this.txtCoord.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtCoord.Location = new System.Drawing.Point(151, 3);
            this.txtCoord.Format = DTC.Utilities.CoordinateFormat.DegreesMinutesSecondsHundredths;
            this.txtCoord.Name = "txtCoord";
            this.txtCoord.PromptChar = '_';
            this.txtCoord.Size = new System.Drawing.Size(224, 28);
            this.txtCoord.TabIndex = 3;
            this.txtCoord.ValidatingType = null;
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(151, 6);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.ReadOnly = true;
            this.domainUpDown1.Size = new System.Drawing.Size(224, 20);
            this.domainUpDown1.TabIndex = 3;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // txtAlt
            // 
            this.txtAlt.AllowPromptAsInput = true;
            this.txtAlt.BackColor = System.Drawing.SystemColors.Window;
            this.txtAlt.HidePromptOnLeave = false;
            this.txtAlt.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.txtAlt.Location = new System.Drawing.Point(381, 3);
            this.txtAlt.Mask = ">00000";
            this.txtAlt.Name = "txtAlt";
            this.txtAlt.PromptChar = '_';
            this.txtAlt.Size = new System.Drawing.Size(66, 28);
            this.txtAlt.TabIndex = 4;
            this.txtAlt.ValidatingType = null;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnCapture.FlatAppearance.BorderSize = 0;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCapture.Location = new System.Drawing.Point(453, 6);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(89, 25);
            this.btnCapture.TabIndex = 5;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // SteerPointEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.txtAlt);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.txtCoord);
            this.Controls.Add(this.cbEnable);
            this.Controls.Add(this.dtcDropDown1);
            this.Name = "SteerPointEditControl";
            this.Size = new System.Drawing.Size(551, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Base.Controls.DTCDropDown dtcDropDown1;
        private Base.Controls.DTCCheckBox cbEnable;
        private Base.Controls.DTCCoordinateTextBox txtCoord;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private Base.Controls.DTCTextBox txtAlt;
        private Base.Controls.DTCButton btnCapture;
    }
}
