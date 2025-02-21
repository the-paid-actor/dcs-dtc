using System.Text.RegularExpressions;

namespace DTC.UI.Base.Controls.TextBox;

internal class DTCBaseTextBox : System.Windows.Forms.TextBox
{
    private const int WM_PASTE = 0x0302;
    private bool firstClick = true;

    public Regex AllowedCharacters { get; set; }

    public event EventHandler<PastingEventArgs>? Pasting;

    public DTCBaseTextBox()
    {
        this.BorderStyle = BorderStyle.None;
        this.Font = new Font("Microsoft Sans Serif", 12F);
        this.TabIndex = 0;
        this.TabStop = true;
    }

    protected override void OnClick(EventArgs e)
    {
        if (firstClick)
        {
            this.SelectAll();
            firstClick = false;
        }
        base.OnClick(e);
    }

    protected override void OnGotFocus(EventArgs e)
    {
        this.SelectAll();
        base.OnGotFocus(e);
    }

    protected override void OnLostFocus(EventArgs e)
    {
        firstClick = true;
        base.OnLostFocus(e);
    }

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

    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (AllowedCharacters != null && !AllowedCharacters.IsMatch(e.KeyChar.ToString()))
        {
            e.Handled = true;
        }
        base.OnKeyPress(e);
    }
}
