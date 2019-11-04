using System;
using System.Threading;

namespace Dsx
{
    public class DsxTestUtility
    {
        private DsxApplication _application;
        private bool _alreadySnapped = false;

        public DsxTestUtility(DsxApplication application)
        {
            _application = application;
        }

        /// <summary>
        /// (2) ログインする<br/>
        /// 
        /// 具体的には以下の処理を行う。<br/>
        /// (1) ログインウィンドウを探す。
        /// (2) ユーザーID、パスワードを入力する。
        /// (3) OKボタンを押す。
        /// </summary>
        public void Login(string userId, string password)
        {
            var loginDialog = _application.GetLoginDialog();
            loginDialog.GetUserNameComboBox().SetText(userId);
            loginDialog.GetPasswordTextBox().SetText(password);

            ////AutomationElement cmbLanguageSelector = loginDialog.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "cmbLanguageSelector"));
            ////SelectionPattern sipCmbLanguageSelector = (SelectionPattern)cmbLanguageSelector.GetCurrentPattern(SelectionPattern.Pattern);
            ////AutomationElement[] itemLangs = sipCmbLanguageSelector.Current.GetSelection();
            ////Console.WriteLine("Selection Language = " + itemLangs[0].Current.Name);
            loginDialog.GetOkButton().Press();
        }

        /// <summary>
        /// (3) ハードウェアを初期化する??<br/>
        /// 
        /// 具体的には以下の処理を行う。<br/>
        /// (1) 「電動ステージが動きます…」のメッセージボックスを探す。<br/>
        /// (2) OKボタンを押す。
        /// </summary>
        public void InitializeHardware() {
            _application.GetDendoStageDialogOkButton().Press();
        }

