using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace Olympus.LI.Triumph.Application.View
{
	public partial class UiLensSettingPage
	{
        public UiLensSettingPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
		}

        // TODO:暫定対応<START>
        // 後処理のファイルエクスプローラ画面を表示した後に、コンテキストメニュー・コンボボックス・ツールチップを
        // 表示しようとすると後処理画面が表示されてしまう問題への対応。
        // 後処理から顕微鏡への切り替えなど、Showの度に対応が必要なのでMainWindowに対して処理を記述。
        // パフォーマンスへの影響が懸念事項。
        // パフォーマンスへの影響が少ない場合は、本対応を正式対応とする。
        /// <summary>
        /// 後処理のファイルエクスプローラ画面を表示した後に、コンテキストメニュー・コンボボックス・ツールチップを
        /// 表示しようとすると後処理画面が表示されてしまう問題への対応。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_ToolTipOpening(object sender, System.Windows.Controls.ToolTipEventArgs e)
        {
            // ExplorerBrowser表示後に下記を行うと現象が発生しなくなる。理由は不明。
            System.Windows.Application.Current.MainWindow.Topmost = true;
            System.Windows.Application.Current.MainWindow.Topmost = false;
        }
        // TODO:暫定対応<END>

        #region GetContentResource
        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblCheckBoxAntiRefrectionAdapterEnable.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FOCUS_REFRECTION_GARD_ADAPTER_SWITCH_CONTENT);
        }
        #endregion GetContentResource
    }
}