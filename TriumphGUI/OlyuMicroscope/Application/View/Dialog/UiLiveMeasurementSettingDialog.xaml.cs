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
    /// ライブ計測ﾀﾞｲｱﾛｸﾞ
    /// </summary>
	public partial class UiLiveMeasurementSetting
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiLiveMeasurementSetting()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Application.ViewModel.UiController.sUiController;
		}

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.Label_LiveMesurement.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_DIALOG_LABEL_TITLE);
            this.Label_LiveSetting.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_DIALOG_LABEL_SETTING);
            this.grpbMeasurementItem.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_GROUP_MEASURE_ITEMS);
            //this.lblAll.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_BUTTON_LABEL_ALL);
            //this.lblDelete.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_BUTTON_LABEL_DELETE);

            this.lblLineColor.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_LINECOLOR);
            this.lblTempLineColor.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_TEMPLINECOLOR);
            this.lblPointColor.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_POINTCOLOR);
            this.lblLabelColor.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_LABELCOLOR);
            this.lblLabelBackColorVisible.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_LABELBACKCOLORVISIBLE);
            this.lblLabelLocation.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_LABELLOCATION);
            this.lblLabelBackColor.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_LIVEMEASURE_LABEL_LABELBACKCOLOR);
        }

        /// <summary>
        /// ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>
        /// 設定画面折りたたみﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void expSettingPage_Collapsed(object sender, RoutedEventArgs e)
        {
            ViewModel.UiController.sUiController.Measurement.SetMeasurementsSettingVisibility(System.Windows.Visibility.Hidden);
        }

        /// <summary>
        /// 設定画面開いくﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender">発生元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void expSettingPage_Expanded(object sender, RoutedEventArgs e)
        {
            ViewModel.UiController.sUiController.Measurement.SetMeasurementsSettingVisibility(System.Windows.Visibility.Visible);
        }

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
	}
}