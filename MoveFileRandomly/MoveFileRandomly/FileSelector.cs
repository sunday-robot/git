using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFileRandomly
{
    public class FileSelector
    {
        /// <summary>
        /// 移動対象のファイルを選択する。
        /// </summary>
        /// <param name="fileInformationList">ファイル情報(ファイル名、参照回数、サイズ)のリスト</param>
        /// <param name="totalSize">ファイルサイズ合計(これを超えない範囲で選択する)</param>
        /// <param name="maxFileCount">ファイル数(これを超えない範囲で選択する)</param>
        /// <returns>ファイル名のリスト</returns>
        public static List<string> Select(Dictionary<string, long> fileSizeDictionary, Dictionary <string, int> fileCountDictionary, long maxFileSizeSum, int maxFileCount)
        {
            var selectedFiles = new List<string>();
            var restFiles = _CreateFileInformationList(fileSizeDictionary, fileCountDictionary);
            long sizeSum = 0;
            var rand = new Random();
            while ((sizeSum < maxFileSizeSum) && (selectedFiles.Count < maxFileCount) && (restFiles.Count > 0))
            {
                var value = rand.Next(_GetTotalWeight(restFiles));
                var file = _GetFile(restFiles, value);
                restFiles.Remove(file);
                long size = file.Item2;
                if (sizeSum + size > maxFileSizeSum)
                    continue;   // 選択されたファイルを追加するとサイズ制限にかかってしまう場合はファイルリストに追加しない
                sizeSum += size;
                selectedFiles.Add(file.Item1);
            }
            Console.Write("size sum = {0}\n", sizeSum);
            return selectedFiles;
        }

        /// <summary>
        /// ファイル名とそのファイルのサイズのDictionaryと、ファイル参照回数の
        /// 指定されたディレクトリのファイル情報(ファイル名、サイズ、参照回数)のリストを返す。
        /// </summary>
        /// <param name="fileSizeDictionary"></param>
        /// <param name="fileCountDictionary"></param>
        /// <returns></returns>
        public static List<Tuple<string, long, int>> _CreateFileInformationList(Dictionary<string, long> fileSizeDictionary, Dictionary<string, int> fileCountDictionary)
        {
            var list = new List<Tuple<string, long, int>>();
            foreach (var e in fileSizeDictionary)
                if (fileCountDictionary.ContainsKey(e.Key))
                    list.Add(new Tuple<string, long, int>(e.Key, e.Value, fileCountDictionary[e.Key]));
                else
                    list.Add(new Tuple<string, long, int>(e.Key, e.Value, 0));
            return list;
        }

        private static int _GetMaxCount(List<Tuple<string, long, int>> files)
        {
            int maxCount = 0;
            foreach (var file in files)
                maxCount = Math.Max(file.Item3, maxCount);
            return maxCount;
        }

        private static int _GetTotalWeight(List<Tuple<string, long, int>> files)
        {
            var maxCount = _GetMaxCount(files);

            int weightSum = 0;
            foreach (var file in files)
            {
                weightSum += maxCount - file.Item3 + 1;
            }
            return weightSum;
        }

        private static Tuple<string, long, int> _GetFile(List<Tuple<string, long, int>> files, int value)
        {
            var maxCount = _GetMaxCount(files);

            int weightSum = 0;
            foreach (var file in files)
            {
                weightSum += maxCount - file.Item3 + 1;
                if (weightSum >= value)
                    return file;
            }
            throw new IndexOutOfRangeException();
        }
    }
}
