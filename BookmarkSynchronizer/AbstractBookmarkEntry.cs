using System;

namespace BookmarkSynchronizer
{
    /// <summary>
    /// ブックマークフォルダーのコンテンツで、ブックマークおよびブックマークフォルダーの基底クラスである。
    /// </summary>
    public class AbstractBookmarkEntry
    {
        /// <summary>
        /// 名前(識別子として使用する)
        /// </summary>
        public string Name;

        /// <summary>
        /// 説明文
        /// </summary>
        public string Description;

        public AbstractBookmarkEntry(String name)
        {
            Name = name;
            Description = string.Empty;
        }
    }
}
