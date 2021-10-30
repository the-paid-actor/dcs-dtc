using System.Windows.Forms;

namespace DTC.UI.CommonPages
{
	public class Page : UserControl
	{
		public virtual string PageTitle
		{
			get { return ""; }
		}

		public MainForm MainForm
		{
			get { return (MainForm)this.ParentForm; }
		}
	}
}
