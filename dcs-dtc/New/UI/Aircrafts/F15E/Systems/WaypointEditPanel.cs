using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.F15E.Systems
{
    public partial class WaypointEditPanel : UserControl, IWaypointEditCustomPanel
    {
        private readonly WaypointSystem waypointSystem;
        private Waypoint waypoint;
        private Action<bool>? coordinateInputEnabledCallback;
        private Action<bool>? timeOverSteerpointEnabledCallback;

        public WaypointEditPanel(WaypointSystem waypointSystem)
        {
            InitializeComponent();
            this.waypointSystem = waypointSystem;
        }

        public Control GetControl()
        {
            return this;
        }

        public bool GenericCoordinateInputEnabled => !chkOffset.Checked || radioButtonDirectCoordinates.Checked;

        public void SetCoordinateInputEnabledCallback(Action<bool> callback)
        {
            this.coordinateInputEnabledCallback = callback;
        }

        public void SetTimeOverSteerpointEnabledCallback(Action<bool> callback)
        {
            this.timeOverSteerpointEnabledCallback = callback;
        }

        public void LoadWaypoint(IWaypoint wpt)
        {
            this.waypoint = (Waypoint)wpt;
            txtMEA.Value = this.waypoint.MEA;
            chkOffset.Checked = this.waypoint.Offset;
            radioButtonDirectCoordinates.Checked = !this.waypoint.UseRelativeOffsetBearingAndRange && !this.waypoint.UseRelativeOffsetLatLong;
            radioButtonRelativeDirRng.Checked = this.waypoint.UseRelativeOffsetBearingAndRange;
            radioButtonRelativeLatLong.Checked = this.waypoint.UseRelativeOffsetLatLong;
            txtDirection.Value = this.waypoint.RelativeOffsetBearingAndRange?.Direction;
            txtRange.Value = this.waypoint.RelativeOffsetBearingAndRange?.Range;
            cmbLatitudeDirection.Text = this.waypoint.RelativeOffsetLatLong?.LatitudeDirection;
            txtRelativeLatitude.Value = this.waypoint.RelativeOffsetLatLong?.RelativeLatitude;
            cmbLongitudeDirection.Text = this.waypoint.RelativeOffsetLatLong?.LongitudeDirection;
            txtRelativeLongitude.Value = this.waypoint.RelativeOffsetLatLong?.RelativeLongitude;
            UpdateCoordinateMode();
        }

        public void Save(IWaypoint wpt)
        {
            ((Waypoint)wpt).MEA = (int)(txtMEA.Value ?? 0);
            ((Waypoint)wpt).Offset = chkOffset.Checked;
            ((Waypoint)wpt).UseRelativeOffsetBearingAndRange = radioButtonRelativeDirRng.Checked;
            ((Waypoint)wpt).UseRelativeOffsetLatLong = radioButtonRelativeLatLong.Checked;
            ((Waypoint)wpt).RelativeOffsetBearingAndRange ??= new RelativeOffsetBearingAndRange();
            ((Waypoint)wpt).RelativeOffsetBearingAndRange.Direction = (int)(txtDirection.Value ?? 0);
            ((Waypoint)wpt).RelativeOffsetBearingAndRange.Range = txtRange.Value ?? 0;
            ((Waypoint)wpt).RelativeOffsetLatLong ??= new RelativeOffsetLatLong();
            ((Waypoint)wpt).RelativeOffsetLatLong.LatitudeDirection = cmbLatitudeDirection.Text;
            ((Waypoint)wpt).RelativeOffsetLatLong.RelativeLatitude = (long)(txtRelativeLatitude.Value ?? 0);
            ((Waypoint)wpt).RelativeOffsetLatLong.LongitudeDirection = cmbLongitudeDirection.Text;
            ((Waypoint)wpt).RelativeOffsetLatLong.RelativeLongitude = (long)(txtRelativeLongitude.Value ?? 0);
        }

        public bool Validate(out string? message)
        {
            if (radioButtonRelativeDirRng.Checked && (txtDirection.Value == null || txtRange.Value == null))
            {
                message = "Direction and range are required for relative direction/range mode";
                return false;
            }

            if (radioButtonRelativeLatLong.Checked &&
                (string.IsNullOrEmpty(cmbLatitudeDirection.Text) || txtRelativeLatitude.Value == null ||
                 string.IsNullOrEmpty(cmbLongitudeDirection.Text) || txtRelativeLongitude.Value == null))
            {
                message = "Latitude and longitude offsets are required for relative latitude/longitude mode";
                return false;
            }

            // No offset state change: no offset-specific validation is needed.
            if (this.waypoint.Offset == chkOffset.Checked)
            {
                message = null;
                return true;
            }

            // Offset -> regular: only allow this when the next waypoint is regular or absent.
            if (this.waypoint.Offset && !chkOffset.Checked)
            {
                var followingWaypoint = this.waypointSystem.Waypoints
                    .Where(existingWaypoint => existingWaypoint.Sequence > this.waypoint.Sequence)
                    .OrderBy(existingWaypoint => existingWaypoint.Sequence)
                    .FirstOrDefault();

                if (followingWaypoint != null && followingWaypoint.Offset)
                {
                    message = "An offset waypoint cannot be changed to a regular waypoint while followed by an offset waypoint";
                    return false;
                }

                message = null;
                return true;
            }

            // Regular waypoint remains regular: no offset-specific validation is needed.
            // Regular -> offset: apply the route-position restrictions for this conversion.
            if (!this.waypoint.Offset && chkOffset.Checked)
            {
                var waypoints = this.waypointSystem.Waypoints
                    .Where(existingWaypoint => existingWaypoint != this.waypoint)
                    .Append(this.waypoint)
                    .OrderBy(existingWaypoint => existingWaypoint.Sequence)
                    .ToList();
                var waypointIndex = waypoints.IndexOf(this.waypoint);

                // Regular -> offset: the first waypoint cannot be an offset waypoint.
                if (waypointIndex == 0)
                {
                    message = "The first waypoint cannot be an offset waypoint";
                    return false;
                }

                // Regular -> offset: reject a waypoint that is immediately followed by an offset.
                if (waypointIndex < waypoints.Count - 1 && waypoints[waypointIndex + 1].Offset)
                {
                    message = "A waypoint followed by an offset waypoint cannot be changed to an offset waypoint";
                    return false;
                }

                // Regular -> offset: reject conversion after offset waypoint number 7.
                var previousWaypoint = waypoints[waypointIndex - 1];
                if (previousWaypoint.Offset && previousWaypoint.Identifier.WaypointOffsetNumber == 7)
                {
                    message = "A waypoint cannot be changed to an offset waypoint after offset 7";
                    return false;
                }
            }

            message = null;
            return true;
        }

        private void CoordinateModeChanged(object? sender, EventArgs e)
        {
            UpdateCoordinateMode();
        }

        private void UpdateCoordinateMode()
        {
            var relativeDirRng = radioButtonRelativeDirRng.Checked;
            var relativeLatLong = radioButtonRelativeLatLong.Checked;
            groupBoxCoordinatesMode.Visible = chkOffset.Checked;
            txtMEA.Enabled = !chkOffset.Checked;
            txtDirection.Enabled = relativeDirRng;
            txtRange.Enabled = relativeDirRng;
            cmbLatitudeDirection.Enabled = relativeLatLong;
            txtRelativeLatitude.Enabled = relativeLatLong;
            cmbLongitudeDirection.Enabled = relativeLatLong;
            txtRelativeLongitude.Enabled = relativeLatLong;
            this.coordinateInputEnabledCallback?.Invoke(!chkOffset.Checked || radioButtonDirectCoordinates.Checked);
            this.timeOverSteerpointEnabledCallback?.Invoke(!chkOffset.Checked);
        }
    }
}
