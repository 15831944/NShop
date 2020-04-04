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
    public partial class GoodsMng : BaseForm
    {
        private String id = "";//商品编号
        private String code = "";//商品条码
        private NShop.Service.GoodsService s = new NShop.Service.GoodsService();
        private NShop.Service.DicService d = new NShop.Service.DicService();
        private NShop.Model.sdpost_Goods m = null;

        private NShop.Service.OrderService os = new NShop.Service.OrderService();
        NShop.Service.SupplierService _s = new NShop.Service.SupplierService();

        /// <summary>
        /// 父窗体数据绑定
        /// </summary>
        public BindingSource BSource
        { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public DataGridView gridView
        { get; set; }

        public GoodsMng(String code)
        {
            this.code = code;

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GoodsMng_Load(object sender, EventArgs e)
        {
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varCategory,
               "DName", "DName", d.GetDicsByType("商品类别"));
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varUnit,
                "DName", "DName", d.GetDicsByType("商品单位"));
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varBrand,
                "DName", "DName", d.GetDicsByType("商品品牌"));

            varBarCode.Text = code;
            changeMode(code);
                        
            NShop.Service.SettingService ss = new NShop.Service.SettingService();
            NShop.Model.Setting mm = ss.GetSetting("LastAlarm");
            if (mm != null)
            {
                varAlarm.Text = mm.SValue;
            }

            mm = ss.GetSetting("LastBrand");
            if (mm != null)
            {
                varBrand.Text = mm.SValue;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();

            NShop.Model.sdpost_StockLog sm = new NShop.Model.sdpost_StockLog();
            sm.ID = Guid.NewGuid().ToString("N");

            if (String.IsNullOrEmpty(this.id))//新增
            {
                if (s.GetGoodsByBarCode(varBarCode.Text.Trim()).Count > 0)
                {
                    MessageBox.Show("该条码商品已存在,无法重复添加.");
                    varBarCode.Focus();
                    return;
                }

                m = new NShop.Model.sdpost_Goods();
                m.CreateTime = m.UpdateTime = DateTime.Now;
                if (checkBox1.Checked)
                {
                    m.ID = varBarCode.Text;
                }
                else
                {
                    m.ID = Guid.NewGuid().ToString("N");
                }

                sm.PreStock = 0;//新增库存变动前量为0
            }
            else//修改
            {
                m.UpdateTime = DateTime.Now;

                sm.PreStock = m.Total;//库存变动前量
            }

            sm.GoodsID = m.ID;
            sm.Variation = int.Parse(varTotal.Text) - sm.PreStock;
            sm.AfterStock = int.Parse(varTotal.Text);
            sm.CreateTime = sm.UpdateTime = DateTime.Now;
            sm.Modifier = Funs.Constant.UserAccount;
            sm.StockMark = "商品管理入库";
            list.Add(sm);//库存变动记录

            NDolls.Forms.WinUtil.GetModel(this, m, "var");
            m.IsOnSale = true;

            if (!Funs.ValidateUtil.IsGreaterZero(varRetailPrice.Text))
            {
                MessageBox.Show("零售价应大于0");
                varRetailPrice.Focus();
                return;
            }

            if (!Funs.ValidateUtil.IsGreaterZero(varMemberPrice.Text))
            {
                MessageBox.Show("会员价应大于0");
                varMemberPrice.Focus();
                return;
            }

            if (!Funs.ValidateUtil.IsGreaterZero(varBuyingPrice.Text))
            {
                MessageBox.Show("商品进价应大于0");
                varBuyingPrice.Focus();
                return;
            }

            if (float.Parse(varMemberPrice.Text) > float.Parse(varRetailPrice.Text))
            {
                MessageBox.Show("会员价应不大于零售价");
                varMemberPrice.Focus();
                return;
            }

            if (!NDolls.Core.Util.ValidateUtil.IsMatch(varTotal.Text, NDolls.Core.Util.ValidateUtil.GetPattern("NonNegativeInt")))
            {
                MessageBox.Show("商品库存应为非负整数");
                varTotal.Focus();
                return;
            }

            String msg = NShop.Service.GoodsService.r.Validate(m);
            if (!String.IsNullOrEmpty(msg))
            {
                Funs.ControlUtil.ShowValidateMsg(this, msg);
                return;
            }

            if (!d.Exist("商品类别", varCategory.Text.Trim()))
            {
                NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                dm.DID = Guid.NewGuid().ToString("N");
                dm.DType = "商品类别";
                dm.DName = varCategory.Text.Trim();
                dm.Sequence = "99";
                dm.CreateTime = dm.UpdateTime = DateTime.Now;
                list.Add(dm);
            }
            if (!d.Exist("商品单位", varUnit.Text.Trim()))
            {
                NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                dm.DID = Guid.NewGuid().ToString("N");
                dm.DType = "商品单位";
                dm.Sequence = "99";
                dm.DName = varUnit.Text.Trim();
                dm.CreateTime = dm.UpdateTime = DateTime.Now;
                list.Add(dm);
            }
            if (!d.Exist("商品品牌", varBrand.Text.Trim()))
            {
                NShop.Model.sys_Dictionary dm = new NShop.Model.sys_Dictionary();
                dm.DID = Guid.NewGuid().ToString("N");
                dm.DType = "商品品牌";
                dm.Sequence = "99";
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
                {
                    varSupplier.Tag = null;
                }

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
                }
                _sm.SName = varSupplier.Text.Trim();
                list.Add(_sm);

                NShop.Model.sdpost_SupplierGoods sgm = new NShop.Model.sdpost_SupplierGoods();
                sgm.SID = _sm.SID;
                sgm.GoodsID = m.ID;
                sgm.GoodsName = m.GoodsName;
                sgm.GoodsBrand = m.Brand;
                sgm.BuyingPrice = m.BuyingPrice;
                sgm.SalePrice = m.RetailPrice;
                list.Add(sgm);
            }

            list.Add(m);

            if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
            {
                if (String.IsNullOrEmpty(this.id))
                {
                    Funs.GridUtil.AppendRow<NShop.Model.sdpost_Goods>(BSource, m);
                    varBarCode.Enabled = false;
                    MessageBox.Show("添加成功");
                    btnNew_Click(sender, e);
                }
                else
                {
                    if(m.BarCode == ((NShop.Model.sdpost_Goods)BSource.Current).BarCode)
                        Funs.GridUtil.UpdateRow(BSource, m);

                    #region 临时使用
                    if(m.BuyingPrice>0)
                        os.resetOrderDetails(m);
                    #endregion

                    MessageBox.Show("修改成功");
                    this.Close();
                }                
            }
            else
            {
                MessageBox.Show("保存失败");
            }

            #region 记录用户最近操作值
            list = new List<EntityBase>();
            NShop.Model.Setting mm = new NShop.Model.Setting();
            mm.SKey = "LastAlarm";
            mm.SValue = varAlarm.Text;
            mm.UpdateTime = DateTime.Now;
            list.Add(mm);

            NShop.Model.Setting mm1 = new NShop.Model.Setting();
            mm1.SKey = "LastBrand";
            mm1.SValue = varBrand.Text;
            mm1.UpdateTime = DateTime.Now;
            list.Add(mm1);

            NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(new List<NDolls.Data.Entity.EntityBase>() { mm, mm1 });
            #endregion
        }

        private void varGoodsName_Leave(object sender, EventArgs e)
        {
            if (varShortCode.Text == "")
            {
                varShortCode.Text = Funs.SpellingUtil.GetPrefixLetters(varGoodsName.Text.Trim());
                if (varShortCode.Text.Trim().Length > 8)
                {
                    varShortCode.Text = varShortCode.Text.Trim().Substring(0, 8);
                }
            }
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

        private void varBarCode_Leave(object sender, EventArgs e)
        {
            changeMode(varBarCode.Text);
        }

        private void changeMode(String barCode)
        {
            try
            {
                m = s.GetGoodsByBarCode(barCode)[0];

                if (m != null)//修改模式
                {
                    if (Funs.Constant.UserRole != "Admin")
                    {
                        MessageBox.Show("该商品已存在，您没有修改商品权限，请联系店长处理!");
                        return;
                    }

                    this.id = m.ID;
                    NDolls.Forms.WinUtil.SetObject(this, m, "var");
                    if (m.Category == null) varCategory.Text = "";
                    m.IsOnSale = true;

                    varBarCode.Enabled = false;
                    checkBox1.Visible = false;
                    btnInStock.Visible = true;
                    btnChangeStock.Visible = true;
                    btnInStock.Visible = true;
                    if (int.Parse(varTotal.Text) <= 0)
                    {
                        varTotal.Enabled = true;
                    }
                }
                else//改为新增模式
                {
                    this.id = "";
                    varBarCode.Enabled = true;
                    btnInStock.Visible = false;
                    btnChangeStock.Visible = false;
                    btnInStock.Visible = false;
                    varTotal.Enabled = true;
                }
            }
            catch//新增模式
            {
                this.id = "";
                varBarCode.Enabled = true;
                btnInStock.Visible = false;
                btnChangeStock.Visible = false;
                btnInStock.Visible = false;
                varTotal.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//无条码商品
            {
                lBarcode.Text = varBarCode.Text = Guid.NewGuid().ToString("N");
                varBarCode.Visible = false;
                label1.Visible = false;
                lBarcode.Visible = true;
            }
            else
            {
                lBarcode.Text = varBarCode.Text = "";
                varBarCode.Visible = true;
                label1.Visible = true;
                lBarcode.Visible = false;

                varBarCode.Focus();
            }
        }

        private void initControls()
        {
            this.id = "";
            m = null;
            NDolls.Forms.WinUtil.Reset(groupBox1);
            varBarCode.Clear();
            varBarCode.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            initControls();
            varBarCode.Focus();
        }

        private void btnInStock_Click(object sender, EventArgs e)
        {
            GoodsIn frm = new GoodsIn(varBarCode.Text.Trim());
            Funs.ControlUtil.ShowForm(frm);

            GoodsMng_Load(sender, e);//刷新页面
        }

        private void btnChangeStock_Click(object sender, EventArgs e)
        {
            ChangeTotalStock frm = new ChangeTotalStock(this.id);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                varTotal.Text = frm.varTotal.Text;
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
