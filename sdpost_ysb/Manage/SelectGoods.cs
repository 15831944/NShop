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
    public partial class SelectGoods : BaseForm
    {
        private List<NShop.Model.sdpost_Goods> list = new List<NShop.Model.sdpost_Goods>();//待选择商品集合

        public SelectGoods(List<NShop.Model.sdpost_Goods> list)
        {
            this.list = list;
            InitializeComponent();
        }

        private void SelectGoods_Load(object sender, EventArgs e)
        {
            List<CustomAttribute> cols = NShop.Service.GoodsService.r.GetCustomFieldsByType("SCol");
            Funs.GridUtil.InitDataGrid(dataGridView1, cols);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            bindingSource1.DataSource = list;
            dataGridView1.DataSource = bindingSource1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择入库商品！");
                return;
            }
            else
            {
                this.barCode = dataGridView1.SelectedRows[0].Cells["BarCode"].Value.ToString();
                this.id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private String id;
        /// <summary>
        /// 商品编号
        /// </summary>
        public String ID
        {
            get { return id; }
            set { id = value; }
        }

        private String barCode;
        /// <summary>
        /// 商品条码
        /// </summary>
        public String BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btnSave_Click(sender,e);
        }

    }
}
