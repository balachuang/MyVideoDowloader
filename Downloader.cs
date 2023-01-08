using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVideoDowloader
{
    internal class Downloader
    {
        private MainForm parentForm = null;
        private List<Thread> threads = new List<Thread>();
        private Process[] processes = null;

        private static string PARAM_TEMPLATE_DOWNLOAD = " {cookie-file} --mark-watched -o {output-path} {cust-format} {video-url}";

        public Downloader(MainForm _form, short _threadCount)
        {
            parentForm = _form;

            // initiate Threads for Video downloading
            if ((_threadCount < 0) || (_threadCount > 30)) _threadCount = 10;
            for (int n = 0; n < _threadCount; ++n)
            {
                Thread thread = new Thread(downloadVideo);
                thread.Start();
                threads.Add(thread);
                Thread.Sleep(200);

                processes = new Process[_threadCount];
            }
        }

        public void stop()
        {
            for (int n=0; n<processes.Length; ++n)
            {
                if (processes[n] != null)
                {
                    processes[n].Close();
                    processes[n] = null;
                }
            }

            foreach (Thread thread in threads) thread.Abort();
            threads.Clear();
        }

        private void downloadVideo()
        {
            while (true)
            {
                // find next video to download
                int currVideotIdx = -1;
                VideoEntity currVideo = null;
                lock (parentForm.lockVideosObj)
                {
                    for (int n = 0; n < parentForm.videos.Count; ++n)
                    {
                        if (parentForm.videos[n].isWaitDownload())
                        {
                            currVideo = parentForm.videos[n];
                            currVideo.setIsDownloading();
                            currVideotIdx = n;
                            break;
                        }
                    }
                }

                if (currVideotIdx < 0)
                {
                    // nothing to download, long sleep
                    Thread.Sleep(5000);
                    continue;
                }

                // prepare output parameter
                PropDownloader prop = parentForm.propMgr.getDownloadProperties();
                string ytdlCommand = prop.ytdlExecPath;
                string ytdlParam_Cookies = "--cookies ''" + currVideo.cookiePath + "''";
                string ytdlParam_CustFmt = prop.custFormat.Equals(string.Empty) ? "" : "-f ''" + prop.custFormat + "''";
                string ytdlParam_VideoUrl = currVideo.url;

                bool isCreateSubFolder = prop.createSubFolder && (!prop.skipWatchLaterSubFolder || !currVideo.playlistName.Equals("稍後觀看"));
                string ytdlParam_Output = (isCreateSubFolder && currVideo.url.Contains("www.youtube.com")) ?
                    "''" + prop.downloadPath.TrimEnd("/\\".ToArray()) + "/%(playlist_title)s/%(title)s.%(ext)s''" :
                    "''" + prop.downloadPath.TrimEnd("/\\".ToArray()) + "/%(title)s.%(ext)s''";

                string ytdlParam = PARAM_TEMPLATE_DOWNLOAD
                    .Replace("{cookie-file}", ytdlParam_Cookies)
                    .Replace("{output-path}", ytdlParam_Output)
                    .Replace("{cust-format}", ytdlParam_CustFmt)
                    .Replace("{video-url}", ytdlParam_VideoUrl)
                    .Replace("''", "\"");
                //MessageBox.Show(ytdlParam);

                // start download
                ProcessStartInfo cmdsi = new ProcessStartInfo(ytdlCommand);
                cmdsi.Arguments = ytdlParam;
                cmdsi.UseShellExecute = false;
                cmdsi.RedirectStandardError = true;
                cmdsi.RedirectStandardInput = true;
                cmdsi.RedirectStandardOutput = true;
                cmdsi.CreateNoWindow = true;

                // get unused process for execution
                int processIdx = -1;
                lock(parentForm.lockVideosObj)
                {
                    for (int n = 0; n < processes.Length; ++n)
                    {
                        if (processes[n] == null)
                        {
                            processes[n] = Process.Start(cmdsi);
                            processIdx = n;
                            break;
                        }
                    }
                }
                if (processIdx < 0)
                {
                    // error in getting un-used process, skip this iteration
                    Thread.Sleep(5000);
                    continue;
                }

                processes[processIdx].OutputDataReceived +=
                    (o, e) =>
                    {
                        if (e.Data != null)
                        {
                            // get source site name
                            Match matchSource = Regex.Match(e.Data, "\\[(.+)\\]\\s+.+:\\s+Downloading webpage");
                            if (matchSource.Success)
                            {
                                Group g1 = matchSource.Groups[1];
                                lock (parentForm.lockVideosObj)
                                {
                                    currVideo.sourceSiteName = g1.ToString();
                                }
                            }

                            // get video name
                            Match matchVideo = Regex.Match(e.Data, "\\[download\\]\\s+Destination:\\s+(.+)");
                            if (matchVideo.Success)
                            {
                                Group g1 = matchVideo.Groups[1];
                                lock (parentForm.lockVideosObj)
                                {
                                    currVideo.name = g1.ToString();
                                }
                            }

                            // get download status
                            Match matchStatus = Regex.Match(e.Data, "\\[download\\]\\s+(.+%) of (.+) at .+");
                            if (matchStatus.Success)
                            {
                                Group g1 = matchStatus.Groups[1];
                                Group g2 = matchStatus.Groups[2];
                                lock (parentForm.lockVideosObj)
                                {
                                    currVideo.progress = g1.ToString();
                                    currVideo.size = g2.ToString();
                                }
                            }

                            // get ERROR...
                            Match matchError = Regex.Match(e.Data, "ERROR:\\s+(.+)");
                            if (matchError.Success)
                            {
                                Group g1 = matchError.Groups[1];
                                lock (parentForm.lockVideosObj)
                                {
                                    string errText = g1.ToString();
                                    if (errText.StartsWith("Unsupported URL"))
                                    {
                                        currVideo.progress = "[Error] Unsupported URL";
                                        currVideo.size = "N/A";
                                    }
                                    else
                                    {
                                        currVideo.progress = "[Error] HTTP Error 403: Forbidden";
                                        currVideo.size = "N/A";
                                    }
                                }
                            }
                        }
                    };
                processes[processIdx].BeginOutputReadLine();
                processes[processIdx].WaitForExit();

                processes[processIdx].Close();
                processes[processIdx] = null;
                processIdx = -1;

                if (!"Err".Equals(currVideo.size))
                {
                    currVideo.progress = "100%";
                    currVideo.setIsDownloaded();
                }

                // sleep 1 sec and find next video to download...
                Thread.Sleep(1000);
            }
        }
    }
}
