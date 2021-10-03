using System;
using System.Drawing;
using System.Windows.Forms;
using DTC.Models.F16.MFD;
using DTC.UI.Base;

namespace DTC.UI.F16
{
	public partial class MFDPage : FeaturePage
	{
		private MFDSystem _mfd;

		public MFDPage(MFDSystem mfd, DataChanged dataChangedCallback) : base(dataChangedCallback)
		{
			_mfd = mfd;
			InitializeComponent();
			this.SuspendLayout();

			var rowHeight = 35;
			var table = new TableLayoutPanel();
			table.SuspendLayout();
			table.RowCount = 2 + (_mfd.Configurations.Length * 2);
			table.ColumnCount = 6;
			table.Dock = DockStyle.Fill;

			table.Controls.Add(CreateLabel("Mode"), 0, 0);
			table.Controls.Add(CreateLabel("MFD"), 1, 0);
			table.Controls.Add(CreateLabel("Page 1"), 2, 0);
			table.Controls.Add(CreateLabel("Page 2"), 3, 0);
			table.Controls.Add(CreateLabel("Page 3"), 4, 0);
			table.Controls.Add(CreateLabel("Selected Page"), 5, 0);

			for (var i = 0; i < _mfd.Configurations.Length; i++)
			{
				var secondRow = (i + 1) * 2;
				var firstRow = secondRow - 1;
				var config = _mfd.Configurations[i];

				var modeLbl = CreateLabel(config.Mode.ToString());
				table.Controls.Add(modeLbl, 0, firstRow);
				table.SetRowSpan(modeLbl, 2);

				table.Controls.Add(CreateLabel("Left"), 1, firstRow);
				table.Controls.Add(CreateLabel("Right"), 1, secondRow);

				table.Controls.Add(CreatePageList(config.LeftMFD.Page1, (cbo, item) => { config.LeftMFD.Page1 = item; }), 2, firstRow);
				table.Controls.Add(CreatePageList(config.RightMFD.Page1, (cbo, item) => { config.RightMFD.Page1 = item; }), 2, secondRow);

				table.Controls.Add(CreatePageList(config.LeftMFD.Page2, (cbo, item) => { config.LeftMFD.Page2 = item; }), 3, firstRow);
				table.Controls.Add(CreatePageList(config.RightMFD.Page2, (cbo, item) => { config.RightMFD.Page2 = item; }), 3, secondRow);

				table.Controls.Add(CreatePageList(config.LeftMFD.Page3, (cbo, item) => { config.LeftMFD.Page3 = item; }), 4, firstRow);
				table.Controls.Add(CreatePageList(config.RightMFD.Page3, (cbo, item) => { config.RightMFD.Page3 = item; }), 4, secondRow);

				table.Controls.Add(CreateSelectedPageList(config.LeftMFD.SelectedPage, (cbo, item) => { config.LeftMFD.SelectedPage = item; } ), 5, firstRow);
				table.Controls.Add(CreateSelectedPageList(config.RightMFD.SelectedPage, (cbo, item) => { config.RightMFD.SelectedPage = item; }), 5, secondRow);

				table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
				table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
			}

			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
			table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
			table.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

			this.Controls.Add(table);

			table.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private Label CreateLabel(string text)
		{
			var lbl = new Label();
			lbl.Text = text;
			lbl.AutoSize = false;
			lbl.TextAlign = ContentAlignment.MiddleCenter;
			lbl.Dock = DockStyle.Fill;
			lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			return lbl;
		}

		private delegate void ListChangedCallback<T>(ComboBox cbo, T selectedItem);

		private ComboBox CreatePageList(Page page, ListChangedCallback<Page> callback)
		{
			var cbo = new ComboBox();
			foreach (Page p in Enum.GetValues(typeof(Page)))
			{
				cbo.Items.Add(p);
			}
			cbo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			cbo.DropDownStyle = ComboBoxStyle.DropDownList;
			cbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			cbo.Tag = callback;
			cbo.BackColor = Color.White;
			cbo.SelectedItem = page;
			cbo.FlatStyle = FlatStyle.Flat;
			cbo.SelectedIndexChanged += cboPage_SelectedIndexChanged;
			return cbo;
		}

		private void cboPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			var cbo = (ComboBox)sender;
			var callback = (ListChangedCallback<Page>)cbo.Tag;
			callback(cbo, (Page)cbo.SelectedItem);
			DataChangedCallback();
		}

		private void cboSelectedPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			var cbo = (ComboBox)sender;
			var callback = (ListChangedCallback<int>)cbo.Tag;
			callback(cbo, (int)cbo.SelectedItem);
			DataChangedCallback();
		}

		private ComboBox CreateSelectedPageList(int selected, ListChangedCallback<int> callback)
		{
			var cbo = new ComboBox();
			cbo.Items.Add(1);
			cbo.Items.Add(2);
			cbo.Items.Add(3);
			cbo.DropDownStyle = ComboBoxStyle.DropDownList;
			cbo.SelectedItem = selected;
			cbo.BackColor = Color.White;
			cbo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			cbo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10);
			cbo.Tag = callback;
			cbo.FlatStyle = FlatStyle.Flat;
			cbo.SelectedIndexChanged += cboSelectedPage_SelectedIndexChanged;
			return cbo;
		}
	}
}
