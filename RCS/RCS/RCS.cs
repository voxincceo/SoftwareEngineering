using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CTCOffice;

namespace RCS
{
    public partial class RCS : Form
    {
        CTC entry;
        public RCS()
        {
            InitializeComponent();
            this.Hide();
            entry = new CTC(this);
            entry.Show();
        }

        private void RCS_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
