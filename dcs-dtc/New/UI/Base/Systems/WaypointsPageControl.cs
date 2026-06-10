using DTC.Models.v476;
using DTC.New.Presets.V2.Aircrafts.F15E;
using DTC.New.Presets.V2.Aircrafts.F15E.Systems;
using DTC.New.Presets.V2.Aircrafts.F16;
using DTC.New.Presets.V2.Aircrafts.FA18;
using DTC.New.Presets.V2.Base;
using DTC.New.UI.Aircrafts.F16;
using DTC.New.UI.Aircrafts.F16.Systems;
using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems.WaypointImport;
using DTC.New.UI.Base.Systems.WaypointImport.Types;
using DTC.UI.Base.Controls;
using DTC.Utilities.Extensions;
using Waypoint = DTC.New.Presets.V2.Aircrafts.F16.Systems.Waypoint;

namespace DTC.New.UI.Base.Systems;

public partial class WaypointsPageControl : AircraftSystemPage
{
    private readonly string systemName;

    public WaypointsPageControl()
    {
        this.InitializeComponent();
    }

    private void importViper(string clipboardContent, F16Configuration f16Config)
    {
        WaypointSystemParser parser = new WaypointSystemParser();
        f16Config.Waypoints.Waypoints.Clear();

        foreach (var waypoint in parser.parseForF16(clipboardContent))
        {
            Waypoint w = new()
            {
                Elevation = waypoint.Elevation,
                Latitude = waypoint.Latitude,
                Longitude = waypoint.Longitude,
                Name = waypoint.Name,
                Sequence = waypoint.Sequence
            };
            f16Config.Waypoints.Add(w);
        }

        if (parser.PilotPosition != -1)
        {
            f16Config.Datalink.OwnshipIndex = parser.PilotPosition;
            if (parser.PilotPosition == 1)
                f16Config.Datalink.FlightLead = true;
            else
                f16Config.Datalink.FlightLead = false;
        }

        if (!string.IsNullOrEmpty(parser.FlightCallsign))
        {
            f16Config.Datalink.OwnCallsign = parser.FlightCallsign[0].ToString().ToUpper() +
                                             parser.FlightCallsign[parser.FlightCallsign.Length - 3].ToString()
                                                 .ToUpper() +
                                             parser.FlightCallsign[parser.FlightCallsign.Length - 1].ToString() +
                                             parser.PilotPosition.ToString();
        }

        f16Config.Datalink.EnableMembers = true;
        f16Config.Datalink.Members = new string[8];
        f16Config.Datalink.OwnshipIndex = parser.PilotPosition;
        for (int i = 0; i < parser.FlightTNs.Length; i++)
        {
            if (!string.IsNullOrEmpty(parser.FlightTNs[i]))
            {
                f16Config.Datalink.Members[i] = parser.FlightTNs[i];
            }
        }

        this.dgWaypoints.RefreshList(f16Config.Waypoints.Waypoints);
        F16Page pag = this.parent as F16Page;
        DatalinkPage dlp = (DatalinkPage)pag.GetPageOfTitle("Datalink");
        //dlp.datali
        dlp.Datalink = f16Config.Datalink;
        dlp.ForceSavePresets();
        dlp.RefreshDatalinkConfig();
    }

    private void importHornet(string clipboardContent, FA18Configuration f18Config)
    {
        WaypointSystemParser parser = new WaypointSystemParser();
        f18Config.Waypoints.Waypoints.Clear();
        foreach (var waypoint in parser.parseForFA18(clipboardContent))
        {
            Presets.V2.Aircrafts.FA18.Systems.Waypoint w = new()
            {
                Elevation = waypoint.Elevation,
                Latitude = waypoint.Latitude,
                Longitude = waypoint.Longitude,
                Name = waypoint.Name,
                Sequence = waypoint.Sequence
            };
            f18Config.Waypoints.Add(w);
        }

        this.dgWaypoints.RefreshList(f18Config.Waypoints.Waypoints);
    }

    private WaypointSystem whichEagleRoute(F15EConfiguration f15config)
    {
        switch (systemName)
        {
            case "RouteA":
                return f15config.RouteA;
            case "RouteB":
                return f15config.RouteB;
            case "RouteC":
                return f15config.RouteC;
            default:
                throw new ArgumentException("Should never get there, F15 has 3 routes.");
        }
    }

    private void importEagle(string clipboardContent, F15EConfiguration f15config)
    {
        WaypointSystemParser parser = new WaypointSystemParser();
        var route = whichEagleRoute(f15config);
        route.Waypoints.Clear();
        foreach (var waypoint in parser.parseForFA18(clipboardContent))
        {
            Presets.V2.Aircrafts.F15E.Systems.Waypoint w = new()
            {
                Elevation = waypoint.Elevation,
                Latitude = waypoint.Latitude,
                Longitude = waypoint.Longitude,
                Name = waypoint.Name,
                Sequence = waypoint.Sequence
            };
            route.Waypoints.Add(w);
        }

        this.dgWaypoints.RefreshList(route.Waypoints);
    }

