using DTC.Utilities;
using DTC.Models.F15E;
using DTC.UI.CommonPages;
using System;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F15E
{
    public partial class LoadSavePage : AircraftSettingPage
    {
        private F15EConfiguration _mainConfig;
        private F15EConfiguration _configToLoad;

        public delegate void RefreshCallback();

        public LoadSavePage(AircraftPage parent, F15EConfiguration cfg) : base(parent)
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
                _configToLoad = F15EConfiguration.FromCompressedString(txt);
            }
            else if (optFile.Checked)
            {
                openFileDlg.ShowHelp = true;
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    var file = FileStorage.LoadFile(openFileDlg.FileName);
                    _configToLoad = F15EConfiguration.FromJson(file);
                }
            }
            else
            {
                openFileDlg.Filter = "CombatFlite files (*.cf)|*.cf";
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    string file = FileStorage.LoadCombatFlite(openFileDlg.FileName);

                    var selector = new CombatFliteFlightSelector(file);
                    if (selector.ShowDialog() == DialogResult.OK)
                    {
                        _configToLoad = F15EConfiguration.FromCombatFlite(file, selector.SelectedItem);
                    }
                }
                openFileDlg.Filter = string.Empty;
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
                if (_configToLoad.Displays != null)
                {
                    chkLoadDisplays.Enabled = true;
                    enableLoad = true;
                }
                if (_configToLoad.Radios != null)
                {
                    chkLoadRadios.Enabled = true;
                    enableLoad = true;
                }
                if (_configToLoad.Misc != null)
                {
                    chkLoadMisc.Enabled = true;
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

            if (!chkLoadDisplays.Checked)
            {
                cfg.Displays = null;
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
            if (!chkSaveDisplays.Checked)
            {
                cfg.Displays = null;
            }
            if (!chkSaveRadios.Checked)
            {
                cfg.Radios = null;
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
            chkLoadDisplays.Enabled = false;
            chkLoadRadios.Enabled = false;
            chkLoadMisc.Enabled = false;
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

        private void optCombatFlite_CheckedChanged(object sender, EventArgs e)
        {
            _configToLoad = null;
            grpLoad.Text = "Load from CombatFlite";
            grpLoad.Visible = true;
            grpSave.Visible = false;
            DisableLoadControls();
        }

        private void grpSave_Enter(object sender, EventArgs e)
        {

        }
    }
}
