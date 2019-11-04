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
	public partial class UiImageRevisionPage
	{
        public UiImageRevisionPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblImageRevisionPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_TITLE);
            this.lblHDR.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_HDR_TITLE);
            this.lblContrast.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_CONTRAST_TITLE);
            this.lblWIDER.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_TITLE);
            this.rbtnHDRTexture.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_STANDARD_RADIO_BUTTON_TITLE);
            this.rbtnHDRAntihalation.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_HIGH_SPEED_RADIO_BUTTON_TITLE);
            this.lblIdentificationColoredEmphasis.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_SPECIFIC_COLOR_GROUP_LABEL);
            this.tglbtxtFastHDR1.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_FASTHDR_BUTTON_TEXT);
            this.tglbtxtFastHDR2.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_HDR_BUTTON_TEXT);
            this.tglbtxtFineHDR1.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_FINEHDR_BUTTON_TEXT);
            this.tglbtxtFineHDR2.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_HDR_BUTTON_TEXT);
            this.tglbtxtCpuHDR.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_IMAGE_REVISION_GROUP_HDR_BUTTON_TEXT);
        }

        #endregion GetContentResource
    }
}