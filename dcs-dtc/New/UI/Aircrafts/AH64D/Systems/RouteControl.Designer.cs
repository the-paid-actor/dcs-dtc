namespace DTC.New.UI.Aircrafts.AH64D.Systems
{
    partial class RouteControl
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
            label4 = new Label();
            txtTo = new DTC.UI.Base.Controls.DTCNumericTextBox();
            txtWpts = new DTC.UI.Base.Controls.DTCTextBox();
            txtFrom = new DTC.UI.Base.Controls.DTCNumericTextBox();
            radSpecific = new RadioButton();
            radRange = new RadioButton();
            radAll = new RadioButton();
            chkWpts = new CheckBox();
            chkHazards = new CheckBox();
            chkCM = new CheckBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(198, 30);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Padding = new Padding(5, 0, 0, 0);
            label4.Size = new Size(40, 25);
            label4.TabIndex = 45;
            label4.Text = "to:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTo
            // 
            txtTo.AllowFraction = false;
            txtTo.BackColor = SystemColors.Window;
            txtTo.Enabled = false;
            txtTo.Location = new Point(234, 30);
            txtTo.MaximumValue = new decimal(new int[] { 999, 0, 0, 0 });
            txtTo.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(45, 25);
            txtTo.TabIndex = 4;
            txtTo.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            txtTo.Value = null;
            // 
            // txtWpts
            // 
            txtWpts.AllowPromptAsInput = true;
            txtWpts.BackColor = SystemColors.Window;
            txtWpts.Enabled = false;
            txtWpts.HidePromptOnLeave = false;
            txtWpts.InsertKeyMode = InsertKeyMode.Default;
            txtWpts.Location = new Point(150, 60);
            txtWpts.Mask = "";
            txtWpts.Name = "txtWpts";
            txtWpts.PromptChar = '_';
            txtWpts.Size = new Size(200, 25);
            txtWpts.TabIndex = 5;
            txtWpts.ValidatingType = null;
            // 
            // txtFrom
            // 
            txtFrom.AllowFraction = false;
            txtFrom.BackColor = SystemColors.Window;
            txtFrom.Enabled = false;
            txtFrom.Location = new Point(150, 30);
            txtFrom.MaximumValue = new decimal(new int[] { 999, 0, 0, 0 });
            txtFrom.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(45, 25);
            txtFrom.TabIndex = 3;
            txtFrom.Unit = DTC.UI.Base.Controls.DTCNumericTextBox.UnitEnum.None;
            txtFrom.Value = null;
            // 
            // radSpecific
            // 
            radSpecific.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radSpecific.Location = new Point(0, 60);
            radSpecific.Name = "radSpecific";
            radSpecific.Size = new Size(144, 25);
            radSpecific.TabIndex = 2;
            radSpecific.TabStop = true;
            radSpecific.Text = "Specific waypoints";
            radSpecific.UseVisualStyleBackColor = true;
            // 
            // radRange
            // 
            radRange.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radRange.Location = new Point(0, 30);
            radRange.Name = "radRange";
            radRange.Size = new Size(144, 25);
            radRange.TabIndex = 1;
            radRange.TabStop = true;
            radRange.Text = "Use range";
            radRange.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            radAll.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radAll.Location = new Point(0, 0);
            radAll.Name = "radAll";
            radAll.Size = new Size(144, 25);
            radAll.TabIndex = 0;
            radAll.TabStop = true;
            radAll.Text = "Use all";
            radAll.UseVisualStyleBackColor = true;
            // 
            // chkWpts
            // 
            chkWpts.Checked = true;
            chkWpts.CheckState = CheckState.Checked;
            chkWpts.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkWpts.Location = new Point(84, 0);
            chkWpts.Margin = new Padding(4);
            chkWpts.Name = "chkWpts";
            chkWpts.Size = new Size(97, 25);
            chkWpts.TabIndex = 46;
            chkWpts.Text = "Waypoints";
            chkWpts.UseVisualStyleBackColor = true;
            // 
            // chkHazards
            // 
            chkHazards.Checked = true;
            chkHazards.CheckState = CheckState.Checked;
            chkHazards.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkHazards.Location = new Point(182, 0);
            chkHazards.Margin = new Padding(4);
            chkHazards.Name = "chkHazards";
            chkHazards.Size = new Size(97, 25);
            chkHazards.TabIndex = 46;
            chkHazards.Text = "Hazards";
            chkHazards.UseVisualStyleBackColor = true;
            // 
            // chkCM
            // 
            chkCM.Checked = true;
            chkCM.CheckState = CheckState.Checked;
            chkCM.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkCM.Location = new Point(266, 0);
            chkCM.Margin = new Padding(4);
            chkCM.Name = "chkCM";
            chkCM.Size = new Size(151, 25);
            chkCM.TabIndex = 46;
            chkCM.Text = "Control Measures";
            chkCM.UseVisualStyleBackColor = true;
            // 
            // RouteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(chkCM);
            Controls.Add(chkHazards);
            Controls.Add(chkWpts);
            Controls.Add(label4);
            Controls.Add(txtTo);
            Controls.Add(txtWpts);
            Controls.Add(txtFrom);
            Controls.Add(radSpecific);
            Controls.Add(radRange);
            Controls.Add(radAll);
            Name = "RouteControl";
            Size = new Size(478, 85);
            ResumeLayout(false);
        }

        #endregion

        private Label label4;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtTo;
        protected DTC.UI.Base.Controls.DTCTextBox txtWpts;
        protected DTC.UI.Base.Controls.DTCNumericTextBox txtFrom;
        private RadioButton radSpecific;
        private RadioButton radRange;
        private RadioButton radAll;
        private CheckBox chkWpts;
        private CheckBox chkHazards;
        private CheckBox chkCM;
    }
}
