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
    /// ｽﾃｰｼﾞｺﾝﾄﾛｰﾙﾀﾞｲｱﾛｸﾞ
    /// </summary>
	public partial class UiLiveColorDialog
    {
        #region ｺﾝｽﾄﾗｸﾀ
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiLiveColorDialog()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = ViewModel.UiController.sUiController;
		}

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.lblDialogTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVE_COLOR_DIALOG_TITLE);
            this.Label1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVE_COLOR_DIALOG_LABEL_REGIST);
            this.BtnRegist.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_REGISTRATION);
            this.BtnUpdate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_UPDATE);
            this.BtnDelete.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_DELETE);
            this.BtnClose.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_CLOSE);
            this.lblColorWidth.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_SPECIFIC_COLOR_GROUP_COLOR_WIDTH_LABEL);
        }

        #endregion ｺﾝｽﾄﾗｸﾀ

        #region ﾌｫｰﾑに対するﾏｳｽ操作のｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// <summary>
        /// ﾀﾞｲｱﾛｸﾞ画面ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.DragMove();
        }
        #endregion ﾌｫｰﾑに対するﾏｳｽ操作のｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ

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