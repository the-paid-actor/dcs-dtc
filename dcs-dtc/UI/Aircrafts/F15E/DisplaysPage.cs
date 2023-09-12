using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        private int halfColWidth = 55;
        private int rowHeight = 24;

        public DisplaysPage(AircraftPage parent, DisplaySystem mfdSystem) : base(parent)
        {
            displaySystem = mfdSystem;
            InitializeComponent();

            var left = 5;
            var top = 5;

            this.Controls.Add(DTCLabel.Make("Pilot", left, top, colWidth, rowHeight));

            top += rowHeight + padding;
            BuildPilot(this, left, top);

            top += (rowHeight * 3) + (padding * 3) + padding * 2;
            this.Controls.Add(DTCLabel.Make("WSO", left, top, colWidth, rowHeight));

            top += rowHeight + padding;
            BuildWSO(this, left, top);
        }

        private void BuildPilot(Control parentControl, int left, int top)
        {
            var originalLeft = left;

            parentControl.Controls.Add(DTCLabel.Make("L MPD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.Pilot.LeftMPD);

            left = originalLeft;
            top += padding + rowHeight;
            parentControl.Controls.Add(DTCLabel.Make("R MPD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.Pilot.RightMPD);

            left = originalLeft;
            top += padding + rowHeight;
            parentControl.Controls.Add(DTCLabel.Make("MPCD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.Pilot.MPCD, true);
        }

        private void BuildWSO(Control parentControl, int left, int top)
        {
            var originalLeft = left;

            parentControl.Controls.Add(DTCLabel.Make("L MPCD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.WSO.LeftMPCD, true);

            left = originalLeft;
            top += padding + rowHeight;
            parentControl.Controls.Add(DTCLabel.Make("L MPD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.WSO.LeftMPD);

            left = originalLeft;
            top += padding + rowHeight;
            parentControl.Controls.Add(DTCLabel.Make("R MPD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.WSO.RightMPD);

            left = originalLeft;
            top += padding + rowHeight;
            parentControl.Controls.Add(DTCLabel.Make("R MPCD", left, top, 65, rowHeight));

            left = padding + 65;
            BuildDisplay(parentControl, left, top, displaySystem.WSO.RightMPCD, true);
        }

        private void BuildDisplay(Control parentControl, int left, int top, DisplayConfig display, bool removeA2G = false)
        {
            var originalLeft = left;

            left = originalLeft;

            var disp1 = DTCDropDown.Make(left, top, colWidth);
            parentControl.Controls.Add(disp1);
            left += padding + colWidth;

            var disp1Mode = DTCDropDown.Make(left, top, halfColWidth);
            parentControl.Controls.Add(disp1Mode);
            left += padding + colWidth;

            var disp2 = DTCDropDown.Make(left, top, colWidth);
            parentControl.Controls.Add(disp2);
            left += padding + colWidth;

            var disp2Mode = DTCDropDown.Make(left, top, halfColWidth);
            parentControl.Controls.Add(disp2Mode);
            left += padding + colWidth;

            var disp3 = DTCDropDown.Make(left, top, colWidth);
            parentControl.Controls.Add(disp3);
            left += padding + colWidth;

            var disp3Mode = DTCDropDown.Make(left, top, halfColWidth);
            parentControl.Controls.Add(disp3Mode);

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

            var displayOptions = new List<string>();
            foreach (var item in Enum.GetValues(typeof(Display)))
            {
                if (removeA2G && (Display)item == Display.AGRDR)
                {
                    continue;
                }
                displayOptions.Add(item.ToString());
            }
            var modeOptions = new List<string>();
            foreach (var item in Enum.GetValues(typeof(DisplayMode)))
            {
                modeOptions.Add(item.ToString());
            }

            PopulateCombo(disp1, displayOptions);

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
                    display.FirstDisplay = (Display)Enum.Parse(typeof(Display), disp1.SelectedItem.ToString());
                    _parent.DataChangedCallback();

                    disp1Mode.Enabled = true;
                    PopulateCombo(disp1Mode, modeOptions);
                    disp2.Enabled = true;
                    PopulateCombo(disp2, displayOptions, new[] { disp1.SelectedItem});
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
                    display.SecondDisplay = (Display)Enum.Parse(typeof(Display), disp2.SelectedItem.ToString());
                    _parent.DataChangedCallback();

                    disp2Mode.Enabled = true;
                    PopulateCombo(disp2Mode, modeOptions, new[] { disp1Mode.SelectedItem });
                    disp3.Enabled = true;
                    PopulateCombo(disp3, displayOptions, new[] { disp1.SelectedItem, disp2.SelectedItem });
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
                    display.ThirdDisplay = (Display)Enum.Parse(typeof(Display), disp3.SelectedItem.ToString());
                    _parent.DataChangedCallback();

                    disp3Mode.Enabled = true;
                    PopulateCombo(disp3Mode, modeOptions, new[] { disp1Mode.SelectedItem, disp2Mode.SelectedItem });
                }
            };

            disp1Mode.SelectedValueChanged += (s, e) =>
            {
                if (disp1Mode.SelectedItem == null || disp1Mode.SelectedItem.ToString() == "")
                {
                    display.FirstDisplayMode = DisplayMode.None;
                    _parent.DataChangedCallback();

                    PopulateCombo(disp2Mode, modeOptions);
                }
                else
                {
                    display.FirstDisplayMode = (DisplayMode)Enum.Parse(typeof(DisplayMode), disp1Mode.SelectedItem.ToString());
                    _parent.DataChangedCallback();

                    PopulateCombo(disp2Mode, modeOptions, new[] { disp1Mode.SelectedItem });
                }
            };

            disp2Mode.SelectedValueChanged += (s, e) =>
            {
                if (disp2Mode.SelectedItem == null || disp2Mode.SelectedItem.ToString() == "")
                {
                    display.SecondDisplayMode = DisplayMode.None;
                    _parent.DataChangedCallback();

                    PopulateCombo(disp3Mode, modeOptions);
                }
                else
                {
                    display.SecondDisplayMode = (DisplayMode)Enum.Parse(typeof(DisplayMode), disp2Mode.SelectedItem.ToString());
                    _parent.DataChangedCallback();

                    PopulateCombo(disp3Mode, modeOptions, new[] { disp1Mode.SelectedItem, disp2Mode.SelectedItem });
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
                    display.ThirdDisplayMode = (DisplayMode)Enum.Parse(typeof(DisplayMode), disp3Mode.SelectedItem.ToString());
                    _parent.DataChangedCallback();
                }
            };

            if (d1 != Display.None) { disp1.SelectedItem = d1.ToString(); }
            if (d2 != Display.None) { disp2.SelectedItem = d2.ToString(); }
            if (d3 != Display.None) { disp3.SelectedItem = d3.ToString(); }

            if (d1Mode != DisplayMode.None) { disp1Mode.SelectedItem = d1Mode.ToString(); }
            if (d2Mode != DisplayMode.None) { disp2Mode.SelectedItem = d2Mode.ToString(); }
            if (d3Mode != DisplayMode.None) { disp3Mode.SelectedItem = d3Mode.ToString(); }
        }

        private static void PopulateCombo(DTCDropDown cbo, List<string> items, object[] removeItems = null)
        {
            var selectedItem = cbo.SelectedItem;
            var removeItemsStr = removeItems?.Select(x => x.ToString()).ToArray();

            cbo.Items.Clear();
            foreach (var item in items)
            {
                if (item.ToString() == "None")
                {
                    cbo.Items.Add("");
                }
                else if (removeItems != null && removeItemsStr.Contains(item.ToString()))
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
