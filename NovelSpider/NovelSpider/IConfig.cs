using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace NovelSpider
{
    /// <summary>
    /// 程序设置的存储结构
    /// </summary>
    [DataContract]
    public class Configuration
    {
        #region 配置文件的内部结构定义

        /// <summary>
        /// 网站结构的定义信息
        /// </summary>
        [DataContract]
        public class SiteInfo
        {
            /// <summary>
            /// 网站首页的相关定义
            /// </summary>
            [DataContract]
            public class _HeadPage
            {
                /// <summary>
                /// "小说简介"的位置
                /// </summary>
                [DataContract]
                public enum S_Loc
                {
                    /// <summary>
                    /// 未定义
                    /// </summary>
                    [EnumMember]
                    Null,

                    /// <summary>
                    /// 封面
                    /// </summary>
                    [EnumMember]
                    Cover,

                    /// <summary>
                    /// 目录
                    /// </summary>
                    [EnumMember]
                    Catalog,
                }

                /// <summary>
                /// "小说简介"的位置
                /// </summary>
                [DataMember]
                public S_Loc SynopLoc { get; set; }

                /// <summary>
                /// 用于重定向的正则替换对的定义
                /// </summary>
                [DataContract]
                public class _RepPair
                {
                    /// <summary>
                    /// 要查找的模式
                    /// </summary>
                    [DataMember]
                    public string Pattern { get; set; }

                    /// <summary>
                    /// 要替换为的串
                    /// </summary>
                    [DataMember]
                    public string Replacement { get; set; }
                }

                /// <summary>
                /// 用于重定向的正则替换对
                /// </summary>
                [DataMember]
                public _RepPair Redirect { get; set; }

                /// <summary>
                /// 小说标题 XPath 地址
                /// </summary>
                [DataMember]
                public string Title { get; set; }

                /// <summary>
                /// 小说类型 XPath 地址
                /// </summary>
                [DataMember]
                public string Genre { get; set; }

                /// <summary>
                /// 小说子类型 XPath 地址
                /// </summary>
                [DataMember]
                public string SubGenre { get; set; }

                /// <summary>
                /// 小说作者 XPath 地址
                /// </summary>
                [DataMember]
                public string Author { get; set; }

                /// <summary>
                /// 小说简介 XPath 地址
                /// </summary>
                [DataMember]
                public string Synopsis { get; set; }

                public _HeadPage()
                {
                    Redirect = new _RepPair();
                }
            }

            /// <summary>
            /// 网站首页信息
            /// </summary>
            [DataMember]
            public _HeadPage HeadPage { get; set; }

            /// <summary>
            /// 小说分卷信息的相关定义
            /// </summary>
            [DataContract]
            public class _Volume
            {
                /// <summary>
                /// 小说分卷的展现形式
                /// </summary>
                [DataContract]
                public enum _Type
                {
                    /// <summary>
                    /// 未定义
                    /// </summary>
                    [EnumMember]
                    Null,

                    /// <summary>
                    /// 标签嵌套
                    /// </summary>
                    [EnumMember]
                    Fold,

                    /// <summary>
                    /// 平坦文本
                    /// </summary>
                    [EnumMember]
                    Plat,
                }

                /// <summary>
                /// 分卷信息的 XPath 地址
                /// </summary>
                [DataMember]
                public string Handle { get; set; }

                /// <summary>
                /// 分卷标题文本
                /// </summary>
                [DataMember]
                public string Name { get; set; }

                /// <summary>
                /// 小说分卷的展现形式
                /// </summary>
                [DataMember]
                public _Type Type { get; set; }
            }

            /// <summary>
            /// 小说分卷信息
            /// </summary>
            [DataMember]
            public _Volume Volume { get; set; }

            /// <summary>
            /// 小说章节信息的相关定义
            /// </summary>
            [DataContract]
            public class _Chapter
            {
                /// <summary>
                /// 章节信息的 XPath 地址. 如果 Fold 模式, 则必须要有Volume.Handle
                /// </summary>
                [DataMember]
                public string Handle { get; set; }

                /// <summary>
                /// 章节标题文本
                /// </summary>
                [DataMember]
                public string Name { get; set; }

                /// <summary>
                /// 章节链接. 可能为相对链接, 根目录链接与绝对链接
                /// </summary>
                [DataMember]
                public string Link { get; set; }
            }

            /// <summary>
            /// 小说章节信息
            /// </summary>
            [DataMember]
            public _Chapter Chapter { get; set; }

            /// <summary>
            /// 小说正文的相关定义
            /// </summary>
            [DataContract]
            public class _TextPage
            {
                /// <summary>
                /// 小说正文页面中, 正文块的 XPath 地址
                /// </summary>
                [DataMember]
                public string Handle { get; set; }

                /// <summary>
                /// 正文标题的 XPath 地址
                /// </summary>
                [DataMember]
                public string Name { get; set; } // Relative of @Handle

                /// <summary>
                /// 正文内容的 HTML 文档
                /// </summary>
                [DataMember]
                public string Body { get; set; } // Relative of @Handle
            }

            /// <summary>
            /// 小说正文信息
            /// </summary>
            [DataMember]
            public _TextPage TextPage { get; set; }

            public SiteInfo()
            {
                HeadPage = new _HeadPage();
                Volume = new _Volume();
                Chapter = new _Chapter();
                TextPage = new _TextPage();
            }
        }

        /// <summary>
        /// 需要文本显示的格式, 用于 CSS 生成器
        /// </summary>
        [DataContract]
        public class _ReaderStyle
        {
            /// <summary>
            /// 字号
            /// </summary>
            [DataMember]
            public string FontSize { get; set; }

            /// <summary>
            /// 字体
            /// </summary>
            [DataMember]
            public string FontFace { get; set; }

            /// <summary>
            /// 字色
            /// </summary>
            [DataMember]
            public string ForgroundColor { get; set; }

            /// <summary>
            /// 背景色
            /// </summary>
            [DataMember]
            public string BackgroundColor { get; set; }
        }

        /// <summary>
        /// 上一次阅读的记录的定义
        /// </summary>
        [DataContract]
        public class _LastRead
        {
            /// <summary>
            /// 小说路径
            /// </summary>
            [DataMember]
            public string BookPath { get; set; }

            /// <summary>
            /// 章节在小说内的路径
            /// </summary>
            [DataMember]
            public string Chapter { get; set; }

            /// <summary>
            /// 存储最后的章节位置
            /// </summary>
            [DataMember]
            public Point LastPosition { get; set; }
        }
        /// <summary>
        /// 设置网络连接失败处理的属性
        /// </summary>
        [DataContract]
        public class _NetConn
        {
            /// <summary>
            /// 重试次数
            /// </summary>
            [DataMember]
            public int Retry { get; set; }
            /// <summary>
            /// 每次尝试的等待时间
            /// </summary>
            [DataMember]
            public int Timeout { get; set; }
        }
        /// <summary>
        /// 描述程序的下载存储路径, 也是一种简化的数据库
        /// </summary>
        [DataContract]
        public class _Storage
        {
            /// <summary>
            /// 定义书籍信息
            /// </summary>
            [DataContract]
            public class _Book
            {
                /// <summary>
                /// 书名
                /// </summary>
                [DataMember]
                public string Title { get; set; }
                /// <summary>
                /// 存储的目录名
                /// </summary>
                [DataMember]
                public string Dir { get; set; }
                /// <summary>
                /// 章节的路径列表
                /// </summary>
                [DataMember]
                public Dictionary<int, string> Chapters { get; set; }
            }
            /// <summary>
            /// 使用 ID, 书籍 的方式保存
            /// </summary>
            [DataMember]
            public Dictionary<int, _Book> BookShelf { get; set; }
        }
        #endregion 配置文件的内部结构定义

        /// <summary>
        /// 存储所有的网站定义
        /// </summary>
        [DataMember]
        public Dictionary<string, SiteInfo> SiteDefines { get; set; }

        /// <summary>
        /// 阅读器的显示格式
        /// </summary>
        [DataMember]
        public _ReaderStyle ReaderStyle { get; set; }

        /// <summary>
        /// 上一次阅读记录
        /// </summary>
        [DataMember]
        public _LastRead LastRead { get; set; }
        /// <summary>
        /// 网络连接属性
        /// </summary>
        [DataMember]
        public _NetConn NetConn { get; set; }
        /// <summary>
        /// 程序的存储情况
        /// </summary>
        [DataMember]
        public _Storage Storage { get; set; }
    }

    /// <summary>
    /// 对配置文件的控制操作. 实现这个接口以保存为不同的语言, 如 XML, json 等
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 程序设置存储
        /// </summary>
        Configuration config { get; set; }

        /// <summary>
        /// 从磁盘读取配置
        /// </summary>
        /// <param name="path">配置文件的路径</param>
        void Load(string path);

        /// <summary>
        /// 把配置保存在磁盘上
        /// </summary>
        /// <param name="path">配置文件的路径</param>
        void Save(string path);
    }
}