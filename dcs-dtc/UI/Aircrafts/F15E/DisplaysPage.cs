using System;
using System.Linq;
using DTC.Models.F15E.Displays;
using DTC.UI.Base.Controls;
using DTC.UI.CommonPages;

namespace DTC.UI.Aircrafts.F15E
{
    public partial class DisplaysPage : AircraftSettingPage
    {
        private DisplaySystem displaySystem;

        private int padding = 5;
        private int colWidth = 85;
        private int rowHeight = 24;

        public DisplaysPage(AircraftPage parent, DisplaySystem mfdSystem) : base(parent)
        {
            displaySystem = mfdSystem;
            InitializeComponent();

            var top = padding;
            var left = padding;

            this.Controls.Add(DTCLabel.Make("Pilot", left, top, colWidth, rowHeight));
            left = padding * 2;
            top += padding + rowHeight;

            this.Controls.Add(DTCLabel.Make("Left MPD", left, top, colWidth, rowHeight));
            left = padding * 3;
            top += padding + rowHeight;

            BuildDisplay(left, top, displaySystem.Pilot.LeftMPD);
            left = padding * 2;
            top += padding + rowHeight + padding + rowHeight;

            this.Controls.Add(DTCLabel.Make("Right MPD", left, top, colWidth, rowHeight));
            left = padding * 3;
            top += padding + rowHeight;

            BuildDisplay(left, top, displaySystem.Pilot.RightMPD);
            left = padding * 2;
            top += padding + rowHeight + padding + rowHeight;

            this.Controls.Add(DTCLabel.Make("MPCD", left, top, colWidth, rowHeight));
            left = padding * 3;
            top += padding + rowHeight;

            BuildDisplay(left, top, displaySystem.Pilot.MPCD);
        }

