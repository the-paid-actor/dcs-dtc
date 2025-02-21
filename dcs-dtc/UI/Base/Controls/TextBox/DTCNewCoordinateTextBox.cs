using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTC.UI.Base.Controls.TextBox
{
    internal class DTCNewCoordinateTextBox : DTCNewTextBox
    {
        private Label label;

        protected override int GetLabelWidth()
        {
            return 20;
        }

        protected override Label GetLabel()
        {
            if (label == null)
            {
                this.label = new Label();
                this.label.Text = "...";
                this.label.Click += (sender, args) =>
                {
                    this.Focus();
                };
            }
            return label;
        }
    }
}
