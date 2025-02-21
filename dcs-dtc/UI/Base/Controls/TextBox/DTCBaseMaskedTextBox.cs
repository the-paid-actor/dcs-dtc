namespace DTC.UI.Base.Controls.TextBox;

internal class DTCBaseMaskedTextBox : MaskedTextBox
{
    private const int WM_PASTE = 0x0302;

    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_PASTE:
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    var args = OnPasting(text);
                    if (args.Cancel)
                    {
                        // Swallow it up!
                        return;
                    }

                    // If value changed, then change what we'll paste from the top of the clipboard
                    if (!args.Value.Equals(text, StringComparison.CurrentCulture))
                    {
                        Clipboard.SetText(args.Value);
                    }
                }
                break;
        }
        base.WndProc(ref m);
    }

    public event EventHandler<PastingEventArgs>? Pasting;

    protected virtual PastingEventArgs OnPasting(string value)
    {
        var handler = Pasting;
        var args = new PastingEventArgs(value);
        if (handler != null)
        {
            handler(this, args);
        }
        return args;
    }
}
