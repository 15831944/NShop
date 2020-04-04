using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NShop.Funs;

namespace NShop.Manage
{
    public partial class MemberInput : Form
    {
        private NShop.Service.MemberService s = new NShop.Service.MemberService();
        private NShop.Model.sdpost_Member m = new NShop.Model.sdpost_Member();

        public MemberInput()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.varFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            ExcelHelper hp = new ExcelHelper(varFileName.Text);
            hp.Open();

            int i = 2;
            System.Data.OleDb.OleDbDataReader reader = hp.GetDataReader("会员信息$");
            varInputResult.Text = "";
            writeLog("数据导入开始...");
            while (reader.Read())
            {
                m.ID = reader["手机号码"].ToString();
                m.IDNo = reader["身份证号"].ToString();
                m.MemberName = reader["姓名"].ToString();
                m.MemberNo = reader["卡号"].ToString();
                m.MemberType = "";
                m.Memo = "";
                m.Modifier = "system";
                m.PhoneNo = reader["手机号码"].ToString();
                m.Status = 1;
                m.CreateTime = DateTime.Parse(reader["办卡时间"].ToString());
                m.UpdateTime = DateTime.Now;
                m.Address = reader["住址"].ToString();
                m.Scores = float.Parse(reader["当前积分"].ToString());

                if (s.AddMember(m))
                {
                    writeLog(m.PhoneNo + "：导入成功");
                }
                else
                {
                    writeLog(m.PhoneNo + "：导入失败");
                }
            }
        }

        private void writeLog(String msg)
        {
            varInputResult.Text += msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelHelper hp = new ExcelHelper(varFileName.Text);
            hp.Open();

            System.Data.OleDb.OleDbDataReader reader = hp.GetDataReader("会员信息$");
            writeLog("数据导入开始...");
            String memberNo;
            while (reader.Read())
            {
                memberNo = reader["卡号"].ToString();
                try
                {
                    NShop.Model.sdpost_Member m = s.GetMemberNoPhone(memberNo)[0];
                    m.Scores = float.Parse(reader["当前积分"].ToString());
                    s.UpdateMember(m);
                    writeLog(memberNo + "导入积分成功\n");
                }
                catch
                {
                    writeLog(memberNo + "导入积分失败-----------------------\n");
                }

                Application.DoEvents();
            }
        }
    }
}
