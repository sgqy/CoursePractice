using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace NovelSpider
{
    class Downloader
    {
        /// <summary>
        /// 定义信息输出, 可用于 Console 和 TextBox 等
        /// </summary>
        /// <param name="info">要打印的信息</param>
        public delegate void InfoOutput(string info);

        private InfoOutput print;
        IConfig cfg { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="config">传入主程序的配置信息</param>
        /// <param name="info">传入用于打印信息的方法</param>
        public Downloader(IConfig config, InfoOutput info = null)
        {
            if (info == null) { this.print = (x => { }); } // set output servant
            else { this.print = info; }
            cfg = config;
        }

        private HtmlDocument GetDocument(Uri uri)
        {
            print("获取   : " + uri);
            var web = new HtmlWeb();
            // 设置内部 WebClient 的属性
            web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = cfg.config.NetConn.Timeout;
                return true;
            };
            HtmlDocument doc = null;
            // 如果失败 重试指定次数
            for (int i = 0; i <= cfg.config.NetConn.Retry && doc == null; ++i)
            {
                if (i != 0) print("重试 " + i + " : " + uri);
                try { doc = web.Load(uri.AbsoluteUri); } catch { }
            }
            return doc;
        }
        /// <summary>
        /// 开始下载整本小说
        /// </summary>
        /// <param name="uri">小说链接</param>
        /// <param name="storedir">要保存的路径</param>
        /// <returns>下载编号与书籍信息. 如果要更新书籍信息, 可无视下载编号</returns>
        public KeyValuePair<int, Configuration._Storage._Book> Start(Uri uri, string storedir)
        {
            try
            {
                // 找一个主键, 为要下载的内容入库
                var nextOrder = 1;
                try { nextOrder = cfg.config.Storage.BookShelf.Select(x => x.Key).Max() + 1; } catch { }               


                // 取得当前域名的结构信息
                var def = cfg.config.SiteDefines[uri.Host];
                // 根据模式替换得到目录的网址
                var listUri = new Uri(Regex.Replace(uri.AbsoluteUri, def.HeadPage.Redirect.Pattern, def.HeadPage.Redirect.Replacement));

                HtmlNode doc = null;

                // 分析小说简介的位置, 得到具体方案
                switch (def.HeadPage.SynopLoc)
                {
                    case Configuration.SiteInfo._HeadPage.S_Loc.Cover:
                        doc = GetDocument(uri).DocumentNode;
                        break;

                    case Configuration.SiteInfo._HeadPage.S_Loc.Catalog:
                        doc = GetDocument(listUri).DocumentNode;
                        break;

                    default:
                        break;
                }

                // 获取小说的相关信息并整理成封面, 保存

                var Title = doc.SelectSingleNode(def.HeadPage.Title).OuterHtml.MultiTrim();
                var RawTitle = nextOrder + "." + doc.SelectSingleNode(def.HeadPage.Title).InnerText.MultiTrim();
                var Author = doc.SelectSingleNode(def.HeadPage.Author).OuterHtml.MultiTrim();
                var Genre = doc.SelectSingleNode(def.HeadPage.Genre).OuterHtml.MultiTrim();
                var SubGenre = doc.SelectSingleNode(def.HeadPage.SubGenre).OuterHtml.MultiTrim();
                var Synopsis = doc.SelectSingleNode(def.HeadPage.Synopsis).OuterHtml.MultiTrim();

                var sb = new StringBuilder();
                try { sb.Append(@"<p>" + Title); } catch { }
                try { sb.Append(@" (" + Author + @")"); } catch { }
                try { sb.Append(@" (" + Genre); } catch { }
                try { sb.AppendLine(@" / " + SubGenre + @")</p>"); } catch { }
                try { sb.AppendLine(@"<p>" + Synopsis + @"</p>"); } catch { }

                // 建立目录并保存
                var curDir = Path.Combine(storedir, RawTitle);
                Directory.CreateDirectory(curDir);

                sb.ToString().Save(Path.Combine(curDir, "0.txt"));

                // 按照上边的 switch 获取目录
                if (def.HeadPage.SynopLoc == Configuration.SiteInfo._HeadPage.S_Loc.Cover)
                { doc = GetDocument(listUri).DocumentNode; }

                // 用 List < Pair < `Title`, `Link` > > 模拟一个多键字典
                var index = new List<KeyValuePair<string, string>>();

                // 根据卷与章在目录里的结构提取出小说的目录
                switch (def.Volume.Type)
                {
                    case Configuration.SiteInfo._Volume._Type.Fold:
                        {
                            var volumes = doc.SelectNodes(def.Volume.Handle);
                            foreach (var v in volumes)
                            {
                                var vtitle = v.SelectSingleNode(def.Volume.Name).InnerText.MultiTrim();
                                var chapters = v.SelectNodes(def.Chapter.Handle);
                                foreach (var c in chapters)
                                {
                                    var ctitle = c.SelectSingleNode(def.Chapter.Name).InnerText.MultiTrim();
                                    var clink = c.SelectSingleNode(def.Chapter.Link).Attributes["href"].Value;
                                    var name = vtitle + " " + ctitle;
                                    //sb.AppendLine(@"<p>" + name + @"</p>");
                                    index.Add(name, clink);
                                }
                            }
                            break;
                        }
                    case Configuration.SiteInfo._Volume._Type.Plat:
                        {
                            var chapters = doc.SelectNodes(def.Volume.Handle + " | " + def.Chapter.Handle);
                            string vtitle = "";
                            foreach (var c in chapters)
                            {
                                try { vtitle = c.SelectSingleNode(def.Volume.Name).InnerText.MultiTrim(); } catch { }
                                var ctitle = c.SelectSingleNode(def.Chapter.Name).InnerText.MultiTrim();
                                var clink = c.SelectSingleNode(def.Chapter.Link).Attributes["href"].Value;
                                var name = vtitle + " " + ctitle;
                                //sb.AppendLine(@"<p>" + name + @"</p>");
                                index.Add((vtitle + " " + ctitle).Trim(), clink);
                            }
                            break;
                        }
                    default:
                        break;
                }

                //////////////////////////////////////////////////////////
                // 下载各章节
                int i = 0;
                foreach (var idx in index)
                {
                    sb.Clear();
                    ++i;
                    // 组合章节的链接
                    var link = idx.Value;
                    if (string.IsNullOrWhiteSpace(link)) continue;
                    if (Regex.IsMatch(link, @"^/.*$")) { link = listUri.RootPath() + link; } // Root path
                    else if (Regex.IsMatch(link, @".*://.*")) { } // Absolute path
                    else { link = listUri.ParentPath() + link; } // Current path

                    // 找到章节正文容器
                    var textbox = GetDocument(new Uri(link)).DocumentNode.SelectSingleNode(def.TextPage.Handle);
                    // 提取章节标题
                    sb.AppendLine(textbox.SelectSingleNode(def.TextPage.Name).OuterHtml.MultiTrim());
                    // 提取正文的所有段落
                    foreach (var p in textbox.SelectNodes(def.TextPage.Body))
                    { sb.AppendLine(p.OuterHtml.MultiTrim()); }

                    sb.ToString().Save(Path.Combine(curDir, i + ".txt"));
                }

                // 建立数据库条目
                var bookinfo = new Configuration._Storage._Book();
                bookinfo.Title = RawTitle;
                bookinfo.Dir = nextOrder.ToString();
                bookinfo.Chapters = new Dictionary<int, string>(); // 这是一个编码缺陷. 需要改动 IConfig 里的所有 class
                for (int j = 0; j <= i; ++j)
                { bookinfo.Chapters.Add(j, j + ".txt"); }

                return new KeyValuePair<int, Configuration._Storage._Book>(nextOrder, bookinfo);
            }
            catch { return new KeyValuePair<int, Configuration._Storage._Book>(-1, null); }
        }
    }
}
