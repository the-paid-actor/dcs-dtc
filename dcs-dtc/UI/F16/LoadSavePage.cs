using DTC.Models;
using DTC.Models.Base;
using DTC.Models.F16;
using DTC.UI.Base.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.F16
{
	public partial class LoadSavePage : UserControl
	{
		private class LoadSave
		{
			public static void Load(
				F16Configuration cfg,
				CheckBox chkWaypoints,
				CheckBox chkCMS,
				CheckBox chkRadios,
				CheckBox chkMFDs,
				DTCButton btnApply
				)
			{
				var enableLoad = false;

				chkWaypoints.Enabled = enableLoad;
				chkCMS.Enabled = enableLoad;
				chkRadios.Enabled = enableLoad;
				chkMFDs.Enabled = enableLoad;
				btnApply.Enabled = enableLoad;

				if (cfg != null)
				{
					if (cfg.Waypoints != null)
					{
						chkWaypoints.Enabled = true;
						enableLoad = true;
					}
					if (cfg.CMS != null)
					{
						chkCMS.Enabled = true;
						enableLoad = true;
					}
					if (cfg.Radios != null)
					{
						chkRadios.Enabled = true;
						enableLoad = true;
					}
					if (cfg.MFD != null)
					{
						chkMFDs.Enabled = true;
						enableLoad = true;
					}

					if (enableLoad == true)
					{
						btnApply.Enabled = true;
					}
				}
			}
		}

		private F16Configuration _mainConfig;
		private readonly RefreshCallback _refreshCallback;
		private F16Configuration _configFromClip;
		private F16Configuration _configFromFile;

		public delegate void RefreshCallback();

		public LoadSavePage(F16Configuration cfg, RefreshCallback callback)
		{
			_mainConfig = cfg;
			this._refreshCallback = callback;
			InitializeComponent();
		}

		private void btnFile_Click(object sender, EventArgs e)
		{
			pnlFile.Dock = DockStyle.Fill;
			pnlFile.Visible = true;
			pnlClipboard.Visible = false;
			btnClipboard.Font = new Font(btnFile.Font, FontStyle.Regular);
			btnFile.Font = new Font(btnFile.Font, FontStyle.Bold);
		}

		private void btnClipboard_Click(object sender, EventArgs e)
		{
			pnlClipboard.Dock = DockStyle.Fill;
			pnlClipboard.Visible = true;
			pnlFile.Visible = false;
			btnFile.Font = new Font(btnFile.Font, FontStyle.Regular);
			btnClipboard.Font = new Font(btnClipboard.Font, FontStyle.Bold);
		}

		private void btnClipboardLoad_Click(object sender, EventArgs e)
		{
			var txt = Clipboard.GetText();
			_configFromClip = F16Configuration.FromCompressedString(txt);

			LoadSave.Load(
				_configFromClip,
				chkClipLoadWaypoints,
				chkClipLoadCMS,
				chkClipLoadRadios,
				chkClipLoadMFDs,
				btnClipboardApply);
		}

		private void btnClipboardApply_Click(object sender, EventArgs e)
		{
			_mainConfig.CopyConfiguration(_configFromClip);
			_configFromClip = null;

			chkClipLoadWaypoints.Enabled = chkClipLoadWaypoints.Checked = false;
			chkClipLoadCMS.Enabled = chkClipLoadCMS.Checked = false;
			chkClipLoadRadios.Enabled = chkClipLoadRadios.Checked = false;
			chkClipLoadMFDs.Enabled = chkClipLoadMFDs.Checked = false;
			btnClipboardApply.Enabled = false;

			_refreshCallback();
		}

		private void btnClipboardSave_Click(object sender, EventArgs e)
		{
			var cfg = _mainConfig.Clone();

			if (!chkClipSaveWaypoints.Checked)
			{
				cfg.Waypoints = null;
			}
			if (!chkClipSaveCMS.Checked)
			{
				cfg.CMS = null;
			}
			if (!chkClipSaveRadios.Checked)
			{
				cfg.Radios = null;
			}
			if (!chkClipSaveMFDs.Checked)
			{
				cfg.MFD = null;
			}

			Clipboard.SetText(cfg.ToCompressedString());
		}

		private void btnFileLoad_Click(object sender, EventArgs e)
		{
			ResetFileControls();

			if (openFileDlg.ShowDialog() == DialogResult.OK)
			{
				var file = FileStorage.LoadFile(openFileDlg.FileName);
				_configFromFile = F16Configuration.FromJson(file);

				LoadSave.Load(
					_configFromFile,
					chkFileLoadWaypoints,
					chkFileLoadCMS,
					chkFileLoadRadios,
					chkFileLoadMFDs,
					btnFileApply);
			}
		}

		private void btnFileApply_Click(object sender, EventArgs e)
		{
			_mainConfig.CopyConfiguration(_configFromFile);
			ResetFileControls();
			_refreshCallback();
		}

		private void ResetFileControls()
		{
			_configFromFile = null;

			chkFileLoadWaypoints.Enabled = chkFileLoadWaypoints.Checked = false;
			chkFileLoadCMS.Enabled = chkFileLoadCMS.Checked = false;
			chkFileLoadRadios.Enabled = chkFileLoadRadios.Checked = false;
			chkFileLoadMFDs.Enabled = chkFileLoadMFDs.Checked = false;
			btnFileApply.Enabled = false;
		}

		private void btnFileSave_Click(object sender, EventArgs e)
		{
			if (saveFileDlg.ShowDialog() == DialogResult.OK)
			{
				var cfg = _mainConfig.Clone();

				if (!chkFileSaveWaypoints.Checked)
				{
					cfg.Waypoints = null;
				}
				if (!chkFileSaveCMS.Checked)
				{
					cfg.CMS = null;
				}
				if (!chkFileSaveRadios.Checked)
				{
					cfg.Radios = null;
				}
				if (!chkFileSaveMFDs.Checked)
				{
					cfg.MFD = null;
				}

				FileStorage.Save(_mainConfig, saveFileDlg.FileName);
			}
		}
	}
}
