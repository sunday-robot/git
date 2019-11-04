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
	public partial class UiSpeculumPage
	{
        public UiSpeculumPage()
		{
			this.InitializeComponent();

            // ﾊﾞｲﾝﾃﾞｨﾝｸﾞﾃﾞｰﾀｺﾝﾃｷｽﾄを設定する
            this.DataContext = Olympus.LI.Triumph.Application.ViewModel.UiController.sUiController;

            // Read the resource, and Setup it on Content.
            this._GetContentResourceInPage();
        }

        #region GetContentResource
        /// <summary>
        /// Contentの設定
        /// </summary>
        private void _GetContentResourceInPage()
        {
            this.lblSpeculumPage.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_MICROSCOPY_LABEL_TITLE);
            this.rbtnBasePointMove.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_BASEPOINT_MOVE_LABEL);
            this.rbtnEucentricMove.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_ECUCENTRIC_MOVE_LABEL);
            this.rbtnMicroscopyBf.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_BRIGHT_FIELD_LABEL);
            this.rbtnMicroscopyDf.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_DARK_FIELD_LABEL);
            this.rbtnMicroscopyMix.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_MIXED_BF_DF_LABEL);
            this.rbtnMicroscopyDic.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_DIC_LABEL);
            this.rbtnMicroscopyPo.Content = Resource.UiResource.GetResourceValue(Resource.UiCaptionResourceKey.CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_POLARIZE_LABEL);
        }
        #endregion GetContentResource
    }
}