using System;
using System.IO;
using System.IO.Compression;

namespace ZipDirectories
{
    /// <summary>
    /// メインプログラム
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">ディレクトリ名のリスト</param>
        public static void Main(string[] args)
        {
            bool errorOccured = false; // エラーあるいは警告が発生したかどうか(何も発生しなければ処理終了後、すぐにプログラムも終了するが、何らかのエラー、警告が発生した場合はユーザーの確認が必要)
            foreach (var directoryName in args)
            {
                try
                {
                    CreateZipFile(directoryName);
                    RemoveDirectory(directoryName);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("{0} : 指定されたディレクトリは存在しません。処理をスキップします。", directoryName);
                    errorOccured = true;
                }
                catch (IOException e)
                {
                    switch (e.HResult)
                    {
                        case -2147024816:
                            Console.WriteLine("{0} : 同名のZIPファイルが存在します。処理をスキップします。", directoryName);
                            errorOccured = true;
                            break;
                        default:
                            throw e;    // 予期していない例外についてはいい加減に処理せず、.netランタイムに処理をゆだねる
                    }
                }
            }

            if (errorOccured)
            {
                Console.WriteLine("エラー/警告が発生しました、内容を確認してください。");
                Console.WriteLine("Enterキーを押してください。");
                Console.Read();
            }
        }

        /// <summary>
        /// ディレクトリからZipファイルを作成する。
        /// </summary>
        /// <param name="directoryName">ディレクトリ名</param>
        private static void CreateZipFile(string directoryName)
        {
            var di = new DirectoryInfo(directoryName);
            if (!di.Exists)
            {
                throw new DirectoryNotFoundException();
            }

            var zipFileName = di.Parent.FullName + "\\" + di.Name + ".zip";
            var f = new FileStream(zipFileName, FileMode.CreateNew);
            var za = new ZipArchive(f, ZipArchiveMode.Create);

            AddDirectory(za, string.Empty, di);

            za.Dispose();
        }

        /// <summary>
        /// ZIPファイルに指定された名前でディレクトリ(正確にはディレクトリ内のファイル)を追加する。
        /// </summary>
        /// <param name="zipArchive">ZIPファイル</param>
        /// <param name="entryName">ZIPファイル内でのパス名</param>
        /// <param name="directoryInfo">ディレクトリ</param>
        private static void AddDirectory(ZipArchive zipArchive, string entryName, DirectoryInfo directoryInfo)
        {
            bool hasEntries = false;

            //// Console.WriteLine("SubDirectory(, {0}, di:{1})", entryName, directoryInfo.Name);
            foreach (var di in directoryInfo.EnumerateDirectories())
            {
                var zen = entryName + di.Name + "/";
                AddDirectory(zipArchive, zen, di);
                hasEntries = true;
            }

            foreach (var fi in directoryInfo.EnumerateFiles())
            {
                var zen = entryName + fi.Name;
                AddFile(zipArchive, zen, fi);
                hasEntries = true;
            }

            if (!hasEntries)
            {
                Console.WriteLine(entryName);
                zipArchive.CreateEntry(entryName);
            }
        }

        /// <summary>
        /// ZIPファイルに指定された名前でファイルを追加する。
        /// </summary>
        /// <param name="zipArchive">ZIPファイル</param>
        /// <param name="entryName">ZIPファイル内でのパス名</param>
        /// <param name="fileInfo">ファイル</param>
        private static void AddFile(ZipArchive zipArchive, string entryName, FileInfo fileInfo)
        {
            Console.WriteLine(entryName);

            ZipArchiveEntry zae = zipArchive.CreateEntry(entryName);
            zae.LastWriteTime = fileInfo.LastWriteTime;
            using (var os = zae.Open())
            {
                using (var fs = File.OpenRead(fileInfo.FullName))
                {
                    fs.CopyTo(os);
                }
            }
        }

        /// <summary>
        /// 指定されたディレクトリを削除する。
        /// </summary>
        /// <param name="directoryName">ディレクトリ名</param>
        private static void RemoveDirectory(string directoryName)
        {
            var di = new DirectoryInfo(directoryName);
            di.Delete(true);
        }
    }
}
