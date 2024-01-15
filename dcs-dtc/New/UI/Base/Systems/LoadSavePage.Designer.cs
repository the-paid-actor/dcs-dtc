using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    partial class LoadSavePage
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
            openFileDlg = new OpenFileDialog();
            saveFileDlg = new SaveFileDialog();
            optFile = new RadioButton();
            optClipboard = new RadioButton();
            btnLoadApply = new DTCButton();
            btnLoad = new DTCButton();
            pnlLoadCheckboxes = new Panel();
            btnSave = new DTCButton();
            pnlSaveCheckboxes = new Panel();
            lblSave = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel5 = new Panel();
            panel6 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDlg
            // 
            openFileDlg.FileName = "dtc.json";
            // 
            // saveFileDlg
            // 
            saveFileDlg.DefaultExt = "json";
            // 
            // optFile
            // 
            optFile.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optFile.Location = new Point(112, 15);
            optFile.Name = "optFile";
            optFile.Size = new Size(48, 25);
            optFile.TabIndex = 7;
            optFile.TabStop = true;
            optFile.Text = "File";
            optFile.UseVisualStyleBackColor = true;
            optFile.CheckedChanged += optFile_CheckedChanged;
            // 
            // optClipboard
            // 
            optClipboard.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            optClipboard.Location = new Point(15, 15);
            optClipboard.Name = "optClipboard";
            optClipboard.Size = new Size(86, 25);
            optClipboard.TabIndex = 7;
            optClipboard.TabStop = true;
            optClipboard.Text = "Clipboard";
            optClipboard.UseVisualStyleBackColor = true;
            optClipboard.CheckedChanged += optClipboard_CheckedChanged;
            // 
            // btnLoadApply
            // 
            btnLoadApply.BackColor = Color.DarkKhaki;
            btnLoadApply.Enabled = false;
            btnLoadApply.FlatAppearance.BorderSize = 0;
            btnLoadApply.FlatStyle = FlatStyle.Flat;
            btnLoadApply.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadApply.Location = new Point(25, 280);
            btnLoadApply.Name = "btnLoadApply";
            btnLoadApply.Size = new Size(160, 25);
            btnLoadApply.TabIndex = 0;
            btnLoadApply.Text = "Apply";
            btnLoadApply.UseVisualStyleBackColor = false;
            btnLoadApply.Click += btnLoadApply_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.DarkKhaki;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoad.Location = new Point(25, 25);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(160, 25);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load From Clipboard";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // pnlLoadCheckboxes
            // 
            pnlLoadCheckboxes.AutoScroll = true;
            pnlLoadCheckboxes.Location = new Point(25, 55);
            pnlLoadCheckboxes.Name = "pnlLoadCheckboxes";
            pnlLoadCheckboxes.Size = new Size(160, 220);
            pnlLoadCheckboxes.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkKhaki;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Location = new Point(25, 280);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 25);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pnlSaveCheckboxes
            // 
            pnlSaveCheckboxes.AutoScroll = true;
            pnlSaveCheckboxes.Location = new Point(25, 55);
            pnlSaveCheckboxes.Name = "pnlSaveCheckboxes";
            pnlSaveCheckboxes.Size = new Size(160, 220);
            pnlSaveCheckboxes.TabIndex = 2;
            // 
            // lblSave
            // 
            lblSave.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblSave.Location = new Point(25, 25);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size(160, 25);
            lblSave.TabIndex = 14;
            lblSave.Text = "label3";
            lblSave.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Olive;
            panel3.Location = new Point(205, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1, 320);
            panel3.TabIndex = 12;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Olive;
            panel4.Location = new Point(5, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(1, 320);
            panel4.TabIndex = 13;
            // 
            // label3
            // 
            label3.BackColor = Color.Olive;
            label3.Location = new Point(5, 5);
            label3.Name = "label3";
            label3.Size = new Size(201, 1);
            label3.TabIndex = 15;
            // 
            // label4
            // 
            label4.BackColor = Color.Olive;
            label4.Location = new Point(5, 325);
            label4.Name = "label4";
            label4.Size = new Size(201, 1);
            label4.TabIndex = 16;
            // 
            // label5
            // 
            label5.BackColor = Color.Olive;
            label5.Location = new Point(5, 325);
            label5.Name = "label5";
            label5.Size = new Size(201, 1);
            label5.TabIndex = 20;
            // 
            // label6
            // 
            label6.BackColor = Color.Olive;
            label6.Location = new Point(5, 5);
            label6.Name = "label6";
            label6.Size = new Size(201, 1);
            label6.TabIndex = 19;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Olive;
            panel5.Location = new Point(5, 5);
            panel5.Name = "panel5";
            panel5.Size = new Size(1, 320);
            panel5.TabIndex = 18;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Olive;
            panel6.Location = new Point(205, 5);
            panel6.Name = "panel6";
            panel6.Size = new Size(1, 320);
            panel6.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pnlLoadCheckboxes);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnLoadApply);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(10, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 330);
            panel1.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblSave);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(pnlSaveCheckboxes);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(230, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(210, 330);
            panel2.TabIndex = 22;
            // 
            // LoadSavePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(optClipboard);
            Controls.Add(optFile);
            Name = "LoadSavePage";
            Size = new Size(1006, 1000);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.RadioButton optFile;
        private System.Windows.Forms.RadioButton optClipboard;
        private DTCButton btnLoadApply;
        private DTCButton btnLoad;
        private DTCButton btnSave;
        private Panel pnlLoadCheckboxes;
        private Panel pnlSaveCheckboxes;
        private Label lblSave;
        private Panel panel3;
        private Panel panel4;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel5;
        private Panel panel6;
        private Panel panel1;
        private Panel panel2;
    }
}
