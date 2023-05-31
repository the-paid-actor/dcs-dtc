using System;
using System.Linq;
using DTC.Models.F16.MFD;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;
using Page = DTC.Models.F16.MFD.Page;

namespace DTC.UI.Aircrafts.F16
{
    public partial class MFDPage : AircraftSettingPage
    {
        private MFDSystem _mfdSystem;

        public MFDPage(AircraftPage parent, MFDSystem mfdSystem) : base(parent)
        {
            _mfdSystem = mfdSystem;
            InitializeComponent();

            var padding = 6;
            var rowHeight = 24;
            var cboPageWidth = 100;
            var chkWidth = 15;
            var labelWidth = 50;

            var top = padding;
            var left = padding;
            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("Mode", left, top, labelWidth, rowHeight));
            left += padding + labelWidth;

            this.Controls.Add(DTCLabel.Make("MFD", left, top, labelWidth, rowHeight));
            left += padding + labelWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Page 1", left, top, cboPageWidth, rowHeight));
            left += padding + cboPageWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Page 2", left, top, cboPageWidth, rowHeight));
            left += padding + cboPageWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Page 3", left, top, cboPageWidth, rowHeight));
            left += padding + cboPageWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Selected Page", left, top, cboPageWidth, rowHeight));

            top += padding + rowHeight;

            foreach (var cfg in _mfdSystem.Configurations)
            {
                left = padding;
                this.Controls.Add(DTCCheckBox.Make(left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight, cfg.ToBeUpdated, (chk) =>
                {
                    cfg.ToBeUpdated = chk.Checked;
                    _parent.DataChangedCallback();
                }));

                left += padding + chkWidth;
                var modeName = Enum.GetName(typeof(Mode), cfg.Mode);
                this.Controls.Add(DTCLabel.Make(modeName, left, top, labelWidth, padding + rowHeight * 2));
                left += padding + chkWidth;
                for (var i = 0; i < 2; i++)
                {
                    var mfd = (i == 0 ? cfg.LeftMFD : cfg.RightMFD);
                    var mfdName = (i == 0 ? "Left" : "Right");

                    left = padding + labelWidth + padding + chkWidth;
                    this.Controls.Add(DTCLabel.Make(mfdName, left, top, labelWidth, rowHeight));
                    left += padding + labelWidth;

                    for (var j = 0; j < 3; j++)
                    {
                        var page = (j == 0 ? mfd.Page1 : (j == 1 ? mfd.Page2 : mfd.Page3));

                        var cboPage = DTCDropDown.Make(left, top);
                        cboPage.Width = cboPageWidth;
                        foreach (Page p in Enum.GetValues(typeof(Page)))
                        {
                            cboPage.Items.Add(p);
                        }
                        cboPage.SelectedItem = page;
                        cboPage.Tag = j + 1;
                        cboPage.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            mfd.SetPage((int)cboPage.Tag, (Page)cboPage.SelectedItem);
                            _parent.DataChangedCallback();
                        };
                        this.Controls.Add(cboPage);
                        left += padding + cboPageWidth;
                    }

                    var cboSelectedPage = DTCDropDown.Make(left, top);
                    cboSelectedPage.Width = cboPageWidth;
                    cboSelectedPage.Items.Add(1);
                    cboSelectedPage.Items.Add(2);
                    cboSelectedPage.Items.Add(3);
                    cboSelectedPage.SelectedItem = mfd.SelectedPage;
                    cboSelectedPage.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        mfd.SelectedPage = (int)cboSelectedPage.SelectedItem;
                        _parent.DataChangedCallback();
                    };
                    this.Controls.Add(cboSelectedPage);

                    top += padding + rowHeight;
                }
            }
        }

        public override string GetPageTitle()
        {
            return "MFDs";
        }
    }
}
