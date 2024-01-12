
using System.Collections.ObjectModel;

namespace DTC.UI.Base.Controls;

public partial class DTCDataGrid2 : UserControl
{
    private DTCDataGrid grid = new DTCDataGrid();

    public class Column
    {
        private int width;
        private string name;

        public string Name 
        {
            get { return this.name; }
            set
            {
                this.name = value;
                if (string.IsNullOrEmpty(this.DataBindName))
                {
                    this.DataBindName = value;
                }
            }
        }

        public string DataBindName { get; set; }

        public DataGridViewAutoSizeColumnMode AutoSizeMode { get; set; } = DataGridViewAutoSizeColumnMode.Fill;

        public DataGridViewContentAlignment Alignment { get; set; }

        public int Width 
        {
            get { return this.width; }
            set
            {
                this.width = value;
                this.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
        }
    }

    private bool loaded = false;
    public event EventHandler SelectionChanged;
    public ObservableCollection<Column> Columns { get; } = new ObservableCollection<Column>(); 

    public bool Multiselect
    {
        get { return grid.MultiSelect; }
        set { grid.MultiSelect = value; }
    }

    public bool ColumnHeadersVisible
    {
        get { return grid.ColumnHeadersVisible; }
        set { grid.ColumnHeadersVisible = value; }
    }

    public DTCDataGrid2()
    {
        InitializeComponent();
        this.Controls.Add(grid);
        this.Columns.CollectionChanged += (sender, args) => { UpdateColumns(); };

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
        grid.SelectionChanged += Grid_SelectionChanged;
    }

    private void Grid_SelectionChanged(object? sender, EventArgs e)
    {
        if (loaded)
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

    private void UpdateColumns()
    {
        grid.Columns.Clear();
        foreach (var column in Columns)
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

    internal void RefreshList(object dataSource)
    {
        loaded = false;
        grid.RefreshList(dataSource);
        grid.ClearSelection();
        loaded = true;
        SelectionChanged?.Invoke(grid, EventArgs.Empty);
    }
}
