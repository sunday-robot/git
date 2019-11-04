using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;

namespace TargetApplication
{
    public abstract class Control
    {
        private AutomationElement _automationElement;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="automationElement">AutomationElement</param>
        protected Control(AutomationElement automationElement)
        {
            if (automationElement == null)
                throw new Exception("AutomationElementがnullです。");
            _automationElement = automationElement;
        }

        public AutomationElement GetAutomationElement()
        {
            return _automationElement;
        }

        /// <summary>
        /// コントロールの状態がEnabledかどうかを返す。
        /// </summary>
        /// <returns>コントロールの状態がEnabledかどうか</returns>
        public bool IsEnabled()
        {
            return _automationElement.Current.IsEnabled;
        }

        /// <summary>
        /// コントロールの状態がEnabledになるまで待つ。
        /// </summary>
        /// <param name="timeOut">タイムアウト値(単位はms)</param>
        public void WaitUntilEnabled(int timeOut)
        {
            var endTime = DateTime.Now.AddMilliseconds(timeOut);
            for (; ; )
            {
                if (IsEnabled())
                {
                    return;
                }
                if (DateTime.Now > endTime)
                    throw new Exception("time out.");
                Console.WriteLine("Waiting control enabled... : " + _automationElement.Current.Name);
                Thread.Sleep(100);  // 0.1秒待つ
            }
        }

        public void WaitUntilEnabled()
        {
            WaitUntilEnabled(10000);
        }

        /// <summary>
        /// 指定されたマウスイベントを発生させる。
        /// </summary>
        /// <param name="mouseEventType"></param>
        private void _RaiseMouseEvent(MouseEventType mouseEventType)
        {
            System.Windows.Point pos;
            _automationElement.TryGetClickablePoint(out pos);
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)pos.X, (int)pos.Y);
            mouse_event((int)mouseEventType, 0, 0, 0, 0);
        }

        /// <summary>
        /// マウスの左ボタンを押す
        /// </summary>
        /// <param name="element"></param>
        public void LeftDown()
        {
            _RaiseMouseEvent(MouseEventType.LeftDown);
        }

        /// <summary>
        /// マウスの左ボタンを離す
        /// </summary>
        /// <param name="element"></param>
        public void LeftUp()
        {
            _RaiseMouseEvent(MouseEventType.LeftUp);
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private enum MouseEventType : int
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10
        }

    }
}
