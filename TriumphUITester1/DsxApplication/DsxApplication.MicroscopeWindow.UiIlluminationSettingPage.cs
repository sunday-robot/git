using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx
{
    public partial class DsxApplication : Control
    {
        public partial class MicroscopeWindow : Control {
            public class UiIlluminationSettingPage : Control
            {
                public UiIlluminationSettingPage(AutomationElement parent)
                    : base(FU.FindChildByAutomationId(parent, "frmIlluminationSetting"))
                {
                }

                public AutomationElement GetBrightnessValueUprightHighMagBFFiberXX()
                {
                    return FU.FindChildByAutomationId(GetAutomationElement(), "lblBrightnessValueUprightHighMagBFFiber");
                }

                public AutomationElement GetBrightnessUprightHighMagBFFiberSlider()
                {
                    return FU.FindChildByAutomationId(GetAutomationElement(), "sldBrightnessUprightHighMagBFFiber");
                }

                private DetailSettingPage _detailSettingPage;

                public DetailSettingPage GetDetailSettingPage()
                {
                    if (_detailSettingPage == null) {
                        _detailSettingPage = new DetailSettingPage(GetAutomationElement());
                    }
                    return _detailSettingPage;
                }

                public class DetailSettingPage : Control {
                    public DetailSettingPage(AutomationElement parent)
                        : base(FU.FindDescendantByAutomationId(parent, "frmIlluminationDetailSettingPage")) {
                    }

                    public ToggleButton GetAeToggleButton() {
                        var group = FU.FindDescendantByAutomationId(GetAutomationElement(), "expAEPage");
                        var ae = FU.FindDescendantByAutomationId(group, "HeaderSite");
                        return new ToggleButton(ae);
                    }

                    public Slider GetAeSlider() {
                        var page = FU.FindDescendantByAutomationId(GetAutomationElement(), "grbAE");
                        var ae = FU.FindDescendantByClassName(page, "Slider");
                        return new Slider(ae);
                    }
                }

                public ToggleButton GetDetailSettingButton()
                {
                    var group = FU.FindDescendantByAutomationId(GetAutomationElement(), "expIlluminationSettingPageUprightHighMagBFFiber");
                    var ae = FU.FindDescendantByAutomationId(group, "HeaderSite");
                    return new ToggleButton(ae);
                }

                public Button GetBrightnessUprightHighMagBFFiberSliderDecreaseSmallButton()
                {
                    return new Button(FU.FindChildByAutomationId(GetBrightnessUprightHighMagBFFiberSlider(), "DecreaseSmall"));
                }

                public AutomationElement GetBrightnessValueUprightHighMagBFFiberLabel()
                {
                    return FU.FindChildByAutomationId(GetAutomationElement(), "lblBrightnessValueUprightHighMagBFFiber");
                }

            }
        }
    }
}
