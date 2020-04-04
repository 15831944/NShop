using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop.Account
{
    public partial class Login : Form
    {
        NShop.Service.UserService s = new NShop.Service.UserService();

        public Login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserName.Text.Trim();
                if (username == "")
                {
                    MessageBox.Show("请输入用户名！");
                    return;
                }

                string password = PWD.Text.Trim();
                if (password == "")
                {
                    MessageBox.Show("请输入用户密码！");
                    return;
                }

                if (s.GetCount() <= 0)
                {
                    NShop.Model.SYS_User mm = new NShop.Model.SYS_User();
                    mm.UserRole = "Admin";
                    mm.UserName = username;
                    mm.Password = Funs.Encodetool.DES3Encrypt(password, "rreessf11111111hhhhhhhhs");
                    mm.RealName = "系统管理员";
                    mm.CreateTime = mm.UpdateTime = DateTime.Now;
                    s.AddUser(mm);
                }

                password = Funs.Encodetool.DES3Encrypt(password, "rreessf11111111hhhhhhhhs");
                NShop.Model.SYS_User m = s.GetUser(username, password);
                if (m != null)
                {
                    Funs.Constant.UserName = m.UserName;
                    Funs.Constant.UserRole = m.UserRole;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("用户认证失败");
                }
            }
            catch
            {
                MessageBox.Show("用户认证失败");
                DialogResult = DialogResult.No;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (s.GetCount() <= 0)
            {
                varStatus.Text = "第一次使用系统:填写用户名、密码作为今后的管理员账号，点击登录即可。";
            }
            else
            {
                varStatus.Text = "请输入用户名、密码，验证通过后进入系统。";
            }

            UserName.Focus();
        }
    }
}