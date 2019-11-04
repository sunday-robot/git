using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx {
    public partial class DsxApplication : Control {
        public partial class MicroscopeWindow : Control {
            public class UiImageDisplayPage : Control {
                public UiImageDisplayPage(AutomationElement parent) :
                    base(FU.FindChildByAutomationId(parent, "frmImageDisplayArea")) {
                }

                public Button GetSpeedButton() {
                    return new Button(FU.FindDescendantByAutomationId(GetAutomationElement(), "cmdSpeed"));
                }

                public TextBox GetSpecificationDistanceTextBox() {
                    return new TextBox(FU.FindDescendantByAutomationId(GetAutomationElement(), "txbSpecificationDistance"));
                }

                public Button GetRightButton() {
                    return new Button(FU.FindChildByAutomationId(GetAutomationElement(), "cmdRight"));
                }

                public Button GetLeftButton() {
                    return new Button(FU.FindChildByAutomationId(GetAutomationElement(), "cmdLeft"));
                }
            }
        }
    }
}
