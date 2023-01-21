using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Serialization;
using CefSharp.DevTools.Profiler;
using CefSharp.DevTools.HeapProfiler;
using CefSharp.DevTools.CSS;

namespace MyVideoDowloader
{
    // TODO: Add Log: https://www.ruyut.com/2021/10/serilog.html
    public partial class MainForm : Form
    {
        // for thread safety
        public Object lockPlaylistsObj = new Object();
        public Object lockVideosObj = new Object();

        public List<PlaylistEntity> playlists = new List<PlaylistEntity>();
        public List<VideoEntity> videos = new List<VideoEntity>();

        private string propFilePath = "";
        public PropertiesManager propMgr = null;
        public BrowserManager browserMgr = null;

        private Downloader downloader = null;
        private PreDownloader preDownloader = null;
        private int previousTabIdx = -1;
        private ListViewRenderer lstviewRenderer = null;

        public MainForm()
        {
            InitializeComponent();
        }

        // ==============================================
        // MainForm Event Handler
        // ==============================================

        private void MainForm_Load(object sender, EventArgs e)
        {
            // initial BrowserManager && navigate to home
            browserMgr = new BrowserManager(this);

            // initial PropertiesManager && load properties from property file
            propFilePath = Path.Combine(System.AppContext.BaseDirectory, @"properties.xml");
            propMgr = new PropertiesManager(this);
            propMgr.readPropertiesFromFile(propFilePath);
            Lbl_Alart.Visible = false;

            // initial pre-downloader && downloader
            short tCnt = short.Parse(ComBox_ThreadCount.Text);
            preDownloader = new PreDownloader(this);
            downloader = new Downloader(this, tCnt);

            // resizing list views
            lstviewRenderer = new ListViewRenderer(this);
            lstviewRenderer.resizeListView();
            timer.Enabled = true;

            // setup listview owner draw handlers
            ListVw_Playlists.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler((hdlr, ee) => ListViewRenderer.drawHeaderHandler(hdlr, ee));
            ListVw_Videos.DrawColumnHeader    += new DrawListViewColumnHeaderEventHandler((hdlr, ee) => ListViewRenderer.drawHeaderHandler(hdlr, ee));
            ListVw_Playlists.DrawItem += new DrawListViewItemEventHandler((hdlr, ee) => ListViewRenderer.drawItemHandler(hdlr, ee));
            ListVw_Videos.DrawItem    += new DrawListViewItemEventHandler((hdlr, ee) => ListViewRenderer.drawItemHandler(hdlr, ee));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop all threads
            preDownloader.stop();
            downloader.stop();

            // leave config tab, save properties to file
            string propFile = Path.Combine(System.AppContext.BaseDirectory, @"properties.xml");
            propMgr.savePropertiesToFile(propFile);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (lstviewRenderer != null) lstviewRenderer.resizeListView();
        }

        // ==============================================
        // Browser Page Event Handler
        // ==============================================

        private void ComBox_WebSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIdx = ComBox_WebSites.SelectedIndex;
            if (selIdx == 0)
            {
                // manually input
                TxtBox_Url.Text = "";
                browserMgr.navigateTo("about:blank", "");
            }
            else
            {
                PropertiesOfWebsite selSite = propMgr.getCurrSite(selIdx - 1);
                TxtBox_Url.Text = selSite.url;
                browserMgr.navigateTo(selSite.url, selSite.cookiePath);
            }

            if (lstviewRenderer != null) lstviewRenderer.resizeListView();
        }

