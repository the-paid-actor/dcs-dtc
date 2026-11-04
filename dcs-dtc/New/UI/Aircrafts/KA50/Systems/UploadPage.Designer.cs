using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.KA50.Systems
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
            lblPvi = new Label();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // chkWaypoints
            // 
            chkWaypoints.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkWaypoints.Location = new Point(15, 15);
            chkWaypoints.Margin = new Padding(4);
            chkWaypoints.Name = "chkWaypoints";
            chkWaypoints.Size = new Size(280, 25);
            chkWaypoints.TabIndex = 0;
            chkWaypoints.Text = "Waypoints (PVI 1-6)";
            chkWaypoints.UseVisualStyleBackColor = true;
            // 
            // lblPvi
            // 
            lblPvi.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPvi.Location = new Point(15, 52);
            lblPvi.Name = "lblPvi";
            lblPvi.Size = new Size(590, 130);
            lblPvi.TabIndex = 1;
            lblPvi.Text = "Enters steerpoints into the PVI-800 (ППМ 1-6).\r\nThe navigation system must already be powered. Upload switches the PVI to ВВОД, types the coordinates, then returns it to РАБОТА.\r\nLatitude is DDMM.m and longitude is DDDMM.m. Names and elevation are kept in the preset only.\r\nHold the accelerometer reset button for 1 second to upload from the cockpit.";
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
            Controls.Add(lblPvi);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UploadPage";
            Size = new Size(636, 554);
            ResumeLayout(false);
        }

        #endregion
        private CheckBox chkWaypoints;
        private Label lblPvi;
        private ToolTip toolTip1;
    }
}
