using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyVideoDowloader
{
    internal class ListViewRenderer
    {
        private MainForm parentForm = null;
        private Dictionary<string, Color> statusBkColorTable = new Dictionary<string, Color>();
        private Dictionary<string, Color> statusTxColorTable = new Dictionary<string, Color>();

        public ListViewRenderer(MainForm _form)
        {
            parentForm = _form;

            // background color for playlist_listview
            statusBkColorTable.Add("取得播放清單名稱中", Color.LightYellow);
            statusBkColorTable.Add("取得影片列表中", Color.LightYellow);
            statusBkColorTable.Add("完成", Color.White);

            // background color for video_listview
            statusBkColorTable.Add("100%", Color.White);

            // background color for playlist_listview
            statusTxColorTable.Add("取得播放清單名稱中", Color.Black);
            statusTxColorTable.Add("取得影片列表中", Color.Black);
            statusTxColorTable.Add("完成", Color.DarkGray);

            // background color for video_listview
            statusTxColorTable.Add("100%", Color.DarkGray);
        }

        public void updateListView(List<PlaylistEntity> _playlists, List<VideoEntity> _videos)
        {
            // 1. update LstView_Playlist
            updateListView_Playlist(_playlists);

            // 2. update LstView_Playlist
            updateListView_Video(_videos);
        }

        private void updateListView_Playlist(List<PlaylistEntity> _playlists)
        {
            // update item text
            for (int n = 0; n < _playlists.Count; ++n)
            {
                if (n < parentForm.ListVw_Playlists.Items.Count)
                {
                    // update current item in list
                    ListViewItem thisItem = parentForm.ListVw_Playlists.Items[n];
                    System.Windows.Forms.ListView.ColumnHeaderCollection thisCol = parentForm.ListVw_Playlists.Columns;
                    updateListViewItem(thisItem.SubItems[0], thisCol[0], n.ToString());
                    updateListViewItem(thisItem.SubItems[1], thisCol[1], _playlists[n].name);
                    updateListViewItem(thisItem.SubItems[2], thisCol[2], _playlists[n].url);
                    updateListViewItem(thisItem.SubItems[3], thisCol[3], _playlists[n].status);
                }
                else
                {
                    // add new items
                    parentForm.ListVw_Playlists.Items.Add(new ListViewItem(_playlists[n].toSubItemInput(n)));
                    foreach (ColumnHeader clhr in parentForm.ListVw_Playlists.Columns) clhr.Width = -1;
                }
            }
            if (parentForm.ListVw_Playlists.Items.Count > _playlists.Count)
            {
                for (int n = parentForm.ListVw_Playlists.Items.Count - 1; n >= _playlists.Count; --n)
                {
                    parentForm.ListVw_Playlists.Items.RemoveAt(n);
                }
            }

            // set color by status
            foreach (ListViewItem lvi in parentForm.ListVw_Playlists.Items)
            {
                string thisStatus = lvi.SubItems[3].Text;
                if (statusBkColorTable.ContainsKey(thisStatus)) lvi.BackColor = statusBkColorTable[thisStatus];
                if (statusTxColorTable.ContainsKey(thisStatus)) lvi.ForeColor = statusTxColorTable[thisStatus];
            }
        }

        private void updateListView_Video(List<VideoEntity> _videos)
        {
            // update item text
            for (int n = 0; n < _videos.Count; ++n)
            {
                if (n < parentForm.ListVw_Videos.Items.Count)
                {
                    ListViewItem thisItem = parentForm.ListVw_Videos.Items[n];
                    System.Windows.Forms.ListView.ColumnHeaderCollection thisCol = parentForm.ListVw_Videos.Columns;
                    updateListViewItem(thisItem.SubItems[0], thisCol[0], _videos[n].sourceSiteName);
                    updateListViewItem(thisItem.SubItems[1], thisCol[1], _videos[n].name.Equals(string.Empty) ? _videos[n].url : _videos[n].name);
                    updateListViewItem(thisItem.SubItems[2], thisCol[2], _videos[n].size);
                    updateListViewItem(thisItem.SubItems[3], thisCol[3], _videos[n].progress);
                }
                else
                {
                    // add new items
                    parentForm.ListVw_Videos.Items.Add(new ListViewItem(_videos[n].toSubItemInput()));
                    foreach (ColumnHeader clhr in parentForm.ListVw_Videos.Columns) clhr.Width = -1;
                }
            }
            if (parentForm.ListVw_Videos.Items.Count > _videos.Count)
            {
                for (int n = parentForm.ListVw_Videos.Items.Count - 1; n >= _videos.Count; --n)
                {
                    parentForm.ListVw_Videos.Items.RemoveAt(n);
                }
            }

            // set color by status
            foreach (ListViewItem lvi in parentForm.ListVw_Videos.Items)
            {
                string thisStatus = lvi.SubItems[3].Text;
                if (statusBkColorTable.ContainsKey(thisStatus)) lvi.BackColor = statusBkColorTable[thisStatus];
                else if (thisStatus.Contains("%")) lvi.BackColor = Color.LightYellow;
                else if (thisStatus.StartsWith("[Error]")) lvi.BackColor = Color.Red;

                if (statusTxColorTable.ContainsKey(thisStatus)) lvi.ForeColor = statusTxColorTable[thisStatus];
                else if (thisStatus.Contains("%")) lvi.ForeColor = Color.Black;
                else if (thisStatus.StartsWith("[Error]")) lvi.ForeColor = Color.White;
            }
        }

        private void updateListViewItem(ListViewItem.ListViewSubItem lvsi, ColumnHeader clhr, string value)
        {
            if (!lvsi.Text.Equals(value))
            {
                lvsi.Text = value;
                clhr.Width = -1;
            }
        }
    }
}
