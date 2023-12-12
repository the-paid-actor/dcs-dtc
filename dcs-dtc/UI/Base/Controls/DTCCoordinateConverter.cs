using DTC.Utilities;

namespace DTC.UI.Base.Controls
{
    public partial class DTCCoordinateConverter : UserControl
    {
        private DTCCoordinateTextBox2 textbox;
        private Coordinate? coordinate;

        public DTCCoordinateConverter()
        {
            InitializeComponent();

            txtLatLongDDMMMMM.Validated += TextBox_Validated;
            txtLatLongDDMMSS.Validated += TextBox_Validated;
            txtLatLongDDMMSSSS.Validated += TextBox_Validated;
            txtMGRS.Validated += TextBox_Validated;
        }

        private void TextBox_Validated(object? sender, EventArgs e)
        {
            var c = ((DTCCoordinateTextBox2)sender).Coordinate;
            UpdateCoordinate(c);
        }

        private void UpdateCoordinate(Coordinate? c)
        {
            this.coordinate = c;
            txtLatLongDDMMMMM.Coordinate = c;
            txtLatLongDDMMSS.Coordinate = c;
            txtLatLongDDMMSSSS.Coordinate = c;
            txtMGRS.Coordinate = c;
        }

        public void ShowConverter(Coordinate? c, DTCCoordinateTextBox2 textbox)
        {
            this.Visible = true;
            this.BringToFront();
            this.Focus();
            this.textbox = textbox;
            UpdateCoordinate(c);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Visible = false;
            this.textbox.Coordinate = this.coordinate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Visible = false;
        }
    }
}
