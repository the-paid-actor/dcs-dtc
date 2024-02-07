
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.AH64D.Systems
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
            chkControlMeasures = new CheckBox();
            chkTargets = new CheckBox();
            chkRoutes = new CheckBox();
            chkTSD = new CheckBox();
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
            chkWaypoints.Size = new Size(102, 25);
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
            // chkControlMeasures
            // 
            chkControlMeasures.Checked = true;
            chkControlMeasures.CheckState = CheckState.Checked;
            chkControlMeasures.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkControlMeasures.Location = new Point(15, 48);
            chkControlMeasures.Margin = new Padding(4);
            chkControlMeasures.Name = "chkControlMeasures";
            chkControlMeasures.Size = new Size(154, 25);
            chkControlMeasures.TabIndex = 0;
            chkControlMeasures.Text = "Control Measures";
            chkControlMeasures.UseVisualStyleBackColor = true;
            // 
            // chkTargets
            // 
            chkTargets.Checked = true;
            chkTargets.CheckState = CheckState.Checked;
            chkTargets.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkTargets.Location = new Point(15, 81);
            chkTargets.Margin = new Padding(4);
            chkTargets.Name = "chkTargets";
            chkTargets.Size = new Size(154, 25);
            chkTargets.TabIndex = 0;
            chkTargets.Text = "Targets";
            chkTargets.UseVisualStyleBackColor = true;
            // 
            // chkRoutes
            // 
            chkRoutes.Checked = true;
            chkRoutes.CheckState = CheckState.Checked;
            chkRoutes.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRoutes.Location = new Point(15, 114);
            chkRoutes.Margin = new Padding(4);
            chkRoutes.Name = "chkRoutes";
            chkRoutes.Size = new Size(154, 25);
            chkRoutes.TabIndex = 0;
            chkRoutes.Text = "Routes";
            chkRoutes.UseVisualStyleBackColor = true;
            // 
            // chkTSD
            // 
            chkTSD.Checked = true;
            chkTSD.CheckState = CheckState.Checked;
            chkTSD.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkTSD.Location = new Point(15, 147);
            chkTSD.Margin = new Padding(4);
            chkTSD.Name = "chkTSD";
            chkTSD.Size = new Size(154, 25);
            chkTSD.TabIndex = 0;
            chkTSD.Text = "TSD";
            chkTSD.UseVisualStyleBackColor = true;
            // 
            // UploadPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(chkTSD);
            Controls.Add(chkRoutes);
            Controls.Add(chkTargets);
            Controls.Add(chkControlMeasures);
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
        private CheckBox chkControlMeasures;
        private CheckBox chkTargets;
        private CheckBox chkRoutes;
        private CheckBox chkTSD;
    }
}
