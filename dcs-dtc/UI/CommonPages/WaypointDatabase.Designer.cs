
namespace DTC.UI.CommonPages
{
	partial class WaypointDatabase
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaypointDatabase));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.treeFolders = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAddSubfolder = new System.Windows.Forms.ToolStripButton();
			this.btnRenameFolder = new System.Windows.Forms.ToolStripButton();
			this.btnRemoveFolder = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgWaypoints = new DTC.UI.Base.Controls.DTCDataGrid();
			this.colSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colElevation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.pnlContent = new System.Windows.Forms.Panel();
			this.contextMenuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgWaypoints)).BeginInit();
			this.toolStrip2.SuspendLayout();
			this.pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeFolders
			// 
			this.treeFolders.BackColor = System.Drawing.Color.Beige;
			this.treeFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeFolders.ContextMenuStrip = this.contextMenuStrip1;
			this.treeFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeFolders.Location = new System.Drawing.Point(0, 25);
			this.treeFolders.Name = "treeFolders";
			this.treeFolders.Size = new System.Drawing.Size(244, 345);
			this.treeFolders.TabIndex = 0;
			this.treeFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFolders_AfterSelect);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(128, 70);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
			this.toolStripMenuItem1.Text = "Add Child";
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.treeFolders);
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(244, 370);
			this.panel1.TabIndex = 104;
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSubfolder,
            this.btnRenameFolder,
            this.btnRemoveFolder});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(244, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnAddSubfolder
			// 
			this.btnAddSubfolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnAddSubfolder.Enabled = false;
			this.btnAddSubfolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddSubfolder.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSubfolder.Image")));
			this.btnAddSubfolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddSubfolder.Name = "btnAddSubfolder";
			this.btnAddSubfolder.Size = new System.Drawing.Size(88, 22);
			this.btnAddSubfolder.Text = "Add Subfolder";
			this.btnAddSubfolder.Click += new System.EventHandler(this.btnAddSubfolder_Click);
			// 
			// btnRenameFolder
			// 
			this.btnRenameFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRenameFolder.Enabled = false;
			this.btnRenameFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRenameFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnRenameFolder.Image")));
			this.btnRenameFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRenameFolder.Name = "btnRenameFolder";
			this.btnRenameFolder.Size = new System.Drawing.Size(59, 22);
			this.btnRenameFolder.Text = "Rename";
			// 
			// btnRemoveFolder
			// 
			this.btnRemoveFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRemoveFolder.Enabled = false;
			this.btnRemoveFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRemoveFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveFolder.Image")));
			this.btnRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemoveFolder.Name = "btnRemoveFolder";
			this.btnRemoveFolder.Size = new System.Drawing.Size(57, 22);
			this.btnRemoveFolder.Text = "Remove";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgWaypoints);
			this.panel2.Controls.Add(this.toolStrip2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(244, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(526, 370);
			this.panel2.TabIndex = 105;
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
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkKhaki;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgWaypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgWaypoints.ColumnHeadersHeight = 40;
			this.dgWaypoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgWaypoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSequence,
            this.colName,
            this.colLatitude,
            this.colLongitude,
            this.colElevation});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgWaypoints.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgWaypoints.EnableHeadersVisualStyles = false;
			this.dgWaypoints.Location = new System.Drawing.Point(0, 25);
			this.dgWaypoints.Name = "dgWaypoints";
			this.dgWaypoints.ReadOnly = true;
			this.dgWaypoints.RowHeadersVisible = false;
			this.dgWaypoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgWaypoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgWaypoints.ShowCellToolTips = false;
			this.dgWaypoints.Size = new System.Drawing.Size(526, 345);
			this.dgWaypoints.TabIndex = 101;
			// 
			// colSequence
			// 
			this.colSequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colSequence.DataPropertyName = "Sequence";
			this.colSequence.HeaderText = "Seq";
			this.colSequence.Name = "colSequence";
			this.colSequence.ReadOnly = true;
			this.colSequence.Width = 63;
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
			this.colLatitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colLatitude.DataPropertyName = "Latitude";
			this.colLatitude.HeaderText = "Latitude";
			this.colLatitude.MinimumWidth = 120;
			this.colLatitude.Name = "colLatitude";
			this.colLatitude.ReadOnly = true;
			this.colLatitude.Width = 120;
			// 
			// colLongitude
			// 
			this.colLongitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colLongitude.DataPropertyName = "Longitude";
			this.colLongitude.HeaderText = "Longitude";
			this.colLongitude.MinimumWidth = 120;
			this.colLongitude.Name = "colLongitude";
			this.colLongitude.ReadOnly = true;
			this.colLongitude.Width = 120;
			// 
			// colElevation
			// 
			this.colElevation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.colElevation.DataPropertyName = "Elevation";
			this.colElevation.HeaderText = "Elevation";
			this.colElevation.Name = "colElevation";
			this.colElevation.ReadOnly = true;
			this.colElevation.Width = 99;
			// 
			// toolStrip2
			// 
			this.toolStrip2.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton6,
            this.toolStripButton3});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(526, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(32, 22);
			this.toolStripButton2.Text = "Add";
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(32, 22);
			this.toolStripButton6.Text = "Edit";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(57, 22);
			this.toolStripButton3.Text = "Remove";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.panel2);
			this.pnlContent.Controls.Add(this.panel1);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(0, 0);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(770, 370);
			this.pnlContent.TabIndex = 106;
			// 
			// WaypointDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.Controls.Add(this.pnlContent);
			this.Name = "WaypointDatabase";
			this.Size = new System.Drawing.Size(770, 370);
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgWaypoints)).EndInit();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.pnlContent.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeFolders;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAddSubfolder;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ImageList imageList1;
		private Base.Controls.DTCDataGrid dgWaypoints;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSequence;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLatitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLongitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn colElevation;
		private System.Windows.Forms.ToolStripButton btnRemoveFolder;
		private System.Windows.Forms.ToolStripButton btnRenameFolder;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.Panel pnlContent;
	}
}
