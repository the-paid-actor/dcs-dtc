
namespace DTC.UI.Base
{
	partial class EmitterList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblSelected = new System.Windows.Forms.Label();
			this.btnCancel = new DTC.UI.Base.Controls.DTCButton();
			this.btnOK = new DTC.UI.Base.Controls.DTCButton();
			this.datagrid = new DTC.UI.Base.Controls.DTCDataGrid();
			this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.colHTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colF16RWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lblSelected);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnOK);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 382);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(547, 35);
			this.panel1.TabIndex = 1;
			// 
			// lblSelected
			// 
			this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSelected.Location = new System.Drawing.Point(257, 0);
			this.lblSelected.Name = "lblSelected";
			this.lblSelected.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
			this.lblSelected.Size = new System.Drawing.Size(290, 35);
			this.lblSelected.TabIndex = 1;
			this.lblSelected.Text = "label1";
			this.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnCancel.FlatAppearance.BorderSize = 0;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(131, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(120, 25);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.BackColor = System.Drawing.Color.DarkKhaki;
			this.btnOK.FlatAppearance.BorderSize = 0;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOK.Location = new System.Drawing.Point(5, 5);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(120, 25);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// datagrid
			// 
			this.datagrid.AllowDrop = true;
			this.datagrid.AllowUserToAddRows = false;
			this.datagrid.AllowUserToDeleteRows = false;
			this.datagrid.AllowUserToResizeColumns = false;
			this.datagrid.AllowUserToResizeRows = false;
			this.datagrid.BackgroundColor = System.Drawing.Color.Beige;
			this.datagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.datagrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.datagrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkKhaki;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkKhaki;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.datagrid.ColumnHeadersHeight = 30;
			this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colHTS,
            this.colCountry,
            this.colF16RWR,
            this.colType,
            this.colName,
            this.colNATO});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.datagrid.DefaultCellStyle = dataGridViewCellStyle2;
			this.datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.datagrid.EnableHeadersVisualStyles = false;
			this.datagrid.Location = new System.Drawing.Point(0, 0);
			this.datagrid.MultiSelect = false;
			this.datagrid.Name = "datagrid";
			this.datagrid.RowHeadersVisible = false;
			this.datagrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.datagrid.ShowCellToolTips = false;
			this.datagrid.Size = new System.Drawing.Size(547, 382);
			this.datagrid.TabIndex = 0;
			// 
			// colSelected
			// 
			this.colSelected.DataPropertyName = "Checked";
			this.colSelected.HeaderText = "";
			this.colSelected.Name = "colSelected";
			this.colSelected.ReadOnly = true;
			this.colSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.colSelected.Width = 30;
			// 
			// colHTS
			// 
			this.colHTS.DataPropertyName = "HTSTable";
			this.colHTS.HeaderText = "HTS";
			this.colHTS.Name = "colHTS";
			this.colHTS.ReadOnly = true;
			this.colHTS.Width = 50;
			// 
			// colCountry
			// 
			this.colCountry.DataPropertyName = "Country";
			this.colCountry.HeaderText = "Country";
			this.colCountry.Name = "colCountry";
			this.colCountry.ReadOnly = true;
			this.colCountry.Width = 70;
			// 
			// colF16RWR
			// 
			this.colF16RWR.DataPropertyName = "F16RWR";
			this.colF16RWR.HeaderText = "RWR";
			this.colF16RWR.Name = "colF16RWR";
			this.colF16RWR.ReadOnly = true;
			this.colF16RWR.Width = 50;
			// 
			// colType
			// 
			this.colType.DataPropertyName = "Type";
			this.colType.HeaderText = "Type";
			this.colType.Name = "colType";
			this.colType.ReadOnly = true;
			this.colType.Width = 50;
			// 
			// colName
			// 
			this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colName.DataPropertyName = "Name";
			this.colName.HeaderText = "Name";
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			// 
			// colNATO
			// 
			this.colNATO.DataPropertyName = "NATO";
			this.colNATO.HeaderText = "NATO";
			this.colNATO.Name = "colNATO";
			this.colNATO.Width = 130;
			// 
			// EmitterList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.datagrid);
			this.Controls.Add(this.panel1);
			this.Name = "EmitterList";
			this.Size = new System.Drawing.Size(547, 417);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private Controls.DTCDataGrid datagrid;
		private System.Windows.Forms.Panel panel1;
		private Controls.DTCButton btnCancel;
		private Controls.DTCButton btnOK;
		private System.Windows.Forms.Label lblSelected;
		private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
		private System.Windows.Forms.DataGridViewTextBoxColumn colHTS;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
		private System.Windows.Forms.DataGridViewTextBoxColumn colF16RWR;
		private System.Windows.Forms.DataGridViewTextBoxColumn colType;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNATO;
	}
}
