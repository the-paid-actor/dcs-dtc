using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Pages;

namespace DTC.New.UI.Base.Systems
{
    public partial class WaypointCapturePage : AircraftSystemPage
    {
        private WaypointCaptureSystem settings;

        public WaypointCapturePage(AircraftPage parent, WaypointCaptureSystem capture) : base(parent)
        {
            InitializeComponent();

            this.settings = capture;
            radNavEndOfList.Checked = settings.NavPointsMode == SteerpointCaptureMode.AddToEndOfList;
            radNavEndOfGap.Checked = settings.NavPointsMode == SteerpointCaptureMode.AddToEndOfFirstGap;
            radNavRange.Checked = settings.NavPointsMode == SteerpointCaptureMode.AddToRange;
            txtNavRangeFrom.Value = settings.NavPointsRangeFrom;

            radTgtAppend.Checked = settings.TgtPointsMode == SteerpointCaptureMode.AddToEndOfList;
            radTgtRange.Checked = settings.TgtPointsMode == SteerpointCaptureMode.AddToRange;
            txtTgtRangeFrom.Value = settings.TgtPointsRangeFrom;

            radNavEndOfList.CheckedChanged += NavRadioChanged;
            radNavEndOfGap.CheckedChanged += NavRadioChanged;
            radNavRange.CheckedChanged += NavRadioChanged;

            radTgtAppend.CheckedChanged += TgtRadioChanged;
            radTgtRange.CheckedChanged += TgtRadioChanged;

            txtNavRangeFrom.TextBoxChanged += (s) =>
            {
                settings.NavPointsRangeFrom = (int)txtNavRangeFrom.Value;
                this.SavePreset();
            };

            txtTgtRangeFrom.TextBoxChanged += (s) =>
            {
                settings.TgtPointsRangeFrom = (int)txtTgtRangeFrom.Value;
                this.SavePreset();
            };
        }

        private void NavRadioChanged(object? sender, EventArgs e)
        {
            if (radNavEndOfList.Checked)
            {
                settings.NavPointsMode = SteerpointCaptureMode.AddToEndOfList;
            }
            else if (radNavEndOfGap.Checked)
            {
                settings.NavPointsMode = SteerpointCaptureMode.AddToEndOfFirstGap;
            }
            else if (radNavRange.Checked)
            {
                settings.NavPointsMode = SteerpointCaptureMode.AddToRange;
            }
            this.SavePreset();
        }

        private void TgtRadioChanged(object? sender, EventArgs e)
        {
            if (radTgtAppend.Checked)
            {
                settings.TgtPointsMode = SteerpointCaptureMode.AddToEndOfList;
            }
            else if (radTgtRange.Checked)
            {
                settings.TgtPointsMode = SteerpointCaptureMode.AddToRange;
            }
            this.SavePreset();
        }

        public override string GetPageTitle()
        {
            return "Capture Settings";
        }
    }
}
