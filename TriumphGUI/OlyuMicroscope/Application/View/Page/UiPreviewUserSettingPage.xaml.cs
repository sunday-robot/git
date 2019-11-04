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
	public partial class UiPreviewUserSettingPage
	{
		public UiPreviewUserSettingPage()
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
            this.lblFileName.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_FILENAME_LABEL);
            this.chkRegister.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_REGISTER_CHECKBOX);

            ((System.Windows.Controls.ComboBoxItem)this.cmbUserList.Items[0]).Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_USERLIST_NON_LABEL);
            ((System.Windows.Controls.ComboBoxItem)this.cmbUserList.Items[1]).Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_USERLIST_USER1_LABEL);
            ((System.Windows.Controls.ComboBoxItem)this.cmbUserList.Items[2]).Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_USERLIST_USER2_LABEL);
            ((System.Windows.Controls.ComboBoxItem)this.cmbUserList.Items[3]).Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_USERLIST_USER3_LABEL);

            this.lblComment.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_COMMENT_LABEL);
        }
	}
}