using System;
using DemoApp.Model;

namespace DemoApp.DataAccess
{
    /// <summary>
    /// CustomerRepositoryに、Cusomerが追加された際に、CusomerRepositoryによって呼び出されるイベントハンドラーの引数。
    /// 
    /// Event arguments used by CustomerRepository's CustomerAdded event.
    /// CustomerRepositoryのCustomerAddedイベントで使用されるイベント引数
    /// 
    /// イベント引数というのがよくわからない…
    /// CustomerAddedイベントが、NewCustomerをプロパティとして持っていればいいのではないか?
    /// →使われ方をみる限り、これは「イベントの引数」ではなく、「イベントハンドラーの引数」であるらしい。
    /// 全体的に、「Event」は、「イベント」ではなく、「イベントハンドラー」のことらしい。(MSの設計者は頭がおかしいのか?)
    /// </summary>
    public class CustomerAddedEventArgs : EventArgs
    {
        public CustomerAddedEventArgs(Customer newCustomer)
        {
            this.NewCustomer = newCustomer;
        }

        public Customer NewCustomer { get; private set; }
    }
}