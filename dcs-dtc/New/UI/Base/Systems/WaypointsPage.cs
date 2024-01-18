using DTC.New.UI.Base.Pages;
using DTC.Utilities;
using DTC.New.UI.Base.Systems.WaypointImport;
using DTC.New.Presets.V2.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems;

public partial class WaypointsPage<T> : WaypointsPageControl where T : class, IWaypoint, new()
{
    private readonly WaypointSystem<T> waypoints;
    private readonly IWaypointEditCustomPanel? customPanel;
    private readonly string title;
    private WaypointEdit<T>? editDialog;

    public WaypointsPage(AircraftPage parent, WaypointSystem<T> waypoints, IWaypointEditCustomPanel? customPanel, string title = "Waypoints") : base(parent)
    {
        this.waypoints = waypoints;
        this.customPanel = customPanel;
        this.title = title;

        this.RefreshList();
    }

    protected override void AddButtonClick(object sender, EventArgs e)
    {
        this.ShowEditDialog();
    }

    protected override void DeleteButtonClick(object sender, EventArgs e)
    {
        this.DeleteSelection();
    }

    protected override void DataGridDoubleClick(object sender, EventArgs e)
    {
        if (this.dgWaypoints.SelectedRows.Count > 0)
        {
            ShowEditDialog((T)this.dgWaypoints.SelectedRows[0].DataBoundItem);
        }
    }

    public override string GetPageTitle()
    {
        return this.title;
    }

    public void RefreshList()
    {
        this.dgWaypoints.RefreshList(this.waypoints.Waypoints);
    }

    private void ShowEditDialog(T? wpt = null)
    {
        this.RemoveEditDialog();

        this.editDialog = new WaypointEdit<T>(this.AfterEdit, this.waypoints, wpt, this.customPanel, this.parent.Aircraft.GetMaxWaypointElevation())
        {
            Location = new Point(0, 0),
            Size = this.Size
        };
        this.Controls.Add(this.editDialog);
        this.editDialog.BringToFront();
        this.editDialog.Focus();
        this.pnlContents.Enabled = false;
    }

    private void AfterEdit()
    {
        RemoveEditDialog();
        this.SavePreset();
        this.RefreshList();
    }

    public override void Shown()
    {
        this.RemoveEditDialog();
    }

    private void RemoveEditDialog()
    {
        this.pnlContents.Enabled = true;
        this.Controls.Remove(this.editDialog);
    }

    protected override void ShiftUp(int[] rows)
    {
        this.waypoints.ShiftUp(rows);
        this.RefreshList();
        this.SelectRows(rows);
        this.SavePreset();
    }

    protected override void ShiftDown(int[] rows)
    {
        this.waypoints.ShiftDown(rows);
        this.RefreshList();
        this.SelectRows(rows);
        this.SavePreset();
    }

    private void DeleteSelection()
    {
        if (!DTCMessageBox.ShowQuestion("Are you sure you want to delete the selected(s) waypoint(s)?"))
        {
            return;
        }

        var wptsToDelete = new List<T>();

        foreach (DataGridViewRow row in this.dgWaypoints.SelectedRows)
        {
            var wpt = (T)row.DataBoundItem;
            wptsToDelete.Add(wpt);
        }

        foreach (var wpt in wptsToDelete)
        {
            this.waypoints.Remove(wpt);
        }

        this.SavePreset();
        this.RefreshList();
        this.dgWaypoints.Focus();
    }

    protected override void ProcessCfImport(ImportDialog dialog)
    {
        var wpts = new List<T>();
        foreach (var cfWpt in dialog.SelectedWaypoints)
        {
            var wpt = this.waypoints.NewWaypoint();
            wpt.Name = cfWpt.Name;
            var coords = cfWpt.Coordinate.ToDegreesMinutesThousandths();
            wpt.Latitude = coords.Lat;
            wpt.Longitude = coords.Lon;
            wpt.Elevation = cfWpt.Elevation;
            wpt.TimeOverSteerpoint = cfWpt.TimeOverSteerpoint;
            wpts.Add(wpt);
        }

        ProcessImport(wpts, dialog.AppendToList, dialog.ReplaceList, dialog.Insert, dialog.InsertAt, dialog.Overwrite, dialog.Shift);
    }

    private void ProcessImport(List<T> wpts, bool append, bool replace, bool insert, int insertAt, bool overwrite, bool shift)
    {
        if (append || replace)
        {
            if (replace)
            {
                this.waypoints.Waypoints.Clear();
            }

            var seq = this.waypoints.GetNextSequence();

            foreach (var wpt in wpts)
            {
                wpt.Sequence = seq++;
                this.waypoints.Add(wpt);
            }
        }
        else if (insert)
        {
            var seq = insertAt;
            var seqEnd = seq + wpts.Count;
            var overlap = this.waypoints.Waypoints.Any(w => w.Sequence >= seq && w.Sequence <= seqEnd);

            var indexToInsert = this.waypoints.Waypoints.FindLastIndex(w => w.Sequence < seq) + 1;
            foreach (var wpt in wpts)
            {
                var other = this.waypoints.GetBySequence(seq);
                if (overlap && other != null)
                {
                    if (shift)
                    {
                        this.waypoints.ShiftSequence(other, seqEnd);
                    }
                    else if (overwrite)
                    {
                        this.waypoints.Waypoints.Remove(other);
                    }
                }

                wpt.Sequence = seq++;
                this.waypoints.Waypoints.Insert(indexToInsert++, wpt);
            }
        }

        this.SavePreset();
        this.RefreshList();
    }

    protected override void DataGridReorder(DTCGridReorderArgs args)
    {
        this.waypoints.Reorder(args.From, args.Between1, args.Between2);
        this.SavePreset();
        this.RefreshList();
    }
}