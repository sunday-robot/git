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
	public partial class UiBeginnerMenuPage
	{
		public UiBeginnerMenuPage()
		{
			this.InitializeComponent();            

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // ﾋﾞｷﾞﾅｰﾒﾆｭｰ画面のｺﾝﾃﾝﾄﾘｿｰｽを読込む
            this._UiBeginnerMenuPageLoad();
        }

        #region GetContentResource
        /// <summary>
        /// ﾋﾞｷﾞﾅｰﾒﾆｭｰ画面のｺﾝﾃﾝﾄﾘｿｰｽ読込
        /// </summary>
        private void _UiBeginnerMenuPageLoad()
        {
            this._GetMenuTabControlContentResource();
            this._GetTextBlockContentResource();
            this._GetButtonControlContentResource();
            this._GetLabelContentResource();
        }

        private void _GetMenuTabControlContentResource()
        {
            this.PositionTabItem.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_POSITION_TAB);
            this.ObservationTabItem.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_OBSERVATION_TAB);
            this.AcquisitionTabItem.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_ACQUISITION_TAB);
        }

        private void _GetTextBlockContentResource()
        {
            this.txbFocus.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_FOCUS_Z_POSITION_TEXT);
            this.txbObservationLocation.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_OBSERVATION_LOCATION_TEXT);
            this.txbZoom.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_ZOOM_TEXT);
            this.txbBright.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_BRIGHT_TEXT);

            this.txbBestImage.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_BEST_IMAGE_TEXT);
            this.txbReadCondition.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_READ_CONDITION_TEXT);
            this.txbRestore.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_RESTORE_TEXT);

            this.txbAcquisitionMode.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_ACQUISITION_MODE_TEXT);
            this.txbZRange.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_Z_RANGE_TEXT);

            this.txbZRangeBaseNowPos.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_Z_RANGE_GUIDE_BASE_NOW_POSITION_TEXT);
            this.txbZRangeBaseCenterPos.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_Z_RANGE_GUIDE_BASE_CENTER_POSITION_TEXT);
        }

        /// <summary>
        /// ﾋﾞｷﾞﾅｰﾒﾆｭｰ画面のﾎﾞﾀﾝｺﾝﾃﾝﾄﾘｿｰｽ読込
        /// </summary>
        private void _GetButtonControlContentResource()
        {
            this.lblBtnMenuPreview.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAINMENU_BUTTON_PREVIEW);
            this.lblBtnReadCondition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_READ_CONDITION_BUTTON_LABEL);
            this.lblBtnBack.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_BACK_BUTTON_LABEL);
            this.lblBtnNext.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_AREA_NEXT_BUTTON_LABEL);

            this.rdbSnap.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SNAP);
            this.rdb3D.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_3D);
            this.rdbEFI.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SIMPLEOMNIFOCAL);

            this.rbtnRangeWide.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_WIDE);
            this.rbtnRangeStandard.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NORMAL);
            this.rbtnRangeSmall.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NARROW);
            this.rbtnManualInput.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_MANUAL);

            this.lblTakePhotograph0.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL);
            this.lblTakePhotograph1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL);
            this.lblTakePhotograph2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL);

            this.lblStopAction0.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL);
            this.lblStopAction1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL);
            this.lblStopAction2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL);
        }

        private void _GetLabelContentResource()
        {
            this.lblAdjustPitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_PITCH);
            this.lblStepCount.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NUM_STEP);
            this.lblAreaEnd.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_END_POS);
            this.lblAreaTop.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_TOP_POS);

            this.lblRange.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG);

            this.lblCombItemCurrentPos.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CURRENT);
            this.lblCombItemCenterBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CENTER);

            this.lblOr1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_OBSERVATION_OR_LABEL);
            this.lblOr2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_BEGINNER_OBSERVATION_OR_LABEL);

            //this.lblAcqUnitUpper.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitLower.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitPitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitRange.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
        }        
        #endregion GetContentResource

        /// <summary>
        /// ﾏｳｽｴﾝﾀｰﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ZPositionAreaMouseEnterHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Layout.ZPositionAreaMouseEnterHandler();
        }

        /// <summary>
        /// ﾏｳｽｴﾝﾀｰﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ObservationLocationAreaMouseEnterHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Layout.ObservationLocationAreaMouseEnterHandler();
        }

        /// <summary>
        /// ﾏｳｽｴﾝﾀｰﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ZoomAreaMouseEnterHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Layout.ZoomAreaMouseEnterHandler();
        }
    }
}