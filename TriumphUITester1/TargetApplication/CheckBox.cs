using System.Windows.Automation;

namespace TargetApplication
{
    public class CheckBox : Control
    {
        public CheckBox(AutomationElement ae)
            : base(ae)
        {
        }

        public void Select()
        {
            var x = GetAutomationElement().GetSupportedPatterns();
            var togglePattern = (TogglePattern)GetAutomationElement().GetCurrentPattern(TogglePattern.Pattern);
            togglePattern.Toggle();
        }
    }
}
