//-----------------------------------------------------------------------
// <copyright file="EnumVisibilityConverter.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
// Source history
// version      date        person      content
// 01.00        2011/04/21  R.Ito       Create
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    /// <summary>
    /// enumをVisibilityに変換するXAML用コンバーター
    /// <para>ViewModelのenumをコントロールのVisibilityにバインドする場合等に使用する</para>
    /// </summary>
    public class EnumVisibilityConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverterメンバ
        /// <summary>
        /// enumをVisibilityに変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            System.String parameterString = parameter as System.String;

            // XAMLでパラメーターが指定されていない場合
            if (parameterString == null)
            {
                // バインド失敗
                return System.Windows.DependencyProperty.UnsetValue;
            }

            // バインドされている値がEnumに存在しない場合
            if (Enum.IsDefined(value.GetType(), value) == false)
            {
                return System.Windows.DependencyProperty.UnsetValue;
            }

            System.Object parameterValue = Enum.Parse(value.GetType(), parameterString);

            if (parameterValue.Equals(value))
            {
                return System.Windows.Visibility.Visible;
            }
            else
            {
                return System.Windows.Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Visibilityをenumに変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object ConvertBack(System.Object value, Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            System.String parameterString = parameter as System.String;

            // XAMLでパラメーターを指定していなかった場合
            if (parameterString == null)
            {
                return System.Windows.DependencyProperty.UnsetValue;
            }

            // 表示以外の場合
            if (value.Equals(System.Windows.Visibility.Collapsed) || value.Equals(System.Windows.Visibility.Hidden))
            {
                // 列挙の0にあたる値を返す
                return Enum.ToObject(targetType, 0);
            }

            return Enum.Parse(targetType, parameterString);
        }
        #endregion IValueConverterメンバ
    }
}
