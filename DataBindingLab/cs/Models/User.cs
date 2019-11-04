using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataBindingLab
{
    public class User
    {
        private readonly string name;
        private int rating;
        private readonly DateTime memberSince;

        #region Property Getters and Setters
        public string Name
        {
            get { return name; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public DateTime MemberSince
        {
            get { return memberSince; }
        }
        #endregion

        public User(string name, int rating, DateTime memberSince)
        {
            this.name = name;
            this.rating = rating;
            this.memberSince = memberSince;
        }
    }

}
