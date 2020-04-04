using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NShop.Task
{
    public class TaskWorker
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private ITask task;

        public TaskWorker(ITask task)
        {
            this.task = task;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        public void Start()
        {
            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Funs.Constant.Loger.WriteLog(worker.GetHashCode() + "：任务完成。" + DateTime.Now.ToString());
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Funs.Constant.Loger.WriteLog(worker.GetHashCode() + "：任务开始。" + DateTime.Now.ToString());
            task.Run();
        }
    }
}
