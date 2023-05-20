using System;
using DTC.Models.Base;
using DTC.UI.Base;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System.Collections.Generic;
using System.Windows.Forms;
using DTC.Models.AH64;
using DTC.Models.F16;
using DTC.Models.FA18;
using DTC.Models.Presets;

namespace DTC.UI
{
	public partial class MainForm : Form
	{
		private MainPage _mainPage = new MainPage();

		private Stack<Page> _pages = new Stack<Page>();
		
		public MainForm()
		{
			if (Settings.HTTPServerEnabled)
			{
				Console.WriteLine("Starting HTTP-Server");
				HttpConfigListener.Instance.Start(this);
			}
			
			InitializeComponent();

			ResetToPage(_mainPage);
			this.TopMost = Settings.AlwaysOnTop;
		}

		public void ResetToMainPage()
		{
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
				p.Dispose();
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
			Settings.AlwaysOnTop = this.TopMost;
		}

		private void lblClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void lblMinimize_Click(object sender, System.EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		public void loadSettingsFromWeb(string airplane, string data)
		{
			PresetsPage loadedPresetsPage = null;
			string aplower = airplane.ToLower().TrimStart('/');
			switch (aplower)
			{
				case "f16":
					ResetToMainPage();
					loadedPresetsPage = new PresetsPage(PresetsStore.GetAircraft(AircraftModel.F16C));
					AddPage(loadedPresetsPage);
					break;
				case "fa18":
					ResetToMainPage();
					loadedPresetsPage = new PresetsPage(PresetsStore.GetAircraft(AircraftModel.FA18C));
					AddPage(loadedPresetsPage);
					break;
				case "ah64":
					ResetToMainPage();
					loadedPresetsPage = new PresetsPage(PresetsStore.GetAircraft(AircraftModel.AH64D));
					AddPage(loadedPresetsPage);
					break;
			}

			if (loadedPresetsPage == null) return;
			Preset preset = null;
			AircraftPage acPage = null;
			if (loadedPresetsPage._aircraft.Presets.Count == 0)
			{
				//If no Presets exist, we create one empty.
				preset = loadedPresetsPage._aircraft.CreatePreset("webloaded");
				acPage = loadedPresetsPage.ShowPreset(preset);
				loadedPresetsPage.RefreshList();
			}
			else
			{
				//Otherwise we load the first one **or** even better: the one with the name "default"
				preset = loadedPresetsPage._aircraft.Presets[0];
				foreach (Preset p in loadedPresetsPage._aircraft.Presets)
				{
					if (p.Name.ToLower().Equals("default")) preset = p;
				}

				acPage = loadedPresetsPage.ShowPreset(preset);
			}

			if (loadedPresetsPage._aircraft.Model == AircraftModel.F16C)
			{
				var configToLoad = F16Configuration.FromCompressedString(data).Clone();
				configToLoad.Misc = null;
				configToLoad.MFD = null;
				configToLoad.Radios = null;
				configToLoad.HTS = null;
				configToLoad.CMS = null;
				configToLoad.HARM = null;
				((DTC.UI.Aircrafts.F16.LoadSavePage)acPage.loadSavePage)._mainConfig.CopyConfiguration(configToLoad);
				acPage.RefreshPages();
			} else if (loadedPresetsPage._aircraft.Model == AircraftModel.FA18C)
			{
				var configToLoad = FA18Configuration.FromCompressedString(data).Clone();
				configToLoad.Radios = null;
				configToLoad.CMS = null;
				configToLoad.Misc = null;
				configToLoad.PrePlanned = null;
				configToLoad.Sequences = null;
				((DTC.UI.Aircrafts.FA18.LoadSavePage)acPage.loadSavePage)._mainConfig.CopyConfiguration(configToLoad);
				acPage.RefreshPages();
			} else if (loadedPresetsPage._aircraft.Model == AircraftModel.AH64D)
			{
				var configToLoad = AH64Configuration.FromCompressedString(data).Clone();
				configToLoad.Radios = null;
				((DTC.UI.Aircrafts.AH64.LoadSavePage)acPage.loadSavePage)._mainConfig.CopyConfiguration(configToLoad);
				acPage.RefreshPages();
			}
		}
	}
}