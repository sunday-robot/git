using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Olympus.LI.Triumph.Application.View
{
	public partial class UiSleepMessageDialog
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
		public UiSleepMessageDialog()
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
            this.lblDialogTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_SLEEP_DIALOG_LABEL_TITLE_NAME);
            this.cmdThird.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_SLEEP_DIALOG_BUTTON_LABEL_RELEASE);
            this.msgTextBox.Text = Resource.UiResource.GetResourceValue(Resource.UiMessageResourceKey.MSG_I_SLEEPING_NEED_RELEASE_TO_WAKEUP);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
	}
}