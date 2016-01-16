using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NovelSpider
{
    /// <summary>
    /// extension methods to built-in objects
    /// </summary>
    public static class Extensions
    {
        
        /// <summary>
        /// trim lines and combine them
        /// </summary>
        /// <param name="source">this string</param>
        /// <returns></returns>
        public static string MultiTrim(this string source)
        {
            var single = source
                .Split(new char[] { '\r', '\n' })
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToArray();
            return string.Concat(single).Trim();
        }

        /// <summary>
        /// treat List[KeyValuePare[,]] as MultiDictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="list">this list</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Add<TKey, TValue>(this List<KeyValuePair<TKey, TValue>> list, TKey key, TValue value)
        { list.Add(new KeyValuePair<TKey, TValue>(key, value)); }
        /// <summary>
        /// get parent path of a URL
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string ParentPath(this Uri uri)
        { return uri.AbsolutePath.Remove(uri.AbsolutePath.Length - uri.Segments.Last().Length); }
        /// <summary>
        /// get the root path of a URL
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string RootPath(this Uri uri)
        { return uri.Scheme + @"://" + uri.Host; }

        /// <summary>
        /// save a string file as UTF-8
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path">output file path</param>
        public static void Save(this string str, string path)
        {
            var sw = new StreamWriter(path, false, Encoding.UTF8);
            sw.Write(str);
            sw.Dispose();
        }
    }
}
