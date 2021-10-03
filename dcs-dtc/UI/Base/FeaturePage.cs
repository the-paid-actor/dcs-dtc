using System.Windows.Forms;

namespace DTC.UI.Base
{
	public class FeaturePage : UserControl
	{
		public delegate void DataChanged();

		protected DataChanged DataChangedCallback;

		public FeaturePage()
		{
		}

		public FeaturePage(DataChanged dataChangedCallback) : base()
		{
			DataChangedCallback = dataChangedCallback;
		}
	}
}
