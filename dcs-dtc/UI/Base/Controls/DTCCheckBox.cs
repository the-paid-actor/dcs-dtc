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

        public static DTCCheckBox Make(DTCCheckBox chk, int x, int y,int chkWidth, int height)
        {
            chk.Location = new Point(x, y);
            chk.AutoSize = false;
            chk.Size = new Size(chkWidth, height);
            return chk;
        }
    }
}
