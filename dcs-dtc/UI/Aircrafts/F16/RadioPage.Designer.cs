
namespace DTC.UI.Aircrafts.F16
{
	partial class RadioPage
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
			this.tblRadios = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tblRadios.SuspendLayout();
			this.SuspendLayout();
			// 
			// tblRadios
			// 
			this.tblRadios.ColumnCount = 2;
			this.tblRadios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblRadios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tblRadios.Controls.Add(this.label2, 1, 0);
			this.tblRadios.Controls.Add(this.label1, 0, 0);
			this.tblRadios.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tblRadios.Location = new System.Drawing.Point(0, 0);
			this.tblRadios.Name = "tblRadios";
			this.tblRadios.RowCount = 2;
			this.tblRadios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.468822F));
			this.tblRadios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.53118F));
			this.tblRadios.Size = new System.Drawing.Size(594, 493);
			this.tblRadios.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(300, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(291, 46);
			this.label2.TabIndex = 1;
			this.label2.Text = "COMM 2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(291, 46);
			this.label1.TabIndex = 0;
			this.label1.Text = "COMM 1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RadioPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.Controls.Add(this.tblRadios);
			this.Name = "RadioPage";
			//this.Size = new System.Drawing.Size(594, 493);
			this.Size = new System.Drawing.Size(654, 493);
			this.tblRadios.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tblRadios;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
