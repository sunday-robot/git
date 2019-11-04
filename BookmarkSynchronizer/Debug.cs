using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookmarkSynchronizer
{
    class Debug
    {
        public static void P(HtmlElement htmlElement, string indent)
        {
            var tagName = htmlElement.TagName;
            Console.Write("{0}<{1}>", indent, tagName);
            var children = htmlElement.Children;
            if (children.Count == 0)
            {
                var innerText = htmlElement.InnerText;
                Console.Write(" \"{0}\"\n", innerText);
            }
            else
            {
                Console.Write("\n");
                foreach (var child in children)
                {
                    P((HtmlElement)child, indent + "  ");
                }
            }
        }


        public static void P(List<AbstractBookmarkEntry> bookmarkList, string indent)
        {
            foreach (var e in bookmarkList)
            {
                P(e, indent);
            }
        }

        public static void P(AbstractBookmarkEntry abe, string indent)
        {
            if (abe is Bookmark)
            {
                var bm = (Bookmark)abe;
                Console.Write("{0}{1}\n", indent, bm.Name);
            }
            else if (abe is BookmarkFolder)
            {
                var bmf = (BookmarkFolder)abe;
                Console.Write("{0}{1}/\n", indent, bmf.Name);
                indent = indent + "  ";
                P(bmf.EntryList, indent + "  ");
            }
        }
    }
}
