using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;
using System;
using System.Threading;

namespace Dsx {
    /// <summary>
    /// ログインダイアログ
    /// デスクトップの直下のウィンドウ。
    /// </summary>
    public class LoginDialog {
        private AutomationElement _automationElement;

        public void Find() {
            // 現状オートメーションIDが設定されていないので、以下の条件で探している。
            // (後処理アプリのウィンドウなので、オートメーションIDを設定できない。)
            // (1) デスクトップ直下である
            // (2) Name="DSX-BSW"である
            // (3) ClassName="Window"である
            var re = AutomationElement.RootElement;
            for (int numWait = 0; numWait < 50; numWait++)
            {
                Console.WriteLine("Finding windows....." + numWait);

                var items = re.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "DSX-BSW"));
                if (items != null)
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        var candinate = items[i].FindFirst(TreeScope.Element, new PropertyCondition(AutomationElement.ClassNameProperty, "Window"));
                        if (candinate != null)
                        {
                            Console.WriteLine("Found.");
                            _automationElement = candinate;
                            return;
                        }
                    }
                }

                Thread.Sleep(1000);
            }
            throw new Exception("Failed to find windows.");
        }

        public ComboBox GetUserNameComboBox() {
            return new ComboBox(FU.FindDescendantByAutomationId(_automationElement, "cmbUsername"));
        }

        public TextBox GetPasswordTextBox() {
            return new TextBox(FU.FindDescendantByAutomationId(_automationElement, "txtPassword"));
        }

        public Button GetOkButton() {
            return new Button(FU.FindDescendantByAutomationId(_automationElement, "cmdOk"));
        }

    }
}
