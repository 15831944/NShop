using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoUpdaterDotNET;
using System.Windows.Forms;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Xml;
using System.Reflection;

namespace Updater
{
    public class Update
    {
        private String updateUrl = NShop.Param.Server.UpdateURL;

        public Update()
        {}

        public Update(String updateUrl)
        {
            this.updateUrl = updateUrl;
        }

        public void Start()
        {
            AutoUpdater.CheckForUpdateEvent += new AutoUpdater.CheckForUpdateEventHandler(AutoUpdater_CheckForUpdateEvent);
            AutoUpdater.Start(updateUrl);
        }

        public String CheckVersion()
        {
            Assembly mainAssembly = Assembly.GetEntryAssembly();
            Version installedVersion = mainAssembly.GetName().Version;//已安装的版本号
            Version currentVersion = installedVersion;
            //MessageBox.Show(currentVersion.ToString());

            WebRequest webRequest = WebRequest.Create(updateUrl);
            webRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            WebResponse webResponse;
            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch
            {
                return "";
            }

            Stream appCastStream = webResponse.GetResponseStream();
            var receivedAppCastDocument = new XmlDocument();
            if (appCastStream != null)
            {
                receivedAppCastDocument.Load(appCastStream);
            }
            else
            {
                return "";
            }

            XmlNodeList appCastItems = receivedAppCastDocument.SelectNodes("item");
            if (appCastItems != null)
            {
                foreach (XmlNode item in appCastItems)
                {
                    XmlNode appCastVersion = item.SelectSingleNode("version");
                    if (appCastVersion != null)
                    {
                        String appVersion = appCastVersion.InnerText;
                        currentVersion = new Version(appVersion);
                    }
                }
            }

            if (currentVersion > installedVersion)
            {
                return currentVersion.ToString();
            }
            else
            {
                return "";
            }
        }

        void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args != null)
            {
                if (args.IsUpdateAvailable)
                {
                    try
                    {
                        AutoUpdater.DownloadUpdate();

                        Application.Exit();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(@"当前没有可更新版本，请稍候再试.", @"无更新通知",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(
                       @"获取新版本过程中遇到问题，请查看您的网络状态稍后再试.",
                       @"更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
