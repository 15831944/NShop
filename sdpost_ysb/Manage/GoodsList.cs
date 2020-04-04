using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Attribute;
using NDolls.Data.Entity;

namespace NShop.Manage
{
    public partial class GoodsList : BaseForm
    {
        private NShop.Service.GoodsService r = new NShop.Service.GoodsService();
        private NShop.Service.DicService d = new NShop.Service.DicService();
        private NShop.Service.GoodsSummaryService gss = new NShop.Service.GoodsSummaryService();

        public GoodsList()
        {
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

        private void GoodsList_Load(object sender, EventArgs e)
        {
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varCategory,
               "DName", "DName", d.GetDicsByType("商品类别"));
            NDolls.Forms.WinUtil.InitComboBox<NShop.Model.sys_Dictionary>(varBrand,
                "DName", "DName", d.GetDicsByType("商品品牌"));

            List<CustomAttribute> cols = NShop.Service.GoodsService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridView1, cols);

            dataGridView1.Columns["RetailPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["RetailPrice"].DefaultCellStyle.Format = "0.00元";
            dataGridView1.Columns["BuyingPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["BuyingPrice"].DefaultCellStyle.Format = "0.00元";
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            NShop.Model.view_GoodsSummary m = gss.GetModel();
            if (m != null)
            {
                varStock.Text = String.Format("{0}种，{1}件，{2}元", m.aCategory, m.aTotal, m.aPrice);
            }

            //btnSearch_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GoodsMng frm = new GoodsMng("");
            frm.gridView = dataGridView1;
            frm.BSource = bindingSource1;
            Funs.ControlUtil.ShowForm(frm);

            refreshStock();
        }

        //列表头添加行
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridView1.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridView1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void btnGoodsIn_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            //if (rows.Count > 0)
            //{
            //    GoodsIn frm = new GoodsIn(rows[0].Cells["BarCode"].Value.ToString());
            //    frm.ShowDialog();
            //}
            GoodsIn frm = new GoodsIn("");
            Funs.ControlUtil.ShowForm(frm);
        }

        private void GoodsList_Activated(object sender, EventArgs e)
        {
            varKeywords.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                GoodsMng frm = new GoodsMng(rows[0].Cells["BarCode"].Value.ToString());
                frm.gridView = dataGridView1;
                frm.BSource = bindingSource1;
                //frm.ShowDialog();
                Funs.ControlUtil.ShowForm(frm);

                Funs.GridUtil.UpdateRow(bindingSource1, r.GetGoodsByID(rows[0].Cells["ID"].Value.ToString()));

                refreshStock(rows[0]);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.PerformClick();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    btnUpdate_Click(sender, e);
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    btnDelete_Click(sender,e);
                    e.Handled = true;
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除选中商品吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (r.DelGoods(rows[0].Cells["ID"].Value.ToString()))
                    {
                        bindingSource1.RemoveCurrent();
                        MessageBox.Show("删除成功！");
                    }
                }
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            Funs.GridUtil.DataToExcel(dataGridView1);
        }

