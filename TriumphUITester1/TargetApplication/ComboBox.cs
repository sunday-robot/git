using System.Windows.Automation;

namespace TargetApplication
{
    public class ComboBox : Control
    {
        public ComboBox(AutomationElement ae)
            : base(ae)
        {
        }

        public void SetText(string s)
        {
            var valuePattern = (ValuePattern)GetAutomationElement().GetCurrentPattern(ValuePattern.Pattern);
            valuePattern.SetValue(s);
        }
    }
}
