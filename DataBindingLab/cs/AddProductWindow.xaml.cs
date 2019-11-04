using System;
using System.Windows;

namespace DataBindingLab
{
    /// <summary>
    /// オークションに出品する際に使用されるウィンドウ
    /// MainWindowのAdd Productボタンが押された際に生成され、
    /// 本ウィンドウのSubmitボタンが押された際にクローズ(やがて破棄)される
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