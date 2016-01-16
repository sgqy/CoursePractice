using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelSpider
{
    /// <summary>
    /// "下载"界面及其相关方法
    /// </summary>
    public partial class DownloadForm : Form
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public DownloadForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try { (Owner as MainForm).DownloadNovel(new Uri(textBoxLink.Text)); }
            catch { return; }

            Close();
        }
    }
}
