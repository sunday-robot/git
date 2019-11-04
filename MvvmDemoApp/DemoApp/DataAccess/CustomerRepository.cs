using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using DemoApp.Model;

namespace DemoApp.DataAccess
{
    /// <summary>
    /// Cusomerのリポジトリ(DBならテーブル?)
    /// 
    /// Represents a source of customers in the application.
    /// </summary>
    public class CustomerRepository
    {
        #region Fields

        private readonly List<Customer> _Customers;

        #endregion // Fields

        #region Constructor

        /// <summary>
        /// Creates a new repository of customers.
        /// </summary>
        /// <param name="customerDataFile">The relative path to an XML resource file that contains customer data.</param>
        public CustomerRepository(string customerDataFile)
        {
            _Customers = _LoadCustomers(customerDataFile);
        }

        #endregion Constructor

        #region Public Interface

        /// <summary>
        /// CustomerAddedEventハンドラーのリスト。
        /// (Customerが本クラスに追加されたとき、ここに登録したイベントハンドラーが呼ばれる。)
        /// Raised when a customer is placed into the repository.
        /// </summary>
        public event EventHandler<CustomerAddedEventArgs> CustomerAddedEventHandlers;

        /// <summary>
        /// Customerを追加し、その旨リスナーたちに知らせる。
        /// ただし、すでに追加済みの場合は何もしない。
        /// </summary>
        public void AddCustomer(Customer customer)
        {
            if (_Customers.Contains(customer))
                return;

            _Customers.Add(customer);

            if (this.CustomerAddedEventHandlers != null)
                this.CustomerAddedEventHandlers(this, new CustomerAddedEventArgs(customer));
        }

        /// <summary>
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <returns>
        /// Cusomerが追加済みかどうか
        /// </returns>
        public bool Contains(Customer customer)
        {
            return _Customers.Contains(customer);
        }

        /// <summary>
        /// </summary>
        /// <remarks>Customerリストの浅いコピー</remarks>
        public List<Customer> GetCustomers()
        {
            return new List<Customer>(_Customers);
        }

        #endregion // Public Interface

        #region Private Helpers

        private static List<Customer> _LoadCustomers(string customerDataFile)
        {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            using (Stream stream = GetResourceStream(customerDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from customerElem in XDocument.Load(xmlRdr).Element("customers").Elements("customer")
                     select new Customer(
                        (double)customerElem.Attribute("totalSales"),
                        (string)customerElem.Attribute("firstName"),
                        (string)customerElem.Attribute("lastName"),
                        (bool)customerElem.Attribute("isCompany"),
                        (string)customerElem.Attribute("email")
                         )).ToList();
        }

        private static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        #endregion // Private Helpers
    }
}