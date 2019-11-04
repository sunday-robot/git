using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace DataBindingLab
{
    public partial class DataBindingLabApp : Application
    {
        private User _CurrentUser;
        private ObservableCollection<AuctionItem> _AuctionItems = new ObservableCollection<AuctionItem>();

        void AppStartup(object sender, StartupEventArgs args)
        {
            _CreateSampleData(out _CurrentUser, ref _AuctionItems);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public User CurrentUser {
            get { return _CurrentUser; }
            set { _CurrentUser = value; }
        }

        public ObservableCollection<AuctionItem> AuctionItems {
            get { return _AuctionItems; }
            set { _AuctionItems = value; }
        }

        private static void _CreateSampleData(out User currentUser, ref ObservableCollection<AuctionItem> auctionItems)
        {
            var userJohn = new User("John", 12, new DateTime(2003, 4, 20));
            var userMary = new User("Mary", 10, new DateTime(2000, 5, 2));
            var userAnna = new User("Anna", 5, new DateTime(2001, 9, 13));
            var userMike = new User("Mike", 13, new DateTime(1999, 11, 23));
            var userMark = new User("Mark", 15, new DateTime(2004, 6, 3));

            var camera = new AuctionItem(
                "Digital camera - good condition",
                ProductCategory.Electronics,
                300,
                new DateTime(2005, 8, 23),
                userAnna,
                SpecialFeatures.None);
            camera.AddBid(new Bid(310, userMike));
            camera.AddBid(new Bid(312, userMark));
            camera.AddBid(new Bid(314, userMike));
            camera.AddBid(new Bid(320, userMark));

            var snowBoard = new AuctionItem(
                "Snowboard and bindings",
                ProductCategory.Sports,
                120,
                new DateTime(2005, 7, 12),
                userMike,
                SpecialFeatures.Highlight);
            snowBoard.AddBid(new Bid(140, userAnna));
            snowBoard.AddBid(new Bid(142, userMary));
            snowBoard.AddBid(new Bid(150, userAnna));

            var insideCSharp = new AuctionItem(
                "Inside C#, second edition",
                ProductCategory.Books,
                10,
                new DateTime(2005, 5, 29),
                userJohn,
                SpecialFeatures.Color);
            insideCSharp.AddBid(new Bid(11, userMark));
            insideCSharp.AddBid(new Bid(13, userAnna));
            insideCSharp.AddBid(new Bid(14, userMary));
            insideCSharp.AddBid(new Bid(15, userAnna));

            var laptop = new AuctionItem(
                "Laptop - only 1 year old",
                ProductCategory.Computers,
                500,
                new DateTime(2005, 8, 15),
                userMark,
                SpecialFeatures.Highlight);
            laptop.AddBid(new Bid(510, userJohn));

            var setOfChairs = new AuctionItem(
                "Set of 6 chairs",
                ProductCategory.Home,
                120,
                new DateTime(2005, 2, 20),
                userMike,
                SpecialFeatures.Color);

            var myDVDCollection = new AuctionItem(
                "My DVD Collection",
                ProductCategory.DVDs,
                5,
                new DateTime(2005, 8, 3),
                userMary,
                SpecialFeatures.Highlight);
            myDVDCollection.AddBid(new Bid(6, userMike));
            myDVDCollection.AddBid(new Bid(8, userJohn));

            var tvDrama = new AuctionItem(
                "TV Drama Series",
                ProductCategory.DVDs,
                40,
                new DateTime(2005, 7, 28),
                userAnna,
                SpecialFeatures.None);
            tvDrama.AddBid(new Bid(42, userMike));
            tvDrama.AddBid(new Bid(45, userMark));
            tvDrama.AddBid(new Bid(50, userMike));
            tvDrama.AddBid(new Bid(51, userJohn));

            var squashRacket = new AuctionItem(
                "Squash racket",
                ProductCategory.Sports,
                60,
                new DateTime(2005, 4, 4),
                userMark,
                SpecialFeatures.Highlight);
            squashRacket.AddBid(new Bid(62, userMike));
            squashRacket.AddBid(new Bid(65, userAnna));

            currentUser = userJohn;

            auctionItems.Add(camera);
            auctionItems.Add(snowBoard);
            auctionItems.Add(insideCSharp);
            auctionItems.Add(laptop);
            auctionItems.Add(setOfChairs);
            auctionItems.Add(myDVDCollection);
            auctionItems.Add(tvDrama);
            auctionItems.Add(squashRacket);
        }
    }
}