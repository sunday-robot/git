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
    public partial class UiMicroscopeFrameWindow
	{
        //2011.05.14Tanuma↓削除予定
        ///// <summary>
        ///// 実GUI用Window
        ///// </summary>
        //private UiRealScreenWindow _uiRealScreenWindow = new UiRealScreenWindow();
        //2011.05.14Tanuma↑削除予定

		public UiMicroscopeFrameWindow()
		{
			this.InitializeComponent();
			
			// ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            //// Read the resource, and Setup it on Content.
            //this._GetContentResourceInWindow();
        }

        //2011.05.14Tanuma↓削除予定
        //private void toggleButton1_Checked(object sender, RoutedEventArgs e)
        //{
        //    this._uiRealScreenWindow.Show();
        //}

        //private void toggleButton1_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    this._uiRealScreenWindow.Hide();
        //}
        //2011.05.14Tanuma↑削除予定

        ///// <summary>
        ///// Contentの設定
        ///// </summary>
        //private void _GetContentResourceInWindow()
        //{
        //    this.tbiMainPanelEasy.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MICROSCOPE_FRAME_WINDOW_GROUP_EASY_MODE_TITLE_NAME);
        //    this.lblMainPanelEasy.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MICROSCOPE_FRAME_WINDOW_GROUP_EASY_MODE_TITLE_NAME);
        //}

        /// <summary>
        /// ウィンドウクロージング処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ViewModel.UiController.sUiController.Layout.IsExecWindowClosing())
            {
                e.Cancel = true;
            }
        }

        ///// <summary>
        ///// ウィンドウアクティブ処理
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ///// <remarks>多言語表示の暫定対応で、アクティブ時に毎回行う。正式には起動時の適切なタイミングで1回だけ行う方がよい。</remarks>
        //private void Window_Activated(object sender, System.EventArgs e)
        //{
        //    // Read the resource, and Setup it on Content.
        //    this._GetContentResourceInWindow();
        //}
        
        // TODO:暫定対応<START>
        // 後処理のファイルエクスプローラ画面を表示した後に、コンテキストメニュー・コンボボックス・ツールチップを
        // 表示しようとすると後処理画面が表示されてしまう問題への対応。
        // 後処理から顕微鏡への切り替えなど、Showの度に対応が必要なのでMainWindowに対して処理を記述。
        // パフォーマンスへの影響が懸念事項。
        // パフォーマンスへの影響が少ない場合は、本対応を正式対応とする。
        /// <summary>
        /// マウスダウン対応
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayoutRoot_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.ForExplorerBrowserProblem();
        }

        /// <summary>
        /// タッチパネル対応
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayoutRoot_PreviewTouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            this.ForExplorerBrowserProblem();
        }

        /// <summary>
        /// 後処理のファイルエクスプローラ画面を表示した後に、コンテキストメニュー・コンボボックス・ツールチップを
        /// 表示しようとすると後処理画面が表示されてしまう問題への対応。
        /// </summary>
        private void ForExplorerBrowserProblem()
        {
            // ExplorerBrowser表示後に下記を行うと現象が発生しなくなる。理由は不明。
            System.Windows.Application.Current.MainWindow.Topmost = true;
            System.Windows.Application.Current.MainWindow.Topmost = false;
        }
        // TODO:暫定対応<END>

    }
}