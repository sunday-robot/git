using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataBindingLab
{
    public class Bid
    {
        private readonly int _Amount;
        private readonly User _Bidder;

        public int Amount
        {
            get { return _Amount; }
        }

        public User Bidder
        {
            get { return _Bidder; }
        }

        public Bid(int amount, User bidder)
        {
            _Amount = amount;
            _Bidder = bidder;
        }
    }
}