    public WaypointsPageControl(AircraftPage parent, string systemName) : base(parent, systemName)
    {
        this.InitializeComponent();

        this.dgWaypoints.EnableReorder = true;
        this.systemName = systemName;

        this.dgWaypoints.SetColumns(
            new DTCGridColumn { Name = "Seq", DataBindName = "Sequence", Width = 40 },
            new DTCGridColumn { Name = "Name" },
            new DTCGridColumn { Name = "Latitude", Width = 100 },
            new DTCGridColumn { Name = "Longitude", Width = 110 },
            new DTCGridColumn
            {
                Name = "Elev", DataBindName = "Elevation", Width = 55,
                Alignment = DataGridViewContentAlignment.MiddleRight
            },
            new DTCGridColumn { Name = "", DataBindName = "ExtraDescription", Width = 100 });

        this.btnImport.Items.Add(new DTCDropDownButton.MenuItem("From 476th MDC", () =>
        {
            Configuration baseConfig = this.parent.Configuration;
            var clipboardContent = Clipboard.GetText();

            switch (baseConfig)
            {
                case F16Configuration config:
                    importViper(clipboardContent, config);
                    break;
                case F15EConfiguration config:
                    importEagle(clipboardContent, config);
                    break;
                case FA18Configuration config:
                    importHornet(clipboardContent, config);
                    break;
            }
        }));

        this.btnImport.Items.Add(new DTCDropDownButton.MenuItem("From CombatFlite...", () =>
        {
            var routes = CombatFlite.Import();
            if (routes != null)
            {
                var dialog = new ImportDialog();
                this.Controls.Add(dialog);
                this.pnlContents.Enabled = false;
                dialog.Show(routes, (bool success) =>
                {
                    if (success)
                    {
                        this.ProcessCfImport(dialog);
                    }

                    this.Controls.Remove(dialog);
                    this.pnlContents.Enabled = true;
                });
            }
        }));

        this.btnImport.Items.Add(new DTCDropDownButton.MenuItem("From CombatFlite XML Export...", () =>
        {
            var routes = CombatFliteXML.Import();
            if (routes != null)
            {
                var dialog = new ImportDialog();
                this.Controls.Add(dialog);
                this.pnlContents.Enabled = false;
                dialog.Show(routes, (bool success) =>
                {
                    if (success)
                    {
                        this.ProcessCfImport(dialog);
                    }

                    this.Controls.Remove(dialog);
                    this.pnlContents.Enabled = true;
                });
            }
        }));

        shiftUpMenu.Click += (s, e) => this.ShiftUp(GetSelectedRows());
        shiftDownMenu.Click += (s, e) => this.ShiftDown(GetSelectedRows());
        copyMenu.Click += (s, e) => this.CopyWaypoints(GetSelectedRows());
        pasteMenu.Click += (s, e) => this.PasteWaypoints();
    }

    protected virtual void PasteWaypoints()
    {
        throw new NotImplementedException();
    }

    protected void SelectRows(int[] rows)
    {
        this.dgWaypoints.Select(rows);
    }

    protected virtual void InsertButtonClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected virtual void AddButtonClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected virtual void DeleteButtonClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected virtual void DataGridDoubleClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    protected virtual void DataGridReorder(DTCGridReorderArgs args)
    {
        throw new NotImplementedException();
    }

    protected virtual void ShiftUp(int[] rows)
    {
        throw new NotImplementedException();
    }

    protected virtual void ShiftDown(int[] rows)
    {
        throw new NotImplementedException();
    }

    protected virtual void ProcessCfImport(ImportDialog cfDialog)
    {
        throw new NotImplementedException();
    }

    protected virtual void CopyWaypoints(int[] ints)
    {
        throw new NotImplementedException();
    }

    private void DataGridSelectionChanged(object sender, EventArgs e)
    {
        this.btnDelete.Enabled = this.dgWaypoints.Enabled && this.dgWaypoints.SelectedRows.Count > 0;
    }

    private bool IsRowSelected(int rowIndex)
    {
        return dgWaypoints.SelectedRows.Cast<DataGridViewRow>().Any(r => r.Index == rowIndex);
    }

    private int[] GetSelectedRows()
    {
        return dgWaypoints.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Index).Order().ToArray();
    }

    private void DataGridShowContextMenu(DTCGridShowContextMenuArgs args)
    {
        shiftUpMenu.Visible = false;
        shiftDownMenu.Visible = false;
        copyMenu.Visible = false;
        pasteMenu.Visible = false;

        if (args.HitTestType == DataGridViewHitTestType.Cell)
        {
            shiftUpMenu.Visible = true;
            shiftDownMenu.Visible = true;
            copyMenu.Visible = true;

            if (this.IsClipboardWaypointsValid())
            {
                pasteMenu.Visible = true;
            }

            if (!IsRowSelected(args.RowIndex))
            {
                dgWaypoints.ClearSelection();
                dgWaypoints.Select(args.RowIndex);
            }

            contextMenu.Show(dgWaypoints, args.Location);
        }
        else if (args.HitTestType == DataGridViewHitTestType.None)
        {
            if (this.IsClipboardWaypointsValid())
            {
                pasteMenu.Visible = true;
                contextMenu.Show(dgWaypoints, args.Location);
            }
        }

        contextMenu.Items.CleanUpSeparators();
    }

    protected virtual bool IsClipboardWaypointsValid()
    {
        throw new NotImplementedException();
    }

    protected virtual void ClearButtonClick(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}