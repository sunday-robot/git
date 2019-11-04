using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;

namespace BftConverter
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

        static void test()
        {
            try
            {
                var bitmaps = BftLoader.Load(@"..\..\..\BCTY16.BFT", 0);
                for (int i = 0; i < bitmaps.Count; i++)
                {
                    var b = bitmaps[i];
                    var fileName = string.Format("{0:00}.bmp", i);
                    b.Save(fileName);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            test();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int transparentColorNumber;

            try
            {
                transparentColorNumber = int.Parse(this.textBox1.Text);
            }
            catch (System.FormatException _)
            {
                MessageBox.Show("透明色の番号を入力してください。");
                return;
            }
            var ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "|*.bft";
            ofd.ShowDialog();
            foreach (var fileName in ofd.FileNames)
            {
                var bitmaps = BftLoader.Load(fileName, transparentColorNumber);
                saveBitmaps(bitmaps, fileName);
            }
        }

        static void saveBitmaps(List<Bitmap> bitmaps, string originalFilePath /* 元になったファイルのパス */)
        {
            var directoryPath = System.IO.Path.GetDirectoryName(originalFilePath);
            var baseName = System.IO.Path.GetFileNameWithoutExtension(originalFilePath);
            var filePathFormat = System.IO.Path.Combine(directoryPath, baseName) + "_{0:00}.png";
            for (int i = 0; i < bitmaps.Count; i++)
            {
                var filePath = string.Format(filePathFormat, i);
                bitmaps[i].Save(filePath);
            }
        }
    }
}
