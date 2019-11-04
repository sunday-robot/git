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
	public partial class UiNaviScreenPage
	{
        public UiNaviScreenPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        /// <summary>
        /// ﾏｳｽﾑｰﾌﾞｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMoveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            // マウスからのイベントかチェック
            if (e.StylusDevice != null)
            {
                return;
            }

            ViewModel.UiController.sUiController.Acquisition.MapMouseMoveEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// ﾏｳｽ左ﾎﾞﾀﾝﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // マウスからのイベントかチェック
            if (e.StylusDevice != null)
            {
                return;
            }

            if (e.MouseDevice.LeftButton == System.Windows.Input.MouseButtonState.Pressed && e.ClickCount == 2)
            {
                // 左ﾀﾞﾌﾞﾙｸﾘｯｸ時のみ処理続行
                ViewModel.UiController.sUiController.Acquisition.MapMouseDoubleClickEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
            }
            else
            {
                // それ以外は単純なマウスダウン
                ViewModel.UiController.sUiController.Acquisition.MapMouseDownEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
            }
        }

        /// <summary>
        /// ﾏｳｽｱｯﾌﾟﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUpHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            // マウスからのイベントかチェック
            if (e.StylusDevice != null)
            {
                return;
            }

            ViewModel.UiController.sUiController.Acquisition.MapMouseUpEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// マウスリーブハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            // マウスからのイベントかチェック
            if (e.StylusDevice != null)
            {
                return;
            }

            ViewModel.UiController.sUiController.Acquisition.MapMouseLeaveEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// マウスエンターハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnterHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // マウスからのイベントかチェック
            if (e.StylusDevice != null)
            {
                return;
            }

            ViewModel.UiController.sUiController.Acquisition.MapMouseEnterEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// タッチ開始イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TouchDownHandler(object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Acquisition.MapTouchDownEventHandler((e.GetTouchPoint((System.Windows.IInputElement)sender)).Position);
        }

        /// <summary>
        /// ﾏﾙﾁﾀｯﾁ変更ｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiTouchDeltaHandler(System.Object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Acquisition.MapTouchMoveEventHandler((e.GetTouchPoint((System.Windows.IInputElement)sender)).Position);
        }

        /// <summary>
        /// フリックｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        private void ManipulationInertiaStartingHandler(System.Object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Acquisition.MapTouchUpEventHandler((e.GetTouchPoint((System.Windows.IInputElement)sender)).Position);
        }

        /// <summary>
        /// タッチリーブハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TouchLeaveHandler(System.Object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Acquisition.MapTouchLeaveEventHandler((e.GetTouchPoint((System.Windows.IInputElement)sender)).Position);
        }

        /// <summary>
        /// タッチエンターハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TouchEnterHandler(object sender, System.Windows.Input.TouchEventArgs e)
        {
            ViewModel.UiController.sUiController.Acquisition.MapTouchEnterEventHandler((e.GetTouchPoint((System.Windows.IInputElement)sender)).Position);
        }

        #region GetContentResource

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblTagNavigation.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_NAVIGATION_SCREEN_PAGE_NAVIGATION_TAG);
            this.lblTagImageDetail.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_NAVIGATION_SCREEN_PAGE_IMAGE_DETAIL_TAG);
            this.lblTextBlockStage.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_NAVIGATION_SCREEN_PAGE_STAGE_LABEL);
        }

        #endregion GetContentResource
    }
}