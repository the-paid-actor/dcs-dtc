using System;
using System.Drawing;
using System.Windows.Forms;
using DTC.Models.FA18.CMS;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System.Linq;

namespace DTC.UI.Aircrafts.FA18
{
    public partial class CMSPage : AircraftSettingPage
    {
        private CMSystem _cms;

        private int _lastTabIndex = 0;

        public CMSPage(AircraftPage parent, CMSystem cms) : base(parent)
        {
            _cms = cms;
            InitializeComponent();

            var padding = 6;
            var columnWidth = 90;
            var rowHeight = 20;
            var chkWidth = 20;
            var qtyMask = "00";
            var IntervalMask = @"0\.00";

            this.SuspendLayout();

            var top = padding;
            var left = padding + 2 * (columnWidth + padding);

            this.Controls.Add(DTCLabel.Make("Chaff Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Flare Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Repeat", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Interval", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            top += rowHeight + padding;

            for (var i = 0; i < _cms.Programs.Length; i++)
            {
                var program = _cms.Programs[i];

                left = padding;
                this.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, program.ToBeUpdated, (chk) =>
                {
                    program.ToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                this.Controls.Add(DTCLabel.Make("Program " + (i + 1).ToString(), left + 20, top, columnWidth, rowHeight));
                left += columnWidth + padding;

                this.Controls.Add(DTCLabel.Make("Chaff", left + chkWidth, top, columnWidth - chkWidth, rowHeight));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetChaffQty(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetFlareQty(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetRepeat(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetRepeat(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetInterval(), IntervalMask, (txt) =>
                {
                    txt.Text = program.SetInterval(txt.Text);
                    _parent.DataChangedCallback();
                }));
                top += rowHeight + padding;
            }

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public override string GetPageTitle()
        {
            return "CMS";
        }

        private delegate void TextBoxChangedCallback(DTCTextBox txt);

        private Control CreateTextBox(int left, int top, int width, string value, string mask, TextBoxChangedCallback callback)
        {
            var txt = new DTCTextBox();
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
            txt.Text = value;
            txt.Mask = mask;
            txt.Tag = callback;
            txt.TabIndex = _lastTabIndex++;
            txt.LostFocus += Txt_LostFocus;
            txt.Location = new Point(left, top);
            txt.Size = new Size(width, 24);
            return txt;
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            var txt = (DTCTextBox)sender;
            var callback = (TextBoxChangedCallback)txt.Tag;
            callback(txt);
        }
    }
}
