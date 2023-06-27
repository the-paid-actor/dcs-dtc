using DTC.Models.DCS;
using DTC.Models.F16.HARMHTS;
using DTC.UI.Base;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F16
{
	public partial class HTSPage : AircraftSettingPage
	{
		private class EmitterListItem
		{
			public Emitter Emitter;
			public int EntryIndex;

			public EmitterListItem(Emitter emitter, int entryIndex)
			{
				Emitter = emitter;
				EntryIndex = entryIndex;
			}

			public override string ToString()
			{
				if (Emitter == null)
				{
					return "<None>";
				}
				else
				{
					return Emitter.ToString();
				}
			}
		}

		private HTSSystem _hts;
		private CheckBox chkManual;

		public HTSPage(AircraftPage parent, HTSSystem hts) : base(parent)
		{
			_hts = hts;
			InitializeComponent();

			ReloadControls();
		}

		private void ReloadControls()
		{
			var padding = 6;
			var labelWidth = 120;
			var rowHeight = 20;

			var top = padding;
			var left = padding;

			this.Controls.Add(DTCLabel.Make("Enabled Classes", left, top, labelWidth, rowHeight));
			left += padding + labelWidth;

			var btnClassesEdit = DTCButton.Make("Edit", left, top, labelWidth, 25);
			btnClassesEdit.Click += BtnClassesEdit_Click;
			this.Controls.Add(btnClassesEdit);

			top += padding + 25;

			var groupTop = top;
			left = padding + 10;

			for (var i = 0; i < _hts.EnabledClasses.Length; i++)
			{
				this.Controls.Add(CreateCheckBox(left, top, $"Class {i + 1}", i, _hts.EnabledClasses[i]));
				top += padding + 15;
				if (i == 5)
				{
					top = groupTop;
					left += padding + 10 + labelWidth;
				}
			}

			chkManual = CreateCheckBox(left, top, "Manual Table", _hts.EnabledClasses.Length, _hts.ManualTableEnabled);
			this.Controls.Add(chkManual);
			EnableDisableManualCheckbox();

			left = padding;
			top += padding + rowHeight + padding;

			this.Controls.Add(DTCLabel.Make("Manual Emitters", left, top, labelWidth, 25));
			left += padding + labelWidth;

			var btnManualEmittersEdit = DTCButton.Make("Edit", left, top, labelWidth, 25);
			btnManualEmittersEdit.Click += BtnManualEmittersEdit_Click;
			this.Controls.Add(btnManualEmittersEdit);

			top += padding + 25;

			if (_hts.ManualEmitters.Length == 0)
			{
				left = padding + 10;
				this.Controls.Add(DTCLabel.Make("<None>", left, top, 500, 15));
				top += padding + 15;
			}
			else
			{
				for (var i = 0; i < _hts.ManualEmitters.Length; i++)
				{
					left = padding + 10;
					var emitter = _hts.ManualEmitters[i];
					this.Controls.Add(DTCLabel.Make(GetEmitterDescription(emitter), left, top, 500, 15));
					top += padding + 15;
				}
			}
		}

		private void BtnClassesEdit_Click(object sender, System.EventArgs e)
		{
			var emitterList = new List<int>();
			
			for (var i = 0; i < _hts.EnabledClasses.Length; i++)
			{
				var enabled = _hts.EnabledClasses[i];
				if (enabled)
				{
					foreach (var emitter in Emitters.EmittersList)
					{
						if (emitter.HTSTable == i+1)
						{
							emitterList.Add(emitter.HARMCode);
						}
					}
				}
			}

			var list = new EmitterList(emitterList.ToArray(), 8, true, HTSClassesOk, HTSClassesCancel,false);
			this.Controls.Add(list);
			list.Dock = DockStyle.Fill;
			list.BringToFront();
		}

		private void HTSClassesCancel(EmitterList sender)
		{
			this.Controls.Remove(sender);
		}

		private void HTSClassesOk(EmitterList sender, int[] selected)
		{
			for (var i = 0; i < _hts.EnabledClasses.Length; i++)
			{
				_hts.EnabledClasses[i] = false;
			}

			foreach (var emitterCode in selected)
			{
				foreach (var emitter in Emitters.EmittersList)
				{
					if (emitter.HARMCode == emitterCode)
					{
						_hts.EnabledClasses[emitter.HTSTable - 1] = true;
					}
				}
			}
			this.Controls.Clear();
			ReloadControls();
			_parent.DataChangedCallback();
		}

		private void BtnManualEmittersEdit_Click(object sender, System.EventArgs e)
		{
			var list = new EmitterList(_hts.ManualEmitters, 8, false, ManualEmitterListOk, ManualEmitterListCancel,true);
			this.Controls.Add(list);
			list.Dock = DockStyle.Fill;
			list.BringToFront();
		}

		private void ManualEmitterListCancel(EmitterList sender)
		{
			this.Controls.Remove(sender);
		}

		private void ManualEmitterListOk(EmitterList sender, int[] selected)
		{
			_hts.ManualEmitters = selected;
			this.Controls.Clear();
			ReloadControls();
			_parent.DataChangedCallback();
		}

		private string GetEmitterDescription(int code)
		{
			if (code == 0)
			{
				return "<None>";
			}
			foreach (var emitter in Emitters.EmittersList)
			{
				if (emitter.HARMCode == code)
				{
					return emitter.ToString();
				}
			}
			return "";
		}

		private void EnableDisableManualCheckbox()
		{
			var wasEnabled = chkManual.Enabled;
			chkManual.Enabled = false;

			for (var i = 0; i < _hts.ManualEmitters.Length; i++)
			{
				if (_hts.ManualEmitters[i] != 0)
				{
					chkManual.Enabled = true;
				}
			}

			if (chkManual.Enabled == false)
			{
				chkManual.Checked = false;
			}
			else if (!wasEnabled && chkManual.Checked == false)
			{
				chkManual.Checked = true;
			}
		}

		private CheckBox CreateCheckBox(int x, int y, string label, int entryIdx, bool selected)
		{
			var chk = new DTCCheckBox();
			chk.Text = label;
			chk.Left = x;
			chk.Top = y;
			chk.Tag = entryIdx;
			chk.Checked = selected;
			chk.CheckedChanged += Chk_CheckedChanged;
			return chk;
		}

		private void Chk_CheckedChanged(object sender, System.EventArgs e)
		{
			var chk = ((DTCCheckBox)sender);
			if (sender == chkManual)
			{
				_hts.ManualTableEnabled = chk.Checked;
			}
			else
			{
				var idx = (int)chk.Tag;
				_hts.EnabledClasses[idx] = chk.Checked;
			}
			_parent.DataChangedCallback();
		}

		private void List_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			var item = (EmitterListItem)((DTCDropDown)sender).SelectedItem;
			if (item.Emitter != null)
			{
				_hts.ManualEmitters[item.EntryIndex] = item.Emitter.HARMCode;
			}
			else
			{
				_hts.ManualEmitters[item.EntryIndex] = 0;
			}

			EnableDisableManualCheckbox();
			_parent.DataChangedCallback();
		}

		public override string GetPageTitle()
		{
			return "HTS";
		}
	}
}
