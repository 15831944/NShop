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
    public partial class changegoodsnumForm : Form
    {
        public changegoodsnumForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(string.Empty))
            {
                MessageBox.Show("数量不能为空。");
                textBox1.Focus();
            }
            else if (Convert.ToInt32(textBox1.Text) == 0)
            {
                MessageBox.Show("数量不能为0。");
                textBox1.Focus();
            }
            else
            {
                saleForm fatherform = (saleForm)this.Owner;
                fatherform.textBox2.Text = textBox1.Text;
                fatherform.changegoodsnum(Convert.ToInt32(textBox1.Text),checkBox1.Checked);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(null, EventArgs.Empty);
                //Button buttonnew = new Button();
                //buttonnew.Click += new EventHandler(button1_Click);
            }
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
            }

        }
    }
}
