using System.Collections.Generic;
using System.IO;

namespace MoveFileRandomly
{
    class FileSizeDictionaryUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static Dictionary<string, long> Create(string directoryPath)
        {
            var dictionary = new Dictionary<string, long>();
            foreach (FileSystemInfo fsi in (new DirectoryInfo(directoryPath)).EnumerateFileSystemInfos())
                dictionary.Add(fsi.Name, _GetSize(fsi));
            return dictionary;
        }

        /// <summary>
        /// 指定されたファイルのサイズ、またはディレクトリ内の全ファイルの合計サイズを返す。
        /// </summary>
        /// <param name="fsi">ファイルまたはディレクトリのFileSystemInfo</param>
        /// <returns>ファイルサイズまたはディレクトリ内の全ファイルの合計サイズ</returns>
        private static long _GetSize(FileSystemInfo fsi)
        {
            if (fsi is FileInfo)
                return ((FileInfo)fsi).Length;
            long size = 0;
            foreach (var e in ((DirectoryInfo)fsi).EnumerateFileSystemInfos())
                size += _GetSize(e);
            return size;
        }
    }
}
