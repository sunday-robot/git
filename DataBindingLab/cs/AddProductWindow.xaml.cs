using System;
using System.Windows;

namespace DataBindingLab
{
    /// <summary>
    /// �I�[�N�V�����ɏo�i����ۂɎg�p�����E�B���h�E
    /// MainWindow��Add Product�{�^���������ꂽ�ۂɐ�������A
    /// �{�E�B���h�E��Submit�{�^���������ꂽ�ۂɃN���[�Y(�₪�Ĕj��)�����
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var item = new AuctionItem(
                "Type your description here",
                ProductCategory.DVDs,
                1,
                DateTime.Now,
                ((DataBindingLabApp)Application.Current).CurrentUser,
                SpecialFeatures.None);
            DataContext = item;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (AuctionItem)DataContext;
            ((DataBindingLabApp)Application.Current).AuctionItems.Add(item);
            Close();
        }

    }
}