using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using FU = TargetApplication.FindUtil;
using TargetApplication;

namespace IE {
    public class IEController {
        private AutomationElement _Window;
        private AutomationElement _NavigationBarChild;  // よくわからないが、ナビゲーションツールバーの直接の子
        private AutomationElement _AddressBandRoot; // アドレスバーのコンテナ？？？
        private TextBox _AddressBarTextBox;

        public AutomationElement GetWindow() {
            if (_Window == null) {
                _Window = FU.FindWindowByClassName("IEFrame");
            }
            return _Window;
        }

        public AutomationElement GetNavigationBar() {
            if (_NavigationBarChild == null)
            {
                var w = GetWindow();
//                ListChildren(w, "");
                _NavigationBarChild = FU.FindChildByClassName(w, "ReBarWindow32");
            }
            return _NavigationBarChild;
        }

        public AutomationElement GetAddressBandRoot() {
            if (_AddressBandRoot == null) {
                var nb = GetNavigationBar();
                _AddressBandRoot = FU.FindChildByClassName(nb, "Address Band Root");
            }
            return _AddressBandRoot;
        }

        public TextBox GetAddressTextBox() {
            if (_AddressBarTextBox == null) {
                var abr = GetAddressBandRoot();
                var ae = FU.FindChildByClassName(abr, "Edit");
                _AddressBarTextBox = new TextBox(ae);
            }
            return _AddressBarTextBox;
        }
    }
}
