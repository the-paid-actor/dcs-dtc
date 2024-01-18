using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class CMSPage : AircraftSystemPage
    {
        private CMSystem cms;

        private int _lastTabIndex = 0;

        public CMSPage(FA18Page parent) : base(parent, nameof(parent.Configuration.CMS))
        {
            cms = parent.Configuration.CMS;
            InitializeComponent();

            foreach (var name in Enum.GetNames(typeof(CMSMode)))
            {
                cboMode.Items.Add(name);
            }

            for (var i = 0; i < cms.Programs.Length; i++)
            {
                cboProgram.Items.Add((i + 1).ToString());
            }

            if (cms.Mode != null)
            {
                cboMode.SelectedItem = cms.Mode.ToString();
            }
            else
            {
                cboMode.SelectedItem = CMSMode.Unchanged.ToString();
            }

            cboProgram.SelectedItem = cms.SelectedProgram.ToString();

            chkHUD.Checked = cms.EnableHUD;

            cboMode.SelectedValueChanged += (s, e) =>
            {
                cms.Mode = (CMSMode)Enum.Parse(typeof(CMSMode), cboMode.SelectedItem.ToString());
                if (cms.Mode == CMSMode.Unchanged)
                {
                    cms.Mode = null;
                }
                this.SavePreset();
            };

            cboProgram.SelectedValueChanged += (s, e) =>
            {
                cms.SelectedProgram = int.Parse(cboProgram.SelectedItem.ToString());
                this.SavePreset();
            };

            chkHUD.CheckedChanged += (s, e) =>
            {
                cms.EnableHUD = chkHUD.Checked;
                this.SavePreset();
            };

            var padding = 6;
            var columnWidth = 90;
            var rowHeight = 20;
            var chkWidth = 20;
            var qtyMask = "00";
            var IntervalMask = @"0\.00";

            this.SuspendLayout();

            var top = padding;
            var left = 2 * (columnWidth + padding);

            panel1.Controls.Add(DTCLabel.Make("Chaff Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            panel1.Controls.Add(DTCLabel.Make("Flare Qty", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            panel1.Controls.Add(DTCLabel.Make("Repeat", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            panel1.Controls.Add(DTCLabel.Make("Interval", left, top, columnWidth, rowHeight));
            left += columnWidth + padding;

            top += rowHeight + padding;

            for (var i = 0; i < cms.Programs.Length; i++)
            {
                var program = cms.Programs[i];

                left = 0;
                panel1.Controls.Add(DTCCheckBox.Make(left, top, chkWidth, rowHeight, program.ToBeUpdated, (chk) =>
                {
                    program.ToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                panel1.Controls.Add(DTCLabel.Make("Program " + (i + 1).ToString(), left + 20, top, columnWidth, rowHeight));
                left += columnWidth + padding;

                panel1.Controls.Add(DTCLabel.Make("Chaff", left + chkWidth, top, columnWidth - chkWidth, rowHeight));
                left += columnWidth + padding;

                panel1.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetChaffQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetChaffQty(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                panel1.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetFlareQty(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetFlareQty(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                panel1.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetRepeat(), qtyMask, (txt) =>
                {
                    txt.Text = program.SetRepeat(txt.Text);
                    this.SavePreset();
                }));
                left += columnWidth + padding;

                panel1.Controls.Add(CreateTextBox(left, top, columnWidth, program.GetInterval(), IntervalMask, (txt) =>
                {
                    txt.Text = program.SetInterval(txt.Text);
                    this.SavePreset();
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
