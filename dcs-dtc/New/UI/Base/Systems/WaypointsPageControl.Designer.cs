using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    partial class WaypointsPageControl
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnImport = new DTCDropDownButton();
            btnDelete = new DTCButton();
            btnAdd = new DTCButton();
            dgWaypoints = new DTCDataGrid();
            colSequence = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colLatitude = new DataGridViewTextBoxColumn();
            colLongitude = new DataGridViewTextBoxColumn();
            colElevation = new DataGridViewTextBoxColumn();
            colExtra = new DataGridViewTextBoxColumn();
            contextMenu = new ContextMenuStrip(components);
            shiftUpMenu = new ToolStripMenuItem();
            shiftDownMenu = new ToolStripMenuItem();
            pnlContents = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgWaypoints).BeginInit();
            contextMenu.SuspendLayout();
            pnlContents.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnImport);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(689, 35);
            panel1.TabIndex = 99;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImport.BackColor = Color.DarkKhaki;
            btnImport.FlatAppearance.BorderSize = 0;
            btnImport.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnImport.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnImport.FlatStyle = FlatStyle.Flat;
            btnImport.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnImport.Location = new Point(606, 5);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(80, 25);
            btnImport.TabIndex = 4;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkKhaki;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(90, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 25);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += DeleteButtonClick;
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
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += AddButtonClick;
            // 
            // dgWaypoints
            // 
            dgWaypoints.AllowDrop = true;
            dgWaypoints.AllowUserToAddRows = false;
            dgWaypoints.AllowUserToDeleteRows = false;
            dgWaypoints.AllowUserToResizeColumns = false;
            dgWaypoints.AllowUserToResizeRows = false;
            dgWaypoints.BackgroundColor = Color.Beige;
            dgWaypoints.BorderStyle = BorderStyle.None;
            dgWaypoints.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgWaypoints.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkKhaki;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgWaypoints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgWaypoints.ColumnHeadersHeight = 30;
            dgWaypoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgWaypoints.Columns.AddRange(new DataGridViewColumn[] { colSequence, colName, colLatitude, colLongitude, colElevation, colExtra });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Beige;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.Olive;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgWaypoints.DefaultCellStyle = dataGridViewCellStyle3;
            dgWaypoints.Dock = DockStyle.Fill;
            dgWaypoints.EnableHeadersVisualStyles = false;
            dgWaypoints.Location = new Point(0, 35);
            dgWaypoints.Name = "dgWaypoints";
            dgWaypoints.ReadOnly = true;
            dgWaypoints.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgWaypoints.RowHeadersVisible = false;
            dgWaypoints.ScrollBars = ScrollBars.Vertical;
            dgWaypoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgWaypoints.ShowCellToolTips = false;
            dgWaypoints.Size = new Size(689, 448);
            dgWaypoints.StandardTab = true;
            dgWaypoints.TabIndex = 100;
            dgWaypoints.SelectionChanged += DataGridSelectionChanged;
            dgWaypoints.DoubleClick += DataGridDoubleClick;
            dgWaypoints.MouseClick += dgWaypoints_MouseClick;
            // 
            // colSequence
            // 
            colSequence.DataPropertyName = "Sequence";
            colSequence.HeaderText = "Seq";
            colSequence.Name = "colSequence";
            colSequence.ReadOnly = true;
            colSequence.Width = 50;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colLatitude
            // 
            colLatitude.DataPropertyName = "Latitude";
            colLatitude.HeaderText = "Latitude";
            colLatitude.Name = "colLatitude";
            colLatitude.ReadOnly = true;
            colLatitude.Width = 110;
            // 
            // colLongitude
            // 
            colLongitude.DataPropertyName = "Longitude";
            colLongitude.HeaderText = "Longitude";
            colLongitude.Name = "colLongitude";
            colLongitude.ReadOnly = true;
            colLongitude.Width = 110;
            // 
            // colElevation
            // 
            colElevation.DataPropertyName = "Elevation";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            colElevation.DefaultCellStyle = dataGridViewCellStyle2;
            colElevation.HeaderText = "Elev";
            colElevation.Name = "colElevation";
            colElevation.ReadOnly = true;
            colElevation.Width = 55;
            // 
            // colExtra
            // 
            colExtra.DataPropertyName = "ExtraDescription";
            colExtra.HeaderText = "";
            colExtra.Name = "colExtra";
            colExtra.ReadOnly = true;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { shiftUpMenu, shiftDownMenu });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(181, 70);
            // 
            // shiftUpMenu
            // 
            shiftUpMenu.Name = "shiftUpMenu";
            shiftUpMenu.Size = new Size(180, 22);
            shiftUpMenu.Text = "Shift up";
            // 
            // shiftDownMenu
            // 
            shiftDownMenu.Name = "shiftDownMenu";
            shiftDownMenu.Size = new Size(180, 22);
            shiftDownMenu.Text = "Shift down";
            // 
            // pnlContents
            // 
            pnlContents.Controls.Add(dgWaypoints);
            pnlContents.Controls.Add(panel1);
            pnlContents.Dock = DockStyle.Fill;
            pnlContents.Location = new Point(0, 0);
            pnlContents.Name = "pnlContents";
            pnlContents.Size = new Size(689, 483);
            pnlContents.TabIndex = 4;
            // 
            // WaypointsPageControl
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(pnlContents);
            Name = "WaypointsPageControl";
            Size = new Size(689, 483);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgWaypoints).EndInit();
            contextMenu.ResumeLayout(false);
            pnlContents.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private DTCButton btnDelete;
        private DTCButton btnAdd;
        protected DTCDataGrid dgWaypoints;
        protected Panel pnlContents;
        private DTCDropDownButton btnImport;
        private DataGridViewTextBoxColumn colSequence;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colLatitude;
        private DataGridViewTextBoxColumn colLongitude;
        private DataGridViewTextBoxColumn colElevation;
        private DataGridViewTextBoxColumn colExtra;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem shiftUpMenu;
        private ToolStripMenuItem shiftDownMenu;
    }
}
