using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
	public class DTCDropDown : ComboBox
	{
		public static DTCDropDown Make(int x, int y)
		{
			var cbo = new DTCDropDown();
			cbo.Location = new Point(x, y);
			return cbo;
		}

		public static DTCDropDown Make(int x, int y, int width)
		{
			var cbo = Make(x, y);
			cbo.Width = width;
			return cbo;
		}

		public DTCDropDown()
		{
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FlatStyle = FlatStyle.Flat;
		}
	}
}
