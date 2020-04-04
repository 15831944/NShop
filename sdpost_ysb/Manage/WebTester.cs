using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NShop
{
    public partial class WebTester : Form
    {
        public WebTester()
        {
            InitializeComponent();
        }

        private void WebTester_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            timer1.Interval = r.Next(20000, 50000);
            timer1.Start();
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
