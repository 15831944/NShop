using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NShop.Funs;

namespace NShop.Settings
{
    public partial class SysSetting : BaseForm
    {
        private NShop.Service.SettingService s = new NShop.Service.SettingService();

        public SysSetting()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();

            NShop.Model.Setting m = new NShop.Model.Setting();
            m.SKey = "PrintScores";
            m.SValue = varPrintScores.Checked.ToString();
            m.UpdateTime = DateTime.Now;
            list.Add(m);

            NShop.Model.Setting m1 = new NShop.Model.Setting();
            m1.SKey = "PrintUserName";
            m1.SValue = varPrintUserName.Checked.ToString();
            m1.UpdateTime = DateTime.Now;
            list.Add(m1);

            NShop.Model.Setting m2 = new NShop.Model.Setting();
            m2.SKey = "PriceStrategy";
            m2.SValue = varPriceStrategy.SelectedValue.ToString();
            m2.UpdateTime = DateTime.Now;
            list.Add(m2);

            NShop.Model.Setting m3 = new NShop.Model.Setting();
            m3.SKey = "PrintCount";
            m3.SValue = varPrintCount.Text;
            m3.UpdateTime = DateTime.Now;
            list.Add(m3);

            if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
            {
                Funs.Constant.PrintScores = null;
                Funs.Constant.PrintUserName = null;
                Funs.Constant.PriceStrategy = null;
                Funs.Constant.PrintCount = null;
                MessageBox.Show("系统参数保存成功!");
            }
        }

        private void SysSetting_Load(object sender, EventArgs e)
        {
            var priceStrategys = new[] 
            {
                new {ID="1",Caption="抹分进位"},
                new {ID="2",Caption="正常价结算"},
                new {ID="3",Caption="抹分舍去"},
                new {ID="4",Caption="分四舍五入"}
            };
            varPriceStrategy.DataSource = priceStrategys;
            varPriceStrategy.DisplayMember = "Caption";
            varPriceStrategy.ValueMember = "ID";
            varMonth.SelectedIndex = varWeek.SelectedIndex = 0;

            NShop.Model.Setting m = s.GetSetting("PrintScores");
            if (m != null)
            {
                varPrintScores.Checked = Boolean.Parse(m.SValue);
            }

            m = s.GetSetting("PrintUserName");
            if (m != null)
            {
                varPrintUserName.Checked = Boolean.Parse(m.SValue);
            }

            m = s.GetSetting("PriceStrategy");
            if (m != null)
            {
                varPriceStrategy.SelectedValue = m.SValue;
            }

            m = s.GetSetting("PrintCount");
            if (m != null)
            {
                varPrintCount.Text = m.SValue;
            }
        }

        private void btnAddSDate_Click(object sender, EventArgs e)
        {
            String name = "var" + ((PictureBox)sender).Name.Replace("btnAdd", "");
            String val = groupBox2.Controls.Find(name, true)[0].Text;
            String vals = groupBox2.Controls.Find(name + "s", true)[0].Text;
            groupBox2.Controls.Find(name + "s", true)[0].Text = vals.Replace(val + ";", "") + val + ";";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabParam"])
            {
                tabControl1.SelectedTab = tabControl1.TabPages["tabSwitch"];
                MessageBox.Show("该功能暂未开放，敬请期待!");
                return;
            }
        }
    }
}
