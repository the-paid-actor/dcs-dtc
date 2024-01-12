
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.FA18.Systems.Controls
{
    partial class SteerPointEditControl
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
            dtcDropDown1 = new DTCDropDown();
            cbEnable = new DTCCheckBox();
            txtCoord = new DTCCoordinateTextBox2();
            domainUpDown1 = new DomainUpDown();
            txtAlt = new DTCTextBox();
            SuspendLayout();
            // 
            // dtcDropDown1
            // 
            dtcDropDown1.DropDownStyle = ComboBoxStyle.DropDownList;
            dtcDropDown1.FlatStyle = FlatStyle.Flat;
            dtcDropDown1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtcDropDown1.FormattingEnabled = true;
            dtcDropDown1.Items.AddRange(new object[] { "Lat/Lon/Elev", "Waypoint" });
            dtcDropDown1.Location = new Point(24, 3);
            dtcDropDown1.Name = "dtcDropDown1";
            dtcDropDown1.Size = new Size(121, 24);
            dtcDropDown1.TabIndex = 2;
            dtcDropDown1.SelectedIndexChanged += dtcDropDown1_SelectedIndexChanged;
            // 
            // cbEnable
            // 
            cbEnable.AutoSize = true;
            cbEnable.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbEnable.Location = new Point(3, 8);
            cbEnable.Name = "cbEnable";
            cbEnable.Size = new Size(15, 14);
            cbEnable.TabIndex = 1;
            cbEnable.UseVisualStyleBackColor = true;
            // 
            // txtCoord
            // 
            txtCoord.BackColor = SystemColors.Window;
            txtCoord.ButtonVisible = true;
            txtCoord.Coordinate = null;
            txtCoord.CoordinateConverterParent = null;
            txtCoord.Format = Utilities.CoordinateFormat.DegreesMinutesSecondsHundredths;
            txtCoord.Location = new Point(151, 3);
            txtCoord.Name = "txtCoord";
            txtCoord.Size = new Size(224, 28);
            txtCoord.TabIndex = 3;
            // 
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(151, 6);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.ReadOnly = true;
            domainUpDown1.Size = new Size(224, 23);
            domainUpDown1.TabIndex = 3;
            domainUpDown1.Text = "domainUpDown1";
            // 
            // txtAlt
            // 
            txtAlt.AllowPromptAsInput = true;
            txtAlt.BackColor = SystemColors.Window;
            txtAlt.HidePromptOnLeave = false;
            txtAlt.InsertKeyMode = InsertKeyMode.Default;
            txtAlt.Location = new Point(381, 3);
            txtAlt.Mask = ">00000";
            txtAlt.Name = "txtAlt";
            txtAlt.PromptChar = '_';
            txtAlt.Size = new Size(66, 28);
            txtAlt.TabIndex = 4;
            txtAlt.ValidatingType = null;
            // 
            // SteerPointEditControl
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(txtAlt);
            Controls.Add(domainUpDown1);
            Controls.Add(txtCoord);
            Controls.Add(cbEnable);
            Controls.Add(dtcDropDown1);
            Name = "SteerPointEditControl";
            Size = new Size(551, 34);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DTCDropDown dtcDropDown1;
        private DTCCheckBox cbEnable;
        private DTCCoordinateTextBox2 txtCoord;
        private DomainUpDown domainUpDown1;
        private DTCTextBox txtAlt;
    }
}
