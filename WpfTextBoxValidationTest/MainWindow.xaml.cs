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

namespace WpfTextBoxValidationTest
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

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // ""
            // "0"
            // "0."
            // "0.1"
            // "." -> NG
            // "-"
            // "-." -> NG
            // "-0"
            // "-01"

            TextBox tb = (TextBox)sender;

            var a = tb.Text.Substring(0, tb.CaretIndex);
            var b = e.Text;
            var c = tb.Text.Substring(tb.CaretIndex);
            var s = a + b + c;

            var ss = "[" + a + "][" + b + "][" + c + "]";
            label1.Content = ss;

            // sが上記のNGパターンに当てはまるかを調べ、NGの場合は、以下を実行する。
            //            e.Handled = true;
        }
    }
}
