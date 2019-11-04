using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsExplorer {
    public class SolutionFileLoader {
        public static SolutionFile Load(string filePath) {
            var sf = new SolutionFile(filePath);

            var sr = new System.IO.StreamReader(filePath);
            var re = new System.Text.RegularExpressions.Regex("^Project");
            var separator = new char[] { '"' };
            for (; ; ) {
                var line = sr.ReadLine();
                if (line == null)
                    break;
                if (re.IsMatch(line)) {
                    var f = line.Split(separator);
                    if (f.Length < 6) {
                        throw new Exception("Cannot get project file name from line below.\n" + line);
                    }
                    var projectFileName = f[5];
                    var pf = ProjectFileLoader.Load(projectFileName, System.IO.Path.GetDirectoryName(sf.FilePath));
                    sf.ProjectFiles.Add(pf);
                }
            }
            sr.Close();

            return sf;
        }
    }
}
