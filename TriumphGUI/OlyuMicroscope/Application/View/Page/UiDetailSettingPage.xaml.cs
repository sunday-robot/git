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
    public partial class UiDetailSettingPage
    {
        public UiDetailSettingPage()
        {
            this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            //SNAP撮影設定部のｺﾝﾃﾝﾄﾘｿｰｽ読込
            this._GetSnapSettingContentResource();
        }

        /// <summary>
        /// SNAP撮影設定部のｺﾝﾃﾝﾄﾘｿｰｽ読込
        /// </summary>
        private void _GetSnapSettingContentResource()
        {
            this.expAFPage.Header =
            this.grbAF.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_GROUP_LABEL_AF);
            this.lblZPosiotionSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_SETTING);
            this.lblRoiAdj.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_ADJUST);
            this.lblBtnDefault.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_BUTTON_ROI_DEFAULT);
            this.lblRoiDisp.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_DISPLAY);

            this.expZPositionRegistPage.Header =
            this.grbZPositionRegist.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_GROUP_LABEL_Z_POSITION_REGISTRATION);
            this.lblCheckBoxZposAct.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_CHECKBOX_ENABLE_Z_POSITION);
            this.lblBtnZposRegist.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_BUTTON_Z_POSITION_REGISTRATION);
            //this.lblZPositionUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_UNIT_LABEL);

            this.expLowerLimitRegistPage.Header =
            this.grbLowerLimitRegist.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_GROUP_LABEL_LOWER_LIMIT);
            this.lblCheckBoxLimitAct.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_CHECKBOX_ENABLE_LIMIT_RANGE);
            this.lblLimitAlerm.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_ALERM_ON_LIMIT_RANGE);
            this.lblBtnLowLmtregist.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_BUTTON_LOWER_LIMIT_REGISTRATION);
            //this.lblZPositionLimitUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_UNIT_LABEL);

            this.lblObservationSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_TITLE_NAME);

            this.expBlurCorrectionPage.Header =
            this.grbBlurCorrection.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_GROUP_LABEL);
            this.checkBox1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_CHECKBOX_LABEL);
            this.label1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_LABEL_EFFECTIVE_INVALID);

            this.expASPage.Header =
            this.grbAS.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_APERTURE_STOP_GROUP_LABEL);
            this.lblToggleBtnAS.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_APERTURE_STOP_LABEL_SETTING);

            this.expMonochromeModePage.Header =
            this.grbMonochromeMode.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_MONOCHROME_MODE_GROUP_LABEL);
            this.lblToggleBtnMonochromeMode.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_MONOCHROME_MODE_LABEL_SETTING);

            this.expAEPage.Header =
            this.grbAE.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_GROUP_LABEL);
            this.lblAETarget.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_TARGET_LABEL);
            this.lblTglBtnAE.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_TOGGLEBUTTON_LABEL);
            this.grbAERange.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_LABEL);
            this.lblBtnIniAE.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_BUTTON_DEFAULT_LABEL);

            this.expAspectPage.Header =
            this.grbAspect.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_LABEL);
            this.expBinningPage.Header =
            this.grbBinning.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_LABEL);

            #region Magnification   // 詳細設定画面 - 倍率設定画面

            this.lblMagnificationSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAGNIFICATION_GROUP_LABEL);

            #region Magnification - Mode    // 詳細設定画面 - 倍率 - 倍率の指定方法 設定画面

            this.expMagnificationModeSettingPage.Header
                = this.grbMagnificationModeSetting.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAGNIFICATION_GROUP_MODE_LABEL);
            this.rbtnZoomMagnificationMode.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAGNIFICATION_SETTING_ZOOM_MODE_TEXT);
            this.rbtnTotalMagnificationMode.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAGNIFICATION_SETTING_TOTAL_MODE_TEXT);

            #endregion Magnification - Mode

            #endregion Magnification

            this.lblImageRevisionSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_LABEL);

            this.expHDRPage.Header =
            this.grbHDR.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_LABEL);
            this.lblHDRBrightness.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_BRIGHTNESS_LABEL);
            this.lblHDRTexture.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_TEXTURE_LABEL);
            this.lblHDRContrast.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CONTRAST_LABEL);
            this.lblHDRChrome.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CHROME_LABEL);
            this.tglbHDRParamLock.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_KEEP_PARAMETER_LABEL);


            this.expContrastPage.Header =
            this.grbContrast.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_LABEL);
            this.lblRadioBtnL.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_LOW_LABEL);
            this.lblRadioBtnM.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_NORMAL_LABEL);
            this.lblRadioBtnH.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_HIGH_LABEL);

            this.expAntiHalationStandardPage.Header =
            this.grbAntiHalationStandard.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATION_GROUP_LABEL);
            this.lblHDRAntiHalationBrightness.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_BRIGHTNESS_LABEL);
            this.lblHDRAntiHalationTexture.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_TEXTURE_LABEL);
            this.lblHDRAntiHalationContrast.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CONTRAST_LABEL);
            this.lblHDRAntiHalationChrome.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATION_GROUP_CHROME_LABEL);
            this.tglbHDRAntiHalationParamLock.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_KEEP_PARAMETER_LABEL);

            this.expAntiHalationHighPage.Header =
            this.grbAntiHalationHigh.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_LABEL);
            this.btnDefaltWiDER.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_GAIN_BUTTON_DEFAULT_LABEL);
            this.lblAsymmetry.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_ASYMMETRY_LABEL);
            this.lblStrength.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_STRENGTH_LABEL);
            this.lblSaturation.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_SATURATION_LABEL);
            this.lblNoiseReductionStatus.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_LABEL);
            this.rbtnOFF.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_OFF_LABEL);
            this.rbtnLOW.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_LOW_LABEL);
            this.rbtnMID.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_MID_LABEL);
            this.rbtnHIGH.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_HIGH_LABEL);

            this.expIdentificationColoredPage.Header =
            this.grbIdentificationColored.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_SPECIFIC_COLOR_GROUP_LABEL);

            this.expEdgePage.Header =
            this.grbEdge.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_EDGE_EMPHASIS_GROUP_LABEL);

            this.expGammaPage.Header =
            this.grbGamma.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_GAMMA_GROUP_LABEL);

            this.expWhiteBalancePage.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_LABEL);
            this.grbWbSubGain.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_GROUP_LABEL);
            this.btnAutomaticBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BUTTON_CALIBRATE_LABEL);
            this.btnDefaltBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BUTTON_DEFAULT_LABEL);
            this.lblRedGain.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_RED_GAIN_LABEL);
            this.lblGreenGain.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_GREEN_GAIN_LABEL);
            this.lblBlueGain.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BLUE_GAIN_LABEL);
            this.grbWbSubROI.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_LABEL);
            this.tglbROIOnOffSwitchBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_BUTTON_ON_OFF_LABEL);
            this.btnROIOnOffSwitchBase.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_BUTTON_DEFAULT_LABEL);

            this.lblPhotographySettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_LABEL);

            this.expSnapPage.Header =
            this.grbSnap.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_SNAP_GROUP_LABEL);
            //this.expThreeDimensionalPage.Header =
            //this.grbThreeDimensional.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_3D_GROUP_LABEL);
            this.expMovingImagePage.Header =
            this.grbMovingImage.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_LABEL);

            // RadioButton-Contentに該当ｺﾝﾃﾝﾄﾘｿｰｽを設定する
            this.rbtn3CcdOff.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_ACQSETTING_RADIOSNAPMODEOFF_TEXT);
            this.rbtn3CcdHR.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_ACQSETTING_RADIOSNAPMODEHR_TEXT);
            this.rbtn3CcdSuperHR.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_ACQSETTING_RADIOSNAPMODESUPERHR_TEXT);

            this.lblPhotoImgMovieSet.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_TITLE_LABEL);
            this.lblRBtmPhotoImgMovieLow.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_LOW_LABEL);
            this.lblRBtmPhotoImgMovieStd.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_STANDARD_LABEL);

            this.lblPhotoImgFramerate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_TITLE_LABEL);
            this.lblRBtnPhotoImgFramerate1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_1_FPS_LABEL);
            this.lblRBtnPhotoImgFramerate15.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_15_FPS_LABEL);

            this.expAutoSavePage.Header =
            this.grbAutoSave.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_AUTOSAVE_GROUP_LABEL);

            this.expGRRPage.Header =
            this.grbGRR.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_LABEL);

            //kokokoko
            this.lblMapSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_MAP_SET_GROUP_LABEL);
            this.expMapPage.Header =
            this.grbMap.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_MAP_SET_GROUP_TITLE_LABEL);

            this.lblStageSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_SET_GROUP_LABEL);
            this.expStagePage.Header =
            this.grbStage.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_SET_GROUP_STAGE_LABEL);

            this.expStageAutoCalibrationPage.Header =
            this.grbStageAutoCalibration.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_AUTO_CALIBRATION_GROUP_LABEL);
            this.btnStartAutoCalibration.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_AUTO_CALIBRATION_START_BUTTON);

            this.lblOtherSettingTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_LABEL);
            this.expSleepPage.Header =
            this.grbSleep.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_LABEL);
            this.lblCheckBoxSleepEnable.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_ENEBLE_LABEL);
            this.lblSleepWaitTime.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_WAIT_TIME_LABEL);
            this.lblSleepMinutesUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_TIME_UNIT_LABEL);
            this.lblSleepSetApply.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_APPLY_BUTTON_LABEL);

            this.expImageFramScalePage.Header =
            this.grbImageFramScale.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SCALE_GROUP_LABEL);
            this.lblCheckBoxShowGrid.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SCALE_GROUP_CHECKBOX_LABEL);

            this.lblCombBoxOFF.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_BINNING_OFF_LABEL);
            this.lblCombBox2x2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_BINNING_2x2_LABEL);

            this.lblRBtnAspect1to1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_ASPECT_1_1_LABEL);
            this.lblRBtnAspect4to3.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_ASPECT_4_3_LABEL);

            this.checkBoxMapUpdateObservationMethod.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAP_UPDATE_SWITCHING_BF_LABEL);
            this.grbMapAutoUpdate.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_LABEL);
            this.rbMapUpdateX1.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X1_LABEL);
            this.rbMapUpdateX2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X2_LABEL);
            this.rbMapUpdateX5.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X5_LABEL);
            this.rbMapUpdateX10.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X10_LABEL);

            this.btnRegistry.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_REGISTRATION_BUTTON_LABEL);
        }

        /// <summary>
        /// TextBoxのKeyboardFocus(LostFocusでは、ハンドルできないときのため)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _TextBox_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt != null)
            {
                BindingExpression binding = txt.GetBindingExpression(TextBox.TextProperty);
                if (binding != null)
                {
                    binding.UpdateSource();
                }
            }
        }

    }
}