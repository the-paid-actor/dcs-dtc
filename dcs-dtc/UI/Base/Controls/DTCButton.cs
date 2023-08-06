using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
	public class DTCButton : Button
	{
		public DTCButton()
		{
			this.BackColor = Color.DarkKhaki;
			this.Font = new Font("Microsoft Sans Serif", 10);
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Olive;
			this.FlatAppearance.MouseOverBackColor = Color.FromArgb(158, 153, 89);
            this.Size = new Size(150, 40);
		}

		public static DTCButton Make(string label, int x, int y, int width, int height)
		{
			var btn = new DTCButton();
			btn.Text = label;
			btn.Left = x;
			btn.Top = y;
			btn.Width = width;
			btn.Height = height;
			return btn;
		}
	}
}
