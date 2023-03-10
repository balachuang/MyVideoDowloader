using CefSharp.DevTools.HeapProfiler;
using CefSharp.DevTools.Profiler;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml.Serialization.Advanced;

namespace MyVideoDowloader
{
    public class PropertiesManager
    {
        private MainForm parentForm = null;
        private List<PropertiesOfGlobal> configs = null;

        public PropertiesManager(MainForm _form)
        {
            parentForm = _form;
        }

        public void readPropertiesFromFile(string propPath)
        {
            // load properties from property file by 反序列化
            try
            {
                using (Stream fStream = new FileStream(propPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<PropertiesOfGlobal>));
                    fStream.Position = 0;
                    configs = (List<PropertiesOfGlobal>)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception ex)
            {
                // read properties fail...
                MessageBox.Show("[ERROR] " + ex.Message);
                configs = null;
            }
            if (configs == null)
            {
                configs = new List<PropertiesOfGlobal>();
                configs.Add(new PropertiesOfGlobal());
            }

            syncPropertiesAndGUI(true);
        }

        public void savePropertiesToFile(string propPath)
        {
            syncPropertiesAndGUI(false);

            // set default properties by 序列化
            using (Stream fStream = new FileStream(propPath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<PropertiesOfGlobal>));
                xmlFormat.Serialize(fStream, configs);
            }
        }

        public bool addNewSite(string _name, string _url, string _compStr, string _cookiePath, bool _isRelative)
        {
            // ToDo: check if duplicate
            PropertiesOfWebsite pWeb = new PropertiesOfWebsite();
            pWeb.name = _name;
            pWeb.url = _url;
            pWeb.compareString = _compStr;
            pWeb.cookiePath = _cookiePath;
            pWeb.isRelativeCookiePath = _isRelative;

            configs[0].websiteAry.Add(pWeb);
            return true;
        }

        public PropertiesOfWebsite getCurrSite(int idx)
        {
            if (idx < 0) return new PropertiesOfWebsite();
            if (idx >= configs[0].websiteAry.Count) return new PropertiesOfWebsite();
            return configs[0].websiteAry[idx];
        }

        private void syncPropertiesAndGUI(bool syncToGui)
        {
            PropertiesOfGlobal config = configs[0];

            if (syncToGui)
            {
                // combobox
                parentForm.ComBox_WebSitesConfig.Items.Clear();
                parentForm.ComBox_WebSites.Items.Clear();
                parentForm.ComBox_WebSitesConfig.Items.Add("[新增網站]");
                parentForm.ComBox_WebSites.Items.Add("[手動輸入]");
                foreach (PropertiesOfWebsite site in config.websiteAry)
                {
                    parentForm.ComBox_WebSitesConfig.Items.Add(site.name);
                    parentForm.ComBox_WebSites.Items.Add(site.name);
                }
                parentForm.ComBox_WebSitesConfig.SelectedIndex = 0;
                parentForm.ComBox_WebSites.SelectedIndex = 0;

                parentForm.ComBox_ThreadCount.Text = config.threadCount.ToString();

                // text box
                parentForm.TxtBox_SiteName.ReadOnly = false;
                parentForm.TxtBox_SiteName.Text = "";
                parentForm.TxtBox_SiteUrl.Text = "";
                parentForm.TxtBox_SiteCompareString.Text = "";
                parentForm.TxtBox_SiteCookiePath.Text = "";
                parentForm.TxtBox_YtdlPath.Text = config.ytdlExecPath;
                parentForm.TxtBox_DownloadPath.Text = config.downloadPath;
                parentForm.TxtBox_CustFormat.Text = config.custFormat;

                // boolean
                parentForm.ChkBox_RelativeYtdlPath.Checked = config.isRelativeYtdlExecPath;
                parentForm.ChkBox_RetativeDownloadPath.Checked = config.isRelativeDownloadPath;
                parentForm.ChkBox_CreateSubFolder.Checked = config.createSubFolder;
                parentForm.ChkBox_SkipWatchLaterSubFolder.Checked = config.skipWatchLaterSubFolder;
                parentForm.ChkBox_UseCustFormat.Checked = config.useCustFormat;
            }
            else
            {
                // combobox - skip web sites gui
                config.threadCount = short.Parse(parentForm.ComBox_ThreadCount.Text);

                // textbox - skip web sites gui
                config.ytdlExecPath = parentForm.TxtBox_YtdlPath.Text;
                config.downloadPath = parentForm.TxtBox_DownloadPath.Text;
                config.custFormat = parentForm.TxtBox_CustFormat.Text;

                // boolean
                config.isRelativeYtdlExecPath = parentForm.ChkBox_RelativeYtdlPath.Checked;
                config.isRelativeDownloadPath = parentForm.ChkBox_RetativeDownloadPath.Checked;
                config.createSubFolder = parentForm.ChkBox_CreateSubFolder.Checked;
                config.skipWatchLaterSubFolder = parentForm.ChkBox_SkipWatchLaterSubFolder.Checked;
                config.useCustFormat = parentForm.ChkBox_UseCustFormat.Checked;
            }
        }

        public int findSiteIdxByVideoUrl(string videoUrl)
        {
            for (int n = 0; n < configs[0].websiteAry.Count; ++n)
                if (configs[0].websiteAry[n].isVideoUnderThisSite(videoUrl))
                    return n;

            return -1;
        }

        public PropertiesOfGlobal getDownloadProperties()
        {
            return configs[0];
        }
    }
}
