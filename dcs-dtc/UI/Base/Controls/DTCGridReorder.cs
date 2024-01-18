using System.Runtime.InteropServices;

namespace DTC.UI.Base.Controls;

public class DTCGridReorderArgs : EventArgs
{
    public int From { get; set; }
    public int Between1 { get; set; }
    public int Between2 { get; set; }
}

public class DTCGridReorder : DataGridView
{
    private Point? dragStartLocation;
    private Point? dragCurrentLocation;
    private bool mousedown;
    private bool reordering;
    private bool multiselecting;
    private int dragSourceIndex;
    private int dragTarget1Index;
    private int dragTarget2Index;
    private Cursor dragCursor;
    private Label dragBar;

    private System.Windows.Forms.Timer dragTimer = new();

    public event Action<DTCGridReorderArgs> Reorder;

    public bool EnableReorder { get; set; } = false;

    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string dllToLoad);

    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, UInt16 lpCursorName);

    public DTCGridReorder()
    {
        var l = LoadLibrary("ole32.dll");
        dragCursor = new Cursor(LoadCursor(l, 2));

        this.dragBar = new Label
        {
            AutoSize = false,
            BackColor = Color.Black,
            Parent = this,
            Visible = false
        };

        this.Controls.Add(this.dragBar);
        this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        dragTimer.Interval = 250;
        dragTimer.Tick += DragTimer_Tick;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (!HandleMouseDown(e))
        {
        }
    }

    private bool HandleMouseDown(MouseEventArgs e)
    {
        var ht = this.HitTest(e.X, e.Y);

        if (!EnableReorder) return false;
        if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return false;
        if (ht.Type != DataGridViewHitTestType.Cell) return false;

        mousedown = true;
        reordering = false;
        multiselecting = false;

        dragSourceIndex = ht.RowIndex;
        dragStartLocation = new Point(e.X, e.Y);
        dragCurrentLocation = new Point(e.X, e.Y);

        dragTimer.Start();

        return true;
    }

    private void DragTimer_Tick(object? sender, EventArgs e)
    {
        if (!dragTimer.Enabled) return;

        dragTimer.Stop();

        if (multiselecting) return;
        if (dragStartLocation == null) return;
        if (dragCurrentLocation == null) return;

        var ht = this.HitTest(dragCurrentLocation.Value.X, dragCurrentLocation.Value.Y);
        if (ht.RowIndex == dragSourceIndex)
        {
            reordering = true;
            UpdateDragBar();
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (!HandleMouseMove(e))
        {
            base.OnMouseMove(e);
        }
    }

    private bool HandleMouseMove(MouseEventArgs e)
    {
        if (!EnableReorder) return false;
        if (!mousedown) return false;

        dragCurrentLocation = new Point(e.X, e.Y);

        if (reordering)
        {
            UpdateDragBar();
            return true;
        }

        return false;
    }

    protected override void OnDoubleClick(EventArgs e)
    {
        dragTimer.Stop();
        base.OnDoubleClick(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);

        HandleMouseUp();
    }

    private bool HandleMouseUp()
    {
        if (!Enabled) return false;

        dragTimer.Stop();

        if (reordering)
        {
            if (!(dragSourceIndex == dragTarget1Index || dragSourceIndex == dragTarget2Index))
            {
                Reorder?.Invoke(new DTCGridReorderArgs { From = dragSourceIndex, Between1 = dragTarget1Index, Between2 = dragTarget2Index});
            }
        }

        dragBar.Visible = false;
        reordering = false;
        multiselecting = false;
        Cursor.Current = Cursors.Default;

        mousedown = false;

        return true;
    }

    private void UpdateDragBar()
    {
        if (!reordering)
        {
            return;
        }

        if (dragCurrentLocation == null) return;

        var ht = this.HitTest(dragCurrentLocation.Value.X, dragCurrentLocation.Value.Y);

        if (this.SelectedRows.Count == 0 || this.SelectedRows.Count > 1 || this.Rows[dragSourceIndex].Selected == false)
        {
            this.ClearSelection();
            this.Rows[dragSourceIndex].Selected = true;
        }

        Cursor.Current = dragCursor;

        if (ht.Type != DataGridViewHitTestType.Cell) return;

        var top = ht.RowY;
        var bottom = top + this.Rows[ht.RowIndex].Height;
        var center = top + (this.Rows[ht.RowIndex].Height / 2);

        dragBar.Visible = true;
        dragBar.Size = new Size(this.Width, 2);

        if (dragCurrentLocation.Value.Y < center)
        {
            dragTarget1Index = ht.RowIndex - 1;
            dragTarget2Index = ht.RowIndex;
            dragBar.Location = new Point(0, top);
        }
        else
        {
            dragTarget1Index = ht.RowIndex;
            dragTarget2Index = ht.RowIndex + 1;
            dragBar.Location = new Point(0, bottom);
        }
    }
}
