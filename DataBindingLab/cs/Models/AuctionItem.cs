using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataBindingLab
{
    public class AuctionItem : INotifyPropertyChanged
    {
        private string _Description;
        private int _StartPrice;
        private DateTime _StartDate;
        private ProductCategory _Category;
        private readonly User _Owner;
        private SpecialFeatures _SpecialFeatures;
        private readonly ObservableCollection<Bid> _Bids;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                _InvokePropertyChangedEventHandlers("Description");
            }
        }

        public int StartPrice
        {
            get { return _StartPrice; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be positive");
                }
                _StartPrice = value;
                _InvokePropertyChangedEventHandlers("StartPrice");
                _InvokePropertyChangedEventHandlers("CurrentPrice");
            }
        }

        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                _InvokePropertyChangedEventHandlers("StartDate");
            }
        }

        public ProductCategory Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
                _InvokePropertyChangedEventHandlers("Category");
            }
        }

        public User Owner
        {
            get { return _Owner; }
        }

        public SpecialFeatures SpecialFeatures
        {
            get { return _SpecialFeatures; }
            set
            {
                _SpecialFeatures = value;
                _InvokePropertyChangedEventHandlers("SpecialFeatures");
            }
        }

        public ReadOnlyObservableCollection<Bid> Bids
        {
            get { return new ReadOnlyObservableCollection<Bid>(_Bids); }
        }

        public int CurrentPrice
        {
            get
            {
                if (_Bids.Count == 0)
                    return _StartPrice;
                var lastBid = _Bids[_Bids.Count - 1];
                return lastBid.Amount;
            }
        }

        public AuctionItem(string description, ProductCategory category, int startPrice, DateTime startDate, User owner, SpecialFeatures specialFeatures)
        {
            _Description = description;
            _Category = category;
            _StartPrice = startPrice;
            _StartDate = startDate;
            _Owner = owner;
            _SpecialFeatures = specialFeatures;
            _Bids = new ObservableCollection<Bid>();
        }

        // Exposing Bids as a ReadOnlyObservableCollection and adding an AddBid method so that CurrentPrice 
        // is updated when a new Bid is added
        public void AddBid(Bid bid)
        {
            _Bids.Add(bid);
            _InvokePropertyChangedEventHandlers("CurrentPrice");
        }

        private void _InvokePropertyChangedEventHandlers(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public enum ProductCategory
    {
        Books,
        Computers,
        DVDs,
        Electronics,
        Home,
        Sports,
    }

    public enum SpecialFeatures
    {
        None,
        Color,
        Highlight
    }

}

