namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    partial class HMDPage
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
            label1 = new Label();
            cboMode = new DTC.UI.Base.Controls.DTCDropDown();
            label2 = new Label();
            pnlContent = new Panel();
            btnReset = new DTC.UI.Base.Controls.DTCButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "Reject mode:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FlatStyle = FlatStyle.Flat;
            cboMode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMode.FormattingEnabled = true;
            cboMode.Location = new Point(121, 16);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(121, 24);
            cboMode.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 45);
            label2.Name = "label2";
            label2.Size = new Size(354, 25);
            label2.TabIndex = 0;
            label2.Text = "Reject settings:                     NORM    REJ1   REJ2";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.AutoScroll = true;
            pnlContent.Location = new Point(15, 75);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(606, 390);
            pnlContent.TabIndex = 2;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.DarkKhaki;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatAppearance.MouseDownBackColor = Color.Olive;
            btnReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnReset.Location = new Point(375, 45);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(80, 25);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // HMDPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(btnReset);
            Controls.Add(pnlContent);
            Controls.Add(cboMode);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HMDPage";
            Size = new Size(636, 480);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DTC.UI.Base.Controls.DTCDropDown cboMode;
        private Label label2;
        private Panel pnlContent;
        private DTC.UI.Base.Controls.DTCButton btnReset;
    }
}
