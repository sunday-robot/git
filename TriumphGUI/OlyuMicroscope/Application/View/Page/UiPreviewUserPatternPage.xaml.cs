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
	public partial class UiPreviewUserPatternPage
	{
        public UiPreviewUserPatternPage()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
		}

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.btnImage_0_FileOpen.Content =
            this.btnImage_1_FileOpen.Content =
            this.btnImage_2_FileOpen.Content =
            this.btnImage_3_FileOpen.Content =
            this.btnImage_4_FileOpen.Content =
            this.btnImage_5_FileOpen.Content =
            this.btnImage_6_FileOpen.Content =
            this.btnImage_7_FileOpen.Content =
            this.btnImage_8_FileOpen.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_FILEOPEN_BUTTON);
            this.btnImage_0_Delete.Content =
            this.btnImage_1_Delete.Content =
            this.btnImage_2_Delete.Content =
            this.btnImage_3_Delete.Content =
            this.btnImage_4_Delete.Content =
            this.btnImage_5_Delete.Content =
            this.btnImage_6_Delete.Content =
            this.btnImage_7_Delete.Content =
            this.btnImage_8_Delete.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_USER_PREVIEW_DELETE_BUTTON);
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
            if (System.Int32.TryParse(o.ToString(), out id))
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
            if (System.Int32.TryParse(o.ToString(), out id))
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
            if (System.Int32.TryParse(o.ToString(), out id))
            {
                ViewModel.UiController.sUiController.Preview.MouseUpEventHandler(id);
            }
        }
	}
}