using System.IO;
using System.Linq;
using Wankuma.Kazuki.Wpf;

namespace WpfFilerApplication.ViewModel {
    public class MainWindowViewModel : ViewModelBase {
        private ExplorerNodeCollection<DriveNode> _drives;
        public ExplorerNodeCollection<DriveNode> Drives {
            get {
                if (_drives == null) {
                    _drives = getDrives();
                }
                return _drives;
            }
        }

        static ExplorerNodeCollection<DriveNode> getDrives() {
            var result = new ExplorerNodeCollection<DriveNode>();
            foreach (var d in DriveInfo.GetDrives()) {
                result.Add(new DriveNode(d.Name));
            }
            return result;
        }
    }
}
