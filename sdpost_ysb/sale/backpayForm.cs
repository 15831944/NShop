using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace NShop.sale
{
    public partial class backpayForm : Form
    {
        public backpayForm()
        {
            InitializeComponent();
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.F1:
                    button1_Click(null, EventArgs.Empty);
                    break;
                case Keys.F2:
                    if (checkBox1.Checked == true)
                        checkBox1.Checked = false;
                    else
                        checkBox1.Checked = true;
                    break;
                case Keys.Escape:
                    button3_Click(null, EventArgs.Empty);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Trim() == string.Empty)
                textBox2.Text = "0.00";
            //if (textBox2.Text.Equals("0.00"))                           //找零
            //    textBox3.Text = "0.00";
            //else
            {
                textBox2.Text = (Convert.ToDecimal(textBox2.Text)).ToString("f2"); 
                //textBox3.Text = (Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text)).ToString("f2");
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                //else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                //{
                //    MessageBox.Show(((TextBox)sender).Text.Trim());
                //    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 2)  //小数点后能输入几位
                //        e.Handled = true;
                //}
            }

        }

        private void backpayForm_Activated(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(textBox2.Text) < Convert.ToDecimal(textBox1.Text))
            //{
            //    MessageBox.Show("实收金额不足。");
            //    textBox2.Focus();
            //}
            //else
            {
                if (checkBox1.Checked == true)
                {
                    backsaleForm fatherform = (backsaleForm)this.Owner;
                    fatherform.backsavedata(Convert.ToDecimal(textBox2.Text), (Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text)));
                    fatherform.printbackdetail();
                    //fatherform.truncatedetail();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    backsaleForm fatherform = (backsaleForm)this.Owner;
                    fatherform.backsavedata(Convert.ToDecimal(textBox2.Text), (Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text)));
                    //fatherform.truncatedetail();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //saleForm fatherform = (saleForm)this.Owner;
            //fatherform.focusselect(1);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.textBox2.Text.Trim() == string.Empty)
            {
                textBox2.Text = "0";
                textBox2.SelectAll();
            }
            //textBox2.Text = (Convert.ToDecimal(textBox2.Text)).ToString("f2");
            //textBox3.Text = (Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text)).ToString("f2");
        }
    }
}
