using System.Windows.Automation;

namespace TargetApplication
{
    public class ToggleButton : Control
    {
        public ToggleButton(AutomationElement ae)
            : base(ae)
        {
        }

        public void Toggle()
        {
            var invokePattern = (TogglePattern)GetAutomationElement().GetCurrentPattern(TogglePattern.Pattern);
            invokePattern.Toggle();
        }

        public ToggleState GetToggleState()
        {
            var pattern = (TogglePattern)GetAutomationElement().GetCurrentPattern(TogglePattern.Pattern);
            return pattern.Current.ToggleState;
        }

    }
}
