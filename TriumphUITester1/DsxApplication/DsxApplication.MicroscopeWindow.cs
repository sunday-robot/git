using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx
{
    public partial class DsxApplication : Control
    {
        public partial class MicroscopeWindow : Control
        {
            private UiImageDisplayPage _imageDisplayPage;
            private UiImageRevisionPage _imageRevisionPage;
            private UiIlluminationSettingPage _illuminationSettingPage;
            private UiPhotographySettingPage _photographSettingPage;
            private UiDetailSettingMainPage _detailSettingPage;
            private UiStatusBarPanelPage _statusPanelPage;
            private MenuButtons _menuButtons;

            private MicroscopeWindow(AutomationElement automationElement) : base(automationElement) {
            }

            public static MicroscopeWindow CreateInstance(AutomationElement parent) {
                var ae = FU.FindChildByName(parent, "UiMicroscopeFrameWindow");
                return new MicroscopeWindow(ae);
            }

            public UiImageDisplayPage GetImageDisplayPage()
            {
                if (_imageDisplayPage == null)
                {
                    _imageDisplayPage = new UiImageDisplayPage(GetAutomationElement());
                }
                return _imageDisplayPage;
            }

            /// <summary>
            /// 画像補正ペインを取得する
            /// </summary>
            /// <returns></returns>
            public UiImageRevisionPage GetUiImageRevisionPage()
            {
                if (_imageRevisionPage == null)
                {
                    _imageRevisionPage = new UiImageRevisionPage(GetAutomationElement());
                }
                return _imageRevisionPage;
            }

            public UiIlluminationSettingPage GetIlluminationSettingPage()
            {
                if (_illuminationSettingPage == null)
                {
                    _illuminationSettingPage = new UiIlluminationSettingPage(GetAutomationElement());
                }
                return _illuminationSettingPage;
            }

            public UiPhotographySettingPage GetPhotographySettingPage()
            {
                if (_photographSettingPage == null)
                {
                    _photographSettingPage = new UiPhotographySettingPage(GetAutomationElement());
                }
                return _photographSettingPage;
            }

            public UiDetailSettingMainPage GetDetailSettingPage()
            {
                if (_detailSettingPage == null)
                {
                    _detailSettingPage = new UiDetailSettingMainPage(GetAutomationElement());
                }
                return _detailSettingPage;
            }

            public UiStatusBarPanelPage GetStatusBar()
            {
                if (_statusPanelPage == null)
                {
                    _statusPanelPage = new UiStatusBarPanelPage(GetAutomationElement());
                }
                return _statusPanelPage;
            }

            /// <summary>
            /// 画面右上の、「ライブ」、「マルチプレビュー」、…、「応用撮影」のボタンのメニュー
            /// </summary>
            /// <returns></returns>
            public MenuButtons GetMenuButtons() {
                if (_menuButtons == null) {
                    _menuButtons = new MenuButtons(GetAutomationElement());
                }
                return _menuButtons;
            }

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public ToggleButton GetWiderButton()
            {
                return new ToggleButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "tglbWIDER"));
            }

            public Slider GetCameraExposureTimeSlider()
            {
                return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldExposureUprightHighMagBFFiber"));
            }

            public ToggleButton GetCameraAeOnOffButton()
            {
                return new ToggleButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "tglbAutoExposureUprightHighMagBFFiber"));
            }

            public ToggleButton GetImageRevisionContrastOnOffButton()
            {
                return new ToggleButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "tglbContrast"));
            }

            public AutomationElement GetSettingTool()
            {
                return FU.FindChildByAutomationId(GetAutomationElement(), "frmSettingTool");
            }

            public Button GetSettingToolNearSampleRoughMoveButton()
            {
                return new Button(FU.FindChildByAutomationId(GetSettingTool(), "btnNearSampleRoughMove"));
            }

            public AutomationElement GetSpeculumForm()
            {
                return FU.FindChildByAutomationId(GetAutomationElement(), "frmSpeculum");
            }

            public RadioButton GetSpeculumMicrosopyRadioButton()
            {
                return new RadioButton(FU.FindChildByAutomationId(GetSpeculumForm(), "rbtnMicroscopyBf"));
            }

            public RadioButton GetSpeculumMicroscopyPoRadioButton()
            {
                return new RadioButton(FU.FindChildByAutomationId(GetSpeculumForm(), "rbtnMicroscopyPo"));
            }
        }
    }
}
