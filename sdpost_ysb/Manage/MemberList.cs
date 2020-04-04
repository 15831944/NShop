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
    public partial class MemberList : BaseForm
    {
        private NShop.Service.MemberService s = new NShop.Service.MemberService();
        private NShop.Model.sdpost_Member m = new NShop.Model.sdpost_Member();

        public MemberList()
        {
            InitializeComponent();
        }

        private void MemberList_Load(object sender, EventArgs e)
        {
            List<NDolls.Data.Attribute.CustomAttribute> cols = NShop.Service.MemberService.r.GetCustomFieldsByType("GridCol");
            Funs.GridUtil.InitDataGrid(dataGridViewEx1, cols);

            //btnSearch_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m = new NShop.Model.sdpost_Member();
            m.ID = Guid.NewGuid().ToString("N");
            NDolls.Forms.WinUtil.GetModel(panel1, m, "var");
            m.CreateTime = DateTime.Now;
            m.UpdateTime = DateTime.Now;
            m.Modifier = "";

            if (!check(m)) return;

            if (s.AddMember(m))
            {
                MessageBox.Show("会员添加成功!");
            }
            else
            {
                MessageBox.Show("会员添加失败!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            m = new NShop.Model.sdpost_Member();
            String phoneNo = varPhoneNo.Text;
            String memberNo = varMemberNo.Text;
            String memberName = varMemberName.Text;
            String idNo = varIDNo.Text;

            String sql = "1=1";

            if (!String.IsNullOrEmpty(phoneNo))
            {
                sql += " AND PhoneNo LIKE '%"+phoneNo+"%' ";
            }

            if (!String.IsNullOrEmpty(memberNo))
            {
                sql += " AND MemberNo LIKE '%" + memberNo + "%' ";
            }

            if (!String.IsNullOrEmpty(memberName))
            {
                sql += " AND MemberName LIKE '%" + memberName + "%' OR ShortCode LIKE '%" + memberName + "%'";
            }

            if (!String.IsNullOrEmpty(idNo))
            {
                sql += " AND IDNo LIKE '%" + idNo + "%' ";
            }

            bindingSource1.DataSource = NShop.Service.MemberService.r.Find(sql);//s.GetMembers(m);
            dataGridViewEx1.DataSource = bindingSource1;

            dataGridViewEx1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private bool check(NShop.Model.sdpost_Member model)
        {
            String err = s.Validate(model);
            if (!String.IsNullOrEmpty(err))
            {
                MessageBox.Show(err);
                return false;
            }

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewEx1.SelectedRows;
            String id = "";
            if (rows.Count == 1)
            {
                id = rows[0].Cells["ID"].Value.ToString();
            }

            //m = s.GetMember(id);
            //NDolls.Forms.WinUtil.GetModel(panel1, m, "var");
            //m.UpdateTime = DateTime.Now;

            //if (!check(m)) return;

            //if (s.UpdateMember(m))
            //{
            //    MessageBox.Show("会员修改成功!");
            //}
            //else
            //{
            //    MessageBox.Show("会员修改失败!");
            //}
            String memberID = id;
            MemberMng frm = new MemberMng(memberID);
            Funs.ControlUtil.ShowForm(frm);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            NDolls.Forms.WinUtil.Reset(panel1);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            MemberMng frm = new MemberMng("");
            Funs.ControlUtil.ShowForm(frm);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            MemberInput frm = new MemberInput();
            frm.ShowDialog();
        }

        bool first = true;
        private void MemberList_Enter(object sender, EventArgs e)
        {
            if (!first)
                btnSearch_Click(sender, e);
            else
                first = false;
        }

        private void dataGridViewEx1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewEx1.SelectedRows.Count > 0)
            {
                String memberID = dataGridViewEx1.SelectedRows[0].Cells["ID"].Value.ToString();
                MemberMng frm = new MemberMng(memberID);
                Funs.ControlUtil.ShowForm(frm);
            }
        }
    }
}
