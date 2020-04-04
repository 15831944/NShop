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
    public partial class saleForm : Form
    {
        private NShop.Service.GoodsService us = new NShop.Service.GoodsService();
        private NShop.Service.OrderService os = new NShop.Service.OrderService();
        //private NShop.Service.OrderService os = new NShop.Service.OrderService();
        string sale_id = DateTime.Now.ToString("yyMMddHHmmssff");
        int goodnum=0 , grid_index_num=0;
        decimal goodprice=(decimal)0.0;             //正常价
        decimal price_member = (decimal)0.0;      //会员价，非会员=正常价
        decimal price_zk = (decimal)0.0;      //折扣价=会员价*整单折扣
        int ismember = 0;                   //是否会员，0非会员，1普通会员

        List<NShop.Model.sdopst_OrderDetail> list2 = new List<NShop.Model.sdopst_OrderDetail>();

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.F1:
                    goodsnumchg(); 
                    break;
                case Keys.F5:
                    button4_Click(null, EventArgs.Empty);
                    break;
                case Keys.F6:
                    button5_Click(null, EventArgs.Empty);
                    break;
                case Keys.F12:
                    button1_Click(null, EventArgs.Empty);
                    break;
                case Keys.F9:
                    button7_Click(null, EventArgs.Empty);
                    break;
                case Keys.Delete:
                    goodsdelfromgrid();
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        public saleForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = bindingSource1;

            this.KeyPreview = true;
        }
        
        public void freshtext()    //刷新显示
        {
            label12.Text=goodnum.ToString();                            //商品数量
            this.label17.Text=goodprice.ToString("0.00");                   //商品原价
            if (ismember==1)
                price_zk = price_member * (Convert.ToDecimal(textBox5.Text)) * (decimal)0.01;      //会员整单折扣价
            else
                price_zk = goodprice * (Convert.ToDecimal(textBox5.Text)) * (decimal)0.01;      //正常整单折扣价

            if (this.checkBox1.Checked == true)                          //抹0.5元
            {
                if ((price_zk - Math.Truncate(price_zk)) >= (decimal)0.5)
                    label10.Text = (Math.Truncate(price_zk) + (decimal)0.5).ToString("0.00");
                else
                    label10.Text = Math.Truncate(price_zk).ToString("0.00");
            }
            else if (this.checkBox2.Checked == true)                     //抹1元
                label10.Text = Math.Floor(price_zk).ToString("0.00");
            else if (checkBox3.Checked == true)                          //抹5元
            {
                if ((price_zk / (decimal)10 - Math.Truncate(price_zk / (decimal)10)) >= (decimal)0.5)
                    label10.Text = (Math.Truncate(price_zk / (decimal)10) * (decimal)10 + (decimal)5).ToString("0.00");
                else
                    label10.Text = (Math.Truncate(price_zk / (decimal)10) * (decimal)10).ToString("0.00");
            }
            else if (checkBox4.Checked == true)                          //抹10元  
                label10.Text = (Math.Truncate(price_zk / (decimal)10) * (decimal)10).ToString("0.00");
            else                                                            //抹分
            {
                switch (Funs.Constant.PriceStrategy)
                {
                    case "1": label10.Text = (Math.Ceiling(price_zk * (decimal)10) / (decimal)10).ToString("0.00");  //抹分进位
                        break;
                    case "2": label10.Text = price_zk.ToString("0.00");  //不抹分
                        break;
                    case "3": label10.Text = (Math.Truncate(price_zk * (decimal)10) / (decimal)10).ToString("0.00");  //抹分舍去
                        break;
                    case "4": label10.Text = (Math.Truncate(price_zk * (decimal)10 + (decimal)0.5) / (decimal)10).ToString("0.00");  //四舍五入
                        break;
                    default: label10.Text = price_zk.ToString("0.00");  //不抹分
                        break;
                }
            }
            //if (textBox3.Text.Equals("0.00"))                           //找零
            //    textBox4.Text = "0.00";
            //else
            //    textBox4.Text = (Convert.ToDecimal(textBox3.Text) - Convert.ToDecimal(label10.Text)).ToString("f2");
            label15.Text = (Convert.ToDecimal(label17.Text) - Convert.ToDecimal(label10.Text)).ToString("f2");
            label3.Text = sale_id;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)          //商品编码（简拼）输入后，订单明细处理
        {
            //对会员价的处理：20150228
            //设定显示原价为正常价，label17，会员优惠算在总优惠里，这样增加一个全局变量记录会员总价price_member
            //这样牵涉到后续继续，单个商品总价orderdetail.saleprice只能记正常总价，因此grid显示中去掉了单个商品总价的显示以免误解。
            //
            if (e.KeyChar == 13)
            {
                textBox1.Text = textBox1.Text.Trim();
                //MessageBox.Show(textBox1.Text);
                if (textBox1.Text == "")
                {
                    button1_Click(null, EventArgs.Empty);          //调用结算Form
                }
                else
                {
                    NShop.Model.sdpost_Goods goodsdetail = new NShop.Model.sdpost_Goods();

                    //List<NShop.Model.sdpost_Goods> list = us.GetGoodsByBarCode(textBox1.Text); us.GetGoods
                    List<NShop.Model.sdpost_Goods> list = us.GetGoods(textBox1.Text);
                    int sss = list.Count;
                    //MessageBox.Show(sss.ToString());
                    if (sss == 1)
                    {
                        grid_index_num++;
                        NShop.Model.sdopst_OrderDetail saledetail = new NShop.Model.sdopst_OrderDetail();
                        saledetail.ID = sale_id + grid_index_num.ToString("000");    //销售明细系统编号 
                        saledetail.OrderID = sale_id;                            //订单编号        
                        saledetail.GoodsID = list[0].BarCode;                                       //商品编号        
                        saledetail.GoodsName = list[0].GoodsName;                                      //商品名称        
                        saledetail.UnitPrice = list[0].RetailPrice;                                          //单价（元）      
                        if (list[0].MemberPrice == 0)
                            saledetail.MemberPrice = list[0].RetailPrice;                   //会员价
                        else
                            saledetail.MemberPrice = list[0].MemberPrice;
                        saledetail.Promotion = list[0].MemberPName;
                        saledetail.GoodsNum = 1;                                           //购买数量        
                        saledetail.Unit = list[0].Unit;                                               //商品单位        
                        if (saledetail.UnitPrice <= 0)
                            saledetail.DiscountRate = 0;
                        else
                            saledetail.DiscountRate = (saledetail.MemberPrice / saledetail.UnitPrice);                                            //折扣率          
                        saledetail.OriginalPrice = list[0].BuyingPrice;                 //总原始价格（元）  这里存成单件的进价，后边计算销售明细的时候用
                        saledetail.Discount = 0;                                                //总折扣金额（元）
                        //saledetail.SalePrice = saledetail.GoodsNum * saledetail.UnitPrice * saledetail.DiscountRate;     //总销售价格（元）正常价
                        saledetail.SalePrice = saledetail.GoodsNum * saledetail.UnitPrice;     //总销售价格（元）正常价
                        saledetail.CostPrice = saledetail.GoodsNum * list[0].BuyingPrice;       //总成本价格（元）
                        saledetail.Profit = (saledetail.SalePrice - saledetail.CostPrice);     //正常价总利润          
                        saledetail.Supplier = list[0].Supplier;                                           //供应商          
                        saledetail.Status = list[0].Status;                                             //数据状态        
                        saledetail.Memo = "";                                               //备注            
                        saledetail.CreateTime = DateTime.Now;                          //创建时间        
                        saledetail.UpdateTime = DateTime.Now;                          //最近修改时间    
                        saledetail.Modifier = "system";                                //最近修改人   
                        saledetail.Category = list[0].Category;             //商品分类

                        //list2.Add(saledetail);
                        //dataGridView1.Refresh();
                        //dataGridView1.DataSource = list2;

                        //if(dataGridView1.RowCount>2)
                        //    NShop.Funs.GridUtil.UpdateRow(bindingSource1, saledetail);
                        // else
                        NShop.Funs.GridUtil.AppendRow(bindingSource1, saledetail);
                        goodnum += saledetail.GoodsNum;
                        goodprice = goodprice + saledetail.SalePrice;
                        price_member += saledetail.MemberPrice * saledetail.GoodsNum;
                        freshtext();
                        //dataGridView1.Rows[dataGridView1.RowCount - 1].Selected=true;
                        //dataGridView1.CurrentRow.Index = dataGridView1.RowCount - 1;
                        //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[17];
                    }
                    else if (sss > 1)
                    {
                        grid_index_num++;
                        goodselectForm selectgoodsid = new goodselectForm();
                        selectgoodsid.dataGridView1.DataSource = list;
                        selectgoodsid.ShowDialog(this);
                    }
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }

        }

        public void goodselectenter(NShop.Model.sdopst_OrderDetail saledetail)  //从goodselectForm(多项商品选择)窗口返回选定的商品后，处理订单明细
        {
            saledetail.ID = sale_id + grid_index_num.ToString("000");    //销售明细系统编号 
            saledetail.OrderID = sale_id;                            //订单编号        
            NShop.Funs.GridUtil.AppendRow(bindingSource1, saledetail);
            goodnum += saledetail.GoodsNum;
            goodprice = goodprice + saledetail.SalePrice;
            price_member += saledetail.MemberPrice * saledetail.GoodsNum;
            freshtext();
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[17];
        }

        private void saleForm_Load(object sender, EventArgs e)          //主窗口生成时，显示一下流水号
        {
            label3.Text = sale_id;
            textBox3.Focus();
        }

        private void button1_Click(object sender, EventArgs e)          //调用结算Form
        {
            if (dataGridView1.RowCount > 0)
            {
                payForm pay_form = new payForm();
                pay_form.textBox1.Text = this.label10.Text;
                pay_form.textBox2.Text = this.label10.Text;
                //changegoodsnum.textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                pay_form.ShowDialog(this);
                if (pay_form.DialogResult == DialogResult.OK)  //如果结算成功，应该返回焦点给textbox3，如果结算不成功，应该返回焦点给textbox1
                {
                    textBox3.Enabled = true;
                    textBox3.Text = "";
                    textBox3.Focus();
                    label6.Text = "";
                }
                else
                {
                    textBox1.Focus();           
                    textBox1.SelectAll();
                }
            }
            else
            {
                textBox3.Enabled = true;
                //textBox3.Focus();
                //textBox3.Text="";
                //label6.Text = "";
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }       

            
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)      //整单折扣输入，控制只能输入数字和一个小数点，刷新显示
        {
            if (e.KeyChar == 13 || e.KeyChar == 123) 
                freshtext();
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
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)         //控制整单折扣输入框离开时，取缔空值并刷新
        {
            if (this.textBox5.Text.Trim() == string.Empty)
                textBox5.Text = "100";
            freshtext();
        }

        private void textBox5_Enter(object sender, EventArgs e)     //整单折扣输入框进入时，高亮text
        {
            textBox5.SelectAll();
        }       

        public void goodsdelfromgrid()           //删除当前代售记录
        {
            if (dataGridView1.RowCount > 0)
            {
                if ((MessageBox.Show("确定要删除当前商品吗？", "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    goodnum -= (int)dataGridView1.CurrentRow.Cells["GoodsNum"].Value;
                    goodprice -= (decimal)dataGridView1.CurrentRow.Cells["SalePrice"].Value;
                    price_member -= (decimal)dataGridView1.CurrentRow.Cells["MemberPrice"].Value * (int)dataGridView1.CurrentRow.Cells["GoodsNum"].Value;
                    freshtext();
                    this.dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    //if (dataGridView1.RowCount > 1)
                    //{
                    //    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[17];
                    //}
                }
            }
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.checkBox2.Checked = false;
                this.checkBox3.Checked = false;
                this.checkBox4.Checked = false;
            }
            freshtext();
        }    //抹零选择，互斥并刷新显示

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            freshtext();
        }    //抹零选择，互斥并刷新显示

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
            freshtext();
        }    //抹零选择，互斥并刷新显示

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            freshtext();
        }    //抹零选择，互斥并刷新显示

        public void changegoodsnum(int singlegoodsnum , bool isgift)      //变更单件数量并刷新，由changegoodsnumForm调用
        {
            int iii = 0;
            int GoodsNum = singlegoodsnum;
            decimal OriginalPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["OriginalPrice"].Value);           //成本单价（元）      
            decimal DiscountRate = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["DiscountRate"].Value);           //折扣率  
            decimal UnitPrice, MemberPrice;
            if (isgift == true)    //赠品
            {
                UnitPrice = 0;           //销售单价（元）      
                MemberPrice = 0;          //会员价
                dataGridView1.CurrentRow.Cells["UnitPrice"].Value = (decimal)0;
                dataGridView1.CurrentRow.Cells["MemberPrice"].Value = (decimal)0;
                dataGridView1.CurrentRow.Cells["Memo"].Value = "赠品";
            }
            else
            {
                NShop.Model.sdpost_Goods aaa = us.GetGoodsByBarCode_mustone(dataGridView1.CurrentRow.Cells["GoodsID"].Value.ToString());
                if (aaa == null)
                {
                    UnitPrice = 0;           //销售单价（元）      
                    MemberPrice = 0;          //会员价
                    dataGridView1.CurrentRow.Cells["UnitPrice"].Value = (decimal)0;
                    dataGridView1.CurrentRow.Cells["MemberPrice"].Value = (decimal)0;
                    dataGridView1.CurrentRow.Cells["Memo"].Value = "";
                }
                else
                {
                    if (aaa.MemberPrice==0)
                        aaa.MemberPrice = aaa.RetailPrice;
                    dataGridView1.CurrentRow.Cells["UnitPrice"].Value = aaa.RetailPrice;
                    dataGridView1.CurrentRow.Cells["MemberPrice"].Value = aaa.MemberPrice;
                    UnitPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["UnitPrice"].Value);           //销售单价（元）      
                    MemberPrice = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["MemberPrice"].Value);          //会员价
                    dataGridView1.CurrentRow.Cells["Memo"].Value = "";
                }
            }
            dataGridView1.CurrentRow.Cells["GoodsNum"].Value = GoodsNum;
            dataGridView1.CurrentRow.Cells["CostPrice"].Value = GoodsNum * OriginalPrice;                             //总成本价格（元）
            dataGridView1.CurrentRow.Cells["Discount"].Value = (decimal)GoodsNum * (UnitPrice - MemberPrice);       //总折扣金额（元）
            dataGridView1.CurrentRow.Cells["SalePrice"].Value = GoodsNum * UnitPrice;                       //销售总价
            dataGridView1.CurrentRow.Cells["Profit"].Value = GoodsNum * UnitPrice - GoodsNum * OriginalPrice;           //按正常价的总利润  

            goodprice = (decimal)0;
            goodnum = 0;
            price_member = 0;
            for (iii = 0; iii < dataGridView1.RowCount; iii++)
            {
                goodprice += (decimal)dataGridView1.Rows[iii].Cells["SalePrice"].Value;
                goodnum += (int)dataGridView1.Rows[iii].Cells["GoodsNum"].Value;
                price_member += (decimal)dataGridView1.Rows[iii].Cells["MemberPrice"].Value * (int)(dataGridView1.Rows[iii].Cells["GoodsNum"].Value);
            }
            freshtext();
        }

        public void savedata(decimal receivedmoney,decimal changemoney,int iscash)      //订单数据存库，由payForm调用
        {                                                                               //iscash：0现金，1银行卡
            //订单与订单详情关联
            int iii;
            decimal tot_costprice = (decimal)0.0;       //总成本
            List<NShop.Model.sdpost_Goods> listgoods = new List<NShop.Model.sdpost_Goods>();

            for (iii = 0; iii < dataGridView1.RowCount; iii++)
            {
                NShop.Model.sdopst_OrderDetail saledetail = new NShop.Model.sdopst_OrderDetail();
                NShop.Model.sdpost_Goods salegoods = new NShop.Model.sdpost_Goods();
                salegoods = us.GetGoodsByBarCode_mustone(dataGridView1.Rows[iii].Cells["GoodsID"].Value.ToString());
                salegoods.Alarm = Convert.ToInt32(dataGridView1.Rows[iii].Cells["GoodsNum"].Value);        //alarm域存一下代售数量

                saledetail.ID = dataGridView1.Rows[iii].Cells["ID"].Value.ToString();                       //销售明细系统编号 
                saledetail.OrderID      = dataGridView1.Rows[iii].Cells["OrderID"].Value.ToString();                  //订单编号        
                saledetail.GoodsID      = dataGridView1.Rows[iii].Cells["GoodsID"].Value.ToString();                  //商品编号        
                saledetail.GoodsName    = dataGridView1.Rows[iii].Cells["GoodsName"].Value.ToString();              //商品名称        
                saledetail.Unit         = Convert.ToString(dataGridView1.Rows[iii].Cells["Unit"].Value);                         //商品单位        
                saledetail.UnitPrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["UnitPrice"].Value);       //单价（元）      
                saledetail.MemberPrice  = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["MemberPrice"].Value);    //会员单价
                saledetail.GoodsNum     = Convert.ToInt32(dataGridView1.Rows[iii].Cells["GoodsNum"].Value);           //购买数量        
                saledetail.OriginalPrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["OriginalPrice"].Value);       //单件进价
                saledetail.Stock = salegoods.Total;                     //售后库存
                if (ismember == 1)
                    saledetail.SalePrice = saledetail.MemberPrice * saledetail.GoodsNum;         //总销售价格（元） 会员总价      
                else
                    saledetail.SalePrice = saledetail.UnitPrice * saledetail.GoodsNum;           //总销售价格（元） 正常总价
                saledetail.SalePrice *= decimal.Parse(textBox5.Text.Trim()) / (decimal)100;//每个单件商品计算整单折扣后的价格
                saledetail.CostPrice = saledetail.OriginalPrice * saledetail.GoodsNum;            //总成本价格（元）
                saledetail.DiscountRate = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["DiscountRate"].Value);             //会员价折扣率          
                saledetail.Profit = saledetail.SalePrice - saledetail.CostPrice;               //改为实际利润  20150321
                saledetail.Supplier = Convert.ToString(dataGridView1.Rows[iii].Cells["Supplier"].Value);                             //供应商          
                saledetail.Status       = Convert.ToInt32(dataGridView1.Rows[iii].Cells["Status"].Value);                              //数据状态        
                saledetail.Memo         = Convert.ToString(dataGridView1.Rows[iii].Cells["Memo"].Value);                                 //备注            
                saledetail.CreateTime   = Convert.ToDateTime(dataGridView1.Rows[iii].Cells["CreateTime"].Value);                          //创建时间        
                saledetail.UpdateTime   = Convert.ToDateTime(dataGridView1.Rows[iii].Cells["UpdateTime"].Value);                         //最近修改时间    
                //saledetail.Modifier     = dataGridView1.Rows[iii].Cells["Modifier"].Value.ToString();             //最近修改人      
                saledetail.Modifier = NShop.Funs.Constant.UserName;             //最近修改人      
                saledetail.Category = Convert.ToString(dataGridView1.Rows[iii].Cells["Category"].Value);
                saledetail.Promotion    = Convert.ToString(dataGridView1.Rows[iii].Cells["Promotion"].Value);
                saledetail.Discount = saledetail.UnitPrice * saledetail.GoodsNum-saledetail.SalePrice;               //总折扣

                tot_costprice += saledetail.CostPrice;
                list2.Add(saledetail);
                listgoods.Add(salegoods);         
            }

            NShop.Model.sdpost_Order order = new NShop.Model.sdpost_Order();
            order.ID = sale_id;
            order.FlowNo = sale_id;
            order.GoodsNum = goodnum;
            order.OriginalPrice = goodprice;                            //原始价格
            order.ReceivablePrice = Convert.ToDecimal(label10.Text);    //应收
            order.Received = receivedmoney;          //实收
            order.Change = changemoney;            //找零
            order.Discount = order.OriginalPrice - order.ReceivablePrice;    //优惠金额
            order.Profit = order.ReceivablePrice - tot_costprice;           //利润
            order.DiscountRate = Convert.ToDecimal(textBox5.Text);
            order.Memo = "";                                               //备注            
            order.CreateTime = DateTime.Now;                          //创建时间        
            order.UpdateTime = DateTime.Now;                          //最近修改时间    
            order.Modifier = NShop.Funs.Constant.UserName;                                //最近修改人     
            order.MemberNo = textBox3.Text.Trim();
            order.Status = 1;                                 //状态1表示已经进行过积分处理，不管成功与否
            if (ismember == 1)
                order.Scores = Convert.ToInt32(Math.Floor(order.ReceivablePrice));
            else
                order.Scores = 0;
            if (iscash == 1)    //银行卡
                order.BandCard = 1;
            else
                order.Cash = 1;

            order.Details = list2;
            //order.Details = dataGridView1.Rows;

            if (os.AddTest(order))
            {
                //for (iii = 0; iii < dataGridView1.RowCount; iii++)    //修改库存
                //{
                //    NShop.Model.sdpost_Goods saledetail = new NShop.Model.sdpost_Goods();
                //    saledetail = us.GetGoodsByBarCode_mustone(dataGridView1.Rows[iii].Cells["GoodsID"].Value.ToString());                  //商品编号        
                //    saledetail.Total -= Convert.ToInt32(dataGridView1.Rows[iii].Cells["GoodsNum"].Value);
                //    if(us.updateGoodsnum(saledetail))
                //    {
                //        //MessageBox.Show("改完了。");
                //    }
                //    else
                //    {
                //        //MessageBox.Show("没改成？");
                //    }
                //}
                try
                {
                    for (iii = 0; iii < listgoods.Count; iii++)    //修改库存
                    {
                        //us.updateGoodsnum(listgoods[iii]);  //不能用这个方式，多条同样商品，每次读出来的售前库存是一样的，现有的model方式改库存就不可用。所以要么改成订单存盘后自己写句子update，要么在订单存之前就改库存，这样订单存盘失败的时候库存量就会错
                        string json = "update sdpost_Goods set total=total-" + listgoods[iii].Alarm + " where id='" + listgoods[iii].ID + "' and barcode='" + listgoods[iii].BarCode + "'";
                        int resp = NDolls.Data.RepositoryBase<NShop.Model.sdpost_Goods>.Excute(json);
                    }
                    //List<NShop.Model.sdpost_Member> members = new List<NShop.Model.sdpost_Member>();
                    if (ismember == 1)
                    {
                        List<NShop.Model.sdpost_Member> members = new List<NShop.Model.sdpost_Member>();
                        NShop.Service.MemberService mmm = new NShop.Service.MemberService();
                        members = mmm.GetMemberNoPhone(textBox3.Text.Trim());
                        if (members.Count == 1)
                        {
                            members[0].Scores += Convert.ToInt32(Math.Floor(order.ReceivablePrice));
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

        private void goodsnumchg()                   //调用数量修改form
        {
            if (dataGridView1.RowCount > 0)
            {
                changegoodsnumForm changegoodsnum = new changegoodsnumForm();
                changegoodsnum.label2.Text = dataGridView1.CurrentRow.Cells["GoodsName"].Value.ToString();
                changegoodsnum.textBox1.Text = dataGridView1.CurrentRow.Cells["GoodsNum"].Value.ToString();
                changegoodsnum.ShowDialog(this);
            }
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)            //调用数量修改form
        {
            goodsnumchg();
        }       

        private void button2_Click(object sender, EventArgs e)     //调用订单明细项删除函数
        {
            //button1_Click(null, EventArgs.Empty);
            //dataGridView1_KeyDown(null, KeyEventArgs e);
            goodsdelfromgrid();
        }

        private void button3_Click(object sender, EventArgs e)      //调用商品数量修改函数
        {
            goodsnumchg();
        }       

        public void printdetail()
        {
            Funs.PrintUtil.PrintReceipt(sale_id);
        }           //调用打印

        public void truncatedetail()              //初始化界面
        {
            goodnum = 0;                        //记录数量
            goodprice = 0;                      //记录总价
            price_member = 0;                   //记录会员总价
            ismember = 0;                       //是否会员
            grid_index_num = 0;                 //订单明细的序列数
            dataGridView1.Rows.Clear();         
            sale_id = DateTime.Now.ToString("yyMMddHHmmssff");
            textBox5.Text = "100";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            freshtext();
            textBox1.Text = "";
            textBox3.Text = "";
            textBox3.Enabled = true;
            textBox3.Focus();
            textBox3.Text = "";
            label6.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)        //挂单，并初始化界面
        {
            if (dataGridView1.RowCount < 1)
            {
                textBox1.Focus();
                textBox1.SelectAll();
                return;
            }

            int iii;
            string namelist = "";
            //int btn4_goodnums = 0;
            //decimal btn4_totalprice = (decimal)0.0;
            for (iii = 0; iii < dataGridView1.RowCount; iii++)
            {
                NShop.Model.sdopst_OrderDetail saledetail = new NShop.Model.sdopst_OrderDetail();
                saledetail.ID = dataGridView1.Rows[iii].Cells["ID"].Value.ToString();                       //销售明细系统编号 
                saledetail.OrderID = dataGridView1.Rows[iii].Cells["OrderID"].Value.ToString();                  //订单编号        
                saledetail.GoodsID = dataGridView1.Rows[iii].Cells["GoodsID"].Value.ToString();                  //商品编号        
                saledetail.GoodsName = dataGridView1.Rows[iii].Cells["GoodsName"].Value.ToString();              //商品名称        
                saledetail.UnitPrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["UnitPrice"].Value);       //单价（元）      
                saledetail.GoodsNum = Convert.ToInt32(dataGridView1.Rows[iii].Cells["GoodsNum"].Value);           //购买数量        
                saledetail.Unit = Convert.ToString(dataGridView1.Rows[iii].Cells["Unit"].Value);                         //商品单位        
                saledetail.OriginalPrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["OriginalPrice"].Value);       //总原始价格（单件进价）
                saledetail.DiscountRate = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["DiscountRate"].Value);             //折扣率          
                saledetail.Discount = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["Discount"].Value);                     //总折扣金额（元）
                saledetail.SalePrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["SalePrice"].Value);            //总销售价格（元）
                saledetail.CostPrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["CostPrice"].Value);            //总成本价格（元）
                saledetail.Profit = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["Profit"].Value);      //总利润          
                saledetail.Supplier = Convert.ToString(dataGridView1.Rows[iii].Cells["Supplier"].Value);                             //供应商          
                saledetail.Status = Convert.ToInt32(dataGridView1.Rows[iii].Cells["Status"].Value);                              //数据状态        
                saledetail.Memo = Convert.ToString(dataGridView1.Rows[iii].Cells["Memo"].Value);                                 //备注            
                saledetail.CreateTime = Convert.ToDateTime(dataGridView1.Rows[iii].Cells["CreateTime"].Value);                          //创建时间        
                saledetail.UpdateTime = Convert.ToDateTime(dataGridView1.Rows[iii].Cells["UpdateTime"].Value);                         //最近修改时间    
                saledetail.Modifier = Convert.ToString(dataGridView1.Rows[iii].Cells["Modifier"].Value);             //最近修改人      
                saledetail.Category = Convert.ToString(dataGridView1.Rows[iii].Cells["Category"].Value);             //商品分类   
                saledetail.MemberPrice = Convert.ToDecimal(dataGridView1.Rows[iii].Cells["MemberPrice"].Value);
                saledetail.Promotion = Convert.ToString(dataGridView1.Rows[iii].Cells["Promotion"].Value); 

                namelist = namelist + saledetail.GoodsName + "|";
                //btn4_goodnums += saledetail.GoodsNum;
                //btn4_totalprice += saledetail.SalePrice;
                Funs.Constant.list_pause.Add(saledetail);
            }
            NShop.Model.sdpost_Order p_orderlist = new NShop.Model.sdpost_Order();
            //p_orderlist.FlowNo = dataGridView1.Rows[iii].Cells["OrderID"].Value.ToString();
            p_orderlist.FlowNo = sale_id;
            p_orderlist.Memo = namelist;
            //p_orderlist.GoodsNum = btn4_goodnums;
            //p_orderlist.ReceivablePrice = btn4_totalprice;     //应收金额，临时存挂单的总价
            p_orderlist.GoodsNum = this.goodnum;
            p_orderlist.ReceivablePrice = this.goodprice;       //应收金额，临时存挂单的正常总价
            p_orderlist.Status = this.grid_index_num;           //状态，临时存挂单的明细流水序列数
            p_orderlist.CreateTime = DateTime.Now;
            p_orderlist.Received = this.price_member;           //实收金额，这里临时存放挂单的会员总价
            p_orderlist.ValueCard = ismember;                   //存放是否会员
            p_orderlist.ValueCardNo = label6.Text;              //存放会员名称
            p_orderlist.MemberNo = textBox3.Text;               //存放会员号

            Funs.Constant.pause_order_list.Add(p_orderlist);
            
            truncatedetail();
        }

        private void button5_Click(object sender, EventArgs e)      //取挂单
        {
            if (Funs.Constant.pause_order_list.Count < 1)
            {
                MessageBox.Show("没有挂单数据。");
                if (dataGridView1.RowCount > 0)  
                {
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                else
                {
                    textBox3.Enabled = true;
                    textBox3.Focus();
                    textBox3.Text="";
                    label6.Text = "";
                }
                return;
            }
            
            if (dataGridView1.RowCount > 0)
            {
                if (MessageBox.Show("当前订单未完成，是否挂单？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    button4_Click(null,EventArgs.Empty);
                }
                else
                {
                    textBox1.Focus();
                    textBox1.SelectAll();
                    return;
                }
            }
            if (Funs.Constant.pause_order_list.Count == 1)
            {
                for (int iii = 0; iii < Funs.Constant.list_pause.Count; iii++)
                {
                    NShop.Funs.GridUtil.AppendRow(bindingSource1, Funs.Constant.list_pause[iii]);
                }
                this.sale_id = Funs.Constant.pause_order_list[0].FlowNo;
                this.goodnum = Funs.Constant.pause_order_list[0].GoodsNum;
                this.goodprice = Funs.Constant.pause_order_list[0].ReceivablePrice;
                this.grid_index_num = Funs.Constant.pause_order_list[0].Status;
                this.price_member = Funs.Constant.pause_order_list[0].Received;
                this.ismember = (int)Funs.Constant.pause_order_list[0].ValueCard;
                label6.Text = Funs.Constant.pause_order_list[0].ValueCardNo;
                textBox3.Text = Funs.Constant.pause_order_list[0].MemberNo;
                //textBox3.Enabled = false;
                this.freshtext();
                Funs.Constant.pause_order_list.Clear();
                Funs.Constant.list_pause.Clear();
                textBox1.Focus();
                textBox1.SelectAll();
            }
            else
            {
                getpauseorderForm getpauseorderid = new getpauseorderForm();
                getpauseorderid.dataGridView1.DataSource = Funs.Constant.pause_order_list;
                getpauseorderid.ShowDialog(this);
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        public void orderselectenter(int orderindex)    //多条挂单，选定一条后处理，由getpauseorderForm调用
        {
            this.sale_id = Funs.Constant.pause_order_list[orderindex].FlowNo;
            this.goodnum = Funs.Constant.pause_order_list[orderindex].GoodsNum;
            this.goodprice = Funs.Constant.pause_order_list[orderindex].ReceivablePrice;
            this.grid_index_num = Funs.Constant.pause_order_list[orderindex].Status;
            this.price_member = Funs.Constant.pause_order_list[orderindex].Received;
            this.ismember = (int)Funs.Constant.pause_order_list[orderindex].ValueCard;
            label6.Text = Funs.Constant.pause_order_list[orderindex].ValueCardNo;
            textBox3.Text = Funs.Constant.pause_order_list[orderindex].MemberNo;
            //textBox3.Enabled = false;
            //for (int iii = 0; iii < Funs.Constant.list_pause.Count; iii++)
            //{
            //    if (Funs.Constant.list_pause[iii].OrderID == this.sale_id)
            //    {
            //        NShop.Funs.GridUtil.AppendRow(bindingSource1, Funs.Constant.list_pause[iii]);

            //    }
            //}
            bindingSource1.DataSource = Funs.Constant.list_pause.FindAll(delegate(NShop.Model.sdopst_OrderDetail pp) { return pp.OrderID == this.sale_id; });
            //dataGridView1.DataSource = bindingSource1;

            this.freshtext();
            Funs.Constant.pause_order_list.RemoveAt(orderindex);
            Funs.Constant.list_pause.RemoveAll(delegate(NShop.Model.sdopst_OrderDetail pp) { return pp.OrderID == this.sale_id; });
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.SelectAll();
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)  //实时刷新，用来解决输入折扣过程中直接按F12的时候，结算金额不按折扣刷新的情况
        {
            if (this.textBox5.Text.Trim() == string.Empty)
            {
                textBox5.Text = "0";
                textBox5.SelectAll();
            }
            freshtext();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                memberenter();
            }
        }

        private void memberenter()    //会员号处理
        {
            if (textBox3.Text.Trim() == string.Empty)
            {
                textBox1.Focus();
                //textBox3.Enabled = false;
                textBox3.Text = "";
                label6.Text = "非会员";
                ismember = 0;
            }
            else
            {
                List<NShop.Model.sdpost_Member> members = new List<NShop.Model.sdpost_Member>();
                NShop.Service.MemberService mmm = new NShop.Service.MemberService();
                members = mmm.GetMemberNoPhone(textBox3.Text.Trim());
                if (members == null || members.Count == 0)
                {
                    label6.Text = "非会员";
                    textBox3.Text = "";
                    textBox1.Focus();
                    ismember = 0;
                }
                else if (members.Count == 1)
                {
                    textBox1.Focus();
                    textBox3.Text = members[0].MemberNo;
                    label6.Text = members[0].MemberName.Trim() + "（当前积分：" + members[0].Scores.ToString() + "）";
                    ismember = 1;
                }
                else
                {
                    MemberSelect frm = new MemberSelect(members);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        textBox1.Focus();
                        textBox3.Text = frm.member.MemberNo;
                        label6.Text = frm.member.MemberName.Trim() + "（当前积分：" + frm.member.Scores.ToString() + "）";
                        ismember = 1;
                    }
                }
            }
            freshtext();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            truncatedetail();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            memberenter();
        }

        private void saleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.RowCount > 0 || Funs.Constant.pause_order_list.Count > 0)
            {
                if (MessageBox.Show("当前订单未完成或者有挂单，退出将放弃这些数据，是否继续？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
