
namespace DTC.New.UI.Base.Pages
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
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblSelected = new Label();
            btnCancel = new DTC.UI.Base.Controls.DTCButton();
            btnOK = new DTC.UI.Base.Controls.DTCButton();
            datagrid = new DTC.UI.Base.Controls.DTCDataGrid();
            colSelected = new DataGridViewCheckBoxColumn();
            colHTS = new DataGridViewTextBoxColumn();
            colCountry = new DataGridViewTextBoxColumn();
            colF16RWR = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colHARMCode = new DataGridViewTextBoxColumn();
            colNATO = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datagrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblSelected);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 382);
            panel1.Name = "panel1";
            panel1.Size = new Size(547, 35);
            panel1.TabIndex = 1;
            // 
            // lblSelected
            // 
            lblSelected.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblSelected.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelected.Location = new Point(257, 0);
            lblSelected.Name = "lblSelected";
            lblSelected.Padding = new Padding(0, 0, 5, 0);
            lblSelected.Size = new Size(290, 35);
            lblSelected.TabIndex = 1;
            lblSelected.Text = "label1";
            lblSelected.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.DarkKhaki;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(90, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 25);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOK.BackColor = Color.DarkKhaki;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOK.Location = new Point(5, 5);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 25);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // datagrid
            // 
            datagrid.AllowDrop = true;
            datagrid.AllowUserToAddRows = false;
            datagrid.AllowUserToDeleteRows = false;
            datagrid.AllowUserToResizeColumns = false;
            datagrid.AllowUserToResizeRows = false;
            datagrid.BackgroundColor = Color.Beige;
            datagrid.BorderStyle = BorderStyle.None;
            datagrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            datagrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = Color.DarkKhaki;
            dataGridViewCellStyle15.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle15.ForeColor = Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = Color.DarkKhaki;
            dataGridViewCellStyle15.SelectionForeColor = Color.Black;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            datagrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            datagrid.ColumnHeadersHeight = 30;
            datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            datagrid.Columns.AddRange(new DataGridViewColumn[] { colSelected, colHTS, colCountry, colF16RWR, colType, colHARMCode, colNATO });
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.Beige;
            dataGridViewCellStyle21.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle21.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.False;
            datagrid.DefaultCellStyle = dataGridViewCellStyle21;
            datagrid.Dock = DockStyle.Fill;
            datagrid.EnableHeadersVisualStyles = false;
            datagrid.Location = new Point(0, 25);
            datagrid.MultiSelect = false;
            datagrid.Name = "datagrid";
            datagrid.RowHeadersVisible = false;
            datagrid.ScrollBars = ScrollBars.Vertical;
            datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid.ShowCellToolTips = false;
            datagrid.Size = new Size(547, 357);
            datagrid.TabIndex = 1;
            // 
            // colSelected
            // 
            colSelected.DataPropertyName = "Checked";
            colSelected.HeaderText = "";
            colSelected.Name = "colSelected";
            colSelected.ReadOnly = true;
            colSelected.SortMode = DataGridViewColumnSortMode.Automatic;
            colSelected.Width = 30;
            // 
            // colHTS
            // 
            colHTS.DataPropertyName = "HTSTable";
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHTS.DefaultCellStyle = dataGridViewCellStyle16;
            colHTS.HeaderText = "HTS";
            colHTS.Name = "colHTS";
            colHTS.ReadOnly = true;
            colHTS.Width = 50;
            // 
            // colCountry
            // 
            colCountry.DataPropertyName = "Country";
            colCountry.HeaderText = "Country";
            colCountry.Name = "colCountry";
            colCountry.ReadOnly = true;
            colCountry.Width = 70;
            // 
            // colF16RWR
            // 
            colF16RWR.DataPropertyName = "F16RWR";
            dataGridViewCellStyle17.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colF16RWR.DefaultCellStyle = dataGridViewCellStyle17;
            colF16RWR.HeaderText = "RWR";
            colF16RWR.Name = "colF16RWR";
            colF16RWR.ReadOnly = true;
            colF16RWR.Width = 50;
            // 
            // colType
            // 
            colType.DataPropertyName = "Type";
            dataGridViewCellStyle18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colType.DefaultCellStyle = dataGridViewCellStyle18;
            colType.HeaderText = "Type";
            colType.Name = "colType";
            colType.ReadOnly = true;
            colType.Width = 50;
            // 
            // colHARMCode
            // 
            colHARMCode.DataPropertyName = "HARMCode";
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHARMCode.DefaultCellStyle = dataGridViewCellStyle19;
            colHARMCode.HeaderText = "Code";
            colHARMCode.Name = "colHARMCode";
            colHARMCode.ReadOnly = true;
            // 
            // colNATO
            // 
            colNATO.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNATO.DataPropertyName = "NATO";
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNATO.DefaultCellStyle = dataGridViewCellStyle20;
            colNATO.HeaderText = "NATO";
            colNATO.Name = "colNATO";
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Top;
            txtSearch.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(547, 25);
            txtSearch.TabIndex = 0;
            txtSearch.Text = "Search Here...";
            // 
            // EmitterList
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(datagrid);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Name = "EmitterList";
            Size = new Size(547, 417);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datagrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DTC.UI.Base.Controls.DTCDataGrid datagrid;
        private System.Windows.Forms.Panel panel1;
        private DTC.UI.Base.Controls.DTCButton btnCancel;
        private DTC.UI.Base.Controls.DTCButton btnOK;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF16RWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHARMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNATO;
        private System.Windows.Forms.TextBox txtSearch;
    }
}
