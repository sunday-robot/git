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
	public partial class UiImageRevisionDetailSettingPage
	{
        /// <summary>
        /// UiDetailSettingPageインスタンス
        /// </summary>
        private UiDetailSettingPage uiDetailSettingPage = new UiDetailSettingPage();

        public UiImageRevisionDetailSettingPage()
		{
			this.InitializeComponent();

            ////ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            ////詳細設定表示データセット
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
            uiDetailSettingPage.lblImageRevisionSettingTitle.Visibility = System.Windows.Visibility.Collapsed;
            ////Page表示
            uiDetailSettingPage.grdZPosiotionSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdObservationSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdMagnificationSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdImageRevisionSettingPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grdPhotographySettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdMapSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdStageSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdOtherSettingPage.Visibility = System.Windows.Visibility.Collapsed;

            /////**子Page**/////
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expHDRPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expContrastPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expAntiHalationStandardPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expAntiHalationHighPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expIdentificationColoredPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expEdgePage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expGammaPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expWhiteBalancePage);
            ////Expander表示設定
            uiDetailSettingPage.expHDRPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expContrastPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expAntiHalationStandardPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expAntiHalationHighPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expIdentificationColoredPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expEdgePage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expGammaPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expWhiteBalancePage.Visibility = System.Windows.Visibility.Visible;
            ////表示設定
            uiDetailSettingPage.grbHDR.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbContrast.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbAntiHalationStandard.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbAntiHalationHigh.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbIdentificationColored.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbEdge.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbGamma.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.stpWhiteBalance.Visibility = System.Windows.Visibility.Visible;

            this.frmImageRevisionDetailSettingPage.Navigate(uiDetailSettingPage);
        }

        #endregion

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblImageRevisionDetailSettingPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_DETAIL_SETTING_GROUP_TITLE);
        }

        #endregion GetContentResource
    }
}