using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;
using DTC.Utilities;
using System;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class HARMHTSPage : AircraftSystemPage
    {
        private class HARMControl
        {
            private class EmitterListItem
            {
                public Emitter Emitter;
                public int TableIndex;
                public int TableEntryIndex;

                public EmitterListItem(Emitter emitter, int tableIndex, int tableEntryIndex)
                {
                    Emitter = emitter;
                    TableIndex = tableIndex;
                    TableEntryIndex = tableEntryIndex;
                }

                public override string ToString()
                {
                    return Emitter.ToString();
                }
            }

            private HARMSystem _harm;
            private Panel pnlContent;
            private HARMHTSPage parent;

            public HARMControl(HARMHTSPage parent, HARMSystem harm)
            {
                this.parent = parent;
                _harm = harm;
                this.pnlContent = parent.pnlHARM;
                ReloadControls();
            }

            private void ReloadControls()
            {
                var margin = 15;
                var padding = 6;
                var labelWidth = 120;
                var chkWidth = 15;
                var bigRow = 25;
                var smallRow = 15;

                var top = margin;
                var left = margin;

                for (var i = 0; i < _harm.Tables.Length; i++)
                {
                    var initialTop = top;

                    var table = _harm.Tables[i];
                    left = margin;
                    this.pnlContent.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, bigRow, table.ToBeUpdated, (chk) =>
                    {
                        table.ToBeUpdated = chk.Checked;
                        this.parent.SavePreset();
                    }));

                    left += padding + chkWidth;
                    this.pnlContent.Controls.Add(DTCLabel.Make($"Threat Table {i + 1}", left, top, labelWidth, bigRow));

                    var btnEdit = DTCButton.Make("Edit", left, top + bigRow + padding, labelWidth, bigRow);
                    btnEdit.Click += BtnEdit_Click;
                    btnEdit.Tag = i;
                    this.pnlContent.Controls.Add(btnEdit);

                    var btnReset = DTCButton.Make("Reset", left, top + bigRow + padding + bigRow + padding, labelWidth, bigRow);
                    btnReset.Click += BtnReset_Click;
                    btnReset.Tag = i;
                    this.pnlContent.Controls.Add(btnReset);

                    left += padding + labelWidth;

                    var emittersHeight = 0;

                    for (var j = 0; j < table.Emitters.Length; j++)
                    {
                        this.pnlContent.Controls.Add(DTCLabel.Make(GetEmitterDescription(table.Emitters[j]), left, top, 500, smallRow));
                        top += 3 + smallRow;
                    }

                    top += Math.Abs(top - (initialTop + 115));
                }
            }

            private string GetEmitterDescription(int code)
            {
                foreach (var emitter in Emitters.EmittersList)
                {
                    if (emitter.HARMCode == code)
                    {
                        return emitter.ToString();
                    }
                }
                return "";
            }

            private void BtnReset_Click(object sender, System.EventArgs e)
            {
                var table = (int)((DTCButton)sender).Tag;
                _harm.Tables[table] = HARMSystem.DefaultTables[table].Clone();
                this.pnlContent.Controls.Clear();
                ReloadControls();
                this.parent.SavePreset();
            }

            private EmitterList emitterList;

            private void BtnEdit_Click(object sender, System.EventArgs e)
            {
                this.parent.Shown();

                var table = (int)((DTCButton)sender).Tag;
                this.emitterList = new EmitterList(_harm.Tables[table].Emitters, 5, false, EmitterListOk, EmitterListCancel, true);
                this.emitterList.Tag = table;

                this.parent.ShowEmitterList(this.emitterList);
            }

            private void EmitterListCancel(EmitterList sender)
            {
                this.parent.Shown();
            }

            private void EmitterListOk(EmitterList sender, int[] selected)
            {
                var table = (int)(this.emitterList).Tag;
                _harm.Tables[table].Emitters = selected;

                this.parent.Shown();

                this.pnlContent.Controls.Clear();
                ReloadControls();
                this.parent.SavePreset();
            }

            private void List_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                var item = (EmitterListItem)((DTCDropDown)sender).SelectedItem;
                _harm.Tables[item.TableIndex].Emitters[item.TableEntryIndex] = item.Emitter.HARMCode;
                this.parent.SavePreset();
            }
        }

        private class HTSControl
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
            private Panel pnlContent;
            private CheckBox chkManual;
            private HARMHTSPage parent;

            public HTSControl(HARMHTSPage parent, HTSSystem hts)
            {
                this.parent = parent;
                _hts = hts;
                this.pnlContent = parent.pnlHTS;
                ReloadControls();
            }

            private void ReloadControls()
            {
                var margin = 15;
                var padding = 6;
                var labelWidth = 120;
                var rowHeight = 20;

                var top = margin;
                var left = margin;

                this.pnlContent.Controls.Add(DTCLabel.Make("Enabled Classes", left, top, labelWidth, rowHeight));
                left += padding + labelWidth;

                var btnClassesEdit = DTCButton.Make("Edit", left, top, labelWidth, 25);
                btnClassesEdit.Click += BtnClassesEdit_Click;
                this.pnlContent.Controls.Add(btnClassesEdit);

                top += padding + 25;

                var groupTop = top;
                left = margin + 10;

                for (var i = 0; i < _hts.EnabledClasses.Length; i++)
                {
                    this.pnlContent.Controls.Add(CreateCheckBox(left, top, $"Class {i + 1}", i, _hts.EnabledClasses[i]));
                    top += padding + 15;
                    if (i == 5)
                    {
                        top = groupTop;
                        left += padding + 10 + labelWidth;
                    }
                }

                chkManual = CreateCheckBox(left, top, "Manual Table", _hts.EnabledClasses.Length, _hts.ManualTableEnabled);
                this.pnlContent.Controls.Add(chkManual);
                EnableDisableManualCheckbox();

                left = margin;
                top += padding + rowHeight + padding;

                this.pnlContent.Controls.Add(DTCLabel.Make("Manual Emitters", left, top, labelWidth, 25));
                left += padding + labelWidth;

                var btnManualEmittersEdit = DTCButton.Make("Edit", left, top, labelWidth, 25);
                btnManualEmittersEdit.Click += BtnManualEmittersEdit_Click;
                this.pnlContent.Controls.Add(btnManualEmittersEdit);

                top += padding + 25;

                if (_hts.ManualEmitters.Length == 0)
                {
                    left = margin + 10;
                    this.pnlContent.Controls.Add(DTCLabel.Make("<None>", left, top, 500, 15));
                    top += padding + 15;
                }
                else
                {
                    for (var i = 0; i < _hts.ManualEmitters.Length; i++)
                    {
                        left = margin + 10;
                        var emitter = _hts.ManualEmitters[i];
                        this.pnlContent.Controls.Add(DTCLabel.Make(GetEmitterDescription(emitter), left, top, 500, 15));
                        top += padding + 15;
                    }
                }
            }

            private EmitterList emitterList;

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
                            if (emitter.HTSTable == i + 1)
                            {
                                emitterList.Add(emitter.HARMCode);
                            }
                        }
                    }
                }

                this.emitterList = new EmitterList(emitterList.ToArray(), 8, true, HTSClassesOk, HTSClassesCancel, false);
                this.parent.ShowEmitterList(this.emitterList);
            }

            private void HTSClassesCancel(EmitterList sender)
            {
                this.parent.Shown();
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

                this.parent.Shown();

                this.pnlContent.Controls.Clear();
                ReloadControls();
                this.parent.SavePreset();
            }

            private void BtnManualEmittersEdit_Click(object sender, System.EventArgs e)
            {
                this.emitterList = new EmitterList(_hts.ManualEmitters, 8, false, ManualEmitterListOk, ManualEmitterListCancel, true);
                this.parent.ShowEmitterList(this.emitterList);
            }

            private void ManualEmitterListCancel(EmitterList sender)
            {
                this.parent.Shown();
            }

            private void ManualEmitterListOk(EmitterList sender, int[] selected)
            {
                this.parent.Shown();

                _hts.ManualEmitters = selected;
                this.pnlContent.Controls.Clear();
                ReloadControls();
                this.parent.SavePreset();
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
                this.parent.SavePreset();
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
                this.parent.SavePreset();
            }
        }

        private HARMControl harmControl;
        private HTSControl htsControl;
        private Control emitterList;

        public HARMHTSPage(F16Page parent) : base(parent, nameof(parent.Configuration.HARM), nameof(parent.Configuration.HTS))
        {
            InitializeComponent();

            this.harmControl = new HARMControl(this, parent.Configuration.HARM);
            this.htsControl = new HTSControl(this, parent.Configuration.HTS);
        }

        public override void Shown()
        {
            this.pnlHARM.Visible = true;
            this.pnlHTS.Visible = true;

            if (this.emitterList != null)
            {
                this.Controls.Remove(this.emitterList);
                this.emitterList = null;
            }
        }

        public void ShowEmitterList(Control list)
        {
            this.emitterList = list;
            this.pnlHARM.Visible = false;
            this.pnlHTS.Visible = false;

            this.Controls.Add(list);
            list.Dock = DockStyle.Fill;
            list.BringToFront();
        }

        public override string GetPageTitle()
        {
            return "HARM / HTS";
        }
    }
}
