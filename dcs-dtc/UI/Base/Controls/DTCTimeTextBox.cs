using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DTC.UI.Base.Controls;

public class DTCTimeTextBox : UserControl
{
    private DTCMaskedTextBox textBox;
    public bool valid = false;
    private bool firstClick = true;
    private static Regex TimeRegex = new Regex("^\\d\\d:\\d\\d:\\d\\d$");

    public bool Valid
    {
        get => this.valid;
    }

    public override string Text
    {
        get => GetText();
        set => SetText(value);
    }

    private string GetText()
    {
        if (this.textBox.Text == "  :  :")
        {
            return null;
        }
        return this.textBox.Text;
    }

    private void SetText(string text)
    {
        if (string.IsNullOrEmpty(text) || !TimeRegex.IsMatch(text))
        {
            text = null;
        }
        this.textBox.Text = text;
        this.valid = true;
    }

    public DTCTimeTextBox()
    {
        this.textBox = new DTCMaskedTextBox();
        this.SuspendLayout();

        this.textBox.Mask = "00\\:00\\:00";
        this.textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.textBox.BorderStyle = BorderStyle.None;
        this.textBox.Font = new Font("Microsoft Sans Serif", 10F);
        this.textBox.Location = new Point(4, 4);
        this.textBox.Name = "textBox";
        this.textBox.HidePromptOnLeave = true;
        this.textBox.Size = new Size(145, 19);
        this.textBox.TabIndex = 0;
        this.textBox.Validating += TextBox_Validating;
        this.textBox.LostFocus += TextBox_LostFocus;
        this.textBox.GotFocus += TextBox_GotFocus;
        this.textBox.KeyDown += TextBox_KeyDown;
        this.textBox.KeyPress += TextBox_KeyPress;
        this.textBox.Click += TextBox_Click;
        this.textBox.InsertKeyMode = InsertKeyMode.Overwrite;

        this.BackColor = SystemColors.Window;
        this.Controls.Add(this.textBox);
        this.Name = "DTCTextBox";
        this.Size = new Size(150, 28);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
    {
        this.valid = false;
    }

    private void TextBox_Validating(object? sender, CancelEventArgs e)
    {
        if (this.textBox.Text == "  :  :")
        {
            this.valid = true;
            return;
        }
        if (!this.textBox.MaskFull)
        {
            this.valid = false;
            return;
        }
        if (Utilities.Util.IsValidTime(this.textBox.Text))
        {
            this.valid = true;
            return;
        }
    }

    private void TextBox_Click(object sender, EventArgs e)
    {
        if (this.firstClick)
        {
            this.SelectAll();
            this.firstClick = false;
        }
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
        {
            this.valid = false;
        }
        this.OnKeyDown(e);
    }

    private void TextBox_GotFocus(object sender, EventArgs e)
    {
        this.SelectAll();
        this.OnGotFocus(e);
    }

    private void TextBox_LostFocus(object sender, EventArgs e)
    {
        this.firstClick = true;
        this.OnLostFocus(e);
    }

    public void SelectAll()
    {
        this.textBox.SelectAll();
    }
}