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
	public partial class UiFullScreenMenuPage
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
		public UiFullScreenMenuPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();

            // ズーム倍率用スライドバーに、"-"ボタン押下時、カーソルキーによるスライダー移動時のイベントハンドラーを登録する。
            sldFullScreenZoom.AddHandler(System.Windows.Controls.Primitives.RepeatButton.ClickEvent, new RoutedEventHandler(_sldFullScreenZoomClickEventHandler), true);
            sldFullScreenZoom.AddHandler(System.Windows.Controls.Primitives.RepeatButton.KeyDownEvent, new RoutedEventHandler(_sldFullScreenZoomKeyDownEventHandler), true);
        }

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblBtnBack.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FULL_SCREEN_PAGE_BACK_BUTTON_LABEL);
            this.lblAcquisitionCancel.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FULL_SCREEN_PAGE_ACQUISITION_CANCEL_BUTTON_LABEL);
            this.lblAcquisitionStart.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FULL_SCREEN_PAGE_ACQUISITION_START_BUTTON_LABEL);
        }

        /// <summary>
        /// ズーム倍率スライダー用のクリックイベントハンドラー
        /// 
        /// 以下の特殊ケース用のもの。
        /// 倍率の指定方法を総合倍率に設定した状態で、倍率設定を小さいほうから2番目に設定する(x5対物レンズの場合、x75)。
        /// 倍率の指定方法をズーム倍率にする。(x5対物レンズの場合、ズーム倍率は約x1.08なので、スライダー位置は一番下のx1.0の位置になる。(仕様でそのように定められている。))
        /// この状態で、スライダーの"-"ボタンを押す。
        /// 既にスライダーは一番下にあるので、ValueChangedイベントは発生せず、バインディングされているViewModelのプロパティの更新も行われない。
        /// 
        /// スライダーのClickイベントハンドラーとして本メソッドを登録しておくことで、強制的にViewModelの更新が行われる。
        /// </summary>
        /// <param name="sender">ズーム倍率のスライダー</param>
        /// <param name="e">RoutedEventArgs</param>
        private void _sldFullScreenZoomClickEventHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            // イベント発生元が、"-"ボタンかどうかを調べる。
            if (e.OriginalSource.GetType() != typeof(System.Windows.Controls.Primitives.RepeatButton))
                return;
            var repeatButton = (System.Windows.Controls.Primitives.RepeatButton)e.OriginalSource;
            if (repeatButton.Content == null)
                return;
            if (!repeatButton.Content.Equals("－"))
                return;

            // スライダー位置が既に最下部にあっても、Valueプロパティを更新する
            // (こうすることでデータバインドされているViewModelのプロパティのセッターが呼ばれる)
            var slider = (Slider)sender;
            if (slider.Value <= slider.Minimum)
                slider.Value = slider.Minimum;
        }

        /// <summary>
        /// ズーム倍率スライダー用のキーダウンイベントハンドラー
        /// (詳細は上のクリックイベントハンドラーを参照。)
        /// </summary>
        /// <param name="sender">スライダー</param>
        /// <param name="e">RoutedEventArgs</param>
        private void _sldFullScreenZoomKeyDownEventHandler(object sender, System.Windows.RoutedEventArgs e)
        {
            // 押されたキーが、下矢印キーかどうかを調べる。
            var keyEventArgs = (System.Windows.Input.KeyEventArgs)e;
            if (keyEventArgs.Key != System.Windows.Input.Key.Down)
                return;

            // スライダー位置が既に最下部にあっても、Valueプロパティを更新する
            // (こうすることでデータバインドされているViewModelのプロパティのセッターが呼ばれる)
            var slider = (Slider)sender;
            if (slider.Value <= slider.Minimum)
                slider.Value = slider.Minimum;
        }

        #endregion GetContentResource

        #region Page内でのコマンド発行イベント
        /// <summary>
        /// Page内でのコマンド発行イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // 戻るコマンドは無効にする(BackSpaceキーで何も表示されなくなる問題の対応)
            if (e.Command == System.Windows.Input.NavigationCommands.BrowseBack)
            {
                e.Handled = true;
            }
        }
        #endregion Page内でのコマンド発行イベント
    }
}