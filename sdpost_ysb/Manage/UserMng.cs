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
    public partial class UserMng : BaseForm
    {
        private String userName;
        private NShop.Service.UserService s = new NShop.Service.UserService();
        private NShop.Model.SYS_User m = new NShop.Model.SYS_User();

        public BindingSource BSource;

        public UserMng(String userName)
        {
            this.userName = userName;

            InitializeComponent();
        }

        private void UserMng_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(userName))
            {
                m = s.GetUser(userName);
                NDolls.Forms.WinUtil.SetObject(panel1, m, "var");
                varUserName.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (varUserName.Text == "")
            {
                MessageBox.Show("请填写用户名!");
                varUserName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(userName) && _varPassword.Text == "")//若添加且密码为空
            {
                MessageBox.Show("请填写用户密码!");
                _varPassword.Focus();
                return;
            }

            NDolls.Forms.WinUtil.GetModel(panel1, m, "var");

            if(_varPassword.Text.Trim() != "")
                m.Password = Funs.Encodetool.DES3Encrypt(_varPassword.Text.Trim(), "rreessf11111111hhhhhhhhs");
            m.UserRole = "Salesman";
            m.UpdateTime = DateTime.Now;
            m.Status = 1;

            if (String.IsNullOrEmpty(userName))//添加
            {
                try
                {
                    m.CreateTime = DateTime.Now;
                    if (s.AddUser(m))
                    {
                        Funs.GridUtil.AppendRow<NShop.Model.SYS_User>(BSource, m);
                        NDolls.Forms.WinUtil.Reset(groupBox1);
                        MessageBox.Show("店员添加成功.");
                    }
                    else
                    {
                        MessageBox.Show("店员添加失败!");
                    }
                }
                catch
                {
                    MessageBox.Show("店员添加失败,该账号已存在!");
                }
            }
            else
            {
                if (s.UpdateUser(m))
                {
                    try
                    {
                        Funs.GridUtil.UpdateRow(BSource, m);
                    }
                    catch
                    { }
                    MessageBox.Show("店员修改成功.");
                }
                else
                {
                    MessageBox.Show("店员修改失败!");
                }
            }
        }
    }
}
