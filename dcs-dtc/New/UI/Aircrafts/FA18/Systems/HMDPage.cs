using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems
{
    public partial class HMDPage : AircraftSystemPage
    {
        private readonly HMDSystem hmd;

        public override string GetPageTitle()
        {
            return "HMD";
        }

        public HMDPage(FA18Page parent, HMDSystem hmd) : base(parent)
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(HMDRejectMode)))
            {
                cboMode.Items.Add(item);
            }
            cboMode.SelectedItem = hmd.RejectMode;
            cboMode.SelectedValueChanged += (s, e) =>
            {
                hmd.RejectMode = (HMDRejectMode)cboMode.SelectedItem;
                this.SavePreset();
            };

            this.hmd = hmd;
            PopulateRejectSettings();
        }

        private void PopulateRejectSettings()
        {
            var top = 0;
            var left = 0;

            pnlContent.Controls.Clear();
            for (int i = 0; i < HMDSystem.RejectSettingsNames.Length; i++)
            {
                left = 0;
                var setting = HMDSystem.RejectSettingsNames[i];
                var mode = HMDSystem.DefaultRejectSettings[i];
                if (hmd.RejectSettings != null && hmd.RejectSettings.ContainsKey(setting))
                {
                    mode = hmd.RejectSettings[setting];
                }

                var label = MakeLabel(setting, top, left);
                pnlContent.Controls.Add(label);
                left += 200;

                var pnl = new Panel();
                pnl.Top = top;
                pnl.Left = left;
                pnl.Width = 300;
                pnl.Height = 20;
                pnlContent.Controls.Add(pnl);

                var radioNorm = new RadioButton
                {
                    Top = 0,
                    Left = 0,
                    Width = 50,
                    Height = 20,
                };
                if (mode == HMDRejectMode.Normal)
                {
                    radioNorm.Checked = true;
                }
                radioNorm.CheckedChanged += (s, a) =>
                {
                    if (radioNorm.Checked)
                    {
                        hmd.RejectSettings[setting] = HMDRejectMode.Normal;
                        this.SavePreset();
                    }
                };
                pnl.Controls.Add(radioNorm);

                var radioRej1 = new RadioButton
                {
                    Top = 0,
                    Left = 50,
                    Width = 50,
                    Height = 20,
                };
                if (mode == HMDRejectMode.Reject1)
                {
                    radioRej1.Checked = true;
                }
                radioRej1.CheckedChanged += (s, a) =>
                {
                    if (radioRej1.Checked)
                    {
                        hmd.RejectSettings[setting] = HMDRejectMode.Reject1;
                        this.SavePreset();
                    }
                };
                pnl.Controls.Add(radioRej1);

                var radioRej2 = new RadioButton
                {
                    Top = 0,
                    Left = 100,
                    Width = 50,
                    Height = 20,
                };
                if (mode == HMDRejectMode.Reject2)
                {
                    radioRej2.Checked = true;
                }
                radioRej2.CheckedChanged += (s, a) =>
                {
                    if (radioRej2.Checked)
                    {
                        hmd.RejectSettings[setting] = HMDRejectMode.Reject2;
                        this.SavePreset();
                    }
                };
                pnl.Controls.Add(radioRej2);
                top += 20;
            }
        }

        private Label MakeLabel(string setting, int top, int left)
        {
            var label = new Label
            {
                Text = setting,
                Top = top,
                Left = left,
                Width = 200,
                Height = 20,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Microsoft Sans Serif", 10)
            };
            return label;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.hmd.RejectSettings = new();
            this.PopulateRejectSettings();
        }
    }
}
