using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop.Manage
{
    public partial class Progress : BaseForm
    {
        public delegate void DoProgress(ProgressBar frm);
        public DoProgress pro;

        public Progress()
        {
            InitializeComponent();
        }

        private void Prograss_Load(object sender, EventArgs e)
        {
            
        }

        private void Progress_Activated(object sender, EventArgs e)
        {
            pro(progressBar1);
            this.Close();
        }
    }
}
