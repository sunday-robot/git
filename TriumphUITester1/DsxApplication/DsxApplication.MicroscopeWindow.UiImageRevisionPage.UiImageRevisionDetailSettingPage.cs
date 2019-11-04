using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx {
    public partial class DsxApplication : Control {
        public partial class MicroscopeWindow : Control {
            public partial class UiImageRevisionPage : Control {
                public class UiImageRevisionDetailSettingPage : Control {
                    public UiImageRevisionDetailSettingPage(AutomationElement parent)
                        : base(FU.FindDescendantByAutomationId(_GetPage(parent), "frmImageRevisionDetailSettingPage")) {
                    }

                    private static AutomationElement _GetPage(AutomationElement parent) {
                        return FU.FindDescendantByAutomationId(parent, "frmImageRevisionDetailSettingPage");
                    }

                    /// <summary>
                    /// 画像補正-詳細設定-コントラスト強調の展開トグルボタン
                    /// </summary>
                    /// <returns></returns>
                    public ToggleButton GetContrastToggleButton() {
                        var group = FU.FindDescendantByAutomationId(GetAutomationElement(), "expContrastPage");
                        return new ToggleButton(FU.FindChildByAutomationId(group, "HeaderSite"));
                    }

                    public ToggleButton GetHdrTeToggleButton() {
                        var group = FU.FindDescendantByAutomationId(GetAutomationElement(), "expHDRPage");
                        return new ToggleButton(FU.FindChildByAutomationId(group, "HeaderSite"));
                    }

                    public ToggleButton GetHdrAhToggleButton() {
                        var group = FU.FindDescendantByAutomationId(GetAutomationElement(), "expAntiHalationStandardPage");
                        return new ToggleButton(FU.FindChildByAutomationId(group, "HeaderSite"));
                    }
                }
            }
        }
    }
}
