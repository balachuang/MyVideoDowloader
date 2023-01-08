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
    public class PropDownloader
    {
        public List<PropWebsite> websiteAry { get; set; }
        public string ytdlExecPath { get; set; }
        public string downloadPath { get; set; }
        public string custFormat { get; set; }
        public bool createSubFolder { get; set; }
        public bool skipWatchLaterSubFolder { get; set; }
        public bool useCustFormat { get; set; }
        public short threadCount { get; set; }

        public PropDownloader()
        {
            websiteAry = new List<PropWebsite>();
            ytdlExecPath = "D:/youtube-dl/youtube-dl.exe";
            downloadPath = "D:/download";
            custFormat = "";
            createSubFolder = true;
            skipWatchLaterSubFolder = true;
            useCustFormat = false;
            threadCount = 10;
        }
    }
}
