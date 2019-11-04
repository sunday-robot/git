using System.Windows.Automation;

namespace TargetApplication
{
    public class Button : Control
    {
        public Button(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public void Press()
        {
            var invokePattern = (InvokePattern)GetAutomationElement().GetCurrentPattern(InvokePattern.Pattern);
            invokePattern.Invoke();
        }
    }
}
