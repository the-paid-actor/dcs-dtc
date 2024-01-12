using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Pages;

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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlPresets = new Panel();
        dgPresets = new DTCDataGrid();
        colName = new DataGridViewTextBoxColumn();
        pnlContent = new Panel();
        panel1 = new Panel();
        btnDelete = new DTCButton();
        btnClone = new DTCButton();
        btnRename = new DTCButton();
        btnEdit = new DTCButton();
        btnAdd = new DTCButton();
        pnlPresets.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgPresets).BeginInit();
        pnlContent.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // pnlPresets
        // 
        pnlPresets.AutoScroll = true;
        pnlPresets.Controls.Add(dgPresets);
        pnlPresets.Dock = DockStyle.Fill;
        pnlPresets.Location = new Point(0, 35);
        pnlPresets.Name = "pnlPresets";
        pnlPresets.Size = new Size(650, 498);
        pnlPresets.TabIndex = 1;
        // 
        // dgPresets
        // 
        dgPresets.AllowDrop = true;
        dgPresets.AllowUserToAddRows = false;
        dgPresets.AllowUserToDeleteRows = false;
        dgPresets.AllowUserToResizeColumns = false;
        dgPresets.AllowUserToResizeRows = false;
        dgPresets.BackgroundColor = Color.Beige;
        dgPresets.BorderStyle = BorderStyle.None;
        dgPresets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgPresets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.DarkKhaki;
        dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        dataGridViewCellStyle1.ForeColor = Color.Black;
        dataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki;
        dataGridViewCellStyle1.SelectionForeColor = Color.Black;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgPresets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgPresets.ColumnHeadersHeight = 30;
        dgPresets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgPresets.ColumnHeadersVisible = false;
        dgPresets.Columns.AddRange(new DataGridViewColumn[] { colName });
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = Color.Beige;
        dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.Olive;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgPresets.DefaultCellStyle = dataGridViewCellStyle2;
        dgPresets.Dock = DockStyle.Fill;
        dgPresets.EditMode = DataGridViewEditMode.EditProgrammatically;
        dgPresets.EnableHeadersVisualStyles = false;
        dgPresets.Location = new Point(0, 0);
        dgPresets.Name = "dgPresets";
        dgPresets.ReadOnly = true;
        dgPresets.RowHeadersVisible = false;
        dgPresets.ScrollBars = ScrollBars.Vertical;
        dgPresets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgPresets.ShowCellToolTips = false;
        dgPresets.Size = new Size(650, 498);
        dgPresets.StandardTab = true;
        dgPresets.TabIndex = 0;
        dgPresets.SelectionChanged += dgPresets_SelectionChanged;
        dgPresets.DoubleClick += dgPresets_DoubleClick;
        // 
        // colName
        // 
        colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colName.DataPropertyName = "Name";
        colName.HeaderText = "Name";
        colName.Name = "colName";
        colName.ReadOnly = true;
        // 
        // pnlContent
        // 
        pnlContent.Controls.Add(pnlPresets);
        pnlContent.Controls.Add(panel1);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(0, 0);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(650, 533);
        pnlContent.TabIndex = 104;
        // 
        // panel1
        // 
        panel1.Controls.Add(btnDelete);
        panel1.Controls.Add(btnClone);
        panel1.Controls.Add(btnRename);
        panel1.Controls.Add(btnEdit);
        panel1.Controls.Add(btnAdd);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(10);
        panel1.Size = new Size(650, 35);
        panel1.TabIndex = 104;
        // 
        // btnDelete
        // 
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.BackColor = Color.DarkKhaki;
        btnDelete.Enabled = false;
        btnDelete.FlatAppearance.BorderSize = 0;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnDelete.Location = new Point(567, 5);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(80, 25);
        btnDelete.TabIndex = 5;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnClone
        // 
        btnClone.BackColor = Color.DarkKhaki;
        btnClone.Enabled = false;
        btnClone.FlatAppearance.BorderSize = 0;
        btnClone.FlatStyle = FlatStyle.Flat;
        btnClone.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnClone.Location = new Point(260, 5);
        btnClone.Name = "btnClone";
        btnClone.Size = new Size(80, 25);
        btnClone.TabIndex = 4;
        btnClone.Text = "Clone";
        btnClone.UseVisualStyleBackColor = false;
        btnClone.Click += btnClone_Click;
        // 
        // btnRename
        // 
        btnRename.BackColor = Color.DarkKhaki;
        btnRename.Enabled = false;
        btnRename.FlatAppearance.BorderSize = 0;
        btnRename.FlatStyle = FlatStyle.Flat;
        btnRename.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnRename.Location = new Point(175, 5);
        btnRename.Name = "btnRename";
        btnRename.Size = new Size(80, 25);
        btnRename.TabIndex = 3;
        btnRename.Text = "Rename";
        btnRename.UseVisualStyleBackColor = false;
        btnRename.Click += btnRename_Click;
        // 
        // btnEdit
        // 
        btnEdit.BackColor = Color.DarkKhaki;
        btnEdit.Enabled = false;
        btnEdit.FlatAppearance.BorderSize = 0;
        btnEdit.FlatStyle = FlatStyle.Flat;
        btnEdit.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnEdit.Location = new Point(90, 5);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(80, 25);
        btnEdit.TabIndex = 2;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = false;
        btnEdit.Click += btnEdit_Click;
        // 
        // btnAdd
        // 
        btnAdd.BackColor = Color.DarkKhaki;
        btnAdd.FlatAppearance.BorderSize = 0;
        btnAdd.FlatStyle = FlatStyle.Flat;
        btnAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        btnAdd.Location = new Point(5, 5);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(80, 25);
        btnAdd.TabIndex = 1;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = false;
        btnAdd.Click += btnAdd_Click;
        // 
        // PresetsPage
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.PaleGoldenrod;
        Controls.Add(pnlContent);
        Name = "PresetsPage";
        Size = new Size(650, 533);
        pnlPresets.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgPresets).EndInit();
        pnlContent.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Panel pnlPresets;
    private DTCDataGrid dgPresets;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.Panel pnlContent;
    private Panel panel1;
    private DTCButton btnDelete;
    private DTCButton btnClone;
    private DTCButton btnRename;
    private DTCButton btnEdit;
    private DTCButton btnAdd;
}
