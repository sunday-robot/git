using System;
using System.Threading;
using System.Windows.Automation;

namespace TargetApplication {
    // AutomationElementを取得するためのユーティリティ関数群
    public static class FindUtil {
        private static int _defaultMaxRetryCount = 10;
        private static int _defaultRetryInterval = 100;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="treeScope"></param>
        /// <param name="condition"></param>
        /// <param name="maxRetryCount">見つからない場合の最大リトライ回数</param>
        /// <returns></returns>
        public static AutomationElement Find(AutomationElement parent, TreeScope treeScope, Condition condition,
            int maxRetryCount, int sleepTime) {
            for (int i = 0; i <= maxRetryCount; i++) {
                var ae = parent.FindFirst(treeScope, condition);
                if (ae != null) {
                    return ae;
                }
                Thread.Sleep(sleepTime);
            }
            throw new Exception(String.Format("Cannot find [{0}]", condition.ToString()));
        }

        #region FindDescendant
        /// <summary>
        /// 
        /// </summary>
        /// <param name="window"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AutomationElement FindDescendantByAutomationId(AutomationElement parent, string automationId) {
            return FindDescendantByAutomationId(parent, automationId, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindDescendantByAutomationId(AutomationElement parent, string automationId, int maxRetryCount, int sleepTime) {
            var pc = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            return FindDescendant(parent, pc, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindDescendantByClassName(AutomationElement parent, string className) {
            return FindDescendantByClassName(parent, className, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindDescendantByClassName(AutomationElement parent, string className, int maxRetryCount, int sleepTime) {
            var pc = new PropertyCondition(AutomationElement.ClassNameProperty, className);
            return FindDescendant(parent, pc, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindDescendant(AutomationElement parent, Condition condition, int maxRetryCount, int sleepTime) {
            return Find(parent, TreeScope.Descendants, condition, maxRetryCount, sleepTime);
        }

        #endregion FindDescendant

        #region FindWindow
        public static AutomationElement FindWindowByName(string name) {
            return FindWindowByName(name, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindWindowByName(string name, int maxRetryCount, int sleepTime) {
            var re = AutomationElement.RootElement;
            return FindChildByName(re, name, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindWindowByClassName(string className) {
            return FindWindowByClassName(className, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindWindowByClassName(string className, int maxRetryCount, int sleepTime) {
            var re = AutomationElement.RootElement;
            return FindChildByClassName(re, className, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindWindowByAutomationId(string automationId) {
            return FindWindowByAutomationId(automationId, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindWindowByAutomationId(string automationId, int maxRetryCount, int sleepTime) {
            var re = AutomationElement.RootElement;
            return FindChildByAutomationId(re, automationId, maxRetryCount, sleepTime);
        }

        #endregion FindWindow

        #region FindChild

        public static AutomationElement FindChildByName(AutomationElement parent, string name) {
            return FindChildByName(parent, name, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindChildByName(AutomationElement parent, string name, int maxRetryCount, int sleepTime) {
            Console.WriteLine("Finding by name [{0}]", name);
            var pc = new PropertyCondition(AutomationElement.NameProperty, name);
            return FindChild(parent, pc, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindChildByClassName(AutomationElement parent, string className) {
            return FindChildByClassName(parent, className, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindChildByClassName(AutomationElement parent, string className, int maxRetryCount, int sleepTime) {
            Console.WriteLine("Finding by class name [{0}]", className);
            var pc = new PropertyCondition(AutomationElement.ClassNameProperty, className);
            return FindChild(parent, pc, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindChildByAutomationId(AutomationElement parent, string automationId) {
            return FindChildByAutomationId(parent, automationId, _defaultMaxRetryCount, _defaultRetryInterval);
        }

        public static AutomationElement FindChildByAutomationId(AutomationElement parent, string automationId, int maxRetryCount, int sleepTime) {
            Console.WriteLine("Finding by Automation ID [{0}]", automationId);
            var pc = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            return FindChild(parent, pc, maxRetryCount, sleepTime);
        }

        public static AutomationElement FindChild(AutomationElement parent, Condition condition, int maxRetryCount, int sleepTime) {
            return Find(parent, TreeScope.Children, condition, maxRetryCount, sleepTime);
        }

        #endregion FindChild

        #region FindChildren

        public static AutomationElementCollection FindChildrenByClassName(AutomationElement parent, string className) {
            var pc = new PropertyCondition(AutomationElement.ClassNameProperty, className);
            return parent.FindAll(TreeScope.Children, pc);
        }

        #endregion FindChildren

        /// <summary>
        /// (デバッグ用)
        /// 子要素をコンソールに出力する。
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="indent"></param>
        public static void ListChildren(AutomationElement parent, string indent) {
            Condition condition = Condition.TrueCondition;
            var aes = parent.FindAll(TreeScope.Children, condition);
            foreach (var e in aes) {
                AutomationElement ae = (AutomationElement)e;
                Console.WriteLine("{0}className = [{1}], Automation ID = [{2}]",
                    indent, ae.Current.ClassName, ae.Current.AutomationId);
                ListChildren(ae, indent + "  ");
            }
        }

    }
}
