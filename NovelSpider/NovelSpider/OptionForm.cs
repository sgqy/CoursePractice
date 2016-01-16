using System;
using System.Windows.Forms;

namespace NovelSpider
{
    /// <summary>
    /// "选项"的界面及其相关方法
    /// </summary>
    public partial class OptionForm : Form
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public OptionForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            (Owner as MainForm).ProgramConfig.config.ReaderStyle.FontSize = textBoxFontSize.Text;
            (Owner as MainForm).ProgramConfig.config.ReaderStyle.FontFace = textBoxFontFace.Text;
            (Owner as MainForm).ProgramConfig.config.ReaderStyle.BackgroundColor = textBoxBackgroundColor.Text;
            (Owner as MainForm).ProgramConfig.config.ReaderStyle.ForgroundColor = textBoxForgroundColor.Text;

            (Owner as MainForm).ProgramConfig.config.NetConn.Retry = (int)numericUpDownRetry.Value;
            (Owner as MainForm).ProgramConfig.config.NetConn.Timeout = (int)numericUpDownTimeout.Value;
        }

        private void OptionForm_Load(object sender, EventArgs e)
        {
            textBoxFontSize.Text = (Owner as MainForm).ProgramConfig.config.ReaderStyle.FontSize;
            textBoxFontFace.Text = (Owner as MainForm).ProgramConfig.config.ReaderStyle.FontFace;
            textBoxBackgroundColor.Text = (Owner as MainForm).ProgramConfig.config.ReaderStyle.BackgroundColor;
            textBoxForgroundColor.Text = (Owner as MainForm).ProgramConfig.config.ReaderStyle.ForgroundColor;

            numericUpDownRetry.Value = (Owner as MainForm).ProgramConfig.config.NetConn.Retry;
            numericUpDownTimeout.Value = (Owner as MainForm).ProgramConfig.config.NetConn.Timeout;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var domain = textBoxDomain.Text;
            var info = new Configuration.SiteInfo();
            info.Chapter.Handle = textBoxChapterHandle.Text;
            info.Chapter.Link = textBoxChapterLink.Text;
            info.Chapter.Name = textBoxChapterTitle.Text;
            info.HeadPage.Author = textBoxAuthor.Text;
            info.HeadPage.Genre = textBoxGenre.Text;
            info.HeadPage.Redirect.Pattern = textBoxPattern.Text;
            info.HeadPage.Redirect.Replacement = textBoxReplacement.Text;
            info.HeadPage.SubGenre = textBoxSubGenre.Text;
            switch (textBoxSynopLoc.Text.ToLower())
            {
                case "catalog":
                    info.HeadPage.SynopLoc = Configuration.SiteInfo._HeadPage.S_Loc.Catalog;
                    break;

                case "cover":
                    info.HeadPage.SynopLoc = Configuration.SiteInfo._HeadPage.S_Loc.Cover;
                    break;

                default:
                    info.HeadPage.SynopLoc = Configuration.SiteInfo._HeadPage.S_Loc.Null;
                    break;
            }
            info.HeadPage.Synopsis = textBoxSynopsis.Text;
            info.HeadPage.Title = textBoxTitle.Text;
            info.TextPage.Body = textBoxTextBody.Text;
            info.TextPage.Handle = textBoxTextHandle.Text;
            info.TextPage.Name = textBoxTextTitle.Text;
            info.Volume.Handle = textBoxVolumeHandle.Text;
            info.Volume.Name = textBoxVolumeTitle.Text;
            switch (textBoxVolumeType.Text.ToLower())
            {
                case "fold":
                    info.Volume.Type = Configuration.SiteInfo._Volume._Type.Fold;
                    break;

                case "plat":
                    info.Volume.Type = Configuration.SiteInfo._Volume._Type.Plat;
                    break;

                default:
                    info.Volume.Type = Configuration.SiteInfo._Volume._Type.Null;
                    break;
            }
            try { (Owner as MainForm).ProgramConfig.config.SiteDefines.Add(domain, info); }
            catch { (Owner as MainForm).ProgramConfig.config.SiteDefines[domain] = info; }
        }
    }
}