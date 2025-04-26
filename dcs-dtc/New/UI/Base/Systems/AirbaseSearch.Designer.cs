namespace DTC.New.UI.Base.Systems
{
    partial class AirbaseSearch
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
            label5 = new Label();
            cboTheater = new DTC.UI.Base.Controls.DTCDropDown();
            label1 = new Label();
            txtSearch = new DTC.UI.Base.Controls.DTCTextBox();
            grid = new DTC.UI.Base.Controls.DTCGrid();
            btnClose = new DTC.UI.Base.Controls.DTCButton();
            btnClear = new DTC.UI.Base.Controls.DTCButton();
            SuspendLayout();
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(8, 11);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 0, 0, 0);
            label5.Size = new Size(125, 23);
            label5.TabIndex = 15;
            label5.Text = "Theater:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboTheater
            // 
            cboTheater.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTheater.FlatStyle = FlatStyle.Flat;
            cboTheater.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboTheater.FormattingEnabled = true;
            cboTheater.Location = new Point(88, 11);
            cboTheater.Margin = new Padding(4, 3, 4, 3);
            cboTheater.Name = "cboTheater";
            cboTheater.Size = new Size(290, 24);
            cboTheater.TabIndex = 16;
            cboTheater.SelectedIndexChanged += cboTheater_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 44);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 0, 0, 0);
            label1.Size = new Size(125, 23);
            label1.TabIndex = 17;
            label1.Text = "Search:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.AllowPromptAsInput = true;
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = SystemColors.Window;
            txtSearch.HidePromptOnLeave = false;
            txtSearch.InsertKeyMode = InsertKeyMode.Default;
            txtSearch.Location = new Point(88, 44);
            txtSearch.Margin = new Padding(4, 3, 4, 3);
            txtSearch.Mask = "";
            txtSearch.Name = "txtSearch";
            txtSearch.PromptChar = '_';
            txtSearch.Size = new Size(436, 24);
            txtSearch.TabIndex = 18;
            txtSearch.ValidatingType = null;
            // 
            // grid
            // 
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.ColumnHeadersVisible = true;
            grid.EnableReorder = false;
            grid.Location = new Point(16, 80);
            grid.Margin = new Padding(3, 2, 3, 2);
            grid.Multiselect = true;
            grid.Name = "grid";
            grid.Size = new Size(597, 293);
            grid.TabIndex = 19;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.DarkKhaki;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(533, 11);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 25);
            btnClose.TabIndex = 20;
            btnClose.Text = "&Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.DarkKhaki;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnClear.Location = new Point(532, 44);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 25);
            btnClear.TabIndex = 21;
            btnClear.Text = "&Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // AirbaseSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(btnClear);
            Controls.Add(btnClose);
            Controls.Add(grid);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(cboTheater);
            Controls.Add(label5);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AirbaseSearch";
            Size = new Size(628, 386);
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        protected DTC.UI.Base.Controls.DTCDropDown cboTheater;
        private Label label1;
        protected DTC.UI.Base.Controls.DTCTextBox txtSearch;
        private DTC.UI.Base.Controls.DTCGrid grid;
        private DTC.UI.Base.Controls.DTCButton btnClose;
        private DTC.UI.Base.Controls.DTCButton btnClear;
    }
}
