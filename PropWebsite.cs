using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoDowloader
{
    public class PropWebsite
    {
        public string name { get; set; }
        public string url { get; set; }
        public string compareString { get; set; } // 用來確定某個 video 是否屬於這個網站的
        public string cookiePath { get; set; }

        public PropWebsite()
        {
            name = "";
            url = "";
            compareString = "";
            cookiePath = "";
        }

        public bool isVideoUnderThisSite(string _videoUrl)
        {
            // find compare string in url
            return (_videoUrl.IndexOf(compareString) >= 0);
        }
    }
}
