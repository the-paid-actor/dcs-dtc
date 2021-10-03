using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Base
{
	public partial class WaypointCaptureCrosshair : Form
	{
		public WaypointCaptureCrosshair()
		{
			InitializeComponent();

			ClientSize = new Size(100, 100);
			TopMost = true;
			ShowInTaskbar = false;
			var screenSize = Screen.FromControl(this).Bounds;
			Left = (screenSize.Width / 2) - (Width / 2);
			Top = (screenSize.Height / 2) - (Height / 2);
		}
	}
}
