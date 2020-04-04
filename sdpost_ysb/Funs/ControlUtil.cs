using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SHDocVw;
using System.Reflection;
using System.ComponentModel;

namespace NShop.Funs
{
    public class ControlUtil
    {
        public static void ShowValidateMsg(Form frm,String msg)
        {
            if (!String.IsNullOrEmpty(msg))
            {
                try
                {
                    frm.Controls.Find("var" + msg.Split(',')[0], true)[0].Focus();
                }
                catch
                { }
                MessageBox.Show(msg.Split(',')[1]);
                return;
            }
        }

        public static void OpenNewIe(string url, string postData)
        {
            var ie = new InternetExplorer();
            object vPost, vHeaders, vFlags, vTargetFrame;
            vPost = null;
            vFlags = null;
            vTargetFrame = null;
            vHeaders = "Content-Type: application/x-www-form-urlencoded" + Convert.ToChar(10) + Convert.ToChar(13);
            if (!string.IsNullOrEmpty(postData))
                vPost = ASCIIEncoding.ASCII.GetBytes(postData);
            ie.Visible = true;
            ie.Navigate(url, ref vFlags, ref vTargetFrame, ref vPost, ref vHeaders);
        }

        public static void ShowForm(BaseForm frm)
        {
            try
            {
                frm.ShowDialog();
            }
            catch
            { }
        }
    }
}
