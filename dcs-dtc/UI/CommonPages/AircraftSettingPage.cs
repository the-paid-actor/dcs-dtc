using System.Windows.Forms;

namespace DTC.UI.CommonPages
{
	public class AircraftSettingPage : UserControl
	{
		public delegate void DataChanged();

		protected readonly AircraftPage _parent;

		public AircraftSettingPage(AircraftPage parent) : base()
		{
			this._parent = parent;
		}

		public AircraftSettingPage()
		{

		}

		public virtual string GetPageTitle()
		{
			return "";
		}
	}
}
