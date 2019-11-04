using System.Windows.Automation;

namespace TargetApplication
{
    public class RadioButton : Control
    {
        public RadioButton(AutomationElement ae)
            : base(ae)
        {
        }

        public void Select()
        {
            var selectionItemPattern = (SelectionItemPattern)GetAutomationElement().GetCurrentPattern(SelectionItemPattern.Pattern);
            selectionItemPattern.Select();
        }
    }
}
