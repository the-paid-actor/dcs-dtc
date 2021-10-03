using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
	public class DTCButton : Button
	{
		public DTCButton()
		{
			this.BackColor = Color.DarkKhaki;
			this.Font = new Font("Microsoft Sans Serif", 12);
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
			this.Size = new Size(150, 40);
		}
	}
}
