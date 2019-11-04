using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using NTidy;

namespace BookmarkSynchronizer
{
    public class FireFoxBookmarkLoader
    {
        //private string filePath;
        //private WebBrowser wb = new WebBrowser();
        //private EventWaitHandle weh = new EventWaitHandle(false, EventResetMode.ManualReset);
        //private List<AbstractBookmarkEntry> bookmarkList;

        //private static FireFoxBookmarkLoader instance = new FireFoxBookmarkLoader();

        public static void Load(string filePath)
        {
            var doc = new TidyDocument();
            doc.LoadFile(filePath);
            var bookmarkList = _ParseBookmarkFile(doc.Body);
            //            instance._Load(filePath);
        }

#if false 
        private void _Load(String filePath)
        {
            this.filePath = filePath;
            var th = new Thread(new ThreadStart(this.startLoad));
            weh.Reset();
            th.Start();
            weh.WaitOne();
            Debug.P(bookmarkList, "");
        }

        private void startLoad()
        {
            WebClient client = new WebClient();
            var f = Path.GetFullPath(filePath);
            var uri = new Uri(f);
            wb.DocumentCompleted += aaa;
            wb.Navigate(uri);
        }

        private void aaa(object o, WebBrowserDocumentCompletedEventArgs args)
        {
            var doc = ((WebBrowser)o).Document;
            var body = doc.Body;
            bookmarkList = _ParseBookmarkFile(body);
            weh.Set();
        }
#endif
        private static void checkTagName(TidyNode htmlElement, string expectedTagName)
        {
            if (htmlElement.Name != expectedTagName)
                throw new Exception("Unexpected tag name : " + htmlElement.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlElement"></param>
        /// <returns></returns>
        private static List<AbstractBookmarkEntry> _ParseBookmarkFile(TidyNode htmlElement)
        {
            var children = htmlElement.ChildNodes.GetEnumerator();

            checkTagName((TidyNode)children.Current, "H1");
            //children.MoveNext();
            //checkTagName(children.Current, "DL");
            //var bookmarkList = _ParseDlTag(children.Current);
            //children.MoveNext();
            //checkTagName(children.Current, "P");
            //if (children.MoveNext())
            //    throw new Exception();
            //return bookmarkList;
            return null;
        }
#if false
        private static List<AbstractBookmarkEntry> _ParseDlTag(HtmlElement dlTag)
        {
            if (dlTag.Children.Count < 1)
                throw new Exception();

            checkTagName(dlTag.Children[0], "P");

            AbstractBookmarkEntry lastEntry = null;

            var bookmarkList = new List<AbstractBookmarkEntry>();
            for (int i = 1; i < dlTag.Children.Count; i++)
            {
                var child = (HtmlElement)dlTag.Children[i];
#if true
                if (lastEntry == null)
                {
                    // 先頭またはDDタグの後
                    checkTagName(child, "DT");
                    var entry = _ParseDtTag(child);
                    bookmarkList.Add(entry);
                    if (entry is BookmarkFolder && ((BookmarkFolder)entry).EntryList != null)
                        lastEntry = null;
                    else
                        lastEntry = entry;
                }
                else if (lastEntry is Bookmark)
                {
                    switch (child.TagName)
                    {
                        case "DT":
                            var entry = _ParseDtTag(child);
                            bookmarkList.Add(entry);
                            if (entry is BookmarkFolder && ((BookmarkFolder)entry).EntryList != null)
                                lastEntry = null;
                            else
                                lastEntry = entry;
                            break;
                        case "DD":
                            string description;
                            _ParseDdTag(child, out description);
                            lastEntry.Description = description;
                            lastEntry = null;
                            break;
                        default:
                            throw new Exception();
                    }
                }
                else if (lastEntry is BookmarkFolder)
                {
                    // 直前のブックマークフォルダ用のDTタグには名前しか含まれていない場合、
                    // 次はブックマークの説明文と、ブックマークリストを含むDDタグが続く。
                    checkTagName(child, "DD");
                    string description;
                    List<AbstractBookmarkEntry> bookmarkList2;
                    _ParseDdTag(child, out description, out bookmarkList2);
                    lastEntry.Description = description;
                    if (bookmarkList2 != null)
                    {
                        ((BookmarkFolder)lastEntry).SetBookmarkList(bookmarkList2);
                    }
                    lastEntry = null;
                }
#if false
                if (lastEntry == null)
                {
                    checkTagName(child, "DT");
                    var entry = _ParseDtTag(child);
                    bookmarkList.Add(entry);
                    if (entry is BookmarkFolder && entry.Description != string.Empty)
                        lastEntry = null;
                    else
                        lastEntry = entry;
                }
                else
                {
                    switch (child.TagName)
                    {
                        case "DT":
                            var entry = _ParseDtTag(child);
                            bookmarkList.Add(entry);
                            if (entry is BookmarkFolder && entry.Description != string.Empty)
                                lastEntry = null;
                            else
                                lastEntry = entry;
                            break;
                        case "DD":
                            string description;
                            List<AbstractBookmarkEntry> bookmarkList2;
                            _ParseDdTag(child, out description, out bookmarkList2);
                            lastEntry.Description = description;
                            if (bookmarkList2 != null)
                            {
                                ((BookmarkFolder)lastEntry).SetBookmarkList(bookmarkList2);
                            }
                            lastEntry = null;
                            break;
                        default:
                            throw new Exception();
                    }
                }
#endif
#else
                switch (child.TagName)
                {
                    case "DT":
                        // 未完成のブックマークフォルダのDTタグの次はDDタグでなければならない。
                        if ((lastEntry is BookmarkFolder)
                            && (((BookmarkFolder)lastEntry).EntryList == null))
                            throw new Exception();
                        bookmarkList.Add(entry);
                        if ((entry is BookmarkFolder)
                            && (((BookmarkFolder)entry).EntryList != null))
                            lastEntry = null;
                        else
                            lastEntry = entry;
                        break;
                    case "DD":
                        string description;
                        List<AbstractBookmarkEntry> bookmarkList2;
                        _ParseDdTag(child, out description, out bookmarkList2);
                        lastEntry.Description = description;
                        if (bookmarkList2 != null)
                        {
                            ((BookmarkFolder)lastEntry).SetBookmarkList(bookmarkList2);
                        }
                        lastEntry = null;
                        break;
                    default:
                        throw new Exception();
                }
                if (lastEntry == null)
                {
                    checkTagName(child, "DT");
                    var entry = _ParseDtTag(child);
                    bookmarkList.Add(entry);
                    if (entry is BookmarkFolder && entry.Description != string.Empty)
                        lastEntry = null;
                    else
                        lastEntry = entry;
                }
                else
                {
                    switch (child.TagName)
                    {
                        case "DT":
                            var entry = _ParseDtTag(child);
                            bookmarkList.Add(entry);
                            if (entry is BookmarkFolder && entry.Description != string.Empty)
                                lastEntry = null;
                            else
                                lastEntry = entry;
                            break;
                        case "DD":
                            string description;
                            List<AbstractBookmarkEntry> bookmarkList2;
                            _ParseDdTag(child, out description, out bookmarkList2);
                            lastEntry.Description = description;
                            if (bookmarkList2 != null)
                            {
                                ((BookmarkFolder)lastEntry).SetBookmarkList(bookmarkList2);
                            }
                            lastEntry = null;
                            break;
                        default:
                            throw new Exception();
                    }
                }
#endif
            }

            return bookmarkList;
        }

        private static AbstractBookmarkEntry _ParseDtTag(HtmlElement htmlElement)
        {
            var firstChild = (HtmlElement)htmlElement.Children[0];
            var name = firstChild.InnerText;
            switch (firstChild.TagName)
            {
                case "A":
                    // ブックマーク
                    var url = firstChild.GetAttribute("HREF");
                    return new Bookmark(name, new Uri(url));
                case "H3":
                    // ブックマークフォルダ
                    // ブックマークフォルダの場合、子供はH3一人だけか、H3とブックマークリストの二人のいずれか。
                    switch (htmlElement.Children.Count)
                    {
                        case 1:
                            // DT{H3}, DD{BookmarkList, P};
                            return new BookmarkFolder(name);
                        case 3:
                            // DT{H3, BookmarkList, P};
                            checkTagName(htmlElement.Children[1], "DL");
                            var bookmarkList = _ParseDlTag(htmlElement.Children[1]);
                            checkTagName(htmlElement.Children[2], "P");
                            return new BookmarkFolder(name, bookmarkList);
                        default:
                            throw new Exception();
                    }
                default:
                    throw new Exception();
            }
        }

        private static void _ParseDdTag(HtmlElement ddTag, out string description)
        {
            if (ddTag.Children.Count != 0)
                throw new Exception();

            description = ddTag.InnerText;
        }

        private static void _ParseDdTag(HtmlElement ddTag, out string description, out List<AbstractBookmarkEntry> bookmarkList)
        {
            if (ddTag.Children.Count != 2)
                throw new Exception();

            description = ddTag.InnerText;
            HtmlElement child;
            child = (HtmlElement)ddTag.Children[0];
            checkTagName(child, "DL");
            bookmarkList = _ParseDlTag(child);
            checkTagName(ddTag.Children[1], "P");
        }
    }
#endif
    }
}
