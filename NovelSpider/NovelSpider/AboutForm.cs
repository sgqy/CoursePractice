using System;
using System.Windows.Forms;

namespace NovelSpider
{
    /// <summary>
    /// "关于"界面及其相关操作
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 对窗口内标签的点击事件. 点击后自动关闭这个窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}