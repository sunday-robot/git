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
	public partial class UiPhotographySettingPage
	{
        public UiPhotographySettingPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();

            // ボタンの表示変更用
            ViewModel.UiController.sUiController.Acquisition.ExtendStopActionLabel = this.lblStopAction2;
        }

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblPhotographySettingPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TITLE);
            this.rbtnSnap.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SNAP);
            this.rbtnSimpleOmnifocal.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SIMPLEOMNIFOCAL);
            this.rbtnThreeDimensional.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_3D);
            this.rbtnMovingImage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_MOVIE);
            this.lblTakePhotograph0.Content =
            this.lblTakePhotograph1.Content =
            this.lblTakePhotograph2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL);
            this.lblStopAction0.Content =
            this.lblStopAction1.Content = 
            this.lblStopAction2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL);
            this.lblRecSTART.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_REC_START_LABEL);
            this.lblRecStop.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_REC_STOP_LABEL);
        }

        #endregion GetContentResource
    }
}