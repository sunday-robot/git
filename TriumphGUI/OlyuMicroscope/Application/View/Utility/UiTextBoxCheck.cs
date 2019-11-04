//-----------------------------------------------------------------------
// <copyright file="UiTextBoxCheck.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
// Source history
// version      date        person      content
// 01.00        2011/08/30  Zhao        Create
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus.Mis.Core.Logging;

using System.Windows;
using System.Windows.Input;

namespace Olympus.LI.Triumph.Application.View.Utility
{
    /// <summary>
    /// アプリケーションレイヤーにおけるテキストボックスの入力チェッククラス
    /// </summary>
    public static class UiTextBoxCheck
    {
        #region 範囲チェック
        /// <summary>
        /// 整数範囲チェック
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="minValue">下限値</param>
        /// <param name="maxValue">上限値</param>
        /// <param name="value">チェック値（文字列）</param>
        /// <returns></returns>
        public static bool IsInRangedNumeric(long minValue, long maxValue, string value)
        {
            // 戻り値
            bool result = true;

            // 文字列を整数に変換
            long NumericData = 0;
            bool bRet = long.TryParse(value, out NumericData);
            if (bRet)
            {
                // 範囲外
                if (minValue > NumericData || NumericData > maxValue)
                {
                    Logger.DebugLog(String.Format("Input Data Check[{0} is out of range [{1},{2}]]", value, minValue, maxValue));
                    result = false;
                }
                else
                {
                    // 範囲内
                    Logger.DebugLog(String.Format("Input Data Check[{0} is in ranged [{1},{2}]]", value, minValue, maxValue));
                }
            }
            else
            {
                // 整数ではない
                Logger.DebugLog(String.Format("Input Data Check[{0} is not numeric.]]", value));
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 実数範囲チェック
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="minValue">下限値</param>
        /// <param name="maxValue">上限値</param>
        /// <param name="value">チェック値（文字列）</param>
        /// <returns></returns>
        public static bool IsInRangedDecimal(double minValue, double maxValue, string value)
        {
            // 戻り値
            bool result = true;

            // 文字列を実数に変換
            double DecimalData = 0.0d;
            bool bRet = Infrastructure.LocalizeUtil.NumberConversionUtil.DoubleTryParse(value, out DecimalData);
            if (bRet)
            {
                // 範囲外
                if (minValue > DecimalData || DecimalData > maxValue)
                {
                    Logger.DebugLog(String.Format("Input Data Check[{0} is out of range [{1},{2}]]", value, minValue, maxValue));
                    result = false;
                }
                else
                {
                    // 範囲内
                    Logger.DebugLog(String.Format("Input Data Check[{0} is in ranged [{1},{2}]]", value, minValue, maxValue));
                }
            }
            else
            {
                // 実数ではない
                Logger.DebugLog(String.Format("Input Data Check[{0} is not decimal.]]", value));
                result = false;
            }

            return result;
        }

        #endregion 範囲チェック

        #region キー入力チェック
        #region Keyの説明
        /// Key.D0～Key.D9はF1～F9
        /// Key.NumPad0～Key.NumPad9は数値キーパッドの 0～9 キー
        /// Key.OemMinusはOEM マイナス キー
        /// Key.Decimalは小数点キー
        #endregion Keyの説明

        /// <summary>
        /// 押下されたKeyが正整数かのチェック
        /// </summary>
        /// <param name="e">KeyEventArgsイベント</param>
        /// <returns></returns>
        public static bool IsNumericPositiveField(System.Windows.Input.KeyEventArgs e)
        {
            // 戻り値
            bool bRet = false;

            // キー値チェック
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                if (Keyboard.Modifiers != ModifierKeys.Shift)
                {
                    bRet = true;
                }
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.End || e.Key == Key.Home || e.Key == Key.Delete || e.Key == Key.Left
                 || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                bRet = true;
            }

            return bRet;
        }

        /// <summary>
        /// 押下されたKeyは整数かのチェック
        /// </summary>
        /// <param name="e">KeyEventArgsイベント</param>
        /// <returns></returns>
        public static bool IsNumericField(System.Windows.Input.KeyEventArgs e)
        {
            // 戻り値
            bool bRet = false;

            // キー値チェック
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                if (Keyboard.Modifiers != ModifierKeys.Shift)
                {
                    bRet = true;
                }
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.End || e.Key == Key.Home || e.Key == Key.Delete || e.Key == Key.Left
                 || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.OemMinus || e.Key == Key.Subtract || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                bRet = true;
            }

            return bRet;
        }

