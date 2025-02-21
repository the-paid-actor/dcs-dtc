namespace DTC.New.UI.Base.Systems
{
    partial class KneeboardPage
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
            txtInfo = new TextBox();
            txtNotes = new TextBox();
            btnInfo = new DTC.UI.Base.Controls.DTCButton();
            btnNotes = new DTC.UI.Base.Controls.DTCButton();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtInfo
            // 
            txtInfo.Dock = DockStyle.Fill;
            txtInfo.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtInfo.Location = new Point(0, 37);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.ScrollBars = ScrollBars.Vertical;
            txtInfo.Size = new Size(536, 414);
            txtInfo.TabIndex = 2;
            // 
            // txtNotes
            // 
            txtNotes.Dock = DockStyle.Fill;
            txtNotes.Font = new Font("Consolas", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtNotes.Location = new Point(0, 37);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(536, 414);
            txtNotes.TabIndex = 3;
            txtNotes.Visible = false;
            // 
            // btnInfo
            // 
            btnInfo.BackColor = Color.DarkKhaki;
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnInfo.Location = new Point(5, 5);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(100, 25);
            btnInfo.TabIndex = 0;
            btnInfo.Text = "Info";
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnNotes
            // 
            btnNotes.BackColor = Color.DarkKhaki;
            btnNotes.FlatAppearance.BorderSize = 0;
            btnNotes.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnNotes.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnNotes.FlatStyle = FlatStyle.Flat;
            btnNotes.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNotes.Location = new Point(111, 5);
            btnNotes.Name = "btnNotes";
            btnNotes.Size = new Size(100, 25);
            btnNotes.TabIndex = 1;
            btnNotes.Text = "Notes";
            btnNotes.UseVisualStyleBackColor = false;
            btnNotes.Click += btnNotes_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNotes);
            panel1.Controls.Add(btnInfo);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(536, 37);
            panel1.TabIndex = 2;
            // 
            // KneeboardPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(txtInfo);
            Controls.Add(txtNotes);
            Controls.Add(panel1);
            Name = "KneeboardPage";
            Size = new Size(536, 451);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInfo;
        private TextBox txtNotes;
        private DTC.UI.Base.Controls.DTCButton btnInfo;
        private DTC.UI.Base.Controls.DTCButton btnNotes;
        private Panel panel1;
    }
}
