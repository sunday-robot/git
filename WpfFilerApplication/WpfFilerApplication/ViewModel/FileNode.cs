
namespace WpfFilerApplication.ViewModel {
    public class FileNode : ExplorerNode {
        #region member variables
        private long _size;
        #endregion
        public FileNode(string name, long size, DirectoryNode parent)
        : base(name, parent){
            _size = size;
        }
        #region properties
        public long Size {
            get { return _size; }
            set {
                if (Equals(_size, value))
                    return;
                _size = value;
                OnPropertyChanged("Size");
            }
        }
        #endregion
    }
}
