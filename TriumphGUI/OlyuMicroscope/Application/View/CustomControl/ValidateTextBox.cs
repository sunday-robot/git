//-----------------------------------------------------------------------
// <copyright file="ValidateTextBox.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
//-----------------------------------------------------------------------
// Source history
// version      date        person      content
// 01.00        2011/09/02  R.Ito       Create
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus.LI.Triumph.Application.ViewModel;
using System.Collections;

namespace Olympus.LI.Triumph.Application.View.CustomControl
{
    /// <summary>
    /// 入力制限付きテキストボックス
    /// </summary>
    /// <remarks>
    /// このテキストボックスで行う機能は以下
    /// <para>入力種別に応じてKeyDown時に入力文字を制限する。IMEがONだと正しく判定出来ないため、必要に応じてXAMLに InputMethod.IsInputMethodEnabled="False"　を設定すること</para>
    /// <para>入力種別と範囲の有無に応じてTextChanged時にエラーチェックを行う</para>
    /// <para>エラー時には背景色を変える</para>
    /// <para>エラー時にはIsInputErrorプロパティにTrueが返る</para>
    /// </remarks>
    public class ValidateTextBox : System.Windows.Controls.TextBox
    {
        #region enum
        /// <summary>
        /// デフォルト値を設定する契機
        /// </summary>
        /// <remarks>
        /// LostFocus時のみでTextChange時に設定する事は無い
        /// </remarks>
        public enum emDefaultSetReason
        {
            /// <summary>
            /// 全て
            /// </summary>
            All,

            /// <summary>
            /// 数値変換に失敗した時のみ
            /// </summary>
            NumericParseError,

            /// <summary>
            /// 範囲チェックに失敗した時のみ
            /// </summary>
            RangeCheckError,

            /// <summary>
            /// 常にデフォルト値はセットしない
            /// </summary>
            None,
        }

        #endregion enum

        #region Const
        /// <summary>
        /// DefaultValueをバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public static readonly System.Windows.DependencyProperty DefaultValueProperty = System.Windows.DependencyProperty.Register(
            "DefaultValue",     // プロパティ名
            typeof(String),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata("1", // デフォルト値
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)); // ModeのデフォルトをToWayに

