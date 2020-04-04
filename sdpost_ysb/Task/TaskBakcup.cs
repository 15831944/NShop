using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NShop.Task
{
    public class TaskBakcup : ITask
    {
        public void Run()
        {
            Funs.DBUtil.SysBackup();
        }
    }
}
