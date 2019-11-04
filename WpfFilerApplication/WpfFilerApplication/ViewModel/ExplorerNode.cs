using System.IO;
using Wankuma.Kazuki.Wpf;

namespace WpfFilerApplication.ViewModel {
    public class ExplorerNode : ViewModelBase {
        #region menmber variables
        private string _name;
        private ExplorerNode _parent;
        #endregion
        #region constructors
        public ExplorerNode(string name, ExplorerNode parent)
            : base() {
            this._name = name;
            this._parent = parent;
        }
        #endregion constructors
        #region properties
        public string Name {
            get { return _name; }
            set {
                if (Equals(_name, value))
                    return;
                _name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("FullPath");
            }
        }
        public ExplorerNode Parent {
            get { return _parent; }
            internal set {
                if (Equals(_parent, value))
                    return;
                _parent = value;

                // 親が変わるとフルパスも変わる
                OnPropertyChanged("Parent");
                OnPropertyChanged("FullPath");
            }
        }
        // このプロパティは実体なし
        public string FullPath {
            get {
                if (this.Parent != null)
                    return Path.Combine(this.Parent.FullPath, this.Name);
                else
                    return this.Name;
            }
        }
        #endregion
    }
}
