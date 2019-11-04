using System.Windows.Automation;
using TargetApplication;
using FU = TargetApplication.FindUtil;

namespace Dsx {
    public partial class DsxApplication : Control {
        public partial class MicroscopeWindow : Control {
            public class UiDetailSettingMainPage : Control {
                public UiDetailSettingMainPage(AutomationElement parent)
                    : base(FU.FindDescendantByAutomationId(parent, "frmDetailSetting")) {
                }

                public Slider GetImageRevisionTextureBrightnessSlider2() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public Slider GetImageRevisionHdrTeTextureSlider2() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public Slider GetImageRevisionHdrTeContrastSlider2() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public Slider GetImageRevisionHdrTeChromeSlider2() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public RadioButton GetContrastLowRadioButton() {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnL"));
                }

                public RadioButton GetContrastMiddleRadioButton() {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnM"));
                }

                public RadioButton GetContrastHighRadioButton() {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnH"));
                }

                public Slider GetHdrAhBrightnessSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationBrightness"));
                }

                public Slider GetHdrAhTextureSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationTexture"));
                }

                public Slider GetHdrAhContrastSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationContrast"));
                }

                public Slider GetHdrAhChromeSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public AutomationElement GetTreeView() {
                    return FU.FindDescendantByAutomationId(GetAutomationElement(), "tviwDetailSetting");
                }

                public AutomationElementCollection GetTreeItems() {
                    return GetTreeItems(GetTreeView());
                }

                public TreeItem GetIlluminationSettingTreeItem() {
                    var aes = GetTreeItems();
                    return new TreeItem(aes[1]);   // 観察は2番目
                }

                public TreeItem GetImageRevisionTreeItem() {
                    var aes = GetTreeItems();
                    return new TreeItem(aes[3]);   // 画像補正は3番目
                }

                public AutomationElementCollection GetHdrTeTreeItems() {
                    var ae = GetImageRevisionTreeItem().GetAutomationElement();
                    return GetTreeItems(ae);
                }

                public TreeItem GetImageRevisionHdrTeTreeItem() {
                    var aes = GetHdrTeTreeItems();
                    return new TreeItem(aes[0]);    // HDR(テクスチャ強調)は1番目
                }

                public Slider GetImageRevisionTextureBrightnessSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRBrightness"));
                }

                public Slider GetImageRevisionHdrTeTextureSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRTexture"));
                }

                public Slider GetImageRevisionHdrTeContrastSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRContrast"));
                }

                public Slider GetImageRevisionHdrTeChromeSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRChrome"));
                }

                public RadioButton GetImageRevisionContrastLowRadioButton() {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnL"));
                }

                public RadioButton GetImageRevisionContrastMiddleRadioButton() {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnM"));
                }

                public RadioButton GetImageRevisionContrastHighRadioButton() {
                    return new RadioButton(FU.FindDescendantByAutomationId(GetAutomationElement(), "lblRadioBtnH"));
                }

                public Slider GetImageRevisionHdrAhBrightnessSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationBrightness"));
                }

                public Slider GetImageRevisionHdrAhTextureSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationTexture"));
                }

                public Slider GetImageRevisionHdrAhContrastSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationContrast"));
                }

                public Slider GetImageRevisionHdrAhChromeSlider() {
                    return new Slider(FU.FindDescendantByAutomationId(GetAutomationElement(), "sldHDRAntiHalationChrome"));
                }

                public TreeItem GetImageRevisionContrastTreeItem() {
                    var aes = GetHdrTeTreeItems();
                    return new TreeItem(aes[1]);    // コントラストは2番目
                }

                public TreeItem GetImageRevisionHdrAhTreeItem() {
                    var aes = GetHdrTeTreeItems();
                    return new TreeItem(aes[2]);    // HDR(ハレーション除去)は3番目
                }

                public AutomationElementCollection GetIlluminationSettingTreeItems() {
                    var ae = GetIlluminationSettingTreeItem().GetAutomationElement();
                    return GetTreeItems(ae);
                }

                /// <summary>
                /// 詳細設定-観察-AE(自動露出)
                /// </summary>
                /// <returns></returns>
                public TreeItem GetIlluminationSettingAeTreeItem() {
                    var aes = GetIlluminationSettingTreeItems();
                    return new TreeItem(aes[2]);    // AE(自動露出)は3番目
                }

                public Slider GetIlluminationSettingAeSlider() {
                    var page = FU.FindDescendantByAutomationId(GetAutomationElement(), "expAEPage");
                    var ae = FU.FindDescendantByClassName(page, "Slider");
                    return new Slider(ae);
                }

                public static AutomationElementCollection GetTreeItems(AutomationElement ae) {
                    return ae.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "TreeViewItem"));
                }
            }
        }
    }
}
