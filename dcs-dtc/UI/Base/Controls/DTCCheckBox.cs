using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
    public partial class DTCCheckBox : CheckBox
    {
        public string RelatedTo { get; set; }
        public DTCCheckBox()
        {
            InitializeComponent();
        }

        public static DTCCheckBox Make(DTCCheckBox cbx, int x, int y,int cbxWidth, int height)
        {
            cbx.Location = new Point(x, y);
            cbx.AutoSize = false;
            cbx.Size = new Size(cbxWidth, height);
            return cbx;
        }
    }
}
