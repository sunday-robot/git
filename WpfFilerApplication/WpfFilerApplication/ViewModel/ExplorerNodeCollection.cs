using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfFilerApplication.ViewModel {
    public class ExplorerNodeCollection<T> : ObservableCollection<T>
        where T : ExplorerNode {
        #region member variables
        private ExplorerNode _parent;
        #endregion
        #region constructor
        public ExplorerNodeCollection(ExplorerNode parent) {
            _parent = parent;
        }
        public ExplorerNodeCollection()
            : this(null) {
        }
        #endregion
        protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            base.OnCollectionChanged(e);
            if (e.OldItems != null) {
                // リストから削除されたアイテムのParentプロパティにnullをセットする。(メモリリークになってしまう?どこからも参照されないならガーベッジコレクションの対象になると思われるが?)
                setParents(e.OldItems.Cast<T>(), null);
            }
            if (e.NewItems != null) {
                // リストに追加されたアイテムのParentプロパティにこのコレクションのParentをセットする。
                setParents(e.NewItems.Cast<T>(), _parent);
            }
        }
        private static void setParents(IEnumerable<T> items, ExplorerNode parent) {
            foreach (var item in items) {
                item.Parent = parent;
            }
        }
    }
}
