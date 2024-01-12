using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class MFDPage : AircraftSystemPage
    {
        private class Row
        {
            private Mode mode;
            private MFDConfiguration mfd;
            private DTCDropDown[] pagesDropDown = new DTCDropDown[3];
            private DTCDropDown selectedPageDropDown;
            private DTCDropDown fcrModeDropDown;
            private DTCDropDown fcrAzBarsDropDown;
            private DTCDropDown fcrRangeDropDown;
            private MFDPage parent;

            public Row(MFDPage parent, Mode mode, MFDConfiguration mfd)
            {
                this.parent = parent;
                this.mode = mode;
                this.mfd = mfd;
            }

            public void SetupPageDropDown(DTCDropDown cboPage, int pageNumber)
            {
                this.pagesDropDown[pageNumber-1] = cboPage;
                PopulatePageDropDown(cboPage, pageNumber);
            }

            private void PopulatePageDropDown(DTCDropDown cboPage, int pageNumber)
            {
                var page = (pageNumber == 1 ? this.mfd.Page1 : (pageNumber == 2 ? this.mfd.Page2 : this.mfd.Page3));

                cboPage.Items.Clear();
                foreach (Page p in Enum.GetValues(typeof(Page)))
                {
                    if (p != Page.BLANK)
                    {
                        if (pageNumber == 1 && (p == this.mfd.Page2 || p == this.mfd.Page3)) continue;
                        if (pageNumber == 2 && (p == this.mfd.Page1 || p == this.mfd.Page3)) continue;
                        if (pageNumber == 3 && (p == this.mfd.Page1 || p == this.mfd.Page2)) continue;
                    }

                    cboPage.Items.Add(p);
                }

                if (!cboPage.Items.Contains(page))
                {
                    cboPage.SelectedItem = Page.BLANK;
                    this.mfd.SetPage(pageNumber, Page.BLANK);
                }
                else
                {
                    cboPage.SelectedItem = page;
                }

                cboPage.Tag = pageNumber;
            }

            public void PageChanged(DTCDropDown cboPage)
            {
                var pageNumber = (int)cboPage.Tag!;

                if ((Page)cboPage.SelectedItem == this.mfd.GetPage(pageNumber))
                {
                    return;
                }

                this.mfd.SetPage(pageNumber, (Page)cboPage.SelectedItem);
                this.CheckFCRVisibility();
                this.CheckSelectedPageAvailability();

                for (var i = 0; i < 3; i++)
                {
                    this.PopulatePageDropDown(this.pagesDropDown[i], i + 1);
                }

                this.parent.SavePreset();
            }

            public void SetupSelectedPageDropDown(DTCDropDown cboSelectedPage)
            {
                this.selectedPageDropDown = cboSelectedPage;
            }

            private void CheckSelectedPageAvailability()
            {
                this.selectedPageDropDown.Items.Clear();
                if (this.mfd.Page1 != Page.BLANK) this.selectedPageDropDown.Items.Add(1);
                if (this.mfd.Page2 != Page.BLANK) this.selectedPageDropDown.Items.Add(2);
                if (this.mfd.Page3 != Page.BLANK) this.selectedPageDropDown.Items.Add(3);

                this.selectedPageDropDown.Visible = this.selectedPageDropDown.Items.Count != 0;

                this.selectedPageDropDown.SelectedItem = mfd.SelectedPage;

                if (this.selectedPageDropDown.Visible && !this.selectedPageDropDown.Items.Contains(this.mfd.SelectedPage))
                {
                    this.selectedPageDropDown.SelectedIndex = 0;
                    this.mfd.SelectedPage = (int)this.selectedPageDropDown.SelectedItem;
                    this.parent.SavePreset();
                }
            }

            public void SelectedPageChanged(DTCDropDown cboSelectedPage)
            {
                mfd.SelectedPage = (int)cboSelectedPage.SelectedItem;
                this.parent.SavePreset();
            }

            public void SetupFCRModeDropDown(DTCDropDown cboFCRMode)
            {
                this.fcrModeDropDown = cboFCRMode;

                cboFCRMode.Items.Clear();
                foreach (FCRMode m in Enum.GetValues(typeof(FCRMode)))
                {
                    if ((mode == Mode.AG) && (m == FCRMode.RWS || m == FCRMode.TWS || m == FCRMode.VSR)) continue;
                    if ((mode == Mode.AA || mode == Mode.MSL) && (m == FCRMode.GM || m == FCRMode.GMT || m == FCRMode.SEA)) continue;

                    cboFCRMode.Items.Add(m);
                }

                cboFCRMode.SelectedItem = this.mfd.FCRMode;
            }

            public void FCRModeChanged(DTCDropDown cboFCRMode)
            {
                this.mfd.FCRMode = (FCRMode)cboFCRMode.SelectedItem;
                PopulateFCRRange(this.fcrRangeDropDown);
                PopulateFCRAzBars(this.fcrAzBarsDropDown);
                this.parent.SavePreset();
            }

            public void SetupFCRAzBarsDropDown(DTCDropDown cboFCRAzBars)
            {
                this.fcrAzBarsDropDown = cboFCRAzBars;

                PopulateFCRAzBars(cboFCRAzBars);
            }

            private void PopulateFCRAzBars(DTCDropDown cboFCRAzBars)
            {
                cboFCRAzBars.Items.Clear();

                if (this.mfd.FCRMode == FCRMode.GM || this.mfd.FCRMode == FCRMode.GMT || this.mfd.FCRMode == FCRMode.SEA)
                {
                    cboFCRAzBars.Items.Add(6);
                    cboFCRAzBars.Items.Add(3);
                    cboFCRAzBars.Items.Add(1);
                    cboFCRAzBars.SelectedItem = this.mfd.FCRAzimuth;
                }
                else
                {
                    cboFCRAzBars.Items.Add("6/4");
                    cboFCRAzBars.Items.Add("6/2");
                    cboFCRAzBars.Items.Add("6/1");
                    cboFCRAzBars.Items.Add("3/4");
                    cboFCRAzBars.Items.Add("3/2");
                    cboFCRAzBars.Items.Add("3/1");
                    cboFCRAzBars.Items.Add("1/4");
                    cboFCRAzBars.Items.Add("1/2");
                    cboFCRAzBars.Items.Add("1/1");
                    cboFCRAzBars.SelectedItem = this.mfd.FCRAzimuth.ToString() + "/" + this.mfd.FCRBars.ToString();
                }

                if (!cboFCRAzBars.Items.Contains(cboFCRAzBars.SelectedItem))
                {
                    cboFCRAzBars.SelectedIndex = 0;
                    FCRAzBarsChanged(cboFCRAzBars);
                }
            }

            public void FCRAzBarsChanged(DTCDropDown cboFCRAzBars)
            {
                if (this.mfd.FCRMode == FCRMode.GM || this.mfd.FCRMode == FCRMode.GMT || this.mfd.FCRMode == FCRMode.SEA)
                {
                    this.mfd.FCRAzimuth = (int)cboFCRAzBars.SelectedItem;
                }
                else
                {
                    var azBars = cboFCRAzBars.SelectedItem.ToString().Split('/');
                    this.mfd.FCRAzimuth = int.Parse(azBars[0]);
                    this.mfd.FCRBars = int.Parse(azBars[1]);
                }
                this.parent.SavePreset();
            }

            public void SetupFCRRangeDropDown(DTCDropDown cboFCRRange)
            {
                this.fcrRangeDropDown = cboFCRRange;

                PopulateFCRRange(cboFCRRange);
            }

            private void PopulateFCRRange(DTCDropDown cboFCRRange)
            {
                cboFCRRange.Items.Clear();

                if (this.mfd.FCRMode == FCRMode.RWS || this.mfd.FCRMode == FCRMode.TWS || this.mfd.FCRMode == FCRMode.VSR)
                {
                    cboFCRRange.Items.Add("5");
                }
                else
                {
                    cboFCRRange.Items.Add("AUTO");
                }

                cboFCRRange.Items.Add("10");
                cboFCRRange.Items.Add("20");
                cboFCRRange.Items.Add("40");
                cboFCRRange.Items.Add("80");

                if (this.mfd.FCRMode == FCRMode.RWS || this.mfd.FCRMode == FCRMode.TWS || this.mfd.FCRMode == FCRMode.VSR)
                {
                    cboFCRRange.Items.Add("160");
                }

                var range = this.mfd.FCRRange.ToString();
                if (range == "-1") range = "AUTO";

                cboFCRRange.SelectedItem = range;

                if (!cboFCRRange.Items.Contains(range))
                {
                    cboFCRRange.SelectedItem = "40";
                    this.mfd.FCRRange = 40;
                }
            }

            public void FCRRangeChanged(DTCDropDown cboFCRRange)
            {
                var sel = cboFCRRange.SelectedItem.ToString();
                if (sel == "AUTO")
                {
                    this.mfd.FCRRange = -1;
                }
                else
                {
                    this.mfd.FCRRange = int.Parse(sel);
                }
                this.parent.SavePreset();
            }

            public void FinishedSetup()
            {
                this.CheckSelectedPageAvailability();
                this.CheckFCRVisibility();
            }

            private void CheckFCRVisibility()
            {
                var fcrVisible = false;

                if ((this.mode != Mode.DGFT) &&
                    (this.mfd.Page1 == Page.FCR || this.mfd.Page2 == Page.FCR || this.mfd.Page3 == Page.FCR))
                {
                    fcrVisible = true;
                }

                this.fcrModeDropDown.Visible = fcrVisible;
                this.fcrAzBarsDropDown.Visible = fcrVisible;
                this.fcrRangeDropDown.Visible = fcrVisible;
            }
        }

        private MFDSystem _mfdSystem;

        private List<Row> rows = new();

        public MFDPage(F16Page parent, MFDSystem mfdSystem) : base(parent)
        {
            _mfdSystem = mfdSystem;
            InitializeComponent();

            var margin = 15;
            var padding = 6;
            var rowHeight = 24;
            var cboPageWidth = 70;
            var chkWidth = 15;
            var labelWidth = 50;

            var top = margin;
            var left = margin;

            left += padding + chkWidth;
            this.Controls.Add(DTCLabel.Make("Mode", left, top, labelWidth, rowHeight));
            left += padding + labelWidth + 20;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Page 1", left, top, cboPageWidth, rowHeight));
            left += padding + cboPageWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Page 2", left, top, cboPageWidth, rowHeight));
            left += padding + cboPageWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Page 3", left, top, cboPageWidth, rowHeight));
            left += padding + cboPageWidth;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("Sel.", left, top, 40, rowHeight));
            left += padding + 40;

            this.Controls.Add(DTCLabel.MakeVerticalCentered("FCR Mode/Az/Bars/Rng", left, top, 180, rowHeight));

            top += padding + rowHeight;

            foreach (var cfg in _mfdSystem.Configurations)
            {
                left = margin;
                this.Controls.Add(DTCCheckBox.Make(left, top + ((rowHeight + padding) / 2), chkWidth, rowHeight, cfg.ToBeUpdated, (chk) =>
                {
                    cfg.ToBeUpdated = chk.Checked;
                    this.SavePreset();
                }));

                left += padding + chkWidth;
                var modeName = Enum.GetName(typeof(Mode), cfg.Mode);
                this.Controls.Add(DTCLabel.Make(modeName, left, top, labelWidth, padding + rowHeight * 2));

                for (var i = 0; i < 2; i++)
                {
                    var mfd = (i == 0 ? cfg.LeftMFD : cfg.RightMFD);
                    var mfdName = (i == 0 ? "L" : "R");

                    var row = new Row(this, cfg.Mode, mfd);
                    this.rows.Add(row);

                    left = margin + labelWidth + padding + chkWidth + padding;
                    this.Controls.Add(DTCLabel.Make(mfdName, left, top, 20, rowHeight));
                    left += padding + 20;

                    for (var j = 0; j < 3; j++)
                    {
                        var cboPage = DTCDropDown.Make(left, top);
                        cboPage.Width = cboPageWidth;
                        row.SetupPageDropDown(cboPage, j+1);
                        cboPage.SelectedIndexChanged += (s, e) => row.PageChanged(cboPage);
                        this.Controls.Add(cboPage);
                        left += padding + cboPageWidth;
                    }

                    var cboSelectedPage = DTCDropDown.Make(left, top);
                    cboSelectedPage.Width = 40;
                    row.SetupSelectedPageDropDown(cboSelectedPage);
                    cboSelectedPage.SelectedIndexChanged += (s, e) => row.SelectedPageChanged(cboSelectedPage);
                    this.Controls.Add(cboSelectedPage);
                    left += padding + 40;

                    var cboFCRMode = DTCDropDown.Make(left, top);
                    cboFCRMode.Width = 60;
                    row.SetupFCRModeDropDown(cboFCRMode);
                    cboFCRMode.SelectedIndexChanged += (s, e) => row.FCRModeChanged(cboFCRMode);
                    this.Controls.Add(cboFCRMode);
                    left += padding + 60;

                    var cboFCRAzBars = DTCDropDown.Make(left, top);
                    cboFCRAzBars.Width = 50;
                    row.SetupFCRAzBarsDropDown(cboFCRAzBars);
                    cboFCRAzBars.SelectedIndexChanged += (s, e) => row.FCRAzBarsChanged(cboFCRAzBars);
                    this.Controls.Add(cboFCRAzBars);
                    left += padding + 50;

                    var cboFCRRange = DTCDropDown.Make(left, top);
                    cboFCRRange.Width = 50;
                    row.SetupFCRRangeDropDown(cboFCRRange);
                    cboFCRRange.SelectedIndexChanged += (s, e) => row.FCRRangeChanged(cboFCRRange);
                    this.Controls.Add(cboFCRRange);

                    top += padding + rowHeight;

                    row.FinishedSetup();
                }
            }
        }

        public override string GetPageTitle()
        {
            return "MFDs";
        }
    }
}
