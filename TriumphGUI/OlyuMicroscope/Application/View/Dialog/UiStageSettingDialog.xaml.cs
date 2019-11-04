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
    /// ｽﾃｰｼﾞ設定ﾀﾞｲｱﾛｸﾞ
    /// </summary>
    public partial class UiStageSettingDialog
    {
        #region Const
        #endregion Const

        #region ｺﾝｽﾄﾗｸﾀ
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiStageSettingDialog()
		{
			this.InitializeComponent();
            
            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
		}
        #endregion ｺﾝｽﾄﾗｸﾀ

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