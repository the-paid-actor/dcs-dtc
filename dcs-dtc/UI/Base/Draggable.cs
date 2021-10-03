using System;
using System.Windows.Forms;

namespace DTC.UI.Base
{
	class Draggable
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public static void Drag(IntPtr handle, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
	}
}
