
using DTC.UI.Base;

namespace DTC.UI.Aircrafts.F15E
{
	partial class WaypointsPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new DTC.UI.Base.Controls.DTCButton();
            this.btnAdd = new DTC.UI.Base.Controls.DTCButton();
            this.dgWaypoints = new DTC.UI.Base.Controls.DTCDataGrid();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colElevation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaypoints)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(689, 35);
            this.panel1.TabIndex = 99;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDelete.Location = new System.Drawing.Point(131, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAdd.Location = new System.Drawing.Point(5, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 25);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgWaypoints
            // 
            this.dgWaypoints.AllowDrop = true;
            this.dgWaypoints.AllowUserToAddRows = false;
            this.dgWaypoints.AllowUserToDeleteRows = false;
            this.dgWaypoints.AllowUserToResizeColumns = false;
            this.dgWaypoints.AllowUserToResizeRows = false;
            this.dgWaypoints.BackgroundColor = System.Drawing.Color.Beige;
            this.dgWaypoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgWaypoints.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgWaypoints.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWaypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWaypoints.ColumnHeadersHeight = 30;
            this.dgWaypoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgWaypoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequence,
            this.colName,
            this.colLatitude,
            this.colLongitude,
            this.colElevation,
            this.colExtra});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWaypoints.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaypoints.EnableHeadersVisualStyles = false;
            this.dgWaypoints.Location = new System.Drawing.Point(0, 35);
            this.dgWaypoints.Name = "dgWaypoints";
            this.dgWaypoints.ReadOnly = true;
            this.dgWaypoints.RowHeadersVisible = false;
            this.dgWaypoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgWaypoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWaypoints.ShowCellToolTips = false;
            this.dgWaypoints.Size = new System.Drawing.Size(689, 448);
            this.dgWaypoints.TabIndex = 100;
            this.dgWaypoints.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgWaypoints_DataError);
            this.dgWaypoints.SelectionChanged += new System.EventHandler(this.dgWaypoints_SelectionChanged);
            this.dgWaypoints.DoubleClick += new System.EventHandler(this.dgWaypoints_DoubleClick);
            // 
            // colSequence
            // 
            this.colSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSequence.DataPropertyName = "Sequence";
            this.colSequence.HeaderText = "Seq";
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            this.colSequence.Width = 58;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colLatitude
            // 
            this.colLatitude.DataPropertyName = "Latitude";
            this.colLatitude.HeaderText = "Latitude";
            this.colLatitude.Name = "colLatitude";
            this.colLatitude.ReadOnly = true;
            // 
            // colLongitude
            // 
            this.colLongitude.DataPropertyName = "Longitude";
            this.colLongitude.HeaderText = "Longitude";
            this.colLongitude.Name = "colLongitude";
            this.colLongitude.ReadOnly = true;
            // 
            // colElevation
            // 
            this.colElevation.DataPropertyName = "Elevation";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colElevation.DefaultCellStyle = dataGridViewCellStyle2;
            this.colElevation.HeaderText = "Elevation";
            this.colElevation.Name = "colElevation";
            this.colElevation.ReadOnly = true;
            this.colElevation.Width = 75;
            // 
            // colExtra
            // 
            this.colExtra.DataPropertyName = "ExtraDescription";
            this.colExtra.HeaderText = "";
            this.colExtra.Name = "colExtra";
            this.colExtra.ReadOnly = true;
            // 
            // WaypointsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.dgWaypoints);
            this.Controls.Add(this.panel1);
            this.Name = "WaypointsPage";
            this.Size = new System.Drawing.Size(689, 483);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWaypoints)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private Base.Controls.DTCButton btnDelete;
		private Base.Controls.DTCButton btnAdd;
		private Base.Controls.DTCDataGrid dgWaypoints;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElevation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtra;
    }
}
