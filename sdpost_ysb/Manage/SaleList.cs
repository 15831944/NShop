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
using NShop.Funs;
using System.Drawing.Printing;

namespace NShop.Manage
{
    public partial class SaleList : BaseForm
    {
        NShop.Service.OrderService s = new NShop.Service.OrderService();
        NShop.Service.OrderGoodsService ss = new NShop.Service.OrderGoodsService();

        public SaleList()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                //case Keys.F2:
                //    btnGoodsIn_Click(this, null);
                //    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            Funs.GridUtil.DataToExcel(gridSlave.Visible?gridSlave:gridMaster);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.Item> conditions = new List<NDolls.Data.Entity.Item>();
            conditions.Add(new NDolls.Data.Entity.ConditionItem("CreateTime", varBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:01", NDolls.Data.Entity.SearchType.Greater));
            conditions.Add(new NDolls.Data.Entity.ConditionItem("CreateTime", varEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59", NDolls.Data.Entity.SearchType.Lower));
            if (varOrderType.Text == "退货订单")
            {
                conditions.Add(new ConditionItem("Memo","退货_", SearchType.Fuzzy));
            }
            else if (varOrderType.Text == "销售订单")
            {
                conditions.Add(new ConditionItem("Memo", "退货_", SearchType.UnContains));
            }

            if (!String.IsNullOrEmpty(varMemberNo.Text.Trim()))
            {
                conditions.Add(new NDolls.Data.Entity.ConditionItem("MemberNo", varMemberNo.Text, NDolls.Data.Entity.SearchType.Fuzzy));
            }
            conditions.Add(new NDolls.Data.Entity.OrderItem("CreateTime", NDolls.Data.Entity.OrderType.DESC));

            if (varShowType.SelectedIndex == 1)//按订单查询
            {
                gridSlave.Visible = false;
                gridMaster.Visible = true;

                gridMaster.Columns["OriginalPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridMaster.Columns["OriginalPrice"].DefaultCellStyle.Format = "0.00元";
                gridMaster.Columns["Discount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridMaster.Columns["Discount"].DefaultCellStyle.Format = "0.00元";
                gridMaster.Columns["ReceivablePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridMaster.Columns["ReceivablePrice"].DefaultCellStyle.Format = "0.00元";
                gridMaster.Columns["Profit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridMaster.Columns["Profit"].DefaultCellStyle.Format = "0.00元";
                gridMaster.Columns["Scores"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridMaster.Columns["Scores"].DefaultCellStyle.Format = "0.00分";
                gridMaster.Columns["DiscountRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridMaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                bMaster.DataSource = s.GetOrders(conditions);
                gridMaster.DataSource = bMaster;

                float sales = 0;
                float profit = 0;
                foreach (DataGridViewRow row in gridMaster.Rows)
                {
                    row.Cells["DiscountRate"].Value = Decimal.Parse(row.Cells["DiscountRate"].Value.ToString())/100;
                    sales += float.Parse(row.Cells["ReceivablePrice"].Value.ToString());
                    profit += float.Parse(row.Cells["Profit"].Value.ToString());
                }
                varSales.Text = sales.ToString("f2") + "元";
                varProfit.Text = profit.ToString("f2") + "元";
            }
            else//按商品查询
            {
                if (varGoodsName.Text.Trim() != "")
                {
                    ConditionOrGroup cg = new ConditionOrGroup();
                    cg.AddCondition(new ConditionItem("GoodsName", varGoodsName.Text.Trim(), NDolls.Data.Entity.SearchType.Fuzzy));
                    cg.AddCondition(new ConditionItem("GoodsID", varGoodsName.Text.Trim(), NDolls.Data.Entity.SearchType.Fuzzy));
                    conditions.Add(cg);
                }

                gridSlave.Visible = true;
                gridMaster.Visible = false;

                bSlave.DataSource = ss.GetOrderGoods(conditions);
                gridSlave.DataSource = bSlave;

                gridSlave.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridSlave.Columns["SalePrice"].DefaultCellStyle.Format = "0.00元";
                gridSlave.Columns["CostPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridSlave.Columns["CostPrice"].DefaultCellStyle.Format = "0.00元";
                gridSlave.Columns["Profit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridSlave.Columns["Profit"].DefaultCellStyle.Format = "0.00元";
                gridSlave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                float sales = 0;
                float profit = 0;
                foreach (DataGridViewRow row in gridSlave.Rows)
                {
                    sales += float.Parse(row.Cells["SalePrice"].Value.ToString());
                    profit += float.Parse(row.Cells["Profit"].Value.ToString());
                }
                varSales.Text = sales.ToString("f2") + "元";
                varProfit.Text = profit.ToString("f2") + "元";
            }
        }

        private void SaleList_Load(object sender, EventArgs e)
        {
            varBeginDate.Value = varEndDate.Value = DateTime.Now;

            List<CustomAttribute> cols = NShop.Service.OrderService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(gridMaster, cols);

            cols = NShop.Service.OrderGoodsService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(gridSlave, cols);

            varShowType.SelectedIndex = 0;
            varOrderType.SelectedIndex = 0;

            btnSearch_Click(sender, e);
        }

        private void gridMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMaster.SelectedRows.Count > 0)
            {
                String orderID = gridMaster.SelectedRows[0].Cells["ID"].Value.ToString();
                SaleDetail frm = new SaleDetail(orderID);
                Funs.ControlUtil.ShowForm(frm);
            }
        }

        private void varBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnSearch_Click(sender, e);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void varShowType_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void varShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (varShowType.Text == "按商品展示")
            {
                varGoodsName.Visible = true;
                lblGoodsName.Visible = true;
            }
            else
            {
                varGoodsName.Visible = false;
                lblGoodsName.Visible = false;
            }
        }

        bool first = true;
        private void SaleList_Enter(object sender, EventArgs e)
        {
            if (!first)
                btnSearch_Click(sender, e);
            else
                first = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gridSlave.SelectedRows.Count > 0)
            {
                String orderID = "";
                if (gridMaster.Visible)
                {
                    orderID = gridMaster.SelectedRows[0].Cells["ID"].Value.ToString(); 
                }
                else
                {
                    orderID = gridSlave.SelectedRows[0].Cells["OrderID"].Value.ToString(); 
                }
                Funs.PrintUtil.PrintReceipt(orderID,true);
            }
            else
            {
                MessageBox.Show("请选择要打印的销售订单!");
            }
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            NShop.sale.backsaleForm getpauseorderid = new NShop.sale.backsaleForm();
            try
            {
                getpauseorderid.ShowDialog(this);
            }
            catch { }
        }

        private void gridSlave_DoubleClick(object sender, EventArgs e)
        {
            if (gridSlave.SelectedRows.Count > 0)
            {
                String orderID = gridSlave.SelectedRows[0].Cells["OrderID"].Value.ToString();
                SaleDetail frm = new SaleDetail(orderID);
                Funs.ControlUtil.ShowForm(frm);
            }
        }

        private void gridMaster_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.Columns[e.ColumnIndex].Name == "Cash" || dgv.Columns[e.ColumnIndex].Name == "BandCard")
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "是";
                }
                else
                {
                    e.Value = "否";
                }
            }
        }

        int drow = -1;
        int dcol = -1;
        private void gridSlave_MouseMove(object sender, MouseEventArgs e)
        {
            drow = gridSlave.HitTest(e.X, e.Y).RowIndex; //行
            dcol = gridSlave.HitTest(e.X, e.Y).ColumnIndex; //列
        }

        private void gridSlave_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            gridSlave.CurrentCell = gridSlave.Rows[e.RowIndex].Cells[e.ColumnIndex];
            gridSlave.Rows[e.RowIndex].Selected = true;
        }

        private void btnCopyCell_Click(object sender, EventArgs e)
        {
            if (drow > -1 && dcol > -1)
            {
                if (gridSlave.Visible)
                {
                    Clipboard.SetText(gridSlave.Rows[drow].Cells[dcol].Value.ToString());
                }
                else
                {
                    Clipboard.SetText(gridMaster.Rows[drow].Cells[dcol].Value.ToString());
                }
            }
            else
            {
                Clipboard.Clear();
            }
        }

        DataGridViewPrinter MyDataGridViewPrinter;
        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Customers Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(20, 20, 40, 40);

            MyDataGridViewPrinter = new DataGridViewPrinter(gridSlave, MyPrintDocument, true, true, "Customers", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }
    }
}
