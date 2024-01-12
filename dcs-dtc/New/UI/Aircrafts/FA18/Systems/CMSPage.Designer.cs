
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
            SuspendLayout();
            // 
            // cboMode
            // 
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FlatStyle = FlatStyle.Flat;
            cboMode.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboMode.FormattingEnabled = true;
            cboMode.Location = new Point(155, 15);
            cboMode.Name = "cboMode";
            cboMode.Size = new Size(121, 24);
            cboMode.TabIndex = 0;
            // 
            // cboProgram
            // 
            cboProgram.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProgram.FlatStyle = FlatStyle.Flat;
            cboProgram.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboProgram.FormattingEnabled = true;
            cboProgram.Location = new Point(155, 46);
            cboProgram.Name = "cboProgram";
            cboProgram.Size = new Size(121, 24);
            cboProgram.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(15, 114);
            panel1.Name = "panel1";
            panel1.Size = new Size(658, 401);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 3;
            label1.Text = "Mode:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(15, 45);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 3;
            label2.Text = "Selected Program:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkHUD
            // 
            chkHUD.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkHUD.Location = new Point(15, 77);
            chkHUD.Name = "chkHUD";
            chkHUD.Size = new Size(162, 24);
            chkHUD.TabIndex = 4;
            chkHUD.Text = "Enable EW on HUD";
            chkHUD.UseVisualStyleBackColor = true;
            // 
            // CMSPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(chkHUD);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(cboProgram);
            Controls.Add(cboMode);
            Name = "CMSPage";
            Size = new Size(698, 548);
            ResumeLayout(false);
        }

        #endregion

        private DTC.UI.Base.Controls.DTCDropDown cboMode;
        private DTC.UI.Base.Controls.DTCDropDown cboProgram;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private DTC.UI.Base.Controls.DTCCheckBox chkHUD;
    }
}
