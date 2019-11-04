using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;
using System;

namespace Dsx
{
    public partial class DsxApplication : Control
    {
        public partial class MicroscopeWindow : Control
        {
            public class MenuButtons : Control {
                private AutomationElementCollection _buttons;
                private ToggleButton _liveToggleButton;
                private ToggleButton _detailSettingToggleButton;

                public MenuButtons(AutomationElement parent)
                    : base(FU.FindDescendantByAutomationId(parent, "frmMenu")) {
                }

                private AutomationElementCollection _getButtons() {
                    if (_buttons == null) {
                        _buttons = FU.FindChildrenByClassName(GetAutomationElement(), "Button");
                    }
                    return _buttons;
                }

                private ToggleButton _getMenuToggleButton(string id) {
                    var menuItems = _getButtons();
                    for (int i = 0; i < menuItems.Count; i++) {
                        var button = menuItems[i].FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, id));
                        if (button != null) {
                            return new ToggleButton(menuItems[i]);
                        }
                    }
                    throw new Exception(string.Format("[{0}] was not found.", id));
                }

                public ToggleButton GetLiveToggleButton() {
                    if (_liveToggleButton == null) {
                        _liveToggleButton = _getMenuToggleButton("btnMenuLive");
                    }
                    return _liveToggleButton;
                }

                public ToggleButton GetDetailSettingToggleButton() {
                    if (_detailSettingToggleButton == null) {
                        _detailSettingToggleButton = _getMenuToggleButton("btnMenuDetail");
                    }
                    return _detailSettingToggleButton;
                }
            }
        }
    }
}
