using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
	public partial class DTCBreadCrumb : UserControl
	{
		private Stack<Crumb> _crumbs = new Stack<Crumb>();

		public delegate void CrumbCallback();

		public class Crumb
		{
			public string Label;
			public CrumbCallback Callback;

			public Crumb(string label, CrumbCallback callback)
			{
				Label = label;
				Callback = callback;
			}
		}

		public DTCBreadCrumb()
		{
			InitializeComponent();
		}

		public void SetCrumbs(params Crumb[] crumbs)
		{
			_crumbs = new Stack<Crumb>(crumbs);
			RefreshCrumbs();
		}

		public void AddCrumb(Crumb crumb)
		{
			_crumbs.Push(crumb);
			RefreshCrumbs();
		}

		public void PopCrumb()
		{
			_crumbs.Pop();
			RefreshCrumbs();
		}

		private void RefreshCrumbs()
		{
			this.Controls.Clear();

			var padding = 5;
			var left = padding;

			var cArr = _crumbs.ToArray();
			Array.Reverse(cArr);

			for (int i = 0; i < cArr.Length; i++)
			{
				Crumb crumb = cArr[i];
				var lbl = new LinkLabel();
				lbl.Font = new Font("Microsoft Sans Serif", 12);
				lbl.Location = new Point(left, padding);
				lbl.Text = crumb.Label;
				lbl.LinkColor = Color.Black;
				lbl.ActiveLinkColor = Color.Brown;
				lbl.Click += (object sender, EventArgs e) =>
				{
					crumb.Callback();
				};
				lbl.AutoSize = true;
				left += lbl.PreferredWidth + padding;
				this.Controls.Add(lbl);

				if ((i + 1) < cArr.Length)
				{
					var lbl2 = DTCLabel.Make(">", left, padding + 2);
					left += lbl2.PreferredWidth + padding;
					this.Controls.Add(lbl2);
				}
			}
		}
	}
}
