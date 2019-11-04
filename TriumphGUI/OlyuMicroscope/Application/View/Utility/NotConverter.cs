using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    public class NotConverter : System.Windows.Data.IValueConverter
    {
        /// <summary>
        /// Booleanを反転させる
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">(使用しない)</param>
        /// <param name="parameter">(使用しない)</param>
        /// <param name="culture">(使用しない)</param>
        /// <returns>変換された値</returns>
        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("NotConverter.Conver({0})", value.ToString());
            var b = (Boolean)value;
            return !b;
        }

        /// <summary>
        /// Booleanを反転させる
        /// </summary>
        /// <param name="value">バインディングされている値</param>
        /// <param name="targetType">(使用しない)</param>
        /// <param name="parameter">(使用しない)</param>
        /// <param name="culture">(使用しない)</param>
        /// <returns>変換された値</returns>
        public System.Object ConvertBack(System.Object value, Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("NotConverter.ConverBack({0})", value.ToString());
            var b = (Boolean)value;
            return !b;
        }
    }
}
