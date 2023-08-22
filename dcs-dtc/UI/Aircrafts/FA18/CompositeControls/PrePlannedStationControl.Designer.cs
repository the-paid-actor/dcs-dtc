namespace DTC.UI.Aircrafts.FA18.CompositeControls
{
    partial class PrePlannedStationControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.ddType = new DTC.UI.Base.Controls.DTCDropDown();
            this.staPP1 = new DTC.UI.Base.Controls.DTCButton();
            this.staPP2 = new DTC.UI.Base.Controls.DTCButton();
            this.staPP3 = new DTC.UI.Base.Controls.DTCButton();
            this.staPP4 = new DTC.UI.Base.Controls.DTCButton();
            this.staPP5 = new DTC.UI.Base.Controls.DTCButton();
            this.cbPP1 = new System.Windows.Forms.CheckBox();
            this.cbPP2 = new System.Windows.Forms.CheckBox();
            this.cbPP3 = new System.Windows.Forms.CheckBox();
            this.cbPP4 = new System.Windows.Forms.CheckBox();
            this.cbPP5 = new System.Windows.Forms.CheckBox();
            this.dtcStackPanel1 = new DTC.UI.Base.Controls.DTCStackPanel();
            this.btnSTP = new DTC.UI.Base.Controls.DTCButton();
            this.dtcStackPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Station n";
            // 
            // ddType
            // 
            this.ddType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ddType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ddType.FormattingEnabled = true;
            this.ddType.Items.AddRange(new object[] {
            "GBU38",
            "GBU32",
            "GBU31-1/2",
            "GBU31-3/4",
            "JSOWA",
            "JSOWC",
            "SLAM",
            "SLAMER",
            "Anti-Air/Nothing",
            "Other-AG"});
            this.ddType.Location = new System.Drawing.Point(9, 34);
            this.ddType.Name = "ddType";
            this.ddType.Size = new System.Drawing.Size(127, 24);
            this.ddType.TabIndex = 1;
            this.ddType.SelectedIndexChanged += new System.EventHandler(this.ddType_SelectedIndexChanged);
            // 
            // staPP1
            // 
            this.staPP1.BackColor = System.Drawing.Color.DarkKhaki;
            this.staPP1.FlatAppearance.BorderSize = 0;
            this.staPP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staPP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.staPP1.Location = new System.Drawing.Point(142, 34);
            this.staPP1.Name = "staPP1";
            this.staPP1.Size = new System.Drawing.Size(44, 24);
            this.staPP1.TabIndex = 2;
            this.staPP1.Text = "PP1";
            this.staPP1.UseVisualStyleBackColor = false;
            this.staPP1.Click += new System.EventHandler(this.staPPn_Click);
            // 
            // staPP2
            // 
            this.staPP2.BackColor = System.Drawing.Color.DarkKhaki;
            this.staPP2.FlatAppearance.BorderSize = 0;
            this.staPP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staPP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.staPP2.Location = new System.Drawing.Point(192, 33);
            this.staPP2.Name = "staPP2";
            this.staPP2.Size = new System.Drawing.Size(44, 24);
            this.staPP2.TabIndex = 3;
            this.staPP2.Text = "PP2";
            this.staPP2.UseVisualStyleBackColor = false;
            this.staPP2.Click += new System.EventHandler(this.staPPn_Click);
            // 
            // staPP3
            // 
            this.staPP3.BackColor = System.Drawing.Color.DarkKhaki;
            this.staPP3.FlatAppearance.BorderSize = 0;
            this.staPP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staPP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.staPP3.Location = new System.Drawing.Point(242, 33);
            this.staPP3.Name = "staPP3";
            this.staPP3.Size = new System.Drawing.Size(44, 24);
            this.staPP3.TabIndex = 4;
            this.staPP3.Text = "PP3";
            this.staPP3.UseVisualStyleBackColor = false;
            this.staPP3.Click += new System.EventHandler(this.staPPn_Click);
            // 
            // staPP4
            // 
            this.staPP4.BackColor = System.Drawing.Color.DarkKhaki;
            this.staPP4.FlatAppearance.BorderSize = 0;
            this.staPP4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staPP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.staPP4.Location = new System.Drawing.Point(292, 33);
            this.staPP4.Name = "staPP4";
            this.staPP4.Size = new System.Drawing.Size(44, 24);
            this.staPP4.TabIndex = 5;
            this.staPP4.Text = "PP4";
            this.staPP4.UseVisualStyleBackColor = false;
            this.staPP4.Click += new System.EventHandler(this.staPPn_Click);
            // 
            // staPP5
            // 
            this.staPP5.BackColor = System.Drawing.Color.DarkKhaki;
            this.staPP5.FlatAppearance.BorderSize = 0;
            this.staPP5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.staPP5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.staPP5.Location = new System.Drawing.Point(342, 33);
            this.staPP5.Name = "staPP5";
            this.staPP5.Size = new System.Drawing.Size(44, 24);
            this.staPP5.TabIndex = 6;
            this.staPP5.Text = "PP5";
            this.staPP5.UseVisualStyleBackColor = false;
            this.staPP5.Click += new System.EventHandler(this.staPPn_Click);
            // 
            // cbPP1
            // 
            this.cbPP1.AutoSize = true;
            this.cbPP1.Location = new System.Drawing.Point(157, 10);
            this.cbPP1.Name = "cbPP1";
            this.cbPP1.Size = new System.Drawing.Size(15, 14);
            this.cbPP1.TabIndex = 7;
            this.cbPP1.UseVisualStyleBackColor = true;
            this.cbPP1.CheckedChanged += new System.EventHandler(this.cbn_CheckedChanged);
            // 
            // cbPP2
            // 
            this.cbPP2.AutoSize = true;
            this.cbPP2.Location = new System.Drawing.Point(206, 10);
            this.cbPP2.Name = "cbPP2";
            this.cbPP2.Size = new System.Drawing.Size(15, 14);
            this.cbPP2.TabIndex = 8;
            this.cbPP2.UseVisualStyleBackColor = true;
            this.cbPP2.CheckedChanged += new System.EventHandler(this.cbn_CheckedChanged);
            // 
            // cbPP3
            // 
            this.cbPP3.AutoSize = true;
            this.cbPP3.Location = new System.Drawing.Point(255, 10);
            this.cbPP3.Name = "cbPP3";
            this.cbPP3.Size = new System.Drawing.Size(15, 14);
            this.cbPP3.TabIndex = 9;
            this.cbPP3.UseVisualStyleBackColor = true;
            this.cbPP3.CheckedChanged += new System.EventHandler(this.cbn_CheckedChanged);
            // 
            // cbPP4
            // 
            this.cbPP4.AutoSize = true;
            this.cbPP4.Location = new System.Drawing.Point(307, 10);
            this.cbPP4.Name = "cbPP4";
            this.cbPP4.Size = new System.Drawing.Size(15, 14);
            this.cbPP4.TabIndex = 10;
            this.cbPP4.UseVisualStyleBackColor = true;
            this.cbPP4.CheckedChanged += new System.EventHandler(this.cbn_CheckedChanged);
            // 
            // cbPP5
            // 
            this.cbPP5.AutoSize = true;
            this.cbPP5.Location = new System.Drawing.Point(357, 10);
            this.cbPP5.Name = "cbPP5";
            this.cbPP5.Size = new System.Drawing.Size(15, 14);
            this.cbPP5.TabIndex = 11;
            this.cbPP5.UseVisualStyleBackColor = true;
            this.cbPP5.CheckedChanged += new System.EventHandler(this.cbn_CheckedChanged);
            // 
            // dtcStackPanel1
            // 
            this.dtcStackPanel1.Controls.Add(this.btnSTP);
            this.dtcStackPanel1.Controls.Add(this.cbPP5);
            this.dtcStackPanel1.Controls.Add(this.cbPP4);
            this.dtcStackPanel1.Controls.Add(this.cbPP3);
            this.dtcStackPanel1.Controls.Add(this.cbPP2);
            this.dtcStackPanel1.Controls.Add(this.cbPP1);
            this.dtcStackPanel1.Controls.Add(this.staPP5);
            this.dtcStackPanel1.Controls.Add(this.staPP4);
            this.dtcStackPanel1.Controls.Add(this.staPP3);
            this.dtcStackPanel1.Controls.Add(this.staPP2);
            this.dtcStackPanel1.Controls.Add(this.staPP1);
            this.dtcStackPanel1.Controls.Add(this.ddType);
            this.dtcStackPanel1.Controls.Add(this.label1);
            this.dtcStackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtcStackPanel1.Location = new System.Drawing.Point(0, 0);
            this.dtcStackPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.dtcStackPanel1.Name = "dtcStackPanel1";
            this.dtcStackPanel1.Size = new System.Drawing.Size(505, 68);
            this.dtcStackPanel1.TabIndex = 2;
            // 
            // btnSTP
            // 
            this.btnSTP.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSTP.FlatAppearance.BorderSize = 0;
            this.btnSTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSTP.Location = new System.Drawing.Point(392, 10);
            this.btnSTP.Name = "btnSTP";
            this.btnSTP.Size = new System.Drawing.Size(55, 47);
            this.btnSTP.TabIndex = 12;
            this.btnSTP.Text = "STP";
            this.btnSTP.UseVisualStyleBackColor = false;
            this.btnSTP.Click += new System.EventHandler(this.btnSTP_Click);
            // 
            // PrePlannedStationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dtcStackPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PrePlannedStationControl";
            this.Size = new System.Drawing.Size(505, 68);
            this.dtcStackPanel1.ResumeLayout(false);
            this.dtcStackPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Base.Controls.DTCDropDown ddType;
        private Base.Controls.DTCButton staPP1;
        private Base.Controls.DTCButton staPP2;
        private Base.Controls.DTCButton staPP3;
        private Base.Controls.DTCButton staPP4;
        private Base.Controls.DTCButton staPP5;
        private System.Windows.Forms.CheckBox cbPP1;
        private System.Windows.Forms.CheckBox cbPP2;
        private System.Windows.Forms.CheckBox cbPP3;
        private System.Windows.Forms.CheckBox cbPP4;
        private System.Windows.Forms.CheckBox cbPP5;
        private Base.Controls.DTCStackPanel dtcStackPanel1;
        private Base.Controls.DTCButton btnSTP;
    }
}
