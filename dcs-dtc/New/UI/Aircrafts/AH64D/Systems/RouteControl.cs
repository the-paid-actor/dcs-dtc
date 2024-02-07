
using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

public partial class RouteControl : UserControl
{
    private Action saveCallback;
    private bool loading = false;

    public RouteControl()
    {
        InitializeComponent();
    }

    public void LoadRoute(Route route, Action saveCallback)
    {
        this.InternalLoad(route);

        this.saveCallback = saveCallback;

        this.radAll.CheckedChanged += (sender, args) => this.Save(route);
        this.radRange.CheckedChanged += (sender, args) => this.Save(route);
        this.radSpecific.CheckedChanged += (sender, args) => this.Save(route);

        this.txtFrom.TextBoxChanged += (sender) => this.Save(route);
        this.txtTo.TextBoxChanged += (sender) => this.Save(route);
        this.txtWpts.LostFocus += (sender, args) => this.Save(route);

        this.chkWpts.CheckedChanged += (sender, args) => this.Save(route);
        this.chkHazards.CheckedChanged += (sender, args) => this.Save(route);
        this.chkCM.CheckedChanged += (sender, args) => this.Save(route);
    }

    private void Save(Route route)
    {
        if (this.loading) return;

        route.Waypoints = null;

        if (this.radAll.Checked)
        {
            route.Mode = RouteMode.UseAll;
        }
        else if (this.radRange.Checked)
        {
            route.Mode = RouteMode.UseRange;

            if (this.txtFrom.Value != null)
            {
                route.Waypoints = new() { (int)this.txtFrom.Value };
                if (this.txtTo.Value != null)
                {
                    route.Waypoints.Add((int)this.txtTo.Value);
                }
            }
            else
            {
                this.txtTo.Value = null;
            }
        }
        else if (this.radSpecific.Checked)
        {
            route.Mode = RouteMode.UseSpecific;
            if (!string.IsNullOrEmpty(this.txtWpts.Text))
            {
                var list = new List<int>();
                var arr = this.txtWpts.Text.Split(',');
                if (arr.Length > 0)
                {
                    foreach (var item in arr)
                    {
                        if (int.TryParse(item.Trim(), out int n))
                        {
                            if (!list.Contains(n)) list.Add(n);
                        }
                    }
                    if (list.Count > 0)
                    {
                        route.Waypoints = list;
                    }
                }
            }
        }

        route.IncludeAllWaypoints = chkWpts.Checked;
        route.IncludeAllHazards = chkHazards.Checked;
        route.IncludeAllControlMeasures = chkCM.Checked;

        this.saveCallback();

        this.InternalLoad(route);
    }

    private void InternalLoad(Route route)
    {
        this.loading = true;

        this.radAll.Checked = route.Mode == RouteMode.UseAll;
        this.radRange.Checked = route.Mode == RouteMode.UseRange;
        this.radSpecific.Checked = route.Mode == RouteMode.UseSpecific;

        txtFrom.Value = null;
        txtTo.Value = null;

        if (route.Mode == RouteMode.UseRange && route.Waypoints?.Count > 0)
        {
            txtFrom.Value = route.Waypoints[0];
            if (route.Waypoints.Count > 1)
            {
                txtTo.Value = route.Waypoints[1];
            }
        }

        this.txtFrom.Enabled = route.Mode == RouteMode.UseRange;
        this.txtTo.Enabled = txtFrom.Value != null;

        this.txtWpts.Text = "";

        if (route.Mode == RouteMode.UseSpecific && route.Waypoints?.Count > 0)
        {
            this.txtWpts.Text = string.Join(",", route.Waypoints);
        }

        this.txtWpts.Enabled = route.Mode == RouteMode.UseSpecific;

        chkWpts.Checked = route.IncludeAllWaypoints;
        chkHazards.Checked = route.IncludeAllHazards;
        chkCM.Checked = route.IncludeAllControlMeasures;

        chkWpts.Enabled = route.Mode == RouteMode.UseAll;
        chkHazards.Enabled = route.Mode == RouteMode.UseAll;
        chkCM.Enabled = route.Mode == RouteMode.UseAll;

        this.loading = false;
    }
}
