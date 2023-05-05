
using DTC.UI.Base;

namespace DTC.UI.Aircrafts.FA18
{
    partial class SequencePage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.seq1 = new System.Windows.Forms.TextBox();
            this.seq2 = new System.Windows.Forms.TextBox();
            this.seq3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSeq1 = new System.Windows.Forms.CheckBox();
            this.cbSeq2 = new System.Windows.Forms.CheckBox();
            this.cbSeq3 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fillWithAllWpts = new System.Windows.Forms.CheckBox();
            this.includeWpt0 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(689, 35);
            this.panel1.TabIndex = 99;
            // 
            // seq1
            // 
            this.seq1.Location = new System.Drawing.Point(74, 86);
            this.seq1.Name = "seq1";
            this.seq1.Size = new System.Drawing.Size(422, 20);
            this.seq1.TabIndex = 100;
            // 
            // seq2
            // 
            this.seq2.Location = new System.Drawing.Point(74, 186);
            this.seq2.Name = "seq2";
            this.seq2.Size = new System.Drawing.Size(422, 20);
            this.seq2.TabIndex = 101;
            // 
            // seq3
            // 
            this.seq3.Location = new System.Drawing.Point(74, 239);
            this.seq3.Name = "seq3";
            this.seq3.Size = new System.Drawing.Size(422, 20);
            this.seq3.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Sequence 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Sequence 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Sequence 3";
            // 
            // cbSeq1
            // 
            this.cbSeq1.AutoSize = true;
            this.cbSeq1.Location = new System.Drawing.Point(53, 89);
            this.cbSeq1.Name = "cbSeq1";
            this.cbSeq1.Size = new System.Drawing.Size(15, 14);
            this.cbSeq1.TabIndex = 106;
            this.cbSeq1.UseVisualStyleBackColor = true;
            // 
            // cbSeq2
            // 
            this.cbSeq2.AutoSize = true;
            this.cbSeq2.Location = new System.Drawing.Point(53, 189);
            this.cbSeq2.Name = "cbSeq2";
            this.cbSeq2.Size = new System.Drawing.Size(15, 14);
            this.cbSeq2.TabIndex = 107;
            this.cbSeq2.UseVisualStyleBackColor = true;
            // 
            // cbSeq3
            // 
            this.cbSeq3.AutoSize = true;
            this.cbSeq3.Location = new System.Drawing.Point(53, 242);
            this.cbSeq3.Name = "cbSeq3";
            this.cbSeq3.Size = new System.Drawing.Size(15, 14);
            this.cbSeq3.TabIndex = 108;
            this.cbSeq3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(399, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "Sequences are entered as comma separated waypoint numbers. (ex. 1,5,8,9,15,53)";
            // 
            // fillWithAllWpts
            // 
            this.fillWithAllWpts.AutoSize = true;
            this.fillWithAllWpts.Location = new System.Drawing.Point(74, 112);
            this.fillWithAllWpts.Name = "fillWithAllWpts";
            this.fillWithAllWpts.Size = new System.Drawing.Size(123, 17);
            this.fillWithAllWpts.TabIndex = 110;
            this.fillWithAllWpts.Text = "Fill with all waypoints";
            this.fillWithAllWpts.UseVisualStyleBackColor = true;
            this.fillWithAllWpts.CheckedChanged += new System.EventHandler(this.fillWithAllWpts_CheckedChanged);
            // 
            // includeWpt0
            // 
            this.includeWpt0.AutoSize = true;
            this.includeWpt0.Enabled = false;
            this.includeWpt0.Location = new System.Drawing.Point(74, 135);
            this.includeWpt0.Name = "includeWpt0";
            this.includeWpt0.Size = new System.Drawing.Size(115, 17);
            this.includeWpt0.TabIndex = 111;
            this.includeWpt0.Text = "Include waypoint 0";
            this.includeWpt0.UseVisualStyleBackColor = true;
            this.includeWpt0.CheckedChanged += new System.EventHandler(this.includeWpt0_CheckedChanged);
            // 
            // SequencePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.Controls.Add(this.includeWpt0);
            this.Controls.Add(this.fillWithAllWpts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSeq3);
            this.Controls.Add(this.cbSeq2);
            this.Controls.Add(this.cbSeq1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seq3);
            this.Controls.Add(this.seq2);
            this.Controls.Add(this.seq1);
            this.Controls.Add(this.panel1);
            this.Name = "SequencePage";
            this.Size = new System.Drawing.Size(689, 483);
            this.VisibleChanged += new System.EventHandler(this.SequencePage_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox seq1;
        private System.Windows.Forms.TextBox seq2;
        private System.Windows.Forms.TextBox seq3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSeq1;
        private System.Windows.Forms.CheckBox cbSeq2;
        private System.Windows.Forms.CheckBox cbSeq3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox fillWithAllWpts;
        private System.Windows.Forms.CheckBox includeWpt0;
    }
}