        /// <summary>
        /// 押下されたKeyが実数のチェック
        /// </summary>
        /// <param name="e">KeyEventArgsイベント</param>
        /// <returns></returns>
        public static bool IsDecimalField(System.Windows.Input.KeyEventArgs e)
        {
            // 戻り値
            bool bRet = false;

            // キー値チェック
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                if (Keyboard.Modifiers != ModifierKeys.Shift)
                {
                    bRet = true;
                }
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.End || e.Key == Key.Home || e.Key == Key.Delete || e.Key == Key.Left
                || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.OemMinus || e.Key == Key.Subtract || e.Key == Key.OemPeriod || e.Key == Key.Decimal || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                bRet = true;
            }

            return bRet;
        }

        /// <summary>
        /// 押下されたKeyが正実数かのチェック
        /// </summary>
        /// <param name="e">KeyEventArgsイベント</param>
        /// <returns></returns>
        public static bool IsDecimalPositiveField(System.Windows.Input.KeyEventArgs e)
        {
            // 戻り値
            bool bRet = false;

            // キー値チェック
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                if (Keyboard.Modifiers != ModifierKeys.Shift)
                {
                    bRet = true;
                }
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab || e.Key == Key.Back || e.Key == Key.End || e.Key == Key.Home || e.Key == Key.Delete || e.Key == Key.Left
                 || e.Key == Key.Right || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.OemPeriod || e.Key == Key.Decimal || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                bRet = true;
            }

            return bRet;
        }

        /// <summary>
        /// 押下されたKeyがGRR用文字列の禁則文字でないかのチェック
        /// </summary>
        /// <param name="e">KeyEventArgsイベント</param>
        /// <returns></returns>
        public static bool IsGRRStringField(System.Windows.Input.KeyEventArgs e)
        {
            // 戻り値
            bool bRet = true;

            if (e.Key == Key.Tab || e.Key == Key.OemComma || e.Key == Key.OemSemicolon || e.Key == Key.OemQuotes || e.Key == Key.OemBackslash
                || e.Key == Key.Return || e.Key == Key.Enter || e.Key == Key.Space || e.Key == Key.LineFeed || e.Key == Key.Separator || e.Key == Key.OemPlus)
            {
                bRet = false;
            }

            return bRet;
        }

        #endregion キー入力チェック

        #region 小数部桁数チェック
        /// <summary>
        /// 文字列が適切な精度(小数部桁数)の数値形式かどうかを返す。
        /// (入力タイプとして数値(DecimalPositiveなど)が指定されたValidateTextBoxの入力チェック用のメソッド。)
        /// </summary>
        /// <param name="s">チェック対象の文字列</param>
        /// <param name="maxDecimalPartLength">小数部の最大桁数</param>
        /// <returns>true:適切な数値形式である, false:数値として解析できないか、小数部の桁数が多すぎる</returns>
        public static Boolean IsValidNumberString(String s, Int32 maxDecimalPartLength)
        {
            if (s.Length == 0)
            {
                return true;    // 空文字列は数値形式とはいえないが入力としてはOK
            }
            if (s.Equals("-"))
            {
                return true;    // "-"は数値形式とはいえないが、入力途中としては許容しなければならない
            }

            var numberFormat = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;

            // 文字列が数値としてパーズできるかどうかチェックする(小数点が2つ以上入力された場合などを考慮したチェック)
            var style = System.Globalization.NumberStyles.AllowDecimalPoint    // 小数点の入力を認める
                | System.Globalization.NumberStyles.AllowLeadingSign;           // 符号の入力を認める(ValidateTextBoxでは"-"のみで、"+"はありえない)
            double v;
            if (!Double.TryParse(s, style, numberFormat, out v))
            {
                return false;   // 数値形式で無いのでNG
            }

            // 小数部の桁数をチェック
            var index = s.IndexOf(numberFormat.NumberDecimalSeparator);
            if (index < 0)
            {
                return true;    // 少数点が無いのであればOK
            }
            if (maxDecimalPartLength == 0)
            {
                return false;   // 小数部桁数が0なのに小数点が含まれているのでNG
            }
            if (s.Length - (index + 1) > maxDecimalPartLength)
            {
                return false;   // 小数部の桁数が多いのでNG
            }

            return true;
        }

        #endregion 小数部桁数チェック
    }
}
