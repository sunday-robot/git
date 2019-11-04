using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionsExplorer {
    public class ProjectFileLoader {
        public static ProjectFile Load(string filePath, string baseDirectory) {
            var projectFile = new ProjectFile(null, filePath);
            var xd = new XmlDocument();
            xd.Load(System.IO.Path.Combine(baseDirectory, filePath));
            var nsm = new XmlNamespaceManager(xd.NameTable);
            nsm.AddNamespace("p", "http://schemas.microsoft.com/developer/msbuild/2003");
            var xns = xd.SelectNodes("/p:Project/p:ItemGroup/p:Compile/@Include", nsm);
            foreach (XmlNode xn in xns) {
                projectFile.SourceFiles.Add(xn.Value);
            }
            return projectFile;
        }
    }
}
