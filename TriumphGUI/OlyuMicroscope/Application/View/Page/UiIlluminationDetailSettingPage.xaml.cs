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
	public partial class UiIlluminationDetailSettingPage
	{
        /// <summary>
        /// UiDetailSettingPageインスタンス
        /// </summary>
        private UiDetailSettingPage uiDetailSettingPage = new UiDetailSettingPage();

        public UiIlluminationDetailSettingPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            ///詳細設定表示データセット
            this._setDetailSettingDisplayDeta();

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblIlluminationDetailSettingPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_DETAIL_TITLE_NAME);
        }

        #endregion GetContentResource

        #region 詳細設定表示データセット

        /// <summary>
        /// 詳細設定表示データセット
        /// </summary>
        private void _setDetailSettingDisplayDeta()
        {
            /////**親Page**/////
            ////TitleLabe非表示
            uiDetailSettingPage.lblObservationSettingTitle.Visibility = System.Windows.Visibility.Collapsed;
            ////Page表示
            uiDetailSettingPage.grdZPosiotionSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdObservationSettingPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grdMagnificationSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdImageRevisionSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdPhotographySettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdMapSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdStageSettingPage.Visibility = System.Windows.Visibility.Collapsed;
            uiDetailSettingPage.grdOtherSettingPage.Visibility = System.Windows.Visibility.Collapsed;

            /////**子Page**/////
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expBlurCorrectionPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expASPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expAEPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expAspectPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expBinningPage);
            ViewModel.UiController.sUiController.DetailSetting.UnBindExpander(uiDetailSettingPage.expMonochromeModePage);
            ////Expander表示設定
            uiDetailSettingPage.expBlurCorrectionPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expASPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expAEPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expAspectPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expBinningPage.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.expMonochromeModePage.Visibility = System.Windows.Visibility.Visible;
            ////表示設定
            uiDetailSettingPage.grbBlurCorrection.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbAS.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbAE.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbAspect.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbBinning.Visibility = System.Windows.Visibility.Visible;
            uiDetailSettingPage.grbMonochromeMode.Visibility = System.Windows.Visibility.Visible;

            this.frmIlluminationDetailSettingPage.Navigate(uiDetailSettingPage);
        }

        #endregion
	}
}