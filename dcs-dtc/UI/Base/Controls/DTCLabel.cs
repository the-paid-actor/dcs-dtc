using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
	class DTCLabel : Label
	{
		public static DTCLabel MakeVerticalCentered(string label, int x, int y, int width, int height)
		{
			var lbl = Make(label, x, y, width, height);
			lbl.TextAlign = ContentAlignment.MiddleCenter;
			return lbl;
		}

		public static DTCLabel Make(string label, int x, int y, int width, int height)
		{
			var lbl = Make(label);
			lbl.Location = new Point(x, y);
			lbl.AutoSize = false;
			lbl.Size = new Size(width, height);
            return lbl;
		}

		public static DTCLabel Make(string label, int x, int y)
		{
			var lbl = Make(label);
			lbl.Location = new Point(x, y);
			return lbl;
		}

		public static DTCLabel Make(string label)
		{
			var lbl = new DTCLabel();
			lbl.TextAlign = ContentAlignment.MiddleLeft;
			lbl.Text = label;
			return lbl;
		}

		public DTCLabel()
		{
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			this.AutoSize = true;
		}
	}
}
