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
	public partial class UiPreviewPatternSelectPage
	{
        public UiPreviewPatternSelectPage()
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
            this.tbiObject.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_TITLE_NAME);
            this.btnDefect.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_DEFECT_BUTTON);
            this.btnFlat.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_FLAT_BUTTON);
            this.btnSubstrate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_SUBSTRATE_BUTTON);
            this.btnContamination.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_CONTAMINATION_BUTTON);
            this.btnIrregularity.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_IRREGULARITY_BUTTON);

            this.tbiCondition.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_TITLE_NAME);
            this.btnBrightness.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_BRIGHTNESS_BUTTON);
            this.btnLighting.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_LIGHTING_BUTTON);
            this.btnImageEnhancement.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_IMAGE_ENH_BUTTON);
            this.btWDR.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_WDR_BUTTON);
            this.btnShearing.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_SHEARING_BUTTON);

            this.btnUserOne.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER1_BUTTON);
            this.btnUserTwo.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER2_BUTTON);
            this.btnUserThree.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER3_BUTTON);
            this.btnOthers.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_OTHER_BUTTON);
            this.btnCreateSetting.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_CREATE_SET_BUTTON);
        }
    }
}