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
    public partial class ChangeStock : BaseForm
    {
        private NShop.Service.GoodsService s = new NShop.Service.GoodsService();
        private DataGridViewRow row;

        public ChangeStock(DataGridViewRow row)
        {
            this.row = row;
            InitializeComponent();
        }

        private void ChangeStock_Load(object sender, EventArgs e)
        {
            if (row != null)
            {
                varGoodsName.Text = row.Cells["GoodsName"].Value.ToString();
                varInCount.Value = decimal.Parse(row.Cells["InCount"].Value.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要修改库存吗?","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                bool ret = s.ChangeStock(row.Cells["GoodsID"].Value.ToString(), row.Cells["ID"].Value.ToString(),
                    (int)varInCount.Value, int.Parse(row.Cells["InCount"].Value.ToString()));
                if (ret)
                {
                    MessageBox.Show("库存调整成功!");
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
