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
    public partial class goodselectForm : Form
    {
        public goodselectForm()
        {
            InitializeComponent();
        }

        public void goodsconfirm()    //选定代售商品
        {
            NShop.Model.sdopst_OrderDetail saledetail = new NShop.Model.sdopst_OrderDetail();
            //saledetail.ID = sale_id + iii.ToString("000");    //销售明细系统编号 
            //saledetail.OrderID = sale_id;                            //订单编号        
            saledetail.GoodsID = dataGridView1.CurrentRow.Cells["BarCode"].Value.ToString();             //商品编号        
            saledetail.GoodsName = dataGridView1.CurrentRow.Cells["GoodsName"].Value.ToString();                      //商品名称        
            saledetail.GoodsNum = 1;                                           //购买数量        
            saledetail.UnitPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["RetailPrice"].Value);                   //单价（元）      
            if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["MemberPrice"].Value) == 0)
                saledetail.MemberPrice = saledetail.UnitPrice;                   //会员价=原价
            else
                saledetail.MemberPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["MemberPrice"].Value);
            saledetail.Unit = Convert.ToString(dataGridView1.CurrentRow.Cells["Unit"].Value);                              //商品单位        
            saledetail.OriginalPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["BuyingPrice"].Value);      //总原始价格（元）  这里存成单件的进价，后边计算销售明细的时候用
            saledetail.Discount = 0;                                                //总折扣金额（元）
            saledetail.SalePrice = saledetail.GoodsNum * saledetail.UnitPrice ;  //总销售价格（元）
            saledetail.CostPrice = saledetail.GoodsNum * saledetail.OriginalPrice;       //总成本价格（元）
            saledetail.Profit = (saledetail.SalePrice - saledetail.CostPrice) ;     //总利润          
            saledetail.Supplier = Convert.ToString(dataGridView1.CurrentRow.Cells["Supplier"].Value);                        //供应商          
            saledetail.Status = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Status"].Value);                     //数据状态        
            saledetail.Memo = "";                                               //备注            
            saledetail.CreateTime = DateTime.Now;                          //创建时间        
            saledetail.UpdateTime = DateTime.Now;                          //最近修改时间    
            saledetail.Modifier = "system";                                //最近修改人      
            saledetail.Category = Convert.ToString(dataGridView1.CurrentRow.Cells["Category"].Value);
            saledetail.Promotion = Convert.ToString(dataGridView1.CurrentRow.Cells["Promotion"].Value);
            if (saledetail.UnitPrice <= 0)
                saledetail.DiscountRate = 0;
            else
                saledetail.DiscountRate = saledetail.MemberPrice / saledetail.UnitPrice;                                            //折扣率          

            saleForm fatherform = (saleForm)this.Owner;
            fatherform.goodselectenter(saledetail);
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                goodsconfirm();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            goodsconfirm();
        }

    }
}
