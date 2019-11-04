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
    /// <summary>
    /// ライブ貼り合わせ画面の貼り合わせ画像領域
    /// </summary>
    public partial class UiLiveStitchingDisplayStitchingPage
    {
        #region Const
        private System.Int32 _DIRECTION_RIGHTDOWN = 1;
        private System.Int32 _DIRECTION_DOWN = 2;
        private System.Int32 _DIRECTION_LEFTDOWN = 3;
        private System.Int32 _DIRECTION_LEFT = 4;
        private System.Int32 _DIRECTION_LEFTUP = 5;
        private System.Int32 _DIRECTION_UP = 6;
        private System.Int32 _DIRECTION_RIGHTUP = 7;
        private System.Int32 _DIRECTION_RIGHT = 8;
        #endregion Const

        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiLiveStitchingDisplayStitchingPage()
        {
            this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();
        }

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            //this.lblSpecificationDistanceUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FULL_SCREEN_PAGE_UNIT_LABEL);
        }

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
        /// ﾏｳｽﾑｰﾌﾞｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMoveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.LiveStitchingMouseMoveEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// ﾏｳｽ左ﾎﾞﾀﾝﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.LiveStitchingMouseDownEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// ﾏｳｽｱｯﾌﾟﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUpHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.LiveStitchingMouseUpEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// マウスリーブハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.LiveStitchingMouseLeaveEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// ｽﾃｰｼﾞ移動速度切替ﾎﾞﾀﾝ ﾏｳｽｸﾘｯｸｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender">ｾﾝﾀﾞｰｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="e">ﾙｰﾃｨﾝｸﾞｲﾍﾞﾝﾄﾊﾟﾗﾒｰﾀ</param>
        private void OnStageCommandSpeedChange(object sender, RoutedEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageCommandSpeedChangeForLiveStitching();
        }

        #region 貼り合せステップ移動上方向ボタン
        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepUpMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageStitchingStepMoveMouseDownEventHandler(_DIRECTION_UP);
        }

        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion

        #region 貼り合せステップ移動下方向ボタン
        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepDownMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageStitchingStepMoveMouseDownEventHandler(_DIRECTION_DOWN);
        }

        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion

        #region 貼り合せステップ移動左方向ボタン
        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepLeftMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageStitchingStepMoveMouseDownEventHandler(_DIRECTION_LEFT);
        }

        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepLeftMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepLeftMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion

        #region 貼り合せステップ移動右方向ボタン
        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepRightMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageStitchingStepMoveMouseDownEventHandler(_DIRECTION_RIGHT);
        }

        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepRightMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender">SenderObject</param>
        /// <param name="e">EventArgs</param>
        private void StitchingStepRightMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion

        #region 左上方向ﾎﾞﾀﾝ
        /// <summary>
        /// 左上方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftUpMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_LEFTUP);
        }

        /// <summary>
        /// 左上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 左上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 左上ﾎﾞﾀﾝ

        #region 上方向ﾎﾞﾀﾝ
        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionUpMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_UP);
        }

        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 上方向ﾎﾞﾀﾝ

        #region 右上方向ﾎﾞﾀﾝ
        /// <summary>
        /// 右上方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightUpMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_RIGHTUP);
        }

        /// <summary>
        /// 右上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 右上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 右上方向ﾎﾞﾀﾝ

        #region 左方向ﾎﾞﾀﾝ
        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_LEFT);
        }

        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 左方向ﾎﾞﾀﾝ

        #region 右方向ﾎﾞﾀﾝ
        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_RIGHT);
        }

        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 右方向ﾎﾞﾀﾝ

        #region 左下方向ﾎﾞﾀﾝ
        /// <summary>
        /// 左下方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftDownMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_LEFTDOWN);
        }

        /// <summary>
        /// 左下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 左下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 左下方向ﾎﾞﾀﾝ

        #region 下方向ﾎﾞﾀﾝ
        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionDownMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_DOWN);
        }

        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 下方向ﾎﾞﾀﾝ

        #region 右下方向ﾎﾞﾀﾝ
        /// <summary>
        /// 右下方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightDownMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandlerForLiveStitching(_DIRECTION_RIGHTDOWN);
        }

        /// <summary>
        /// 右下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }

        /// <summary>
        /// 右下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandlerForLiveStitching();
        }
        #endregion 右下方向ﾎﾞﾀﾝ

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

        #region Private Method
        /// <summary>
        /// ScrollViewerの初期スクロール位置を中央にする
        /// </summary>
        private void SetOffsetCenter()
        {
            // TODO: Y.Ito 直接ScrollBarのメソッドをViewModelで呼んでいるため修正する
            ViewModel.UiController.sUiController.Display.SetScrollViewerForGetOffsetForStitchingImage(ref this.LayoutRoot);
        }
        #endregion Private Method
    }
}