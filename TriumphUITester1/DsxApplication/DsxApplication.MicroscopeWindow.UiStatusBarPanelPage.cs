using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx {
    public partial class DsxApplication : Control {
        public partial class MicroscopeWindow : Control {
            public class UiStatusBarPanelPage : Control {
                public UiStatusBarPanelPage(AutomationElement parent)
                    : base(FU.FindChildByAutomationId(parent, "frmStatusBar")) {
                }

                public AutomationElement GetXYPosition() {
                    // "("などで一意に決定できればなおよいが、今のところ1番目(index=0)を固定で
                    // XY位置表示部分として取得している
                    var status = FU.FindChildrenByClassName(GetAutomationElement(), "Text");
                    return status[0];
                }

                public AutomationElement GetZPosition() {
                    // "("などで一意に決定できればなおよいが、今のところ3番目(index=2)を固定で
                    // Z位置表示部分として取得している
                    var status = FU.FindChildrenByClassName(GetAutomationElement(), "Text");
                    return status[2];
                }
            }
        }
    }
}
