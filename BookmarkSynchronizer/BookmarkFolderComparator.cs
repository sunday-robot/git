using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkSynchronizer
{
    /// <summary>
    /// ブックマークフォルダーの比較を行うもの。
    /// </summary>
    public class BookmarkFolderComparator
    {
        /// <summary>
        /// 二つのブックマークフォルダーを比較する。
        /// (まだ比較で何をすればよいのかわかっていない。)
        /// </summary>
        /// <param name="a">ブックマークフォルダーA</param>
        /// <param name="b">ブックマークフォルダーB</param>
        /// <returns>比較結果???</returns>
        public static Object Compare(List<AbstractBookmarkEntry> a, List<AbstractBookmarkEntry> b) 
        {
            // aとbの和集合
            var aub = a.Union(b);

            // 追加されたもののリスト(Aにはなかったが、Bにはあるもののリスト)
            var added = a.Except(a);

            // 削除されたもののリスト(Aにはあるが、Bにはないもののリスト)
            var deleted = b.Except(b);
            
            return null;
        }

        // ブックマークの追加(ブックマークフォルダー、名前、URL)
        // ブックマークの削除(ブックマークフォルダー、名前)
        // ブックマークのURL変更(ブックマークフォルダー、名前、新しいURL)
        // ブックマークフォルダーの追加(ブックマークフォルダー、名前)
        // ブックマークフォルダーの削除(ブックマークフォルダー、名前)

        // 以下は削除、追加が絡むと難しそうだが対応したい。
        // ブックマークフォルダーのエントリーの順番変更

        // 以下のコマンドも考えられるが、名前変更かどうかの判定が面倒だし、削除と追加で代用できるので対応しない。
        // ブックマークの名前変更(ブックマークフォルダー、名前、新しい名前)
        // ブックマークフォルダーの名前変更(ブックマークフォルダー、名前、新しい名前)
    }
}
