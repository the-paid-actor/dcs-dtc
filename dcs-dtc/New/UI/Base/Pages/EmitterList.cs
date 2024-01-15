using DTC.UI.Base;
using DTC.Utilities;

namespace DTC.New.UI.Base.Pages;

public partial class EmitterList : UserControl
{
    public delegate void OK(EmitterList sender, int[] selected);
    public delegate void Cancel(EmitterList sender);

    private class GridItem
    {
        public Emitter Emitter;

        public GridItem(Emitter emitter, bool selected)
        {
            Emitter = emitter;
            Checked = selected;
        }

        public bool Checked { get; set; }
        public string Country { get => Emitter.Country; }
        public string F16RWR { get => Emitter.F16RWR; }
        public string Type { get => Emitter.Type; }
        public string Name { get => Emitter.Name; }
        public string NATO { get => Emitter.NATO; }
        public int HARMCode { get => Emitter.HARMCode; }
        public int HTSTable { get => Emitter.HTSTable; }
    }

    private readonly int maxAllowed;
    private readonly bool showHTSColumn;
    private int numSelected;
    private readonly OK okCallback;
    private readonly Cancel cancelCallback;
    private SortableBindingList<GridItem> items = new SortableBindingList<GridItem>();

    public EmitterList(int[] selected, int maxAllowed, bool showHTSColumn, OK okCallback, Cancel cancelCallback, bool showSearch)
    {
        InitializeComponent();
        this.txtSearch.Enter += txtSearch_Enter;
        this.txtSearch.Leave += txtSearch_Leave;
        this.txtSearch.TextChanged += txtSearch_TextChanged;
        this.txtSearch.KeyUp += txtSearch_KeyUP;
        this.txtSearch.KeyDown += txtSearch_KeyDown;

        foreach (var emitter in Emitters.EmittersList)
        {
            var isSelected = false;
            foreach (var sel in selected)
            {
                if (sel == emitter.HARMCode)
                {
                    isSelected = true;
                }
            }

            var item = new GridItem(emitter, isSelected);
            this.items.Add(item);
        }
        if (!showSearch)
        {
            txtSearch.Visible = false;
            datagrid.Size = new Size(547, 355);
        }
        else
        {
            txtSearch.Visible = true;
            //datagrid.Size = new Size(547, 417); 
        }

        datagrid.RefreshList(items);
        datagrid.CellContentClick += Datagrid_CellContentClick;
        this.maxAllowed = maxAllowed;
        this.showHTSColumn = showHTSColumn;
        this.okCallback = okCallback;
        this.cancelCallback = cancelCallback;

        colHTS.Visible = showHTSColumn;
        lblSelected.Visible = !showHTSColumn;

        if (showHTSColumn)
        {
            datagrid.Sort(datagrid.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
        }

        numSelected = selected.Length;
        RefreshSelectedLabel();
    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (!txtSearch.Text.Contains("Search here..."))
            return;

        txtSearch.Text = String.Empty;
        txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
        txtSearch.ForeColor = Color.Black;
    }

    private void txtSearch_KeyUP(object sender, KeyEventArgs e)
    {
        var searchTerm = txtSearch.Text.ToLowerInvariant();
        if (!string.IsNullOrEmpty(searchTerm))
            return;

        txtSearch.Text = "Search here...";
        txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
        txtSearch.ForeColor = Color.Gray;
        this.datagrid.RefreshList(items);
        return;
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        var searchTerm = txtSearch.Text.ToLowerInvariant();
        if (string.IsNullOrEmpty(searchTerm))
            return;

        var searchItems = items.Where(i => i.NATO != null && i.NATO.ToLowerInvariant().Contains(searchTerm)
                                        || i.Country != null && i.Country.ToLowerInvariant().Contains(searchTerm)
                                        || i.F16RWR != null && i.F16RWR.ToLowerInvariant().Contains(searchTerm)
                                        || i.Type != null && i.Type.ToLowerInvariant().Contains(searchTerm)
                                        || i.HARMCode.ToString().Contains(searchTerm)).ToList();

        //var searchItems = items.Where(i => htsTables.Contains(i.HTSTable)).ToList();

        this.datagrid.RefreshList(searchItems);
    }

    private void txtSearch_Leave(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSearch.Text))
            return;

        txtSearch.Text = "Search here...";
        txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
        txtSearch.ForeColor = Color.Gray;
        this.datagrid.RefreshList(items);
    }

    private void txtSearch_Enter(object sender, EventArgs e)
    {
        txtSearch.Text = String.Empty;
        txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
        txtSearch.ForeColor = Color.Black;
    }

    private void RefreshSelectedLabel()
    {
        lblSelected.Text = $"{numSelected} of max {maxAllowed} selected";
    }

    private void Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            var value = (bool)datagrid.Rows[e.RowIndex].Cells[0].Value;

            if (showHTSColumn)
            {
                var htsTable = (int)datagrid.Rows[e.RowIndex].Cells[1].Value;

                for (var i = 0; i < datagrid.RowCount; i++)
                {
                    var row = datagrid.Rows[i];
                    if ((int)row.Cells[1].Value == htsTable)
                    {
                        row.Cells[0].Value = !value;
                    }
                }
            }
            else
            {
                if (value)
                {
                    datagrid.Rows[e.RowIndex].Cells[0].Value = false;
                    numSelected--;
                    RefreshSelectedLabel();
                }
                else
                {
                    if (numSelected < maxAllowed)
                    {
                        datagrid.Rows[e.RowIndex].Cells[0].Value = true;
                        numSelected++;
                        RefreshSelectedLabel();
                    }
                }
            }
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        cancelCallback(this);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        var list = new List<int>();
        foreach (var emitter in items)
        {
            if (emitter.Checked)
            {
                list.Add(emitter.HARMCode);
            }
        }

        okCallback(this, list.ToArray());
    }
}
