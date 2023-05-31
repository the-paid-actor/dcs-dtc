using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
    public partial class DTCCheckBox : CheckBox
    {
        public delegate void CheckBoxChangedCallback(DTCCheckBox chk);

        public static DTCCheckBox Make(int x, int y, int chkWidth, int height, bool initialValue, CheckBoxChangedCallback callback)
        {
            var chk = new DTCCheckBox();
            chk.Location = new Point(x, y);
            chk.AutoSize = false;
            chk.Size = new Size(chkWidth, height);
            chk.Checked = initialValue;
            chk.CheckedChanged += (sender, args) =>
            {
                callback(chk);
            };
            return chk;
        }

        public DTCCheckBox()
        {
            InitializeComponent();
        }
    }
}