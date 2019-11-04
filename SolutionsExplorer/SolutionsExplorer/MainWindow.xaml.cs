using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolutionsExplorer {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MainWindowViewModel viewModel;

        public MainWindow() {
            InitializeComponent();
            this.viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;
        }

        void addSolutionsButton_Click(object sender, RoutedEventArgs e) {
            var ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Solution files|*.sln|Project files|*.csproj;*.prj";
            ofd.ShowDialog(this);
            var files = ofd.FileNames;
            this.viewModel.LoadSolutionFiles(ofd.FileNames);
            this.redraw();
        }

        void redraw() {
            this.solutionFileListBox.Items.Clear();
            foreach (var e in this.viewModel.SolutionFiles) {
                this.solutionFileListBox.Items.Add(e/*.Name*/);
            }
        }

        private void solutionFileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
//            this.viewModel.SetSelectedSolutionFile(e.AddedItems[0]);
        }

        private void projectFileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
