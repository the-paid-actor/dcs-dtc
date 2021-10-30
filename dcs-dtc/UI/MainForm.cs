using DTC.UI.Base;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DTC.UI
{
	public partial class MainForm : Form
	{
		private MainPage _mainPage = new MainPage();

		private Stack<Page> _pages = new Stack<Page>();

		public MainForm()
		{
			InitializeComponent();

			ResetToPage(_mainPage);
		}

		private void SetPage(Page page)
		{
			pnlPages.Controls.Add(page);
			page.Dock = DockStyle.Fill;
			page.Visible = true;
			page.BringToFront();
		}

		private void ResetToPage(Page page)
		{
			pnlPages.Controls.Clear();

			SetPage(page);

			_pages.Clear();
			_pages.Push(page);

			breadCrumbs.SetCrumbs(new DTCBreadCrumb.Crumb(page.PageTitle, () => { ResetToPage(page); }));
		}

		public void AddPage(Page page)
		{
			SetPage(page);

			_pages.Push(page);

			breadCrumbs.AddCrumb(new DTCBreadCrumb.Crumb(page.PageTitle, () => { PopUntilPage(page); }));
		}

		private void PopUntilPage(Page page)
		{
			while (_pages.Peek() != page)
			{
				var p = _pages.Pop();
				pnlPages.Controls.Remove(p);
				breadCrumbs.PopCrumb();
			}

			SetPage(page);
		}

		private void pnlBackground_MouseDown(object sender, MouseEventArgs e)
		{
			Draggable.Drag(Handle, e);
		}

		public void ToggleEnabled()
		{
			//_planeForm.ToggleEnabled();
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