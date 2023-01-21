using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoDowloader
{
    public class PlaylistEntity
    {
        public string name { get; set; }
        public string url { get; set; }
        public string cookiePath { get; set; }
        public string status { get; set; } // for diaplay only

        public PlaylistEntity()
        {
            name = string.Empty;
            url = string.Empty;
            cookiePath = string.Empty;
            status = string.Empty;
        }

        public string[] toSubItemInput(int idx)
        {
            string[] response = new string[4];
            response[0] = idx.ToString();
            response[1] = name;
            response[2] = url;
            response[3] = status;
            return response;
        }

        public bool isUnprocessed() { return status.Equals(string.Empty); }
        public bool isProcessing() { return isProcessing1() || isProcessing2(); }
        public bool isProcessing1() { return status.Equals("取得播放清單名稱中"); }
        public bool isProcessing2() { return status.Equals("取得影片列表中"); }
        public bool isDone() { return status.Equals("完成"); }

        //public void setProcessing() { status = "處理中"; }
        public void setProcessing1() { status = "取得播放清單名稱中"; }
        public void setProcessing2() { status = "取得影片列表中"; }
        public void setDone() { status = "完成"; }
    }
}
