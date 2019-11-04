using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Collections.Generic;

namespace Olympus.LI.Triumph.Application.View
{
	public partial class UiCoordinatesRegistrationPage
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiCoordinatesRegistrationPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();
		}

        /// <summary>
        /// 登録座標ﾘｽﾄのSelectionChangedｲﾍﾞﾝﾄﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StageCoordinatesListSelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            // ViewModelの登録座標ﾘｽﾄのSelectionChangedｲﾍﾞﾝﾄﾊﾝﾄﾞﾗにDataGridの選択行ﾘｽﾄを渡して呼び出す
            ViewModel.UiController.sUiController.Stage.StageCoordinatesListSelectionChangedHandler(this.StageCoordinatesList.SelectedItems);
        }

        /// <summary>
        /// 行数ﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾞﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowCountTextChangedHandler(object sender, TextChangedEventArgs e)
        {
            // ViewModelの行数ﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾝﾄﾞﾗを呼び出す
            ViewModel.UiController.sUiController.Stage.RowCountTextChangedHandler(this.RowCount.Text, this.ColumnCount.Text);
        }

        /// <summary>
        /// 列数ﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾞﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnCountTextChangedHandler(object sender, TextChangedEventArgs e)
        {
            // ViewModelの列数ﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾝﾄﾞﾗを呼び出す
            ViewModel.UiController.sUiController.Stage.ColumnCountTextChangedHandler(this.RowCount.Text, this.ColumnCount.Text);
        }

        /// <summary>
        /// 行ﾋﾟｯﾁﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾞﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowPitchTextChangedHandler(object sender, TextChangedEventArgs e)
        {
            // ViewModelの行数ﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾝﾄﾞﾗを呼び出す
            ViewModel.UiController.sUiController.Stage.RowPitchTextChangedHandler(this.RowPitch.Text);
        }

        /// <summary>
        /// 列ﾋﾟｯﾁﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾞﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColumnPitchTextChangedHandler(object sender, TextChangedEventArgs e)
        {
            // ViewModelの列数ﾃｷｽﾄﾎﾞｯｸｽのTextChangedｲﾍﾞﾝﾄﾊﾝﾄﾞﾗを呼び出す
            ViewModel.UiController.sUiController.Stage.ColumnPitchTextChangedHandler(this.ColumnPitch.Text);
        }

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.lblColmnNumI.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_NUMBER_INDEX_LABEL);
            this.lblColmnPosX.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_X_POSITION_LABEL);
            this.lblColmnPosY.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_Y_POSITION_LABEL);
            this.lblColmnMove.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_CHANGE_POSITION_LABEL);
        }
	}
}