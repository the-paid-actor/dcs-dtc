namespace DTC.New.UI.Base.Systems.WaypointImport
{
    partial class ImportDialog
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
            gridRoutes = new DTC.UI.Base.Controls.DTCGrid();
            gridWaypoints = new DTC.UI.Base.Controls.DTCGrid();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            radAppend = new RadioButton();
            radInsert = new RadioButton();
            radOverwrite = new RadioButton();
            radShift = new RadioButton();
            radReplace = new RadioButton();
            pnlInsert = new Panel();
            txtInsertAt = new DTC.UI.Base.Controls.DTCNumericTextBox();
            btnOK = new DTC.UI.Base.Controls.DTCButton();
            btnCancel = new DTC.UI.Base.Controls.DTCButton();
            lblError = new Label();
            pnlInsert.SuspendLayout();
            SuspendLayout();
            // 
            // gridRoutes
            // 
            gridRoutes.BorderStyle = BorderStyle.FixedSingle;
            gridRoutes.ColumnHeadersVisible = true;
            gridRoutes.Location = new Point(15, 50);
            gridRoutes.Multiselect = true;
            gridRoutes.Name = "gridRoutes";
            gridRoutes.Size = new Size(403, 100);
            gridRoutes.TabIndex = 0;
            // 
            // gridWaypoints
            // 
            gridWaypoints.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridWaypoints.BorderStyle = BorderStyle.FixedSingle;
            gridWaypoints.ColumnHeadersVisible = true;
            gridWaypoints.Location = new Point(15, 195);
            gridWaypoints.Multiselect = true;
            gridWaypoints.Name = "gridWaypoints";
            gridWaypoints.Size = new Size(635, 150);
            gridWaypoints.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 2;
            label1.Text = "Select the route:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(15, 160);
            label2.Name = "label2";
            label2.Size = new Size(288, 25);
            label2.TabIndex = 2;
            label2.Text = "Select the waypoints to be imported:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(15, 355);
            label3.Name = "label3";
            label3.Size = new Size(210, 25);
            label3.TabIndex = 2;
            label3.Text = "Select the import options:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radAppend
            // 
            radAppend.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radAppend.Location = new Point(15, 390);
            radAppend.Name = "radAppend";
            radAppend.Size = new Size(204, 25);
            radAppend.TabIndex = 3;
            radAppend.TabStop = true;
            radAppend.Text = "Append to the list";
            radAppend.UseVisualStyleBackColor = true;
            // 
            // radInsert
            // 
            radInsert.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radInsert.Location = new Point(15, 452);
            radInsert.Name = "radInsert";
            radInsert.Size = new Size(204, 25);
            radInsert.TabIndex = 3;
            radInsert.TabStop = true;
            radInsert.Text = "Insert at sequence:";
            radInsert.UseVisualStyleBackColor = true;
            radInsert.CheckedChanged += radInsert_CheckedChanged;
            // 
            // radOverwrite
            // 
            radOverwrite.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radOverwrite.Location = new Point(3, 3);
            radOverwrite.Name = "radOverwrite";
            radOverwrite.Size = new Size(237, 25);
            radOverwrite.TabIndex = 3;
            radOverwrite.TabStop = true;
            radOverwrite.Text = "Overwrite subsequent waypoints";
            radOverwrite.UseVisualStyleBackColor = true;
            // 
            // radShift
            // 
            radShift.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radShift.Location = new Point(3, 34);
            radShift.Name = "radShift";
            radShift.Size = new Size(204, 25);
            radShift.TabIndex = 3;
            radShift.TabStop = true;
            radShift.Text = "Shift subsequent waypoints";
            radShift.UseVisualStyleBackColor = true;
            // 
            // radReplace
            // 
            radReplace.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radReplace.Location = new Point(15, 421);
            radReplace.Name = "radReplace";
            radReplace.Size = new Size(231, 25);
            radReplace.TabIndex = 3;
            radReplace.TabStop = true;
            radReplace.Text = "Replace entire list";
            radReplace.UseVisualStyleBackColor = true;
            // 
            // pnlInsert
            // 
            pnlInsert.Controls.Add(radOverwrite);
            pnlInsert.Controls.Add(radShift);
            pnlInsert.Location = new Point(33, 483);
            pnlInsert.Name = "pnlInsert";
            pnlInsert.Size = new Size(311, 65);
            pnlInsert.TabIndex = 4;
            // 
            // txtInsertAt
            // 
            txtInsertAt.AllowFraction = false;
            txtInsertAt.BackColor = SystemColors.Window;
            txtInsertAt.Location = new Point(171, 452);
            txtInsertAt.MaximumValue = new decimal(new int[] { 999, 0, 0, 0 });
            txtInsertAt.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtInsertAt.Name = "txtInsertAt";
            txtInsertAt.Size = new Size(69, 25);
            txtInsertAt.TabIndex = 5;
            txtInsertAt.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            txtInsertAt.Value = null;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.DarkKhaki;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnOK.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnOK.Location = new Point(15, 564);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(80, 25);
            btnOK.TabIndex = 6;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkKhaki;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(101, 564);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 25);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblError
            // 
            lblError.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblError.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(187, 564);
            lblError.Name = "lblError";
            lblError.Size = new Size(463, 25);
            lblError.TabIndex = 2;
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // WaypointImportCombatFlite
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMargin = new Size(0, 15);
            BackColor = Color.PaleGoldenrod;
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtInsertAt);
            Controls.Add(pnlInsert);
            Controls.Add(radInsert);
            Controls.Add(radReplace);
            Controls.Add(radAppend);
            Controls.Add(lblError);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gridWaypoints);
            Controls.Add(gridRoutes);
            Name = "WaypointImportCombatFlite";
            Size = new Size(668, 605);
            pnlInsert.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DTC.UI.Base.Controls.DTCGrid gridRoutes;
        private DTC.UI.Base.Controls.DTCGrid gridWaypoints;
        private Label label1;
        private Label label2;
        private Label label3;
        private RadioButton radAppend;
        private RadioButton radInsert;
        private RadioButton radOverwrite;
        private RadioButton radShift;
        private RadioButton radReplace;
        private Panel pnlInsert;
        private DTC.UI.Base.Controls.DTCNumericTextBox txtInsertAt;
        private DTC.UI.Base.Controls.DTCButton btnOK;
        private DTC.UI.Base.Controls.DTCButton btnCancel;
        private Label lblError;
    }
}
