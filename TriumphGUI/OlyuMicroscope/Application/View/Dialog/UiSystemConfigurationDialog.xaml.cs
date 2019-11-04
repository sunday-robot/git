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
    /// UiSystemConfigurationDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class UiSystemConfigurationDialog
    {
        public UiSystemConfigurationDialog()
        {
            InitializeComponent();
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;
            
            // Read the resource, and Setup it on Content.
            this._GetDialogContentResource();
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

        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetDialogContentResource()
        {
            this.colHardwareName.Header = Resource.UiResource.GetResourceValue(Olympus.LI.Triumph.Application.Resource.UiCaptionResourceKey.CAP_SYSCONFIGURATION_TABLE_COLUMN_HARD);
            this.colSoftwareName.Header = Resource.UiResource.GetResourceValue(Olympus.LI.Triumph.Application.Resource.UiCaptionResourceKey.CAP_SYSCONFIGURATION_TABLE_COLUMN_SOFT);
        }
    }
}
