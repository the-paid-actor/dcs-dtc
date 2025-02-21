using System.Text;

namespace DTC.Utilities;

public class KneeboardBuilder
{
    private StringBuilder sb = new StringBuilder();
    private int lineWidth = 77;
    private int columnWidth = 37;

    public void Append(string text)
    {
        text = text ?? "";
        sb.Append(text);
    }

    public void Append(int number)
    {
        sb.Append(number.ToString());
    }

    public void AppendJustifyLeft(int number, int size, char c = ' ')
    {
        AppendJustifyLeft(number.ToString(), size, c);
    }

    public void AppendJustifyRight(int number, int size, char c = ' ')
    {
        AppendJustifyRight(number.ToString(), size, c);
    }

    public void AppendJustifyLeft(string text, int size, char c = ' ')
    {
        text = text ?? "";
        var l = Math.Min(text.Length, size);
        sb.Append(text.Substring(0, l).PadRight(size, c));
    }

    public void AppendJustifyRight(string text, int size, char c = ' ')
    {
        text = text ?? "";
        var l = Math.Min(text.Length, size);
        sb.Append(text.Substring(0, l).PadLeft(size, c));
    }

    public void AppendCentered(string text)
    {
        AppendCentered(text, lineWidth);
        AppendLine();
    }

    private void AppendCentered(string text, int lineLength)
    {
        text = text ?? "";
        var length = text.Length;
        var preffix = (lineLength / 2) - (length / 2);
        var suffix = lineLength - (preffix + length);
        Repeat(preffix, ' ');
        sb.Append(text);
        Repeat(suffix, ' ');
    }

    public void AppendCenteredColumn(string text)
    {
        AppendCentered(text, columnWidth);
    }

    public void Repeat(int times, char character)
    {
        sb.Append("".PadLeft(times, character));
    }

    public void AppendLineDivider()
    {
        Repeat(lineWidth, '-');
        sb.AppendLine();
    }

    public void AppendColumnDivider()
    {
        sb.Append(" | ");
    }

    public void AppendColumnBlank()
    {
        Repeat(columnWidth, ' ');
    }

    public void AppendSpace()
    {
        sb.Append(" ");
    }

    public void AppendLine()
    {
        sb.AppendLine();
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}
