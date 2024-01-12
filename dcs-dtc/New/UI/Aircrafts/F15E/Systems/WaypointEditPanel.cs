using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    public partial class WaypointEditPanel : UserControl, IWaypointEditCustomPanel
    {
        public WaypointEditPanel()
        {
            InitializeComponent();
        }

        public Control GetControl()
        {
            return this;
        }

        public void LoadWaypoint(IWaypoint wpt)
        {
            txtMEA.Value = ((Waypoint)wpt).MEA;
        }

        public void Save(IWaypoint wpt)
        {
            ((Waypoint)wpt).MEA = (int)(txtMEA.Value ?? 0);
        }

        public bool Validate(out string? message)
        {
            message = null;
            return true;
        }
    }
}
