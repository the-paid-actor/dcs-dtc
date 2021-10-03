using DTC.Models.Base;
using DTC.Models.F16;
using DTC.UI.F16;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTC.UI
{
	class Pages
	{
		public LoadSavePage LoadSavePage;
		public WaypointsPage WaypointsPage;
		public RadioPage RadiosPage;
		public CMSPage CMSPage;
		public MFDPage MFDPage;
		public UploadToJetPage UploadPage;

		private Control[] Controls;
		private readonly F16Configuration cfg;
		private readonly Panel pnl;

		public Pages(F16Configuration cfg, Panel pnl)
		{
			LoadSavePage = new LoadSavePage(cfg, RefreshAfterLoad);
			this.cfg = cfg;
			this.pnl = pnl;

			Reload();
		}

		private void RefreshAfterLoad()
		{
			Reload();
		}

		private void DataChanged()
		{
			FileStorage.PersistAutoSaveFile(cfg);
		}

		private void Reload()
		{
			pnl.Controls.Clear();

			if (UploadPage != null)
			{
				UploadPage.Dispose();
			}
			if (WaypointsPage != null)
			{
				WaypointsPage.Dispose();
			}
			if (RadiosPage != null)
			{
				RadiosPage.Dispose();
			}
			if (CMSPage != null)
			{
				CMSPage.Dispose();
			}
			if (MFDPage != null)
			{
				MFDPage.Dispose();
			}

			WaypointsPage = new WaypointsPage(cfg.Waypoints, this.DataChanged);
			UploadPage = new UploadToJetPage(cfg);
			RadiosPage = new RadioPage(cfg.Radios, this.DataChanged);
			CMSPage = new CMSPage(cfg.CMS, this.DataChanged);
			MFDPage = new MFDPage(cfg.MFD, this.DataChanged);

			Controls = new Control[]
			{
				LoadSavePage,
				UploadPage,
				WaypointsPage,
				RadiosPage,
				CMSPage,
				MFDPage
			};

			foreach (var ctl in Controls)
			{
				pnl.Controls.Add(ctl);
				ctl.Location = new Point(0, 0);
				ctl.Size = pnl.Size;
				ctl.Visible = false;
			}
		}

		public void SetPage(Control page)
		{
			foreach (var ctl in Controls)
			{
				ctl.Visible = false;
			}
			page.Visible = true;
		}
	}
}
