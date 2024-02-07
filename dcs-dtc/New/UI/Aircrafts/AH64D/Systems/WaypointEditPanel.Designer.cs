namespace DTC.New.UI.Aircrafts.AH64D.Systems
{
    partial class WaypointEditPanel
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
            label1 = new Label();
            cboIdentifier = new DTC.UI.Base.Controls.DTCDropDown();
            label2 = new Label();
            cboPointTypes = new DTC.UI.Base.Controls.DTCDropDown();
            txtFree = new DTC.UI.Base.Controls.DTCTextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(0, 32);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(5, 0, 0, 0);
            label5.Size = new Size(150, 25);
            label5.TabIndex = 15;
            label5.Text = "Identifier:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 63);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 0, 0, 0);
            label1.Size = new Size(150, 25);
            label1.TabIndex = 15;
            label1.Text = "Free Text:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboIdentifier
            // 
            cboIdentifier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboIdentifier.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIdentifier.FlatStyle = FlatStyle.Flat;
            cboIdentifier.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboIdentifier.FormattingEnabled = true;
            cboIdentifier.Location = new Point(163, 33);
            cboIdentifier.Name = "cboIdentifier";
            cboIdentifier.Size = new Size(388, 24);
            cboIdentifier.TabIndex = 17;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 0, 0, 0);
            label2.Size = new Size(150, 25);
            label2.TabIndex = 15;
            label2.Text = "Point Type";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboPointTypes
            // 
            cboPointTypes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPointTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPointTypes.FlatStyle = FlatStyle.Flat;
            cboPointTypes.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboPointTypes.FormattingEnabled = true;
            cboPointTypes.Location = new Point(163, 3);
            cboPointTypes.Name = "cboPointTypes";
            cboPointTypes.Size = new Size(388, 24);
            cboPointTypes.TabIndex = 17;
            cboPointTypes.SelectedIndexChanged += cboPointTypes_SelectedIndexChanged;
            // 
            // txtFree
            // 
            txtFree.AllowPromptAsInput = true;
            txtFree.BackColor = SystemColors.Window;
            txtFree.HidePromptOnLeave = true;
            txtFree.InsertKeyMode = InsertKeyMode.Default;
            txtFree.Location = new Point(163, 63);
            txtFree.Mask = "AAA";
            txtFree.Name = "txtFree";
            txtFree.PromptChar = '_';
            txtFree.Size = new Size(62, 25);
            txtFree.TabIndex = 18;
            txtFree.ValidatingType = null;
            // 
            // WaypointEditPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(txtFree);
            Controls.Add(cboIdentifier);
            Controls.Add(cboPointTypes);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Name = "WaypointEditPanel";
            Size = new Size(555, 257);
            ResumeLayout(false);
        }

        #endregion

        private Label label5;
        private Label label1;
        protected DTC.UI.Base.Controls.DTCDropDown cboIdentifier;
        private Label label2;
        protected DTC.UI.Base.Controls.DTCDropDown cboPointTypes;
        protected DTC.UI.Base.Controls.DTCTextBox txtFree;
    }
}
