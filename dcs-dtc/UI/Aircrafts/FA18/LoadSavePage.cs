using DTC.Utilities;
using DTC.Models.FA18;
using DTC.UI.CommonPages;
using System;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
	public partial class LoadSavePage : AircraftSettingPage
	{
		private FA18Configuration _mainConfig;
		private FA18Configuration _configToLoad;

		public delegate void RefreshCallback();

		public LoadSavePage(AircraftPage parent, FA18Configuration cfg) : base(parent)
		{
			_mainConfig = cfg;
			InitializeComponent();
		}

		public override string GetPageTitle()
		{
			return "Load / Save";
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			if (optClipboard.Checked)
			{
				var txt = Clipboard.GetText();
				_configToLoad = FA18Configuration.FromCompressedString(txt);
			}
			else
			{
				openFileDlg.ShowHelp = true;
				if (openFileDlg.ShowDialog() == DialogResult.OK)
				{
					var file = FileStorage.LoadFile(openFileDlg.FileName);
					_configToLoad = FA18Configuration.FromJson(file);
				}
			}

			DisableLoadControls();

			var enableLoad = false;

			if (_configToLoad != null)
			{
				if (_configToLoad.Waypoints != null)
				{
					chkLoadWaypoints.Enabled = true;
					enableLoad = true;
				}
				if (_configToLoad.Radios != null)
				{
					chkLoadRadios.Enabled = true;
					enableLoad = true;
				}
				if (_configToLoad.CMS != null)
				{
					chkLoadCMS.Enabled = true;
					enableLoad = true;
				}
				if (_configToLoad.Misc != null)
				{
					chkLoadMisc.Enabled = true;
					enableLoad = true;
				}
				if (_configToLoad.PrePlanned != null)
				{
					chkLoadPP.Enabled = true;
					enableLoad = true;
				}
				if (_configToLoad.Sequences != null)
				{
					chkLoadSeq.Enabled = true;
					enableLoad = true;
				}

				if (enableLoad == true)
				{
					btnLoadApply.Enabled = true;
				}
			}
		}

		private void btnLoadApply_Click(object sender, EventArgs e)
		{
			var load = false;

			var cfg = _configToLoad.Clone();

			if (!chkLoadWaypoints.Checked)
			{
				cfg.Waypoints = null;
			}
			else
			{
				load = true;
			}

			if (!chkLoadRadios.Checked)
			{
				cfg.Radios = null;
			}
			else
			{
				load = true;
			}

			if (!chkLoadMisc.Checked)
			{
				cfg.Misc = null;
			}
			else
			{
				load = true;
			}
			if (!chkLoadCMS.Checked)
			{
				cfg.CMS = null;
			}
			else
			{
				load = true;
			}
			if (!chkLoadPP.Checked)
			{
				cfg.PrePlanned = null;
			}
			else
			{
				load = true;
			}
			if (!chkLoadSeq.Checked)
			{
				cfg.Sequences = null;
			}
			else
			{
				load = true;
			}

			if (load)
			{
				_mainConfig.CopyConfiguration(cfg);
				_parent.RefreshPages();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var cfg = _mainConfig.Clone();

			if (!chkSaveWaypoints.Checked)
			{
				cfg.Waypoints = null;
			}
			if (!chkSaveRadios.Checked)
			{
				cfg.Radios = null;
			}
			if (!chkSaveCMS.Checked)
			{
				cfg.CMS = null;
			}
			if (!chkSavePP.Checked)
			{
				cfg.PrePlanned = null;
			}
			if (!chkSaveSeq.Checked)
			{
				cfg.Sequences = null;
			}
			if (!chkSaveMisc.Checked)
			{
				cfg.Misc = null;
			}

			if (optClipboard.Checked)
			{
				Clipboard.SetText(cfg.ToCompressedString());
			}
			else
			{
				if (saveFileDlg.ShowDialog() == DialogResult.OK)
				{
					FileStorage.Save(cfg, saveFileDlg.FileName);
				}
			}
		}

		private void DisableLoadControls()
		{
			chkLoadWaypoints.Enabled = false;
			chkLoadRadios.Enabled = false;
			chkLoadCMS.Enabled = false;
			chkLoadMisc.Enabled = false;
			chkLoadPP.Enabled = false;
			chkLoadSeq.Enabled = false;
			btnLoadApply.Enabled = false;
		}

		private void optFile_CheckedChanged(object sender, EventArgs e)
		{
			_configToLoad = null;
			grpLoad.Text = "Load from File";
			grpSave.Text = "Save to File";
			grpLoad.Visible = true;
			grpSave.Visible = true;
			DisableLoadControls();
		}

		private void optClipboard_CheckedChanged(object sender, EventArgs e)
		{
			_configToLoad = null;
			grpLoad.Text = "Load from Clipboard";
			grpSave.Text = "Save to Clipboard";
			grpLoad.Visible = true;
			grpSave.Visible = true;
			DisableLoadControls();
		}

        private void chkSaveSeq_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
