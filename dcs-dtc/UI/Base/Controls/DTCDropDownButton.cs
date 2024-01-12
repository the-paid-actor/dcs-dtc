using System.Collections.ObjectModel;

namespace DTC.UI.Base.Controls;

public class DTCDropDownButton : DTCButton
{
    public class MenuItem
    {
        public string Text { get; set; }
        public Action Callback { get; private set; }

        public MenuItem(string text, Action callback)
        {
            this.Text = text;
            this.Callback = callback;
        }
    }

    public ObservableCollection<MenuItem> Items { get; } = new();

    private ContextMenuStrip menu;
    private bool rebuildMenu = false;

    public DTCDropDownButton()
    {
        this.Items.CollectionChanged += (sender, args) => { this.rebuildMenu = true; } ;
        this.menu = new ContextMenuStrip();
        this.menu.BackColor = this.BackColor;
        this.menu.ShowImageMargin = false;
        this.menu.Font = this.Font;
    }

    private void RebuildMenu()
    {
        if (!this.rebuildMenu) return;

        this.menu.Items.Clear();
        this.rebuildMenu = false;

        foreach (var item in this.Items)
        {
            var menuItem = new ToolStripMenuItem(item.Text);
            menuItem.Click += (s, e) => item.Callback();
            this.menu.Items.Add(menuItem);
        }
    }

    protected override void OnMouseDown(MouseEventArgs mevent)
    {
        base.OnMouseDown(mevent);

        if (mevent.Button == MouseButtons.Left)
        {
            this.RebuildMenu();
            this.menu.Show(this, new Point(0, Height - 1));
        }
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        int arrowX = ClientRectangle.Width - Padding.Right - 14;
        int arrowY = (ClientRectangle.Height / 2) - 1;

        Color color = Enabled ? ForeColor : SystemColors.ControlDark;
        using (Brush brush = new SolidBrush(color))
        {
            Point[] arrows = new Point[] { new Point(arrowX, arrowY), new Point(arrowX + 7, arrowY), new Point(arrowX + 3, arrowY + 4) };
            pevent.Graphics.FillPolygon(brush, arrows);
        }
    }
}
