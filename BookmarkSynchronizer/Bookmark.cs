using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkSynchronizer
{
    /// <summary>
    /// 一つのブックマークを表すもの。
    /// </summary>
    public class Bookmark : AbstractBookmarkEntry
    {
        /// <summary>
        /// URL
        /// </summary>
        public Uri Url;

        // 名前とURL以外は無視してよい?

        public Bookmark(String name, Uri url)
            : base(name)
        {
            Url = url;
        }
    }
}
