using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using System.IO;
using System.Xml.Serialization;
using static MyVideoDowloader.MainForm;
using System.Runtime.ConstrainedExecution;

namespace MyVideoDowloader
{
    public class BrowserManager
    {
        public delegate void changeParentCursorDelegate();

        private MainForm parentForm = null;
        private ChromiumWebBrowser browserObj;
        private ICookieManager cookieMgr;

        public BrowserManager(MainForm _form)
        {
            parentForm = _form;

            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);

            browserObj = new ChromiumWebBrowser();
            browserObj.LifeSpanHandler = new CustomLifeSpanHandler();

            browserObj.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
            browserObj.LoadingStateChanged += Browser_LoadingStateChanged;

            parentForm.Pnl_BrowserContainer.Controls.Add(browserObj);
            browserObj.Dock = DockStyle.Fill;
        }

        public void navigateTo(string url, string cookiePath)
        {
            if ("".Equals(url)) return;
            if (!browserObj.IsBrowserInitialized) return;

            if (!"".Equals(cookiePath)) readCookiesFromFile(url, cookiePath);
            browserObj.Load(url);
        }

        public void changeParentCursor()
        {
            if (browserObj.IsLoading)
            {
                parentForm.Pnl_BrowserContainer.Cursor = Cursors.WaitCursor;
                parentForm.TxtBox_Url.Enabled = false;
            }
            else
            {
                parentForm.Pnl_BrowserContainer.Cursor = Cursors.Default;
                if (browserObj.Address != null) parentForm.TxtBox_Url.Text = browserObj.Address.ToString();
                parentForm.TxtBox_Url.Enabled = true;
            }
        }

        private void Browser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            if (browserObj.IsBrowserInitialized) cookieMgr = browserObj.GetCookieManager();
        }

        private void Browser_LoadingStateChanged(object sender, EventArgs e)
        {
            // 用 delegate 解決不同 thread 不能呼叫 form.control 的問題.
            changeParentCursorDelegate cpcd = new changeParentCursorDelegate(changeParentCursor);
            parentForm.BeginInvoke(cpcd, new Object[] {});
        }

        private bool readCookiesFromFile(string url, string cookiePath)
        {
            if (!browserObj.IsBrowserInitialized) return false;
            if ("".Equals(cookiePath)) return false;

            try
            {
                cookieMgr.DeleteCookies("", "");

                IEnumerable<string> lines = File.ReadLines(cookiePath);
                foreach (string line in lines)
                {
                    if (line.Trim().Equals("")) continue;
                    if (line.Trim().StartsWith("#")) continue;

                    addCookie(url, line);
                }
            }
            catch (Exception ex)
            {
                // clear cookies
                MessageBox.Show("[ERROR] " + ex.Message);
                cookieMgr.DeleteCookies("", "");
                return false;
            }

            return true;
        }

        private void addCookie(string url, string cookieCols)
        {
            // format: Domain, Include subdomains, Path, Secure, Expiry, Name, Value
            string[] cookieAry = cookieCols.Split(new char[] { '\t' });

            cookieMgr.SetCookie(url, new Cookie()
            {
                Domain = cookieAry[0],
                HttpOnly = "TRUE".Equals(cookieAry[1]),
                Path = cookieAry[2],
                Secure = "TRUE".Equals(cookieAry[3]),
                //Expires = new DateTime(long.Parse(cookieAry[4])),
                Name = cookieAry[5],
                Value = cookieAry[6]
            });
        }
    }
}
