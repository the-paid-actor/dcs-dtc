
namespace DTC.UI.Base.Controls
{
    public class DTCTextBox : UserControl
    {
        public static DTCTextBox Make(int left, int top, int width, int height)
        {
            var txt = new DTCTextBox();
            txt.Left = left;
            txt.Top = top;
            txt.Width = width;
            txt.Height = height;
            return txt;
        }

        public delegate void TextBoxChangedCallback(DTCTextBox txt);

        public static DTCTextBox Make(int left, int top, int width, int height, string mask, string initialValue, TextBoxChangedCallback callback)
        {
            var txt = Make(left, top, width, height);
            txt.Mask = mask;
            txt.Text = initialValue;
            txt.HidePromptOnLeave = true;
            txt.AllowPromptAsInput = false;
            txt.PromptChar = ' ';
            txt.Tag = callback;
            txt.Font = new Font("Microsoft Sans Serif", 10);
            txt.LostFocus += (sender, args) =>
            {
                callback(txt);
            };
            return txt;
        }

        private MaskedTextBox textBox;

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public override Font Font
        {
            get { return textBox.Font; }
            set { textBox.Font = value; }
        }

        public string Mask
        {
            get { return textBox.Mask; }
            set { textBox.Mask = value; }
        }

        public bool AllowPromptAsInput
        {
            get { return textBox.AllowPromptAsInput; }
            set { textBox.AllowPromptAsInput = value; }
        }

        public bool HidePromptOnLeave
        {
            get { return textBox.HidePromptOnLeave; }
            set { textBox.HidePromptOnLeave = value; }
        }

        public InsertKeyMode InsertKeyMode
        {
            get { return textBox.InsertKeyMode; }
            set { textBox.InsertKeyMode = value; }
        }

        public char PromptChar
        {
            get { return textBox.PromptChar; }
            set { textBox.PromptChar = value; }
        }

        public Type ValidatingType
        {
            get { return textBox.ValidatingType; }
            set { textBox.ValidatingType = value; }
        }

        public bool MaskFull
        {
            get { return textBox.MaskFull; }
        }

        public DTCTextBox()
        {
            InitializeComponent();

            textBox.LostFocus += TextBox_LostFocus;
            textBox.GotFocus += TextBox_GotFocus;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.Click += TextBox_Click;
        }

        private bool _firstClick = true;

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
            base.OnEnabledChanged(e);
        }

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
            this.textBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(4, 4);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(143, 19);
            this.textBox.TabIndex = 0;
            // 
            // DTCTextBox
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.textBox);
            this.Name = "DTCTextBox";
            this.Size = new System.Drawing.Size(150, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public new event EventHandler? TextChanged
        {
            add { textBox.TextChanged += value; }
            remove { textBox.TextChanged -= value; }
        }
    }
}
