using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems
{
    partial class WaypointCapturePage
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
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            radNavEndOfList = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            radTgtAppend = new RadioButton();
            radTgtRange = new RadioButton();
            txtTgtRangeFrom = new DTCNumericTextBox();
            panel1 = new Panel();
            radNavEndOfGap = new RadioButton();
            radNavRange = new RadioButton();
            txtNavRangeFrom = new DTCNumericTextBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 20;
            // 
            // radNavEndOfList
            // 
            radNavEndOfList.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radNavEndOfList.Location = new Point(10, 32);
            radNavEndOfList.Name = "radNavEndOfList";
            radNavEndOfList.Size = new Size(171, 25);
            radNavEndOfList.TabIndex = 33;
            radNavEndOfList.Text = "Add to end of the list";
            radNavEndOfList.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Enabled = false;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(1, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(5, 0, 0, 0);
            label1.Size = new Size(148, 25);
            label1.TabIndex = 31;
            label1.Text = "Navigation Points";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Enabled = false;
            label2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(1, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(5, 0, 0, 0);
            label2.Size = new Size(148, 25);
            label2.TabIndex = 31;
            label2.Text = "Target Points";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radTgtAppend
            // 
            radTgtAppend.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radTgtAppend.Location = new Point(10, 33);
            radTgtAppend.Name = "radTgtAppend";
            radTgtAppend.Size = new Size(199, 25);
            radTgtAppend.TabIndex = 33;
            radTgtAppend.Text = "Add to the end of the list";
            radTgtAppend.UseVisualStyleBackColor = true;
            // 
            // radTgtRange
            // 
            radTgtRange.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radTgtRange.Location = new Point(10, 63);
            radTgtRange.Name = "radTgtRange";
            radTgtRange.Size = new Size(251, 25);
            radTgtRange.TabIndex = 33;
            radTgtRange.Text = "Add to specific range, starting from:";
            radTgtRange.UseVisualStyleBackColor = true;
            // 
            // txtTgtRangeFrom
            // 
            txtTgtRangeFrom.AllowFraction = false;
            txtTgtRangeFrom.BackColor = SystemColors.Window;
            txtTgtRangeFrom.Location = new Point(267, 63);
            txtTgtRangeFrom.MaximumValue = new decimal(new int[] { 99, 0, 0, 0 });
            txtTgtRangeFrom.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtTgtRangeFrom.Name = "txtTgtRangeFrom";
            txtTgtRangeFrom.Size = new Size(57, 25);
            txtTgtRangeFrom.TabIndex = 4;
            txtTgtRangeFrom.Unit = DTCNumericTextBox.UnitEnum.None;
            txtTgtRangeFrom.Value = null;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(radNavEndOfGap);
            panel1.Controls.Add(radNavRange);
            panel1.Controls.Add(radNavEndOfList);
            panel1.Controls.Add(txtNavRangeFrom);
            panel1.Location = new Point(5, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 133);
            panel1.TabIndex = 34;
            // 
            // radNavEndOfGap
            // 
            radNavEndOfGap.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radNavEndOfGap.Location = new Point(10, 63);
            radNavEndOfGap.Name = "radNavEndOfGap";
            radNavEndOfGap.Size = new Size(199, 25);
            radNavEndOfGap.TabIndex = 33;
            radNavEndOfGap.Text = "Add to end of the first gap";
            radNavEndOfGap.UseVisualStyleBackColor = true;
            // 
            // radNavRange
            // 
            radNavRange.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radNavRange.Location = new Point(10, 94);
            radNavRange.Name = "radNavRange";
            radNavRange.Size = new Size(251, 25);
            radNavRange.TabIndex = 33;
            radNavRange.Text = "Add to specific range, starting from:";
            radNavRange.UseVisualStyleBackColor = true;
            // 
            // txtNavRangeFrom
            // 
            txtNavRangeFrom.AllowFraction = false;
            txtNavRangeFrom.BackColor = SystemColors.Window;
            txtNavRangeFrom.Location = new Point(267, 94);
            txtNavRangeFrom.MaximumValue = new decimal(new int[] { 99, 0, 0, 0 });
            txtNavRangeFrom.MinimumValue = new decimal(new int[] { 1, 0, 0, 0 });
            txtNavRangeFrom.Name = "txtNavRangeFrom";
            txtNavRangeFrom.Size = new Size(57, 25);
            txtNavRangeFrom.TabIndex = 4;
            txtNavRangeFrom.Unit = DTCNumericTextBox.UnitEnum.None;
            txtNavRangeFrom.Value = null;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(radTgtAppend);
            panel2.Controls.Add(radTgtRange);
            panel2.Controls.Add(txtTgtRangeFrom);
            panel2.Location = new Point(5, 149);
            panel2.Name = "panel2";
            panel2.Size = new Size(433, 104);
            panel2.TabIndex = 34;
            // 
            // WaypointCapturePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "WaypointCapturePage";
            Size = new Size(616, 454);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ToolTip toolTip1;
        private RadioButton radNavEndOfList;
        private Label label1;
        private Label label2;
        private RadioButton radTgtAppend;
        private RadioButton radTgtRange;
        private DTCNumericTextBox txtTgtRangeFrom;
        private Panel panel1;
        private Panel panel2;
        private RadioButton radNavEndOfGap;
        private RadioButton radNavRange;
        private DTCNumericTextBox txtNavRangeFrom;
    }
}
