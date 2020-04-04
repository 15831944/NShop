using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUIControls;
using System.Drawing;
using NShop.Service;

namespace NShop.Funs
{
    public class Constant
    {
        private static NDolls.Core.Log loger = new NDolls.Core.Log(Application.StartupPath+"\\Logs", NDolls.Core.LogMod.Month);
        /// <summary>
        /// 日志管理器
        /// </summary>
        public static NDolls.Core.Log Loger
        {
            get { return Constant.loger; }
            set { Constant.loger = value; }
        }

        #region 登录用户信息

        private static String userName = "";
        /// <summary>
        /// 登录用户名
        /// </summary>
        public static String UserName
        {
            get { return Constant.userName; }
            set { Constant.userName = value; }
        }

        private static String userRole="Admin";//默认店员角色
        /// <summary>
        /// 用户角色
        /// </summary>
        public static String UserRole
        {
            get { return Constant.userRole; }
            set { Constant.userRole = value; }
        }

        /// <summary>
        /// 角色的权限集合
        /// </summary>
        public static Dictionary<String, String> RolePermission
        {
            get 
            {
                return NShop.Param.Role.Roles[UserRole];
            }
        }

        #endregion

        private static String printer = null;
        /// <summary>
        /// 打印机
        /// </summary>
        public static String Printer
        {
            get 
            {
                if (String.IsNullOrEmpty(printer))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        printer = s.GetSetting("Printer").SValue;
                    }
                    catch { }
                }
                return printer; 
            }
            set
            {
                printer = value;
            }
        }

        private static String topTitle = null;
        /// <summary>
        /// 头部标题
        /// </summary>
        public static String TopTitle
        {
            get 
            {
                if (String.IsNullOrEmpty(topTitle))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        topTitle = s.GetSetting("PrintTitle").SValue;
                    }
                    catch { }
                }
                return topTitle; 
            }
            set
            {
                topTitle = value;
            }
        }

        private static String bottomTitle = null;
        /// <summary>
        /// 底部标题
        /// </summary>
        public static String BottomTitle
        {
            get 
            {
                if (String.IsNullOrEmpty(bottomTitle))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        bottomTitle = s.GetSetting("PrintBottom").SValue;
                    }
                    catch { }
                }
                return bottomTitle; 
            }
            set
            {
                bottomTitle = value;
            }
        }

        private static String usertype = null;
        //系统参数中记录的用户类型：买卖惠、便民服务站
        public static String UserType
        {
            get
            {
                if (String.IsNullOrEmpty(usertype))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        usertype = s.GetSetting("usertype").SValue;
                    }
                    catch { }
                }
                return usertype;
            }
            set
            {
                usertype = value;
            }
        }

        private static String serverurl = null;
        //系统参数中记录的后台服务url
        public static String ServerUrl
        {
            get
            {
                if (String.IsNullOrEmpty(serverurl))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        serverurl = s.GetSetting("serverurl").SValue;
                    }
                    catch { }
                }
                return serverurl;
            }
            set
            {
                serverurl = value;
            }
        }

        private static String useraccount = null;
        //系统参数中记录的用户账户，分别对应便民服务站机构号和买卖惠用户名
        public static String UserAccount
        {
            get
            {
                if (String.IsNullOrEmpty(useraccount))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        useraccount = s.GetSetting("useraccount").SValue;
                    }
                    catch { }
                }
                return useraccount;
            }
            set
            {
                useraccount = value;
            }
        }

        private static String encodepaswd = null;
        //系统参数中记录的传输过程中使用的密码encodepaswd
        public static String EncodePaswd
        {
            get
            {
                if (String.IsNullOrEmpty(encodepaswd))
                {
                    SettingService s = new SettingService();
                    try
                    {
                        encodepaswd = s.GetSetting("encodepaswd").SValue;
                    }
                    catch { }
                }
                return encodepaswd;
            }
            set
            {
                encodepaswd = value;
            }
        }

        #region 用户习惯配置
        private static String printCount = null;
        /// <summary>
        /// 小票打印数量
        /// </summary>
        public static String PrintCount
        {
            get
            {
                if (String.IsNullOrEmpty(printCount))
                {
                    NShop.Service.SettingService s = new SettingService();
                    NShop.Model.Setting m = s.GetSetting("PrintCount");
                    if (m != null)
                        printCount = m.SValue;
                }
                return Constant.printCount;
            }
            set { printCount = value; }
        }

        private static String printScores = null;
        /// <summary>
        /// 小票打印是否打印积分
        /// </summary>
        public static String PrintScores
        {
            get 
            {
                if (String.IsNullOrEmpty(printScores))
                {
                    NShop.Service.SettingService s = new SettingService();
                    NShop.Model.Setting m = s.GetSetting("PrintScores");
                    if(m!=null)
                        printScores = m.SValue;
                }
                return Constant.printScores; 
            }
            set { printScores = value; }
        }

        private static String printUserName = null;
        /// <summary>
        /// 小票打印是否打印积分
        /// </summary>
        public static String PrintUserName
        {
            get
            {
                if (String.IsNullOrEmpty(printUserName))
                {
                    NShop.Service.SettingService s = new SettingService();
                    NShop.Model.Setting m = s.GetSetting("PrintUserName");
                    if (m != null)
                        printUserName = m.SValue;
                }
                return Constant.printUserName;
            }
            set { printUserName = value; }
        }

        private static String priceStrategy = null;
        /// <summary>
        /// 结算费用是否抹零进位
        /// </summary>
        public static String PriceStrategy
        {
            get
            {
                if (String.IsNullOrEmpty(priceStrategy))
                {
                    NShop.Service.SettingService s = new SettingService();
                    NShop.Model.Setting m = s.GetSetting("PriceStrategy");
                    if (m != null)
                        priceStrategy = m.SValue;
                }
                return Constant.priceStrategy;
            }
            set { priceStrategy = value; }
        }
        #endregion

        #region 用户最近操作记录

        private static String lastAlarm = null;
        /// <summary>
        /// 库存预警值
        /// </summary>
        public static String LastAlarm
        {
            get
            {
                if (String.IsNullOrEmpty(lastAlarm))
                {
                    NShop.Service.SettingService s = new SettingService();
                    NShop.Model.Setting m = s.GetSetting("LastAlarm");
                    if (m != null)
                        lastAlarm = m.SValue;
                }
                return Constant.lastAlarm;
            }
            set { lastAlarm = value; }
        }

        private static String lastBrand = null;
        /// <summary>
        /// 商品品牌
        /// </summary>
        public static String LastBrand
        {
            get
            {
                if (String.IsNullOrEmpty(lastBrand))
                {
                    NShop.Service.SettingService s = new SettingService();
                    NShop.Model.Setting m = s.GetSetting("LastBrand");
                    if (m != null)
                        lastBrand = m.SValue;
                }
                return Constant.lastBrand;
            }
            set { lastBrand = value; }
        }
        #endregion

        public static List<NShop.Model.sdopst_OrderDetail> list_pause = new List<NShop.Model.sdopst_OrderDetail>();
        public static List<NShop.Model.sdpost_Order> pause_order_list = new List<NShop.Model.sdpost_Order>();
    }
}
