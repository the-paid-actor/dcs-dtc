using DTC.Utilities;
using DTC.Models.AH64;
using DTC.UI.CommonPages;
using System;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.AH64
{
    public partial class LoadSavePage : AircraftSettingPage
    {
        private AH64Configuration _mainConfig;
        private AH64Configuration _configToLoad;

        public delegate void RefreshCallback();

        public LoadSavePage(AircraftPage parent, AH64Configuration cfg) : base(parent)
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
                _configToLoad = AH64Configuration.FromCompressedString(txt);
            }
            if (optFile.Checked)
            {
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    var file = FileStorage.LoadFile(openFileDlg.FileName);
                    _configToLoad = AH64Configuration.FromJson(file);
                }
            }
            if (optXML.Checked)
            {
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    var file = FileStorage.LoadFile(openFileDlg.FileName);
                    _configToLoad = AH64Configuration.FromCombatFliteXML(_mainConfig, file);
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

        private void optXML_CheckedChanged(object sender, EventArgs e)
        {
            _configToLoad = null;
            grpLoad.Text = "Load from Combatflite XML";
            grpLoad.Visible = true;
            grpSave.Visible = false;
            DisableLoadControls();
        }
    }
}
