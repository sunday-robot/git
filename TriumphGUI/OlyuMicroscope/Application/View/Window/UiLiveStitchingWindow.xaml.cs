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
	public partial class UiLiveStitchingWindow
	{
        public UiLiveStitchingWindow()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInWindow();

            // ボタンの表示変更用
            ViewModel.UiController.sUiController.Acquisition.StitchingExtendStopActionLabel = this.lblStopPhoto3;
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
        private void _GetContentResourceInWindow()
        {
            // Page固有
            this.lblTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_TITLE_NAME);
            this.lblDisplaySize.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_DISPLAY_SIZE_LABEL);
            this.btnReturn.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_BACKBUTTON_LABEL);

            this.lblReferencePosition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_REFERENCE_POSITION_LABEL);
            this.rbtnEasy.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_2D_EASY_LABEL);
            this.rbtnStandard.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_2D_STANDARD_LABEL);
            this.checkBox1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_USE_AS_MAP_IMAGE_LABEL);
            this.lblImageDeletion.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_DELETE_IMAGE_LABEL);
            this.lblComplete.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVESTITCH_WINDOW_GROUP_COMPLETE_LABEL);

            // 3D設定と共用
            this.lblTakePhoto0.Content =
            this.lblTakePhoto1.Content =
            this.lblTakePhoto2.Content =
            this.lblTakePhoto3.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL);  // 撮影
            this.lblStopPhoto0.Content =
            this.lblStopPhoto1.Content =
            this.lblStopPhoto2.Content =
            this.lblStopPhoto3.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL);  // 中止
            this.rbtnThreeDimensional.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_3D);
            this.rbtnSimpleOmnifocal.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SIMPLEOMNIFOCAL);
            this.lblFocusMenu.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_FOCUS_LABEL);
            this.lblThreeDimensionalSettingPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TITLE);
            this.lblRange2.Content =
            this.lblRange.Content =
            this.tbiRange.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG);
            this.tbiUpperLowerLimit.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_LIMIT);
            this.lblPhotographyMode.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_LABEL);
            this.lblPhotographyRange.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP);
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
            this.lblCombItemCurrentPos.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CURRENT);
            this.lblCombItemCenterBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CENTER);
            this.rbtnPhotographyModeFreePrecise.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_FREE_PRECISE_LABEL);
            this.rbtnPhotographyModeHighlyPrecise.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGHLY_PRECISE_LABEL);
            this.rbtnPhotographyModeHighSpeed.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGH_SPEED_LABEL);
            this.lblPhotographySetting.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TITLE);
            //this.lblAcqUnitUpper.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitLower.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitPitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitRange.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitUpper2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitLower2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitPitch2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
            //this.lblAcqUnitRange2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT);
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

        /// <summary>
        /// ウィンドウ表示・非表示処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>多言語表示の暫定対応で、表示時に毎回行う。正式には起動時の適切なタイミングで1回だけ行う方がよい。</remarks>
        private void Window_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            // 表示時の処理を行う（パフォーマンス低下を防ぐため）
            if ((System.Boolean)e.NewValue == true)
            {
                // Read the resource, and Setup it on Content.
                this._GetContentResourceInWindow();
            }
        }
    }
}