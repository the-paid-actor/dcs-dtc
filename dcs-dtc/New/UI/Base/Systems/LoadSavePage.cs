using DTC.New.Presets.V2.Base;
using DTC.New.UI.Base.Pages;
using DTC.UI.Base.Controls;
using DTC.Utilities;

namespace DTC.New.UI.Base.Systems
{
    public partial class LoadSavePage : AircraftSystemPage
    {
        private Type configurationType;
        private Configuration mainConfig;
        private List<ConfigurationSystem> systems;
        private Configuration? configToLoad;

        public delegate void RefreshCallback();

        public LoadSavePage(AircraftPage parent) : base(parent)
        {
            InitializeComponent();

            configurationType = parent.Aircraft.GetAircraftConfigurationType();
            mainConfig = parent.Configuration;
            systems = mainConfig.GetSystems();

            BuildCheckboxes();

            optClipboard.Checked = true;
        }

        public override string GetPageTitle()
        {
            return "Load / Save";
        }

        private void BuildCheckboxes()
        {
            var top = 0;
            foreach (var system in systems)
            {
                if (system.IgnoreForLoadSave) continue;

                var cbLoad = new DTCCheckBox();
                cbLoad.Text = system.SystemName;
                cbLoad.Tag = system;
                cbLoad.Enabled = false;
                cbLoad.Top = top;
                cbLoad.Width = 140;
                pnlLoadCheckboxes.Controls.Add(cbLoad);

                var cbSave = new DTCCheckBox();
                cbSave.Text = system.SystemName;
                cbSave.Tag = system;
                cbSave.Checked = false;
                cbSave.Top = top;
                cbSave.Width = 140;
                pnlSaveCheckboxes.Controls.Add(cbSave);

                top += cbSave.Height;
            }
        }

        private void DisableLoadCheckboxes()
        {
            configToLoad = null;
            btnLoadApply.Enabled = false;

            foreach (var ctl in pnlLoadCheckboxes.Controls)
            {
                if (ctl is DTCCheckBox)
                {
                    var cb = (DTCCheckBox)ctl;
                    cb.Enabled = false;
                    cb.Checked = false;
                }
            }
        }

        private void optFile_CheckedChanged(object sender, EventArgs e)
        {
            btnLoad.Text = "Load from File";
            lblSave.Text = "Save to File";
            DisableLoadCheckboxes();
        }

        private void optClipboard_CheckedChanged(object sender, EventArgs e)
        {
            btnLoad.Text = "Load from Clipboard";
            lblSave.Text = "Save to Clipboard";
            DisableLoadCheckboxes();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DisableLoadCheckboxes();

            if (optClipboard.Checked)
            {
                var txt = Clipboard.GetText();
                configToLoad = Configuration.FromCompressedString(txt, configurationType);
            }
            else
            {
                openFileDlg.ShowHelp = true;
                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    var file = FileStorage.LoadFile(openFileDlg.FileName);
                    configToLoad = Configuration.FromJson(file, configurationType);
                }
            }

            if (configToLoad == null)
            {
                return;
            }

            var enableLoad = false;

            foreach (var system in systems)
            {
                if (configToLoad.IsSystemNull(system))
                {
                    continue;
                }

                foreach (var ctl in pnlLoadCheckboxes.Controls)
                {
                    if (ctl is DTCCheckBox)
                    {
                        var cb = (DTCCheckBox)ctl;
                        if (cb.Tag == system)
                        {
                            cb.Enabled = true;
                            cb.Checked = true;
                            enableLoad = true;
                        }
                    }
                }
            }

            if (enableLoad == true)
            {
                btnLoadApply.Enabled = true;
            }
        }

        private void btnLoadApply_Click(object sender, EventArgs e)
        {
            if (configToLoad is null)
            {
                return;
            }

            foreach (var ctl in pnlLoadCheckboxes.Controls)
            {
                if (ctl is DTCCheckBox)
                {
                    var cb = (DTCCheckBox)ctl;
                    if (cb.Checked)
                    {
                        var system = (ConfigurationSystem)cb.Tag;
                        mainConfig.CopySystemFrom(system, configToLoad);
                    }
                }
            }

            parent.RefreshPages();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var clone = mainConfig.Clone();

            foreach (var ctl in pnlSaveCheckboxes.Controls)
            {
                if (ctl is DTCCheckBox)
                {
                    var cb = (DTCCheckBox)ctl;
                    if (!cb.Checked)
                    {
                        var system = (ConfigurationSystem)cb.Tag;
                        clone.ClearSystem(system);
                    }
                }
            }

            if (optClipboard.Checked)
            {
                Clipboard.SetText(clone.ToCompressedString());
            }
            else
            {
                if (saveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    FileStorage.Save(clone, saveFileDlg.FileName);
                }
            }
        }
    }
}
