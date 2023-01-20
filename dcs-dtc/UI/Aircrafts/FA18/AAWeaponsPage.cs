using DTC.Models.FA18.AAWeapons;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.FA18
{
    public partial class AAWeaponsPage : AircraftSettingPage
    {
        private AAWeaponsSystem _aaweapons;

        public override string GetPageTitle()
        {
            return "A/A Weapons";
        }

        public AAWeaponsPage(AircraftPage parent, AAWeaponsSystem aaweapons) : base(parent)
        {
            _aaweapons = aaweapons;
            InitializeComponent();

            var padding = 6;
            var columnWidth = 90;
            var rowHeight = 20;
            var chkWidth = 20;

            var left = padding;
            var top = padding;

            var chkUpdateAzEl = new DTCCheckBox();
            chkUpdateAzEl.RelatedTo = "AzEl";
            chkUpdateAzEl.Checked = _aaweapons.AzElToBeUpdated;
            chkUpdateAzEl.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateAzEl, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("Az/El Auto IFF", left, top, columnWidth + 10, rowHeight));

            top += rowHeight + padding;
            left = padding + (columnWidth + padding);

            this.Controls.Add(DTCLabel.Make("Bars", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Range", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Azimuth", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("PRF", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Timeout", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            //AIM9 Row
            left = padding;
            top += rowHeight + padding;
            var chkUpdateAIM9 = new DTCCheckBox();
            chkUpdateAIM9.RelatedTo = "AIM9";
            chkUpdateAIM9.Checked = _aaweapons.AIM9ToBeUpdated;
            chkUpdateAIM9.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateAIM9, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("AIM-9", left, top, columnWidth-20, rowHeight));
            left = padding + (columnWidth + padding);

            var cboAIM9Bars = DTCDropDown.Make(left, top, columnWidth-20);
            cboAIM9Bars.Items.AddRange(new string[] { "1B", "2B", "4B", "6B"});
            cboAIM9Bars.SelectedItem = _aaweapons.AIM9Bars;
            cboAIM9Bars.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM9Bars.SelectedItem;
                _aaweapons.AIM9Bars = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM9Bars);
            left += columnWidth + padding;

            var cboAIM9Range = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM9Range.Items.AddRange(new string[] { "5", "10", "20", "40", "80", "160"});
            cboAIM9Range.SelectedItem = _aaweapons.AIM9Range;
            cboAIM9Range.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM9Range.SelectedItem;
                _aaweapons.AIM9Range = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM9Range);
            left += columnWidth + padding;

            var cboAIM9Az = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM9Az.Items.AddRange(new string[] { "20", "40", "60", "80", "140"});
            cboAIM9Az.SelectedItem = _aaweapons.AIM9Az;
            cboAIM9Az.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM9Az.SelectedItem;
                _aaweapons.AIM9Az = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM9Az);
            left += columnWidth + padding;

            var cboAIM9PRF = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM9PRF.Items.AddRange(new string[] { "INTL", "MED", "HI"});
            cboAIM9PRF.SelectedItem = _aaweapons.AIM9PRF;
            cboAIM9PRF.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM9PRF.SelectedItem;
                _aaweapons.AIM9PRF = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM9PRF);
            left += columnWidth + padding;

            var cboAIM9Timeout = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM9Timeout.Items.AddRange(new string[] { "2", "4", "8", "16", "32"});
            cboAIM9Timeout.SelectedItem = _aaweapons.AIM9Timeout;
            cboAIM9Timeout.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM9Timeout.SelectedItem;
                _aaweapons.AIM9Timeout = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM9Timeout);

            //AIM7 Row
            left = padding;
            top += rowHeight + padding;
            var chkUpdateAIM7 = new DTCCheckBox();
            chkUpdateAIM7.RelatedTo = "AIM7";
            chkUpdateAIM7.Checked = _aaweapons.AIM7ToBeUpdated;
            chkUpdateAIM7.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateAIM7, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("AIM-7", left, top, columnWidth - 20, rowHeight));
            left = padding + (columnWidth + padding);

            var cboAIM7Bars = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM7Bars.Items.AddRange(new string[] { "1B", "2B", "4B", "6B" });
            cboAIM7Bars.SelectedItem = _aaweapons.AIM7Bars;
            cboAIM7Bars.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM7Bars.SelectedItem;
                _aaweapons.AIM7Bars = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM7Bars);
            left += columnWidth + padding;

            var cboAIM7Range = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM7Range.Items.AddRange(new string[] { "5", "10", "20", "40", "80", "160" });
            cboAIM7Range.SelectedItem = _aaweapons.AIM7Range;
            cboAIM7Range.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM7Range.SelectedItem;
                _aaweapons.AIM7Range = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM7Range);
            left += columnWidth + padding;

            var cboAIM7Az = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM7Az.Items.AddRange(new string[] { "20", "40", "60", "80", "140" });
            cboAIM7Az.SelectedItem = _aaweapons.AIM7Az;
            cboAIM7Az.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM7Az.SelectedItem;
                _aaweapons.AIM7Az = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM7Az);
            left += columnWidth + padding;

            var cboAIM7PRF = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM7PRF.Items.AddRange(new string[] { "INTL", "PDI", "MED", "HI" });
            cboAIM7PRF.SelectedItem = _aaweapons.AIM7PRF;
            cboAIM7PRF.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM7PRF.SelectedItem;
                _aaweapons.AIM7PRF = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM7PRF);
            left += columnWidth + padding;

            var cboAIM7Timeout = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM7Timeout.Items.AddRange(new string[] { "2", "4", "8", "16", "32" });
            cboAIM7Timeout.SelectedItem = _aaweapons.AIM7Timeout;
            cboAIM7Timeout.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM7Timeout.SelectedItem;
                _aaweapons.AIM7Timeout = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM7Timeout);

            //AIM120 Row
            left = padding;
            top += rowHeight + padding;
            var chkUpdateAIM120 = new DTCCheckBox();
            chkUpdateAIM120.RelatedTo = "AIM120";
            chkUpdateAIM120.Checked = _aaweapons.AIM120ToBeUpdated;
            chkUpdateAIM120.CheckedChanged += chk_OnChange;
            this.Controls.Add(DTCCheckBox.Make(chkUpdateAIM120, left, top, chkWidth, rowHeight));
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("AIM-120", left, top, columnWidth - 20, rowHeight));
            left = padding + (columnWidth + padding);

            var cboAIM120Bars = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM120Bars.Items.AddRange(new string[] { "1B", "2B", "4B", "6B" });
            cboAIM120Bars.SelectedItem = _aaweapons.AIM120Bars;
            cboAIM120Bars.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM120Bars.SelectedItem;
                _aaweapons.AIM120Bars = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM120Bars);
            left += columnWidth + padding;

            var cboAIM120Range = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM120Range.Items.AddRange(new string[] { "5", "10", "20", "40", "80", "160" });
            cboAIM120Range.SelectedItem = _aaweapons.AIM120Range;
            cboAIM120Range.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM120Range.SelectedItem;
                _aaweapons.AIM120Range = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM120Range);
            left += columnWidth + padding;

            var cboAIM120Az = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM120Az.Items.AddRange(new string[] { "20", "40", "60", "80", "140" });
            cboAIM120Az.SelectedItem = _aaweapons.AIM120Az;
            cboAIM120Az.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM120Az.SelectedItem;
                _aaweapons.AIM120Az = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM120Az);
            left += columnWidth + padding;

            var cboAIM120PRF = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM120PRF.Items.AddRange(new string[] { "INTL", "MED", "HI" });
            cboAIM120PRF.SelectedItem = _aaweapons.AIM120PRF;
            cboAIM120PRF.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM120PRF.SelectedItem;
                _aaweapons.AIM120PRF = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM120PRF);
            left += columnWidth + padding;

            var cboAIM120Timeout = DTCDropDown.Make(left, top, columnWidth - 20);
            cboAIM120Timeout.Items.AddRange(new string[] { "2", "4", "8", "16", "32" });
            cboAIM120Timeout.SelectedItem = _aaweapons.AIM120Timeout;
            cboAIM120Timeout.SelectedIndexChanged += (sender, args) =>
            {
                object selectedItem = cboAIM120Timeout.SelectedItem;
                _aaweapons.AIM120Timeout = selectedItem.ToString();
                _parent.DataChangedCallback();
            };
            this.Controls.Add(cboAIM120Timeout);
        }

        private void chk_OnChange(object sender, EventArgs e)
        {
            var chk = ((DTCCheckBox)sender);
            switch (chk.RelatedTo)
            {
                case "AzEl":
                    _aaweapons.AzElToBeUpdated = chk.Checked;
                    break;
                case "AIM9":
                    _aaweapons.AIM9ToBeUpdated = chk.Checked;
                    break;
                case "AIM7":
                    _aaweapons.AIM7ToBeUpdated = chk.Checked;
                    break;
                case "AIM120":
                    _aaweapons.AIM120ToBeUpdated = chk.Checked;
                    break;
            }
            _parent.DataChangedCallback();
        }
    }
}
