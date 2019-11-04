using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using DemoApp.DataAccess;
using DemoApp.Properties;
using DemoApp.Model;

namespace DemoApp.ViewModel
{
    /// <summary>
    /// CustomerViewModelのコンテナ。
    /// 
    /// Customerの選択状態も保持する。
    /// 
    /// Represents a container of CustomerViewModel objects
    /// that has support for staying synchronized with the
    /// CustomerRepository.  This class also provides information
    /// related to multiple selected customers.
    /// </summary>
    public class AllCustomersViewModel : WorkspaceViewModel
    {
        #region Public Interface    // AllCustomersView用のインターフェイス(XAMLからしか参照されない…)

        /// <summary>
        /// Returns a collection of all the CustomerViewModel objects.
        /// </summary>
        public ObservableCollection<CustomerViewModel> AllCustomers { get; private set; }

        /// <summary>
        /// Returns the total sales sum of all selected customers.
        /// </summary>
        public double TotalSelectedSales
        {
            get
            {
                return this.AllCustomers.Sum(custVM => custVM.IsSelected ? custVM.TotalSales : 0.0);
            }
        }

        #endregion Public Interface

        #region Fields

        readonly CustomerRepository _CustomerRepository;

        #endregion // Fields

        #region Constructor

        public AllCustomersViewModel(CustomerRepository customerRepository)
        {
            base.DisplayName = Strings.AllCustomersViewModel_DisplayName;

            _CustomerRepository = customerRepository;

            // Subscribe for notifications of when a new customer is saved.
            _CustomerRepository.CustomerAddedEventHandlers += this.OnCustomerAddedToRepository;

            // Populate the AllCustomers collection with CustomerViewModels.
            var all = new ObservableCollection<CustomerViewModel>();
            foreach (var cust in customerRepository.GetCustomers())
            {
                var cvm = new CustomerViewModel(cust, customerRepository);
                cvm.PropertyChanged += CustomerViewModelPropertyChangedEventHandler;
                all.Add(cvm);
            }
            all.CollectionChanged += this.AllCustomersCollectionChangedEventHandler;
            this.AllCustomers = all;
        }

        #endregion // Constructor

        #region  Base Class Overrides

        protected override void OnDispose()
        {
            foreach (CustomerViewModel custVM in this.AllCustomers)
                custVM.Dispose();

            this.AllCustomers.Clear();
            this.AllCustomers.CollectionChanged -= this.AllCustomersCollectionChangedEventHandler;

            _CustomerRepository.CustomerAddedEventHandlers -= this.OnCustomerAddedToRepository;
        }

        #endregion // Base Class Overrides

        #region Event Handling MethodsDemoApp.ViewModel.AllCustomersViewModel.OnDispose()

        /// <summary>
        /// this.AllCustomersにCustomerViewModelが追加/削除された際に呼ばれるイベントハンドラー。
        /// CustomerViewModelが追加された場合は、CustomerViewModelに、PropertyChangedイベントハンドラーを登録し、
        /// 削除された場合は、イベントハンドラーの登録を解除する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AllCustomersCollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (CustomerViewModel custVM in e.NewItems)
                    custVM.PropertyChanged += this.CustomerViewModelPropertyChangedEventHandler;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (CustomerViewModel custVM in e.OldItems)
                    custVM.PropertyChanged -= this.CustomerViewModelPropertyChangedEventHandler;
        }

        /// <summary>
        /// this.AllCustomersの要素CustomerViewModelのプロパティが更新された際に呼ばれるイベントハンドラー。
        /// プロパティIsSelectedの更新時に、本ViewModelのTotalSelectedSalesのPropertyChangedイベントを発生させるだけ。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CustomerViewModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            // When a customer is selected or unselected, we must let the
            // world know that the TotalSelectedSales property has changed,
            // so that it will be queried again for a new value.
            if (e.PropertyName == "IsSelected")
                this.RaisePropertyChangedEvent("TotalSelectedSales");
        }

        void OnCustomerAddedToRepository(object sender, CustomerAddedEventArgs e)
        {
            var viewModel = new CustomerViewModel(e.NewCustomer, _CustomerRepository);
            this.AllCustomers.Add(viewModel);
        }

        #endregion // Event Handling Methods
    }
}