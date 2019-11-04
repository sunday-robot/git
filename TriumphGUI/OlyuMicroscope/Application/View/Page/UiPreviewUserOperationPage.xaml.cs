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
	public partial class UiPreviewUserOperationPage
	{
		public UiPreviewUserOperationPage()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
		}

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.btnFile.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_FILE_BUTTON);
            this.btnMaker.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_MAKER_BUTTON);
            this.btnSave.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_SAVE_BUTTON);
            this.btnBack.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_BACK_BUTTON);
        }
	}
}