using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Attribute;

namespace NShop.Manage
{
    public partial class SaleDetail : BaseForm
    {
        private String orderID;
        private NShop.Service.OrderService s = new NShop.Service.OrderService();

        public SaleDetail(String orderID)
        {
            this.orderID = orderID;
            InitializeComponent();
        }

        private void SaleDetail_Load(object sender, EventArgs e)
        {
            varOrderID.Text = orderID;

            List<CustomAttribute> cols = NShop.Service.OrderService.dr.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(gridSlave, cols);
            gridSlave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            gridSlave.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSlave.Columns["UnitPrice"].DefaultCellStyle.Format = "0.00元";
            gridSlave.Columns["OriginalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSlave.Columns["OriginalPrice"].DefaultCellStyle.Format = "0.00元";
            gridSlave.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSlave.Columns["SalePrice"].DefaultCellStyle.Format = "0.00元";
            gridSlave.Columns["MemberPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridSlave.Columns["MemberPrice"].DefaultCellStyle.Format = "0.00元";

            bindingSource1.DataSource = s.GetOrderDetails(orderID);
            gridSlave.DataSource = bindingSource1;

            gridSlave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void gridSlave_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection rows = gridSlave.SelectedRows;
            if (rows.Count == 1)
            {
                varGoodsName.Text = rows[0].Cells["GoodsName"].Value.ToString();
                varDetailID.Text = rows[0].Cells["ID"].Value.ToString();
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退货吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                NShop.Service.OrderService s = new NShop.Service.OrderService();
                NShop.Model.sdpost_Order order = s.GetOrder(orderID);

                NShop.Model.sdopst_OrderDetail detail = order.Details.Find((NShop.Model.sdopst_OrderDetail d) => d.ID == varDetailID.Text);
                detail.Status = -1;
                detail.Memo = "已退款";

                order.Profit -= detail.Profit;//对订单利润进行修正

                if (s.UpdateOrder(order))
                {
                    SaleDetail_Load(sender, e);
                    MessageBox.Show("退款成功");
                }
            }
        }
    }
}