        private void varGoodsName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
                btnSearch_Click(sender, e);
        }

        private void btnInList_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择商品信息");
                return;
            }

            String goods = "";
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                goods += row.Cells["ID"].Value.ToString()+",";
            }
            goods = goods.TrimEnd(',') ;

            StockLog frm = new StockLog(goods);
            Funs.ControlUtil.ShowForm(frm);
        }

        List<Item> list = new List<Item>();
        private void SearchPaper(int pageIndex)
        {
            String key = varKeywords.Text.Trim();
            list = new List<Item>();
            ConditionOrGroup groupOr = new ConditionOrGroup();
            groupOr.AddCondition(new ConditionItem("GoodsName", key, SearchType.Fuzzy));
            groupOr.AddCondition(new ConditionItem("BarCode", key, SearchType.Fuzzy));
            groupOr.AddCondition(new ConditionItem("StockNo", key, SearchType.Fuzzy));
            groupOr.AddCondition(new ConditionItem("ShortCode", key, SearchType.Fuzzy));
            list.Add(groupOr);

            if (varCategory.Text.Trim() != "")
            {
                list.Add(new ConditionItem("Category", varCategory.Text, SearchType.Fuzzy));
            }

            if (varBrand.Text.Trim() != "")
            {
                list.Add(new ConditionItem("Brand", varBrand.Text, SearchType.Fuzzy));
            }

            if (Funs.ValidateUtil.IsInt(varTotal.Text.Trim()))
            {
                list.Add(new ConditionItem("Total", varTotal.Text, SearchType.GreaterEqual));
            }
            if (Funs.ValidateUtil.IsInt(varTotalEx.Text.Trim()))
            {
                list.Add(new ConditionItem("Total", varTotalEx.Text, SearchType.LowerEqual));
            }

            Paper<NShop.Model.sdpost_Goods> paper = NShop.Service.GoodsService.r.FindPager(15, pageIndex, list);
            if (paper != null)
            {
                varDataCount.Text = paper.Total.ToString();
                varPageCount.Text = "共" + paper.PageCount + "页";
                varCurrent.Text = pageIndex.ToString();

                bindingSource1.DataSource = paper.Result;
                dataGridView1.DataSource = bindingSource1;
            }
            else
            {
                varDataCount.Text = "0";
                varPageCount.Text = "共0页";
                varCurrent.Text = "0" ;

                bindingSource1.DataSource = null;
                dataGridView1.DataSource = bindingSource1; 
            }
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPaper(1);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            try
            {
                DataTable dt = r.CustomSearch("COUNT(1) CNT,SUM(CASE WHEN Total<0 THEN 0 ELSE Total END) aTotal,SUM(CASE WHEN Total<0 THEN 0 ELSE Total END*RetailPrice) aPrice ", list);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    this.varSummary.Text = String.Format("{0}种，{1}件，{2}元", row["CNT"].ToString(), row["aTotal"].ToString(), float.Parse(row["aPrice"].ToString()).ToString("f2"));//查询汇总
                }
            }
            catch
            { }
            
            refreshStock();
        }

        private void refreshStock(DataGridViewRow row)
        {
            String a = row.Cells["Total"].Value.ToString();
            String b = row.Cells["Alarm"].Value.ToString();
            if (float.Parse(a) < float.Parse(b))
            {
                row.Cells["Total"].Style.BackColor = Color.Red;
            }
            else
            {
                row.Cells["Total"].Style.BackColor = row.Cells["Alarm"].Style.BackColor;
            }
        }

        private void refreshStock()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                String a = row.Cells["Total"].Value.ToString();
                String b = row.Cells["Alarm"].Value.ToString();
                if (float.Parse(a) <= float.Parse(b))
                {
                    row.Cells["Total"].Style.BackColor = Color.Red;
                }
                else
                {
                    row.Cells["Total"].Style.BackColor = row.Cells["Alarm"].Style.BackColor;
                }
            }
        }

        bool first = true;
        private void GoodsList_Enter(object sender, EventArgs e)
        {
            if (!first)
                btnSearch_Click(sender, e);
            else
                first = false;
        }

        private void varKeywords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, null);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int current = int.Parse(varCurrent.Text);
            int pageCount = int.Parse(varPageCount.Text.Replace("共","").Replace("页",""));
            if (current + 1 > pageCount) return;

            SearchPaper(current + 1);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            int current = int.Parse(varCurrent.Text);
            int pageCount = int.Parse(varPageCount.Text.Replace("共", "").Replace("页", ""));
            if (current - 1 < 1) return;

            SearchPaper(current - 1);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            SearchPaper(1);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            int pageCount = int.Parse(varPageCount.Text.Replace("共", "").Replace("页", ""));
            SearchPaper(pageCount);
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        int drow = -1;
        int dcol = -1;
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            drow = this.dataGridView1.HitTest(e.X, e.Y).RowIndex; //行
            dcol = this.dataGridView1.HitTest(e.X, e.Y).ColumnIndex; //列
        }

        private void btnCopyCell_Click(object sender, EventArgs e)
        {
            if (drow > -1 && dcol > -1)
            {
                Clipboard.SetText(dataGridView1.Rows[drow].Cells[dcol].Value.ToString());
            }
            else
            {
                Clipboard.Clear();
            }
        }

    }
}
