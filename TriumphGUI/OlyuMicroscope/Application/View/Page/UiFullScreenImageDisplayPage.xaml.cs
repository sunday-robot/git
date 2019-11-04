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
    /// 全画面ライブ画像領域
    /// </summary>
	public partial class UiFullScreenImageDisplayPage
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
		public UiFullScreenImageDisplayPage()
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
            // this.lblSpecificationDistanceUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FULL_SCREEN_PAGE_UNIT_LABEL);
        }

        /// <summary>
        /// ﾏｳｽﾑｰﾌﾞｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMoveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Point ptMousePosition = e.MouseDevice.GetPosition((System.Windows.IInputElement)sender);
            ViewModel.UiController.sUiController.Display.MouseMoveEventHandler(ptMousePosition);

            // グリッドから外れたらマウスリーブｲﾍﾞﾝﾄを発生させる
            System.Windows.Controls.Grid grid = (System.Windows.Controls.Grid)sender;
            if (ptMousePosition.X < 0 ||
                ptMousePosition.Y < 0 ||
                ptMousePosition.Y > grid.ActualHeight ||
                ptMousePosition.X > grid.ActualWidth)
            {
                this.MouseLeaveHandler(sender, e);
            }
        }

        /// <summary>
        /// ﾏｳｽ左ﾎﾞﾀﾝﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.MouseDevice.LeftButton == System.Windows.Input.MouseButtonState.Pressed && e.ClickCount == 2)
            {
                // 左ﾀﾞﾌﾞﾙｸﾘｯｸ時のみ処理続行
                ViewModel.UiController.sUiController.Display.MouseDoubleClickEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
            }
            else
            {
                // それ以外は単純なマウスダウン
                ViewModel.UiController.sUiController.Display.MouseDownEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
            }

            // イベント発生元グリッドをキャプチャして、他のコントロールにマウスイベントが行かないようにする
            this.grdMouseEventArea.CaptureMouse();
        }

        /// <summary>
        /// ﾏｳｽｱｯﾌﾟﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.MouseUpEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));

            // キャプチャ解除
            this.grdMouseEventArea.ReleaseMouseCapture();
        }

        /// <summary>
        /// ﾏｳｽﾎｲｰﾙﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheelHandler(System.Object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.MouseWheelEventHandler(e.Delta);
        }

        /// <summary>
        /// マウスリーブハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.MouseLeaveEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));

            // キャプチャ解除
            this.grdMouseEventArea.ReleaseMouseCapture();
        }

        /// <summary>
        /// タッチ開始イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TouchDownHandler(object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.ManipulationStartingHandler((e.GetTouchPoint((System.Windows.IInputElement)sender)).Position);
        }

        /// <summary>
        /// ﾏﾙﾁﾀｯﾁ変更ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiTouchDeltaHandler(System.Object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.ManipulationDeltaHandler(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.Y, e.ManipulationOrigin);
        }

        /// <summary>
        /// フリックｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        private void ManipulationInertiaStartingHandler(System.Object sender, System.Windows.Input.ManipulationInertiaStartingEventArgs e)
        {
            ViewModel.UiController.sUiController.Display.ManipulationInertiaStartingHandler(e.InitialVelocities.LinearVelocity.X, e.InitialVelocities.LinearVelocity.Y, e.ManipulationOrigin);
        }

        /// <summary>
        /// ｽﾃｰｼﾞ移動速度切替ﾎﾞﾀﾝ ﾏｳｽｸﾘｯｸｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender">ｾﾝﾀﾞｰｵﾌﾞｼﾞｪｸﾄ</param>
        /// <param name="e">ﾙｰﾃｨﾝｸﾞｲﾍﾞﾝﾄﾊﾟﾗﾒｰﾀ</param>
        private void OnStageCommandSpeedChange(object sender, RoutedEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.StageCommandSpeedChange();
        }

        #region 左上方向ﾎﾞﾀﾝ
        /// <summary>
        /// 左上方向ﾎﾞﾀﾝMouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftUpMouseDownHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_LEFTUP);
        }

        /// <summary>
        /// 左上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 左上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_UP);
        }

        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_RIGHTUP);
        }

        /// <summary>
        /// 右上方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightUpMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 右上方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightUpMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_LEFT);
        }

        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 左方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_RIGHT);
        }

        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 右方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_LEFTDOWN);
        }

        /// <summary>
        /// 左下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 左下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionLeftDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_DOWN);
        }

        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseDownEventHandler(_DIRECTION_RIGHTDOWN);
        }

        /// <summary>
        /// 右下方向ﾎﾞﾀﾝMouseUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightDownMouseUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
        }

        /// <summary>
        /// 右下方向ﾎﾞﾀﾝMouseLeave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionRightDownMouseLeaveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Stage.StageControllerDirectionMouseUpEventHandler();
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
    }
}