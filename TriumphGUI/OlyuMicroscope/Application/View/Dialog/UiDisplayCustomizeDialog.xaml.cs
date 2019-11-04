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
    /// 画面カスタマイズ設定ダイアログ
    /// </summary>
	public partial class UiDisplayCustomizeDialog
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiDisplayCustomizeDialog()
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
            this.Label1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_TITLE_LABEL);

            this.grbMenu.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_MENUHEADER_LABEL);

            this.chkBestImage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_BESTIMAGE_LABEL);
            this.chkFullScreen.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_FULLSCREEN_LABEL);
            this.chkDualScreen.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_DUALSCREEN_LABEL);
            this.chkConditionSettings.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_CONDITIONSETTINGS_LABEL);
            this.chkStitching.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_STITCHING_LABEL);
            this.chkAdvancedSettings.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_ADVANCEDSETTINGS_LABEL);
            this.chkAdvancedAcquisition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_ADVANCEDACQUISITION_LABEL);

            this.grbPanel.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_PANELHEADER_LABEL);

            this.chkObsevationMode.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_OBSEVATIONMODE_LABEL);
            this.chkObsevationSettings.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_OBSEVATIONSETTINGS_LABEL);
            this.chkImageProcessing.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_IMAGEPROCESSING_LABEL);
            this.chkAccsssory.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_ACCESSORY_LABEL);

            this.chkTabNameApply.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_TABNAME_APPLY_CHECKBOX);
            this.lblTabName.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAYCUSTOMIZE_TABNAME_LABEL);

            this.btnOK.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MESSAGEBOX_OK);
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