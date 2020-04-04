using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Entity;

namespace NShop.Manage
{
    public partial class GoodsInEx : BaseForm
    {
        NShop.Service.GoodsService s = new NShop.Service.GoodsService();
        NShop.Service.DicService d = new NShop.Service.DicService();

        NShop.Model.sdpost_Goods gm = new NShop.Model.sdpost_Goods();
        NShop.Model.sdpost_GoodsIn gim = new NShop.Model.sdpost_GoodsIn();

        private NShop.Service.OrderService os = new NShop.Service.OrderService();
        NShop.Service.SupplierService _s = new NShop.Service.SupplierService();

        public GoodsInEx()
        {
            InitializeComponent();
        }

        private String code = "";
        public GoodsInEx(String code)
        {
            InitializeComponent();

            this.code = code;
        }

        private void GoodsIn_Load(object sender, EventArgs e)
        {
            varCreateTime.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varCategory,
                "DName", "DName", d.GetDicsByType("商品类别"));
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varUnit,
                "DName", "DName", d.GetDicsByType("商品单位"));
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varBrand,
                "DName", "DName", d.GetDicsByType("商品品牌"));

            if (!String.IsNullOrEmpty(code))
            {
                varBarCode.Text = code;
                varBarCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            }

            varBarCode.SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SelectGoods sfrm = null;
        private void varBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<NShop.Model.sdpost_Goods> list = s.GetGoods(varBarCode.Text.Trim());
                if (list != null && list.Count == 1)
                {
                    gm = list[0];
                    NDolls.Forms.WinUtil.SetObject(this, gm, "var");
                    varGoodsName_Leave(sender, e);

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
                    varGoodsName.Focus();
                }
            }
        }

        private void varBarCode_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(varBarCode.Text.Trim()))
            {
                varBarCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //对象构造
            gm = s.GetGoodsByBarCode_mustone(varBarCode.Text.Trim());
            if (gm == null) gm = new NShop.Model.sdpost_Goods();
            NDolls.Forms.WinUtil.GetModel(this, gm, "var");
            if (String.IsNullOrEmpty(gm.ID))
            {
                gm.ID = Guid.NewGuid().ToString("N");
                gm.CreateTime = DateTime.Now;
            }
            gm.IsOnSale = true;
            gm.UpdateTime = DateTime.Now;

            NDolls.Forms.WinUtil.GetModel(this, gim, "var");
            if (String.IsNullOrEmpty(gim.ID))
            {
                gim.ID = Guid.NewGuid().ToString("N");
                gim.CreateTime = DateTime.Now;

                gm.Total += gim.InCount;//若新增入库，则更新库存数量
            }
            gim.GoodsID = gm.ID;
            gim.UpdateTime = DateTime.Now;

            //数据验证
            String msg = NShop.Service.GoodsService.r.Validate(gm);
            if (!String.IsNullOrEmpty(msg))
            {
                Funs.ControlUtil.ShowValidateMsg(this, msg);
                gm.ID = null;
                return;
            }

            msg = NShop.Service.GoodsService.ir.Validate(gim);
            if (!String.IsNullOrEmpty(msg))
            {
                Funs.ControlUtil.ShowValidateMsg(this, msg);
                gim.ID = null;
                return;
            }

            if (float.Parse(varMemberPrice.Text) > float.Parse(varRetailPrice.Text))
            {
                MessageBox.Show("会员价应不大于零售价");
                varMemberPrice.Focus();
                return;
            }

            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();
            if (!d.Exist("商品类别", varCategory.Text.Trim()))
            {
                NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                dm.DID = Guid.NewGuid().ToString("N");
                dm.DType = "商品类别";
                dm.DName = varCategory.Text.Trim();
                dm.CreateTime = dm.UpdateTime = DateTime.Now;
                list.Add(dm);
            }
            if (!d.Exist("商品单位", varUnit.Text.Trim()))
            {
                NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                dm.DID = Guid.NewGuid().ToString("N");
                dm.DType = "商品单位";
                dm.DName = varUnit.Text.Trim();
                dm.CreateTime = dm.UpdateTime = DateTime.Now;
                list.Add(dm);
            }
            if (!d.Exist("商品品牌", varBrand.Text.Trim()))
            {
                NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                dm.DID = Guid.NewGuid().ToString("N");
                dm.DType = "商品品牌";
                dm.DName = varBrand.Text.Trim();
                dm.CreateTime = dm.UpdateTime = DateTime.Now;
                list.Add(dm);
            }

            //维护供应商信息
            if (varSupplier.Text.Trim() != "")
            {
                try
                {
                    varSupplier.Tag = _s.Find(new List<Item> { new ConditionItem("SName", varSupplier.Text.Trim(), SearchType.Accurate) })[0].SID;
                }
                catch
                { }

                NShop.Model.sdpost_Supplier _sm = new NShop.Model.sdpost_Supplier();
                if (varSupplier.Tag == null || String.IsNullOrEmpty(varSupplier.Tag.ToString()))
                {
                    _sm.SID = Guid.NewGuid().ToString("N");
                    _sm.CreateTime = _sm.UpdateTime = DateTime.Now;
                    _sm.ShortCode = Funs.SpellingUtil.GetPrefixLetters(varSupplier.Text.Trim());
                }
                else
                {
                    _sm = _s.GetModel(varSupplier.Tag.ToString());
                    _sm.UpdateTime = DateTime.Now;
                }
                _sm.SName = varSupplier.Text.Trim();
                list.Add(_sm);

                NShop.Model.sdpost_SupplierGoods sgm = new NShop.Model.sdpost_SupplierGoods();
                sgm.SID = _sm.SID;
                sgm.GoodsID = gm.ID;
                sgm.GoodsName = gm.GoodsName;
                sgm.GoodsBrand = gm.Brand;
                sgm.BuyingPrice = gm.BuyingPrice;
                sgm.SalePrice = gm.RetailPrice;
                list.Add(sgm);
            }

            list.Add(gm);
            list.Add(gim);

            NShop.Model.sdpost_StockLog sm = new NShop.Model.sdpost_StockLog();
            sm.ID = Guid.NewGuid().ToString("N");
            sm.GoodsID = gm.ID;
            sm.PreStock = gm.Total - gim.InCount;
            sm.Variation = gim.InCount;
            sm.AfterStock = gm.Total;
            sm.CreateTime = sm.UpdateTime = DateTime.Now;
            sm.Modifier = Funs.Constant.UserAccount;
            sm.StockMark = "正常入库";
            list.Add(sm);
            
            if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
            {
                #region 临时使用
                if (gm.BuyingPrice > 0)
                    os.resetOrderDetails(gm);
                #endregion

                btnNew_Click(sender, e);

                MessageBox.Show("入库成功");
            }
            else
            {
                MessageBox.Show("入库失败");
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

            varTotal.Text = "--";
            //NDolls.Forms.WinUtil.Reset(panel1);
            NDolls.Forms.WinUtil.Reset(groupBox1);
            varBarCode.Clear();
        }

        private void varGoodsName_Leave(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(varShortCode.Text.Trim()))
                varShortCode.Text = Funs.SpellingUtil.GetPrefixLetters(varGoodsName.Text.Trim());
        }

        private void GoodsIn_Activated(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(varGoodsName.Text.Trim()))
                varInCount.Focus();
        }

        private void varRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void varRetailPrice_Leave(object sender, EventArgs e)
        {
            if (varRetailPrice.Text != "" && varMemberPrice.Text == "")
            {
                varMemberPrice.Text = varRetailPrice.Text;
            }
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
