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
    /// <summary>
    /// キャリブレーション設定ダイアログ
    /// </summary>
	public partial class UiCalibrationDialog
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiCalibrationDialog()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();
            
            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Application.ViewModel.UiController.sUiController;
		}

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.Label1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIALOG_TITLE_NAME);
            this.TabItem1.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIALOG_TAG_EXECUTE);
            this.TabItem2.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIALOG_TAG_CHANGE);
            this.TabItem3.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIALOG_TAG_HISTORY);
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
	}
}