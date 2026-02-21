
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.AV8B.Systems
{
    partial class UploadPage
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
            chkWaypoints = new CheckBox();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // chkWaypoints
            // 
            chkWaypoints.Checked = true;
            chkWaypoints.CheckState = CheckState.Checked;
            chkWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkWaypoints.Location = new Point(15, 15);
            chkWaypoints.Margin = new Padding(4);
            chkWaypoints.Name = "chkWaypoints";
            chkWaypoints.Size = new Size(154, 25);
            chkWaypoints.TabIndex = 0;
            chkWaypoints.Text = "Waypoints";
            chkWaypoints.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 20;
            // 
            // UploadPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(chkWaypoints);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UploadPage";
            Size = new Size(636, 554);
            ResumeLayout(false);
        }

        #endregion
        private CheckBox chkWaypoints;
        private ToolTip toolTip1;
    }
}
