using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Aircrafts.AH64D.Systems;

public partial class RoutePage : AircraftSystemPage
{
    public RoutePage(AH64DPage parent) : base(parent, nameof(parent.Configuration.Upload))
    {
        InitializeComponent();

        var routeCfg = parent.Configuration.Routes;

        var routeList = Enum.GetValues(typeof(RouteCode)).Cast<RouteCode>();

        var top = 10;

        foreach (var routeCode in routeList)
        {
            var chk = new DTCCheckBox();
            chk.Text = Enum.GetName(typeof(RouteCode), routeCode);
            chk.Location = new Point(10, top);
            this.Controls.Add(chk);

            var routeCtl = new RouteControl();
            routeCtl.Location = new Point(30, top + 30);
            this.Controls.Add(routeCtl);

            top += 120;

            var r = routeCfg.GetByCode(routeCode);
            chk.Checked = r != null;
            routeCtl.Enabled = r != null;

            if (r != null)
            {
                chk.Tag = r;
            }
            else
            {
                chk.Tag = new Route() { Code = routeCode };
            }

            routeCtl.LoadRoute((Route)chk.Tag, SavePreset);

            chk.CheckedChanged += (s, e) =>
            {
                routeCtl.Enabled = chk.Checked;
                if (chk.Checked)
                {
                    routeCfg.Routes.Add((Route)chk.Tag);
                }
                else
                {
                    routeCfg.Routes.Remove((Route)chk.Tag);
                }
            };
        }
    }

    public override string GetPageTitle()
    {
        return "Routes";
    }
}
