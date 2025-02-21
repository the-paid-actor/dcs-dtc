using System.Text.RegularExpressions;

namespace DTC.UI.Base.Controls.TextBox;

internal class DTCNewTextBox : Control
{
    private DTCBaseTextBox textBox;

    public DTCNewTextBox()
    {
        this.InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.SuspendLayout();

        var ctls = new List<Control>();

        this.textBox = new();
        this.textBox.AllowedCharacters = GetAllowedChars();
        this.textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.textBox.Location = new Point(7, 4);
        this.textBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        this.textBox.Size = new Size(137, 19);
        this.textBox.TextAlign = GetTextAlignment();
        this.textBox.Text = "";

        this.textBox.Pasting += TextBox_Pasting;

        ctls.Add(this.textBox);

        var ctl = GetLabel();
        if (ctl != null)
        {
            var labelWidth = GetLabelWidth();
            this.textBox.Width -= (labelWidth - 2);

            ctl.Anchor = AnchorStyles.Right;
            ctl.AutoSize = false;
            ctl.Font = new Font("Microsoft Sans Serif", 10F);
            ctl.Location = new Point(this.textBox.Right + 3, 2);
            ctl.Margin = new Padding(0);
            ctl.Padding = new Padding(0);
            ctl.Size = new Size(labelWidth, 19);
            ctl.TextAlign = ContentAlignment.MiddleCenter;
            ctls.Add(ctl);
        }

        this.BackColor = SystemColors.Window;
        this.Controls.AddRange(ctls.ToArray());
        this.Name = "DTCTextBox";
        this.Size = new Size(150, 24);

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    protected override void OnGotFocus(EventArgs e)
    {
        this.textBox.Focus();
        base.OnGotFocus(e);
    }

    protected override void OnClick(EventArgs e)
    {
        this.textBox.Focus();
        base.OnClick(e);
    }

    private void TextBox_Pasting(object? sender, PastingEventArgs e)
    {
        throw new NotImplementedException();
    }

    protected virtual Label GetLabel()
    {
        return null;
    }

    protected virtual int GetLabelWidth()
    {
        return 0;
    }

    protected virtual Regex GetAllowedChars()
    {
        return null;
    }

    protected virtual HorizontalAlignment GetTextAlignment()
    {
        return HorizontalAlignment.Left;
    }

    public override string Text
    {
        get { return textBox.Text; }
        set { textBox.Text = value; }
    }
}
