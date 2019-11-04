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
    public partial class UiConditionReappearanceDialog
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
		public UiConditionReappearanceDialog()
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
            this.LabelComment.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_REAPPEARANCE_DIALOG_LABEL_COMMENT);
            this.cmdSave.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_SAVE);
            this.cmdAdapt.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_APPLY);
            this.cmdCancel.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_CANCEL);
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
        /// ウィンドウ表示・非表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>多言語表示の暫定対応で、表示時に毎回行う。正式には起動時の適切なタイミングで1回だけ行う方がよい。</remarks>
        private void Window_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            // 表示時の処理を行う（パフォーマンス低下を防ぐため）
            if ((System.Boolean)e.NewValue == true)
            {
                // Read the resource, and Setup it on Content.
                this._GetDialogContentResource();
            }
        }
    }
}