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
    public partial class ChangeSupplier : BaseForm
    {
        private NShop.Service.GoodsService s = new NShop.Service.GoodsService();
        private DataGridViewRow row;

        public ChangeSupplier(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();
        }

        private void ChangeStock_Load(object sender, EventArgs e)
        {
            if (row != null)
            {
                varGoodsName.Text = row.Cells["GoodsName"].Value.ToString();
                try
                {
                    varSupplier.Text = row.Cells["Supplier"].Value.ToString();
                }
                catch
                { }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要修改供应商吗?","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                bool ret = s.ChangeSupplier(row.Cells["GoodsID"].Value.ToString(), row.Cells["ID"].Value.ToString(), varSupplier.Text.Trim());
                if (ret)
                {
                    MessageBox.Show("供应商修改成功!");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
