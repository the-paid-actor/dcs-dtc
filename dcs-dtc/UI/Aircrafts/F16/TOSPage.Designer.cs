
namespace DTC.UI.Aircrafts.F16
{
	partial class TOSPage
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
            this.tblTOS = new System.Windows.Forms.TableLayoutPanel();
            this.tblTOS.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Times on Station";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblTOS
            // 
            this.tblTOS.ColumnCount = 2;
            this.tblTOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.80428F));
            this.tblTOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.19572F));
            this.tblTOS.Controls.Add(this.label1, 0, 0);
            this.tblTOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTOS.Location = new System.Drawing.Point(0, 0);
            this.tblTOS.Name = "tblTOS";
            this.tblTOS.RowCount = 2;
            this.tblTOS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.468822F));
            this.tblTOS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.53118F));
            this.tblTOS.Size = new System.Drawing.Size(654, 493);
            this.tblTOS.TabIndex = 0;
            // 
            // TOSPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.tblTOS);
            this.Name = "TOSPage";
            this.Size = new System.Drawing.Size(654, 493);
            this.tblTOS.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tblTOS;
    }
}
