using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using NShop.Funs;

namespace NShop.Print
{
    public partial class PrintReceipt : BaseForm
    {
        private NShop.Service.SettingService s = new NShop.Service.SettingService();

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern long SetDefaultPrinter(string pszPrinter);

        private static PrintDocument fPrintDocument = new PrintDocument();
        ///
        /// 获取本机默认打印机名称
        ///
        public static String DefaultPrinter
        {
            get { return fPrintDocument.PrinterSettings.PrinterName; }
        }

        public PrintReceipt()
        {
            InitializeComponent();
        }

        private void print(PrintPageEventArgs e,String title,String content)
        {
            System.Drawing.Font bigFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);
            System.Drawing.Font smallFont = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Regular);

            // 设置信息打印格式 
            e.Graphics.DrawString(title, bigFont, System.Drawing.Brushes.Black, 5, 5);
            e.Graphics.DrawString(content, smallFont, System.Drawing.Brushes.Black, 5, 30);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Funs.PrintUtil.PrintTest();
        }

        private void PrintReceipt_Load(object sender, EventArgs e)
        {
            //初始化打印机
            foreach (String fPrinterName in GetLocalPrinters())
                listBox1.Items.Add(fPrinterName);

            initPrinters();

            //初始化打印配置
            List<NShop.Model.Setting> list = s.GetSettings("Print");
            foreach (NShop.Model.Setting m in list)
            {
                try
                {
                    if (m.SKey == "Printer")
                    {
                        varPrinter.Text = m.SValue;
                    }

                    Control txt = groupBox2.Controls.Find("var" + m.SKey, true)[0] as Control;
                    txt.Text = m.SValue;
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 初始化打印机
        /// </summary>
        private void initPrinters()
        {
            varPrinter.Items.Clear();
            foreach (String fPrinterName in GetLocalPrinters())
            {
                varPrinter.Items.Add(fPrinterName);
            }
        }

        public List<String> GetLocalPrinters()
        {
            varDefaultPrinter.Text = DefaultPrinter;

            List<String> fPrinters = new List<String>();
            fPrinters.Add(DefaultPrinter); // 默认打印机始终出现在列表的第一项
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                    fPrinters.Add(fPrinterName);
            }
            return fPrinters;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SetDefaultPrinter(listBox1.SelectedItem.ToString());
            varDefaultPrinter.Text = DefaultPrinter;
            //Funs.Printer.AddCustomPaperSize(varDefaultPrinter.Text, "Custom", float.Parse(varWidth.Text), float.Parse(varHeight.Text));
            MessageBox.Show("打印机" + listBox1.SelectedItem.ToString() + "已设置为默认打印机！");
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1_DoubleClick(sender, e);
            }
            else
            {
                MessageBox.Show("请选择要设置的打印机信息！");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<NDolls.Data.Entity.EntityBase> list = new List<NDolls.Data.Entity.EntityBase>();
            NShop.Model.sys_Setting m = new NShop.Model.sys_Setting();
            m.SKey = "PrintTitle";
            m.SValue = varPrintTitle.Text;
            list.Add(m);

            m = new NShop.Model.sys_Setting();
            m.SKey = "PrintBottom";
            m.SValue = varPrintBottom.Text;
            list.Add(m);

            m = new NShop.Model.sys_Setting();
            m.SKey = "Printer";
            m.SValue = varPrinter.Text;
            list.Add(m);
            
            if (NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.BatchSave(list))
            {
                Constant.BottomTitle = varPrintBottom.Text;
                Constant.TopTitle = varPrintTitle.Text;
                Constant.Printer = varPrinter.Text;//刷新缓存
                MessageBox.Show("设置保存成功！");
            }
            else
            {
                MessageBox.Show("设置保存失败！");
            }
        }
        
    }
}
