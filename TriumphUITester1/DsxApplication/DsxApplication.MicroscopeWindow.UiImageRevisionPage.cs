using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx
{
    public partial class DsxApplication : Control
    {
        public partial class MicroscopeWindow : Control {
            public partial class UiImageRevisionPage : Control
            {
                private UiImageRevisionDetailSettingPage _imageRevisionDetailSettingPane;

                public UiImageRevisionPage(AutomationElement parent)
                    : base(FU.FindDescendantByAutomationId(parent, "frmImageRevision"))
                {
                }

                public UiImageRevisionDetailSettingPage GetDetailSettingPage()
                {
                    if (_imageRevisionDetailSettingPane == null)
                    {
                        _imageRevisionDetailSettingPane = new UiImageRevisionDetailSettingPage(GetAutomationElement());
                    }
                    return _imageRevisionDetailSettingPane;
                }

                /// <summary>
                /// 画像補正-詳細設定-HDR(テクスチャ強調) 明るさスライダーを取得する
                /// </summary>
                /// <returns></returns>
                public Slider GetHdrTeBrightnessSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRBrightness"));
                }


                public Slider GetHdrTeTextureSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRTexture"));
                }

                public Slider GetHdrTeContrastSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRContrast"));
                }

                public Slider GetHdrTeChromeSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRChrome"));
                }

                public RadioButton GetContrastLowRadioButton()
                {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnL"));
                }

                public RadioButton GetContrastMiddleRadioButton()
                {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnM"));
                }

                public RadioButton GetContrastHighRadioButton()
                {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnH"));
                }

                /// <summary>
                /// 画像補正-詳細設定-HDR(ハレーション除去) 明るさスライダーを返す
                /// </summary>
                /// <returns></returns>
                public Slider GetHdrAhBrightnessSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationBrightness"));
                }

                public Slider GetHdrAhTextureSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationTexture"));
                }

                public Slider GetHdrAhContrastSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationContrast"));
                }

                public Slider GetHdrAhChromeSlider()
                {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public ToggleButton GetHdrWiderToggleButton()
                {
                    return new ToggleButton(FU.FindChildByAutomationId(GetAutomationElement(), "tglbHDRWIDER"));
                }

                public AutomationElement GetLiveColorToggleButton()
                {
                    return FU.FindChildByAutomationId(GetAutomationElement(), "tglbLiveColor");
                }

                public ToggleButton GetDetailSettingButton()
                {
                    var ae = FU.FindDescendantByAutomationId(GetAutomationElement(), "expImageRevisionPage");
                    return new ToggleButton(FU.FindChildByAutomationId(ae, "HeaderSite"));
                }

            }
        }
    }
}
