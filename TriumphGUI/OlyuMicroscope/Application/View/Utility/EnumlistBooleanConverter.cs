//-----------------------------------------------------------------------
// <copyright file="EnumlistBooleanConverter.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
// Source history
// version      date        person      content
// 01.00        2011/04/05  R.Ito       Create
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    /// <summary>
    /// List&lt;enum&gt;をBooleanに変換するXAML用コンバーター
    /// <para>ViewModelのList&lt;enum&gt;をEnabledプロパティにバインドする場合等に使用する</para>
    /// </summary>
    public class EnumlistBooleanConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverterメンバ
        /// <summary>
        /// List&lt;enum&gt;をBooleanに変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            System.String parameterString = parameter as System.String;

            // XAMLにパラメーターが指定されていない場合は無効
            if (parameterString == null)
            {
                return System.Windows.DependencyProperty.UnsetValue;
            }

            // IList型に変換
            System.Collections.IList enumList = value as System.Collections.IList;

            // IListに変換出来ないなら無効
            if (enumList == null)
            {
                return System.Windows.DependencyProperty.UnsetValue;
            }

            // 長さが0ならfalseを返す
            if ( enumList.Count == 0)
            {
                return false;
            }

            // parameterで指定された文字列をEnum型に変換する
            System.Type enumType = enumList[0].GetType();
            System.Object parameterValue = Enum.Parse(enumType, parameterString);

            // IList内にparameterのEnumが存在すればTrueを返す
            return enumList.Contains(parameterValue);
        }

        /// <summary>
        /// BooleanをList&lt;enum&gt;に変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object ConvertBack(System.Object value, Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            // 現在はOneWayのプロパティにバインドする場合しか想定していないので考慮しない
            return false;
        }
        #endregion IValueConverterメンバ
    }
}
