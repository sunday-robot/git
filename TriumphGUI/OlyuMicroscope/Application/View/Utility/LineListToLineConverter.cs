//-----------------------------------------------------------------------
// <copyright file="LineListToLineConverter.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
// Source history
// version      date        person      content
// 01.00        2011/04/28  R.Ito       Create
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    /// <summary>
    /// LineのListをLineに変換するXAML用コンバーター
    /// </summary>
    public class LineListToLineConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverterメンバ
        /// <summary>
        /// LineのListをLineに変換
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">バインディングプロパティの型</param>
        /// <param name="parameter">XAMLで指定するコンバーターパラメーター</param>
        /// <param name="culture">使用するカルチャ情報</param>
        /// <returns>変換された値</returns>
        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            Int32 i32Index;

            // パラメーターが数値に変換できないなら
            if (!Int32.TryParse(parameter as String, out i32Index))
            {
                // バインド失敗
                return System.Windows.DependencyProperty.UnsetValue;
            }

            System.Collections.Generic.List<System.Windows.Shapes.Line> lineArray = value as System.Collections.Generic.List<System.Windows.Shapes.Line>;

            // 値がList<Line>でなかったら
            if (lineArray == null)
            {
                // バインド失敗
                return System.Windows.DependencyProperty.UnsetValue;
            }

            // パラメーターで指定したインデックスが存在しなかったら
            if (lineArray.Count <= i32Index)
            {
                // バインド失敗
                return System.Windows.DependencyProperty.UnsetValue;
            }

            return lineArray[i32Index];
        }

        /// <summary>
        /// LineをLineのListに変換
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
