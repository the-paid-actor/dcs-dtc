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
			this.comboBoxFlight = new System.Windows.Forms.ComboBox();
			this.dtcLabel1 = new DTC.UI.Base.Controls.DTCLabel();
			this.btnCancel = new DTC.UI.Base.Controls.DTCButton();
			this.btnOK = new DTC.UI.Base.Controls.DTCButton();
			this.SuspendLayout();
			// 
			// comboBoxFlight
			// 
			this.comboBoxFlight.Location = new System.Drawing.Point(104, 24);
			this.comboBoxFlight.Name = "comboBoxFlight";
			this.comboBoxFlight.Size = new System.Drawing.Size(459, 28);
			this.comboBoxFlight.TabIndex = 7;
			this.comboBoxFlight.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlight_SelectedIndexChanged);
			// 
			// dtcLabel1
			// 
			this.dtcLabel1.AutoSize = true;
			this.dtcLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.dtcLabel1.Location = new System.Drawing.Point(22, 23);
			this.dtcLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.dtcLabel1.Name = "dtcLabel1";
			this.dtcLabel1.Size = new System.Drawing.Size(65, 25);
			this.dtcLabel1.TabIndex = 10;
			this.dtcLabel1.Text = "Flight:";
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnCancel.Location = new System.Drawing.Point(338, 70);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(225, 62);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnOK.FlatAppearance.BorderSize = 0;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.btnOK.Location = new System.Drawing.Point(104, 70);
			this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(225, 62);
			this.btnOK.TabIndex = 9;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// CombatFliteFlightSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.ClientSize = new System.Drawing.Size(585, 155);
			this.ControlBox = false;
			this.Controls.Add(this.dtcLabel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.comboBoxFlight);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "CombatFliteFlightSelector";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "CombatFliteFlightSelector";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxFlight;
		private Base.Controls.DTCLabel dtcLabel1;
		public Base.Controls.DTCButton btnCancel;
		public Base.Controls.DTCButton btnOK;
	}
}