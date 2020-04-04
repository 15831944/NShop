using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Entity;

namespace NShop.sale
{
    public partial class backsaleForm : Form
    {
        public backsaleForm()
        {
            InitializeComponent();
        }
        decimal goodprice = 0;
        string orderid;

        private void backsaleForm_Load(object sender, EventArgs e)
        {
            textBox_LSH.Focus();
            textBox_LSH.SelectAll();
            //dataGridView1.DataSource = bindingSource1;
            //dataGridView2.DataSource = bindingSource2;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            varBeginDate.Value = varEndDate.Value = DateTime.Now;
        }

        private void textBox_LSH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_HYH.Focus();
                textBox_HYH.SelectAll();
            }
        }

        private void textBox_HYH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.textBox_TM.Focus();
                textBox_TM.SelectAll();
            }
        }

        private void textBox_TM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox_TM.Text = textBox_TM.Text.Trim(); 
                getgoodid();
                //selectorder();
                //textBox_LSH.Focus();
            }
        }

        private void textBox_LSH_Leave(object sender, EventArgs e)
        {
            textBox_LSH.Text = textBox_LSH.Text.Trim();
            //selectorder();
        }

        private void textBox_HYH_Leave(object sender, EventArgs e)
        {
            textBox_HYH.Text = textBox_HYH.Text.Trim();
            memberenter();
            //selectorder();
        }

        private void textBox_TM_Leave(object sender, EventArgs e)
        {
            textBox_TM.Text = textBox_TM.Text.Trim();
            if (textBox_TM.Text == "")
            {
                return;
            }
            getgoodid();
            //selectorder();
        }

        private void getgoodid()
        {
            NShop.Model.sdpost_Goods goodsdetail = new NShop.Model.sdpost_Goods();
            NShop.Service.GoodsService us = new NShop.Service.GoodsService();

            List<NShop.Model.sdpost_Goods> list = us.GetGoods(textBox_TM.Text);
            int sss = list.Count;
            if (sss == 1)
            {
                textBox_TM.Text = list[0].BarCode;                                       //商品编号        
            }
            else if (sss > 1)
            {
                backgoodidselectForm selectgoodsid = new backgoodidselectForm();
                selectgoodsid.dataGridView1.DataSource = list;
                selectgoodsid.ShowDialog(this);
                if (selectgoodsid.DialogResult != DialogResult.OK)  //如果结算成功，应该返回焦点给textbox3，如果结算不成功，应该返回焦点给textbox1
                {
                    textBox_TM.Text = "";
                    textBox_TM.Focus();
                    return;
                }
            }
        }

        private void varBeginDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //selectorder();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void varEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    //selectorder();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void selectorder()
        {
            //if (textBox_LSH.Text.Trim() == "" && textBox_HYH.Text.Trim() == "" && textBox_TM.Text.Trim() == "")
            //    return;

            string sqlorder = "select * from sdpost_Order where status!=9 and (createtime between '" + varBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:01' and '" + varEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59') ";

            if (!string.IsNullOrEmpty(textBox_LSH.Text))
                sqlorder = sqlorder + " and flowno like '%" + textBox_LSH.Text + "%' ";
            if (!string.IsNullOrEmpty(textBox_HYH.Text))
                sqlorder = sqlorder + " and memberno='" + textBox_HYH.Text + "' ";
            if (!string.IsNullOrEmpty(textBox_TM.Text))
                sqlorder = sqlorder + " and flowno in (select distinct orderid from sdpost_orderdetail where goodsid='" + textBox_TM.Text + "') ";
            DataTable orders =NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.Query(sqlorder);

            //if (orders.Rows.Count > 0)
            {
                bindingSource1.DataSource = orders;
                selectorderdetail();
            }
        }

        private void selectorderdetail()
        {
            string FlowNo = "";
            if (dataGridView1.RowCount > 0)
                FlowNo = Convert.ToString(dataGridView1.CurrentRow.Cells["FlowNo"].Value);

            goodprice = 0;
            label10.Text = goodprice.ToString();
            string sqlorderdetail = "select * from sdpost_Orderdetail where orderid='" + FlowNo + "' ";
            DataTable orderdetails = NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.Query(sqlorderdetail);

            //if (orderdetails.Rows.Count > 0)
                bindingSource2.DataSource = orderdetails;
        }
        
        private void memberenter()    //会员号处理
        {
            if (textBox_HYH.Text.Trim() == string.Empty)
            {
            }
            else
            {
                List<NShop.Model.sdpost_Member> members = new List<NShop.Model.sdpost_Member>();
                NShop.Service.MemberService mmm = new NShop.Service.MemberService();
                members = mmm.GetMemberNoPhone(textBox_HYH.Text.Trim());
                if (members.Count == 0)
                {
                    textBox_HYH.Text = "";
                }
                else
                {
                    textBox_HYH.Text = members[0].MemberNo;
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            selectorderdetail();
        }

        private Service.OrderService s = new Service.OrderService();
        private void dataGridView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.RowCount <= 0) return;

            String orderNo = dataGridView1.CurrentRow.Cells["FlowNo"].Value.ToString();
            Model.sdpost_Order m = s.GetOrder(orderNo);

            string bz = Convert.ToString(dataGridView2.CurrentRow.Cells["Grid2_Memo"].Value);
            if (Convert.ToInt32(dataGridView2.CurrentRow.Cells["Grid2_Status"].Value)==9)
            {
                MessageBox.Show("该商品已退货。");
                return;
            }

            if (bz == "预备退货")
            {
                dataGridView2.CurrentRow.Cells["Grid2_Memo"].Value = "";
                goodprice -= Convert.ToDecimal(dataGridView2.CurrentRow.Cells["SalePrice"].Value);
                label10.Text = goodprice.ToString();
            }
            else
            {
                dataGridView2.CurrentRow.Cells["Grid2_Memo"].Value = "预备退货";
                goodprice += Convert.ToDecimal(dataGridView2.CurrentRow.Cells["SalePrice"].Value) ;
                label10.Text = goodprice.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (dataGridView2.RowCount > 0)
            if (goodprice > 0)
            {
                backpayForm pay_form = new backpayForm();
                pay_form.textBox1.Text = this.label10.Text;
                pay_form.textBox2.Text = this.label10.Text;
                if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["MemberNo"].Value.ToString()))
                    pay_form.textBox3.Text = "0";
                else
                    pay_form.textBox3.Text = Convert.ToInt32(Math.Floor((-1) * Convert.ToDecimal(this.label10.Text))).ToString();
                pay_form.ShowDialog(this);
                if (pay_form.DialogResult == DialogResult.OK)  //如果结算成功，应该返回焦点给textbox3，如果结算不成功，应该返回焦点给textbox1
                {
                    this.Close();
                }
                else
                {
                    this.dataGridView2.Focus();
                }
            }
            else
            {
                MessageBox.Show("未选择要退货的商品。");
            }
        }

        public void backsavedata(decimal receivedmoney, decimal changemoney)      //订单数据存库，由payForm调用
        {
            //订单与订单详情关联
            int iii, goodnum=0;
            decimal tot_costprice = (decimal)0.0, normalprice = 0, orderDiscount = 0, orderprofit = 0;       //总成本
            List<NShop.Model.sdpost_Goods> listgoods = new List<NShop.Model.sdpost_Goods>();
            List<NShop.Model.sdopst_OrderDetail> list2 = new List<NShop.Model.sdopst_OrderDetail>();
            orderid=DateTime.Now.ToString("yyMMddhhmmssff");
            NShop.Service.OrderService os = new NShop.Service.OrderService();

            for (iii = 0; iii < dataGridView2.RowCount; iii++)
            {
                if (dataGridView2.Rows[iii].Cells["Grid2_Memo"].Value == "预备退货")
                {
                    NShop.Model.sdopst_OrderDetail saledetail = new NShop.Model.sdopst_OrderDetail();

                    saledetail.ID = orderid+iii.ToString("000");                       //销售明细系统编号 
                    saledetail.OrderID = orderid;                  //订单编号        
                    saledetail.GoodsID = dataGridView2.Rows[iii].Cells["GoodsID"].Value.ToString();                  //商品编号        
                    saledetail.GoodsName = dataGridView2.Rows[iii].Cells["GoodsName"].Value.ToString();              //商品名称        
                    saledetail.Unit = Convert.ToString(dataGridView2.Rows[iii].Cells["Unit"].Value);                         //商品单位        
                    saledetail.Category = Convert.ToString(dataGridView2.Rows[iii].Cells["Category"].Value);
                    saledetail.UnitPrice = Convert.ToDecimal(dataGridView2.Rows[iii].Cells["UnitPrice"].Value);       //单价（元）      
                    saledetail.MemberPrice = Convert.ToDecimal(dataGridView2.Rows[iii].Cells["MemberPrice"].Value);    //会员单价
                    saledetail.OriginalPrice = (-1) * Convert.ToDecimal(dataGridView2.Rows[iii].Cells["Grid2_OriginalPrice"].Value);       //单件进价
                    saledetail.Promotion = Convert.ToString(dataGridView2.Rows[iii].Cells["Promotion"].Value);
                    saledetail.GoodsNum = Convert.ToInt32(dataGridView2.Rows[iii].Cells["Grid2_GoodsNum"].Value);           //购买数量        
                    saledetail.Stock = Convert.ToInt32(dataGridView2.Rows[iii].Cells["Stock"].Value);
                    saledetail.DiscountRate = Convert.ToDecimal(dataGridView2.Rows[iii].Cells["Grid2_DiscountRate"].Value);             //会员价折扣率          
                    saledetail.Discount = (-1) * Convert.ToDecimal(dataGridView2.Rows[iii].Cells["Grid2_Discount"].Value);               //总折扣
                    saledetail.SalePrice = (-1) * Convert.ToDecimal(dataGridView2.Rows[iii].Cells["SalePrice"].Value);        //总销售价格（元） 会员总价      

                    saledetail.CostPrice = (-1) * Convert.ToDecimal(dataGridView2.Rows[iii].Cells["CostPrice"].Value);             //总成本价格（元）
                    saledetail.Profit = (-1) * Convert.ToDecimal(dataGridView2.Rows[iii].Cells["Grid2_Profit"].Value);               //改为实际利润  20150321
                    saledetail.Supplier = Convert.ToString(dataGridView2.Rows[iii].Cells["Supplier"].Value);                             //供应商          
                    saledetail.Status = 9;                              //数据状态        
                    saledetail.Memo = "退货_"+varMemo.Text.Trim();                                 //备注            
                    saledetail.CreateTime = DateTime.Now;                           //创建时间        
                    saledetail.UpdateTime = DateTime.Now;                        //最近修改时间    
                    saledetail.Modifier = dataGridView2.Rows[iii].Cells["Grid2_Modifier"].Value.ToString();             //最近修改人      

                    tot_costprice += saledetail.CostPrice;
                    goodnum += saledetail.GoodsNum;
                    normalprice += saledetail.GoodsNum * saledetail.UnitPrice;
                    orderDiscount += saledetail.Discount;
                    orderprofit += saledetail.Profit;
                    list2.Add(saledetail);
                    try
                    {
                        string aaa = "update sdpost_OrderDetail set status=9,memo='已退货' where id='" + dataGridView2.Rows[iii].Cells["Grid2_ID"].Value.ToString() + "' ";
                        int resp = NDolls.Data.RepositoryBase<NShop.Model.sdpost_Goods>.Excute(aaa);
                    }
                    catch (Exception ex)
                    {
                    }

                }
            }

            NShop.Model.sdpost_Order order = new NShop.Model.sdpost_Order();
            order.ID = orderid;
            order.FlowNo = orderid; 
            order.GoodsNum = goodnum;
            order.OriginalPrice = (-1) * normalprice;                            //原始价格
            order.ReceivablePrice = (-1) * Convert.ToDecimal(label10.Text);    //应收
            order.Received = (-1) * receivedmoney;          //实收
            order.Change = changemoney;            //找零
            order.Discount = orderDiscount;    //优惠金额
            order.Profit = orderprofit;           //利润
            order.DiscountRate = 100;
            order.Memo = "退货_" + varMemo.Text.Trim();                                               //备注            
            order.CreateTime = DateTime.Now;                          //创建时间        
            order.UpdateTime = DateTime.Now;                          //最近修改时间    
            order.Modifier = "system";                                //最近修改人     
            order.MemberNo = dataGridView1.CurrentRow.Cells["MemberNo"].Value.ToString();
            order.Status = 9;                                 //状态1表示已经进行过积分处理，不管成功与否
            if (string.IsNullOrEmpty(order.MemberNo))
                order.Scores = 0;
            else
                order.Scores = Convert.ToInt32(Math.Floor(order.ReceivablePrice));

            order.Details = list2;
            //order.Details = dataGridView1.Rows;

            if (os.AddTest(order))
            {
                try
                {
                    for (iii = 0; iii < list2.Count; iii++)    //修改库存
                    {
                        string json = "update sdpost_Goods set total=total+" + list2[iii].GoodsNum + " where barcode='" + list2[iii].GoodsID + "'";
                        int resp = NDolls.Data.RepositoryBase<NShop.Model.sdpost_Goods>.Excute(json);
                    }
                    if (!string.IsNullOrEmpty(order.MemberNo))
                    {
                        List<NShop.Model.sdpost_Member> members = new List<NShop.Model.sdpost_Member>();
                        NShop.Service.MemberService mmm = new NShop.Service.MemberService();
                        members = mmm.GetMemberNoPhone(order.MemberNo);
                        if (members.Count == 1)
                        {
                            members[0].Scores += Convert.ToInt32(order.Scores);
                            mmm.UpdateMember(members[0]);
                        }
                        else if (members.Count < 1)
                            MessageBox.Show("会员号不存在，无法积分。");
                        else
                            MessageBox.Show("会员号重复，无法积分。");

                    }
                }
                catch (Exception ex)
                {
                }
                MessageBox.Show("结算完成。");
            }
            else
                MessageBox.Show("记录销售信息错误，结算失败！");

        }

        private void varBeginDate_Leave(object sender, EventArgs e)
        {
            //selectorder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectorder();
        }

        public void printbackdetail()
        {
            Funs.PrintUtil.PrintReceipt(orderid);
        }           //调用打印

    }
}
