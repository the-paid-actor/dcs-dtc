using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems.WaypointImport;

public partial class ImportDialog : UserControl
{
    private Action<bool>? callback;

    public ImportDialog()
    {
        this.InitializeComponent();

        this.Dock = DockStyle.Fill;

        this.gridRoutes.SetColumns(
            new DTCGridColumn { Name = "Name" },
            new DTCGridColumn { Name = "Aircraft" });
        this.gridRoutes.Multiselect = false;
        this.gridRoutes.ColumnHeadersVisible = false;
        this.gridRoutes.SelectionChanged += GridRoutes_SelectionChanged;

        this.gridWaypoints.SetColumns(
            new DTCGridColumn { Name = "Seq", DataBindName = "Sequence", Width = 50 },
            new DTCGridColumn { Name = "Name", Width = 200 },
            new DTCGridColumn { Name = "Coordinate", DataBindName = "CoordinateString" },
            new DTCGridColumn { Name = "Elevation", Width = 75 });
        this.gridWaypoints.Multiselect = true;

        this.radInsert.Checked = true;
        this.radAppend.Checked = true;
        this.radOverwrite.Checked = true;
        this.txtInsertAt.Value = 1;
    }

    private void GridRoutes_SelectionChanged(object? sender, EventArgs e)
    {
        if (this.gridRoutes.SelectedRows.Count > 0)
        {
            this.gridWaypoints.RefreshList(((ImportRoute)this.gridRoutes.SelectedRows[0].DataBoundItem).Waypoints);
            this.gridWaypoints.SelectAllRows();
        }
    }

    public void Show(ImportRoute[] routes, Action<bool> callback)
    {
        this.BringToFront();
        this.callback = callback;
        this.gridRoutes.RefreshList(routes);
    }

    private void radInsert_CheckedChanged(object sender, EventArgs e)
    {
        this.pnlInsert.Enabled = this.radInsert.Checked;
        this.txtInsertAt.Enabled = this.radInsert.Checked;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        if (this.callback != null)
            this.callback(false);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (this.SelectedWaypoints.Length == 0)
        {
            this.lblError.Text = "No waypoints selected.";
            return;
        }

        if (this.callback != null)
            this.callback(true);
    }

    public ImportWaypoint[] SelectedWaypoints
    {
        get
        {
            var waypoints = new List<ImportWaypoint>();
            foreach (DataGridViewRow row in this.gridWaypoints.SelectedRows)
            {
                waypoints.Add((ImportWaypoint)row.DataBoundItem);
            }
            waypoints.Sort((a, b) => a.Sequence.CompareTo(b.Sequence));
            return waypoints.ToArray();
        }
    }

    public bool AppendToList => this.radAppend.Checked;
    public bool ReplaceList => this.radReplace.Checked;
    public bool Insert => this.radInsert.Checked;
    public int InsertAt => (int)(this.txtInsertAt.Value ?? 0);
    public bool Overwrite => this.radOverwrite.Checked;
    public bool Shift => this.radShift.Checked;
}
