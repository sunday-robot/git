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
	public partial class UiIlluminationSettingPage
	{
        public UiIlluminationSettingPage()
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
            this.lblIlluminationSettingPageBase.Content =
            this.lblIlluminationSettingPageFlexibleLowMagBF.Content =
            this.lblIlluminationSettingPageUprightHighMagBFCoaxial.Content =
            this.lblIlluminationSettingPageUprightHighMagBFFiber.Content =
            this.lblIlluminationSettingPageUprightHighMagDF.Content =
            this.lblIlluminationSettingPageUprightHighMagMIXCoaxial.Content =
            this.lblIlluminationSettingPageUprightHighMagMIXFiber.Content =
            this.lblIlluminationSettingPageUprightHighMagDICCoaxial.Content =
            this.lblIlluminationSettingPageUprightHighMagDICFiber.Content =
            this.lblIlluminationSettingPageUprightHighMagPOCoaxial.Content =
            this.lblIlluminationSettingPageUprightHighMagPOFiber.Content =
            this.lblIlluminationSettingPageInvertHighMagBFCoaxial.Content =
            this.lblIlluminationSettingPageInvertHighMagBFFiber.Content =
            this.lblIlluminationSettingPageInvertHighMagDF.Content =
            this.lblIlluminationSettingPageInvertHighMagMIXCoaxial.Content =
            this.lblIlluminationSettingPageInvertHighMagMIXFiber.Content =
            this.lblIlluminationSettingPageInvertHighMagDICCoaxial.Content =
            this.lblIlluminationSettingPageInvertHighMagDICFiber.Content =
            this.lblIlluminationSettingPageInvertHighMagPOCoaxial.Content =
            this.lblIlluminationSettingPageInvertHighMagPOFiber.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_TITLE_NAME);

            this.grpbIlluminationSettingbase.Header =
            this.grpbIlluminationSettingFlexibleLowMagBF.Header =
            this.grpbIlluminationSettingUprightHighMagBFCoaxial.Header =
            this.grpbIlluminationSettingUprightHighMagBFFiber.Header =
            this.grpbIlluminationSettingUprightHighMagDF.Header =
            this.grpbIlluminationSettingUprightHighMagMIXCoaxial.Header =
            this.grpbIlluminationSettingUprightHighMagMIXFiber.Header =
            this.grpbIlluminationSettingUprightHighMagDICCoaxial.Header =
            this.grpbIlluminationSettingUprightHighMagDICFiber.Header =
            this.grpbIlluminationSettingUprightHighMagPOCoaxial.Header =
            this.grpbIlluminationSettingUprightHighMagPOFiber.Header =
            this.grpbIlluminationSettingInvertHighMagBFCoaxial.Header =
            this.grpbIlluminationSettingInvertHighMagBFFiber.Header =
            this.grpbIlluminationSettingInvertHighMagDF.Header =
            this.grpbIlluminationSettingInvertHighMagMIXCoaxial.Header =
            this.grpbIlluminationSettingInvertHighMagMIXFiber.Header =
            this.grpbIlluminationSettingInvertHighMagDICCoaxial.Header =
            this.grpbIlluminationSettingInvertHighMagDICFiber.Header =
            this.grpbIlluminationSettingInvertHighMagPOCoaxial.Header =
            this.grpbIlluminationSettingInvertHighMagPOFiber.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP);

            this.grpbIlluminationBase.Header=
            this.grpbIlluminationFlexibleLowMagBF.Header=
            this.grpbIlluminationUprightHighMagDF.Header=
            this.grpbIlluminationUprightHighMagMIXCoaxial.Header=
            this.grpbIlluminationUprightHighMagMIXFiber.Header=
            this.grpbIlluminationInvertHighMagDF.Header=
            this.grpbIlluminationInvertHighMagMIXCoaxial.Header=
            this.grpbIlluminationInvertHighMagMIXFiber.Header=

            this.lblBrightnessBase.Content =
            this.lblBrightnessUprightHighMagBFCoaxial.Content=
            this.lblBrightnessUprightHighMagBFFiber.Content =
            this.lblBrightnessUprightHighMagMIXCoaxial.Content =
            this.lblBrightnessUprightHighMagMIXFiber.Content =
            this.lblBrightnessUprightHighMagDICCoaxial.Content =
            this.lblBrightnessUprightHighMagDICFiber.Content =
            this.lblBrightnessUprightHighMagPOCoaxial.Content =
            this.lblBrightnessUprightHighMagPOFiber.Content =
            this.lblBrightnessInvertHighMagBFCoaxial.Content =
            this.lblBrightnessInvertHighMagBFFiber.Content =
            this.lblBrightnessInvertHighMagMIXCoaxial.Content =
            this.lblBrightnessInvertHighMagMIXFiber.Content =
            this.lblBrightnessInvertHighMagDICCoaxial.Content =
            this.lblBrightnessInvertHighMagDICFiber.Content =
            this.lblBrightnessInvertHighMagPOCoaxial.Content =
            this.lblBrightnessInvertHighMagPOFiber.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_BRIGHTNESS_LIGHT_UP);

            this.lblBackLightBase.Content =
            this.lblBackLightFlexibleLowMagBF.Content =
            this.lblBackLightUprightHighMagBFCoaxial.Content =
            this.lblBackLightUprightHighMagBFFiber.Content =
            this.lblBackLightUprightHighMagDF.Content =
            this.lblBackLightUprightHighMagMIXCoaxial.Content =
            this.lblBackLightUprightHighMagMIXFiber.Content =
            this.lblBackLightUprightHighMagDICCoaxial.Content =
            this.lblBackLightUprightHighMagDICFiber.Content =
            this.lblBackLightUprightHighMagPOCoaxial.Content =
            this.lblBackLightUprightHighMagPOFiber.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_BRIGHTNESS_BACK_LIGHT);

            this.tglbBrightnessONBase.Content=
            this.tglbIlluminationONBase.Content =
            this.tglbBackLightONBase.Content =
            this.tglbIlluminationONFlexibleLowMagBF.Content =
            this.tglbBackLightONFlexibleLowMagBF.Content =
            this.tglbBrightnessONUprightHighMagBFCoaxial.Content =
            this.tglbBackLightONUprightHighMagBFCoaxial.Content =
            this.tglbBrightnessONUprightHighMagBFFiber.Content =
            this.tglbBackLightONUprightHighMagBFFiber.Content =
            this.tglbBackLightONUprightHighMagDF.Content =
            this.tglbBrightnessONUprightHighMagMIXCoaxial.Content =
            this.tglbBackLightONUprightHighMagMIXCoaxial.Content =
            this.tglbBrightnessONUprightHighMagMIXFiber.Content =
            this.tglbBackLightONUprightHighMagMIXFiber.Content =
            this.tglbBrightnessONUprightHighMagDICCoaxial.Content =
            this.tglbBackLightONUprightHighMagDICCoaxial.Content =
            this.tglbBrightnessONUprightHighMagDICFiber.Content =
            this.tglbBackLightONUprightHighMagDICFiber.Content =
            this.tglbBrightnessONUprightHighMagPOCoaxial.Content =
            this.tglbBackLightONUprightHighMagPOCoaxial.Content =
            this.tglbBrightnessONUprightHighMagPOFiber.Content =
            this.tglbBackLightONUprightHighMagPOFiber.Content =
            this.tglbBrightnessONInvertHighMagBFCoaxial.Content =
            this.tglbBrightnessONInvertHighMagBFFiber.Content =
            this.tglbBrightnessONInvertHighMagMIXCoaxial.Content =
            this.tglbBrightnessONInvertHighMagMIXFiber.Content =
            this.tglbBrightnessONInvertHighMagDICCoaxial.Content =
            this.tglbBrightnessONInvertHighMagDICFiber.Content =
            this.tglbBrightnessONInvertHighMagPOCoaxial.Content =
            this.tglbBrightnessONInvertHighMagPOFiber.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_LIGHT_ON_TOGGLEBUTTON_LABEL);

            this.lblIlluminationPositionBase.Content =
            this.lblIlluminationPositionFlexibleLowMagBF.Content =
            this.lblIlluminationPositionUprightHighMagDF.Content =
            this.lblIlluminationPositionUprightHighMagMIXCoaxial.Content =
            this.lblIlluminationPositionUprightHighMagMIXFiber.Content =
            this.lblIlluminationPositionInvertHighMagDF.Content =
            this.lblIlluminationPositionInvertHighMagMIXCoaxial.Content =
            this.lblIlluminationPositionInvertHighMagMIXFiber.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_ILLMINATION_POSITION_LABEL);

            this.lblExposureBase.Content =
            this.lblExposureFlexibleLowMagBF.Content =
            this.lblExposureUprightHighMagBFCoaxial.Content =
            this.lblExposureUprightHighMagBFFiber.Content =
            this.lblExposureUprightHighMagDF.Content =
            this.lblExposureUprightHighMagMIXCoaxial.Content =
            this.lblExposureUprightHighMagMIXFiber.Content =
            this.lblExposureUprightHighMagDICCoaxial.Content =
            this.lblExposureUprightHighMagDICFiber.Content =
            this.lblExposureUprightHighMagPOCoaxial.Content =
            this.lblExposureUprightHighMagPOFiber.Content =
            this.lblExposureInvertHighMagBFCoaxial.Content =
            this.lblExposureInvertHighMagBFFiber.Content =
            this.lblExposureInvertHighMagDF.Content =
            this.lblExposureInvertHighMagMIXCoaxial.Content =
            this.lblExposureInvertHighMagMIXFiber.Content =
            this.lblExposureInvertHighMagDICCoaxial.Content =
            this.lblExposureInvertHighMagDICFiber.Content =
            this.lblExposureInvertHighMagPOCoaxial.Content =
            this.lblExposureInvertHighMagPOFiber.Content =
            this.lblExposureBase.Content =
            this.lblExposureBase.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_EXPOSURE_TIME_LABEL);

            this.tglbAutoExposureBase.Content =
            this.tglbAutoExposureFlexibleLowMagBF.Content=
            this.tglbAutoExposureUprightHighMagBFCoaxial.Content =
            this.tglbAutoExposureUprightHighMagBFFiber.Content =
            this.tglbAutoExposureUprightHighMagDF.Content =
            this.tglbAutoExposureUprightHighMagMIXCoaxial.Content =
            this.tglbAutoExposureUprightHighMagMIXFiber.Content =
            this.tglbAutoExposureUprightHighMagDICCoaxial.Content =
            this.tglbAutoExposureUprightHighMagDICFiber.Content =
            this.tglbAutoExposureUprightHighMagPOCoaxial.Content =
            this.tglbAutoExposureUprightHighMagPOFiber.Content =
            this.tglbAutoExposureInvertHighMagBFCoaxial.Content =
            this.tglbAutoExposureInvertHighMagBFFiber.Content =
            this.tglbAutoExposureInvertHighMagDF.Content =
            this.tglbAutoExposureInvertHighMagMIXCoaxial.Content =
            this.tglbAutoExposureInvertHighMagMIXFiber.Content =
            this.tglbAutoExposureInvertHighMagDICCoaxial.Content =
            this.tglbAutoExposureInvertHighMagDICFiber.Content =
            this.tglbAutoExposureInvertHighMagPOCoaxial.Content =
            this.tglbAutoExposureInvertHighMagPOFiber.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_AUTO_EXPOSURE_TOGGLEBUTTON_LABEL);

            this.grpbExposureBase.Header =
            this.grpbExposureFlexibleLowMagBF.Header =
            this.grpbExposureUprightHighMagBFCoaxial.Header =
            this.grpbExposureUprightHighMagBFFiber.Header =
            this.grpbExposureUprightHighMagDF.Header =
            this.grpbExposureUprightHighMagMIXCoaxial.Header =
            this.grpbExposureUprightHighMagMIXFiber.Header =
            this.grpbExposureUprightHighMagDICCoaxial.Header =
            this.grpbExposureUprightHighMagDICFiber.Header =
            this.grpbExposureUprightHighMagPOCoaxial.Header =
            this.grpbExposureUprightHighMagPOFiber.Header =
            this.grpbExposureInvertHighMagBFCoaxial.Header =
            this.grpbExposureInvertHighMagBFFiber.Header =
            this.grpbExposureInvertHighMagDF.Header =
            this.grpbExposureInvertHighMagMIXCoaxial.Header =
            this.grpbExposureInvertHighMagMIXFiber.Header =
            this.grpbExposureInvertHighMagDICCoaxial.Header =
            this.grpbExposureInvertHighMagDICFiber.Header =
            this.grpbExposureInvertHighMagPOCoaxial.Header =
            this.grpbExposureInvertHighMagPOFiber.Header =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_LABEL);

            this.lblSensitivityBase.Content =
            this.lblSensitivityFlexibleLowMagBF.Content =
            this.lblSensitivityUprightHighMagBFCoaxial.Content =
            this.lblSensitivityUprightHighMagBFFiber.Content =
            this.lblSensitivityUprightHighMagDF.Content =
            this.lblSensitivityUprightHighMagMIXCoaxial.Content =
            this.lblSensitivityUprightHighMagMIXFiber.Content =
            this.lblSensitivityUprightHighMagDICCoaxial.Content =
            this.lblSensitivityUprightHighMagDICFiber.Content =
            this.lblSensitivityUprightHighMagPOCoaxial.Content =
            this.lblSensitivityUprightHighMagPOFiber.Content =
            this.lblSensitivityInvertHighMagBFCoaxial.Content =
            this.lblSensitivityInvertHighMagBFFiber.Content =
            this.lblSensitivityInvertHighMagDF.Content =
            this.lblSensitivityInvertHighMagMIXCoaxial.Content =
            this.lblSensitivityInvertHighMagMIXFiber.Content =
            this.lblSensitivityInvertHighMagDICCoaxial.Content =
            this.lblSensitivityInvertHighMagDICFiber.Content =
            this.lblSensitivityInvertHighMagPOCoaxial.Content =
            this.lblSensitivityInvertHighMagPOFiber.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_ISO_SENSITIVETY_LABEL);

            this.lblDICInvertHighMagDICCoaxial.Content =
            this.lblDICUprightHighMagDICCoaxial.Content =
            this.lblDICUprightHighMagDICFiber.Content =
            this.lblDICInvertHighMagDICFiber.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_DIC_SETTING_LABEL);
        }

        #endregion GetContentResource
    }
}