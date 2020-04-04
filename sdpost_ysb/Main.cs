using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using CustomUIControls;
using SHDocVw;
using System.Reflection;
using System.Diagnostics;

namespace NShop
{
    public partial class Main : BaseForm
    {
        protected TaskbarNotifier notifier;

        public Main()
        {
            InitializeComponent();

            //启动数据库备份任务
            //SplashScreen.SetCommentaryString("数据备份...");
            Task.TaskBakcup tb = new Task.TaskBakcup();
            Task.TaskWorker worker = new Task.TaskWorker(tb);
            worker.Start();

            Task.TaskCommon tc = new Task.TaskCommon(this);
            worker = new Task.TaskWorker(tc);
            worker.Start();

            #region 事件注册
            NShop.Controls.Ribbon rb = elementHost1.Child as NShop.Controls.Ribbon;
            WebTester wf = new WebTester();
            wf.ShowInTaskbar = false;
            wf.WindowState = FormWindowState.Minimized;
            wf.Show();

            rb.btnCash.Click += new RoutedEventHandler(btnCash_Click);
            rb.btnGoods.Click += new RoutedEventHandler(btnGoods_Click);
            rb.btnSales.Click += new RoutedEventHandler(btnSales_Click);

            rb.btnIns.Click +=new RoutedEventHandler(btnIns_Click);

            rb.btnPrintSetting.Click += new RoutedEventHandler(btnPrintSetting_Click);
            rb.btnBrandType.Click += new RoutedEventHandler(btnBrandType_Click);
            rb.btnGoodsType.Click += new RoutedEventHandler(btnGoodsType_Click);
            rb.btnUnitType.Click += new RoutedEventHandler(btnUnitType_Click);
            rb.btnSupplier.Click += new RoutedEventHandler(btnSupplier_Click);
            rb.btnSysSetting.Click += new RoutedEventHandler(btnSysSetting_Click);
            rb.btnMember.Click += new RoutedEventHandler(btnMember_Click);

            rb.btnBackup.Click += new RoutedEventHandler(btnBackup_Click);
            rb.btnRestore.Click += new RoutedEventHandler(btnRestore_Click);
            
            rb.btnRestart.Click += new RoutedEventHandler(btnRestart_Click);
            rb.btnExit.Click += new RoutedEventHandler(btnExit_Click);
            rb.btnChangePwd.Click += new RoutedEventHandler(btnChangePwd_Click);

            rb.btnUserList.Click += new RoutedEventHandler(btnUserList_Click);
            rb.btnUserAdd.Click += new RoutedEventHandler(btnUserAdd_Click);

            rb.btnRpt1.Click += new RoutedEventHandler(btnRpt1_Click);
            rb.btnRpt2.Click += new RoutedEventHandler(btnRpt2_Click);
            #endregion
        }
        
        void btnRpt1_Click(object sender, RoutedEventArgs e)
        {
            Report.SaleReport frm = new Report.SaleReport();
            showSubForm(frm, "店铺销售额统计");
        }

        void btnRpt2_Click(object sender, RoutedEventArgs e)
        {
            Report.SaleReportByGoods frm = new Report.SaleReportByGoods();
            showSubForm(frm, "商品销售额统计");
        }
        
        void btnUserAdd_Click(object sender, RoutedEventArgs e)
        {
            Manage.UserMng frm = new Manage.UserMng("");
            showForm(frm);
        }

        void btnUserList_Click(object sender, RoutedEventArgs e)
        {
            Manage.UserList frm = new Manage.UserList();
            showSubForm(frm, "店员管理");
        }

        void btnChangePwd_Click(object sender, RoutedEventArgs e)
        {
            Settings.ChangePwd frm = new Settings.ChangePwd(Funs.Constant.UserName);
            frm.ShowDialog();
        }

        void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Main_FormClosing(sender,new FormClosingEventArgs(CloseReason.None,false));
        }

        void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        void btnSysSetting_Click(object sender, RoutedEventArgs e)
        {
            Settings.SysSetting frm = new Settings.SysSetting();
            showForm(frm);
        }

