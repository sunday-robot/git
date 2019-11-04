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
	public partial class UiThreeDimensionalSettingPage
	{
        public UiThreeDimensionalSettingPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        /// <summary>
        /// 【テスト用】上下限指定のZ位置ﾌﾟﾛｸﾞﾚｽﾊﾞｰ　⇒　正常動作が確認できたら削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ////System.Windows.Controls.ProgressBar bar = sender as System.Windows.Controls.ProgressBar;
            ////if (bar != null)
            ////{
            ////    System.Diagnostics.Debug.Write("NewValue=" + bar.Value + ", Max=" + bar.Maximum.ToString() + ", Min=" + bar.Minimum.ToString() + "\n");
            ////}
        }

        /// <summary>
        /// 【テスト用】範囲指定のZ位置ﾌﾟﾛｸﾞﾚｽﾊﾞｰ　⇒　正常動作が確認できたら削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ////System.Windows.Controls.ProgressBar bar = sender as System.Windows.Controls.ProgressBar;
            ////if (bar != null)
            ////{
            ////    System.Diagnostics.Debug.Write("NewValue=" + bar.Value + ", Max=" + bar.Maximum.ToString() + ", Min=" + bar.Minimum.ToString() + "\n");
            ////}
        }
        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblThreeDimensionalSettingPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TITLE);
            this.lblPhotographyMode.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_LABEL);
            this.rbtnPhotographyModeFreePrecise.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_FREE_PRECISE_LABEL);
            this.rbtnPhotographyModeHighlyPrecise.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGHLY_PRECISE_LABEL);
            this.rbtnPhotographyModeHighSpeed.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGH_SPEED_LABEL);
            this.lblPhotographyRange.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP);
            this.lblRange2.Content =
            this.lblRange.Content =
            this.tbiRange.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG);
            this.rbtnRangeWide.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_WIDE);
            this.rbtnRangeStandard.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NORMAL);
            this.rbtnRangeSmall.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NARROW);
            this.rbtnManualInput.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_MANUAL);
            this.lblAdjustPitch2.Content =
            this.lblAdjustPitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_PITCH);
            this.lblStepCount2.Content =
            this.lblStepCount.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NUM_STEP);
            this.lblAreaEnd2.Content =
            this.lblAreaEnd.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_END_POS);
            this.lblAreaTop2.Content =
            this.lblAreaTop.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_TOP_POS);
            this.tbiUpperLowerLimit.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_LIMIT);
            this.lblCombItemCurrentPos.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CURRENT);
            this.lblCombItemCenterBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CENTER);
            //this.lblAcqUnitUpper.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitLower.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitPitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitRange.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitUpper2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitLower2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitPitch2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitRange2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
        }
    }
}