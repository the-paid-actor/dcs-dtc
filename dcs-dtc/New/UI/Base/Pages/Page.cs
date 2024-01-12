namespace DTC.New.UI.Base.Pages
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
