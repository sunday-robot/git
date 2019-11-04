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
	public partial class UiCalibrationMessagePage
	{
		public UiCalibrationMessagePage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();
        }
        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.rbtnMaker.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_MAKER_LABEL);
            this.rbtnUser.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_USER_LABEL);
            this.rbtnCheck.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_CHECK_LABEL);
            this.rbtnUpdate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_UPDATE_LABEL);
            this.rbtnRepetition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_REPETITION_MEASURE_MODE_BUTTON);
            this.lblSamplePitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_SAMPLE_PITCH_LABEL);
            // this.lblScaleUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_UNIT_LABEL);
            this.lblPitchNotice.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_PITCH_NOTICE_LABEL);
            this.lblRepetitionCountSeparate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_REPETITION_FRACTION_SEPARATE_MARK_LABEL);
            this.rbtnXY.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_AXIS_XY_LABEL);
            this.rbtnX.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_AXIS_X_LABEL);
            this.rbtnY.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_AXIS_Y_LABEL);
            
            this.lblName.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_NAME_LABEL);
            this.btnRetry.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_RETRY_BUTTON);
            this.btnStop1.Content =
            this.btnStop.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_STOP_BUTTON);
            this.btnNext.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_NEXT_BUTTON);
            this.btnCancel1.Content =
            this.btnCancel2.Content =
            this.btnCancel3.Content =
            this.btnCancel.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_CANCEL_BUTTON);
            this.btnStart.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_START_BUTTON);
            this.btnMeasurementStart.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_MEASUREMENT_START_BUTTON);
            this.btnContinue.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_CONTINUE_BUTTON);
            this.btnSave.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_SAVE_BUTTON);
            this.btnEnd1.Content =
            this.btnEnd.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_END_BUTTON);
            this.btnReferLog.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_MESSAGE_PAGE_REFER_LOG_BUTTON);
        }
    }
}