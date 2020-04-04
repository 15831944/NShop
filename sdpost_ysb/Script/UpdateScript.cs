using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace NShop.Script
{
    public class UpdateScript
    {
        public static void Update()
        {
            Assembly mainAssembly = Assembly.GetEntryAssembly();
            Version installedVersion = mainAssembly.GetName().Version;//当前主程序版本号（可执行文件存储）
            Version lastVersion = null;//升级前老版本号（数据库存储）

            NShop.Service.SettingService s = new NShop.Service.SettingService();
            NShop.Model.Setting setting = s.GetSetting("LastVersion");
            if (setting == null)
            {
                lastVersion = new Version("0.0.0.0");
            }
            else
            {
                lastVersion = new Version(setting.SValue);
            }

            if (installedVersion == lastVersion) return;//程序版本与数据库版本一致，无需升级

            Assembly asm = Assembly.GetExecutingAssembly();//读取嵌入式资源
            String[] files = asm.GetManifestResourceNames();
            Stream ms = null;
            byte[] bs;
            String sql = "";

            Funs.Constant.Loger.WriteLog("数据库备份开始");
            Funs.DBUtil.Backup("update_" + lastVersion.ToString());
            Funs.Constant.Loger.WriteLog("数据库备份完毕");

            Funs.Constant.Loger.WriteLog("数据库脚本升级开始");
            foreach (String fileName in files)
            {
                //对oldversion～newversion之间的数据脚本进行更新执行
                if (fileName.Contains("NShop.Script"))
                {
                    String scriptVersion = fileName.Replace("NShop.Script.", "").Replace(".sql", "");//脚本对应版本号
                    if (scriptVersion.CompareTo(lastVersion.ToString()) > 0 && scriptVersion.CompareTo(installedVersion.ToString()) <= 0)
                    {
                        ms = asm.GetManifestResourceStream(fileName);
                        bs = new byte[ms.Length];
                        ms.Read(bs, 0, bs.Length);
                        sql = GetUTF8String(bs);
                        sql = sql.Replace("\n", "").Replace("\r", "").Replace("\t", "");

                        if (!String.IsNullOrEmpty(sql))
                        {
                            try
                            {
                                NDolls.Data.RepositoryBase<NDolls.Data.Entity.EntityBase>.Excute(sql);
                                Funs.Constant.Loger.WriteLog(fileName + "脚本升级成功");
                            }
                            catch
                            {
                                Funs.Constant.Loger.WriteLog(fileName + "脚本升级失败");
                            }
                        }
                    }
                }
            }
            Funs.Constant.Loger.WriteLog("数据库脚本升级结束");

            setting = new NShop.Model.Setting();
            setting.SKey = "LastVersion";
            setting.SValue = installedVersion.ToString();
            s.AddorUpdate(setting);
        }

        /// <summary>
        /// 获取UTF8数据字符串（过滤BOM头部）
        /// </summary>
        /// <param name="buffer">二进制流</param>
        /// <returns>数据字符串</returns>
        private static string GetUTF8String(byte[] buffer)
        {
            if (buffer == null)
                return null;

            if (buffer.Length <= 3)
            {
                return Encoding.UTF8.GetString(buffer);
            }

            byte[] bomBuffer = new byte[] { 0xef, 0xbb, 0xbf };

            if (buffer[0] == bomBuffer[0]
                && buffer[1] == bomBuffer[1]
                && buffer[2] == bomBuffer[2])
            {
                return new UTF8Encoding(false).GetString(buffer, 3, buffer.Length - 3);
            }

            return Encoding.UTF8.GetString(buffer);
        }
    }
}
