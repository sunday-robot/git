using System;
using System.IO;
using System.Linq;

namespace WpfFilerApplication.ViewModel {
    public class DirectoryNode : ExplorerNode {
        #region member variables
        private ExplorerNodeCollection<DirectoryNode> _childDirectories;
        private ExplorerNodeCollection<FileNode> _childFiles;
        #endregion
        public DirectoryNode(string name, DirectoryNode parent)
            : base(name, parent) {
            ;
        }
        #region properties
        public new String Name {
            get {
                return base.Name;
            }
            set {
                base.Name = value;
            }
        }
        public ExplorerNodeCollection<DirectoryNode> ChildDirectories {
            get {
                if (_childDirectories == null) {
                    _childDirectories = new ExplorerNodeCollection<DirectoryNode>(this);
                    try {
                        foreach (var dirname in Directory.GetDirectories(this.FullPath)) {
                            _childDirectories.Add(
                                new DirectoryNode(Path.GetFileName(dirname), this));
                        }
                    } catch (Exception e) {
#if false
                        _childDirectories.Add(new DirectoryNodeViewModel {
                            Name = e.Message
                        });
#endif
                        return _childDirectories;
                    }
                }
                return _childDirectories;
            }
        }
        public ExplorerNodeCollection<FileNode> ChildFiles {
            get {
                if (_childFiles == null) {
                    _childFiles = new ExplorerNodeCollection<FileNode>();
                    try {
                        var files = Directory.GetFiles(this.FullPath).Select(name =>
                            new FileNode(
                                Path.GetFileName(name),
                                new FileInfo(name).Length,
                                this)
                            );
                        foreach (var file in files) {
                            _childFiles.Add(file);
                        }
                    } catch (Exception e) {
                        return null;
                    }
                }
                return _childFiles;
            }
        }
        #endregion
    }
}
