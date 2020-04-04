using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Core.Util;

namespace NShop.Manage
{
    public partial class GoodsIn : BaseForm
    {
        private String barcode;
        private NShop.Model.sdpost_Goods gm = new NShop.Model.sdpost_Goods();
        private NShop.Model.sdpost_GoodsIn gim = new NShop.Model.sdpost_GoodsIn();
        private NShop.Service.GoodsService s = new NShop.Service.GoodsService();

        public GoodsIn(String barcode)
        {
            this.barcode = barcode;
            InitializeComponent();
        }

        private void GoodsIn_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(barcode))
            {
                varBarCode.Text = barcode;
                varBarCode_Leave(sender, e);
            }
        }

        SelectGoods sfrm = null;
        private void varBarCode_Leave(object sender, EventArgs e)
        {
            if (varBarCode.Text == "") return;

            List<NShop.Model.sdpost_Goods> list = s.GetGoods(varBarCode.Text.Trim());
            if (list != null && list.Count == 1)
            {
                gm = list[0];
                NDolls.Forms.WinUtil.SetObject(this, gm, "var");

                varInCount.Focus();
            }
            else if (list != null && list.Count > 1)
            {
                if (sfrm != null) return;

                sfrm = new SelectGoods(list);
                if (sfrm.ShowDialog() == DialogResult.OK)
                {
                    String barCode = sfrm.BarCode;
                    varBarCode.Text = barCode;
                    list = s.GetGoods(varBarCode.Text.Trim());
                    gm = list[0];
                    NDolls.Forms.WinUtil.SetObject(this, gm, "var");
                    varInCount.Focus();
                }
                sfrm = null;
            }
            else
            {
                if (!btnClose.Focused)//非关闭操作，提示新增商品
                {
                    varBarCode.Focus();
                    if (MessageBox.Show("该商品不存在，是否立即录入商品信息？","新增商品提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        GoodsMng frm = new GoodsMng(varBarCode.Text);
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool check()
        {
            if (!ValidateUtil.IsMatch(varInCount.Text, ValidateUtil.GetPattern("PositiveInt")))
            {
                varInCount.Focus();
                MessageBox.Show("入库数量应为正整数!");
                return false;
            }

            if (!ValidateUtil.IsMatch(varBuyingPrice.Text, ValidateUtil.GetPattern("PositiveNumber")))
            {
                varBuyingPrice.Focus();
                MessageBox.Show("商品进价有误!");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check())
            {
                List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();

                NDolls.Forms.WinUtil.GetModel(this, gim, "var");
                if (String.IsNullOrEmpty(gim.ID))
                {
                    gim.ID = Guid.NewGuid().ToString("N");
                    gim.CreateTime = DateTime.Now;

                    gm.Total += gim.InCount;//若新增入库，则更新库存数量
                }
                gim.GoodsID = gm.ID;
                gim.RetailPrice = gm.RetailPrice;
                gim.UpdateTime = DateTime.Now;
                gim.Brand = gm.Brand;
                gim.Unit = gm.Unit;

                gm.Supplier = gim.Supplier;//更新商品信息的供应商

                list.Add(gm);//商品信息
                list.Add(gim);//入库信息

                NShop.Model.sdpost_StockLog sm = new NShop.Model.sdpost_StockLog();
                sm.ID = Guid.NewGuid().ToString("N");
                sm.GoodsID = gm.ID;
                sm.PreStock = gm.Total - gim.InCount;
                sm.Variation = gim.InCount;
                sm.AfterStock = gm.Total;
                sm.CreateTime = sm.UpdateTime = DateTime.Now;
                sm.Modifier = Funs.Constant.UserAccount;
                sm.StockMark = "正常入库";
                list.Add(sm);//库存变动记录

                if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
                {
                    btnNew_Click(sender, e);

                    MessageBox.Show("入库成功");
                }
                else
                {
                    MessageBox.Show("入库失败");
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            initControls();
            varBarCode.Focus();
        }

        private void initControls()
        {
            gm = new NShop.Model.sdpost_Goods();
            gim = new NShop.Model.sdpost_GoodsIn();

            varTotal.Text = "库存量";
            varGoodsName.Text = "商品名称";
            NDolls.Forms.WinUtil.Reset(groupBox1);
            varBarCode.Clear();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectSupplier frm = new SelectSupplier();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                varSupplier.Text = frm.SName;
                varSupplier.Tag = frm.SID;
            }
        }
    }
}
