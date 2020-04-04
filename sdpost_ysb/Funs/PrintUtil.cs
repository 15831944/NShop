using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security;
using System.Drawing;
using System.IO;

namespace NShop.Funs
{
    public class PrintHelper
    {
        private String title;
        private String content;
        private String bottom;
        private bool isCheck = false;//是否弹出对话确认框

        private String orderID;
        /// <summary>
        /// 订单号
        /// </summary>
        public String OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        /// <summary>
        /// 打印类构造函数
        /// </summary>
        /// <param name="title">打印标题</param>
        /// <param name="content">打印内容</param>
        public PrintHelper(String title, String content, String bottom)
        {
            this.title = title;
            this.content = content;
            this.bottom = bottom;
        }

        /// <summary>
        /// 执行打印操作
        /// </summary>
        public void Print()
        {
            //创建一个PrintDocument的实例 
            System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
            docToPrint.DocumentName = title;
            docToPrint.DefaultPageSettings.PrinterSettings.PrinterName = Funs.Constant.Printer;//"XP-58";

            docToPrint.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            if (isCheck)
            {
                // 创建一个PrintDialog的实例。 
                PrintDialog PrintDialog1 = new PrintDialog();
                PrintDialog1.AllowSomePages = true;
                PrintDialog1.ShowHelp = true;

                // 把PrintDialog的Document属性设为上面配置好的PrintDocument的实例 
                PrintDialog1.Document = docToPrint;

                // 调用PrintDialog的ShowDialog函数显示打印对话框 
                DialogResult result = PrintDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    docToPrint.Print();
                }
            }
            else
            {
                docToPrint.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            System.Drawing.Font smallFont = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Regular);

            e.Graphics.DrawString(title, smallFont, System.Drawing.Brushes.Black, 5, 1);
            String tmpContent = content;
            tmpContent += " \n" + bottom + " \n";
            tmpContent += " \n       ";
            tmpContent += " \n       ";
            e.Graphics.DrawString(tmpContent, smallFont, System.Drawing.Brushes.Black, 5, 18);

            #region 小票图片保存
            Image img = new Bitmap(e.PageSettings.PaperSize.Width, 170 + 5 * content.Split('\n').Length);
            Graphics g = Graphics.FromImage(img);
            g.DrawString(title, smallFont, System.Drawing.Brushes.Black, 5, 5);
            g.DrawString(content, smallFont, System.Drawing.Brushes.Black, 5, 18);
            if (!Directory.Exists("Receipts\\" + DateTime.Now.ToString("yyyyMM")))
            {
                Directory.CreateDirectory("Receipts\\" + DateTime.Now.ToString("yyyyMM"));
            }
            img.Save("Receipts\\" + DateTime.Now.ToString("yyyyMM") + "\\" + OrderID + ".bmp");
            e.Graphics.Dispose();
            #endregion
        }
    }

    public class PrintUtil
    {
        public static void PrintReceipt(String orderID)
        {
            PrintReceipt(orderID, false);
        }

        /// <summary>
        /// 打印小票
        /// </summary>
        /// <param name="orderID">订单编号</param>
        /// <param name="isReprint">是否补打小票</param>
        public static void PrintReceipt(String orderID,Boolean isReprint)
        {
            NShop.Service.OrderService s = new NShop.Service.OrderService();
            NShop.Model.sdpost_Order m = new NShop.Model.sdpost_Order();
            m = s.GetOrder(orderID);

            String content = "";
            content += "单号:" + m.ID + "\n";
            content += "日期:" + DateTime.Now.ToString() + "\n"; 
            content += "数量           单价          金额\n";
            content += "------------------------------------------------------\n";
            foreach(NShop.Model.sdopst_OrderDetail md in m.Details)
            {
                content += md.GoodsName + "  " + md.Unit + "\n";
                content += md.GoodsNum + "           " + String.Format("{0,8}", md.UnitPrice.ToString("C")) + "       " + String.Format("{0,8}", md.SalePrice.ToString("C")) + "\n";
            }

            content += "------------------------------------------------------\n";
            content += "总件数:" + m.GoodsNum + "\n";
            content += "总价:" + m.OriginalPrice.ToString("C") + "        ";
            content += "优惠:" + "-" + m.Discount.ToString("C") + "\n";
            content += "应收:" + m.ReceivablePrice.ToString("C") + "        ";
            content += "实收:" + m.Received.ToString("C") + "\n";
            content += "找零:" + m.Change.ToString("C") + "\n";

            #region 会员信息
            if (Funs.Constant.PrintScores == "True")
            {
                NShop.Service.MemberService ms = new NShop.Service.MemberService();
                NShop.Model.sdpost_Member mm = null;
                if (!String.IsNullOrEmpty(m.MemberNo))//查找会员信息
                {
                    mm = ms.GetMemberByMemberNo(m.MemberNo);
                }

                if (mm != null)
                {
                    content += "------------------------------------------------------\n";
                    content += "会员号:" + m.MemberNo + "\n";
                    if (isReprint)
                        content += "新增积分:" + m.Scores + "\n";
                    else
                        content += "新增积分:" + m.Scores + "        剩余积分:" + mm.Scores + "\n";
                }
            }
            #endregion

            PrintHelper ph = new PrintHelper(Funs.Constant.TopTitle, content, Funs.Constant.BottomTitle);
            ph.OrderID = orderID;
            try
            {
                int cnt = 1;
                if (!String.IsNullOrEmpty(Funs.Constant.PrintCount))
                {
                    cnt = int.Parse(Funs.Constant.PrintCount);
                }

                for (int i = 0; i < cnt; i++)
                {
                    ph.Print();
                }
            }
            catch
            {
                MessageBox.Show("打印机设置有误，请先设置打印机!");
                Print.PrintReceipt frm = new Print.PrintReceipt();
                Funs.ControlUtil.ShowForm(frm);
            }
        }

        public static void PrintTest()
        {
            String content = "";
            content += "单号:00000000001\n";
            content += "日期:" + DateTime.Now.ToString() + "\n";
            content += "------------------------------------------------------\n";

            content += "欢迎使用店面助手进销存系统\n";
            content += "您的小票打印机已可正常使用\n";

            content += "------------------------------------------------------\n";

            PrintHelper ph = new PrintHelper(Funs.Constant.TopTitle, content, Funs.Constant.BottomTitle);
            try
            {
                ph.Print();
            }
            catch
            {
                MessageBox.Show("打印机设置有误，请先设置打印机!");
                Print.PrintReceipt frm = new Print.PrintReceipt();
                Funs.ControlUtil.ShowForm(frm);
            }
        }
 
    }
}
