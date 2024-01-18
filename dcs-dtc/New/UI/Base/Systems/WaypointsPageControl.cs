using DTC.New.UI.Base.Pages;
using DTC.New.UI.Base.Systems.WaypointImport;
using DTC.New.UI.Base.Systems.WaypointImport.Types;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Systems;

public partial class WaypointsPageControl : AircraftSystemPage
{
    public WaypointsPageControl()
    {
        this.InitializeComponent();
    }

    public WaypointsPageControl(AircraftPage parent) : base(parent)
    {
        this.InitializeComponent();

        this.dgWaypoints.EnableReorder = true;

        this.dgWaypoints.SetColumns(
            new DTCGridColumn { Name = "Seq", DataBindName = "Sequence", Width = 40 },
            new DTCGridColumn { Name = "Name" },
            new DTCGridColumn { Name = "Latitude", Width = 100 },
            new DTCGridColumn { Name = "Longitude", Width = 110 },
            new DTCGridColumn { Name = "Elev", DataBindName = "Elevation", Width = 55, Alignment = DataGridViewContentAlignment.MiddleRight },
            new DTCGridColumn { Name = "", DataBindName = "ExtraDescription", Width = 100 });

        //this.btnImport.Items.Add(new DTCDropDownButton.MenuItem("From DTC file...", () =>
        //{
        //}));

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
    }

    protected void SelectRows(int[] rows)
    {
        this.dgWaypoints.Select(rows);
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
        if (args.HitTestType == DataGridViewHitTestType.Cell)
        {
            if (!IsRowSelected(args.RowIndex))
            {
                dgWaypoints.ClearSelection();
                dgWaypoints.Select(args.RowIndex);
            }
            contextMenu.Show(dgWaypoints, args.Location);
        }
    }
}
