using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DTC.UI.CommonPages
{
    public partial class CombatFliteFlightSelector : Form
    {
        public string SelectedItem { get; private set; }

        public CombatFliteFlightSelector(string file)
        {
            InitializeComponent();

            // Populate the combobox with the flight names
            var doc = XDocument.Parse(file);
            var flights = doc.XPathSelectElements("//Route").Select(r => r.Element("Name")?.Value);
            comboBoxFlight.Items.AddRange(flights.ToArray<object>());

            // Select the first flight
            comboBoxFlight.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBoxFlight_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedItem = comboBoxFlight.SelectedItem.ToString();
        }

        private void CombatFliteFlightSelector_Load(object sender, EventArgs e)
        {

        }

        private void grpSave_Enter(object sender, EventArgs e)
        {

        }
    }
}
