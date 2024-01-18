namespace DTC.UI.Base.Controls;

public class DTCGridShowContextMenuArgs : EventArgs
{
    public Point Location { get; set; }
    public int RowIndex { get; set; }
    public DataGridViewHitTestType HitTestType { get; set; }
}

public class DTCGrid : UserControl
{
    private DTCGridColumn[] columns;

    private DTCGridReorder grid = new();
    private BindingSource dataSource = new BindingSource();
    private bool suppressSelectionChangeEvents;

    public event Action<DTCGridReorderArgs> Reorder;
    public event Action<DTCGridShowContextMenuArgs> ShowContextMenu;
    public event EventHandler SelectionChanged;

    public bool Multiselect
    {
        get { return grid.MultiSelect; }
        set { grid.MultiSelect = value; }
    }

    public bool EnableReorder
    {
        get { return this.grid.EnableReorder; }
        set { this.grid.EnableReorder = value; }
    }

    public bool ColumnHeadersVisible
    {
        get { return grid.ColumnHeadersVisible; }
        set { grid.ColumnHeadersVisible = value; }
    }

    public DTCGrid()
    {
        this.Controls.Add(grid);
        grid.EnableReorder = false;

        var headerStyle = new DataGridViewCellStyle();
        headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        headerStyle.BackColor = Color.DarkKhaki;
        headerStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        headerStyle.ForeColor = Color.Black;
        headerStyle.SelectionBackColor = Color.DarkKhaki;
        headerStyle.SelectionForeColor = Color.Black;
        headerStyle.WrapMode = DataGridViewTriState.False;

        var cellStyle = new DataGridViewCellStyle();
        cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        cellStyle.BackColor = Color.Beige;
        cellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
        cellStyle.ForeColor = SystemColors.ControlText;
        cellStyle.SelectionBackColor = SystemColors.Highlight;
        cellStyle.SelectionForeColor = SystemColors.HighlightText;
        cellStyle.WrapMode = DataGridViewTriState.False;

        grid.Dock = DockStyle.Fill;
        grid.AllowDrop = true;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeColumns = false;
        grid.AllowUserToResizeRows = false;
        grid.AutoGenerateColumns = false;
        grid.BackgroundColor = Color.Beige;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.ColumnHeadersDefaultCellStyle = headerStyle;
        grid.ColumnHeadersHeight = 30;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.DefaultCellStyle = cellStyle;
        grid.EnableHeadersVisualStyles = false;
        grid.ReadOnly = true;
        grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.RowHeadersVisible = false;
        grid.ScrollBars = ScrollBars.Vertical;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.ShowCellToolTips = false;
        grid.StandardTab = true;
        grid.SelectionChanged += GridSelectionChanged;

        this.grid.Reorder += (a) => Reorder?.Invoke(a);
        this.grid.MouseClick += GridMouseClick;
        this.grid.DoubleClick += GridDoubleClick;
    }

    private void GridDoubleClick(object? sender, EventArgs e)
    {
        OnDoubleClick(e);
    }

    private void GridMouseClick(object? sender, MouseEventArgs e)
    {
        var ht = grid.HitTest(e.X, e.Y);
        if (ht.Type != DataGridViewHitTestType.Cell) return;
        if (e.Button != MouseButtons.Right) return;

        ShowContextMenu?.Invoke(new DTCGridShowContextMenuArgs { Location = e.Location, RowIndex = ht.RowIndex, HitTestType = ht.Type});
    }

    private void GridSelectionChanged(object? sender, EventArgs e)
    {
        if (!suppressSelectionChangeEvents)
        {
            SelectionChanged?.Invoke(sender, e);
        }
    }

    public DataGridViewSelectedRowCollection SelectedRows
    {
        get
        {
            return grid.SelectedRows;
        }
    }

    public void RefreshList(object dataSource)
    {
        suppressSelectionChangeEvents = true;

        this.dataSource.DataSource = dataSource;
        grid.DataSource = this.dataSource;
        this.dataSource.ResetBindings(false);

        grid.ClearSelection();
        suppressSelectionChangeEvents = false;
        SelectionChanged?.Invoke(grid, EventArgs.Empty);
    }

    public void ClearSelection()
    {
        grid.ClearSelection();
    }

    public void SetColumns(params DTCGridColumn[] columns)
    {
        this.columns = columns;
        this.UpdateColumns();
    }

    public void SelectAllRows()
    {
        this.grid.SelectAll();
    }

    public void Select(params int[] rowIndex)
    {
        suppressSelectionChangeEvents = true;
        this.grid.ClearSelection();
        for (var i = 0; i < rowIndex.Length; i++)
        {
            this.grid.Rows[rowIndex[i]].Selected = true;
        }
        suppressSelectionChangeEvents = false;
        SelectionChanged?.Invoke(grid, EventArgs.Empty);
    }

    private void UpdateColumns()
    {
        grid.Columns.Clear();
        foreach (var column in this.columns)
        {
            var col = new DataGridViewTextBoxColumn();
            col.DefaultCellStyle.Alignment = column.Alignment;
            col.AutoSizeMode = column.AutoSizeMode;
            col.DataPropertyName = column.DataBindName;
            col.HeaderText = column.Name;
            col.Name = column.Name;
            col.ReadOnly = true;
            col.Width = column.Width;
            grid.Columns.Add(col);
        }
    }
}
