using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DemoApp.Properties;

namespace DemoApp.Model
{
    /// <summary>
    /// 会社の顧客を表現するもの。
    /// 
    /// このクラスは組み込みのバリデートロジックを含む。
    /// CusomerViewModelでラップされている。
    /// これは、WPFユーザーインターフェイスによって簡単に表示、編集されることを可能にする。
    /// 
    /// (秋山メモ)
    /// このアプリでは、顧客としては個人と法人の2種類存在し、区別している。
    /// 通常は抽象クラスAbstractCustomerを継承した個人顧客、法人顧客という具象クラスを作るところだが、
    /// このアプリではそのようにしていない。
    /// 理由は示されてはいないが、MVVM説明用のため、あえて通常とは異なる設計にしているらしい(理由に気付いたが忘れてしまった…)
    /// 
    /// Represents a customer of a company.  This class
    /// has built-in validation logic. It is wrapped
    /// by the CustomerViewModel class, which enables it to
    /// be easily displayed and edited by a WPF user interface.
    /// </summary>
    public class Customer : IDataErrorInfo
    {
        #region Constructor

        public Customer()
        {
        }

        public Customer(
            double totalSales,
            string firstName,
            string lastName,
            bool isCompany,
            string email)
        {
            TotalSales = totalSales;
            FirstName = firstName;
            LastName = lastName;
            IsCompany = isCompany;
            EMailAddress = email;
        }

        #endregion

        #region Properties

        public string EMailAddress { get; set; }

        /// <summary>
        /// Gets/sets the customer's first name.  If this customer is a 
        /// company, this value stores the company's name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets/sets whether the customer is a company or a person.
        /// The default value is false.
        /// </summary>
        public bool IsCompany { get; set; }

        /// <summary>
        /// Gets/sets the customer's last name.  If this customer is a 
        /// company, this value is not set.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Returns the total amount of money spent by the customer.
        /// </summary>
        public double TotalSales { get; private set; }

        #endregion Properties

        #region IDataErrorInfo Members // インターフェイスIDataErrorInfoの実装

        // 常にnullを返すというのは???
        string IDataErrorInfo.Error { get { return null; } }

        // ↓プロパティの名前でアクセスするという残念すぎる仕様。こんなものが標準ライブラリとは…
        // 言語仕様を拡張した方がよかったのでは?(そこまで自信がなかったということか?)

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "Email":
                        return _ValidateEmail(EMailAddress);
                    case "FirstName":
                        return _ValidateFirstName(FirstName);
                    case "LastName":
                        return _ValidateLastName(LastName, IsCompany);
                    default:
                        return null;
                }
            }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                string error;
                error = _ValidateEmail(EMailAddress);
                if (error != null)
                    return true;
                error = _ValidateFirstName(FirstName);
                if (error != null)
                    return true;
                error = _ValidateLastName(LastName, IsCompany);
                if (error != null)
                    return true;
                return false;
            }
        }

        #endregion Validation

        #region Validation Utilities

        private static string _ValidateEmail(string emailAddress)
        {
            if (_IsStringMissing(emailAddress))
                return Strings.Customer_Error_MissingEmail;
            if (!_IsValidEmailAddress(emailAddress))
                return Strings.Customer_Error_InvalidEmail;
            return null;
        }

        private static string _ValidateFirstName(string firstName)
        {
            if (_IsStringMissing(firstName))
                return Strings.Customer_Error_MissingFirstName;
            return null;
        }

        private static string _ValidateLastName(string lastName, Boolean isCompany)
        {
            if (isCompany)
            {
                if (!_IsStringMissing(lastName))
                    return Strings.Customer_Error_CompanyHasNoLastName;
            }
            else
            {
                if (_IsStringMissing(lastName))
                    return Strings.Customer_Error_MissingLastName;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool _IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        private static bool _IsValidEmailAddress(string email)
        {
            if (_IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        #endregion Validation Utilities
    }
}