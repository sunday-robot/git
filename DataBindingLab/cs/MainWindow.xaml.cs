using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace DataBindingLab
{
    public partial class MainWindow : Window
    {
        readonly CollectionViewSource _ListingDataView;

        public MainWindow()
        {
            InitializeComponent();
            _ListingDataView = (CollectionViewSource)Resources["listingDataView"];
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            new AddProductWindow().ShowDialog();
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void GroupingCheckBox_Checked(object sender, RoutedEventArgs args)
        {
            // This groups the items in the view by the property "Category"
            _ListingDataView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }


        void GroupingCheckBox_Unchecked(object sender, RoutedEventArgs args)
        {
            _ListingDataView.GroupDescriptions.Clear();
        }

        void SortingCheckBox_Checked(object sender, RoutedEventArgs args)
        {
            // This sorts the items first by Category and within each Category,
            // by StartDate. Notice that because Category is an enumeration,
            // the order of the items is the same as in the enumeration declaration
            _ListingDataView.SortDescriptions.Add(
                new SortDescription("Category", ListSortDirection.Ascending));
            _ListingDataView.SortDescriptions.Add(
                new SortDescription("StartDate", ListSortDirection.Ascending));
        }

        void SortingCheckBox_Unchecked(object sender, RoutedEventArgs args)
        {
            _ListingDataView.SortDescriptions.Clear();
        }


        void FilteringCheckBox_Checked(object sender, RoutedEventArgs args)
        {
            _ListingDataView.Filter += new FilterEventHandler(ShowOnlyBargainsFilter);
        }

        void FilteringCheckBox_Unchecked(object sender, RoutedEventArgs args)
        {
            _ListingDataView.Filter -= new FilterEventHandler(ShowOnlyBargainsFilter);
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ShowOnlyBargainsFilter(object sender, FilterEventArgs e)
        {
            // Filter out products with price 25 or above
            e.Accepted = ((AuctionItem)e.Item).CurrentPrice < 25;
        }
    }
}
