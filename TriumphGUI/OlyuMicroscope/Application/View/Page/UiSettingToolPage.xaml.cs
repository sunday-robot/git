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
    public partial class UiSettingToolPage
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UiSettingToolPage()
        {
            this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();

            // ズーム倍率用スライドバーに、"-"ボタン押下時、カーソルキーによるスライダー移動時のイベントハンドラーを登録する。
            sldZoom.AddHandler(System.Windows.Controls.Primitives.RepeatButton.ClickEvent, new RoutedEventHandler(_ZoomSliderClickEventHandler), true);
            sldZoom.AddHandler(System.Windows.Controls.Primitives.RepeatButton.KeyDownEvent, new RoutedEventHandler(_ZoomSliderKeyDownEventHandler), true);

            // 総合倍率用スライドバーに、"-"ボタン押下時、カーソルキーによるスライダー移動時のイベントハンドラーを登録する。
            sldOverall.AddHandler(System.Windows.Controls.Primitives.RepeatButton.ClickEvent, new RoutedEventHandler(_ZoomSliderClickEventHandler), true);
            sldOverall.AddHandler(System.Windows.Controls.Primitives.RepeatButton.KeyDownEvent, new RoutedEventHandler(_ZoomSliderKeyDownEventHandler), true);
        }
        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 連続移動上方向マウスダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveUpMouseDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.MoveUpContinuouslyStart();
        }

        /// <summary>
        /// 連続移動上方向マウスアップハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveUpMouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.MoveContinuouslyStop();
        }

        /// <summary>
        /// 連続移動上方向マウスキャプチャ解除ハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveUpLostMouseCaptureHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.MoveContinuouslyStop();
        }

        /// <summary>
        /// 連続移動下方向マウスダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveDownMouseDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.MoveDownContinuouslyStart();
        }

        /// <summary>
        /// 連続移動下方向マウスアップハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveDownMouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.MoveContinuouslyStop();
        }

        /// <summary>
        /// 連続移動下方向マウスキャプチャ解除ハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveDownLostMouseCaptureHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.MoveContinuouslyStop();
        }

        /// <summary>
        /// 連続移動上下方向ボタンでのマウス右ボタンダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveMouseRightButtonUpHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.UiController.sUiController.Focus.ChangeZContinuousMovingSpeedTypeFromMouse();
        }

        /// <summary>
        /// Ｚ移動速度設定パネルのタッチダウンイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMoveTouchDownHandler(object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Focus.ChangeZContinuousMovingSpeedTypeFromTouch();
        }

        /// <summary>
        /// 粗動上方向マウスダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoughMoveUpMouseDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.RoughMoveStart();
        }

        /// <summary>
        /// 粗動上方向マウスアップハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoughMoveUpMouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.RoughMoveStop();
        }

        /// <summary>
        /// 粗動上方向マウスキャプチャ解除ハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoughMoveUpLostMouseCaptureHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.RoughMoveStop();
        }

        /// <summary>
        /// 粗動下方向マウスダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoughMoveDownMouseDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.RoughMoveStart();
        }

        /// <summary>
        /// 粗動下方向マウスアップハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoughMoveDownMouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.RoughMoveStop();
        }

        /// <summary>
        /// 粗動下方向マウスキャプチャ解除ハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoughMoveDownLostMouseCaptureHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.RoughMoveStop();
        }

        /// <summary>
        /// 微動上方向マウスダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMoveUpMouseDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.DetailMoveStart();
        }

        /// <summary>
        /// 微動上方向マウスアップハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMoveUpMouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.DetailMoveStop();
        }

        /// <summary>
        /// 微動上方向マウスキャプチャ解除ハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMoveUpLostMouseCaptureHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.DetailMoveStop();
        }

        /// <summary>
        /// 微動下方向マウスダウンハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMoveDownMouseDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.DetailMoveStart();
        }

        /// <summary>
        /// 微動下方向マウスアップハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMoveDownMouseUpHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.DetailMoveStop();
        }

        /// <summary>
        /// 微動下方向マウスキャプチャ解除ハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMoveDownLostMouseCaptureHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Focus.DetailMoveStop();
        }

        /// <summary>
        /// 補助線ItemのMouseLeaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Display.GridItemVisibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// 補助線ItemのMouseEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Display.GridItemVisibility = System.Windows.Visibility.Visible;
        }

        /// <summary>
        /// 補助線表示ボタンのMouseLeaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((System.Boolean)this.tbtnGrid.IsChecked)
            {
                Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Display.GridItemVisibility = System.Windows.Visibility.Hidden;
            }
        }

        /// <summary>
        /// 補助線表示ボタンのMouseEnterイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if ((System.Boolean)this.tbtnGrid.IsChecked)
            {
                Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Display.GridItemVisibility = System.Windows.Visibility.Visible;
            }
        }

        /// <summary>
        /// ズーム倍率スライダーおよび総合倍率スライダー用のクリックイベントハンドラー
        /// 
        /// 以下の特殊ケース用のもの。
        /// 倍率の指定方法を総合倍率に設定した状態で、倍率設定を小さいほうから2番目に設定する(x5対物レンズの場合、x75)。
        /// 倍率の指定方法をズーム倍率にする。(x5対物レンズの場合、ズーム倍率は約x1.08なので、スライダー位置は一番下のx1.0の位置になる。(仕様でそのように定められている。))
        /// この状態で、スライダーの"-"ボタンを押す。
        /// 既にスライダーは一番下にあるので、ValueChangedイベントは発生せず、バインディングされているViewModelのプロパティの更新も行われない。
        /// 
        /// スライダーのClickイベントハンドラーとして本メソッドを登録しておくことで、強制的にViewModelの更新が行われる。
        /// </summary>
        /// <param name="sender">スライダー</param>
        /// <param name="e">RoutedEventArgs</param>
        private void _ZoomSliderClickEventHandler(object sender, System.Windows.RoutedEventArgs e)
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
        /// ズーム倍率スライダーおよび総合倍率スライダー用のキーダウンイベントハンドラー
        /// (詳細は上のクリックイベントハンドラーを参照。)
        /// </summary>
        /// <param name="sender">スライダー</param>
        /// <param name="e">RoutedEventArgs</param>
        private void _ZoomSliderKeyDownEventHandler(object sender, System.Windows.RoutedEventArgs e)
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

        #endregion

        #region GetContentResource
        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblImageList.Content =
            this.lblImageList_.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_IMAGE_LIST_LABEL);
            this.lblFocusMenu.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_FOCUS_LABEL);
            this.btnFocusMenuHome.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_Z_ESCAPE_LABEL);
            this.btnFocusMenuHome.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_Z_ESCAPE_LABEL);
            this.lblZReleaaseWarning.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_Z_RELEASE_WARNING_LABEL);
            this.lblCurZPos.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_CURRENT_Z_POSITION_LABEL);

            // AF-ROI Start Add
            this.cbxAFRoiSwitch.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_ADJUST);
            this.cbxAFRoiDisplaySetting.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_DISPLAY);
            this.btnAFRoiPositionSizeDefault.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_BUTTON_ROI_DEFAULT);
            // AF-ROI End Add

            this.lblCheckBoxRegistZPos.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_REGISTERED_Z_POSITION_LABEL);
            this.lblCheckBox.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_Z_LOWER_LIMIT_POSITION_LABEL);
            this.lblBtnRegistrationZPos.Content =
            this.lblBtnRegistrationZLow.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_Z_VALUES_BUTTON_REGISTRATION_LABEL);
            this.lblZPosMargin.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_Z_VALUES_Z_POSITION_MARGIN_LABEL);
            this.lblZoom.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_ZOOM_LABEL);
            this.lblSupportMenu.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SETTING_TOOL_GROUP_SUPPORT_MENU_LABEL);

            this.rbtnZSpeedLow.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FOCUS_CONTINUOUS_MOVE_SPEED_LOW_LABEL_CONTENT);
            this.rbtnZSpeedMedium.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FOCUS_CONTINUOUS_MOVE_SPPED_MIDDLE_LABEL_CONTENT);
            this.rbtnZSpeedHigh.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_FOCUS_CONTINUOUS_MOVE_SPEED_HIGH_LABEL_CONTENT);

        }
        #endregion GetContentResource
    }
}