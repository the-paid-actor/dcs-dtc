using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTC.UI.CommonPages
{
	public partial class WaypointDatabase : UserControl
	{
		public WaypointDatabase()
		{
			InitializeComponent();
		}

		private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
		{
			btnAddSubfolder.Enabled = false;
			btnRenameFolder.Enabled = false;
			btnRemoveFolder.Enabled = false;

			if (treeFolders.SelectedNode != null)
			{
				btnAddSubfolder.Enabled = true;
				btnRenameFolder.Enabled = true;
				btnRemoveFolder.Enabled = true;
			}
		}
	}
}
