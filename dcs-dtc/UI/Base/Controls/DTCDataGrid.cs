using System.Drawing;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
    public class DTCDataGrid : DataGridView
    {
        private Rectangle _dragRectangle;
        private int _dragIndexFrom;
        private int _dragIndexTo;
        private BindingSource _binding = new BindingSource();

        public delegate void Reorder(int indexFrom, int indexTo);

        public Reorder ReorderCallback;

        public DTCDataGrid()
        {
            this.AllowDrop = true;
            this.AutoGenerateColumns = false;
        }

        public void RefreshList(object dataSource)
        {
            _binding.DataSource = dataSource;
            this.DataSource = _binding;
            _binding.ResetBindings(false);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (ReorderCallback != null)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    if (_dragRectangle != Rectangle.Empty && !_dragRectangle.Contains(e.X, e.Y))
                    {
                        this.DoDragDrop(this.Rows[_dragIndexFrom], DragDropEffects.Move);
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (ReorderCallback != null)
            {
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
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);

            if (ReorderCallback != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);

            if (ReorderCallback != null)
            {

                var clientPoint = this.PointToClient(new Point(e.X, e.Y));
                _dragIndexTo = this.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

                if (_dragIndexTo == -1)
                {
                    return;
                }

                if (e.Effect == DragDropEffects.Move)
                {
                    ReorderCallback(_dragIndexFrom, _dragIndexTo);
                    this.ClearSelection();
                    this.Rows[_dragIndexTo].Selected = true;
                }
            }
        }
    }
}
