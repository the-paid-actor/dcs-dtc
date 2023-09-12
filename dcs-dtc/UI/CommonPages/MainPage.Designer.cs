
namespace DTC.UI.CommonPages
{
	partial class MainPage
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
            this.btnF16 = new System.Windows.Forms.Button();
            this.btnF18 = new System.Windows.Forms.Button();
            this.btnAH64 = new System.Windows.Forms.Button();
            this.btnF15E = new System.Windows.Forms.Button();
            this.btnWptDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnF16
            // 
            this.btnF16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF16.ForeColor = System.Drawing.Color.Black;
            this.btnF16.Image = global::DTC.Properties.Resources.F16;
            this.btnF16.Location = new System.Drawing.Point(23, 14);
            this.btnF16.Name = "btnF16";
            this.btnF16.Padding = new System.Windows.Forms.Padding(5);
            this.btnF16.Size = new System.Drawing.Size(226, 150);
            this.btnF16.TabIndex = 3;
            this.btnF16.Text = "F-16CJ Viper";
            this.btnF16.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnF16.UseVisualStyleBackColor = true;
            this.btnF16.Click += new System.EventHandler(this.btnF16_Click);
            // 
            // btnF18
            // 
            this.btnF18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF18.ForeColor = System.Drawing.Color.Black;
            this.btnF18.Image = global::DTC.Properties.Resources.FA18;
            this.btnF18.Location = new System.Drawing.Point(272, 14);
            this.btnF18.Name = "btnF18";
            this.btnF18.Padding = new System.Windows.Forms.Padding(5);
            this.btnF18.Size = new System.Drawing.Size(226, 150);
            this.btnF18.TabIndex = 3;
            this.btnF18.Text = "F/A-18C Hornet";
            this.btnF18.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnF18.UseVisualStyleBackColor = true;
            this.btnF18.Click += new System.EventHandler(this.btnF18_Click);
            // 
            // btnAH64
            // 
            this.btnAH64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAH64.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAH64.ForeColor = System.Drawing.Color.Black;
            this.btnAH64.Image = global::DTC.Properties.Resources.AH64;
            this.btnAH64.Location = new System.Drawing.Point(23, 189);
            this.btnAH64.Name = "btnAH64";
            this.btnAH64.Padding = new System.Windows.Forms.Padding(5);
            this.btnAH64.Size = new System.Drawing.Size(226, 150);
            this.btnAH64.TabIndex = 5;
            this.btnAH64.Text = "AH-64D Apache Longbow";
            this.btnAH64.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAH64.UseVisualStyleBackColor = true;
            this.btnAH64.Visible = false;
            this.btnAH64.Click += new System.EventHandler(this.btnAH64_Click);
            // 
            // btnF15E
            // 
            this.btnF15E.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF15E.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnF15E.ForeColor = System.Drawing.Color.Black;
            this.btnF15E.Image = global::DTC.Properties.Resources.F15E;
            this.btnF15E.Location = new System.Drawing.Point(521, 14);
            this.btnF15E.Name = "btnF15E";
            this.btnF15E.Padding = new System.Windows.Forms.Padding(5);
            this.btnF15E.Size = new System.Drawing.Size(226, 150);
            this.btnF15E.TabIndex = 5;
            this.btnF15E.Text = "F-15E Strike Eagle";
            this.btnF15E.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnF15E.UseVisualStyleBackColor = true;
            this.btnF15E.Click += new System.EventHandler(this.btnF15E_Click);
            // 
            // btnWptDatabase
            // 
            this.btnWptDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWptDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWptDatabase.ForeColor = System.Drawing.Color.Black;
            this.btnWptDatabase.Image = global::DTC.Properties.Resources.Waypoints;
            this.btnWptDatabase.Location = new System.Drawing.Point(510, 300);
            this.btnWptDatabase.Name = "btnWptDatabase";
            this.btnWptDatabase.Padding = new System.Windows.Forms.Padding(5);
            this.btnWptDatabase.Size = new System.Drawing.Size(200, 100);
            this.btnWptDatabase.TabIndex = 4;
            this.btnWptDatabase.Text = "Waypoints Database";
            this.btnWptDatabase.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnWptDatabase.UseVisualStyleBackColor = true;
            this.btnWptDatabase.Visible = false;
            this.btnWptDatabase.Click += new System.EventHandler(this.btnWptDatabase_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.btnF16);
            this.Controls.Add(this.btnF18);
            this.Controls.Add(this.btnAH64);
            this.Controls.Add(this.btnF15E);
            this.Controls.Add(this.btnWptDatabase);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(770, 434);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnF16;
		private System.Windows.Forms.Button btnF18;
		private System.Windows.Forms.Button btnF15E;
		private System.Windows.Forms.Button btnWptDatabase;
        private System.Windows.Forms.Button btnAH64;
    }
}
