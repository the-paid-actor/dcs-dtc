using System;
using System.Drawing;
using System.Windows.Forms;
using DTC.Models.F16.CMS;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.F16
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
            var burstIntervalMask = @"00\.000";
            var salvoIntervalMask = @"000\.00";

            this.SuspendLayout();

            var top = padding;
            var left = padding;

            left = padding + columnWidth + padding + columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Chaff Bingo", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(CreateTextBox(left, top, columnWidth, cms.ChaffBingo.ToString(), qtyMask, (txt) =>
            {
                txt.Text = cms.SetChaffBingo(txt.Text);
                _parent.DataChangedCallback();
            }));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Flare Bingo", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(CreateTextBox(left, top, columnWidth, cms.FlareBingo.ToString(), qtyMask, (txt) =>
            {
                txt.Text = cms.SetFlareBingo(txt.Text);
                _parent.DataChangedCallback();
            }));
            left += columnWidth + padding;
            top += rowHeight + padding;

            left = padding + columnWidth + padding + columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Burst Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Burst Intv", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Salvo Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Salvo Intv", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            top += rowHeight + padding;

            for (var i = 0; i < _cms.Programs.Length; i++)
            {
                var program = _cms.Programs[i];

                left = padding;
                this.Controls.Add(DTCCheckBox.Make(left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight, program.ToBeUpdated, (chk) =>
                {
                    program.ToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                this.Controls.Add(DTCLabel.Make("Program " + (i + 1).ToString(), left + 20, top + ((rowHeight + padding) / 2), columnWidth, rowHeight));
                left += columnWidth + padding;

                this.Controls.Add(DTCLabel.Make("Chaff", left + chkWidth, top, columnWidth - chkWidth, rowHeight));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffBurstQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetChaffBurstQty(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffBurstInterval(), burstIntervalMask, (txt) =>
                {
                    txt.Text = program.SetChaffBurstInterval(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffSalvoQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetChaffSalvoQty(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffSalvoInterval(), salvoIntervalMask, (txt) =>
                {
                    txt.Text = program.SetChaffSalvoInterval(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                top += rowHeight + padding;
                left = padding + columnWidth + padding;

                this.Controls.Add(DTCLabel.Make("Flare", left + chkWidth, top, columnWidth - chkWidth, rowHeight));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareBurstQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetFlareBurstQty(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareBurstInterval(), burstIntervalMask, (txt) =>
                {
                    txt.Text = program.SetFlareBurstInterval(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareSalvoQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetFlareSalvoQty(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareSalvoInterval(), salvoIntervalMask, (txt) =>
                {
                    txt.Text = program.SetFlareSalvoInterval(txt.Text);
                    _parent.DataChangedCallback();
                }));
                left += columnWidth + padding;

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
