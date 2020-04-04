using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop.Settings
{
    public partial class ChangePwd : Form
    {
        private String userName;
        private NShop.Model.SYS_User m;
        private NShop.Service.UserService s = new NShop.Service.UserService();

        public ChangePwd(String userName)
        {
            this.userName = userName;
            InitializeComponent();
        }

        private void ChangePwd_Load(object sender, EventArgs e)
        {
            m = s.GetUser(userName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (varOldPassword.Text.Trim() == "")
            {
                MessageBox.Show("请填写原密码!");
                varOldPassword.Focus();
                return;
            }

            if (varNewPassword.Text.Trim() == "")
            {
                MessageBox.Show("请填写新密码!");
                varNewPassword.Focus();
                return;
            }

            if (varPassword.Text.Trim() == "")
            {
                MessageBox.Show("请填写重复密码!");
                varPassword.Focus();
                return;
            }

            if (varNewPassword.Text.Trim() != varPassword.Text.Trim())
            {
                MessageBox.Show("新密码两次输入不一致!");
                return;
            }

            if (m!=null && varOldPassword.Text.Trim() != Funs.Encodetool.DES3Decrypt(m.Password, "rreessf11111111hhhhhhhhs"))
            {
                MessageBox.Show("原密码错误，请重新输入!");
                varOldPassword.Focus();
                return;
            }
            
            //修复因最早版用户SYS_User无管理员用户信息导致的错误
            if (m == null)
            {
                m = new NShop.Model.SYS_User();
                m.UserName = Funs.Constant.UserName;
                m.UserRole = Funs.Constant.UserRole;
                m.CreateTime = m.UpdateTime = DateTime.Now;
                m.Status = 1;
                m.RealName = "系统管理员";
            }
            m.Password = Funs.Encodetool.DES3Encrypt(varPassword.Text.Trim(), "rreessf11111111hhhhhhhhs");

            if (s.SaveUser(m))
            {
                MessageBox.Show("密码修改成功!");
            }
            else
            {
                MessageBox.Show("密码修改失败!");
            }
        }
    }
}
