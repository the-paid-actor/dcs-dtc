using DTC.Models.DCS;
using DTC.Models.F16.HARMHTS;
using DTC.UI.Base;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F16
{
    public partial class HARMPage : AircraftSettingPage
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

        public HARMPage(AircraftPage parent, HARMSystem harm) : base(parent)
        {
            _harm = harm;
            InitializeComponent();

            ReloadControls();
        }

        private void ReloadControls()
        {
            var padding = 6;
            var labelWidth = 120;
            var chkWidth = 15;
            var bigRow = 25;
            var smallRow = 15;

            var top = padding;
            var left = padding;

            for (var i = 0; i < _harm.Tables.Length; i++)
            {
                var table = _harm.Tables[i];
                left = padding;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, bigRow, table.ToBeUpdated, (chk) =>
                {
                    table.ToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                this.Controls.Add(DTCLabel.Make($"Threat Table {i + 1}", left, top, labelWidth, bigRow));
                left += padding + labelWidth;

                var btnEdit = DTCButton.Make("Edit", left, top, labelWidth, bigRow);
                btnEdit.Click += BtnEdit_Click;
                btnEdit.Tag = i;
                this.Controls.Add(btnEdit);

                left += padding + labelWidth;

                var btnReset = DTCButton.Make("Reset", left, top, labelWidth, bigRow);
                btnReset.Click += BtnReset_Click;
                btnReset.Tag = i;
                this.Controls.Add(btnReset);

                top += padding + bigRow;

                for (var j = 0; j < table.Emitters.Length; j++)
                {
                    left = padding + 10;
                    this.Controls.Add(DTCLabel.Make(GetEmitterDescription(table.Emitters[j]), left, top, 500, smallRow));
                    top += 3 + smallRow;
                }

                top += padding;
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
            this.Controls.Clear();
            ReloadControls();
            _parent.DataChangedCallback();
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            var table = (int)((DTCButton)sender).Tag;
            var list = new EmitterList(_harm.Tables[table].Emitters, 5, false, EmitterListOk, EmitterListCancel, true);
            list.Tag = table;
            this.Controls.Add(list);
            list.Dock = DockStyle.Fill;
            list.BringToFront();
        }

        private void EmitterListCancel(EmitterList sender)
        {
            this.Controls.Remove(sender);
        }

        private void EmitterListOk(EmitterList sender, int[] selected)
        {
            var table = (int)((EmitterList)sender).Tag;
            _harm.Tables[table].Emitters = selected;
            this.Controls.Clear();
            ReloadControls();
            _parent.DataChangedCallback();
        }

        private void List_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var item = (EmitterListItem)((DTCDropDown)sender).SelectedItem;
            _harm.Tables[item.TableIndex].Emitters[item.TableEntryIndex] = item.Emitter.HARMCode;
            _parent.DataChangedCallback();
        }

        public override string GetPageTitle()
        {
            return "HARM";
        }
    }
}
