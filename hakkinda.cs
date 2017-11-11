using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notix
{
    public partial class hakkinda : Form
    {
        public hakkinda()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.karacasercan.com");
        }

        private void hakkinda_Load(object sender, EventArgs e)
        {

        }
    }
}
