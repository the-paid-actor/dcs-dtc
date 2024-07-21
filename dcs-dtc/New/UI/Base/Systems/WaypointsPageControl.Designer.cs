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
            panel1 = new Panel();
            btnDeleteAll = new DTCButton();
            btnImport = new DTCDropDownButton();
            btnDelete = new DTCButton();
            btnAdd = new DTCButton();
            dgWaypoints = new DTCGrid();
            contextMenu = new ContextMenuStrip(components);
            shiftUpMenu = new ToolStripMenuItem();
            shiftDownMenu = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyMenu = new ToolStripMenuItem();
            pasteMenu = new ToolStripMenuItem();
            pnlContents = new Panel();
            panel1.SuspendLayout();
            contextMenu.SuspendLayout();
            pnlContents.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteAll);
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
            // btnDeleteAll
            // 
            btnDeleteAll.BackColor = Color.DarkKhaki;
            btnDeleteAll.FlatAppearance.BorderSize = 0;
            btnDeleteAll.FlatStyle = FlatStyle.Flat;
            btnDeleteAll.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteAll.Location = new Point(176, 5);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(80, 25);
            btnDeleteAll.TabIndex = 5;
            btnDeleteAll.Text = "Delete All";
            btnDeleteAll.UseVisualStyleBackColor = false;
            btnDeleteAll.Click += DeleteAllButtonClick;
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
            dgWaypoints.ColumnHeadersVisible = true;
            dgWaypoints.Dock = DockStyle.Fill;
            dgWaypoints.EnableReorder = true;
            dgWaypoints.Location = new Point(0, 35);
            dgWaypoints.Multiselect = true;
            dgWaypoints.Name = "dgWaypoints";
            dgWaypoints.Size = new Size(689, 448);
            dgWaypoints.TabIndex = 100;
            dgWaypoints.Reorder += DataGridReorder;
            dgWaypoints.ShowContextMenu += DataGridShowContextMenu;
            dgWaypoints.SelectionChanged += DataGridSelectionChanged;
            dgWaypoints.DoubleClick += DataGridDoubleClick;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { shiftUpMenu, shiftDownMenu, toolStripSeparator1, copyMenu, pasteMenu });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(186, 98);
            // 
            // shiftUpMenu
            // 
            shiftUpMenu.Name = "shiftUpMenu";
            shiftUpMenu.Size = new Size(185, 22);
            shiftUpMenu.Text = "Decrement sequence";
            // 
            // shiftDownMenu
            // 
            shiftDownMenu.Name = "shiftDownMenu";
            shiftDownMenu.Size = new Size(185, 22);
            shiftDownMenu.Text = "Increment sequence";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(182, 6);
            // 
            // copyMenu
            // 
            copyMenu.Name = "copyMenu";
            copyMenu.Size = new Size(185, 22);
            copyMenu.Text = "Copy";
            // 
            // pasteMenu
            // 
            pasteMenu.Name = "pasteMenu";
            pasteMenu.Size = new Size(185, 22);
            pasteMenu.Text = "Paste";
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
            contextMenu.ResumeLayout(false);
            pnlContents.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private DTCButton btnDelete;
        private DTCButton btnAdd;
        protected DTCGrid dgWaypoints;
        protected Panel pnlContents;
        private DTCDropDownButton btnImport;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem shiftUpMenu;
        private ToolStripMenuItem shiftDownMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem copyMenu;
        private ToolStripMenuItem pasteMenu;
        private DTCButton btnDeleteAll;
    }
}
