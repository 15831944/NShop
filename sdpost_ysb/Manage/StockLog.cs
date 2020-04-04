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
    public partial class StockLog : BaseForm
    {
        private String id;
        private NShop.Service.StockService s = new NShop.Service.StockService();

        public StockLog(String id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void StockLog_Load(object sender, EventArgs e)
        {
            List<CustomAttribute> cols = NShop.Service.StockService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridView1,cols);
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            btnSearch_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = s.GetStockLog(id);
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
