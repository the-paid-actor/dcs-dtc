namespace DTC.UI.CommonPages
{
    partial class CombatFliteFlightSelector
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
            comboBoxFlight = new ComboBox();
            btnCancel = new Base.Controls.DTCButton();
            btnOK = new Base.Controls.DTCButton();
            Group = new Base.Controls.DTCGroupBox();
            Group.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxFlight
            // 
            comboBoxFlight.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxFlight.Location = new Point(31, 29);
            comboBoxFlight.Name = "comboBoxFlight";
            comboBoxFlight.Size = new Size(408, 24);
            comboBoxFlight.TabIndex = 7;
            comboBoxFlight.SelectedIndexChanged += comboBoxFlight_SelectedIndexChanged;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkKhaki;
            btnCancel.FlatAppearance.BorderColor = Color.Black;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(270, 66);
            btnCancel.Margin = new Padding(4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(148, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.DarkKhaki;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOK.Location = new Point(65, 66);
            btnOK.Margin = new Padding(4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(148, 35);
            btnOK.TabIndex = 9;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // Group
            // 
            Group.BackColor = Color.PaleGoldenrod;
            Group.BorderColor = Color.Black;
            Group.BorderRadius = 2;
            Group.BorderWidth = 2;
            Group.Controls.Add(btnOK);
            Group.Controls.Add(comboBoxFlight);
            Group.Controls.Add(btnCancel);
            Group.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Group.ForeColor = Color.Black;
            Group.LabelIndent = 10;
            Group.Location = new Point(3, -1);
            Group.Margin = new Padding(0);
            Group.Name = "Group";
            Group.Padding = new Padding(0, 0, 0, 0);
            Group.Size = new Size(478, 116);
            Group.TabIndex = 10;
            Group.TabStop = false;
            Group.Text = "Select Flight";
            Group.Enter += grpSave_Enter;
            // 
            // CombatFliteFlightSelector
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            ClientSize = new Size(484, 118);
            ControlBox = false;
            Controls.Add(Group);
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "CombatFliteFlightSelector";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "CombatFliteFlightSelector";
            Load += CombatFliteFlightSelector_Load;
            Group.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxFlight;
        public Base.Controls.DTCButton btnCancel;
        public Base.Controls.DTCButton btnOK;
        private Base.Controls.DTCGroupBox Group;
    }
}