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
	public partial class UiPhotographyDetailSettingPage
	{
        /// <summary>
        /// UiDetailSettingPageインスタンス
        /// </summary>
        private UiDetailSettingPage uiDetailSettingPage = new UiDetailSettingPage();

        public UiPhotographyDetailSettingPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            ///詳細設定表示データセット
            this._setDetailSettingDisplayDeta();

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        #region 詳細設定表示データセット

        /// <summary>
        /// 詳細設定表示データセット
        /// </summary>
        private void _setDetailSettingDisplayDeta()
        {
            /////**親Page**/////
            ////TitleLabe非表示
            uiDetailSettingPage.lblPhotographySettingTitle.Visibility = System.Windows.Visibility.Collapsed;
            ////Page表示
            uiDetailSettingPage.grdZPosiotionSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdObservationSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdMagnificationSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdImageRevisionSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdPhotographySettingPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grdMapSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdStageSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdOtherSettingPage.Visibility = System.Windows.Visibility.Collapsed;

            /////**子Page**/////
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expSnapPage);
            //ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expThreeDimensionalPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expMovingImagePage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expAutoSavePage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expGRRPage);
            ////Expander表示設定
            uiDetailSettingPage.expSnapPage.Visibility = System.Windows.Visibility.Visible;
            //uiDetailSettingPage.expThreeDimensionalPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expMovingImagePage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expAutoSavePage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expGRRPage.Visibility = System.Windows.Visibility.Visible;
            ////表示設定
            uiDetailSettingPage.grbSnap.Visibility = System.Windows.Visibility.Visible;
            //uiDetailSettingPage.grbThreeDimensional.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbMovingImage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbAutoSave.Visibility = System.Windows.Visibility.Visible;

            this.frmPhotographyDetailSettingPage.Navigate(uiDetailSettingPage);
        }

        #endregion

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblPhotographyDetailSettingPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_TITLE);
        }

        #endregion GetContentResource
    }
}