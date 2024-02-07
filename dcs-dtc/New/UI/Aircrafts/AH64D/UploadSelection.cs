using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTC.New.UI.Aircrafts.AH64D
{
    public partial class UploadSelection : UserControl
    {
        public UploadSelection()
        {
            InitializeComponent();
        }

        public AH64DPage ApachePage { get; internal set; }

        private void btnPilot_Click(object sender, EventArgs e)
        {
            ApachePage.UploadToJet(ApachePage.Configuration, true);
            this.Parent.Controls.Remove(this);
        }

        private void btnGunner_Click(object sender, EventArgs e)
        {
            ApachePage.UploadToJet(ApachePage.Configuration, false);
            this.Parent.Controls.Remove(this);
        }
    }
}
