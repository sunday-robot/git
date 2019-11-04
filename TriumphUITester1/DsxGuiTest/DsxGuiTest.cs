using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dsx;
using System.Windows.Automation;

namespace DsxGuiTest {
    [TestFixture]
    public class DsxGuiTest {
        [Test]
        /// <summary>
        /// WiDERボタンをON状態にし、AEなどの機能に関するコントロールがDisableになることを確認する。
        /// </summary>
        public void test40_30_400_UC_01_2() {
            var target = DsxApplication .CreateInstance();
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

            Assert.IsFalse(detailSettingPane.GetIlluminationSettingAeSlider().IsEnabled(), "詳細設定-観察-AE AEスライダー状態");
            Assert.IsFalse(mw.GetCameraAeOnOffButton().IsEnabled(), "カメラ設定 AE ON/OFFボタン状態");
            Assert.IsFalse(mw.GetCameraExposureTimeSlider().IsEnabled(), "カメラ設定 露出時間設定スライダー状態");
            Assert.IsFalse(mw.GetImageRevisionContrastOnOffButton().IsEnabled(), "画像補正 コントラストON/OFFボタン状態");

            // 画像補正-詳細設計を表示させる。
            var imageRevisionPane = mw.GetUiImageRevisionPage();
            imageRevisionPane.GetDetailSettingButton().Toggle();

            // 画像補正-詳細設計-HDR(テクスチャ強調)を表示させる。
            var imageRevisionDetailSettingPane = imageRevisionPane.GetDetailSettingPage();
            imageRevisionDetailSettingPane.GetHdrTeToggleButton().Toggle();

            Assert.IsFalse(imageRevisionPane.GetHdrTeBrightnessSlider().IsEnabled(), "画像補正-詳細設定-HDR(テクスチャ強調) 明るさスライダー状態");
            Assert.IsFalse(imageRevisionPane.GetHdrTeTextureSlider().IsEnabled(), "画像補正-詳細設定-HDR(テクスチャ強調) テクスチャスライダー状態");
            Assert.IsFalse(imageRevisionPane.GetHdrTeContrastSlider().IsEnabled(), "画像補正-詳細設定-HDR(テクスチャ強調) コントラストスライダー状態");
            Assert.IsFalse(imageRevisionPane.GetHdrTeChromeSlider().IsEnabled(), "画像補正-詳細設定-HDR(テクスチャ強調) 鮮やかさスライダー状態");

            // 画像補正-詳細設計-コントラスト強調を表示させる。
            imageRevisionDetailSettingPane.GetContrastToggleButton().Toggle();
            Assert.IsFalse(imageRevisionPane.GetContrastLowRadioButton().IsEnabled(), "画像補正-詳細設定-コントラスト強調 弱ラジオボタン状態");
            Assert.IsFalse(imageRevisionPane.GetContrastMiddleRadioButton().IsEnabled(), "画像補正-詳細設定-コントラスト強調 中ラジオボタン状態");
            Assert.IsFalse(imageRevisionPane.GetContrastHighRadioButton().IsEnabled(), "画像補正-詳細設定-コントラスト強調 強ラジオボタン状態");

            // 画像補正-詳細設計-HDR(ハレーション除去)を表示させる。
            imageRevisionDetailSettingPane.GetHdrAhToggleButton().Toggle();
            Assert.IsFalse(imageRevisionPane.GetHdrAhBrightnessSlider().IsEnabled(), "画像補正-詳細設定-HDR(ハレーション除去) 明るさスライダー状態");
            Assert.IsFalse(imageRevisionPane.GetHdrAhTextureSlider().IsEnabled(), "画像補正-詳細設定-HDR(ハレーション除去) テクスチャスライダー状態");
            Assert.IsFalse(imageRevisionPane.GetHdrAhContrastSlider().IsEnabled(), "画像補正-詳細設定-HDR(ハレーション除去) コントラストスライダー状態");
            Assert.IsFalse(imageRevisionPane.GetHdrAhChromeSlider().IsEnabled(), "画像補正-詳細設定-HDR(ハレーション除去) 鮮やかさスライダー状態");

            // 観察設定-詳細設定を表示させる。
            var illuminationSettingForm = mw.GetIlluminationSettingPage();
            illuminationSettingForm.GetDetailSettingButton().Toggle();

            // 観察設定-詳細設定-AE(自動露出)を表示させる。
            var illuminationDetailSettingPage = illuminationSettingForm.GetDetailSettingPage();
            illuminationDetailSettingPage.GetAeToggleButton().Toggle();
            Assert.IsFalse(illuminationDetailSettingPage.GetAeSlider().IsEnabled(), "観察設定-詳細設定-AE(自動露出) 目標値スライダー状態");

            // 詳細設定-画像補正を表示させる。
            detailSettingPane.GetImageRevisionTreeItem().Expand();

            // 詳細設定-画像補正-HDR(テクスチャ強調)を表示させる。
            detailSettingPane.GetImageRevisionHdrTeTreeItem().Select();
            Assert.IsFalse(detailSettingPane.GetImageRevisionTextureBrightnessSlider().IsEnabled(), "詳細設定-画像補正-HDR(テクスチャ強調) 明るさスライダー状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrTeTextureSlider().IsEnabled(), "詳細設定-画像補正-HDR(テクスチャ強調) テクスチャスライダー状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrTeContrastSlider().IsEnabled(), "詳細設定-画像補正-HDR(テクスチャ強調) コントラストスライダー状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrTeChromeSlider().IsEnabled(), "詳細設定-画像補正-HDR(テクスチャ強調) 鮮やかさスライダー状態");

            // 詳細設定-画像補正-コントラスト強調を表示させる。
            detailSettingPane.GetImageRevisionContrastTreeItem().Select();
            Assert.IsFalse(detailSettingPane.GetImageRevisionContrastLowRadioButton().IsEnabled(), "詳細設定-画像補正-コントラスト強調 コントラスト強調 弱ラジオボタン状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionContrastMiddleRadioButton().IsEnabled(), "詳細設定-画像補正-コントラスト強調 コントラスト強調 中ラジオボタン状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionContrastHighRadioButton().IsEnabled(), "詳細設定-画像補正-コントラスト強調 コントラスト強調 強ラジオボタン状態");

            // 詳細設定-画像補正-HDR(ハレーション除去)を表示させる。
            detailSettingPane.GetImageRevisionHdrAhTreeItem().Select();
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrAhBrightnessSlider().IsEnabled(), "詳細設定-HDR(ハレーション除去) 明るさスライダー状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrAhTextureSlider().IsEnabled(), "詳細設定-HDR(ハレーション除去) テクスチャスライダー状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrAhContrastSlider().IsEnabled(), "詳細設定-HDR(ハレーション除去) コントラストスライダー状態");
            Assert.IsFalse(detailSettingPane.GetImageRevisionHdrAhChromeSlider().IsEnabled(), "詳細設定-HDR(ハレーション除去) 鮮やかさスライダー状態" );

            Assert.AreEqual(mw.GetWiderButton().GetToggleState(), ToggleState.On, "WiDERボタン状態");
        }
    }
}
