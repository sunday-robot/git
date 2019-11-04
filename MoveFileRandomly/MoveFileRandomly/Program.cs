using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFileRandomly
{
    class Program
    {
        /// <summary>
        /// 移動元ディレクトリから、ランダムにファイルを選択し、移動先ディレクトリに移動させる。
        /// </summary>
        /// <param name="args">
        /// [0]:移動元ディレクトリ
        /// [1]:移動先ディレクトリ
        /// [2]:ファイルサイズ合計(これを超えない範囲で移動させる)
        /// [3]:最大ファイル数(これを超えない範囲で移動させる)
        /// </param>
        static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                _Usage();
                return;
            }
            var srcDir = args[0];
            var destDir = args[1];
            var maxFileSizeSum = long.Parse(args[2]);
            var maxFileCount = int.Parse(args[3]);
            _MoveFileRandomly(srcDir, destDir, maxFileSizeSum, maxFileCount);
        }

        private static void _Usage()
        {
            Console.Write("Usage:  <src directory> <dest directory> <maximum file size sum> <maximum file count>");
        }

        /// <summary>
        /// 移動元ディレクトリから、ランダムにファイルを選択し、移動先ディレクトリに移動させる。
        /// </summary>
        /// <param name="srcDir">移動元ディレクトリ</param>
        /// <param name="destDir">移動先ディレクトリ</param>
        /// <param name="totalSize">ファイルサイズ合計(これを超えない範囲で移動させる)</param>
        /// <param name="maxFileCount">ファイル数(これを超えない範囲で移動させる)</param>
        private static void _MoveFileRandomly(string srcDir, string destDir, long maxFileSizeSum, int maxFileCount)
        {
            _ValidateParameters(srcDir, destDir, maxFileSizeSum, maxFileCount);

            // 移動元ディレクトリから、「参照回数ファイル」をロードする。
            var fileCountDictionary = FileCountFileUtil.Load(srcDir);

            // 移動元ディレクトリから、すべてのファイルorディレクトリ名とそのサイズを取得する。
            var fileSizeDictionary = FileSizeDictionaryUtil.Create(srcDir);
            fileSizeDictionary.Remove(FileCountFileUtil.FileCountFileName); // 「参照回数ファイル」は除外する

            // 移動させるファイルをランダムに選択する。
            var selectedFiles = FileSelector.Select(fileSizeDictionary, fileCountDictionary, maxFileSizeSum, maxFileCount);

            // 選択されたファイル、ディレクトリのリストに従い、実際に移動させる。
            _MoveFiles(srcDir, selectedFiles, destDir);

            // 選択されたファイル、ディレクトリのリストで、「参照回数ファイル」を更新する。
            foreach (var name in selectedFiles)
                if (fileCountDictionary.ContainsKey(name))
                    fileCountDictionary[name]++;
                else
                    fileCountDictionary.Add(name, 1);

            // 移動元ディレクトリに新しい「参照回数ファイル」を保存する。
            FileCountFileUtil.Save(fileCountDictionary, srcDir);
        }

        /// <summary>
        /// 入力パラメータを検証する。
        /// </summary>
        /// <param name="srcDir"></param>
        /// <param name="destDir"></param>
        /// <param name="maxFileSizeSum"></param>
        private static void _ValidateParameters(string srcDir, string destDir, long maxFileSizeSum, int maxFileCount)
        {
            if (!Directory.Exists(srcDir))
                throw new FileNotFoundException(srcDir.ToString());
            if (!Directory.Exists(destDir))
                throw new FileNotFoundException(destDir.ToString());
            if (maxFileSizeSum <= 0)
                throw new ArgumentOutOfRangeException("invalid total size(3rd parameter)");
            if (maxFileCount <= 0)
                throw new ArgumentOutOfRangeException("invalid maximum file count(4th parameter)");
        }

        /// <summary>
        /// ファイルを移動させる。
        /// </summary>
        /// <param name="selectedFiles"></param>
        /// <param name="destDir"></param>
        private static void _MoveFiles(string srcDir, List<string> selectedFiles, string destDir)
        {
            foreach (var file in selectedFiles)
            {
                var srcFile = Path.Combine(srcDir, file);
                var destFile = Path.Combine(destDir, file);
                File.Move(srcFile, destFile);
            }
        }
    }
}
