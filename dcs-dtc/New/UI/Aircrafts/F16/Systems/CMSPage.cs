using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class CMSPage : AircraftSystemPage
    {
        private CMSSystem cms;

        private int _lastTabIndex = 0;

        public CMSPage(F16Page parent) : base(parent, nameof(parent.Configuration.CMS))
        {
            cms = parent.Configuration.CMS;
            InitializeComponent();

            var margin = 15;
            var padding = 6;
            var firstColumnWidth = 80;
            var chaffFlareLabelWidth = 45;
            var columnWidth = 90;
            var rowHeight = 20;
            var chkWidth = 20;
            var qtyMask = "00";
            var burstIntervalMask = @"00\.000";
            var salvoIntervalMask = @"000\.00";

            this.SuspendLayout();

            var top = margin;
            var left = padding;

            left = margin + chkWidth + firstColumnWidth + padding + chaffFlareLabelWidth + padding;

            this.Controls.Add(DTCLabel.Make("Chaff Bingo", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(CreateTextBox(left, top, columnWidth, cms.ChaffBingo.ToString(), qtyMask, (txt) =>
            {
                txt.Text = cms.SetChaffBingo(txt.Text);
                this.SavePreset();
            }));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Flare Bingo", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(CreateTextBox(left, top, columnWidth, cms.FlareBingo.ToString(), qtyMask, (txt) =>
            {
                txt.Text = cms.SetFlareBingo(txt.Text);
                this.SavePreset();
            }));
            left += columnWidth + padding;
            top += rowHeight + padding;

            left = margin + chkWidth + firstColumnWidth + padding + chaffFlareLabelWidth + padding;

            this.Controls.Add(DTCLabel.Make("Burst Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Burst Intv", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Salvo Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            this.Controls.Add(DTCLabel.Make("Salvo Intv", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            top += rowHeight + padding;

            for (var i = 0; i < cms.Programs.Length; i++)
            {
                var program = cms.Programs[i];

                left = margin;
                this.Controls.Add(DTCCheckBox.Make(left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight, program.ToBeUpdated, (chk) =>
                {
                    program.ToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));
                left += chkWidth;

                this.Controls.Add(DTCLabel.Make("Program " + (i + 1).ToString(), left, top + ((rowHeight + padding) / 2), firstColumnWidth, rowHeight));
                left += firstColumnWidth + padding;

                this.Controls.Add(DTCLabel.Make("Chaff", left, top, chaffFlareLabelWidth, rowHeight));
                left += chaffFlareLabelWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffBurstQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetChaffBurstQty(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffBurstInterval(), burstIntervalMask, (txt) =>
                {
                    txt.Text = program.SetChaffBurstInterval(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffSalvoQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetChaffSalvoQty(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffSalvoInterval(), salvoIntervalMask, (txt) =>
                {
                    txt.Text = program.SetChaffSalvoInterval(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                top += rowHeight + padding;
                left = margin + chkWidth + firstColumnWidth + padding;

                this.Controls.Add(DTCLabel.Make("Flare", left, top, chaffFlareLabelWidth, rowHeight));
                left += chaffFlareLabelWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareBurstQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetFlareBurstQty(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareBurstInterval(), burstIntervalMask, (txt) =>
                {
                    txt.Text = program.SetFlareBurstInterval(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareSalvoQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetFlareSalvoQty(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                this.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareSalvoInterval(), salvoIntervalMask, (txt) =>
                {
                    txt.Text = program.SetFlareSalvoInterval(txt.Text);
                    this.SavePreset();
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