        /// <summary>
        /// (4) XYステージを動かす???<br/>
        /// </summary>
        public void MoveStage() {
            var mw = _application.GetMicroscopeMainWindow();
            Console.WriteLine("Start Moving...");
            Thread.Sleep(3000);

            var imageDisplayArea = mw.GetImageDisplayPage();

            for (int i = 0; i < 5; i++) {
                Console.WriteLine("Change speed [" + i + "]...");
                var cmdSpeed = imageDisplayArea.GetSpeedButton();
                cmdSpeed.WaitUntilEnabled();
                cmdSpeed.Press();
            }

            imageDisplayArea.GetSpecificationDistanceTextBox().SetText("1000");

            Thread.Sleep(1000);

            var statusBar = mw.GetStatusBar();

            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Move right [" + i + "]...");
                var cmdRight = imageDisplayArea.GetRightButton();
                cmdRight.WaitUntilEnabled();
                cmdRight.LeftDown();
                Thread.Sleep(500);
                cmdRight.LeftUp();
                var ae = statusBar.GetXYPosition();
                Console.WriteLine("XY Position = " + ae.Current.Name);
            }

            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Move left [" + i + "]...");
                var cmdLeft = imageDisplayArea.GetLeftButton();
                cmdLeft.WaitUntilEnabled();
                cmdLeft.LeftDown();
                Thread.Sleep(500);
                cmdLeft.LeftUp();
                var ae = statusBar.GetXYPosition();
                Console.WriteLine("XY Position = " + ae.Current.Name);
            }

        }

        /// <summary>
        /// (5) Z ステージを動かす。
        /// </summary>
        public void MoveZ() {
            var mw = _application.GetMicroscopeMainWindow();
            var frmSettingTool = mw.GetSettingTool();
            var btnNearSampleRoughMove = mw.GetSettingToolNearSampleRoughMoveButton();
            var statusBar = mw.GetStatusBar();
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Move near [" + i + "]...");
                btnNearSampleRoughMove.WaitUntilEnabled();
                btnNearSampleRoughMove.Press();
                var ae = statusBar.GetZPosition();
                Console.WriteLine("Z Position = " + ae.Current.Name);
            }
        }

        private object GetSettingTool() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// (6) ???
        /// </summary>
        public void ChangeLightValueOnBf() {
            var mw = _application.GetMicroscopeMainWindow();
            var rbtnMicroscopyBf = mw.GetSpeculumMicrosopyRadioButton();
            rbtnMicroscopyBf.WaitUntilEnabled();
            rbtnMicroscopyBf.Select();

            // 検鏡法が切り替わるまで待つ
            Thread.Sleep(5000);

            var illuminationSettingForm = mw.GetIlluminationSettingPage();
            var lblBrightnessValueUprightHighMagBFFiber = illuminationSettingForm.GetBrightnessValueUprightHighMagBFFiberXX();

            Console.WriteLine("BrightnessValue (BF) = " + lblBrightnessValueUprightHighMagBFFiber.Current.Name);
        }

        /// <summary>
        /// (7) ???
        /// </summary>
        public void ChangeLightValueOnPo() {
            var mw = _application.GetMicroscopeMainWindow();
            var frmSpeculum = mw.GetSpeculumForm();
            var rbtnMicroscopyPo = mw.GetSpeculumMicroscopyPoRadioButton();
            rbtnMicroscopyPo.WaitUntilEnabled();
            rbtnMicroscopyPo.Select();

            // 検鏡法が切り替わるまで待つ
            Thread.Sleep(5000);
            var illuminationSettingForm = mw.GetIlluminationSettingPage();

            var frmIlluminationSetting = mw.GetIlluminationSettingPage();
            var sldBrightnessUprightHighMagBFFiber = illuminationSettingForm.GetBrightnessUprightHighMagBFFiberSlider();
            for (int i = 0; i < 10; i++) {
                var decreaseSmall = illuminationSettingForm.GetBrightnessUprightHighMagBFFiberSliderDecreaseSmallButton();
                decreaseSmall.WaitUntilEnabled();
                decreaseSmall.Press();
                var lblBrightnessValueUprightHighMagBFFiber = illuminationSettingForm.GetBrightnessValueUprightHighMagBFFiberLabel();
                Console.WriteLine("BrightnessValue (PO)= " + lblBrightnessValueUprightHighMagBFFiber.Current.Name);
            }
        }

        /// <summary>
        /// (8) ???
        /// </summary>
        public void ChangeHdrMode() {
            var mw = _application.GetMicroscopeMainWindow();
            var imageRevisionPane = mw.GetUiImageRevisionPage();
            var tglbHDRWIDER = imageRevisionPane.GetHdrWiderToggleButton();
            var tglbContrast = mw.GetImageRevisionContrastOnOffButton();
            var tglbLiveColor = imageRevisionPane.GetLiveColorToggleButton();

            Console.WriteLine("(PREV) HDR button : status = " + tglbHDRWIDER.GetToggleState());
            Console.WriteLine("(PREV) Contrast button : enable/disable = " + tglbContrast.IsEnabled());
            Console.WriteLine("(PREV) LiveColor button : enable/disable = " + tglbLiveColor.Current.IsEnabled);
            tglbHDRWIDER.WaitUntilEnabled();
            tglbHDRWIDER.Toggle();
            Thread.Sleep(3000);
            Console.WriteLine("(AFTER) HDR button : status = " + tglbHDRWIDER.GetToggleState());
            Console.WriteLine("(AFTER) Contrast button : enable/disable = " + tglbContrast.IsEnabled());
            Console.WriteLine("(AFTER) LiveColor button : enable/disable = " + tglbLiveColor.Current.IsEnabled);
        }

        /// <summary>
        /// (9) スナップショットを撮る?
        /// </summary>
        public void Snapshot() {
            var mw = _application.GetMicroscopeMainWindow();
            var psf = mw.GetPhotographySettingPage();
            var button = psf.GetAcquisitionSnapStartButton();
            button.Press();
            _alreadySnapped = true;
            Console.WriteLine("Done snapshot.");
        }

        /// <summary>
        /// (10) ライブを開始する?
        /// </summary>
        public void StartLive() {
            var mw = _application.GetMicroscopeMainWindow();
            var mbs = mw.GetMenuButtons();
            var toggleLive = mbs.GetLiveToggleButton();

            Console.WriteLine("(PREV) Push Live button : status = " + toggleLive.GetToggleState());
            toggleLive.WaitUntilEnabled();
            toggleLive.Toggle();
            Thread.Sleep(2000);
            Console.WriteLine("(AFTER) Push Live button : status = " + toggleLive.GetToggleState());
            Console.WriteLine("Started live.");
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExitAppication() {
            // 起動直後にExitしてしまうとよくなさそうなので、何秒か秒待つ
            Thread.Sleep(2000);

            // 画面上部の"測定"ラジオボタンを押し、後処理アプリに切り替える
            var rdbMeasurement = _application.GetApplicationMainWindow().GetMeasurementRadioButton();
            rdbMeasurement.WaitUntilEnabled();
            rdbMeasurement.Select();

            Thread.Sleep(2000);

            // 顕微鏡アプリの[X]を押してしまうとうまく終了できないので、後処理アプリの
            // [X]ボタンを押す
            var cmdExitApplication = _application.GetApplicationMainWindow().GetExitApplicationButton();
            cmdExitApplication.WaitUntilEnabled();
            cmdExitApplication.Press();
            Console.WriteLine("Exit Appication.");

            // 保存確認ダイアログ
            if (this._alreadySnapped) {
                Thread.Sleep(3000);
                var cmdNoToAll = _application.GetSaveComfirmationNoToAllButton();
                cmdNoToAll.Press();
            }

            // 終了確認ダイアログ
            Thread.Sleep(3000);

            var cmdYesOk = _application.GetExitConfirmationYesButton();
            cmdYesOk.Press();
        }


    }
}
