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
    public partial class ChangeTotalStock : BaseForm
    {
        private String id = "";
        private NShop.Model.sdpost_Goods m = new NShop.Model.sdpost_Goods();
        private NShop.Service.GoodsService s = new NShop.Service.GoodsService();

        public ChangeTotalStock(String id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void ChangeTotalStock_Load(object sender, EventArgs e)
        {
            m = s.GetGoodsByID(id);
            varGoodsName.Text = m.GoodsName;
            varTotal.Text = m.Total.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();

            //记录库存调整日志
            if (m.Total.ToString() != varTotal.Text.Trim())
            {
                NShop.Model.sdpost_StockLog sm = new NShop.Model.sdpost_StockLog();
                sm.ID = Guid.NewGuid().ToString("N");
                sm.GoodsID = m.ID;
                sm.PreStock = m.Total;
                sm.Variation = int.Parse(varTotal.Text.Trim()) - m.Total;
                sm.AfterStock = int.Parse(varTotal.Text.Trim());
                sm.CreateTime = sm.UpdateTime = DateTime.Now;
                sm.Modifier = Funs.Constant.UserAccount;
                sm.StockMark = "库存手动调整";
                sm.Memo = varMemo.Text;
                list.Add(sm);

                m.Total = sm.AfterStock;
                list.Add(m);

                if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    MessageBox.Show("库存调整成功!");
                }
            }
            else
            {
                MessageBox.Show("库存数量未作调整!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