        void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            Manage.SupplierList frm = new Manage.SupplierList();
            showSubForm(frm,"供应商管理");
        }

        void btnUnitType_Click(object sender, RoutedEventArgs e)
        {
            Sys.DicList frm = new Sys.DicList("商品单位");
            showSubForm(frm, "商品单位管理");
        }

        void btnGoodsType_Click(object sender, RoutedEventArgs e)
        {
            Sys.DicList frm = new Sys.DicList("商品类别");
            showSubForm(frm, "商品类别管理");
        }

        void btnBrandType_Click(object sender, RoutedEventArgs e)
        {
            Sys.DicList frm = new Sys.DicList("商品品牌");
            showSubForm(frm, "商品品牌管理");
        }

        void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (Funs.Constant.UserRole != "Admin")
            {
                System.Windows.MessageBox.Show("您没有该操作权限，请联系店长处理.");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "数据库备份文件（*.bak）| *.bak";
            ofd.RestoreDirectory = true;

            if (System.Windows.Forms.MessageBox.Show("数据还原为不可逆操作，请谨慎使用!\n确定要从选中备份文件还原数据吗?",
                "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) 
                == System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string localFilePath = ofd.FileName.ToString(); //获得文件路径
                    Funs.DBUtil.SysBackup();
                    try
                    {
                        System.IO.File.Copy(localFilePath, System.Windows.Forms.Application.StartupPath + "\\NShop.db", true);
                        System.Windows.Forms.MessageBox.Show("数据库还原成功!");
                    }
                    catch
                    { }
                }
            }
        }

        void btnBackup_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "数据库备份文件（*.bak）| *.bak";
            sfd.RestoreDirectory = true;
            sfd.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径
                System.IO.File.Copy(System.Windows.Forms.Application.StartupPath + "\\NShop.db", localFilePath);
            }
        }

        void btnMember_Click(object sender, RoutedEventArgs e)
        {
            Manage.MemberList frm = new Manage.MemberList();
            showSubForm(frm, "会员管理");
        }

        //public void ShowNotify(String title, String content)
        //{
        //    notifier.Show(title, content, 500, 3000, 500);
        //}

        //void notifier_ContentClick(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.MessageBox.Show("click");
        //}

        void Main_Load(object sender, System.EventArgs e)
        {
            this.button1.Width = 0;
            this.button1.Focus();
        }

        void btnPrintSetting_Click(object sender, RoutedEventArgs e)
        {
            Print.PrintReceipt frm = new Print.PrintReceipt();
            showForm(frm);
        }

        //系统类别
        void btnDicList_Click(object sender, RoutedEventArgs e)
        {
            Sys.DicList frm = new Sys.DicList();
            showSubForm(frm, "系统类别管理");
        }

        /// <summary>
        /// 商品销售记录
        /// </summary>
        void btnSales_Click(object sender, RoutedEventArgs e)
        {
            Manage.SaleList frm = new Manage.SaleList();
            showSubForm(frm,"销售记录");
        }

        /// <summary>
        /// 商品入库记录
        /// </summary>
        void btnIns_Click(object sender, RoutedEventArgs e)
        {
            Manage.GoodsInList frm = new Manage.GoodsInList();
            showSubForm(frm, "入库记录");
        }

        /// <summary>
        /// 商品浏览
        /// </summary>
        void btnGoods_Click(object sender, RoutedEventArgs e)
        {
            BaseForm frm = new Manage.GoodsList();
            showSubForm(frm,"商品管理");
        }

        /// <summary>
        /// 收银台
        /// </summary>
        private void btnCash_Click(object sender, EventArgs e)
        {
            sale.saleForm frm = new sale.saleForm();
            frm.ShowDialog();
        }

        private void showForm(BaseForm frm)
        {
            try
            {
                frm.ShowDialog();
            }
            catch
            { }
        }

        private void showSubForm(BaseForm frm,String caption)
        {
            foreach (WeifenLuo.WinFormsUI.Docking.DockContent c in dockPanel1.Contents)
            {
                if (c.Text == caption)
                {
                    c.Activate();
                    return;
                }
            }

            try
            {
                frm.Text = caption;
                frm.BringToFront();
                frm.Show(dockPanel1);
                dockPanel1.Visible = true;
                panel2.Visible = false;
            }
            catch
            { }
        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (dockPanel1.Documents.Count() <= 0)
            {
                dockPanel1.Visible = false;
                panel2.Visible = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnCash_Click(this,null);
                    break;
                case Keys.F2:
                    btnGoods_Click(this, null);
                    break;
                case Keys.F3:
                    btnMember_Click(this, null);
                    break;
                case Keys.F4:
                    btnIns_Click(this, null);
                    break;
                case Keys.F5:
                    btnSales_Click(this, null);
                    break;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                System.Windows.Forms.Application.Exit();
                return;
            }

            if (DialogResult.OK == System.Windows.Forms.MessageBox.Show("你确定要关闭店面助手吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                this.FormClosing -= new FormClosingEventHandler(this.Main_FormClosing);//为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
                System.Windows.Forms.Application.Exit();//退出整个应用程序
            }
            else
            {
                e.Cancel = true;  //取消关闭事件
            }
        }
        
    }
}
