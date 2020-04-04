using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NShop.Model;
using NShop.Service;
using System.Management;
using NShop.Funs;
using System.Diagnostics;
using System.IO;

namespace NShop
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。判断激活码是否存在，是否正确，决定是否显示激活窗口
        /// </summary>
        [STAThread]
        public static void Main(String[] args)
        {
            //Sqlite数据库
            NDolls.Data.DataConfig.ConnectionString = "Data Source=NShop.db;Password=123456;Pooling=False;Max Pool Size=100;";
            NDolls.Data.DataConfig.DatabaseType = NDolls.Data.DBType.SQLite;

            //SQLServer数据库
            //NDolls.Data.DataConfig.ConnectionString = "Data Source=.;Initial Catalog=NShop;Persist Security Info=True;User ID=sa;PWD=as";
            //NDolls.Data.DataConfig.DatabaseType = NDolls.Data.DBType.SqlClient;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen.Instance.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SplashScreen.SetBackgroundImage(NShop.Properties.Resources.splashbg);
            SplashScreen.SetTitleString("店面助手努力加载中，请稍后～～～");
            SplashScreen.BeginDisplay();

            SplashScreen.SetCommentaryString("系统新版本检测..."); 
            #region 清理历史系统升级包
            if (File.Exists("update.exe"))
            {
                //升级前关闭相关所有进程
                foreach (Process p in Process.GetProcessesByName("update.exe"))
                {
                    p.Kill();
                }
                File.Delete("update.exe");
            }
            #endregion

            #region 系统升级
            if (Funs.NetUtil.IsConnectInternet())//若网络正常，则检测系统版本升级
            {
                Updater.Update updater = new Updater.Update();
                String newVewsion = updater.CheckVersion();
                if (newVewsion != "")//检测是否有升级
                {
                    if (MessageBox.Show(
                                string.Format("发现最新版本V{0}更新.您是否要立即更新系统?", newVewsion), @"更新通知",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start("Updater.exe", newVewsion);
                        SplashScreen.EndDisplay();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        Process.GetProcessesByName("Updater.exe")[0].Kill();
                    }
                    catch
                    { }
                }
            }
            #endregion

            SplashScreen.SetCommentaryString("数据库脚本升级...");
            #region 数据库脚本升级
            //数据库脚本升级
            Script.UpdateScript.Update();
            #endregion

            SplashScreen.SetCommentaryString("店面助手准备启动...");
            SplashScreen.EndDisplay();
            Form frm = new Account.Login();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Application.Run(new Main());
            }
            else
            {
                Application.Exit();
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            MessageBox.Show("ThreadException" + ex.ToString());
            Constant.Loger.WriteLog(ex.Exception.ToString());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            MessageBox.Show("UnhandledException" + ex.ToString());
            Constant.Loger.WriteLog(ex.ToString());
        }

    }
}
