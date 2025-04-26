
namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    partial class CMSPage
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
            cboMode = new DTC.UI.Base.Controls.DTCDropDown();
            cboProgram = new DTC.UI.Base.Controls.DTCDropDown();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            chkHUD = new DTC.UI.Base.Controls.DTCCheckBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FlatStyle = FlatStyle.Flat;
            cboMode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMode.FormattingEnabled = true;
            cboMode.Location = new Point(194, 53);
            cboMode.Margin = new Padding(4);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(150, 28);
            cboMode.TabIndex = 0;
            // 
            // cboProgram
            // 
            cboProgram.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProgram.FlatStyle = FlatStyle.Flat;
            cboProgram.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboProgram.FormattingEnabled = true;
            cboProgram.Location = new Point(194, 134);
            cboProgram.Margin = new Padding(4);
            cboProgram.Name = "cboProgram";
            cboProgram.Size = new Size(150, 28);
            cboProgram.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(19, 181);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(822, 462);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(19, 53);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 31);
            label1.TabIndex = 3;
            label1.Text = "Mode:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 132);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(168, 31);
            label2.TabIndex = 3;
            label2.Text = "Selected Program:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkHUD
            // 
            chkHUD.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkHUD.Location = new Point(19, 18);
            chkHUD.Margin = new Padding(4);
            chkHUD.Name = "chkHUD";
            chkHUD.Size = new Size(202, 30);
            chkHUD.TabIndex = 4;
            chkHUD.Text = "Enable EW on HUD";
            chkHUD.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(19, 91);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(429, 31);
            label3.TabIndex = 5;
            label3.Text = "Settings below will only apply if Mode = Manual";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CMSPage
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(label3);
            Controls.Add(chkHUD);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(cboProgram);
            Controls.Add(cboMode);
            Margin = new Padding(4);
            Name = "CMSPage";
            Size = new Size(872, 685);
            ResumeLayout(false);
        }

        #endregion

        private DTC.UI.Base.Controls.DTCDropDown cboMode;
        private DTC.UI.Base.Controls.DTCDropDown cboProgram;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private DTC.UI.Base.Controls.DTCCheckBox chkHUD;
        private Label label3;
    }
}
