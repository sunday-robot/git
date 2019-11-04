using System;
using System.Collections.Generic;

namespace BookmarkSynchronizer
{
    /// <summary>
    /// ブックマークフォルダー
    /// </summary>
    public class BookmarkFolder : AbstractBookmarkEntry
    {
        public List<AbstractBookmarkEntry> EntryList;

        public BookmarkFolder(string Name)
            : base(Name)
        {
            EntryList = null;
        }

        public BookmarkFolder(string Name, List<AbstractBookmarkEntry> bookmarkList)
            : base(Name)
        {
            EntryList = bookmarkList;
        }

        public void SetBookmarkList(List<AbstractBookmarkEntry> bookmarkList)
        {
            if (EntryList != null)
                throw new Exception();
            EntryList = bookmarkList;
        }
    }
}
