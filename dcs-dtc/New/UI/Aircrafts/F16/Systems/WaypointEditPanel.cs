using DTC.New.Presets.V2.Aircrafts.F16.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Systems;
using DTC.Utilities;

namespace DTC.New.UI.Aircrafts.F16.Systems
{
    public partial class WaypointEditPanel : UserControl, IWaypointEditCustomPanel
    {
        private readonly WaypointSystem waypointSystem;
        private readonly F16Page parent;
        private Waypoint waypoint;

        public WaypointEditPanel(WaypointSystem waypointSystem, F16Page parent)
        {
            InitializeComponent();
            this.waypointSystem = waypointSystem;
            this.parent = parent;
        }

        public Control GetControl()
        {
            return this;
        }

        public void LoadWaypoint(IWaypoint wpt)
        {
            this.waypoint = (Waypoint)wpt;

            this.chkUseOA.Checked = waypoint.UseOA;
            if (waypoint.UseOA)
            {
                this.txtOA1Range.Value = waypoint.OffsetAimpoint1.Range;
                this.txtOA1Bearing.Value = waypoint.OffsetAimpoint1.Bearing;
                this.txtOA1Elev.Value = waypoint.OffsetAimpoint1.Elevation;

                this.txtOA2Range.Value = waypoint.OffsetAimpoint2.Range;
                this.txtOA2Bearing.Value = waypoint.OffsetAimpoint2.Bearing;
                this.txtOA2Elev.Value = waypoint.OffsetAimpoint2.Elevation;
            }

            this.chkUseVIP.Checked = waypoint.UseVIP;

            if (waypoint.UseVIP)
            {
                this.txtVIPtoTGTRange.Value = waypoint.VIPtoTGT.Range;
                this.txtVIPtoTGTBearing.Value = waypoint.VIPtoTGT.Bearing;
                this.txtVIPtoTGTElev.Value = waypoint.VIPtoTGT.Elevation;

                this.txtVIPtoPUPRange.Value = waypoint.VIPtoPUP.Range;
                this.txtVIPtoPUPBearing.Value = waypoint.VIPtoPUP.Bearing;
                this.txtVIPtoPUPElev.Value = waypoint.VIPtoPUP.Elevation;
            }

            this.chkUseVRP.Checked = waypoint.UseVRP;

            if (waypoint.UseVRP)
            {
                this.txtTGTtoVRPRange.Value = waypoint.TGTtoVRP.Range;
                this.txtTGTtoVRPBearing.Value = waypoint.TGTtoVRP.Bearing;
                this.txtTGTtoVRPElev.Value = waypoint.TGTtoVRP.Elevation;

                this.txtTGTtoPUPRange.Value = waypoint.TGTtoPUP.Range;
                this.txtTGTtoPUPBearing.Value = waypoint.TGTtoPUP.Bearing;
                this.txtTGTtoPUPElev.Value = waypoint.TGTtoPUP.Elevation;
            }

            this.UpdateOAVIPVRPPanels();
        }

        private void UpdateOAVIPVRPPanels()
        {
            this.pnlVIP.Visible = this.chkUseVIP.Checked;
            this.pnlVRP.Visible = this.chkUseVRP.Checked;

            var topVIPPanel = this.pnlOA.Top;
            var topVRPPanel = this.pnlOA.Top;

            if (this.pnlOA.Visible)
            {
                topVIPPanel += this.pnlOA.Height;
                topVRPPanel += this.pnlOA.Height;
            }

            this.pnlVIP.Top = topVIPPanel;
            this.pnlVRP.Top = topVRPPanel;
        }

        private void chkUseOA_CheckedChanged(object sender, EventArgs e)
        {
            pnlOA.Visible = chkUseOA.Checked;
            UpdateOAVIPVRPPanels();
        }

        private void chkUseVIP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseVIP.Checked)
            {
                if (!this.ClearVIPVRPOtherWpts())
                {
                    this.chkUseVIP.Checked = false;
                    return;
                }
            }

            if (this.chkUseVIP.Checked && this.chkUseVRP.Checked)
            {
                this.chkUseVRP.Checked = false;
            }

