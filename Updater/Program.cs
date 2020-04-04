using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;


namespace Updater
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。判断激活码是否存在，是否正确，决定是否显示激活窗口
        /// </summary>
        [STAThread]
        public static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Update updater = new Update();
            if (args.Length > 0 && args[0] != "")
            {
                //升级前关闭相关所有进程
                try
                {
                    foreach (Process p in Process.GetProcessesByName("NShop.exe"))
                    {
                        p.Kill();
                    }
                }
                catch
                { }

                updater.Start();
                Application.Run();
            }
        }
    }
}
