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

namespace TwoTimes
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            var p = e.GetPosition(this.canvas1);
            Shape s = new Rectangle();
            this.canvas1.Children.Add(s);
            MessageBox.Show(p.ToString());
        }


    }
}
