using DTC.Models.F16.TOS;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DTC.UI.Aircrafts.F16
{
    public partial class TOSPage : AircraftSettingPage
    {
        private TOSSystem _tos;

        public TOSPage(AircraftPage parent, TOSSystem tos) : base(parent)
        {
            _tos = tos;

            InitializeComponent();

            var tblTos = PopulateTable(_tos);

            tblTOS.Controls.Add(tblTos, 0, 1);
        }

        public override string GetPageTitle()
        {
            return "ToS";
        }

        private TableLayoutPanel PopulateTable(TOSSystem tos)
        {
            var tblTos = new TableLayoutPanel();
            tblTos.RowCount = tos.TimesOnStation.Length;
            tblTos.ColumnCount = 3;
            tblTos.Dock = DockStyle.Fill;
            tblTos.AutoScroll = true;
            var rowHeight = 30;

            for (int i = 0; i < tos.TimesOnStation.Length; i++)
            {
                TOSSetting timeOnStation = (TOSSetting)tos.TimesOnStation[i];
                var chk = new DTCCheckBox();
                chk.Checked = timeOnStation.EnableUpload;
                chk.RelatedTo = i.ToString();
                chk.Width = 20;
                chk.CheckedChanged += chk_OnChange;
                tblTos.Controls.Add(chk, 0, i);
                var lbl = new Label();
                lbl.Text = "Steerpoint " + (i+1).ToString();
                lbl.AutoSize = false;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                tblTos.Controls.Add(lbl, 1, i);

                var txt = new DTCTextBox();
                txt.Width = 100;
                txt.Anchor = AnchorStyles.Left;
                txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
                txt.Mask = @"00:00:00";
                txt.Text = String.Format(System.Globalization.CultureInfo.InvariantCulture, @"{00:00:00}", timeOnStation.Time);
                txt.Tag = i;
                txt.LostFocus += Txt_LostFocus;
                tblTos.Controls.Add(txt, 2, i);

                tblTos.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
            }

            return tblTos;
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            var txt = ((DTCTextBox)sender);
            var num = (int)txt.Tag;
            var tos = _tos.TimesOnStation[num];
            if (validTime(txt.Text))
            {
                tos.Time = txt.Text;
            }
            txt.Text = tos.Time;
            _parent.DataChangedCallback();
        }

        private bool validTime(string s)
        {
            var parts = s.Split(':');
            if (parts[0].Trim() == "" || int.Parse(parts[0]) > 23) return false;
            if (parts[1].Trim() == "" || int.Parse(parts[1]) > 59) return false;
            if (parts[2].Trim() == "" || int.Parse(parts[2]) > 59) return false;
            return true;
        }

        private void chk_OnChange(object sender, EventArgs e)
        {
            var chk = ((DTCCheckBox)sender);
            var number = (int)chk.Parent.Controls.OfType<DTCTextBox>()
                .First(x => ((int)x.Tag).ToString() == chk.RelatedTo).Tag;
            var tos = _tos.TimesOnStation[number];
            if(tos.Time.Split(':')[0].Trim() != "") tos.EnableUpload = chk.Checked;
            chk.Checked = tos.EnableUpload;
            _parent.DataChangedCallback();
        }
    }
}