        private void BuildDisplay(int left, int top, DisplayConfig display)
        {
            this.Controls.Add(DTCLabel.Make("1", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(DTCLabel.Make("Mode", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(DTCLabel.Make("2", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(DTCLabel.Make("Mode", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(DTCLabel.Make("3", left, top, colWidth, rowHeight));
            left += padding + colWidth;

            this.Controls.Add(DTCLabel.Make("Mode", left, top, colWidth, rowHeight));

            left = padding * 3;
            top += padding + rowHeight;

            var disp1 = DTCDropDown.Make(left, top, colWidth);
            this.Controls.Add(disp1);
            left += padding + colWidth;

            var disp1Mode = DTCDropDown.Make(left, top, colWidth);
            this.Controls.Add(disp1Mode);
            left += padding + colWidth;

            var disp2 = DTCDropDown.Make(left, top, colWidth);
            this.Controls.Add(disp2);
            left += padding + colWidth;

            var disp2Mode = DTCDropDown.Make(left, top, colWidth);
            this.Controls.Add(disp2Mode);
            left += padding + colWidth;

            var disp3 = DTCDropDown.Make(left, top, colWidth);
            this.Controls.Add(disp3);
            left += padding + colWidth;

            var disp3Mode = DTCDropDown.Make(left, top, colWidth);
            this.Controls.Add(disp3Mode);

            disp2.Enabled = false;
            disp3.Enabled = false;
            disp1Mode.Enabled = false;
            disp2Mode.Enabled = false;
            disp3Mode.Enabled = false;

            var d1 = display.FirstDisplay;
            var d2 = display.SecondDisplay;
            var d3 = display.ThirdDisplay;
            var d1Mode = display.FirstDisplayMode;
            var d2Mode = display.SecondDisplayMode;
            var d3Mode = display.ThirdDisplayMode;

            PopulateCombo<Display>(disp1);

            disp1.SelectedValueChanged += (s, e) =>
            {
                if (disp1.SelectedItem == null || disp1.SelectedItem.ToString() == "")
                {
                    display.FirstDisplay = Display.None;
                    _parent.DataChangedCallback();

                    disp1Mode.Items.Clear();
                    disp1Mode.Enabled = false;
                    disp2.SelectedIndex = -1;
                    disp2.Items.Clear();
                    disp2.Enabled = false;
                }
                else
                {
                    display.FirstDisplay = (Display)disp1.SelectedItem;
                    _parent.DataChangedCallback();

                    disp1Mode.Enabled = true;
                    PopulateCombo<DisplayMode>(disp1Mode);
                    disp2.Enabled = true;
                    PopulateCombo<Display>(disp2, new[] { disp1.SelectedItem});
                }
            };

            disp2.SelectedValueChanged += (s, e) =>
            {
                if (disp2.SelectedItem == null || disp2.SelectedItem.ToString() == "")
                {
                    display.SecondDisplay = Display.None;
                    _parent.DataChangedCallback();

                    disp2Mode.Items.Clear();
                    disp2Mode.Enabled = false;
                    disp3.SelectedIndex = -1;
                    disp3.Items.Clear();
                    disp3.Enabled = false;
                }
                else
                {
                    display.SecondDisplay = (Display)disp2.SelectedItem;
                    _parent.DataChangedCallback();

                    disp2Mode.Enabled = true;
                    PopulateCombo<DisplayMode>(disp2Mode, new[] { disp1Mode.SelectedItem });
                    disp3.Enabled = true;
                    PopulateCombo<Display>(disp3, new[] { disp1.SelectedItem, disp2.SelectedItem });
                }
            };

            disp3.SelectedValueChanged += (s, e) =>
            {
                if (disp3.SelectedItem == null || disp3.SelectedItem.ToString() == "")
                {
                    display.ThirdDisplay = Display.None;
                    _parent.DataChangedCallback();

                    disp3Mode.Items.Clear();
                    disp3Mode.Enabled = false;
                }
                else
                {
                    display.ThirdDisplay = (Display)disp3.SelectedItem;
                    _parent.DataChangedCallback();

                    disp3Mode.Enabled = true;
                    PopulateCombo<DisplayMode>(disp3Mode, new[] { disp1Mode.SelectedItem, disp2Mode.SelectedItem });
                }
            };

            disp1Mode.SelectedValueChanged += (s, e) =>
            {
                if (disp1Mode.SelectedItem == null || disp1Mode.SelectedItem.ToString() == "")
                {
                    display.FirstDisplayMode = DisplayMode.None;
                    _parent.DataChangedCallback();

                    PopulateCombo<DisplayMode>(disp2Mode);
                }
                else
                {
                    display.FirstDisplayMode = (DisplayMode)disp1Mode.SelectedItem;
                    _parent.DataChangedCallback();

                    PopulateCombo<DisplayMode>(disp2Mode, new[] { disp1Mode.SelectedItem });
                }
            };

            disp2Mode.SelectedValueChanged += (s, e) =>
            {
                if (disp2Mode.SelectedItem == null || disp2Mode.SelectedItem.ToString() == "")
                {
                    display.SecondDisplayMode = DisplayMode.None;
                    _parent.DataChangedCallback();

                    PopulateCombo<DisplayMode>(disp3Mode);
                }
                else
                {
                    display.SecondDisplayMode = (DisplayMode)disp2Mode.SelectedItem;
                    _parent.DataChangedCallback();

                    PopulateCombo<DisplayMode>(disp3Mode, new[] { disp1Mode.SelectedItem, disp2Mode.SelectedItem });
                }
            };

            disp3Mode.SelectedValueChanged += (s, e) =>
            {
                if (disp3Mode.SelectedItem == null || disp3Mode.SelectedItem.ToString() == "")
                {
                    display.ThirdDisplayMode = DisplayMode.None;
                    _parent.DataChangedCallback();
                }
                else
                {
                    display.ThirdDisplayMode = (DisplayMode)disp3Mode.SelectedItem;
                    _parent.DataChangedCallback();
                }
            };

            if (d1 != Display.None) { disp1.SelectedItem = d1; }
            if (d2 != Display.None) { disp2.SelectedItem = d2; }
            if (d3 != Display.None) { disp3.SelectedItem = d3; }

            if (d1Mode != DisplayMode.None) { disp1Mode.SelectedItem = d1Mode; }
            if (d2Mode != DisplayMode.None) { disp2Mode.SelectedItem = d2Mode; }
            if (d3Mode != DisplayMode.None) { disp3Mode.SelectedItem = d3Mode; }
        }

        private static void PopulateCombo<T>(DTCDropDown cbo, object[] removeItems = null) where T : Enum
        {
            var selectedItem = cbo.SelectedItem;

            cbo.Items.Clear();
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString() == "None")
                {
                    cbo.Items.Add("");
                }
                else if (removeItems != null && removeItems.Contains(item.ToString()))
                {
                    continue;
                }
                else
                {
                    cbo.Items.Add(item);
                }
            }

            if (selectedItem != null && cbo.Items.Contains(selectedItem))
                cbo.SelectedItem = selectedItem;
            else
                cbo.SelectedIndex = 0;
        }

        public override string GetPageTitle()
        {
            return "Displays";
        }
    }
}
