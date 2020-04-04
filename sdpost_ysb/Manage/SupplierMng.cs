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
    public partial class SupplierMng : BaseForm
    {
        public BindingSource BSource { get; set; }

        private NShop.Service.SupplierService s = new NShop.Service.SupplierService();
        private NShop.Model.sdpost_Supplier m = new NShop.Model.sdpost_Supplier();
        private String id;

        public SupplierMng(String id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void SupplierMng_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(id))//修改
            {
                m = s.GetModel(id);
                NDolls.Forms.WinUtil.SetObject(groupBox1, m, "var");

                List<CustomAttribute> cols = NShop.Service.SupplierGoodsService.r.GetCustomFieldsByType("GridCol");
                Funs.GridUtil.InitDataGrid(dataGridViewEx1, cols);
                bindingSource1.DataSource = m.Goods;

                dataGridViewEx1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool check()
        {
            if (varSName.Text.Trim() == "")
            {
                MessageBox.Show("请填写供应商名称!");
                varSName.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool ret = false;
            NDolls.Forms.WinUtil.GetModel(groupBox1, m, "var");
            if (String.IsNullOrEmpty(id))//新增
            {
                m.SID = Guid.NewGuid().ToString("N");
                m.CreateTime = m.UpdateTime = DateTime.Now;
                ret = s.Add(m);
                if (ret) Funs.GridUtil.AppendRow<NShop.Model.sdpost_Supplier>(BSource, m);
            }
            else
            {
                m.UpdateTime = DateTime.Now;
                ret = s.Update(m);
            }

            if (ret)
                MessageBox.Show("保存成功");
            else
                MessageBox.Show("保存失败");
        }

        private void varSName_Leave(object sender, EventArgs e)
        {
            if(varShortCode.Text.Trim() == "")
                varShortCode.Text = Funs.SpellingUtil.GetPrefixLetters(varSName.Text);
        }
    }
}
