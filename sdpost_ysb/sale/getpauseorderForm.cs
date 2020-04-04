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
    public partial class getpauseorderForm : Form
    {
        public getpauseorderForm()
        {
            InitializeComponent();
        }

        public void orderconfirm()    //选定代售商品
        {
            saleForm fatherform = (saleForm)this.Owner;
            fatherform.orderselectenter(dataGridView1.CurrentRow.Index);
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                orderconfirm();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            orderconfirm();
        }
    }
}
