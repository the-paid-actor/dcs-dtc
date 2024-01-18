
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F16.Systems
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
            chkMFDs = new CheckBox();
            chkRadios = new CheckBox();
            chkCMS = new CheckBox();
            chkWaypoints = new CheckBox();
            toolTip1 = new ToolTip(components);
            chkMisc = new CheckBox();
            chkHARMHTS = new CheckBox();
            chkDatalink = new CheckBox();
            SuspendLayout();
            // 
            // chkMFDs
            // 
            chkMFDs.Checked = true;
            chkMFDs.CheckState = CheckState.Checked;
            chkMFDs.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMFDs.Location = new Point(15, 114);
            chkMFDs.Margin = new Padding(4);
            chkMFDs.Name = "chkMFDs";
            chkMFDs.Size = new Size(323, 25);
            chkMFDs.TabIndex = 9;
            chkMFDs.Text = "MFDs";
            chkMFDs.UseVisualStyleBackColor = true;
            // 
            // chkRadios
            // 
            chkRadios.Checked = true;
            chkRadios.CheckState = CheckState.Checked;
            chkRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRadios.Location = new Point(15, 81);
            chkRadios.Margin = new Padding(4);
            chkRadios.Name = "chkRadios";
            chkRadios.Size = new Size(78, 25);
            chkRadios.TabIndex = 7;
            chkRadios.Text = "Radios";
            chkRadios.UseVisualStyleBackColor = true;
            // 
            // chkCMS
            // 
            chkCMS.Checked = true;
            chkCMS.CheckState = CheckState.Checked;
            chkCMS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkCMS.Location = new Point(15, 48);
            chkCMS.Margin = new Padding(4);
            chkCMS.Name = "chkCMS";
            chkCMS.Size = new Size(63, 25);
            chkCMS.TabIndex = 6;
            chkCMS.Text = "CMS";
            chkCMS.UseVisualStyleBackColor = true;
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
            // chkMisc
            // 
            chkMisc.Checked = true;
            chkMisc.CheckState = CheckState.Checked;
            chkMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMisc.Location = new Point(15, 213);
            chkMisc.Margin = new Padding(4);
            chkMisc.Name = "chkMisc";
            chkMisc.Size = new Size(167, 25);
            chkMisc.TabIndex = 8;
            chkMisc.Text = "Misc";
            chkMisc.UseVisualStyleBackColor = true;
            // 
            // chkHARMHTS
            // 
            chkHARMHTS.Checked = true;
            chkHARMHTS.CheckState = CheckState.Checked;
            chkHARMHTS.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkHARMHTS.Location = new Point(15, 147);
            chkHARMHTS.Margin = new Padding(4);
            chkHARMHTS.Name = "chkHARMHTS";
            chkHARMHTS.Size = new Size(323, 25);
            chkHARMHTS.TabIndex = 10;
            chkHARMHTS.Text = "HARM / HTS";
            chkHARMHTS.UseVisualStyleBackColor = true;
            // 
            // chkDatalink
            // 
            chkDatalink.Checked = true;
            chkDatalink.CheckState = CheckState.Checked;
            chkDatalink.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkDatalink.Location = new Point(15, 180);
            chkDatalink.Margin = new Padding(4);
            chkDatalink.Name = "chkDatalink";
            chkDatalink.Size = new Size(323, 25);
            chkDatalink.TabIndex = 32;
            chkDatalink.Text = "Datalink";
            chkDatalink.UseVisualStyleBackColor = true;
            // 
            // UploadPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(chkDatalink);
            Controls.Add(chkHARMHTS);
            Controls.Add(chkMisc);
            Controls.Add(chkMFDs);
            Controls.Add(chkRadios);
            Controls.Add(chkCMS);
            Controls.Add(chkWaypoints);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UploadPage";
            Size = new Size(636, 554);
            ResumeLayout(false);
        }

        #endregion

        private CheckBox chkMFDs;
        private CheckBox chkRadios;
        private CheckBox chkCMS;
        private CheckBox chkWaypoints;
        private ToolTip toolTip1;
        private CheckBox chkMisc;
        private CheckBox chkHARMHTS;
        private CheckBox chkDatalink;
    }
}
