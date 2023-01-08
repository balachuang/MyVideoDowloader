using CefSharp.DevTools.HeapProfiler;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyVideoDowloader.BrowserManager;

namespace MyVideoDowloader
{
    internal class PreDownloader
    {
        private MainForm parentForm = null;
        private Thread thread = null;

        private static string PARAM_TEMPLATE_GET_NAME = " {cookie-file} --flat-playlist {playlist-url}";
        private static string PARAM_TEMPLATE_GET_VIDEOS = " {cookie-file} --get-title {playlist-url}";

        public PreDownloader(MainForm _form)
        {
            parentForm = _form;

            // initiate a new Thread for Youtube Playlist processing
            thread = new Thread(processPlaylist);
            thread.Start();
        }

        public void stop()
        {
            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }
        }

        // url preprocessing
        public void analysis(string url)
        {
            // 1. find site index from url
            int siteIdx = parentForm.propMgr.findSiteIdxByVideoUrl(url);
            if (siteIdx >= 0)
            {
                // in the site list
                if (url.Contains("www.youtube.com/playlist?"))
                {
                    // is Youtube Playlist, add to playlist array
                    PlaylistEntity pe = new PlaylistEntity();
                    pe.url = url;
                    pe.cookiePath = parentForm.propMgr.getCurrSite(siteIdx).cookiePath;
                    lock (parentForm.lockPlaylistsObj) { parentForm.playlists.Add(pe); }
                }
                else
                {
                    // is video, add to video list
                    VideoEntity ve = new VideoEntity();
                    ve.url = url;
                    ve.cookiePath = parentForm.propMgr.getCurrSite(siteIdx).cookiePath;
                    lock (parentForm.lockVideosObj) { parentForm.videos.Add(ve); }
                }
            }
            else
            {
                // not in the site list, add to video list directory
                VideoEntity ve = new VideoEntity();
                ve.url = url;
                lock (parentForm.lockVideosObj) { parentForm.videos.Add(ve); }
            }
        }

        private void processPlaylist()
        {
            while(true)
            {
                // find playlist to get video list
                int currPlaylistIdx = -1;
                PlaylistEntity currPlaylist = null;
                lock(parentForm.lockPlaylistsObj)
                {
                    for (int n = 0; n < parentForm.playlists.Count; ++n)
                    {
                        if (parentForm.playlists[n].isUnprocessed())
                        {
                            currPlaylist = parentForm.playlists[n];
                            currPlaylistIdx = n;
                            break;
                        }
                    }
                }

                if (currPlaylistIdx >= 0)
                {
                    PropDownloader prop = parentForm.propMgr.getDownloadProperties();

                    // 1. get playlist name
                    string ytdlCommand = prop.ytdlExecPath;
                    string ytdlParam_Cookies = "--cookies ''" + currPlaylist.cookiePath + "''";
                    string ytdlParam1 = PARAM_TEMPLATE_GET_NAME.Replace("{cookie-file}", ytdlParam_Cookies).Replace("{playlist-url}", "''" + currPlaylist.url + "''").Replace("''", "\"");
                    string ytdlParam2 = PARAM_TEMPLATE_GET_VIDEOS.Replace("{cookie-file}", ytdlParam_Cookies).Replace("{playlist-url}", "''" + currPlaylist.url + "''").Replace("''", "\"");

                    currPlaylist.setProcessing1();

                    ProcessStartInfo cmdsi = new ProcessStartInfo(ytdlCommand);
                    cmdsi.Arguments = ytdlParam1;
                    cmdsi.UseShellExecute = false;
                    cmdsi.RedirectStandardError = true;
                    cmdsi.RedirectStandardInput = true;
                    cmdsi.RedirectStandardOutput = true;
                    cmdsi.CreateNoWindow = true;

                    Process process1 = Process.Start(cmdsi);
                    process1.OutputDataReceived +=
                        (o, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data) && e.Data.StartsWith("[download] Downloading playlist:"))
                            {
                                // Playlist name found
                                lock (parentForm.lockPlaylistsObj)
                                {
                                    currPlaylist.name = e.Data.Substring(33);
                                }
                                
                            }
                        };
                    process1.BeginOutputReadLine();
                    process1.WaitForExit();

                    if (currPlaylist.name.Trim().Equals(string.Empty)) currPlaylist.name = "[無法取得此播放清單名稱]";

                    currPlaylist.setProcessing2();

                    // 2. get videos in playlist
                    int vIdx = 0;
                    cmdsi.Arguments = ytdlParam2;
                    Process process2 = Process.Start(cmdsi);
                    process2.OutputDataReceived +=
                        (o, e) =>
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                                VideoEntity ve = new VideoEntity();
                                ve.name = e.Data;
                                ve.cookiePath = currPlaylist.cookiePath;
                                ve.url = "''" + currPlaylist.url + "'' --playlist-items " + (++vIdx);
                                ve.playlistName = currPlaylist.name;
                                ve.progress = "等待中";

                                lock (parentForm.lockVideosObj) { parentForm.videos.Add(ve); }
                            }
                        };
                    process2.BeginOutputReadLine();
                    process2.WaitForExit();

                    // process done.
                    currPlaylist.setDone();
                }

                // if nothing to do, sleep 1 sec.
                Thread.Sleep(1000);
            }
        }
    }
}

//// Delegation for parentForm call back
//public delegate void updateVideoListDelegate(VideoEntity ve);
//public delegate void updatePlaylistDelegate(PlaylistEntity pe);
//
//// Delegation for parentForm call back
//public void updateVideoList(VideoEntity ve) { parentForm.videos.Add(ve); }
//public void updatePlaylist(PlaylistEntity pe) { parentForm.playlists.Add(pe); }

// 用 delegate 解決不同 thread 不能呼叫 form.control 的問題.
//updatePlaylistDelegate delegater = new updatePlaylistDelegate(updatePlaylist);
//parentForm.BeginInvoke(delegater, new Object[] { pe });

// 用 delegate 解決不同 thread 不能呼叫 form.control 的問題.
//updateVideoListDelegate delegater = new updateVideoListDelegate(updateVideoList);
//parentForm.BeginInvoke(delegater, new Object[] { ve });
