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
	public partial class UiCalibrationHistoryDetailPage
	{
        public UiCalibrationHistoryDetailPage()
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
            this.lblSaveName.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_SAVE_NAME_COL_LABEL);
            this.colMagnification.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_MAGNIFICATION_COL_LABEL);
            this.colCurrentX.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_X_COL_LABEL);
            this.colCurrentY.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_Y_COL_LABEL);
            this.btnClose.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_CLOSE_BUTTON);
        }
    }
}