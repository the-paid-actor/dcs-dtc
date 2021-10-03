using DTC.Models.F16;
using DTC.UI.Base;
using System.Windows.Forms;

namespace DTC.UI
{
	public partial class MainForm : Form
	{
		private F16Configuration _cfg;
		private Pages _pages;

		public MainForm()
		{
			InitializeComponent();

			_cfg = F16Configuration.FromAutoSaveFile();
			if (_cfg == null)
			{
				_cfg = new F16Configuration();
			}

			_pages = new Pages(_cfg, pnlMain);
		}

		private void pnlBackground_MouseDown(object sender, MouseEventArgs e)
		{
			Draggable.Drag(Handle, e);
		}

		private void btnLoadSave_Click(object sender, System.EventArgs e)
		{
			_pages.SetPage(_pages.LoadSavePage);
		}

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			_pages.SetPage(_pages.UploadPage);
		}

		private void btnWaypoints_Click(object sender, System.EventArgs e)
		{
			_pages.SetPage(_pages.WaypointsPage);
		}

		private void btnCMS_Click(object sender, System.EventArgs e)
		{
			_pages.SetPage(_pages.CMSPage);
		}

		private void btnRadios_Click(object sender, System.EventArgs e)
		{
			_pages.SetPage(_pages.RadiosPage);
		}

		private void btnMFDs_Click(object sender, System.EventArgs e)
		{
			_pages.SetPage(_pages.MFDPage);
		}

		public void ToggleEnabled()
		{
			pnlLeft.Enabled = !pnlLeft.Enabled;
		}

		private void lblPin_Click(object sender, System.EventArgs e)
		{
			this.TopMost = !this.TopMost;
		}

		private void lblClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}