using DTC.Utilities;
using System.ComponentModel;
using System.Media;

namespace DTC.UI.Base.Controls;

public class DTCCoordinateTextBox2 : UserControl
{
    private CoordinateFormat format;
    private DTCMaskedTextBox textBox;
    private DTCLabel label;
    private DTCCoordinateConverter converter;
    private Coordinate? coordinate;
    public bool valid = false;
    private bool firstClick = true;
    private Control coordinateConverterParent;

    public event Action<Coordinate> CoordinateChanged;
    public event Action WillOpenConverter;
    public event Action<int> ElevationPasted;

    public Control CoordinateConverterParent
    {
        get => this.coordinateConverterParent;
        set => this.coordinateConverterParent = value;
    }

    public CoordinateFormat Format
    {
        get => this.format;
        set
        {
            this.format = value;
            switch (this.format)
            {
                case CoordinateFormat.DegreesMinutesHundredths:
                    this.textBox.Mask = Coordinate.DegreesMinutesHundredthsMask; break;
                case CoordinateFormat.DegreesMinutesThousandths:
                    this.textBox.Mask = Coordinate.DegreesMinutesThousandthsMask; break;
                case CoordinateFormat.DegreesMinutesSeconds:
                    this.textBox.Mask = Coordinate.DegreesMinutesSecondsMask; break;
                case CoordinateFormat.DegreesMinutesSecondsHundredths:
                    this.textBox.Mask = Coordinate.DegreesMinutesSecondsHundredthsMask; break;
                case CoordinateFormat.MGRSTenDigits:
                    this.textBox.Mask = Coordinate.MGRSTenDigitsMask; break;
                default:
                    throw new NotImplementedException();
            }

            this.UpdateText();
        }
    }

    public Coordinate? Coordinate
    {
        get => this.coordinate;
        set
        {
            this.coordinate = value;
            this.valid = value != null;
            this.UpdateText();
            this.CoordinateChanged?.Invoke(this.coordinate);
        }
    }

    public bool Valid
    {
        get => this.valid;
    }

    public bool ButtonVisible
    {
        get => this.label.Visible;
        set
        {
            this.label.Visible = value;
            this.textBox.Width = value ? this.Width - this.label.Width - 4 : this.Width - 4;
        }
    }

    public DTCCoordinateTextBox2()
    {
        this.textBox = new DTCMaskedTextBox();
        this.label = new DTCLabel();
        this.SuspendLayout();

        this.textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.textBox.BorderStyle = BorderStyle.None;
        this.textBox.Font = new Font("Microsoft Sans Serif", 10F);
        this.textBox.Location = new Point(4, 4);
        this.textBox.Name = "textBox";
        this.textBox.Size = new Size(115, 19);
        this.textBox.TabIndex = 0;
        this.textBox.Pasting += TextBox_Pasting;
        this.textBox.Validating += TextBox_Validating;
        this.textBox.LostFocus += TextBox_LostFocus;
        this.textBox.GotFocus += TextBox_GotFocus;
        this.textBox.KeyDown += TextBox_KeyDown;
        this.textBox.KeyPress += TextBox_KeyPress;
        this.textBox.Click += TextBox_Click;
        this.textBox.InsertKeyMode = InsertKeyMode.Overwrite;

        this.label.Anchor = AnchorStyles.Right;
        this.label.AutoSize = false;
        this.label.Text = "...";
        this.label.Location = new Point(120, 4);
        this.label.Size = new Size(30, 19);
        this.label.TextAlign = ContentAlignment.MiddleLeft;
        this.label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        this.label.Click += Label_Click;

        this.BackColor = SystemColors.Window;
        this.Controls.Add(this.textBox);
        this.Controls.Add(this.label);
        this.Name = "DTCTextBox";
        this.Size = new Size(150, 28);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
    {
        this.valid = false;
    }

    private void UpdateText()
    {
        this.textBox.Text = this.Coordinate?.ToString(this.format) ?? "";
    }

    private void TextBox_Validating(object? sender, CancelEventArgs e)
    {
        ValidateCoords(e);
    }

    private void ValidateCoords(CancelEventArgs e)
    {
        if (!this.textBox.MaskFull)
        {
            this.valid = false;
            this.Coordinate = null;
            return;
        }

        if (this.valid == false)
        {
            Coordinate.TryFromString(textBox.Text, out var c);
            if (c == null)
            {
                this.valid = false;
                SystemSounds.Beep.Play();
                e.Cancel = true;
            }
            else
            {
                this.valid = true;
                this.Coordinate = c;
                OnValidated(EventArgs.Empty);
            }
        }
    }

    private void TextBox_Pasting(object? sender, PastingEventArgs e)
    {
        var s = e.Value;
        var (coordStr, elev) = ProcessDCSDialogString(s);
        Coordinate.TryFromString(coordStr, out var c);

        if (c != null)
        {
            this.Coordinate = c;
        }
        else
        {
            SystemSounds.Beep.Play();
        }

        if (elev > -1)
        {
            this.ElevationPasted?.Invoke(elev);
        }
        e.Cancel = true;
    }

    private (string, int) ProcessDCSDialogString(string s)
    {
        //check if it looks like the string below

        /*
        Metric: X-00196098 Z-00595860
        Lat Long Standard: S 53°43' 4"   W 68°17'19"
        Lat Long Precise: S 53°43'4.71"   W 68°17'19.74"
        Lat Long Decimal Minutes: S 53°43.078'   W 68°17.329'
        MGRS GRID: 19 F EA 46931 47620
        Altitude: 87 m / 286 feet
        */

        s = s.Replace("\r", "");

        var lines = s.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length == 6 && lines[0].StartsWith("Metric: "))
        {
            var coord = lines[4].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];
            var elev = int.Parse(lines[5].Split("/")[1].Replace("feet", "").Trim());
            return (coord, elev);
        }

        if (lines.Length == 1)
        {
            if (s.StartsWith("Lat Long Standard") || s.StartsWith("Lat Long Precise") || s.StartsWith("Lat Long Decimal Minutes") || s.StartsWith("MGRS GRID"))
            {
                var coord = lines[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[1];
                return (coord, -1);
            }
        }

        return (s, -1);
    }

    private void Label_Click(object? sender, EventArgs e)
    {
        if (this.Parent == null)
        {
            return;
        }

        var args = new CancelEventArgs();
        ValidateCoords(args);

        if (args.Cancel)
        {
            return;
        }

        if (this.converter == null)
        {
            this.converter = new DTCCoordinateConverter();
        }

        this.WillOpenConverter?.Invoke();

        Control parent = this.Parent;
        if (this.coordinateConverterParent != null)
        {
            parent = this.coordinateConverterParent;
        }

        parent.Controls.Add(this.converter);
        this.converter.ShowConverter(this.Coordinate, this);
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