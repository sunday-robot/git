using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx
{
    public partial class DsxApplication : Control
    {
        public class ApplicationWindow : Control
        {
            public ApplicationWindow()
                : base(FU.FindWindowByAutomationId("frmMain"))
            {
            }

            public Button GetExitApplicationButton()
            {
                return new Button(FU.FindChildByName(GetAutomationElement(), "cmdExitApplication"));
            }

            public RadioButton GetMeasurementRadioButton()
            {
                return new RadioButton(FU.FindChildByName(GetAutomationElement(), "rdbMeasurement"));
            }
        }
    }
}
