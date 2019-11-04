using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkSynchronizer
{
    public abstract class BookmarkEditCommand
    {
        /// <summary>
        /// ブックマークまたはブックマークフォルダーのパス名
        /// </summary>
        public String Path;

    }
}
