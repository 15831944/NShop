using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop
{
    public partial class NewVersion : Form
    {
        private String newVersion;

        public NewVersion(String newVersion)
        {
            this.newVersion = newVersion;
            InitializeComponent();
        }

        private void buttonRemindLater_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void NewVersion_Load(object sender, EventArgs e)
        {
            //加载更新说明
            webBrowser.Navigate(NShop.Param.Server.UpdateLogUrl);
            labelUpdate.Text = String.Format(labelUpdate.Text, newVersion);
            labelDescription.Text = String.Format(labelDescription.Text, newVersion);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
