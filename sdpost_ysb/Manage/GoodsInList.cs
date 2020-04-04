using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Attribute;
using NShop.Funs;

namespace NShop.Manage
{
    public partial class GoodsInList : BaseForm
    {
        private NShop.Service.GoodsService gs = new NShop.Service.GoodsService();
        private String goods = "";//商品编号集合条件

        public GoodsInList()
        {
            InitializeComponent();
        }

        public GoodsInList(String goods)
        {
            this.goods = goods;
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnGoodsIn_Click(this, null);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void GoodsInList_Load(object sender, EventArgs e)
        {
            List<CustomAttribute> cols = NShop.Service.GoodsService.ir.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridViewEx1, cols);
            dataGridViewEx1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewEx1.Columns["Supplier"].SortMode = DataGridViewColumnSortMode.Automatic ;
            dataGridViewEx1.Columns["GoodsName"].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridViewEx1.Columns["BuyingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewEx1.Columns["BuyingPrice"].DefaultCellStyle.Format = "0.00元";
            dataGridViewEx1.Columns["RetailPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewEx1.Columns["RetailPrice"].DefaultCellStyle.Format = "0.00元";
            dataGridViewEx1.Columns["InCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            varBeginDate.Value = DateTime.Now;
            varEndDate.Value = DateTime.Now;

            btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String begin = varBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:01";
            String end = varEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            bindingSource1.DataSource = gs.GetGoodsIn(begin,end,varKeywords.Text.Trim());
            dataGridViewEx1.DataSource = bindingSource1;

            float sales = 0;
            float ins = 0;
            foreach (DataGridViewRow row in this.dataGridViewEx1.Rows)
            {
                sales += float.Parse(row.Cells["RetailPrice"].Value.ToString()) * float.Parse(row.Cells["InCount"].Value.ToString());
                ins += float.Parse(row.Cells["BuyingPrice"].Value.ToString()) * float.Parse(row.Cells["InCount"].Value.ToString());
            }
            this.varSalePrice.Text = sales.ToString("f2") + "元";
            this.varInPrice.Text = ins.ToString("f2") + "元";
        }

        private void btnGoodsIn_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewEx1.SelectedRows;
            if (rows.Count > 0)
            {
                GoodsInEx frm = new GoodsInEx(rows[0].Cells["BarCode"].Value.ToString());
                Funs.ControlUtil.ShowForm(frm);
            }
        }

        private void dataGridViewEx1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGoodsIn_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            Funs.GridUtil.DataToExcel(dataGridViewEx1);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Manage.InputGoodsIn frm = new InputGoodsIn();
            frm.ShowDialog();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            ResUtil.OutputXLS("入库模板.xls");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewEx1.SelectedRows.Count > 0)
            {
                try
                {
                    ChangeStock frm = new ChangeStock(dataGridViewEx1.SelectedRows[0]);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Funs.GridUtil.UpdateRow(bindingSource1, gs.GetGoodsIn(dataGridViewEx1.SelectedRows[0].Cells["ID"].Value.ToString()));
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("请选择要修改的入库记录");
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewEx1.SelectedRows.Count > 0)
            {
                ChangeSupplier frm = new ChangeSupplier(dataGridViewEx1.SelectedRows[0]);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Funs.GridUtil.UpdateRow(bindingSource1, gs.GetGoodsIn(dataGridViewEx1.SelectedRows[0].Cells["ID"].Value.ToString()));
                }
            }
            else
            {
                MessageBox.Show("请选择要修改的入库记录");
            }
        }

        bool first = true;
        private void GoodsInList_Enter(object sender, EventArgs e)
        {
            if (!first)
                btnSearch_Click(sender, e);
            else
                first = false;
        }

        private void dataGridViewEx1_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }
    }
}
