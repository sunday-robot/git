using System;
using Dsx;
using System.Diagnostics;

namespace TestProgram {
    class TestProgram {
        /// <summary>
        /// WiDERボタンをON状態にし、AEなどの機能に関するコントロールがDisableになることを確認する。
        /// </summary>
        static void test40_30_400_UC_01_2() {
            var target = DsxApplication.CreateInstance();
            var mw = target.GetMicroscopeMainWindow();

            // テスト
            mw.GetWiderButton().Toggle();

            // テスト結果確認

            // 詳細設定を表示させる(画面右上の「詳細設定」トグルボタンを押す)
            mw.GetMenuButtons().GetDetailSettingToggleButton().Toggle();

            var detailSettingPane = mw.GetDetailSettingPage();

            // 詳細設定-観察を表示させる。
            detailSettingPane.GetIlluminationSettingTreeItem().Expand();

            // 詳細設定-観察-AEを表示させる。
            detailSettingPane.GetIlluminationSettingAeTreeItem().Select();
            Console.WriteLine("詳細設定-観察-AE AEスライダー状態 : " + detailSettingPane.GetIlluminationSettingAeSlider().IsEnabled());
            Console.WriteLine("カメラ設定 AE ON/OFFボタン状態 : " + mw.GetCameraAeOnOffButton().IsEnabled());
            Console.WriteLine("カメラ設定 露出時間設定スライダー状態 : " + mw.GetCameraExposureTimeSlider().IsEnabled());
            Console.WriteLine("画像補正 コントラストON/OFFボタン状態 : " + mw.GetImageRevisionContrastOnOffButton().IsEnabled());

            // 画像補正-詳細設計を表示させる。
            var imageRevisionPane = mw.GetUiImageRevisionPage();
            imageRevisionPane.GetDetailSettingButton().Toggle();

            // 画像補正-詳細設計-HDR(テクスチャ強調)を表示させる。
            var imageRevisionDetailSettingPane = imageRevisionPane.GetDetailSettingPage();
            imageRevisionDetailSettingPane.GetHdrTeToggleButton().Toggle();
            Console.WriteLine("画像補正-詳細設定-HDR(テクスチャ強調) 明るさスライダー状態 : " + imageRevisionPane.GetHdrTeBrightnessSlider().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-HDR(テクスチャ強調) テクスチャスライダー状態 : " + imageRevisionPane.GetHdrTeTextureSlider().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-HDR(テクスチャ強調) コントラストスライダー状態 : " + imageRevisionPane.GetHdrTeContrastSlider().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-HDR(テクスチャ強調) 鮮やかさスライダー状態 : " + imageRevisionPane.GetHdrTeChromeSlider().IsEnabled());

            // 画像補正-詳細設計-コントラスト強調を表示させる。
            imageRevisionDetailSettingPane.GetContrastToggleButton().Toggle();
            Console.WriteLine("画像補正-詳細設定-コントラスト強調 弱ラジオボタン状態 : " + imageRevisionPane.GetContrastLowRadioButton().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-コントラスト強調 中ラジオボタン状態 : " + imageRevisionPane.GetContrastMiddleRadioButton().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-コントラスト強調 強ラジオボタン状態 : " + imageRevisionPane.GetContrastHighRadioButton().IsEnabled());

            // 画像補正-詳細設計-HDR(ハレーション除去)を表示させる。
            imageRevisionDetailSettingPane.GetHdrAhToggleButton().Toggle();
            Console.WriteLine("画像補正-詳細設定-HDR(ハレーション除去) 明るさスライダー状態 : " + imageRevisionPane.GetHdrAhBrightnessSlider().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-HDR(ハレーション除去) テクスチャスライダー状態 : " + imageRevisionPane.GetHdrAhTextureSlider().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-HDR(ハレーション除去) コントラストスライダー状態 : " + imageRevisionPane.GetHdrAhContrastSlider().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-HDR(ハレーション除去) 鮮やかさスライダー状態 : " + imageRevisionPane.GetHdrAhChromeSlider().IsEnabled());

            // 観察設定-詳細設定を表示させる。
            var illuminationSettingForm = mw.GetIlluminationSettingPage();
            illuminationSettingForm.GetDetailSettingButton().Toggle();

            // 観察設定-詳細設定-AE(自動露出)を表示させる。
            var illuminationDetailSettingPage = illuminationSettingForm.GetDetailSettingPage();
            illuminationDetailSettingPage.GetAeToggleButton().Toggle();
            Console.WriteLine("観察設定-詳細設定-AE(自動露出) 目標値スライダー状態 : " + illuminationDetailSettingPage.GetAeSlider().IsEnabled());

            // 詳細設定-画像補正を表示させる。
            detailSettingPane.GetImageRevisionTreeItem().Expand();

            // 詳細設定-画像補正-HDR(テクスチャ強調)を表示させる。
            detailSettingPane.GetImageRevisionHdrTeTreeItem().Select();
            Console.WriteLine("詳細設定-画像補正-HDR(テクスチャ強調) 明るさスライダー状態 : " + detailSettingPane.GetImageRevisionTextureBrightnessSlider().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-HDR(テクスチャ強調) テクスチャスライダー状態 : " + detailSettingPane.GetImageRevisionHdrTeTextureSlider().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-HDR(テクスチャ強調) コントラストスライダー状態 : " + detailSettingPane.GetImageRevisionHdrTeContrastSlider().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-HDR(テクスチャ強調) 鮮やかさスライダー状態 : " + detailSettingPane.GetImageRevisionHdrTeChromeSlider().IsEnabled());

            // 詳細設定-画像補正-コントラスト強調を表示させる。
            detailSettingPane.GetImageRevisionContrastTreeItem().Select();
            Console.WriteLine("詳細設定-画像補正-コントラスト強調 コントラスト強調 弱ラジオボタン状態 : " + detailSettingPane.GetImageRevisionContrastLowRadioButton().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-コントラスト強調 コントラスト強調 中ラジオボタン状態 : " + detailSettingPane.GetImageRevisionContrastMiddleRadioButton().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-コントラスト強調 コントラスト強調 強ラジオボタン状態 : " + detailSettingPane.GetImageRevisionContrastHighRadioButton().IsEnabled());

            // 詳細設定-画像補正-HDR(ハレーション除去)を表示させる。
            detailSettingPane.GetImageRevisionHdrAhTreeItem().Select();
            Console.WriteLine("詳細設定-HDR(ハレーション除去) 明るさスライダー状態 : " + detailSettingPane.GetImageRevisionHdrAhBrightnessSlider().IsEnabled());
            Console.WriteLine("詳細設定-HDR(ハレーション除去) テクスチャスライダー状態 : " + detailSettingPane.GetImageRevisionHdrAhTextureSlider().IsEnabled());
            Console.WriteLine("詳細設定-HDR(ハレーション除去) コントラストスライダー状態 : " + detailSettingPane.GetImageRevisionHdrAhContrastSlider().IsEnabled());
            Console.WriteLine("詳細設定-HDR(ハレーション除去) 鮮やかさスライダー状態 : " + detailSettingPane.GetImageRevisionHdrAhChromeSlider().IsEnabled());

            Console.WriteLine("WiDERボタン状態 : " + mw.GetWiderButton().GetToggleState());
        }

        /// <summary>
        /// WiDERボタンをOFF状態にし、AEなどの機能に関するコントロールがEnableになることを確認する。
        /// </summary>
        static void test40_30_400_UC_01_3() {
            var target = DsxApplication.CreateInstance();
            var mw = target.GetMicroscopeMainWindow();

            // テスト
            mw.GetWiderButton().Toggle();

            // テスト結果確認

            // 詳細設定を表示させる(画面右上の「詳細設定」トグルボタンを押す)
            mw.GetMenuButtons().GetDetailSettingToggleButton().Toggle();

            var detailSettingPane = mw.GetDetailSettingPage();

            // 詳細設定-観察を表示させる。
            detailSettingPane.GetIlluminationSettingTreeItem().Expand();

            // 詳細設定-観察-AEを表示させる。
            detailSettingPane.GetIlluminationSettingAeTreeItem().Select();
            Console.WriteLine("詳細設定-観察-AE AEスライダー状態 : " + detailSettingPane.GetIlluminationSettingAeSlider().IsEnabled());
            Console.WriteLine("カメラ設定 AE ON/OFFボタン状態 : " + mw.GetCameraAeOnOffButton().IsEnabled());
            Console.WriteLine("カメラ設定 露出時間設定スライダー状態 : " + mw.GetCameraExposureTimeSlider().IsEnabled());
            Console.WriteLine("画像補正 コントラストON/OFFボタン状態 : " + mw.GetImageRevisionContrastOnOffButton().IsEnabled());

            // 画像補正-詳細設計を表示させる。
            var imageRevisionPane = mw.GetUiImageRevisionPage();
            imageRevisionPane.GetDetailSettingButton().Toggle();

            // 詳細設定-画像補正-コントラスト強調を表示させる。
            var imageRevisionDetailSettingPane = imageRevisionPane.GetDetailSettingPage();
            imageRevisionDetailSettingPane.GetContrastToggleButton().Toggle();
            Console.WriteLine("画像補正-詳細設定-コントラスト強調 弱ラジオボタン状態 : " + imageRevisionPane.GetContrastLowRadioButton().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-コントラスト強調 中ラジオボタン状態 : " + imageRevisionPane.GetContrastMiddleRadioButton().IsEnabled());
            Console.WriteLine("画像補正-詳細設定-コントラスト強調 強ラジオボタン状態 : " + imageRevisionPane.GetContrastHighRadioButton().IsEnabled());

            // 観察設定-詳細設定を表示させる。
            var illuminationSettingForm = mw.GetIlluminationSettingPage();
            illuminationSettingForm.GetDetailSettingButton().Toggle();

            // 観察設定-詳細設定-AE(自動露出)を表示させる。
            var illuminationDetailSettingPage = illuminationSettingForm.GetDetailSettingPage();
            illuminationDetailSettingPage.GetAeToggleButton().Toggle();
            Console.WriteLine("観察設定-詳細設定-AE(自動露出) 目標値スライダー状態 : " + illuminationDetailSettingPage.GetAeSlider().IsEnabled());

            // 詳細設定-画像補正を表示させる。
            detailSettingPane.GetImageRevisionTreeItem().Expand();

            // 詳細設定-画像補正-コントラスト強調を表示させる。
            detailSettingPane.GetImageRevisionContrastTreeItem().Select();
            Console.WriteLine("詳細設定-画像補正-コントラスト強調 コントラスト強調 弱ラジオボタン状態 : " + detailSettingPane.GetImageRevisionContrastLowRadioButton().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-コントラスト強調 コントラスト強調 中ラジオボタン状態 : " + detailSettingPane.GetImageRevisionContrastMiddleRadioButton().IsEnabled());
            Console.WriteLine("詳細設定-画像補正-コントラスト強調 コントラスト強調 強ラジオボタン状態 : " + detailSettingPane.GetImageRevisionContrastHighRadioButton().IsEnabled());

            Console.WriteLine("WiDERボタン状態 : " + mw.GetWiderButton().GetToggleState());
        }

        static void test_sugita() {
            DsxApplication target = DsxApplication.CreateInstance();
            var du = new DsxTestUtility(target);

            Console.WriteLine("*** Start DSX-BSW Application ***");
            var p = Process.Start(@"C:\Program Files\OLYMPUS\DSX-BSW\DSX-BSW-APP\DSX-BSW-APP.exe");
#if false
            Console.WriteLine("*** Login ***");
            du.Login("ADMIN", "olympus");

            Console.WriteLine("*** Confirm hardware initialization ***");
            du.InitializeHardware();
#endif
            //            Console.WriteLine("*** Get microscope/application main window ***");
            //            target.GetMainWindow();

            Console.WriteLine("*** Move XY Stage ***");
            du.MoveStage();

            Console.WriteLine("*** Move Z position ***");
            du.MoveZ();

            Console.WriteLine("*** To Change light value on BF ***");
            du.ChangeLightValueOnBf();

            Console.WriteLine("*** To Change light value on PO ***");
            du.ChangeLightValueOnPo();

            Console.WriteLine("*** To Change backlight value on BF ***");
            du.ChangeLightValueOnBf();

            Console.WriteLine("*** Change HDR Mode ***");
            du.ChangeHdrMode();

            Console.WriteLine("*** Take snapshot ***");
            du.Snapshot();

            Console.WriteLine("*** Start live ***");
            du.StartLive();

            Console.WriteLine("*** Exit DSX-BSW Application ***");
            du.ExitAppication();
        }

        static void Main(string[] args) {
            test40_30_400_UC_01_2();
            test40_30_400_UC_01_3();
            //test_sugita();
            Console.WriteLine("テスト終了。");
            Console.ReadLine();
        }

    }
}
