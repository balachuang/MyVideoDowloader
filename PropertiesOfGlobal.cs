using CefSharp.DevTools.HeapProfiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Serialization;

namespace MyVideoDowloader
{
    public class PropertiesOfGlobal
    {
        public List<PropertiesOfWebsite> websiteAry { get; set; }
        public string ytdlExecPath { get; set; }
        public string downloadPath { get; set; }
        public string custFormat { get; set; }
        public bool isRelativeYtdlExecPath { get; set; }
        public bool isRelativeDownloadPath { get; set; }
        public bool createSubFolder { get; set; }
        public bool skipWatchLaterSubFolder { get; set; }
        public bool useCustFormat { get; set; }
        public short threadCount { get; set; }

        public PropertiesOfGlobal()
        {
            websiteAry = new List<PropertiesOfWebsite>();
            ytdlExecPath = "D:/youtube-dl/youtube-dl.exe";
            downloadPath = "D:/download";
            custFormat = "";
            isRelativeYtdlExecPath = false;
            isRelativeDownloadPath = false;
            createSubFolder = true;
            skipWatchLaterSubFolder = true;
            useCustFormat = false;
            threadCount = 10;
        }
    }
}
