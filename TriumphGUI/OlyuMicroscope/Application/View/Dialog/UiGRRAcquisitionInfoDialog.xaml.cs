using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

using Olympus.LI.Triumph.Application.View.Utility;

namespace Olympus.LI.Triumph.Application.View
{
    /// <summary>
    /// GRR情報設定ﾀﾞｲｱﾛｸﾞ
    /// </summary>
	public partial class UiGRRAcquisitionInfoDialog
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiGRRAcquisitionInfoDialog()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
		}

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.lblBtnOK.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MESSAGEBOX_OK);
            this.lblBtnCancel.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MESSAGEBOX_CANCEL);
        }

        /// <summary>
        /// ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// ウィンドウクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ViewModel.UiController.sUiController.Layout.IsExecWindowClosing())
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// ダイアログの測定者コンボボックスの個別キー入力のチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlignmentAcqOperatorComboKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // GRR文字列チェック
            Boolean blnCheckResult = View.Utility.UiTextBoxCheck.IsGRRStringField(e);
            if (!blnCheckResult)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// ダイアログのサンプルコンボボックスの個別キー入力のチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlignmentAcqSampleComboKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // GRR文字列チェック
            Boolean blnCheckResult = View.Utility.UiTextBoxCheck.IsGRRStringField(e);
            if (!blnCheckResult)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
	}
}
