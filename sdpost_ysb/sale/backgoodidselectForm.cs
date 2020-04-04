using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop.sale
{
    public partial class backgoodidselectForm : Form
    {
        public backgoodidselectForm()
        {
            InitializeComponent();
        }

        public void backgoodidconfirm()    //选定代售商品
        {
            backsaleForm fatherform = (backsaleForm)this.Owner;
            fatherform.textBox_TM.Text = dataGridView1.CurrentRow.Cells["BarCode"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                backgoodidconfirm();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            backgoodidconfirm();
        }

    }
}
