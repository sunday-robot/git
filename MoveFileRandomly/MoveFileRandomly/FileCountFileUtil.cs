using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveFileRandomly
{
    public class FileCountFileUtil
    {
        /// <summary>
        /// ファイル参照回数ファイル名
        /// </summary>
        public const String FileCountFileName = ".fileCount";

        /// <summary>
        /// 指定されたディレクトリのファイル参照回数ファイルをロードする。
        /// (ファイルがない場合はnullを返したり、例外を投げたりせず、空のリストを返す。)
        /// </summary>
        /// <param name="directoryPath">ディレクトリパス名</param>
        /// <returns>ファイル参照回数のDictionary</returns>
        public static Dictionary<string, int> Load(string directoryPath)
        {
            var dictionary = new Dictionary<string, int>();

            // 指定されたディレクトリの".FileAndCountList"を読み、参照回数をFileAndCountのリストに設定する。
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(directoryPath, FileCountFileName), Encoding.GetEncoding("UTF-8")))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var elements = line.Split('\t');
                        var name = elements[0];
                        var count = int.Parse(elements[1]);
                        dictionary.Add(name, count);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                ;   // ".fileCount"がないことは普通のことなので、catch節では何もしない(結果としてからのリストを返す)
            }

            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNameAndCountDictionary"></param>
        /// <param name="directoryPath"></param>
        public static void Save(Dictionary<string, int> fileNameAndCountDictionary, string directoryPath)
        {
            using (var sw = new StreamWriter(Path.Combine(directoryPath, FileCountFileName), false, Encoding.GetEncoding("UTF-8")))
            {
                // ファイル名順にして書き出す(デバッグ用)
                foreach (var e in fileNameAndCountDictionary.OrderBy(p => p.Key))
                    sw.WriteLine(e.Key + "\t" + e.Value);
            }
        }
    }
}
