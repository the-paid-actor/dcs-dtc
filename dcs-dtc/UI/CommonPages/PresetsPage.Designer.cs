
namespace DTC.UI.CommonPages
{
	partial class PresetsPage
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetsPage));
			this.pnlPresets = new System.Windows.Forms.Panel();
			this.dgPresets = new DTC.UI.Base.Controls.DTCDataGrid();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolbar = new System.Windows.Forms.ToolStrip();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnEdit = new System.Windows.Forms.ToolStripButton();
			this.btnRename = new System.Windows.Forms.ToolStripButton();
			this.btnClone = new System.Windows.Forms.ToolStripButton();
			this.btnUpload = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.pnlPresets.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPresets)).BeginInit();
			this.toolbar.SuspendLayout();
			this.pnlContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlPresets
			// 
			this.pnlPresets.AutoScroll = true;
			this.pnlPresets.Controls.Add(this.dgPresets);
			this.pnlPresets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPresets.Location = new System.Drawing.Point(0, 25);
			this.pnlPresets.Name = "pnlPresets";
			this.pnlPresets.Size = new System.Drawing.Size(650, 508);
			this.pnlPresets.TabIndex = 1;
			// 
			// dgPresets
			// 
			this.dgPresets.AllowDrop = true;
			this.dgPresets.AllowUserToAddRows = false;
			this.dgPresets.AllowUserToDeleteRows = false;
			this.dgPresets.AllowUserToResizeColumns = false;
			this.dgPresets.AllowUserToResizeRows = false;
			this.dgPresets.BackgroundColor = System.Drawing.Color.Beige;
			this.dgPresets.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgPresets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dgPresets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkKhaki;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkKhaki;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgPresets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgPresets.ColumnHeadersHeight = 40;
			this.dgPresets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgPresets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName});
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgPresets.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgPresets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgPresets.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgPresets.EnableHeadersVisualStyles = false;
			this.dgPresets.Location = new System.Drawing.Point(0, 0);
			this.dgPresets.Name = "dgPresets";
			this.dgPresets.ReadOnly = true;
			this.dgPresets.RowHeadersVisible = false;
			this.dgPresets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgPresets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgPresets.ShowCellToolTips = false;
			this.dgPresets.Size = new System.Drawing.Size(650, 508);
			this.dgPresets.TabIndex = 102;
			this.dgPresets.SelectionChanged += new System.EventHandler(this.dgPresets_SelectionChanged);
			this.dgPresets.DoubleClick += new System.EventHandler(this.dgPresets_DoubleClick);
			// 
			// colName
			// 
			this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colName.DataPropertyName = "Name";
			this.colName.HeaderText = "Name";
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			// 
			// toolbar
			// 
			this.toolbar.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnRename,
            this.btnClone,
            this.btnUpload,
            this.btnDelete});
			this.toolbar.Location = new System.Drawing.Point(0, 0);
			this.toolbar.Name = "toolbar";
			this.toolbar.Size = new System.Drawing.Size(650, 25);
			this.toolbar.TabIndex = 103;
			this.toolbar.Text = "toolStrip2";
			// 
			// btnAdd
			// 
			this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(32, 22);
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
			this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(32, 22);
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnRename
			// 
			this.btnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRename.Image = ((System.Drawing.Image)(resources.GetObject("btnRename.Image")));
			this.btnRename.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRename.Name = "btnRename";
			this.btnRename.Size = new System.Drawing.Size(59, 22);
			this.btnRename.Text = "Rename";
			this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
			// 
			// btnClone
			// 
			this.btnClone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnClone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
			this.btnClone.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClone.Name = "btnClone";
			this.btnClone.Size = new System.Drawing.Size(43, 22);
			this.btnClone.Text = "Clone";
			this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
			// 
			// btnUpload
			// 
			this.btnUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
			this.btnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(83, 22);
			this.btnUpload.Text = "Upload to Jet";
			this.btnUpload.Visible = false;
			// 
			// btnDelete
			// 
			this.btnDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(47, 22);
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.pnlPresets);
			this.pnlContent.Controls.Add(this.toolbar);
			this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContent.Location = new System.Drawing.Point(0, 0);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(650, 533);
			this.pnlContent.TabIndex = 104;
			// 
			// PresetsPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.Controls.Add(this.pnlContent);
			this.Name = "PresetsPage";
			this.Size = new System.Drawing.Size(650, 533);
			this.pnlPresets.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgPresets)).EndInit();
			this.toolbar.ResumeLayout(false);
			this.toolbar.PerformLayout();
			this.pnlContent.ResumeLayout(false);
			this.pnlContent.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel pnlPresets;
		private Base.Controls.DTCDataGrid dgPresets;
		private System.Windows.Forms.DataGridViewTextBoxColumn colName;
		private System.Windows.Forms.ToolStrip toolbar;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnEdit;
		private System.Windows.Forms.ToolStripButton btnRename;
		private System.Windows.Forms.ToolStripButton btnClone;
		private System.Windows.Forms.ToolStripButton btnUpload;
		private System.Windows.Forms.ToolStripButton btnDelete;
		private System.Windows.Forms.Panel pnlContent;
	}
}
