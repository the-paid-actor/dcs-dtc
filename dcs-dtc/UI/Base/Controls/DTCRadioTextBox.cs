using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace DTC.UI.Base.Controls
{
    internal class DTCRadioTextBox : UserControl
    {
        public delegate void TextBoxChangedCallback(DTCRadioTextBox textBox);

        public class FrequencyBand
        {
            public decimal Min { get; set; }
            public decimal Max { get; set; }
            public string Name { get; set; }
        }

        private TextBox textBox;
        private DTCLabel label;
        private int integerDigits = 0;
        private int fractionDigits = 0;

        public override string Text
        {
            get { return textBox.Text; }
            set
            {
                textBox.Text = value;
                if (decimal.TryParse(textBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
                {
                    ValidAllowedRange(result);
                }
            }
        }

        public int FractionDigits 
        {
            get { return fractionDigits; }
            set 
            {
                fractionDigits = value;
                UpdateMaxLength();
            }
        }

        public int IntegerDigits
        {
            get { return integerDigits; }
            set
            {
                integerDigits = value;
                UpdateMaxLength();
            }
        }

        private void UpdateMaxLength()
        {
            textBox.MaxLength = integerDigits;
            if (fractionDigits > 0)
            {
                textBox.MaxLength += fractionDigits + 1;
            }
        }

        public bool AllowNegative { get; set; } = false;
        public decimal FractionInterval { get; set; } = 0;
        public List<decimal> AllowedFractions { get; } = new List<decimal>();

        public List<FrequencyBand> AllowedRanges { get; } = new List<FrequencyBand>();

        public decimal? Value
        {
            get
            {
                if (decimal.TryParse(textBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var value))
                {
                    return value;
                }
                return null;
            }
            set
            {
                var str = value?.ToString(CultureInfo.InvariantCulture);
                textBox.Text = str;
            }
        }

        public DTCRadioTextBox()
        {
            InitializeComponent();
        }

        private void TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            label.Text = "";
            if (decimal.TryParse(textBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
            {
                e.Cancel = !ValidAllowedRange(result);
                if (e.Cancel)
                {
                    SystemSounds.Exclamation.Play();
                    return;
                }

                e.Cancel = !ValidateFractionInterval(result);
                if (e.Cancel)
                {
                    SystemSounds.Exclamation.Play();
                    return;
                }
            }
        }

        private bool ValidateFractionInterval(decimal number)
        {
            decimal fraction = number % 1;

            if (AllowedFractions.Count > 0)
            {
                return AllowedFractions.Contains(fraction);
            }

            if (FractionInterval > 0)
            {
                decimal remainder = fraction % FractionInterval;
                return remainder == 0;
            }

            return false;
        }

        private bool ValidAllowedRange(decimal result)
        {
            foreach (var range in AllowedRanges)
            {
                if (result >= range.Min && result <= range.Max)
                {
                    label.Text = range.Name;
                    return true;
                }
            }

            return false;
        }

        private char[] allowedChars = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) return;
            if (allowedChars.Contains(e.KeyChar)) return;
            if (AllowNegative && e.KeyChar == '-')
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

        bool inEvent = false;

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (inEvent) return;

            if (textBox.Text.Length == 0)
            {
                return;
            }

            inEvent = true;
            var str = textBox.Text;
            str = str.Replace(".", "").Replace(" ", "");

            if (FractionDigits > 0)
            {
                str = str.TrimStart('0');

                if (str.Length <= FractionDigits)
                {
                    str = str.PadLeft(FractionDigits, '0');
                    str = "0." + str;
                }
                else
                {
                    var left = str.Substring(0, str.Length - FractionDigits);
                    var right = str.Substring(str.Length - FractionDigits);
                    str = left + "." + right;
                }
            }

            textBox.Text = str;
            textBox.SelectionStart = textBox.Text.Length;
            inEvent = false;
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
            OnLostFocus(e);
        }

        public void SelectAll()
        {
            textBox.SelectAll();
        }

        private void InitializeComponent()
        {
            /*
            Hornet
            0.005 increments (jet accepts 0.001 increments)
            
            COMM1/COMM2
            30.000 - 87.995
            108.000 - 173.995 (108.000 - 117.995 no voice TX/RX on SRS)
            225.000 - 399.975

            Viper
            0.025 increments (jet has 2 decimal digits so only .00, .02, .05 and .07 are accepted)

            COMM1
            225.000 - 399.975

            COMM2
            30.000 - 87.975
            108.000 - 151.975 (108.000 - 115.975 no voice TX/RX on SRS)

            Strike Eagle
            0.005 increments (jet accepts 0.001 increments)

            COMM1
            225.000 - 399.975

            COMM2
            30.000 - 87.995 (currently 30.000 is inaccessible, use 30.001)
            108.000 - 173.995
            225.000 - 399.975
            */

            this.textBox = new TextBox();
            this.label = new DTCLabel();
            this.SuspendLayout();

            this.textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.textBox.BorderStyle = BorderStyle.None;
            this.textBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new Point(4, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new Size(105, 19);
            this.textBox.TabIndex = 0;
            this.textBox.TabStop = true;
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
            this.label.Text = "";
            this.label.Location = new Point(110, 4);
            this.label.Size = new Size(40, 19);
            this.label.TextAlign = ContentAlignment.MiddleLeft;
            this.label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.label.Click += (sender, args) =>
            {
                textBox.Focus();
            };

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
