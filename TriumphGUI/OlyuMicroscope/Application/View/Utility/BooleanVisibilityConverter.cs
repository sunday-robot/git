//-----------------------------------------------------------------------
// <copyright file="BooleanVisibilityConverter.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
// Source history
// version      date        person      content
// 01.00        2011/05/06  R.Ito       Create
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    /// <summary>
    /// BooleanをVisibilityに変換するXAML用コンバーター
    /// <para>ViewModelのenumをコントロールのVisibilityにバインドする場合等に使用する</para>
    /// </summary>
    public class BooleanVisibilityConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverterメンバ
        /// <summary>
        /// BooleanをVisibilityに変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.Equals(true))
            {
                // TrueならVisible
                return System.Windows.Visibility.Visible;
            }
            else if (value.Equals(false))
            {
                // FalseならCollapsed
                return System.Windows.Visibility.Collapsed;
            }

            return System.Windows.DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// VisibilityをBooleanに変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object ConvertBack(System.Object value, Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            // 現在はOneWayのプロパティにバインドする場合しか想定していないので考慮しない
            return System.Windows.DependencyProperty.UnsetValue;
        }
        #endregion IValueConverterメンバ
    }
}
