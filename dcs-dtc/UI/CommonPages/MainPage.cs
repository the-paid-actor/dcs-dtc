using DTC.Models.Presets;

namespace DTC.UI.CommonPages
{
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public override string PageTitle => "Home";

		private void btnF16_Click(object sender, System.EventArgs e)
		{
			MainForm.AddPage(new PresetsPage(PresetsStore.GetAircraft(AircraftModel.F16C)));
		}

		private void btnF18_Click(object sender, System.EventArgs e)
		{
			MainForm.AddPage(new PresetsPage(PresetsStore.GetAircraft(AircraftModel.FA18C)));
		}

		private void btnWptDatabase_Click(object sender, System.EventArgs e)
		{
			MainForm.AddPage(new WaypointDatabase());
		}
	}
}