using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
    internal class DTCNumericTextBox : UserControl
    {
        public delegate void TextBoxChangedCallback(DTCNumericTextBox textBox);

        public enum UnitEnum
        {
            None,
            Degree,
            Feet,
            NauticalMile
        }

        public event TextBoxChangedCallback TextBoxChanged;

        private TextBox textBox;
        private DTCLabel label;
        private UnitEnum unit;
        private decimal? currentValue;

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public bool AllowFraction { get; set; } = false;
        public decimal MinimumValue { get; set; } = 0;
        public decimal MaximumValue { get; set; } = 0;

        public decimal? Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                var str = value?.ToString(CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(str) && AllowFraction && !str.Contains(".")) str = str + ".0";
                suppressTextChanged = true;
                textBox.Text = str;
                suppressTextChanged = false;
                currentValue = value;
            }
        }

        public UnitEnum Unit
        {
            get
            {
                return unit;
            }
            set
            {
                unit = value;
                label.Visible = true;
                textBox.Width = label.Left - 5;

                if (unit == UnitEnum.None)
                {
                    label.Visible = false;
                    textBox.Width += label.Right - textBox.Right - 5;
                }

                if (unit == UnitEnum.Degree) label.Text = "°";
                if (unit == UnitEnum.Feet) label.Text = "ft";
                if (unit == UnitEnum.NauticalMile) label.Text = "nm";
            }
        }

        public DTCNumericTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ValidateValue())
            {
                SystemSounds.Beep.Play();
                e.Cancel = true;
            }
        }

        private bool ValidateValue()
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                if (currentValue != null)
                {
                    currentValue = null;
                    TextBoxChanged?.Invoke(this);
                }
                return true;
            }

            if (decimal.TryParse(textBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
            {
                var min = MinimumValue;
                var max = MaximumValue;

                if (unit == UnitEnum.Degree)
                {
                    max = 359M;
                    if (AllowFraction) max = 359.9M;
                }

                if (result < min || result > max)
                {
                    return false;
                }

                if (currentValue != result)
                {
                    currentValue = result;
                    TextBoxChanged?.Invoke(this);
                }
            }

            return true;
        }

        private char[] allowedChars = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;
            if (allowedChars.Contains(e.KeyChar)) return;
            if (MinimumValue < 0 && e.KeyChar == '-')
            {
                if (textBox.Text == "" || 
                    textBox.SelectionLength == textBox.TextLength ||
                    (textBox.SelectionStart == 0 && textBox.SelectionLength == 0 && textBox.Text.First() != '-'))
                {
                    return;
                }
            }
            e.Handled = true;
        }

        bool suppressTextChanged = false;

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (suppressTextChanged) return;
            suppressTextChanged = true;
            textBox.Text = textBox.Text.Replace(".", "").Replace(" ", "");

            if (AllowFraction && textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1) + "." + textBox.Text.Last();
                if (textBox.Text.First() == '.')
                {
                    textBox.Text = "0" + textBox.Text;
                }
                if (textBox.Text.First() == '0' && textBox.Text.Substring(0, 2) != "0.")
                {
                    textBox.Text = textBox.Text.Substring(1, textBox.Text.Length-1);
                }
            }

            textBox.SelectionStart = textBox.Text.Length;
            suppressTextChanged = false;
        }

        private bool _firstClick = true;

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (_firstClick)
            {
                this.SelectAll();
                _firstClick = false;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            this.SelectAll();
            OnGotFocus(e);
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            _firstClick = true;
            ValidateValue();
            OnLostFocus(e);
        }

        public void SelectAll()
        {
            textBox.SelectAll();
        }

        private void InitializeComponent()
        {
            this.textBox = new TextBox();
            this.label = new DTCLabel();
            this.SuspendLayout();

            this.textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.textBox.BorderStyle = BorderStyle.None;
            this.textBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new Point(4, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new Size(115, 19);
            this.textBox.TabIndex = 0;
            this.textBox.TabStop = true;
            this.textBox.MaxLength = 5;
            this.textBox.TextAlign = HorizontalAlignment.Right;
            this.textBox.LostFocus += TextBox_LostFocus;
            this.textBox.GotFocus += TextBox_GotFocus;
            this.textBox.KeyDown += TextBox_KeyDown;
            this.textBox.Click += TextBox_Click;
            this.textBox.TextChanged += TextBox_TextChanged;
            this.textBox.KeyPress += TextBox_KeyPress;
            this.textBox.Validating += TextBox_Validating;

            this.label.Anchor = AnchorStyles.Right;
            this.label.AutoSize = false;
            this.label.Text = "°";
            this.label.Location = new Point(120, 4);
            this.label.Size = new Size(30, 19);
            this.label.TextAlign = ContentAlignment.MiddleLeft;
            this.label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));


            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label);
            this.Name = "DTCNumericTextBox";
            this.Size = new System.Drawing.Size(150, 28);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
