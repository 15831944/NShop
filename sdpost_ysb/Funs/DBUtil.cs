using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace NShop.Funs
{
    public class DBUtil
    {
        public static void SysBackup()
        {
            if (!Directory.Exists("Backup"))
            {
                Directory.CreateDirectory("Backup");
            }

            //7+天备份一次；或者从没备份过时备份
            if (!File.Exists("Backup\\auto" + DateTime.Now.AddDays(-7).ToString("yyyyMMdd")) || Directory.GetFiles("Backup") == null)
            {
                File.Copy("NShop.db", "Backup\\auto" + DateTime.Now.ToString("yyyyMMdd") + ".bak", true);

                //删除非最近两个月的备份文件
                Process pro = new Process();
                pro.StartInfo.FileName = "cmd.exe";
                pro.StartInfo.WorkingDirectory = System.Windows.Forms.Application.StartupPath + "\\Backup";
                pro.StartInfo.Arguments = "/c del auto" + DateTime.Now.AddMonths(-2).ToString("yyyyMM") + "*.bak";
                pro.StartInfo.UseShellExecute = false;//不使用系统外壳程序启动
                pro.StartInfo.RedirectStandardInput = true;//不重定向输入
                pro.StartInfo.RedirectStandardOutput = true; //重定向输出
                pro.StartInfo.RedirectStandardError = true;
                pro.StartInfo.CreateNoWindow = true;//不创建窗口
                pro.Start();
            }
        }

        public static void Backup(String backFileName)
        {
            if (!Directory.Exists("Backup"))
            {
                Directory.CreateDirectory("Backup");
            }

            if (!File.Exists("Backup\\"+backFileName))
            {
                File.Copy("NShop.db", "Backup\\" + backFileName + ".bak", true);
            }
        }
    }
}
