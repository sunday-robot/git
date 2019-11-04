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
	public partial class UiPreviewImagePage
	{
		public UiPreviewImagePage()
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
            this.btnDeteilSeting1.Content =
            this.btnDeteilSeting2.Content =
            this.btnDeteilSeting3.Content =
            this.btnDeteilSeting4.Content =
            this.btnDeteilSeting5.Content =
            this.btnDeteilSeting6.Content =
            this.btnDeteilSeting7.Content =
            this.btnDeteilSeting8.Content =
            this.btnDeteilSeting9.Content =
                Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_DETAILSETTING_TITLE_NAME);
        }

        /// <summary>
        /// ﾏｳｽﾑｰﾌﾞｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMoveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Object o = ((System.Windows.FrameworkElement)sender).Tag;
            System.Int32 id;
            if (o != null && System.Int32.TryParse(o.ToString(), out id))
            {
                ViewModel.UiController.sUiController.Preview.MouseMoveEventHandler(id, ((System.Windows.FrameworkElement)sender).IsMouseOver);
            }
        }

        /// <summary>
        /// ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Object o = ((System.Windows.FrameworkElement)sender).Tag;
            System.Int32 id;
            if (o != null && System.Int32.TryParse(o.ToString(), out id))
            {
                ViewModel.UiController.sUiController.Preview.MouseDownEventHandler(id);
            }
        }

        /// <summary>
        /// ﾏｳｽｱｯﾌﾟﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseUpHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Object o = ((System.Windows.FrameworkElement)sender).Tag;
            System.Int32 id;
            if (o != null && System.Int32.TryParse(o.ToString(), out id))
            {
                ViewModel.UiController.sUiController.Preview.MouseUpEventHandler(id);
            }
        }

        /// <summary>
        /// ﾏｳｽｴﾝﾀｰﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseEnterHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Object o = ((System.Windows.FrameworkElement)sender).Tag;
            System.Int32 id;
            if (o != null && System.Int32.TryParse(o.ToString(), out id))
            {
                ViewModel.UiController.sUiController.Preview.MouseEnterEventHandler(id);
            }
        }

        /// <summary>
        /// ﾏｳｽﾘｰﾌﾞﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeaveHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Object o = ((System.Windows.FrameworkElement)sender).Tag;
            System.Int32 id;
            if (o != null && System.Int32.TryParse(o.ToString(), out id))
            {
                ViewModel.UiController.sUiController.Preview.MouseLeaveEventHandler(id);
            }
        }

        /// <summary>
        /// ﾏｳｽﾀﾞﾌﾞﾙｸﾘｯｸﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseDoubleClickHandler(System.Object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Object o = ((System.Windows.FrameworkElement)sender).Tag;
            System.Int32 id;
            if (o != null && System.Int32.TryParse(o.ToString(), out id))
            {
                // 次のﾏｳｽﾀﾞｳﾝｲﾍﾞﾝﾄの発生を抑止する
                e.Handled = true;
                ViewModel.UiController.sUiController.Preview.MouseDoubleClickEventHandler(id);
            }
        }
	}
}