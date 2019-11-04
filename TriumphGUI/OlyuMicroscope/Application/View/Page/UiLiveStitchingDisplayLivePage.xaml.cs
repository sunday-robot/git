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
    public partial class UiLiveStitchingDisplayLivePage
    {
        #region Constructor
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiLiveStitchingDisplayLivePage()
        {
            this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
        }
        #endregion Constructor

        #region Event
        /// <summary>
        /// Loadedイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 初期表示時に発生する
        /// </remarks>
        public void LoadedHandler(Object sender, System.Windows.RoutedEventArgs e)
        {
            // IsVisibleChangedイベントでは、初期表示時にコントロールの幅と高さがまだ取れないため、初期表示時だけはこのイベントで代用する
            // ScrollViewerの初期スクロール位置を中央にする
            this.SetOffsetCenter();
        }

        /// <summary>
        /// IsVisibleChangedイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// 表示・非表示が切り替わったタイミングで発生する
        /// </remarks>
        public void IsVisibleChangedHandler(Object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            // 表示状態に変わった場合
            //if (e.NewValue.Equals(true))
            //{
            //    // ScrollViewerの初期スクロール位置を中央にする
            //    this.SetOffsetCenter();
            //}
        }

        /// <summary>
        /// ﾏｳｽﾎｲｰﾙﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheelHandler(System.Object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            // マウスホイールでスクロールしないようにハンドルされたことにする
            e.Handled = true;
            ViewModel.UiController.sUiController.Display.LiveStitchingMouseWheelEventHandler(e.Delta);
        }

        #region ScrollViewer内でのコマンド発行イベント
        /// <summary>
        /// ScrollViewer内でのコマンド発行イベント
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
        #endregion ScrollViewer内でのコマンド発行イベント
        #endregion Event

        #region Private Method
        /// <summary>
        /// ScrollViewerの初期スクロール位置を中央にする
        /// </summary>
        private void SetOffsetCenter()
        {
            // TODO: Y.Ito 直接ScrollBarのメソッドをViewModelで呼んでいるため修正する
            ViewModel.UiController.sUiController.Display.SetScrollViewerForGetOffsetForLive(ref this.LayoutRoot);
        }
        #endregion Private Method
    }
}