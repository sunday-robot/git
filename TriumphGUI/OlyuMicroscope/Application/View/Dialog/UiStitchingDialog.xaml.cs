using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Olympus.LI.Triumph.Application.ViewModel;

namespace Olympus.LI.Triumph.Application.View
{
    /// <summary>
    /// ｽﾃｰｼﾞ設定ﾀﾞｲｱﾛｸﾞ
    /// </summary>
    public partial class UiStitchingDialog
    {
        #region Const
        #endregion Const

        #region ｺﾝｽﾄﾗｸﾀ
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiStitchingDialog()
		{
			this.InitializeComponent();

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
		}
        #endregion ｺﾝｽﾄﾗｸﾀ

        #region Private Method
        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.lblTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_TITLE_NAME);
            this.rbAppointSheets.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_SPECIFY_PAGES);
            this.rbAppointLength.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_SPECIFY_SIZE);
            this.rbAppointPoints.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_STITCH_AREA);
            this.lblHorizontal.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_ALIGN_HORIZONTAL);
            this.lblVertical.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_ALIGN_VERTICAL);
            this.lblHorizontalSheetsUnit.Content =
            this.lblVerticalSheetsUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_NUM_OF_SHEETS);
            this.lblBasePosition.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_REFERENCE_POSITION);
            this.cbLargeAreas.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX);
            this.lblUnit.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_UNIT);
            this.lblOverlap.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_LABEL);
            this.btnUpdate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_ALIGNMENT_UPDATE_BUTTON);
            this.btnRegistry.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_REGISTRATION_BUTTON);
            this.btnRelease.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_RELEASE_BUTTON);
            this.grbStitchingPosition.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_STITCHING_POSITION);
            this.lblNo.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_DIALOG_GROUP_STITCHING_POSITION_NUM);
            this.btnMove.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_CHANGE_BUTTON);
            this.lblAcquisitionComment.Text = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_USE_CONDITION_DEFINED_IN_MAIN_MENU);
            this.cbCompletedExecuteStitching.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_STITCH_AFTER_TAKE_PHIOTOGRAPHY);
            this.cbIndividuallyAutoSave.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY);
            this.grbIndividuallyAutoSave.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY_SETTING);
            this.cbIndividuallyAutoSaveDetailEnabled.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY_SETTING);
            this.grbIndividuallyAutoSavePlace.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_AS);

            this.lblTakePhotograph0.Content =
            this.lblTakePhotograph1.Content =
            this.lblTakePhotograph2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL);
            this.lblStopAction0.Content =
            this.lblStopAction1.Content =
            this.lblStopAction2.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL);
            this.lblRecSTART.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_REC_START_LABEL);
            this.lblRecStop.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_PHOTOGRAPHY_GROUP_REC_STOP_LABEL);
        }
        #endregion

        #region ﾏｳｽ操作のｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// <summary>
        /// ﾀﾞｲｱﾛｸﾞ画面ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.DragMove();
        }
        #endregion ﾏｳｽ操作のｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ

        #region テキスト操作のイベントハンドラ

        #region 横枚数
        /// <summary>
        /// テキストボックスのロストフォーカス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalSheets_LostFocus(object sender, RoutedEventArgs e)
        {
            CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

            if (textBox != null)
            {
                // 更新
                ViewModel.UiController.sUiController.Acquisition.HorizontalSheets = Convert.ToInt32(textBox.Text);
            }
        }

        /// <summary>
        /// テキストボックスのキーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalSheets_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // エンターキーなら更新
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

                if (textBox != null)
                {
                    // 更新
                    ViewModel.UiController.sUiController.Acquisition.HorizontalSheets = Convert.ToInt32(textBox.Text);
                }
            }
        }
        #endregion

        #region 横長さ
        /// <summary>
        /// テキストボックスのロストフォーカス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalLength_LostFocus(object sender, RoutedEventArgs e)
        {
            CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

            if (textBox != null)
            {
                // 更新
                ViewModel.UiController.sUiController.Acquisition.HorizontalLength = textBox.Text;
            }
        }

        /// <summary>
        /// テキストボックスのキーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalLength_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // エンターキーなら更新
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

                if (textBox != null)
                {
                    // 更新
                    ViewModel.UiController.sUiController.Acquisition.HorizontalLength = textBox.Text;
                }
            }
        }
        #endregion

        #region 縦枚数
        /// <summary>
        /// テキストボックスのロストフォーカス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerticalSheets_LostFocus(object sender, RoutedEventArgs e)
        {
            CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

            if (textBox != null)
            {
                // 更新
                ViewModel.UiController.sUiController.Acquisition.VerticalSheets = Convert.ToInt32(textBox.Text);
            }
        }

        /// <summary>
        /// テキストボックスのキーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerticalSheets_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // エンターキーなら更新
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

                if (textBox != null)
                {
                    // 更新
                    ViewModel.UiController.sUiController.Acquisition.VerticalSheets = Convert.ToInt32(textBox.Text);
                }
            }
        }
        #endregion

        #region 縦長さ
        /// <summary>
        /// テキストボックスのロストフォーカス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerticalLength_LostFocus(object sender, RoutedEventArgs e)
        {
            CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

            if (textBox != null)
            {
                // 更新
                ViewModel.UiController.sUiController.Acquisition.VerticalLength = textBox.Text;
            }
        }

        /// <summary>
        /// テキストボックスのキーダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerticalLength_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // エンターキーなら更新
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

                if (textBox != null)
                {
                    // 更新
                    ViewModel.UiController.sUiController.Acquisition.VerticalLength = textBox.Text;
                }
            }
        }
        #endregion

        #region テキスト変更
        /// <summary>
        /// テキストボックスのテキスト変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValidateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CustomControl.ValidateTextBox textBox = sender as CustomControl.ValidateTextBox;

            if (textBox != null && ViewModel.UiController.sUiController.Acquisition.IsAreaDesignationTypeSheets())
            {
                Double value = Infrastructure.LocalizeUtil.ConvertUtil.ToDouble(textBox.Text);

                // 最小の制限
                if (value < textBox.RangeMin)
                {
                    textBox.Text = textBox.RangeMin.ToString();
                }

                // 最大の制限
                if (textBox.RangeMax < value)
                {
                    textBox.Text = textBox.RangeMax.ToString();
                }
            }
        }
        #endregion

        #endregion

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