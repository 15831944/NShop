using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDolls.Data.Entity;
using NDolls.Data.Attribute;
using NDolls.Data;

namespace NShop.Manage
{
    public partial class SupplierList : BaseForm
    {
        private NShop.Service.SupplierService s = new NShop.Service.SupplierService();

        public SupplierList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierMng frm = new SupplierMng("");
            frm.BSource = bindingSource1;
            frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = s.GetModels(varKeywords.Text);
        }

        private void SupplierList_Load(object sender, EventArgs e)
        {
            List<CustomAttribute> cols = NShop.Service.SupplierService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridViewEx1, cols);

            dataGridViewEx1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewEx1.SelectedRows;
            if (rows.Count > 0)
            {
                SupplierMng frm = new SupplierMng(rows[0].Cells["SID"].Value.ToString());
                frm.ShowDialog();

                Funs.GridUtil.UpdateRow(bindingSource1, s.GetModel(rows[0].Cells["SID"].Value.ToString()));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewEx1.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除选中供应商吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (s.Delete(rows[0].Cells["SID"].Value.ToString()))
                    {
                        bindingSource1.RemoveCurrent();
                        MessageBox.Show("删除成功！");
                    }
                }
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Progress frm = new Progress();
            frm.pro = DoWork;
            frm.ShowDialog();

            MessageBox.Show("供应商转入成功");
        }

        public void DoWork(ProgressBar bar)
        {
            DataTable dt = RepositoryBase<EntityBase>.Query("SELECT DISTINCT(Supplier) FROM sdpost_Goods WHERE Supplier IS NOT NULL AND Supplier <> ''");
            bar.Maximum = dt.Rows.Count;
            NShop.Model.sdpost_Supplier m;
            foreach (DataRow row in dt.Rows)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);

                if (s.GetModels(row["Supplier"].ToString()).Count <= 0)
                {
                    m = new NShop.Model.sdpost_Supplier();
                    m.SID = Guid.NewGuid().ToString("N");
                    m.SName = row["Supplier"].ToString();
                    m.ShortCode = Funs.SpellingUtil.GetPrefixLetters(m.SName);
                    s.Add(m);
                }

                bar.PerformStep();
            }
        }

        private void varKeywords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void dataGridViewEx1_DoubleClick(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, null);
        }
    }
}
