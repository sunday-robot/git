namespace MQData
{
    using Mq;
    using System;
    using System.Windows;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ノーコメント
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new System.Windows.Forms.OpenFileDialog();
            var r = ofd.ShowDialog();
            if (r != System.Windows.Forms.DialogResult.OK)
                return;

            var filePath = ofd.FileName;
            try
            {
                var mqo = MqoLoader.Load(filePath);
                Console.WriteLine("MQO = \n{0}", mqo.ToString());
            }
            catch (MqoLoaderException exp)
            {
                MessageBox.Show("ロードエラー, " + exp.GetOriginalException() + ", " + exp.GetLineNumber());
            }
        }
    }
}
