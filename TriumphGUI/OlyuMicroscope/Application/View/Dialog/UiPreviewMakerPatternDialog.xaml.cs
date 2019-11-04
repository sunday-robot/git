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
	public partial class UiPreviewMakerPatternDialog
	{
        /// <summary>
        /// ｺﾝｽﾄﾗｸﾀ
        /// </summary>
        public UiPreviewMakerPatternDialog()
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
            this.lblDialogTitle.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MAKER_PREVIEW_DIALOG_TITLE_NAME);
            this.cmdSecond.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MESSAGEBOX_OK);
            this.cmdThird.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MESSAGEBOX_CANCEL);

            this.lblListBoxDefect.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_DEFECT_BUTTON);
            this.lblListBoxFlat.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_FLAT_BUTTON);
            this.lblListBoxContamination.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_CONTAMINATION_BUTTON);
            this.lblListBoxBumpiness.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_IRREGULARITY_BUTTON);
            this.lblListBoxSubstrate.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_SUBSTRATE_BUTTON);
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