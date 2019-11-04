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
	public partial class UiMenuPage
	{
        public UiMenuPage()
		{
			this.InitializeComponent();

            // ﾒﾆｭｰ画面のｺﾝﾃﾝﾄﾘｿｰｽを読込む
            this._UiMenuPageLoad();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        /// <summary>
        /// ﾒﾆｭｰ画面のｺﾝﾃﾝﾄﾘｿｰｽ読込
        /// </summary>
        private void _UiMenuPageLoad()
        {
            this._GetMenuButtonControlContentResource();
        }

        /// <summary>
        /// ﾒﾆｭｰ画面のﾎﾞﾀﾝｺﾝﾃﾝﾄﾘｿｰｽ読込
        /// </summary>
        private void _GetMenuButtonControlContentResource()
        {
            this.btnMenuLive.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_BUTTON_LIVE);
            this.btnMenuPreview.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_BUTTON_PREVIEW);
            this.expMenu2Display.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_2DISPLAY);
            this.btnMenuWide.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_BUTTON_WIDE);
            this.btnMenuDetail.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_BUTTON_DETAIL);
            this.expMenuStitching.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_STITCHING);
            this.expMenuCondition.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_CONDITION);
            this.btnMenuNavi.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_BUTTON_NAVIGATION);
        }

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblRectSplitScreen.Content =
            this.lblTglBtnSplitScreen.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_2DISPLAY);
            this.lblRectStiching.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_STITCHING);
            this.lblRectCondition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_CONDITION);
            this.lblRectLiveStich.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_LIVE_STITCH);
            this.lblToggleBtnAutoStich.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_AUTO_STITCH_TOGGLE_BUTTON);
            this.lblBtnReadCondition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_READ_CONDITION_BUTTON);
            this.lblBtnSaveCondition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_SAVE_CONDITION_BUTTON);
            this.lblBtnViewImage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_VIEW_IMAGE_BUTTON);
            this.lblRadioBtnSplitVertical.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_SPLIT_VERTICAL_RADIO_BUTTON);
            this.lblRadioBtnSplitHorizontal.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_SPLIT_HORIZONTAL_RADIO_BUTTON);
            this.lblBtnSwapScreen.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_SWAP_SCREEN_BUTTON);
            this.lblRadioBtnFullVertical.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_FULL_VERTICAL_RADIO_BUTTON);
            this.lblRadioBtnFullHorizontal.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_FULL_HOROZONTAL_RADIO_BUTTON);
            this.lblRadioBtnThumbnail.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_EXPANDER_THUMBNAIL_RADIO_BUTTON);
        }

        #endregion GetContentResource
    }
}