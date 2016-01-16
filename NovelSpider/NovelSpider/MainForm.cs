using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelSpider
{
    /// <summary>
    /// 程序主界面与相关操作
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 程序的全局配置信息
        /// </summary>
        public IConfig ProgramConfig { get; set; }
        /// <summary>
        /// 配置文件的保存地址
        /// </summary>
        string ConfigFilePath { get; set; }
        /// <summary>
        /// 保存文章的路径, 现时使用程序路径
        /// </summary>
        public string NovelStoreDir { get; set; }
        /// <summary>
        /// 主界面的构造方法
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ProgramConfig = new ConfigToJSON();

            var curExe = Assembly.GetExecutingAssembly().Location;
            var curDir = Path.GetDirectoryName(curExe);
            var curFn = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);

            NovelStoreDir = Path.Combine(curDir, "NovelStore");
            ConfigFilePath = Path.Combine(curDir, curFn) + ".json";
        }

        /// <summary>
        /// 控件初始化完成后的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try { ProgramConfig.Load(ConfigFilePath); } catch { StatusBarText = "配置文件加载失败"; }
            Directory.CreateDirectory(NovelStoreDir);
            new Thread(BackgroundStateUpdateAsync).Start();

            UpdateTreeView();

            // 继续上一次 | issue: 在窗口加载时 WebBrowser 不会显示内容
            //if (!string.IsNullOrEmpty(ProgramConfig.config.LastRead.BookPath))
            //    ShowChapter(ProgramConfig.config.LastRead.BookPath);
            // select treeView is not implemented            
        }

        /// <summary>
        /// 程序退出时的处理过程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { ProgramConfig.Save(ConfigFilePath); } catch { MessageBox.Show("配置文件保存失败"); }
        }

        #region 程序的状态显示
        string StatusBarText = "就绪";
        int StatusProgressBarVal = 0;
        enum _StatusCurr
        {
            Null,
            Downloading,
            Reading,
        }
        _StatusCurr StatusCurrent = _StatusCurr.Null;
        /// <summary>
        /// 为章节提供样式
        /// </summary>
        string ChapterCSS = "<!-- Not Implemented CSS -->";
        /// <summary>
        /// 使用异步的方式对程序的各种状态定时显示在界面上
        /// </summary>
        void BackgroundStateUpdateAsync()
        {
            try
            {
                Thread.Sleep(500); // 等待界面显示完整

                while (true)
                {
                    // 更新进度条的模式以区别当前状态
                    switch (StatusCurrent)
                    {
                        case _StatusCurr.Downloading:
                            Invoke(new Action(() => progressBar.Style = ProgressBarStyle.Marquee));
                            break;
                        case _StatusCurr.Null:
                        case _StatusCurr.Reading:
                        default:
                            Invoke(new Action(() => progressBar.Style = ProgressBarStyle.Continuous));
                            break;
                    }
                    // 更新进度条的值
                    Invoke(new Action(() =>
                    {
                        var max = progressBar.Maximum;
                        if (StatusProgressBarVal > max)
                            progressBar.Value = max;
                        else
                            progressBar.Value = StatusProgressBarVal;
                    }));
                    // 更新状态栏的文字
                    Invoke(new Action(() =>
                    {
                        textBoxStatus.Text = StatusBarText;
                    }));
                    Thread.Sleep(1000);
                }
            }
            catch { }
        }

        #endregion


        /// <summary>
        /// 开始下载例程
        /// </summary>
        public void DownloadNovel(Uri uri)
        {
            if (StatusCurrent == _StatusCurr.Downloading) return; // 防止下载线程多开
            new Thread(() => DownloadNovelAsync(uri)).Start();
        }

        void DownloadNovelAsync(Uri uri)
        {
            try
            {
                StatusCurrent = _StatusCurr.Downloading;
                StatusBarText = "正在下载: " + uri.AbsoluteUri;

                var downloader = new Downloader(ProgramConfig, x => StatusBarText = x);
                var book = downloader.Start(uri, NovelStoreDir);
                if (book.Value == null) { StatusBarText = "下载失败"; return; }
                // 在外部添加可以在下载时修改设置. 局部修改保证安全性
                ProgramConfig.config.Storage.BookShelf.Add(book.Key, book.Value);

                Invoke(new Action(() => UpdateTreeView()));
                StatusBarText = "就绪";
            }
            catch { }
            finally { StatusCurrent = _StatusCurr.Reading; }
        }
        /// <summary>
        /// 更新章节列表
        /// </summary>
        void UpdateTreeView()
        {
            treeViewChapter.Nodes.Clear();
            var tvnl = new List<TreeNode>();
            foreach (var book in ProgramConfig.config.Storage.BookShelf)
            {
                var tnl = new List<TreeNode>();
                foreach (var ch in book.Value.Chapters)
                { tnl.Add(new TreeNode(ch.Value)); }
                tvnl.Add(new TreeNode(book.Value.Title, tnl.ToArray()));
            }
            treeViewChapter.Nodes.AddRange(tvnl.ToArray());
        }
        /// <summary>
        /// 显示章节内容
        /// </summary>
        void ShowChapter()
        {
            ShowChapter(treeViewChapter.SelectedNode.FullPath);
        }

        void ShowChapter(string path)
        {
            try
            {                
                if (!path.EndsWith(".txt")) path = Path.Combine(path, "0.txt"); // 双击根目录则显示首页
                var realpath = Path.Combine(NovelStoreDir, path);
                var sr = new StreamReader(realpath, Encoding.UTF8, true);
                var content = sr.ReadToEnd();
                BrowserContent.DocumentText = "<html><body>"+content+"</body></html>";
                sr.Dispose();
                ProgramConfig.config.LastRead.BookPath = path;
            }
            catch { StatusBarText = "章节加载失败"; }
        }
        /// <summary>
        /// 对"关于"的单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StripAbout_Click(object sender, EventArgs e)
        {
            new AboutForm().Show(this);
        }
        /// <summary>
        /// 对"选项"的单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StripOption_Click(object sender, EventArgs e)
        {
            new OptionForm().Show(this);
        }
        /// <summary>
        /// 对"本地"的单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StripLocal_Click(object sender, EventArgs e)
        {
            new LocalForm().Show(this);
        }
        /// <summary>
        /// 对"下载"的单击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StripDownload_Click(object sender, EventArgs e)
        {
            new DownloadForm().Show(this);
        }
        /// <summary>
        /// 在章节列表中双击鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewChapter_DoubleClick(object sender, EventArgs e)
        {
            ShowChapter();
        }
        /// <summary>
        /// 在章节列表中按下回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewChapter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { ShowChapter(); }
        }
    }
}
