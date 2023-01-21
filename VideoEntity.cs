using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoDowloader
{
    public class VideoEntity
    {
        public string name { get; set; }
        public string url { get; set; }
        public string cookiePath { get; set; }
        public string status { get; set; } // record current video status, for process judgment
        public string sourceSiteName { get; set; } // for display only
        public string playlistName { get; set; } // for creating download path
        public string size { get; set; }     // for GUI update
        public string progress { get; set; } // for GUI update
        public List<string> processHistory = new List<string>();

        public VideoEntity()
        {
            name = string.Empty;
            url = string.Empty;
            cookiePath = string.Empty;
            sourceSiteName = string.Empty;
            status = string.Empty;
            playlistName = string.Empty;
            size = string.Empty;
            progress = string.Empty;
        }

        public string[] toSubItemInput()
        {
            // Video Name ; Video Url ; Size ; Status
            string[] response = new string[4];
            response[0] = sourceSiteName; // source name
            response[1] = name.Equals(string.Empty) ? url : name; // video name / url
            response[2] = size; // size
            response[3] = progress; // status
            return response;
        }

        public bool isWaitDownload() { return status.Equals(string.Empty); }
        public bool isDownloading() { return status.Equals("下載中"); }
        public bool isDownloaded() { return status.Equals("下載完成"); }

        public void setIsDownloading() { status = "下載中"; }
        public void setIsDownloaded() { status = "下載完成"; }
    }
}
