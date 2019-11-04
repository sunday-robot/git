using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olympus.LI.Triumph.Application.View
{
    /// <summary>
    /// UiOptionSettingDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class UiOptionSettingDialog
    {
        public UiOptionSettingDialog()
        {
            InitializeComponent();
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
        }
        /// <summary>
        /// ﾏｳｽﾀﾞｳﾝﾊﾝﾄﾞﾗ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseLeftButtonDownHandler(System.Object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.DragMove();
        }

    }
}
