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
	public partial class UiHeaderBarPage
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
		public UiHeaderBarPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        /// <summary>
        /// ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.UiController.sUiController.Layout.MouseLeftButtonDownEventHandler(e.MouseDevice.GetPosition((System.Windows.IInputElement)sender));
        }

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblRBtnReport.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_REPORT_BUTTON);
            this.lblRBtnAnalize.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_ANALIZE_BUTTON);
            this.lblRBtnPhotography.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_PHOTOGRAPHY_BUTTON);
        }

	}
}