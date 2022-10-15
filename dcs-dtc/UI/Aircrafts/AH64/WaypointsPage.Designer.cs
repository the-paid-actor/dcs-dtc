using DTC.UI.Base;

namespace DTC.UI.Aircrafts.AH64
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new DTC.UI.Base.Controls.DTCButton();
            this.btnAdd = new DTC.UI.Base.Controls.DTCButton();
            this.dgWaypoints = new DTC.UI.Base.Controls.DTCDataGrid();
            this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMGRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colElevation = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(1034, 54);
            this.panel1.TabIndex = 100;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDelete.Location = new System.Drawing.Point(196, 8);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 38);
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
            this.btnAdd.Location = new System.Drawing.Point(8, 8);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 38);
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWaypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWaypoints.ColumnHeadersHeight = 30;
            this.dgWaypoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgWaypoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequence,
            this.colType,
            this.colIdent,
            this.colFree,
            this.colMGRS,
            this.colElevation});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWaypoints.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaypoints.EnableHeadersVisualStyles = false;
            this.dgWaypoints.Location = new System.Drawing.Point(0, 54);
            this.dgWaypoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgWaypoints.Name = "dgWaypoints";
            this.dgWaypoints.ReadOnly = true;
            this.dgWaypoints.RowHeadersVisible = false;
            this.dgWaypoints.RowHeadersWidth = 62;
            this.dgWaypoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgWaypoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgWaypoints.ShowCellToolTips = false;
            this.dgWaypoints.Size = new System.Drawing.Size(1034, 689);
            this.dgWaypoints.TabIndex = 101;
            this.dgWaypoints.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgWaypoints_DataError);
            this.dgWaypoints.SelectionChanged += new System.EventHandler(this.dgWaypoints_SelectionChanged);
            this.dgWaypoints.DoubleClick += new System.EventHandler(this.dgWaypoints_DoubleClick);
            // 
            // colSequence
            // 
            this.colSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSequence.DataPropertyName = "Sequence";
            this.colSequence.HeaderText = "Seq";
            this.colSequence.MinimumWidth = 8;
            this.colSequence.Name = "colSequence";
            this.colSequence.ReadOnly = true;
            this.colSequence.Width = 84;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.MinimumWidth = 8;
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colIdent
            // 
            this.colIdent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIdent.DataPropertyName = "Ident";
            this.colIdent.HeaderText = "Ident";
            this.colIdent.MinimumWidth = 120;
            this.colIdent.Name = "colIdent";
            this.colIdent.ReadOnly = true;
            this.colIdent.Width = 120;
            // 
            // colFree
            // 
            this.colFree.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFree.DataPropertyName = "Free";
            this.colFree.HeaderText = "Free";
            this.colFree.MinimumWidth = 120;
            this.colFree.Name = "colFree";
            this.colFree.ReadOnly = true;
            this.colFree.Width = 120;
            // 
            // colMGRS
            // 
            this.colMGRS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMGRS.DataPropertyName = "MGRS";
            this.colMGRS.HeaderText = "MGRS";
            this.colMGRS.MinimumWidth = 8;
            this.colMGRS.Name = "colMGRS";
            this.colMGRS.ReadOnly = true;
            this.colMGRS.Width = 107;
            // 
            // colElevation
            // 
            this.colElevation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colElevation.DataPropertyName = "Elevation";
            this.colElevation.HeaderText = "Elevation";
            this.colElevation.MinimumWidth = 8;
            this.colElevation.Name = "colElevation";
            this.colElevation.ReadOnly = true;
            this.colElevation.Width = 128;
            // 
            // WaypointsPage
            // 
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.dgWaypoints);
            this.Controls.Add(this.panel1);
            this.Name = "WaypointsPage";
            this.Size = new System.Drawing.Size(1034, 743);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFree;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMGRS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colElevation;
    }
}
