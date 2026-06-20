using DTC.New.Presets.V2.Aircrafts.C130.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.C130.Systems;

internal class RoutePage : AircraftSystemPage
{
    private readonly Route route;
    private readonly NumericUpDown numFrom;
    private readonly NumericUpDown numTo;
    private readonly TextBox txtSpecific;
    private readonly RadioButton radAll;
    private readonly RadioButton radRange;
    private readonly RadioButton radSpecific;
    private bool loading;

    public RoutePage(C130Page parent) : base(parent, nameof(parent.Configuration.Route))
    {
        route = parent.Configuration.Route.Route;
        route.Mode = route.Mode == 0 ? RouteMode.UseAll : route.Mode;

        BackColor = Color.PaleGoldenrod;

        radAll = new RadioButton
        {
            Text = "Use all waypoints",
            Location = new Point(15, 15),
            Width = 220
        };
        radRange = new RadioButton
        {
            Text = "Use range",
            Location = new Point(15, 45),
            Width = 220
        };
        radSpecific = new RadioButton
        {
            Text = "Use specific",
            Location = new Point(15, 101),
            Width = 220
        };

        var lblFrom = new Label
        {
            Text = "From",
            Location = new Point(40, 73),
            AutoSize = true
        };
        numFrom = new NumericUpDown
        {
            Location = new Point(82, 70),
            Width = 70,
            Minimum = 1,
            Maximum = 200
        };

        var lblTo = new Label
        {
            Text = "To",
            Location = new Point(165, 73),
            AutoSize = true
        };
        numTo = new NumericUpDown
        {
            Location = new Point(190, 70),
            Width = 70,
            Minimum = 1,
            Maximum = 200
        };

        var lblSpecific = new Label
        {
            Text = "Waypoint sequence list (comma separated)",
            Location = new Point(40, 127),
            AutoSize = true
        };
        txtSpecific = new TextBox
        {
            Location = new Point(40, 151),
            Width = 420
        };

        Controls.Add(radAll);
        Controls.Add(radRange);
        Controls.Add(radSpecific);
        Controls.Add(lblFrom);
        Controls.Add(numFrom);
        Controls.Add(lblTo);
        Controls.Add(numTo);
        Controls.Add(lblSpecific);
        Controls.Add(txtSpecific);

        radAll.CheckedChanged += (_, _) => SaveRoute();
        radRange.CheckedChanged += (_, _) => SaveRoute();
        radSpecific.CheckedChanged += (_, _) => SaveRoute();
        numFrom.ValueChanged += (_, _) => SaveRoute();
        numTo.ValueChanged += (_, _) => SaveRoute();
        txtSpecific.TextChanged += (_, _) => SaveRoute();
        txtSpecific.LostFocus += (_, _) => SaveRoute();

        LoadRoute();
    }

    public override string GetPageTitle()
    {
        return "Route";
    }

    private void LoadRoute()
    {
        loading = true;

        radAll.Checked = route.Mode == RouteMode.UseAll;
        radRange.Checked = route.Mode == RouteMode.UseRange;
        radSpecific.Checked = route.Mode == RouteMode.UseSpecific;

        numFrom.Enabled = route.Mode == RouteMode.UseRange;
        numTo.Enabled = route.Mode == RouteMode.UseRange;
        txtSpecific.Enabled = route.Mode == RouteMode.UseSpecific;

        if (route.Mode == RouteMode.UseRange && route.Waypoints != null && route.Waypoints.Count > 0)
        {
            numFrom.Value = route.Waypoints[0];
            numTo.Value = route.Waypoints.Count > 1 ? route.Waypoints[1] : route.Waypoints[0];
        }

        if (!txtSpecific.Focused)
        {
            txtSpecific.Text = "";
            if (route.Mode == RouteMode.UseSpecific && route.Waypoints != null && route.Waypoints.Count > 0)
            {
                txtSpecific.Text = string.Join(",", route.Waypoints);
            }
        }

        loading = false;
    }

    private void SaveRoute()
    {
        if (loading)
        {
            return;
        }

        route.Waypoints = null;

        if (radAll.Checked)
        {
            route.Mode = RouteMode.UseAll;
        }
        else if (radRange.Checked)
        {
            route.Mode = RouteMode.UseRange;
            route.Waypoints = new List<int> { (int)numFrom.Value, (int)numTo.Value };
        }
        else if (radSpecific.Checked)
        {
            route.Mode = RouteMode.UseSpecific;

            var list = new List<int>();
            var arr = txtSpecific.Text.Split(',');
            foreach (var item in arr)
            {
                if (!int.TryParse(item.Trim(), out var seq))
                {
                    continue;
                }

                if (seq < 1 || seq > 200 || list.Contains(seq))
                {
                    continue;
                }

                list.Add(seq);
            }

            route.Waypoints = list.Count > 0 ? list : null;
        }

        SavePreset();
        LoadRoute();
    }
}
