using DTC.Models.DCS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DTC.UI.Base
{
	public partial class EmitterList : UserControl
	{
		public delegate void OK(EmitterList sender, int[] selected);
		public delegate void Cancel(EmitterList sender);

		private class GridItem
		{
			public Emitter Emitter;

			public GridItem(Emitter emitter, bool selected)
			{
				Emitter = emitter;
				Checked = selected;
			}

			public bool Checked { get; set; }
			public string Country { get => Emitter.Country; }
			public string F16RWR { get => Emitter.F16RWR; }
			public string Type { get => Emitter.Type; }
			public string Name { get => Emitter.Name; }
			public string NATO { get => Emitter.NATO; }
			public int HARMCode { get => Emitter.HARMCode; }
			public int HTSTable { get => Emitter.HTSTable; }
		}

		private readonly int maxAllowed;
		private readonly bool showHTSColumn;
		private int numSelected;
		private readonly OK okCallback;
		private readonly Cancel cancelCallback;
		private SortableBindingList<GridItem> items = new SortableBindingList<GridItem>();

		public EmitterList(int[] selected, int maxAllowed, bool showHTSColumn, OK okCallback, Cancel cancelCallback)
		{
			InitializeComponent();

			foreach (var emitter in Emitters.EmittersList)
			{
				var isSelected = false;
				foreach (var sel in selected)
				{
					if (sel == emitter.HARMCode)
					{
						isSelected = true;
					}
				}

				var item = new GridItem(emitter, isSelected);
				this.items.Add(item);
			}

			datagrid.RefreshList(items);
			datagrid.CellContentClick += Datagrid_CellContentClick;
			this.maxAllowed = maxAllowed;
			this.showHTSColumn = showHTSColumn;
			this.okCallback = okCallback;
			this.cancelCallback = cancelCallback;

			colHTS.Visible = showHTSColumn;
			lblSelected.Visible = !showHTSColumn;

			if (showHTSColumn)
			{
				datagrid.Sort(datagrid.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
			}

			numSelected = selected.Length;
			RefreshSelectedLabel();
		}

		private void RefreshSelectedLabel()
		{
			lblSelected.Text = $"{numSelected} of max {maxAllowed} selected";
		}

		private void Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				var value = (bool)datagrid.Rows[e.RowIndex].Cells[0].Value;

				if (showHTSColumn)
				{
					var htsTable = (int)datagrid.Rows[e.RowIndex].Cells[1].Value;

					for (var i = 0; i < datagrid.RowCount; i++)
					{
						var row = datagrid.Rows[i];
						if ((int)row.Cells[1].Value == htsTable)
						{
							row.Cells[0].Value = !value;
						}
					}
				}
				else
				{
					if (value)
					{
						datagrid.Rows[e.RowIndex].Cells[0].Value = false;
						numSelected--;
						RefreshSelectedLabel();
					}
					else
					{
						if (numSelected < maxAllowed)
						{
							datagrid.Rows[e.RowIndex].Cells[0].Value = true;
							numSelected++;
							RefreshSelectedLabel();
						}
					}
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			cancelCallback(this);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			var list = new List<int>();
			foreach (var emitter in items)
			{
				if (emitter.Checked)
				{
					list.Add(emitter.HARMCode);
				}
			}

			okCallback(this, list.ToArray());
		}
	}
}
