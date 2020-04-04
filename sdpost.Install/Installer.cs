using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace NShop.Install
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(IDictionary savedState)
        {
            String from = Context.Parameters["Targetdir"] + "微软雅黑.ttf";
            String to = System.Environment.GetEnvironmentVariable("windir") + "\\fonts\\微软雅黑.ttf";
            //MessageBox.Show(from);
            //MessageBox.Show(to);
            if (!File.Exists(to))
            {
                File.Copy(from, to, true);
            }
            base.OnAfterInstall(savedState);
        }
    }
}
