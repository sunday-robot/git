using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsExplorer {
    class MainWindowViewModel {
        private Dictionary<string, SolutionFile> solutionFiles;
        private SolutionFile selectedSolutionFile;
        private ProjectFile selectedProjectFile;

        public Dictionary<string, SolutionFile> SolutionFiles
        {
            set
            {
                solutionFiles = value;
            }
            get
            {
                return solutionFiles;
            }
        }
#if false
        public Dictionary<string, ProjectFile> ProjectFiles {
            get {
                return selectedSolutionFile.ProjectFiles;
            }
        }
#endif

#if false
        public Dictionary<string, string> SourceFiles {
            get {
                return selectedProjectFile.SourceFiles;
            }
        }
#endif

        public void SetSelectedSolutionFile(SolutionFile solutionFile) {
            this.selectedSolutionFile = solutionFile;
        }

        public MainWindowViewModel() {
            this.SolutionFiles = new Dictionary<string, SolutionFile>();
        }

        public void LoadSolutionFiles(string[] solutionFilePathes) {
            foreach (var p in solutionFilePathes) {
                var sf = SolutionFileLoader.Load(p);
                this.SolutionFiles[sf.FilePath] = sf;
            }
        }
    }
}
