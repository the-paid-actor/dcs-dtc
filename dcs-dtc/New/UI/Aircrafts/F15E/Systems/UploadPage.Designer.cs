
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F15E.Systems
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
            chkRouteA = new CheckBox();
            toolTip1 = new ToolTip(components);
            chkDisplays = new CheckBox();
            chkMisc = new CheckBox();
            radDisplaysAuto = new RadioButton();
            radDisplaysPilotAndWSO = new RadioButton();
            chkRadios = new CheckBox();
            chkSmartWeapons = new CheckBox();
            chkRouteB = new CheckBox();
            chkRouteC = new CheckBox();
            SuspendLayout();
            // 
            // chkRouteA
            // 
            chkRouteA.Checked = true;
            chkRouteA.CheckState = CheckState.Checked;
            chkRouteA.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRouteA.Location = new Point(16, 18);
            chkRouteA.Margin = new Padding(4);
            chkRouteA.Name = "chkRouteA";
            chkRouteA.Size = new Size(102, 25);
            chkRouteA.TabIndex = 0;
            chkRouteA.Text = "Route A";
            chkRouteA.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 100;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.IsBalloon = true;
            toolTip1.ReshowDelay = 20;
            // 
            // chkDisplays
            // 
            chkDisplays.Checked = true;
            chkDisplays.CheckState = CheckState.Checked;
            chkDisplays.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkDisplays.Location = new Point(16, 183);
            chkDisplays.Margin = new Padding(4);
            chkDisplays.Name = "chkDisplays";
            chkDisplays.Size = new Size(234, 25);
            chkDisplays.TabIndex = 3;
            chkDisplays.Text = "Displays";
            chkDisplays.UseVisualStyleBackColor = true;
            chkDisplays.CheckedChanged += chkDisplays_CheckedChanged;
            // 
            // chkMisc
            // 
            chkMisc.Checked = true;
            chkMisc.CheckState = CheckState.Checked;
            chkMisc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkMisc.Location = new Point(16, 270);
            chkMisc.Margin = new Padding(4);
            chkMisc.Name = "chkMisc";
            chkMisc.Size = new Size(234, 25);
            chkMisc.TabIndex = 6;
            chkMisc.Text = "Misc";
            chkMisc.UseVisualStyleBackColor = true;
            chkMisc.CheckedChanged += chkMisc_CheckedChanged;
            // 
            // radDisplaysAuto
            // 
            radDisplaysAuto.AutoSize = true;
            radDisplaysAuto.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radDisplaysAuto.Location = new Point(39, 215);
            radDisplaysAuto.Name = "radDisplaysAuto";
            radDisplaysAuto.Size = new Size(97, 21);
            radDisplaysAuto.TabIndex = 4;
            radDisplaysAuto.TabStop = true;
            radDisplaysAuto.Text = "Auto-select";
            radDisplaysAuto.UseVisualStyleBackColor = true;
            radDisplaysAuto.CheckedChanged += radDisplaysAuto_CheckedChanged;
            // 
            // radDisplaysPilotAndWSO
            // 
            radDisplaysPilotAndWSO.AutoSize = true;
            radDisplaysPilotAndWSO.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            radDisplaysPilotAndWSO.Location = new Point(39, 242);
            radDisplaysPilotAndWSO.Name = "radDisplaysPilotAndWSO";
            radDisplaysPilotAndWSO.Size = new Size(118, 21);
            radDisplaysPilotAndWSO.TabIndex = 5;
            radDisplaysPilotAndWSO.TabStop = true;
            radDisplaysPilotAndWSO.Text = "Pilot and WSO";
            radDisplaysPilotAndWSO.UseVisualStyleBackColor = true;
            radDisplaysPilotAndWSO.CheckedChanged += radDisplaysPilotAndWSO_CheckedChanged;
            // 
            // chkRadios
            // 
            chkRadios.Checked = true;
            chkRadios.CheckState = CheckState.Checked;
            chkRadios.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRadios.Location = new Point(16, 117);
            chkRadios.Margin = new Padding(4);
            chkRadios.Name = "chkRadios";
            chkRadios.Size = new Size(234, 25);
            chkRadios.TabIndex = 1;
            chkRadios.Text = "Radios";
            chkRadios.UseVisualStyleBackColor = true;
            chkRadios.CheckedChanged += chkRadios_CheckedChanged;
            // 
            // chkSmartWeapons
            // 
            chkSmartWeapons.Checked = true;
            chkSmartWeapons.CheckState = CheckState.Checked;
            chkSmartWeapons.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkSmartWeapons.Location = new Point(16, 150);
            chkSmartWeapons.Margin = new Padding(4);
            chkSmartWeapons.Name = "chkSmartWeapons";
            chkSmartWeapons.Size = new Size(234, 25);
            chkSmartWeapons.TabIndex = 2;
            chkSmartWeapons.Text = "Smart Weapons";
            chkSmartWeapons.UseVisualStyleBackColor = true;
            // 
            // chkRouteB
            // 
            chkRouteB.Checked = true;
            chkRouteB.CheckState = CheckState.Checked;
            chkRouteB.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRouteB.Location = new Point(16, 51);
            chkRouteB.Margin = new Padding(4);
            chkRouteB.Name = "chkRouteB";
            chkRouteB.Size = new Size(102, 25);
            chkRouteB.TabIndex = 0;
            chkRouteB.Text = "Route B";
            chkRouteB.UseVisualStyleBackColor = true;
            // 
            // chkRouteC
            // 
            chkRouteC.Checked = true;
            chkRouteC.CheckState = CheckState.Checked;
            chkRouteC.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            chkRouteC.Location = new Point(16, 84);
            chkRouteC.Margin = new Padding(4);
            chkRouteC.Name = "chkRouteC";
            chkRouteC.Size = new Size(102, 25);
            chkRouteC.TabIndex = 0;
            chkRouteC.Text = "Route C";
            chkRouteC.UseVisualStyleBackColor = true;
            // 
            // UploadPage
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.PaleGoldenrod;
            Controls.Add(radDisplaysPilotAndWSO);
            Controls.Add(radDisplaysAuto);
            Controls.Add(chkRadios);
            Controls.Add(chkSmartWeapons);
            Controls.Add(chkMisc);
            Controls.Add(chkDisplays);
            Controls.Add(chkRouteC);
            Controls.Add(chkRouteB);
            Controls.Add(chkRouteA);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "UploadPage";
            Size = new Size(636, 554);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox chkRouteA;
        private ToolTip toolTip1;
        private CheckBox chkDisplays;
        private CheckBox chkMisc;
        private RadioButton radDisplaysAuto;
        private RadioButton radDisplaysPilotAndWSO;
        private CheckBox chkRadios;
        private CheckBox chkSmartWeapons;
        private CheckBox chkRouteB;
        private CheckBox chkRouteC;
    }
}
