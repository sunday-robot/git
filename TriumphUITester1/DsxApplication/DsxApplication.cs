using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx {
    public partial class DsxApplication : Control {
        private MicroscopeWindow _microscopeWindow = null;      // 顕微鏡アプリケーションウィンドウ
        private ApplicationWindow _applicationWindow = null;    // 後処理アプリケーションウィンドウ???

        public DsxApplication(AutomationElement automationElement)
            : base(automationElement) {
        }

        /// <summary>
        /// 後処理アプリケーションのウィンドウを見つける。
        /// </summary>
        /// <returns>DsxApplicationのインスタンス</returns>
        /// TODO:名前は考え直したほうが良い。Find()あたりが良いのか?GetWindow()あたりが良い?
        public static DsxApplication CreateInstance() {
            var ae = FU.FindWindowByName("DSX-BSW");
            return new DsxApplication(ae);
        }

        /// <summary>
        /// 顕微鏡アプリケーションのウィンドウを見つける。
        /// </summary>
        /// <returns></returns>
        public MicroscopeWindow GetMicroscopeMainWindow() {
            if (_microscopeWindow == null) {
                _microscopeWindow = MicroscopeWindow.CreateInstance(GetAutomationElement());
            }
            return _microscopeWindow;
        }

        public ApplicationWindow GetApplicationMainWindow() {
            if (_applicationWindow == null) {
                _applicationWindow = new ApplicationWindow();
            }
            return _applicationWindow;
        }

        /// <summary>
        /// ログインダイアログを取得する。
        /// !!!現状ログインダイアログにはAutomationIDが設定されていないので、
        /// 別なものが取得されてしまうことが考えられます。
        /// </summary>
        /// <returns></returns>
        public LoginDialog GetLoginDialog() {
            var loginDialog = new LoginDialog();
            loginDialog.Find();
            return loginDialog;
        }

        /// <summary>
        /// 「電動ステージが動きます…」のメッセージボックスを取得する。
        /// </summary>
        /// <returns></returns>
        public AutomationElement GetDendoStageDialog() {
            return FU.FindChildByName(GetAutomationElement(), "UiMessageDialog", 120, 1000); // タイムアウトは2分程度で十分か?
        }

        /// <summary>
        /// 「電動ステージが動きます…」のメッセージボックスのOKボタン取得する。
        /// </summary>
        /// <returns></returns>
        public Button GetDendoStageDialogOkButton() {
            return new Button(FU.FindDescendantByAutomationId(GetDendoStageDialog(), "cmdFirst"));
        }

        public Button GetExitConfirmationYesButton() {
            var dialog2 = GetExitConfirmationDialog();
            return new Button(FU.FindChildByAutomationId(dialog2, "cmdYesOk"));
        }

        public AutomationElement GetExitConfirmationDialog() {
            return FU.FindChildByName(GetAutomationElement(), "DSX-BSW");
        }

        public Button GetSaveComfirmationNoToAllButton() {
            return new Button(FU.FindChildByAutomationId(GetSaveComfirmationDialog(), "cmdNoToAll"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AutomationElement GetSaveComfirmationDialog() {
            return FU.FindChildByName(GetAutomationElement(), "DSX-BSW");
        }
    }
}
