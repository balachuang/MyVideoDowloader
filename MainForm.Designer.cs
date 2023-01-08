namespace MyVideoDowloader
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListVw_Videos = new System.Windows.Forms.ListView();
            this.vcol1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vcol2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vcol3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vcol4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabCtl_Main = new System.Windows.Forms.TabControl();
            this.TbPg_Browse = new System.Windows.Forms.TabPage();
            this.Btn_SupportList = new System.Windows.Forms.Button();
            this.Pnl_BrowserContainer = new System.Windows.Forms.Panel();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.TxtBox_Url = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComBox_WebSites = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbPg_Dowload = new System.Windows.Forms.TabPage();
            this.ListVw_Playlists = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TbPg_Config = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Lbl_Alart = new System.Windows.Forms.Label();
            this.ComBox_ThreadCount = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtBox_CustFormat = new System.Windows.Forms.TextBox();
            this.ChkBox_UseCustFormat = new System.Windows.Forms.CheckBox();
            this.ChkBox_SkipWatchLaterSubFolder = new System.Windows.Forms.CheckBox();
            this.ChkBox_CreateSubFolder = new System.Windows.Forms.CheckBox();
            this.TxtBox_DownloadPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtBox_YtdlPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtBox_SiteCompareString = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Btn_AddNewSite = new System.Windows.Forms.Button();
            this.TxtBox_SiteCookiePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtBox_SiteUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBox_SiteName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ComBox_WebSitesConfig = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TabCtl_Main.SuspendLayout();
            this.TbPg_Browse.SuspendLayout();
            this.TbPg_Dowload.SuspendLayout();
            this.TbPg_Config.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListVw_Videos
            // 
            this.ListVw_Videos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListVw_Videos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vcol1,
            this.vcol2,
            this.vcol3,
            this.vcol4});
            this.ListVw_Videos.FullRowSelect = true;
            this.ListVw_Videos.GridLines = true;
            this.ListVw_Videos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListVw_Videos.HideSelection = false;
            this.ListVw_Videos.Location = new System.Drawing.Point(12, 155);
            this.ListVw_Videos.MultiSelect = false;
            this.ListVw_Videos.Name = "ListVw_Videos";
            this.ListVw_Videos.Size = new System.Drawing.Size(956, 298);
            this.ListVw_Videos.TabIndex = 3;
            this.ListVw_Videos.UseCompatibleStateImageBehavior = false;
            this.ListVw_Videos.View = System.Windows.Forms.View.Details;
            // 
            // vcol1
            // 
            this.vcol1.Text = "來源";
            this.vcol1.Width = 200;
            // 
            // vcol2
            // 
            this.vcol2.Text = "影片名稱或網址";
            this.vcol2.Width = 500;
            // 
            // vcol3
            // 
            this.vcol3.Text = "大小";
            this.vcol3.Width = 100;
            // 
            // vcol4
            // 
            this.vcol4.Text = "進度";
            this.vcol4.Width = 80;
            // 
            // TabCtl_Main
            // 
            this.TabCtl_Main.Controls.Add(this.TbPg_Browse);
            this.TabCtl_Main.Controls.Add(this.TbPg_Dowload);
            this.TabCtl_Main.Controls.Add(this.TbPg_Config);
            this.TabCtl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabCtl_Main.Name = "TabCtl_Main";
            this.TabCtl_Main.SelectedIndex = 0;
            this.TabCtl_Main.Size = new System.Drawing.Size(984, 491);
            this.TabCtl_Main.TabIndex = 0;
            this.TabCtl_Main.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TbPg_Browse
            // 
            this.TbPg_Browse.Controls.Add(this.Btn_SupportList);
            this.TbPg_Browse.Controls.Add(this.Pnl_BrowserContainer);
            this.TbPg_Browse.Controls.Add(this.Btn_Download);
            this.TbPg_Browse.Controls.Add(this.TxtBox_Url);
            this.TbPg_Browse.Controls.Add(this.label2);
            this.TbPg_Browse.Controls.Add(this.ComBox_WebSites);
            this.TbPg_Browse.Controls.Add(this.label1);
            this.TbPg_Browse.Location = new System.Drawing.Point(4, 28);
            this.TbPg_Browse.Name = "TbPg_Browse";
            this.TbPg_Browse.Padding = new System.Windows.Forms.Padding(3);
            this.TbPg_Browse.Size = new System.Drawing.Size(976, 459);
            this.TbPg_Browse.TabIndex = 0;
            this.TbPg_Browse.Text = "瀏覽頁";
            this.TbPg_Browse.UseVisualStyleBackColor = true;
            // 
            // Btn_SupportList
            // 
            this.Btn_SupportList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_SupportList.Location = new System.Drawing.Point(850, 11);
            this.Btn_SupportList.Name = "Btn_SupportList";
            this.Btn_SupportList.Size = new System.Drawing.Size(118, 27);
            this.Btn_SupportList.TabIndex = 6;
            this.Btn_SupportList.Text = "支援網站列表";
            this.Btn_SupportList.UseVisualStyleBackColor = true;
            this.Btn_SupportList.Click += new System.EventHandler(this.Btn_SupportList_Click);
            // 
            // Pnl_BrowserContainer
            // 
            this.Pnl_BrowserContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pnl_BrowserContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_BrowserContainer.Location = new System.Drawing.Point(12, 48);
            this.Pnl_BrowserContainer.Name = "Pnl_BrowserContainer";
            this.Pnl_BrowserContainer.Size = new System.Drawing.Size(956, 403);
            this.Pnl_BrowserContainer.TabIndex = 5;
            // 
            // Btn_Download
            // 
            this.Btn_Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Download.Location = new System.Drawing.Point(713, 11);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(121, 27);
            this.Btn_Download.TabIndex = 4;
            this.Btn_Download.Text = "下載目前頁面";
            this.Btn_Download.UseVisualStyleBackColor = true;
            this.Btn_Download.Click += new System.EventHandler(this.Btn_Download_Click);
            // 
            // TxtBox_Url
            // 
            this.TxtBox_Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_Url.Location = new System.Drawing.Point(386, 11);
            this.TxtBox_Url.Name = "TxtBox_Url";
            this.TxtBox_Url.Size = new System.Drawing.Size(321, 27);
            this.TxtBox_Url.TabIndex = 3;
            this.TxtBox_Url.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBox_Url_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "網址：";
            // 
            // ComBox_WebSites
            // 
            this.ComBox_WebSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBox_WebSites.FormattingEnabled = true;
            this.ComBox_WebSites.Location = new System.Drawing.Point(98, 11);
            this.ComBox_WebSites.Name = "ComBox_WebSites";
            this.ComBox_WebSites.Size = new System.Drawing.Size(212, 27);
            this.ComBox_WebSites.TabIndex = 1;
            this.ComBox_WebSites.SelectedIndexChanged += new System.EventHandler(this.ComBox_WebSites_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "預設網站：";
            // 
            // TbPg_Dowload
            // 
            this.TbPg_Dowload.Controls.Add(this.ListVw_Videos);
            this.TbPg_Dowload.Controls.Add(this.ListVw_Playlists);
            this.TbPg_Dowload.Controls.Add(this.label4);
            this.TbPg_Dowload.Controls.Add(this.label3);
            this.TbPg_Dowload.Location = new System.Drawing.Point(4, 28);
            this.TbPg_Dowload.Name = "TbPg_Dowload";
            this.TbPg_Dowload.Padding = new System.Windows.Forms.Padding(3);
            this.TbPg_Dowload.Size = new System.Drawing.Size(976, 459);
            this.TbPg_Dowload.TabIndex = 1;
            this.TbPg_Dowload.Text = "下載頁";
            this.TbPg_Dowload.UseVisualStyleBackColor = true;
            // 
            // ListVw_Playlists
            // 
            this.ListVw_Playlists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListVw_Playlists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4});
            this.ListVw_Playlists.FullRowSelect = true;
            this.ListVw_Playlists.GridLines = true;
            this.ListVw_Playlists.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListVw_Playlists.HideSelection = false;
            this.ListVw_Playlists.Location = new System.Drawing.Point(12, 32);
            this.ListVw_Playlists.MultiSelect = false;
            this.ListVw_Playlists.Name = "ListVw_Playlists";
            this.ListVw_Playlists.Size = new System.Drawing.Size(956, 93);
            this.ListVw_Playlists.TabIndex = 2;
            this.ListVw_Playlists.UseCompatibleStateImageBehavior = false;
            this.ListVw_Playlists.View = System.Windows.Forms.View.Details;
            // 
            // col1
            // 
            this.col1.Text = "#";
            this.col1.Width = 50;
            // 
            // col2
            // 
            this.col2.Text = "名稱";
            this.col2.Width = 200;
            // 
            // col3
            // 
            this.col3.Text = "網址";
            this.col3.Width = 300;
            // 
            // col4
            // 
            this.col4.Text = "進度";
            this.col4.Width = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "影片列表：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "播放清單 (Playlist) 列表：";
            // 
            // TbPg_Config
            // 
            this.TbPg_Config.Controls.Add(this.groupBox2);
            this.TbPg_Config.Controls.Add(this.groupBox1);
            this.TbPg_Config.Location = new System.Drawing.Point(4, 28);
            this.TbPg_Config.Name = "TbPg_Config";
            this.TbPg_Config.Size = new System.Drawing.Size(976, 459);
            this.TbPg_Config.TabIndex = 2;
            this.TbPg_Config.Text = "設定頁";
            this.TbPg_Config.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Lbl_Alart);
            this.groupBox2.Controls.Add(this.ComBox_ThreadCount);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TxtBox_CustFormat);
            this.groupBox2.Controls.Add(this.ChkBox_UseCustFormat);
            this.groupBox2.Controls.Add(this.ChkBox_SkipWatchLaterSubFolder);
            this.groupBox2.Controls.Add(this.ChkBox_CreateSubFolder);
            this.groupBox2.Controls.Add(this.TxtBox_DownloadPath);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtBox_YtdlPath);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(8, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 228);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "下載設定";
            // 
            // Lbl_Alart
            // 
            this.Lbl_Alart.AutoSize = true;
            this.Lbl_Alart.ForeColor = System.Drawing.Color.Blue;
            this.Lbl_Alart.Location = new System.Drawing.Point(355, 192);
            this.Lbl_Alart.Name = "Lbl_Alart";
            this.Lbl_Alart.Size = new System.Drawing.Size(351, 19);
            this.Lbl_Alart.TabIndex = 18;
            this.Lbl_Alart.Text = "注意 !!! 這個新設定將在下次程式執行時才會生效 !!!";
            this.Lbl_Alart.Visible = false;
            // 
            // ComBox_ThreadCount
            // 
            this.ComBox_ThreadCount.FormattingEnabled = true;
            this.ComBox_ThreadCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "5",
            "10",
            "20",
            "30"});
            this.ComBox_ThreadCount.Location = new System.Drawing.Point(174, 189);
            this.ComBox_ThreadCount.Name = "ComBox_ThreadCount";
            this.ComBox_ThreadCount.Size = new System.Drawing.Size(164, 27);
            this.ComBox_ThreadCount.TabIndex = 9;
            this.ComBox_ThreadCount.SelectedIndexChanged += new System.EventHandler(this.ComBox_ThreadCount_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "同時下載的影片數：";
            // 
            // TxtBox_CustFormat
            // 
            this.TxtBox_CustFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_CustFormat.Location = new System.Drawing.Point(449, 148);
            this.TxtBox_CustFormat.Name = "TxtBox_CustFormat";
            this.TxtBox_CustFormat.Size = new System.Drawing.Size(505, 27);
            this.TxtBox_CustFormat.TabIndex = 16;
            // 
            // ChkBox_UseCustFormat
            // 
            this.ChkBox_UseCustFormat.AutoSize = true;
            this.ChkBox_UseCustFormat.Location = new System.Drawing.Point(174, 150);
            this.ChkBox_UseCustFormat.Name = "ChkBox_UseCustFormat";
            this.ChkBox_UseCustFormat.Size = new System.Drawing.Size(269, 23);
            this.ChkBox_UseCustFormat.TabIndex = 15;
            this.ChkBox_UseCustFormat.Text = "(Youtube 專用) 使用自訂格式下載：";
            this.ChkBox_UseCustFormat.UseVisualStyleBackColor = true;
            // 
            // ChkBox_SkipWatchLaterSubFolder
            // 
            this.ChkBox_SkipWatchLaterSubFolder.AutoSize = true;
            this.ChkBox_SkipWatchLaterSubFolder.Location = new System.Drawing.Point(174, 121);
            this.ChkBox_SkipWatchLaterSubFolder.Name = "ChkBox_SkipWatchLaterSubFolder";
            this.ChkBox_SkipWatchLaterSubFolder.Size = new System.Drawing.Size(384, 23);
            this.ChkBox_SkipWatchLaterSubFolder.TabIndex = 14;
            this.ChkBox_SkipWatchLaterSubFolder.Text = "(Youtube 專用) 下載 [稍後觀看] 時, 不另外建立子目錄";
            this.ChkBox_SkipWatchLaterSubFolder.UseVisualStyleBackColor = true;
            // 
            // ChkBox_CreateSubFolder
            // 
            this.ChkBox_CreateSubFolder.AutoSize = true;
            this.ChkBox_CreateSubFolder.Location = new System.Drawing.Point(174, 92);
            this.ChkBox_CreateSubFolder.Name = "ChkBox_CreateSubFolder";
            this.ChkBox_CreateSubFolder.Size = new System.Drawing.Size(585, 23);
            this.ChkBox_CreateSubFolder.TabIndex = 13;
            this.ChkBox_CreateSubFolder.Text = "(Youtube 專用) 下載 Playlist 時, 用 Playlist 名稱建立子目錄並將影片下載到子目錄中";
            this.ChkBox_CreateSubFolder.UseVisualStyleBackColor = true;
            // 
            // TxtBox_DownloadPath
            // 
            this.TxtBox_DownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_DownloadPath.Location = new System.Drawing.Point(174, 59);
            this.TxtBox_DownloadPath.Name = "TxtBox_DownloadPath";
            this.TxtBox_DownloadPath.Size = new System.Drawing.Size(780, 27);
            this.TxtBox_DownloadPath.TabIndex = 12;
            this.TxtBox_DownloadPath.TextChanged += new System.EventHandler(this.TxtBox_DownloadPath_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(84, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 19);
            this.label10.TabIndex = 11;
            this.label10.Text = "下載位置：";
            // 
            // TxtBox_YtdlPath
            // 
            this.TxtBox_YtdlPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_YtdlPath.Location = new System.Drawing.Point(174, 26);
            this.TxtBox_YtdlPath.Name = "TxtBox_YtdlPath";
            this.TxtBox_YtdlPath.Size = new System.Drawing.Size(780, 27);
            this.TxtBox_YtdlPath.TabIndex = 10;
            this.TxtBox_YtdlPath.TextChanged += new System.EventHandler(this.TxtBox_YtdlPath_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "youtube_dl.exe 位置：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TxtBox_SiteCompareString);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.Btn_AddNewSite);
            this.groupBox1.Controls.Add(this.TxtBox_SiteCookiePath);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtBox_SiteUrl);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtBox_SiteName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ComBox_WebSitesConfig);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "來源網站設定";
            // 
            // TxtBox_SiteCompareString
            // 
            this.TxtBox_SiteCompareString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_SiteCompareString.Location = new System.Drawing.Point(171, 133);
            this.TxtBox_SiteCompareString.Name = "TxtBox_SiteCompareString";
            this.TxtBox_SiteCompareString.Size = new System.Drawing.Size(783, 27);
            this.TxtBox_SiteCompareString.TabIndex = 10;
            this.TxtBox_SiteCompareString.TextChanged += new System.EventHandler(this.TxtBox_SiteCompareString_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 19);
            this.label12.TabIndex = 9;
            this.label12.Text = "本站識別字串：";
            // 
            // Btn_AddNewSite
            // 
            this.Btn_AddNewSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_AddNewSite.Location = new System.Drawing.Point(873, 27);
            this.Btn_AddNewSite.Name = "Btn_AddNewSite";
            this.Btn_AddNewSite.Size = new System.Drawing.Size(81, 27);
            this.Btn_AddNewSite.TabIndex = 8;
            this.Btn_AddNewSite.Text = "新增";
            this.Btn_AddNewSite.UseVisualStyleBackColor = true;
            this.Btn_AddNewSite.Click += new System.EventHandler(this.Btn_AddNewSite_Click);
            // 
            // TxtBox_SiteCookiePath
            // 
            this.TxtBox_SiteCookiePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_SiteCookiePath.Location = new System.Drawing.Point(163, 166);
            this.TxtBox_SiteCookiePath.Name = "TxtBox_SiteCookiePath";
            this.TxtBox_SiteCookiePath.Size = new System.Drawing.Size(791, 27);
            this.TxtBox_SiteCookiePath.TabIndex = 7;
            this.TxtBox_SiteCookiePath.TextChanged += new System.EventHandler(this.TxtBox_SiteCookiePath_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Cookie 檔位置：";
            // 
            // TxtBox_SiteUrl
            // 
            this.TxtBox_SiteUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_SiteUrl.Location = new System.Drawing.Point(96, 100);
            this.TxtBox_SiteUrl.Name = "TxtBox_SiteUrl";
            this.TxtBox_SiteUrl.Size = new System.Drawing.Size(858, 27);
            this.TxtBox_SiteUrl.TabIndex = 5;
            this.TxtBox_SiteUrl.TextChanged += new System.EventHandler(this.TxtBox_SiteUrl_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "網址：";
            // 
            // TxtBox_SiteName
            // 
            this.TxtBox_SiteName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBox_SiteName.Location = new System.Drawing.Point(96, 67);
            this.TxtBox_SiteName.Name = "TxtBox_SiteName";
            this.TxtBox_SiteName.ReadOnly = true;
            this.TxtBox_SiteName.Size = new System.Drawing.Size(858, 27);
            this.TxtBox_SiteName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "名稱：";
            // 
            // ComBox_WebSitesConfig
            // 
            this.ComBox_WebSitesConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComBox_WebSitesConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBox_WebSitesConfig.FormattingEnabled = true;
            this.ComBox_WebSitesConfig.Location = new System.Drawing.Point(96, 27);
            this.ComBox_WebSitesConfig.Name = "ComBox_WebSitesConfig";
            this.ComBox_WebSitesConfig.Size = new System.Drawing.Size(771, 27);
            this.ComBox_WebSitesConfig.TabIndex = 1;
            this.ComBox_WebSitesConfig.SelectedIndexChanged += new System.EventHandler(this.ComBox_WebSitesConfig_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "選擇網站：";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 491);
            this.Controls.Add(this.TabCtl_Main);
            this.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1000, 530);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyVideoDownloader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabCtl_Main.ResumeLayout(false);
            this.TbPg_Browse.ResumeLayout(false);
            this.TbPg_Browse.PerformLayout();
            this.TbPg_Dowload.ResumeLayout(false);
            this.TbPg_Dowload.PerformLayout();
            this.TbPg_Config.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabCtl_Main;
        private System.Windows.Forms.TabPage TbPg_Browse;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage TbPg_Dowload;
        private System.Windows.Forms.TabPage TbPg_Config;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Btn_AddNewSite;
        protected internal System.Windows.Forms.ComboBox ComBox_WebSitesConfig;
        protected internal System.Windows.Forms.TextBox TxtBox_SiteCookiePath;
        protected internal System.Windows.Forms.TextBox TxtBox_SiteUrl;
        protected internal System.Windows.Forms.TextBox TxtBox_SiteName;
        protected internal System.Windows.Forms.CheckBox ChkBox_CreateSubFolder;
        protected internal System.Windows.Forms.TextBox TxtBox_DownloadPath;
        protected internal System.Windows.Forms.TextBox TxtBox_YtdlPath;
        protected internal System.Windows.Forms.ComboBox ComBox_ThreadCount;
        protected internal System.Windows.Forms.TextBox TxtBox_CustFormat;
        protected internal System.Windows.Forms.CheckBox ChkBox_UseCustFormat;
        protected internal System.Windows.Forms.CheckBox ChkBox_SkipWatchLaterSubFolder;
        private System.Windows.Forms.Button Btn_SupportList;
        protected internal System.Windows.Forms.ComboBox ComBox_WebSites;
        protected internal System.Windows.Forms.Panel Pnl_BrowserContainer;
        protected internal System.Windows.Forms.TextBox TxtBox_Url;
        protected internal System.Windows.Forms.ListView ListVw_Playlists;
        private System.Windows.Forms.Label Lbl_Alart;
        protected internal System.Windows.Forms.ListView ListVw_Videos;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ColumnHeader vcol2;
        private System.Windows.Forms.ColumnHeader vcol1;
        private System.Windows.Forms.ColumnHeader vcol3;
        private System.Windows.Forms.ColumnHeader vcol4;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.ColumnHeader col2;
        protected internal System.Windows.Forms.TextBox TxtBox_SiteCompareString;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader col4;
    }
}

