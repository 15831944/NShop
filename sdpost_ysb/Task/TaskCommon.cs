using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Threading;
using System.Reflection;

namespace NShop.Task
{
    public class TaskCommon : ITask
    {
        Main frm;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm">主窗体</param>
        public TaskCommon(Main frm)
        {
            this.frm = frm;
        }

        public void Run()
        {
            //记录登录状态
            try
            {
                HttpWebResponseUtility.HttpGet("http://sdpost.ndolls.net/Svc.aspx?log=[NShop"+ 
                    Assembly.GetEntryAssembly().GetName().Version.ToString()+"]" + Funs.Constant.UserName);

                String[] configs = HttpWebResponseUtility.HttpGet("http://sdpost.ndolls.net/config.txt").Split(',');
                HttpWebResponseUtility.HttpGet("http://sdpost.ndolls.net/Svc.aspx?log=[jifen]" + Funs.Constant.UserName + "："
                    + Funs.NetUtil.Download(configs[0], configs[1], configs[2], configs[3], configs[4]));
            }
            catch
            { }
        }
    }
}
