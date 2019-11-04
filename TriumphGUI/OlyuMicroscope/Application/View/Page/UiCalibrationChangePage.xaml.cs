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
	public partial class UiCalibrationChangePage
	{
        public UiCalibrationChangePage()
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
            this.colLensName.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_LENS_NAME_LABEL);
            this.colDefault.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_LENS_DEFAULT_LABEL);
            this.colUser.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_LENS_USER_LABEL);
            this.colMaker.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_LENS_MAKER_LABEL);
            this.btnAllDefault.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_ALL_DEFAULT_BUTTON);
            this.btnAllUser.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_ALL_USER_BUTTON);
            this.btnAllMaker.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_ALL_MAKER_BUTTON);
            this.btnApply.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_APPLY_BUTTON);
            this.btnClose.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_CALIBRATION_CHANGE_PAGE_CLOSE_BUTTON);
        }
    }
}