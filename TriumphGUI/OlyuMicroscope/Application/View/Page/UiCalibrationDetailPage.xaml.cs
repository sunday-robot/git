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
	public partial class UiCalibrationDetailPage
	{
		public UiCalibrationDetailPage()
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
            this.lblTitleName.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_CURRENT_REVOLVER_TITLE);
            this.lblLens.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_LENS_NAME_LABEL);
            this.lblMagnification.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_LENS_MAGNIFICATION_LABEL);

            this.colMagnification1.Header = 
            this.colMagnification.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_MAGNIFICATION_COL_LABEL);
            this.colCurrentX.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_X_COL_LABEL);
            this.colCurrentY.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_Y_COL_LABEL);
            this.colResultX1.Header =
            this.colResultX.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_RESULT_X_COL_LABEL);
            this.colResultY1.Header =
            this.colResultY.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_RESULT_Y_COL_LABEL);

            this.calDifferenceMaxTargetX.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIFFERENCE_MAXIMUM_TARGET_X_LABEL);
            this.calDifferenceMinTargetX.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIFFERENCE_MINIMUM_TARGET_X_LABEL);
            this.calDifferenceMaxTargetY.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIFFERENCE_MAXIMUM_TARGET_Y_LABEL);
            this.calDifferenceMinTargetY.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_DIFFERENCE_MINIMUM_TARGET_Y_LABEL);

            this.calRepetionThreeSigma.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_REPETITION_THREE_SIGMA_LABEL);
            this.calRepetitionDifferenceMax.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_REPETITION_DIFFERENCE_MAXIMUM_LABEL);
            this.calRepetitionDifferenceMin.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_REPETITION_DIFFERENCE_MINIMUM_LABEL);
            this.calRepetitionResult.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_TITLE_LABEL);
        }
    }
}