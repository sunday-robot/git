using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus.LI.Triumph.Application.ViewModel;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    /// <summary>
    /// 重なり幅コンボボックスリスト選択のコンバーター(emOverlap⇔selectedIndex) 
    /// </summary>
    public class OverlapListConverter : System.Windows.Data.IValueConverter
    {
        /// <summary>
        /// emOverlap→selectedIndex変換を行います。 
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値。(emOverlap)</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。(emOverlapの型)</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>selectedIndex</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // UiDataの値が必要だがここから参照できない為ViewModelにある変換メソッドを使用
            return ViewModel.UiController.sUiController.Acquisition.ConvertToIntFromEmOverlap(value);
        }

        /// <summary>
        /// selectedIndex→emOverlap変換を行います。 
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値。(int)</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。(intの型)</param>
        /// <param name="parameter">使用するコンバーター パラメーター。</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>emOverlap</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // UiDataの値が必要だがここから参照できない為ViewModelにある変換メソッドを使用
            return (object)ViewModel.UiController.sUiController.Acquisition.ConvertToEmOverLapFromInt((int)value);
        }

    }
}
