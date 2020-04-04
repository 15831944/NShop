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
    public partial class MemberMng : BaseForm
    {
        private NShop.Service.MemberService s = new NShop.Service.MemberService();
        private NShop.Model.sdpost_Member m = new NShop.Model.sdpost_Member();
        private NShop.Model.NShop_MemberCostume sm = new NShop.Model.NShop_MemberCostume();
        private String memberID = "";

        public MemberMng(String memberID)
        {
            this.memberID = memberID;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            m = new NShop.Model.sdpost_Member();
            if (String.IsNullOrEmpty(memberID))//添加
            {
                m.ID = Guid.NewGuid().ToString("N");
            }
            else//修改
            {
                m.ID = memberID;
            }
            NDolls.Forms.WinUtil.GetModel(groupBox1, m, "var");
            m.Scores = float.Parse(varScores.Text);
            m.Birthday = varBirthday.Value;
            m.CreateTime = DateTime.Now;
            m.UpdateTime = DateTime.Now;
            m.Modifier = "";
            m.Status = 1;

            if (!check(m)) return;

            NDolls.Forms.WinUtil.GetModel(groupBox2, sm, "var");
            sm.ID = m.ID;
            sm.CreateTime = DateTime.Now;
            sm.UpdateTime = DateTime.Now;
            sm.Status = 1;

            if (s.SaveMember(m) && s.SaveMemberCostume(sm))
            {
                MessageBox.Show("会员保存成功!");
            }
            else
            {
                MessageBox.Show("会员保存失败!");
            }
        }

        private void MemberMng_Load(object sender, EventArgs e)
        {
            varBirthday.Text = "1900-01-01";

            if (!String.IsNullOrEmpty(memberID))
            {
                m = s.GetMember(memberID);
                if (m != null)
                {
                    NDolls.Forms.WinUtil.SetObject(groupBox1, m, "var");
                    memberID = m.ID;
                }

                sm = s.GetMemberCostume(memberID);
                if (sm != null)
                {
                    NDolls.Forms.WinUtil.SetObject(groupBox2, sm, "var");
                }
            }
        }

        private void varPhoneNo_Leave(object sender, EventArgs e)
        {
            if (varMemberNo.Text == "")
            {
                varMemberNo.Text = varPhoneNo.Text;
            }
        }

        private void varMemberName_Leave(object sender, EventArgs e)
        {
            if (varShortCode.Text == "")
            {
                varShortCode.Text = Funs.SpellingUtil.GetPrefixLetters(varMemberName.Text.Trim());
            }
        }
    }
}
