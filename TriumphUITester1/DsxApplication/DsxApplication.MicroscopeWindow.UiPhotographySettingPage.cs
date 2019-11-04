using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx {
    public partial class DsxApplication : Control {
        public partial class MicroscopeWindow : Control {
            public class UiPhotographySettingPage : Control {
                private Button _AcquisitionSnapStartButton;

                public UiPhotographySettingPage(AutomationElement parent)
                    : base(FU.FindChildByAutomationId(parent, "frmPhotographySetting")) {
                }

                public Button GetAcquisitionSnapStartButton() {
                    if (_AcquisitionSnapStartButton == null) {
                        _AcquisitionSnapStartButton = new Button(FU.FindChildByAutomationId(GetAutomationElement(), "btnAcquisitionSnapStart"));
                    }
                    return _AcquisitionSnapStartButton;
                }
            }
        }
    }
}