        /// <summary>
        /// RangeMinをバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public static readonly System.Windows.DependencyProperty RangeMinProperty = System.Windows.DependencyProperty.Register(
            "RangeMin",     // プロパティ名
            typeof(Double),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata(0d, // デフォルト値
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,  // ModeのデフォルトをToWayに
                _OnRangeMinPropertyChanged));    // プロパティ変更時に呼ばれるコールバックメソッドを設定

        /// <summary>
        /// RangeMaxをバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public static readonly System.Windows.DependencyProperty RangeMaxProperty = System.Windows.DependencyProperty.Register(
            "RangeMax",     // プロパティ名
            typeof(Double),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata(0d, // デフォルト値
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,  // ModeのデフォルトをToWayに
                _OnRangeMaxPropertyChanged));    // プロパティ変更時に呼ばれるコールバックメソッドを設定

        /// <summary>
        /// IsInputErrorをバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public static readonly System.Windows.DependencyProperty IsInputErrorProperty = System.Windows.DependencyProperty.Register(
            "IsInputError",     // プロパティ名
            typeof(Boolean),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata(false, // デフォルト値
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)); // ModeのデフォルトをToWayに

        /// <summary>
        /// Tagをバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public new static readonly System.Windows.DependencyProperty TagProperty = System.Windows.DependencyProperty.Register(
            "Tag",     // プロパティ名
            typeof(Object),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata(null,  // デフォルト値
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)); // ModeのデフォルトをToWayに

        /// <summary>
        /// InputTypeをバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public static readonly System.Windows.DependencyProperty InputTypeProperty = System.Windows.DependencyProperty.Register(
            "InputType",     // プロパティ名
            typeof(emInputType),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata(emInputType.String, // デフォルト値
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));  // ModeのデフォルトをToWayに

        /// <summary>
        /// MaxNumberOfDecimalPlaces(小数部桁数)をバインディング出来るようにするために依存関係プロパティとするための設定
        /// </summary>
        public static readonly System.Windows.DependencyProperty MaxNumberOfDecimalPlacesProperty = System.Windows.DependencyProperty.Register(
            "MaxNumberOfDecimalPlaces",     // プロパティ名
            typeof(Int32),    // プロパティの型
            typeof(ValidateTextBox),　 // コントロールの型
            new System.Windows.FrameworkPropertyMetadata(Int32.MaxValue, // デフォルト値(事実上、小数部桁数制限なし)
                System.Windows.FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));  // ModeのデフォルトをToWayに

        /// <summary>
        /// キーコードと文字の対応表
        /// <remarks>
        /// 数値入力時のチェック用なので、文字は数字と"-"、"."しかない。
        /// </remarks>
        /// </summary>
        static private Hashtable _KeyCodeToChar = new Hashtable() {
            {System.Windows.Input.Key.D0, '0'},
            {System.Windows.Input.Key.D1, '1'},
            {System.Windows.Input.Key.D2, '2'},
            {System.Windows.Input.Key.D3, '3'},
            {System.Windows.Input.Key.D4, '4'},
            {System.Windows.Input.Key.D5, '5'},
            {System.Windows.Input.Key.D6, '6'},
            {System.Windows.Input.Key.D7, '7'},
            {System.Windows.Input.Key.D8, '8'},
            {System.Windows.Input.Key.D9, '9'},
            {System.Windows.Input.Key.OemMinus, '-'},
            {System.Windows.Input.Key.OemPeriod, '.'},

            {System.Windows.Input.Key.NumPad0, '0'},
            {System.Windows.Input.Key.NumPad1, '1'},
            {System.Windows.Input.Key.NumPad2, '2'},
            {System.Windows.Input.Key.NumPad3, '3'},
            {System.Windows.Input.Key.NumPad4, '4'},
            {System.Windows.Input.Key.NumPad5, '5'},
            {System.Windows.Input.Key.NumPad6, '6'},
            {System.Windows.Input.Key.NumPad7, '7'},
            {System.Windows.Input.Key.NumPad8, '8'},
            {System.Windows.Input.Key.NumPad9, '9'},
            {System.Windows.Input.Key.Subtract, '-'},
            {System.Windows.Input.Key.Decimal, '.'},
        };

        #endregion Const

        #region Member(CLR プロパティ)
        /// <summary>
        /// 範囲チェック有無
        /// </summary>
        private Boolean _blnIsRangeCheck = false;

        /// <summary>
        /// デフォルト値設定契機
        /// </summary>
        private emDefaultSetReason _defaultSetReason = emDefaultSetReason.All;

        #endregion Member(CLR プロパティ)

        #region Member(内部制御用)
        /// <summary>
        /// 数値変換エラー(フォーカスロスト時のエラー値リセット処理で参照される)
        /// </summary>
        private Boolean _blnParseError;

        /// <summary>
        /// 範囲チェックエラー(フォーカスロスト時のエラー値リセット処理で参照される)
        /// </summary>
        private Boolean _blnRangeError;

        /// <summary>
        /// 数値入力時のチェック用に使用する文字列。
        /// stringや、GRRStringの場合は使用されない。
        /// <remarks>
        /// OnPreviewKeyDown()で数値入力チェックを行っているが、以下のような設定が行われていると、
        /// ViewModelのgetterが呼ばれてしまい、適切なチェックができないため、本文字列でチェックする。
        /// ・Text="{Binding xxx, UpdateSourceTrigger=PropertyChanged}"のように設定されている。
        /// ・ViewModel側のプロパティのgetterが、setterでセットされたものとは異なる文字列を返すことがある。
        /// </remarks>
        /// </summary>
        private string _TextForNumericalValidation;

        #endregion Member(内部制御用)

        #region Contrtactor
        /// <summary>
        /// staticコンストラクタ
        /// </summary>
        static ValidateTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ValidateTextBox), new System.Windows.FrameworkPropertyMetadata(typeof(System.Windows.Controls.TextBox)));
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ValidateTextBox()
        {
            // コンテキストメニューを無効にする
            this.ContextMenu = null;

            // ドラッグ＆ドロップを不可にする
            this.AllowDrop = false;
        }
        #endregion Contrtactor

        #region Public Property(Binding不可　XAMLに直接書くことのみ設定可能)
        /// <summary>
        /// 範囲チェック有無
        /// </summary>
        public Boolean IsRangeCheck
        {
            get { return this._blnIsRangeCheck; }
            set { this._blnIsRangeCheck = value; }
        }

        /// <summary>
        /// デフォルト値設定契機
        /// </summary>
        /// <remarks>
        /// InputType=Numeric/NumericPositive/Decimal/DecimalPositiveのコントロールで
        /// フォーカスが外れたとき、どの理由ならデフォルト値を設定するかを持つ
        /// 何も設定しない場合の規定値はAll(どの契機でもエラーになったらデフォルト値を設定)
        /// </remarks>
        public emDefaultSetReason DefaultSetReason
        {
            get { return this._defaultSetReason; }
            set { this._defaultSetReason = value; }
        }

        #endregion Public Property(Binding不可　XAMLに直接書くことのみ設定可能)

        #region Public 依存関係プロパティ（Binding可能なプロパティ）
        /// <summary>
        /// デフォルト値
        /// </summary>
        /// <remarks>
        /// InputType=Numeric/NumericPositive/Decimal/DecimalPositiveのコントロールで
        /// 数値として認識出来ない値でフォーカスを外れたときに設定するデフォルト値
        /// 何も設定しない場合の規定値は"1"
        /// </remarks>
        public String DefaultValue
        {
            get { return (String)this.GetValue(DefaultValueProperty); }
            set { this.SetValue(DefaultValueProperty, value); }
        }

        /// <summary>
        /// 範囲最小値
        /// </summary>
        public Double RangeMin
        {
            get { return (Double)this.GetValue(RangeMinProperty); }
            set { this.SetValue(RangeMinProperty, value); }
        }

        /// <summary>
        /// 範囲最大値
        /// </summary>
        public Double RangeMax
        {
            get { return (Double)this.GetValue(RangeMaxProperty); }
            set { this.SetValue(RangeMaxProperty, value); }
        }

        /// <summary>
        /// 入力エラー発生中かどうか
        /// </summary>
        public Boolean IsInputError
        {
            get { return (Boolean)this.GetValue(IsInputErrorProperty); }
            set { this.SetValue(IsInputErrorProperty, value); }
        }

        /// <summary>
        /// エラー情報を格納するTagプロパティ
        /// </summary>
        /// <remarks>
        /// Tagプロパティはそのままではバインド出来ないので依存関係プロパティとしてnewキーワードで隠蔽して再定義する
        /// <para>エラー無し:"0"</para>
        /// <para>エラー有り:"1"</para>
        /// </remarks>
        public new Object Tag
        {
            get { return (Object)this.GetValue(TagProperty); }
            set { this.SetValue(TagProperty, value); }
        }

        /// <summary>
        /// 入力種別
        /// </summary>
        public emInputType InputType
        {
            get { return (emInputType)this.GetValue(InputTypeProperty); }
            set { this.SetValue(InputTypeProperty, value); }
        }

        /// <summary>
        /// 小数部桁数の最大値
        /// </summary>
        public Int32 MaxNumberOfDecimalPlaces
        {
            get { return (Int32)this.GetValue(MaxNumberOfDecimalPlacesProperty); }
            set { this.SetValue(MaxNumberOfDecimalPlacesProperty, value); }
        }

        #endregion Public 依存関係プロパティ（Binding可能なプロパティ）

        #region Protected Method（基底処理の拡張）

        #region OnPreviewKeyDown
        /// <summary>
        /// OnPreviewKeyDown
        /// </summary>
        /// <param name="e">キーダウンイベント</param>
        protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            // *********************************************************************
            // IMEがONだと正しく判定出来ないので、数字入力のテキストボックスの場合は
            // XAMLで InputMethod.IsInputMethodEnabled="False" を指定する事
            // *********************************************************************

            Boolean blnCheckResult = false;

            switch ((emInputType)this.InputType)
            {
                case emInputType.Numeric:
                    // 整数チェック
                    blnCheckResult = View.Utility.UiTextBoxCheck.IsNumericField(e);
                    break;

                case emInputType.NumericPositive:
                    // 正整数チェック
                    blnCheckResult = View.Utility.UiTextBoxCheck.IsNumericPositiveField(e);
                    break;

                case emInputType.Decimal:
                    // 実数チェック
                    blnCheckResult = View.Utility.UiTextBoxCheck.IsDecimalField(e);
                    break;

                case emInputType.DecimalPositive:
                    // 正実数チェック
                    blnCheckResult = View.Utility.UiTextBoxCheck.IsDecimalPositiveField(e);
                    break;

                case emInputType.String:
                    // 文字列は入力制限無し
                    blnCheckResult = true;
                    break;

                case emInputType.GRRString:
                    blnCheckResult = View.Utility.UiTextBoxCheck.IsGRRStringField(e);
                    break;
            }

            if (blnCheckResult)
            {
                // 小数部の桁数をチェックする
                switch (this.InputType)
                {
                    case emInputType.Decimal:
                    case emInputType.DecimalPositive:
                        // 変更後の文字列が数値に変換できることと、小数部の桁数が適切であることを確認する。確認できない場合は変更を拒絶する。
                        var newText = _GetNewText(_TextForNumericalValidation, SelectionStart, SelectionLength, e);
                        if (newText.Length > MaxLength) // 本来MaxLengthについては基底クラス(TextBox)でチェックされるのだが、_TextForNumericValidationの設定のため、自前でチェックする。
                        {
                            blnCheckResult = false;
                        }
                        else if (!View.Utility.UiTextBoxCheck.IsValidNumberString(newText, MaxNumberOfDecimalPlaces))
                        {
                            blnCheckResult = false;
                        }
                        else
                        {
                            _TextForNumericalValidation = newText;
                        }
                        break;
                    default:
                        break;  // Number、NumberPositive、String、GRRStringの場合はチェックしない。
                }
            }

            if (blnCheckResult)
            {
                base.OnPreviewKeyDown(e);
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion OnPreviewKeyDown

        #region OnPropertyChanged
        /// <summary>
        /// Textプロパティ変更時に、_TextForNumericValidationも更新させるためのもの。
        /// </summary>
        /// <param name="e">DependencyPropertyChangedEventArgs</param>
        protected override void OnPropertyChanged(System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (e.Property.Name.Equals("Text"))
            {
                _TextForNumericalValidation = (string)e.NewValue;
            }
            base.OnPropertyChanged(e);
        }

        #endregion OnPropertyChanged

        #region OnTextChanged
        /// <summary>
        /// OnTextChanged
        /// </summary>
        /// <param name="e">テキスト変更イベント</param>
        protected override void OnTextChanged(System.Windows.Controls.TextChangedEventArgs e)
        {
            this._CheckIsRangeError();
            base.OnTextChanged(e);
        }
        #endregion OnTextChanged

        #region OnPreviewLostKeyboardFocus
        /// <summary>
        /// OnPreviewLostKeyboardFocus
        /// </summary>
        /// <param name="e">フォーカス変更イベント</param>
        protected override void OnPreviewLostKeyboardFocus(System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            // エラーが有る場合はデフォルト値をセット
            if (this.IsInputError)
            {
                // デフォルト値設定契機とエラーが発生した理由かを比較し、必要があればデフォルト値をセット
                if (this._defaultSetReason == emDefaultSetReason.All ||
                    (this._defaultSetReason == emDefaultSetReason.NumericParseError && this._blnParseError) ||
                    (this._defaultSetReason == emDefaultSetReason.RangeCheckError && this._blnRangeError))
                {
                    this.Text = this.DefaultValue;
                }
            }

            base.OnPreviewLostKeyboardFocus(e);
        }
        #endregion

        #endregion Protected Method（基底処理の拡張）

        #region Private Method

        /// <summary>
        /// 範囲チェック（数値に変換できるかのチェック含む）
        /// </summary>
        private void _CheckIsRangeError()
        {
            Boolean blnCheckResult = true;

            // エラー情報のクリア
            this._blnParseError = false;
            this._blnRangeError = false;

            switch ((emInputType)this.InputType)
            {
                case emInputType.Numeric:
                case emInputType.NumericPositive:
                    // 整数に変換できるかのチェック
                    Int32 i32Temp;
                    if (!Int32.TryParse(this.Text, out i32Temp))
                    {
                        this._blnParseError = true;
                        blnCheckResult = false;
                    }
                    break;

                case emInputType.Decimal:
                case emInputType.DecimalPositive:
                    // 実数に変換できるかのチェック
                    Double dblTemp;
                    if (!Infrastructure.LocalizeUtil.NumberConversionUtil.DoubleTryParse(this.Text, out dblTemp))
                    {
                        this._blnParseError = true;
                        blnCheckResult = false;
                    }
                    break;
            }

            // Parseに成功且つ範囲チェックが必要なら
            // Parseに成功したなら
            if (blnCheckResult)
            {
                // 入力種別に応じた最低限の範囲チェック
                switch ((emInputType)this.InputType)
                {
                    case emInputType.NumericPositive:
                    case emInputType.DecimalPositive:
                        // 自然数であるかチェック
                        Double dblTemp = Infrastructure.LocalizeUtil.NumberConversionUtil.DoubleParse(this.Text);
                        if (dblTemp <= 0)
                        {
                            this._blnRangeError = true;
                            blnCheckResult = false;
                        }
                        break;
                }

                // 範囲チェックが必要か判定
                if (this._blnIsRangeCheck)
                {
                    // 入力種別に応じた範囲チェック
                    switch ((emInputType)this.InputType)
                    {
                        case emInputType.Numeric:
                        case emInputType.NumericPositive:
                            // 整数の範囲チェック
                            if (!View.Utility.UiTextBoxCheck.IsInRangedNumeric((Int64)this.RangeMin, (Int64)this.RangeMax, this.Text))
                            {
                                this._blnRangeError = true;
                                blnCheckResult = false;
                            }
                            break;

                        case emInputType.Decimal:
                        case emInputType.DecimalPositive:
                            // 実数（少数）の範囲チェック
                            if (!View.Utility.UiTextBoxCheck.IsInRangedDecimal((Double)this.RangeMin, (Double)this.RangeMax, this.Text))
                            {
                                this._blnRangeError = true;
                                blnCheckResult = false;
                            }
                            break;
                    }
                }
            }

            if (blnCheckResult)
            {
                // エラーを解除
                this._ClearErrorState();
            }
            else
            {
                // エラーを設定
                this._SetErrorState();
            }
        }

        /// <summary>
        /// エラー状態に設定する
        /// </summary>
        private void _SetErrorState()
        {
            this.IsInputError = true;
            this.Tag = "1";

            // 背景をエラー色に設定
            this.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 80, 0));
        }

        /// <summary>
        /// エラー状態を解除する
        /// </summary>
        private void _ClearErrorState()
        {
            this.IsInputError = false;
            this.Tag = "0";

            // 背景を白に設定
            this.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
        }

        /// <summary>
        /// OnPreviewKeyDown()から呼ばれ、キー入力受け入れ後のTextの内容を組み立てる。
        /// </summary>
        /// <param name="currentText">現状のText</param>
        /// <param name="selectionStart">カーソルの位置または選択文字列の開始位置</param>
        /// <param name="selectionLength">選択文字列の長さ</param>
        /// <param name="e">KeyEventArgs</param>
        /// <returns></returns>
        private static string _GetNewText(string currentText, int selectionStart, int selectionLength, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Left:
                case System.Windows.Input.Key.Right:
                case System.Windows.Input.Key.Up:
                case System.Windows.Input.Key.Down:
                case System.Windows.Input.Key.Home:
                case System.Windows.Input.Key.End:
                case System.Windows.Input.Key.Return:
                    // カーソルを移動させるキーの場合は何もしない
                    return currentText;
                case System.Windows.Input.Key.Back:
                    // BSの場合
                    if (selectionLength > 0)
                    {
                        // 選択状態の文字列がある場合は、それらを削除する。(BSもDELも同じ)
                        return currentText.Substring(0, selectionStart) + currentText.Substring(selectionStart + selectionLength);
                    }
                    // 選択状態の文字列がない場合は、カーソルの前(左)の1文字を削除する。
                    if (selectionStart > 0)
                    {
                        return currentText.Substring(0, selectionStart - 1) + currentText.Substring(selectionStart);
                    }
                    // カーソルが文字列の先頭(左端)にある場合は何もしない
                    return currentText;
                case System.Windows.Input.Key.Delete:
                    // DELの場合
                    if (selectionLength > 0)
                    {
                        // 選択状態の文字列がある場合は、それらを削除する。(BSもDELも同じ)
                        return currentText.Substring(0, selectionStart) + currentText.Substring(selectionStart + selectionLength);
                    }
                    // 選択状態の文字列がない場合は、カーソルの後(右)の1文字を削除する。
                    if (selectionStart < currentText.Length)
                    {
                        return currentText.Substring(0, selectionStart) + currentText.Substring(selectionStart + 1);
                    }
                    // カーソルが文字列の末尾(右端)にある場合は何もしない
                    return currentText;
                default:
                    // 通常の文字入力の場合
                    return currentText.Substring(0, selectionStart) + _KeyCodeToChar[e.Key] + currentText.Substring(selectionStart + selectionLength);
            }
        }

        #endregion Private Method

        #region Private Static Method(依存関係プロパティ変更時のコールバックメソッド)
        /// <summary>
        /// RangeMinプロパティ変更時コールバックメソッド
        /// </summary>
        /// <param name="d">ValidateTextBoxオブジェクトインスタンス</param>
        /// <param name="e">プロパティ変更イベント</param>
        private static void _OnRangeMinPropertyChanged(
            System.Windows.DependencyObject d, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ValidateTextBox instance = d as ValidateTextBox;

            instance._CheckIsRangeError();
        }

        /// <summary>
        /// RangeMaxプロパティ変更時コールバックメソッド
        /// </summary>
        /// <param name="d">ValidateTextBoxオブジェクトインスタンス</param>
        /// <param name="e">プロパティ変更イベント</param>
        private static void _OnRangeMaxPropertyChanged(
            System.Windows.DependencyObject d, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ValidateTextBox instance = d as ValidateTextBox;

            instance._CheckIsRangeError();
        }

        #endregion Private Static Method(依存関係プロパティ変更時のコールバックメソッド)
    }
}