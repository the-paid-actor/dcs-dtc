using DTC.New.UI.Base.Systems;
using DTC.UI.Base.Controls;

namespace DTC.New.UI.Base.Pages;

internal class AircraftSystemButton : UserControl
{
    private DTCButton button;
    private AircraftSystemPage page;
    private ContextMenuStrip contextMenuStrip;

    public AircraftSystemButton(AircraftSystemPage page)
    {
        this.TabStop = true;
        this.Height = 30;
        this.page = page;

        this.contextMenuStrip = new ContextMenuStrip();
        this.contextMenuStrip.Items.Add("Copy", null, (object sender, EventArgs e) =>
        {
            this.page.CopyToClipboard();
        });
        this.contextMenuStrip.Items.Add("Paste", null, (object sender, EventArgs e) =>
        {
            this.page.PasteFromClipboard();
        });
        this.contextMenuStrip.Opening += (s, e) =>
        {
            if (page.IsCopyPasteEnabled())
            {
                this.contextMenuStrip.Items[1].Visible = this.page.IsClipboardValid();
            }
            else
            {
                e.Cancel = true;
            }
        };

        button = new DTCButton();
        button.Text = page.GetPageTitle();
        button.Dock = DockStyle.Fill;
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.Font = new Font("Microsoft Sans Serif", 10);

        button.MouseClick += (s, e) =>
        {
            if (e.Button == MouseButtons.Left)
            {
                this.OnClick(e);
                button.BackColor = button.FlatAppearance.MouseOverBackColor;
                button.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(button, e.Location);
            }
        };

        this.Controls.Add(button);
        button.ContextMenuStrip = this.contextMenuStrip;
    }

    public void ResetAppearance()
    {
        button.BackColor = Color.DarkKhaki;
        button.Font = new Font("Microsoft Sans Serif", 10);
    }
}
