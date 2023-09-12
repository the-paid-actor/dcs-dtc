using DTC.Utilities;
using DTC.Models.Presets;
using System;
using System.Windows.Forms;

namespace DTC.UI.CommonPages
{
	public partial class PresetsPage : Page
	{
		private readonly Aircraft _aircraft;

		public override string PageTitle {
			get
			{
				return _aircraft.Name + " Presets";
			}
		}

		public PresetsPage(Aircraft aircraft)
		{
			InitializeComponent();
			_aircraft = aircraft;
			dgPresets.RefreshList(_aircraft.Presets);
			RefreshButtons();
		}

		private void dgPresets_SelectionChanged(object sender, System.EventArgs e)
		{
			RefreshButtons();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			AddRenamePreset(null);
		}

		private void btnRename_Click(object sender, System.EventArgs e)
		{
			if (dgPresets.SelectedRows.Count > 0)
			{
				AddRenamePreset((Preset)dgPresets.SelectedRows[0].DataBoundItem);
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if (dgPresets.SelectedRows.Count > 0)
			{
				ShowPreset((Preset)dgPresets.SelectedRows[0].DataBoundItem);
			}
		}

		private void ShowPreset(Preset preset)
		{
			var acPage = AircraftPageFactory.Make(_aircraft, preset);
			MainForm.AddPage(acPage);
		}

		private void RefreshButtons()
		{
			var selected = dgPresets.SelectedRows.Count > 0;

			btnEdit.Enabled = selected;
			btnRename.Enabled = selected;
			btnClone.Enabled = selected;
			btnUpload.Enabled = selected;
			btnDelete.Enabled = selected;
		}

		private void AddRenamePreset(IPreset preset, Action callback = null)
		{
			var dialog = new PresetName();
			this.Controls.Add(dialog);
			dialog.Left = (this.Width / 2) - (dialog.Width / 2);
			dialog.Top = (this.Height / 2) - (dialog.Height / 2);
			dialog.txtName.Focus();
			dialog.BringToFront();

			string oldName = null;

			if (preset != null)
			{
				oldName = preset.Name;
				dialog.txtName.Text = preset.Name;
			}

			pnlContent.Enabled = false;

			dialog.DialogResultCallback = (DialogResult result) =>
			{
				if (result == DialogResult.OK)
				{
					if (preset == null)
					{
						var newPreset = _aircraft.CreatePreset(dialog.txtName.Text);
						ShowPreset(newPreset);
					}
					else
					{
						preset.Name = dialog.txtName.Text;
						if (preset.Name != oldName)
						{
							FileStorage.RenamePresetFile(_aircraft, preset, oldName);
						}
					}
				}
				this.Controls.Remove(dialog);
				pnlContent.Enabled = true;
				dgPresets.RefreshList(_aircraft.Presets);
				if (callback != null)
				{
					callback();
				}
			};
		}

		private void dgPresets_DoubleClick(object sender, System.EventArgs e)
		{
			if (dgPresets.SelectedRows.Count > 0)
			{
				ShowPreset((Preset)dgPresets.SelectedRows[0].DataBoundItem);
			}
		}

		private void btnClone_Click(object sender, System.EventArgs e)
		{
			if (dgPresets.SelectedRows.Count > 0)
			{
				var preset = (Preset)dgPresets.SelectedRows[0].DataBoundItem;
				var cloned = _aircraft.ClonePreset(preset);
				AddRenamePreset(cloned);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgPresets.SelectedRows.Count > 0)
			{
				var preset = (Preset)dgPresets.SelectedRows[0].DataBoundItem;

				if (DTCMessageBox.ShowQuestion("Do you really want to delete " + preset.Name + "?"))
				{
					_aircraft.DeletePreset(preset);
					dgPresets.RefreshList(_aircraft.Presets);
				}
			}
		}
	}
}
