using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsExplorer {
    public class SolutionFile {
        public string FilePath { get; set; }
        public List<ProjectFile> ProjectFiles { get; set; }

        public string Name {
            // 上のFilePathから、ディレクトリ名を取り除いたものを返す。(必要ない?)
            get {
                return System.IO.Path.GetFileName(this.FilePath);
            }
        }

        public SolutionFile() {
            this.FilePath = "";
            this.ProjectFiles = new List<ProjectFile>();
        }

        public SolutionFile(string filePath)
            : this() {
            this.FilePath = filePath;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
