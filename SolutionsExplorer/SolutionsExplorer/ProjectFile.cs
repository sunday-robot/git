using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsExplorer {
    public class ProjectFile {
        public SolutionFile SolutionFile { get; set; }
        public string FilePath { get; set; }
        public List<string> SourceFiles;

        public ProjectFile() {
            this.SourceFiles = new List<string>();
        }

        public ProjectFile(SolutionFile sf, string filePath)
            : this() {
            this.SolutionFile = sf;
            this.FilePath = filePath;
        }
    }
}
