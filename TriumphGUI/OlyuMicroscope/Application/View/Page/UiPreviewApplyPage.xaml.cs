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
	public partial class UiPreviewApplyPage
	{
		public UiPreviewApplyPage()
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
            this.btnApply.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DIALOG_APPLY);
            this.btnCancel.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MESSAGEBOX_CANCEL);
            this.btnStop.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DIALOG_STOP);
        }
    }
}