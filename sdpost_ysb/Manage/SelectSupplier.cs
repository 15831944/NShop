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
    public partial class SelectSupplier : BaseForm
    {
        private List<NShop.Model.sdpost_Supplier> list = new List<NShop.Model.sdpost_Supplier>();//待选择商品集合
        private NShop.Service.SupplierService s = new NShop.Service.SupplierService();

        public SelectSupplier()
        {
            InitializeComponent();
        }

        private void SelectGoods_Load(object sender, EventArgs e)
        {
            List<CustomAttribute> cols = NShop.Service.SupplierService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridView1, cols);

            btnSearch_Click(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择供应商！");
                return;
            }
            else
            {
                this.sid = dataGridView1.SelectedRows[0].Cells["SID"].Value.ToString();
                this.sName = dataGridView1.SelectedRows[0].Cells["SName"].Value.ToString();
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

        private String sid;
        /// <summary>
        /// 供应商编号
        /// </summary>
        public String SID
        {
            get { return sid; }
            set { sid = value; }
        }

        private String sName;
        /// <summary>
        /// 供应商名称
        /// </summary>
        public String SName
        {
            get { return sName; }
            set { sName = value; }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btnSave_Click(sender,e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = s.GetModels(varKeywords.Text);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

    }
}
