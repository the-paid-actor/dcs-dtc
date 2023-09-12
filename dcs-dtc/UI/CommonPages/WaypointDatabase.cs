using DTC.Utilities;
using System;
using System.Windows.Forms;

namespace DTC.UI.CommonPages
{
	public partial class WaypointDatabase : Page
	{
		private class TheaterNode { };
		private class AirbaseNode { };

		public WaypointDatabase()
		{
			InitializeComponent();

			var theaters = FileStorage.LoadAirbases();

			foreach(var theater in theaters)
			{
				var theaterNode = treeFolders.Nodes.Add(theater.Name);
				theaterNode.Tag = new TheaterNode();
				var airbasesNode = theaterNode.Nodes.Add("Airbases");
				airbasesNode.Tag = new AirbaseNode();
			}
		}

		public override string PageTitle => "Waypoints Database";

		private void treeFolders_AfterSelect(object sender, TreeViewEventArgs e)
		{
			btnAddSubfolder.Enabled = false;
			btnRenameFolder.Enabled = false;
			btnRemoveFolder.Enabled = false;

			if (treeFolders.SelectedNode != null)
			{
				if (treeFolders.SelectedNode.Tag is TheaterNode)
				{
					btnAddSubfolder.Enabled = true;
				}
				else if (treeFolders.SelectedNode.Tag is AirbaseNode)
				{
				}
				else
				{
					btnRenameFolder.Enabled = true;
					btnRemoveFolder.Enabled = true;
				}
			}
		}

		private void AddSubFolder()
		{
			var dialog = new PresetName();
			this.Controls.Add(dialog);
			dialog.Left = (this.Width / 2) - (dialog.Width / 2);
			dialog.Top = (this.Height / 2) - (dialog.Height / 2);
			dialog.txtName.Focus();
			dialog.BringToFront();

			pnlContent.Enabled = false;

			dialog.DialogResultCallback = (DialogResult result) =>
			{
				if (result == DialogResult.OK)
				{
					treeFolders.SelectedNode.Nodes.Add(dialog.txtName.Text);
				}
				this.Controls.Remove(dialog);
				pnlContent.Enabled = true;
			};
		}

		private void btnAddSubfolder_Click(object sender, EventArgs e)
		{
			AddSubFolder();
		}
	}
}
