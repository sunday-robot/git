using System.Windows.Automation;

namespace TargetApplication
{
    public class TextBox : Control
    {
        public TextBox(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        public void SetText(string s)
        {
            var valuePattern = (ValuePattern)GetAutomationElement().GetCurrentPattern(ValuePattern.Pattern);
            valuePattern.SetValue(s);
        }

        public string GetText()
        {
            var valuePattern = (ValuePattern)GetAutomationElement().GetCurrentPattern(ValuePattern.Pattern);
            return valuePattern.Current.Value;
        }

    }
}
