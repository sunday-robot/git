using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace TargetApplication
{
    public class TreeItem : Control
    {
        public TreeItem(AutomationElement ae)
            : base(ae)
        {
        }

        public void Expand()
        {
            var toggleButton = new ToggleButton(FindUtil.FindChildByAutomationId(GetAutomationElement(), "Expander"));
            toggleButton.Toggle();
        }

        public void Select()
        {
            var toggleButton = new ToggleButton(FindUtil.FindChildByClassName(GetAutomationElement(), "CheckBox"));
            toggleButton.Toggle();
            var pc = new PropertyCondition(AutomationElement.ClassNameProperty, "CheckBox");
            var checkBox = new CheckBox(GetAutomationElement().FindFirst(TreeScope.Children, pc));
            checkBox.Select();
        }
    }
}
