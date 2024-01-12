
namespace DTC.New.UI.Aircrafts.FA18.Systems
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
            pnlSeq1 = new SequenceControl();
            chkSeq1 = new CheckBox();
            pnlSeq2 = new SequenceControl();
            chkSeq2 = new CheckBox();
            pnlSeq3 = new SequenceControl();
            chkSeq3 = new CheckBox();
            SuspendLayout();
            // 
            // pnlSeq1
            // 
            pnlSeq1.BackColor = Color.PaleGoldenrod;
            pnlSeq1.Enabled = false;
            pnlSeq1.Location = new Point(35, 45);
            pnlSeq1.Name = "pnlSeq1";
            pnlSeq1.Size = new Size(403, 85);
            pnlSeq1.TabIndex = 1;
            // 
            // chkSeq1
            // 
            chkSeq1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSeq1.Location = new Point(15, 15);
            chkSeq1.Margin = new Padding(4);
            chkSeq1.Name = "chkSeq1";
            chkSeq1.Size = new Size(128, 25);
            chkSeq1.TabIndex = 0;
            chkSeq1.Text = "Sequence 1";
            chkSeq1.UseVisualStyleBackColor = true;
            // 
            // pnlSeq2
            // 
            pnlSeq2.BackColor = Color.PaleGoldenrod;
            pnlSeq2.Enabled = false;
            pnlSeq2.Location = new Point(35, 165);
            pnlSeq2.Name = "pnlSeq2";
            pnlSeq2.Size = new Size(403, 85);
            pnlSeq2.TabIndex = 3;
            // 
            // chkSeq2
            // 
            chkSeq2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSeq2.Location = new Point(15, 135);
            chkSeq2.Margin = new Padding(4);
            chkSeq2.Name = "chkSeq2";
            chkSeq2.Size = new Size(128, 25);
            chkSeq2.TabIndex = 2;
            chkSeq2.Text = "Sequence 2";
            chkSeq2.UseVisualStyleBackColor = true;
            // 
            // pnlSeq3
            // 
            pnlSeq3.BackColor = Color.PaleGoldenrod;
            pnlSeq3.Enabled = false;
            pnlSeq3.Location = new Point(35, 285);
            pnlSeq3.Name = "pnlSeq3";
            pnlSeq3.Size = new Size(403, 85);
            pnlSeq3.TabIndex = 5;
            // 
            // chkSeq3
            // 
            chkSeq3.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSeq3.Location = new Point(15, 255);
            chkSeq3.Margin = new Padding(4);
            chkSeq3.Name = "chkSeq3";
            chkSeq3.Size = new Size(128, 25);
            chkSeq3.TabIndex = 4;
            chkSeq3.Text = "Sequence 3";
            chkSeq3.UseVisualStyleBackColor = true;
            // 
            // SequencePage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(chkSeq3);
            Controls.Add(pnlSeq3);
            Controls.Add(chkSeq2);
            Controls.Add(pnlSeq2);
            Controls.Add(chkSeq1);
            Controls.Add(pnlSeq1);
            Name = "SequencePage";
            Size = new Size(689, 483);
            ResumeLayout(false);
        }

        #endregion
        private SequenceControl pnlSeq1;
        private CheckBox chkSeq1;
        private SequenceControl pnlSeq2;
        private CheckBox chkSeq2;
        private SequenceControl pnlSeq3;
        private CheckBox chkSeq3;
    }
}
