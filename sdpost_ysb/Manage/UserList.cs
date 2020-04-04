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
    public partial class UserList : BaseForm
    {
        NShop.Service.UserService s = new NShop.Service.UserService();

        public UserList()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ConditionItem item = new ConditionItem("UserName", varUserName.Text.Trim(), SearchType.Fuzzy);
            ConditionItem item1 = new ConditionItem("UserRole", "Salesman", SearchType.Accurate);
            bindingSource1.DataSource = s.GetUsers(new List<Item>() { item,item1 }); 
            dataGridViewEx1.DataSource = bindingSource1;
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            List<CustomAttribute> cols = NShop.Service.UserService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridViewEx1, cols);
            dataGridViewEx1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserMng frm = new UserMng("");
            frm.BSource = bindingSource1;
            Funs.ControlUtil.ShowForm(frm);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewEx1.SelectedRows;
            if (rows.Count > 0)
            {
                UserMng frm = new UserMng(rows[0].Cells["UserName"].Value.ToString());
                frm.BSource = bindingSource1;
                Funs.ControlUtil.ShowForm(frm);
            }
        }

        bool first = true;
        private void UserList_Enter(object sender, EventArgs e)
        {
            if (!first)
                btnSearch_Click(sender, e);
            else
                first = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewEx1.SelectedRows;
            if (rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除选中店员吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (s.DeleteUser(rows[0].Cells["UserName"].Value.ToString()))
                    {
                        bindingSource1.RemoveCurrent();
                        MessageBox.Show("删除成功！");
                    }
                }
            }
        }

        private void dataGridViewEx1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewEx1.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                String userName = dataGridViewEx1.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
                UserMng frm = new UserMng(userName);
                Funs.ControlUtil.ShowForm(frm);
            }
        }
    }
}
