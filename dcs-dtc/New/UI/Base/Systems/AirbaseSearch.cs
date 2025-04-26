using DTC.UI.Base.Controls;
using DTC.Utilities;

namespace DTC.New.UI.Base.Systems
{
    public partial class AirbaseSearch : UserControl
    {
        private static int SavedTheaterIndex = 0;
        private static string SavedSearch = string.Empty;

        public class AirbaseListItem
        {
            public string Theater { get; }
            public string Name { get; }
            public string Latitude { get; }
            public string Longitude { get; }
            public int Elevation { get; }
            public AirbaseListItem(string theater, string name, string latitude, string longitude, int elevation)
            {
                Theater = theater;
                Name = name;
                Latitude = latitude;
                Longitude = longitude;
                Elevation = elevation;
            }
        }

        public event Action<AirbaseListItem>? AirbaseSelected;

        public AirbaseSearch()
        {
            InitializeComponent();
            txtSearch.TextChanged += TxtSearch_TextChanged;

            this.grid.SetColumns(
                new DTCGridColumn { Name = "Theater", Width = 90 },
                new DTCGridColumn { Name = "Name" },
                new DTCGridColumn { Name = "Latitude", Width = 90 },
                new DTCGridColumn { Name = "Longitude", Width = 90 },
                new DTCGridColumn { Name = "Elev", DataBindName = "Elevation", Width = 40, Alignment = DataGridViewContentAlignment.MiddleRight });

            cboTheater.Items.Add("Any");

            foreach (var theater in Theater.Theaters)
            {
                cboTheater.Items.Add(theater.Name);
            }

            txtSearch.Text = SavedSearch;
            cboTheater.SelectedIndex = SavedTheaterIndex;

            grid.SetFontSize(9F);
            grid.DoubleClick += Grid_DoubleClick;
        }

        private void Grid_DoubleClick(object? sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0 && grid.SelectedRows[0].DataBoundItem is AirbaseListItem item)
            {
                AirbaseSelected?.Invoke(item);
                this.Visible = false;
            }
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            SavedSearch = txtSearch.Text;
            RefreshGrid();
        }

        private void cboTheater_SelectedIndexChanged(object sender, EventArgs e)
        {
            SavedTheaterIndex = cboTheater.SelectedIndex;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var theater = cboTheater.SelectedItem;
            var search = txtSearch.Text;

            var items = new List<AirbaseListItem>();

            foreach (var ab in Theater.GetAirbaseListItems())
            {
                if ((theater == "Any" || ab.Theatre == theater) && (string.IsNullOrEmpty(search) || ab.Airbase.Contains(search, StringComparison.OrdinalIgnoreCase)))
                {
                    items.Add(new AirbaseListItem(ab.Theatre, ab.Airbase, ab.Latitude, ab.Longitude, ab.Elevation));
                }
            }

            grid.RefreshList(items);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        internal void ShowSearch()
        {
            this.Visible = true;
            txtSearch.Focus();
            txtSearch.SelectAll();
        }
    }
}
