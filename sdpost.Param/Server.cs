using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NShop.Param
{
    public static class Server
    {
        public static readonly String ServerURL = "http://www.ndolls.net/";
        public static readonly String UpdateURL = ServerURL + "update_nshop/update.xml";//系统升级地址
        public static readonly String UpdateLogUrl = ServerURL + "update_nshop/update.txt";//最新升级日志说明地址
    }
}