        private void TxtBox_Url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!TxtBox_Url.Enabled) return;

            if (e.KeyChar == '\r')
            {
                string urlTmp = TxtBox_Url.Text;
                ComBox_WebSites.SelectedIndex = 0;
                browserMgr.navigateTo(urlTmp, "");
            }
        }

        private void Btn_SupportList_Click(object sender, EventArgs e)
        {
            ComBox_WebSites.SelectedIndex = 0;
            browserMgr.navigateTo("https://ytdl-org.github.io/youtube-dl/supportedsites.html", "");
        }

        private void Btn_Download_Click(object sender, EventArgs e)
        {
            // send current url to pre-downloader
            preDownloader.analysis(TxtBox_Url.Text.Trim());
            TabCtl_Main.SelectedIndex = 1;
        }

        // ==============================================
        // Config Page Event Handler
        // ==============================================

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 離開 config 頁面時, 把設定回存.
            if (TabCtl_Main.SelectedIndex != previousTabIdx)
            {
                if (previousTabIdx == 2)
                {
                    // leave config tab, save properties to file
                    string propFile = Path.Combine(System.AppContext.BaseDirectory, @"properties.xml");
                    propMgr.savePropertiesToFile(propFile);
                }

                previousTabIdx = TabCtl_Main.SelectedIndex;
            }
        }

        private void Btn_AddNewSite_Click(object sender, EventArgs e)
        {
            DialogResult res = DialogResult.None;
            if (TxtBox_SiteName.ReadOnly) res = MessageBox.Show("網站已存在");
            if (TxtBox_SiteName.Text.Trim().Equals("")) res = MessageBox.Show("網站名稱不可以為空白");
            if (TxtBox_SiteUrl.Text.Trim().Equals("")) res = MessageBox.Show("網站網址不可以為空白");
            if (TxtBox_SiteCompareString.Text.Trim().Equals("")) res = MessageBox.Show("網站比對串字串不可以為空白");
            if (!ComBox_WebSitesConfig.Text.Equals("[新增網站]")) res = MessageBox.Show("網站已存在");
            if (res != DialogResult.None) return;

            bool isAdded = propMgr.addNewSite(
                TxtBox_SiteName.Text.Trim(),
                TxtBox_SiteUrl.Text.Trim(),
                TxtBox_SiteCompareString.Text.Trim(),
                TxtBox_SiteCookiePath.Text.Trim(),
                ChkBox_RelativeCookiePath.Checked
            );

            if (isAdded)
            {
                // update to Gui
                int newIdx = ComBox_WebSitesConfig.Items.Add(TxtBox_SiteName.Text.Trim());
                ComBox_WebSitesConfig.SelectedIndex = newIdx;
                TxtBox_SiteName.ReadOnly = true;

                ComBox_WebSites.Items.Add(TxtBox_SiteName.Text.Trim());
            }
        }

        private void ComBox_WebSitesConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            // currIdx = 0 不在 properties array 中
            int currIdex = ComBox_WebSitesConfig.SelectedIndex;

            if (currIdex == 0)
            {
                // add new item
                TxtBox_SiteName.ReadOnly = false;
                TxtBox_SiteName.Text = "";
                TxtBox_SiteUrl.Text = "";
                TxtBox_SiteCompareString.Text = "";
                TxtBox_SiteCookiePath.Text = "";
            }
            else
            {
                // get old item
                PropertiesOfWebsite currSite = propMgr.getCurrSite(currIdex - 1);
                TxtBox_SiteName.ReadOnly = true;
                TxtBox_SiteName.Text = currSite.name;
                TxtBox_SiteUrl.Text = currSite.url;
                TxtBox_SiteCompareString.Text = currSite.compareString;
                TxtBox_SiteCookiePath.Text = currSite.cookiePath;
                ChkBox_RelativeCookiePath.Checked = currSite.isRelativeCookiePath;
            }
        }

        private void TxtBox_SiteUrl_TextChanged(object sender, EventArgs e)
        {
            int currIdex = ComBox_WebSitesConfig.SelectedIndex;

            if (currIdex > 0)
            {
                // update current setting
                PropertiesOfWebsite currSite = propMgr.getCurrSite(currIdex - 1);
                currSite.url = TxtBox_SiteUrl.Text.Trim();
            }
        }

        private void TxtBox_SiteCookiePath_TextChanged(object sender, EventArgs e)
        {
            // replace all \\
            string txt = TxtBox_SiteCookiePath.Text;
            if (txt.Contains("\\")) TxtBox_SiteCookiePath.Text = txt.Replace("\\", "/");

            // update propMgr
            int currIdex = ComBox_WebSitesConfig.SelectedIndex;

            if (currIdex > 0)
            {
                // check is relative
                if (checkRelative(TxtBox_SiteCookiePath.Text, ChkBox_RelativeCookiePath.Checked)) return;

                // update current setting
                PropertiesOfWebsite currSite = propMgr.getCurrSite(currIdex - 1);
                currSite.cookiePath = TxtBox_SiteCookiePath.Text.Trim();
                currSite.isRelativeCookiePath = ChkBox_RelativeCookiePath.Checked;
            }
        }

        private void TxtBox_SiteCompareString_TextChanged(object sender, EventArgs e)
        {
            int currIdex = ComBox_WebSitesConfig.SelectedIndex;

            if (currIdex > 0)
            {
                // update current setting
                PropertiesOfWebsite currSite = propMgr.getCurrSite(currIdex - 1);
                currSite.compareString = TxtBox_SiteCompareString.Text.Trim();
            }
        }

        private void TxtBox_YtdlPath_TextChanged(object sender, EventArgs e)
        {
            // replace all \\
            string txt = TxtBox_YtdlPath.Text;
            if (txt.Contains("\\")) TxtBox_YtdlPath.Text = txt.Replace("\\", "/");

            // check is relative
            checkRelative(TxtBox_YtdlPath.Text, ChkBox_RelativeYtdlPath.Checked);
        }

        private void TxtBox_DownloadPath_TextChanged(object sender, EventArgs e)
        {
            // replace all \\
            string txt = TxtBox_DownloadPath.Text;
            if (txt.Contains("\\")) TxtBox_DownloadPath.Text = txt.Replace("\\", "/");

            // check is relative
            checkRelative(TxtBox_DownloadPath.Text, ChkBox_RetativeDownloadPath.Checked);
        }

        private void ComBox_ThreadCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lbl_Alart.Visible = true;
        }

        private bool checkRelative(string _txt, bool _isRelative)
        {
            if (_isRelative && !_txt.Trim().StartsWith("."))
            {
                MessageBox.Show("Relative Path should start with \"./\" or \"../\"");
                return false;
            }
            return true;
        }

        // ==============================================
        // Update ListView in timer
        // ==============================================

        private void timer_Tick(object sender, EventArgs e)
        {
            lstviewRenderer.updateListView(playlists, videos);
        }

        private void ListVw_Videos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string historyStr = "";
                foreach (string his in videos[e.Item.Index].processHistory) historyStr += his + "\r\n";
                MessageBox.Show(historyStr);
            }
        }
    }
}