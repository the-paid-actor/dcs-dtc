using System.Drawing;
using System.Windows.Forms;
using DTC.Models.F16.Waypoints;

namespace DTC.UI.Base.Controls
{
	public class DTCDataGrid : DataGridView
	{
    private Rectangle _dragRectangle;
    private int _dragIndexFrom;
    private int _dragIndexTo;
    private BindingSource _binding = new BindingSource();
    private WaypointSystem _waypoints;

    public DTCDataGrid()
		{
      this.AllowDrop = true;
		}

    public void SetWaypoints(WaypointSystem wpts)
		{
			_waypoints = wpts;
			RefreshList();
		}

		private void RefreshList()
		{
			_binding.DataSource = _waypoints.Waypoints;
			this.DataSource = _binding;
			_binding.ResetBindings(false);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
      {
        if (_dragRectangle != Rectangle.Empty && !_dragRectangle.Contains(e.X, e.Y))
        {
          this.DoDragDrop(this.Rows[_dragIndexFrom], DragDropEffects.Move);
        }
      }
    }

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

      _dragIndexFrom = this.HitTest(e.X, e.Y).RowIndex;

      if (_dragIndexFrom != -1)
      {
        Size dragSize = SystemInformation.DragSize;
        _dragRectangle = new Rectangle(
          new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
      }
      else
      {
        _dragRectangle = Rectangle.Empty;
      }
    }

		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);

      e.Effect = DragDropEffects.Move;
    }

		protected override void OnDragDrop(DragEventArgs e)
		{
			base.OnDragDrop(e);

      var clientPoint = this.PointToClient(new Point(e.X, e.Y));
      _dragIndexTo = this.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

      if (_dragIndexTo == -1)
      {
        return;
      }

      if (e.Effect == DragDropEffects.Move)
      {
        _waypoints.Reorder(_dragIndexFrom, _dragIndexTo);
        RefreshList();
      }
    }
  }
}
