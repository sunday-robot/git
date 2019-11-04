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
	public partial class UiCalibrationHistoryPage
	{
		public UiCalibrationHistoryPage()
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
            this.colRevolver.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_REVOLVER_COL_LABEL);
            this.colLensName.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_LENS_NAME_COL_LABEL);
            this.colTarget.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_TARGET_COL_LABEL);
            this.colSaveName.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_SAVE_NAME_COL_LABEL);
            this.colDate.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_DATE_COL_LABEL);
        }
    }
}