            this.UpdateOAVIPVRPPanels();
        }

        private void chkUseVRP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseVRP.Checked)
            {
                if (!this.ClearVIPVRPOtherWpts())
                {
                    this.chkUseVRP.Checked = false;
                    return;
                }
            }

            if (this.chkUseVRP.Checked && this.chkUseVIP.Checked)
            {
                this.chkUseVIP.Checked = false;
            }

            this.UpdateOAVIPVRPPanels();
        }

        private bool ClearVIPVRPOtherWpts()
        {
            foreach (var wpt in this.waypointSystem.Waypoints)
            {
                if (wpt == this.waypoint) continue;

                if (wpt.UseVIP || wpt.UseVRP)
                {
                    if (DTCMessageBox.ShowQuestion("Only one steerpoint can be designated as VIP or VRP.\nThis will clear VIP/VRP from other steerpoints. Do you want to proceed?"))
                    {
                        wpt.UseVIP = false;
                        wpt.UseVRP = false;
                        this.parent.SavePreset();
                        break;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Save(IWaypoint wpt)
        {
            var f16Wpt = (Waypoint)wpt;

            f16Wpt.UseOA = this.chkUseOA.Checked;

            if (f16Wpt.UseOA)
            {
                if (f16Wpt.OffsetAimpoint1 == null) f16Wpt.OffsetAimpoint1 = new Offset();
                f16Wpt.OffsetAimpoint1.Range = this.txtOA1Range.Value ?? 0;
                f16Wpt.OffsetAimpoint1.Bearing = this.txtOA1Bearing.Value ?? 0;
                f16Wpt.OffsetAimpoint1.Elevation = this.txtOA1Elev.Value ?? 0;

                if (f16Wpt.OffsetAimpoint2 == null) f16Wpt.OffsetAimpoint2 = new Offset();
                f16Wpt.OffsetAimpoint2.Range = this.txtOA2Range.Value ?? 0;
                f16Wpt.OffsetAimpoint2.Bearing = this.txtOA2Bearing.Value ?? 0;
                f16Wpt.OffsetAimpoint2.Elevation = this.txtOA2Elev.Value ?? 0;
            }
            else
            {
                f16Wpt.OffsetAimpoint1 = null;
                f16Wpt.OffsetAimpoint2 = null;
            }

            f16Wpt.UseVIP = this.chkUseVIP.Checked;

            if (f16Wpt.UseVIP)
            {
                if (f16Wpt.VIPtoTGT == null) f16Wpt.VIPtoTGT = new Offset();
                f16Wpt.VIPtoTGT.Range = this.txtVIPtoTGTRange.Value ?? 0;
                f16Wpt.VIPtoTGT.Bearing = this.txtVIPtoTGTBearing.Value ?? 0;
                f16Wpt.VIPtoTGT.Elevation = this.txtVIPtoTGTElev.Value ?? 0;

                if (f16Wpt.VIPtoPUP == null) f16Wpt.VIPtoPUP = new Offset();
                f16Wpt.VIPtoPUP.Range = this.txtVIPtoPUPRange.Value ?? 0;
                f16Wpt.VIPtoPUP.Bearing = this.txtVIPtoPUPBearing.Value ?? 0;
                f16Wpt.VIPtoPUP.Elevation = this.txtVIPtoPUPElev.Value ?? 0;
            }
            else
            {
                f16Wpt.VIPtoTGT = null;
                f16Wpt.VIPtoPUP = null;
            }

            f16Wpt.UseVRP = this.chkUseVRP.Checked;

            if (f16Wpt.UseVRP)
            {
                if (f16Wpt.TGTtoVRP == null) f16Wpt.TGTtoVRP = new Offset();
                f16Wpt.TGTtoVRP.Range = this.txtTGTtoVRPRange.Value ?? 0;
                f16Wpt.TGTtoVRP.Bearing = this.txtTGTtoVRPBearing.Value ?? 0;
                f16Wpt.TGTtoVRP.Elevation = this.txtTGTtoVRPElev.Value ?? 0;

                if (f16Wpt.TGTtoPUP == null) f16Wpt.TGTtoPUP = new Offset();
                f16Wpt.TGTtoPUP.Range = this.txtTGTtoPUPRange.Value ?? 0;
                f16Wpt.TGTtoPUP.Bearing = this.txtTGTtoPUPBearing.Value ?? 0;
                f16Wpt.TGTtoPUP.Elevation = this.txtTGTtoPUPElev.Value ?? 0;
            }
            else
            {
                f16Wpt.TGTtoVRP = null;
                f16Wpt.TGTtoPUP = null;
            }
        }

        public bool Validate(out string? message)
        {
            message = null;
            return true;
        }
    }
}
