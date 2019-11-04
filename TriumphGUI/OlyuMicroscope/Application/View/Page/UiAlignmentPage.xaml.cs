using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

using System.Text.RegularExpressions;

namespace Olympus.LI.Triumph.Application.View
{
	public partial class UiAlignmentPage
	{
        public UiAlignmentPage()
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
            this.lblColmnNumI.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_NUMBER_INDEX_LABEL);
            this.lblColmnPosX.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_X_POSITION_LABEL);
            this.lblColmnPosY.Header = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_STAGE_SETTING_GROUP_Y_POSITION_LABEL);
        }

        /// <summary>
        /// アライメントリストのPreviewKeyDownイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>1つ1つのDataGridへの入力のチェックおよび無効化（削除）</remarks>
        private void AlignmentBAPListPreviewKeyDownHandler(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // 整数チェック
            Boolean blnCheckResult = false;

            // μmの場合は整数のみ許容
            if (Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Layout.CommonUnit == Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAY_UNIT_UM))
            {
                blnCheckResult = View.Utility.UiTextBoxCheck.IsNumericField(e);
            }
            else
            {
                blnCheckResult = View.Utility.UiTextBoxCheck.IsDecimalField(e);
            }

            if (!blnCheckResult)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        /// <summary>
        /// アライメントリストのCellEditEndingイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>セルへの入力終了時の数値文字列のチェックおよび0初期化</remarks>
        private void AlignmentBAPListCellEditEndingHandler(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            ViewModel.UiController.sUiController.Stage.AlignmentBAPListCellEditEndingHandler(e);
        }
        
        /// <summary>
        /// 個々の入力テキスト時のチェック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>=（-と同じキー）はKeyDownではじけないので、このｲﾍﾞﾝﾄではじく。
        /// ひらがなを入力されたときは確定させないと、ここにこないしe.Handled = trueにしても入ってしまうので、KeyDownではじく</remarks>
        private void AlignmentBAPListPreviewTextInputHandler(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // μmの場合は整数のみ許容
            if (Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController.Layout.CommonUnit == Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_DISPLAY_UNIT_UM))
            {
                // -か、数字？
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"[-\d]"))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                // -か、数字か、.か？
                if (System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"[-0-9\.]"))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }        
	}
}
