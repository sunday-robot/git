// ------------------------------------------------------------------------------
// <copyright file="CstCaptionResourceKey.cs" company="OLYMPUS,LI">
//     Copyright (C) 2010-2011 OLYMPUS CORPORATION All Rights Reserved.
// </copyright>
// ------------------------------------------------------------------------------
// Source history
// version      date        person      content
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus.LI.Triumph.Application.Resource
{
    /// <summary>
    /// GUIｷｬﾌﾟｼｮﾝﾘｿｰｽｷｰの定義
    /// </summary>
    public static class UiCaptionResourceKey
    {
        #region ｱﾌﾟﾘｹｰｼｮﾝ名
        /// <summary>
        /// ｱﾌﾟﾘｹｰｼｮﾝ名
        /// </summary>
        public static readonly System.String CAP_APPLICATION_NAME = "CAP_APPLICATION_NAME";
        #endregion ｱﾌﾟﾘｹｰｼｮﾝ名

        #region 共通
        /// <summary>
        /// 表示単位「μm」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_UM = "CAP_DISPLAY_UNIT_UM";

        /// <summary>
        /// 表示単位「mm」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_MM = "CAP_DISPLAY_UNIT_MM";

        /// <summary>
        /// 表示単位「inch」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_INCH = "CAP_DISPLAY_UNIT_INCH";

        /// <summary>
        /// 表示単位「mil」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_MIL = "CAP_DISPLAY_UNIT_MIL";

        /// <summary>
        /// 表示単位「μm²」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_UM2 = "CAP_DISPLAY_UNIT_UM2";

        /// <summary>
        /// 表示単位「mm²」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_MM2 = "CAP_DISPLAY_UNIT_MM2";

        /// <summary>
        /// 表示単位「inch²」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_INCH2 = "CAP_DISPLAY_UNIT_INCH2";

        /// <summary>
        /// 表示単位「mil²」のキャプション
        /// </summary>
        public static readonly System.String CAP_DISPLAY_UNIT_MIL2 = "CAP_DISPLAY_UNIT_MIL2";
        #endregion

        #region ParentWindowFrame

        /// <summary>
        /// TOP_FRAMEのエキスパートモードのラベル
        /// </summary>
        public static readonly System.String CAP_MICROSCOPE_FRAME_WINDOW_GROUP_EXPERT_MODE_TITLE_NAME = "CAP_MICROSCOPE_FRAME_WINDOW_GROUP_EXPERT_MODE_TITLE_NAME";

        /// <summary>
        /// TOP_FRAMEのかんたんモードのラベル
        /// </summary>
        public static readonly System.String CAP_MICROSCOPE_FRAME_WINDOW_GROUP_EASY_MODE_TITLE_NAME = "CAP_MICROSCOPE_FRAME_WINDOW_GROUP_EASY_MODE_TITLE_NAME";

        /// <summary>
        /// TOP_FRAMEのHeaderBarのLiveのラベル
        /// </summary>
        public static readonly System.String CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_LIVE_LABEL = "CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_LIVE_LABEL";

        /// <summary>
        /// TOP_FRAMEのHeaderBarのレポートボタンのラベル
        /// </summary>
        public static readonly System.String CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_REPORT_BUTTON = "CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_REPORT_BUTTON";

        /// <summary>
        /// TOP_FRAMEのHeaderBarの解析ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_ANALIZE_BUTTON = "CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_ANALIZE_BUTTON";

        /// <summary>
        /// TOP_FRAMEのHeaderBarの撮影ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_PHOTOGRAPHY_BUTTON = "CAP_MICROSCOPE_FRAME_WINDOW_GROUP_HEADER_BAR_GROUP_PHOTOGRAPHY_BUTTON";

        #endregion ParentWindowFrame

        #region ﾒｯｾｰｼﾞﾀﾞｲｱﾛｸﾞ
        /// <summary>
        /// ﾒｯｾｰｼﾞﾎﾞｯｸｽに表示する共通のﾀｲﾄﾙ
        /// </summary>
        public static readonly System.String CAP_MESSAGEBOX_TITLE = "CAP_MESSAGEBOX_TITLE";

        /// <summary>
        /// ﾒｯｾｰｼﾞﾎﾞｯｸｽ OK
        /// </summary>
        public static readonly System.String CAP_MESSAGEBOX_OK = "CAP_MESSAGEBOX_OK";

        /// <summary>
        /// ﾒｯｾｰｼﾞﾎﾞｯｸｽ ｷｬﾝｾﾙ
        /// </summary>
        public static readonly System.String CAP_MESSAGEBOX_CANCEL = "CAP_MESSAGEBOX_CANCEL";

        /// <summary>
        /// ﾒｯｾｰｼﾞﾎﾞｯｸｽ Yes
        /// </summary>
        public static readonly System.String CAP_MESSAGEBOX_YES = "CAP_MESSAGEBOX_YES";

        /// <summary>
        /// ﾒｯｾｰｼﾞﾎﾞｯｸｽ No
        /// </summary>
        public static readonly System.String CAP_MESSAGEBOX_NO = "CAP_MESSAGEBOX_NO";

        /// <summary>
        /// ダイアログ：Apply
        /// </summary>
        public static readonly System.String CAP_DIALOG_APPLY = "CAP_DIALOG_APPLY";

        /// <summary>
        /// ダイアログ：STOP
        /// </summary>
        public static readonly System.String CAP_DIALOG_STOP = "CAP_DIALOG_STOP";

        /// <summary>
        /// ダイアログ：再開
        /// </summary>
        public static readonly System.String CAP_DIALOG_RETRY = "CAP_DIALOG_RETRY";

        /// <summary>
        /// ダイアログ：中止
        /// </summary>
        public static readonly System.String CAP_DIALOG_DISCONTINUE = "CAP_DIALOG_DISCONTINUE";
        #endregion ﾒｯｾｰｼﾞﾀﾞｲｱﾛｸﾞ

        #region ﾒｲﾝﾒﾆｭｰ
        /// <summary>
        /// ﾗｲﾌﾞ開始/停止ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_BUTTON_LIVE = "CAP_MAINMENU_BUTTON_LIVE";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ表示ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_BUTTON_PREVIEW = "CAP_MAINMENU_BUTTON_PREVIEW";

        /// <summary>
        /// 2画面表示ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_2DISPLAY = "CAP_MAINMENU_EXPANDER_2DISPLAY";

        /// <summary>
        /// 全画面表示ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_BUTTON_WIDE = "CAP_MAINMENU_BUTTON_WIDE";

        /// <summary>
        /// 詳細設定ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_BUTTON_DETAIL = "CAP_MAINMENU_BUTTON_DETAIL";

        /// <summary>
        /// 貼り合せ表示ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_STITCHING = "CAP_MAINMENU_EXPANDER_STITCHING";

        /// <summary>
        /// メインメニューのLive貼り合せ表示ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_LIVE_STITCH = "CAP_MAINMENU_EXPANDER_LIVE_STITCH";

        /// <summary>
        /// 条件設定ﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_CONDITION = "CAP_MAINMENU_EXPANDER_CONDITION";

        /// <summary>
        /// ﾅﾋﾞﾎﾞﾀﾝ
        /// </summary>
        public static readonly System.String CAP_MAINMENU_BUTTON_NAVIGATION = "CAP_MAINMENU_BUTTON_NAVIGATION";

        /// <summary>
        /// メインメニューの電動貼り合せボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_AUTO_STITCH_TOGGLE_BUTTON = "CAP_MAINMENU_EXPANDER_AUTO_STITCH_TOGGLE_BUTTON";

        /// <summary>
        /// メインメニューの条件読み出しボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_READ_CONDITION_BUTTON = "CAP_MAINMENU_EXPANDER_READ_CONDITION_BUTTON";

        /// <summary>
        /// メインメニューの条件保存ボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_SAVE_CONDITION_BUTTON = "CAP_MAINMENU_EXPANDER_SAVE_CONDITION_BUTTON";

        /// <summary>
        /// メインメニューの画像開くボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_VIEW_IMAGE_BUTTON = "CAP_MAINMENU_EXPANDER_VIEW_IMAGE_BUTTON";

        /// <summary>
        /// メインメニューの縦分割ボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_SPLIT_VERTICAL_RADIO_BUTTON = "CAP_MAINMENU_EXPANDER_SPLIT_VERTICAL_RADIO_BUTTON";

        /// <summary>
        /// メインメニューの横分割ボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_SPLIT_HORIZONTAL_RADIO_BUTTON = "CAP_MAINMENU_EXPANDER_SPLIT_HORIZONTAL_RADIO_BUTTON";

        /// <summary>
        /// メインメニューの表示入れ替えボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_SWAP_SCREEN_BUTTON = "CAP_MAINMENU_EXPANDER_SWAP_SCREEN_BUTTON";

        /// <summary>
        /// メインメニューの縦全体ボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_FULL_VERTICAL_RADIO_BUTTON = "CAP_MAINMENU_EXPANDER_FULL_VERTICAL_RADIO_BUTTON";

        /// <summary>
        /// メインメニューの横全体ボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_FULL_HOROZONTAL_RADIO_BUTTON = "CAP_MAINMENU_EXPANDER_FULL_HOROZONTAL_RADIO_BUTTON";

        /// <summary>
        /// メインメニューのミニビューボタン
        /// </summary>
        public static readonly System.String CAP_MAINMENU_EXPANDER_THUMBNAIL_RADIO_BUTTON = "CAP_MAINMENU_EXPANDER_THUMBNAIL_RADIO_BUTTON";

        /// <summary>
        /// メイン画面のNavigationScreenのNavigationTag
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_SCREEN_PAGE_NAVIGATION_TAG = "CAP_NAVIGATION_SCREEN_PAGE_NAVIGATION_TAG";

        /// <summary>
        /// メイン画面のNavigationScreenの画像詳細Tag
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_SCREEN_PAGE_IMAGE_DETAIL_TAG = "CAP_NAVIGATION_SCREEN_PAGE_IMAGE_DETAIL_TAG";

        /// <summary>
        /// メイン画面のNavigationScreenのNavigationTagの電動Stageラベル
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_SCREEN_PAGE_STAGE_LABEL = "CAP_NAVIGATION_SCREEN_PAGE_STAGE_LABEL";

        /// <summary>
        /// メイン画面のNavigationScreenのNavigationTagの原点ラベル
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_SCREEN_PAGE_ORIGIN_LABEL = "CAP_NAVIGATION_SCREEN_PAGE_ORIGIN_LABEL";
        #endregion ﾒｲﾝﾒﾆｭｰ

        #region ContextMenu

        /// <summary>
        /// ContextMenuのZoom
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_ZOOM_LABEL = "CAP_CONTEXT_MENU_ITEM_ZOOM_LABEL";

        /// <summary>
        /// ContextMenuのBrightness
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_BRIGHTNESS_LABEL = "CAP_CONTEXT_MENU_ITEM_BRIGHTNESS_LABEL";

        /// <summary>
        /// ContextMenuのRough move
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_ROUGH_MOVE_LABEL = "CAP_CONTEXT_MENU_ITEM_ROUGH_MOVE_LABEL";

        /// <summary>
        /// ContextMenuのDetail move
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_DETAIL_MOVE_LABEL = "CAP_CONTEXT_MENU_ITEM_DETAIL_MOVE_LABEL";

        /// <summary>
        /// ContextMenuのGrid表示：Tiny
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_GRID_TINY_LABEL = "CAP_CONTEXT_MENU_ITEM_GRID_TINY_LABEL";

        /// <summary>
        /// ContextMenuのGrid表示：Small
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_GRID_SMALL_LABEL = "CAP_CONTEXT_MENU_ITEM_GRID_SMALL_LABEL";

        /// <summary>
        /// ContextMenuのGrid表示：Middle
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_GRID_MIDDLE_LABEL = "CAP_CONTEXT_MENU_ITEM_GRID_MIDDLE_LABEL";

        /// <summary>
        /// ContextMenuのGrid表示：Large
        /// </summary>
        public static readonly System.String CAP_CONTEXT_MENU_ITEM_GRID_LARGE_LABEL = "CAP_CONTEXT_MENU_ITEM_GRID_LARGE_LABEL";

        #endregion ContextMenu

        #region 詳細設定

        /// <summary>
        /// 詳細設定のPageTitle
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_TITLE_NAME = "CAP_PAGE_DETAILSETTING_TITLE_NAME";

        /// <summary>
        /// 詳細設定のZ位置のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_SETTING = "CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_SETTING";

        /// <summary>
        /// 詳細設定のAFグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_GROUP_LABEL_AF = "CAP_PAGE_DETAILSETTING_GROUP_LABEL_AF";

        /// <summary>
        /// 詳細設定のAFグループのROIラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_ADJUST = "CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_ADJUST";

        /// <summary>
        /// 詳細設定のAFグループの初期化ボタンラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_BUTTON_ROI_DEFAULT = "CAP_PAGE_DETAILSETTING_BUTTON_ROI_DEFAULT";

        /// <summary>
        /// 詳細設定のAFグループのROIガイドのトグルボタンラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_DISPLAY = "CAP_PAGE_DETAILSETTING_TOGGLEBUTTON_ROI_DISPLAY";

        /// <summary>
        /// 詳細設定のZ位置登録のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_GROUP_LABEL_Z_POSITION_REGISTRATION = "CAP_PAGE_DETAILSETTING_GROUP_LABEL_Z_POSITION_REGISTRATION";

        /// <summary>
        /// 詳細設定のZ位置設定の有効無効ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_CHECKBOX_ENABLE_Z_POSITION = "CAP_PAGE_DETAILSETTING_LABEL_CHECKBOX_ENABLE_Z_POSITION";

        /// <summary>
        /// 詳細設定のZ位置登録ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_BUTTON_Z_POSITION_REGISTRATION = "CAP_PAGE_DETAILSETTING_LABEL_BUTTON_Z_POSITION_REGISTRATION";

        /// <summary>
        /// 詳細設定のZ位置登録の単位ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_UNIT_LABEL = "CAP_PAGE_DETAILSETTING_LABEL_Z_POSITION_UNIT_LABEL";

        /// <summary>
        /// 詳細設定の近接焦点のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_GROUP_LABEL_LOWER_LIMIT = "CAP_PAGE_DETAILSETTING_GROUP_LABEL_LOWER_LIMIT";

        /// <summary>
        /// 詳細設定の近接焦点の有効無効チェックボックスのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_CHECKBOX_ENABLE_LIMIT_RANGE = "CAP_PAGE_DETAILSETTING_LABEL_CHECKBOX_ENABLE_LIMIT_RANGE";

        /// <summary>
        /// 詳細設定の近接焦点の警告表示のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_ALERM_ON_LIMIT_RANGE = "CAP_PAGE_DETAILSETTING_LABEL_ALERM_ON_LIMIT_RANGE";

        /// <summary>
        /// 詳細設定の近接焦点の設定ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_BUTTON_LOWER_LIMIT_REGISTRATION = "CAP_PAGE_DETAILSETTING_LABEL_BUTTON_LOWER_LIMIT_REGISTRATION";

        /// <summary>
        /// 詳細設定の近接焦点のTREE表示のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_LABEL_LOWERLIMIT_POS_REGISTRATION_TREE = "CAP_PAGE_DETAILSETTING_LABEL_LOWERLIMIT_POS_REGISTRATION_TREE";

        /// <summary>
        /// 詳細設定の観察設定のタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_TITLE_NAME = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_TITLE_NAME";

        /// <summary>
        /// 詳細設定の観察設定のBLURCORRECTIONグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のBLURCORRECTIONのチェックボックスのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_CHECKBOX_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_CHECKBOX_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のBLURCORRECTIONの状態表示のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_LABEL_EFFECTIVE_INVALID = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BLURCORRECTION_LABEL_EFFECTIVE_INVALID";

        /// <summary>
        /// 詳細設定の観察設定のASグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_APERTURE_STOP_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_APERTURE_STOP_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のASの設定状態のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_APERTURE_STOP_LABEL_SETTING = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_APERTURE_STOP_LABEL_SETTING";

        /// <summary>
        /// 詳細設定の観察設定のMonochromeModeグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_MONOCHROME_MODE_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_MONOCHROME_MODE_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のMonochromeModeの設定状態のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_MONOCHROME_MODE_LABEL_SETTING = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_MONOCHROME_MODE_LABEL_SETTING";

        /// <summary>
        /// 詳細設定の観察設定のAEグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のAEのトグルボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_TOGGLEBUTTON_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_TOGGLEBUTTON_LABEL";

        /// <summary>
        /// 詳細設定のTargetラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_TARGET_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_TARGET_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のAEの初期化ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_BUTTON_DEFAULT_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_AE_BUTTON_DEFAULT_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のAspectグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のAspectのAspect=1:1ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_ASPECT_1_1_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_ASPECT_1_1_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のAspectのAspect=4:3ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_ASPECT_4_3_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_ASPECT_GROUP_ASPECT_4_3_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のBinningグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のBinningのBinning=OFFのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_BINNING_OFF_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_BINNING_OFF_LABEL";

        /// <summary>
        /// 詳細設定の観察設定のBinningのBinning=2x2のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_BINNING_2x2_LABEL = "CAP_PAGE_DETAILSETTING_OBSERVATIONSETTING_BINNING_GROUP_BINNING_2x2_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のグループラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのグループラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのBrightnessのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_BRIGHTNESS_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_BRIGHTNESS_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのTextureのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_TEXTURE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_TEXTURE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのContrastのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CONTRAST_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CONTRAST_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのChromeのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CHROME_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_CHROME_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのパラメータ固定化ラベル(Texture/Anti-Halation共用)
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_KEEP_PARAMETER_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_HDR_GROUP_KEEP_PARAMETER_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのContrastグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのContrastのLOWラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_LOW_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_LOW_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのContrastのNORMALラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_NORMAL_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_NORMAL_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のHDRのContrastのHIGHラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_HIGH_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_CONTRAST_GROUP_HIGH_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATIONグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATION_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATION_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATIONのChromeラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATION_GROUP_CHROME_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATION_GROUP_CHROME_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-Highグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_LABEL";

        /// <summary>
        /// 【Ver.2.1.1】詳細設定の画像調整のANTIHALATION-Highの初期化ボタンラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_GAIN_BUTTON_DEFAULT_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_GAIN_BUTTON_DEFAULT_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのASYMMETRYラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_ASYMMETRY_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_ASYMMETRY_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのSTRENGTHラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_STRENGTH_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_STRENGTH_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのSATURATIONラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_SATURATION_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_SATURATION_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのNRラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのNRのOFFラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_OFF_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_OFF_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのNRのLOWラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_LOW_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_LOW_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのNRのMIDラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_MID_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_MID_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のANTIHALATION-HighのNRのHIGHラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_HIGH_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_ANTIHALATIONHIGH_GROUP_NR_HIGH_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の特定色強調グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_SPECIFIC_COLOR_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_SPECIFIC_COLOR_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のエッジ強調グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_EDGE_EMPHASIS_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_EDGE_EMPHASIS_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のガンマ補正グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_GAMMA_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_GAMMA_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGAINグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGAIN-CALIBRATEボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BUTTON_CALIBRATE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BUTTON_CALIBRATE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGAIN-初期化ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BUTTON_DEFAULT_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BUTTON_DEFAULT_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのRED-GAINのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_RED_GAIN_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_RED_GAIN_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGREEN-GAINのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_GREEN_GAIN_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_GREEN_GAIN_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのBLUE-GAINのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BLUE_GAIN_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_GAIN_BLUE_GAIN_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGAINのROIグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGAINのROIのON/OFFラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_BUTTON_ON_OFF_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_BUTTON_ON_OFF_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のホワイトバランスのGAINのROIの初期化ボタンラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_BUTTON_DEFAULT_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_WHITEBALANCE_GROUP_ROI_GROUP_BUTTON_DEFAULT_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のSNAPグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_SNAP_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_SNAP_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定の3Dグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_3D_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_3D_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のMOVIEグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のMOVIEのタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_TITLE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_TITLE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のMOVIEのLOWラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_LOW_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_LOW_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のMOVIEのSTANDARDラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_STANDARD_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_MOVIE_GROUP_STANDARD_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のフレームレートのタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_TITLE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_TITLE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のフレームレートの１FPSラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_1_FPS_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_1_FPS_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のフレームレートの15FPSラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_15_FPS_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_FRAME_RATE_GROUP_15_FPS_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定の自動保存ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_AUTOSAVE_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_AUTOSAVE_GROUP_LABEL";
                
        /// <summary>
        /// 詳細設定の画像調整の撮影設定のGRRラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_LABEL";
                        
        /// <summary>
        /// 詳細設定の画像調整の撮影設定のGRR用取り込み 有効/無効（チェックボックス）
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_ACQENABLE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_ACQENABLE_LABEL";
        
        /// <summary>
        /// 詳細設定の画像調整の撮影設定のGRR測定者ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_OPERATOR_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_OPERATOR_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のGRR測定者編集ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_EDITOPERATORBUTTON_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_EDITOPERATORBUTTON_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のGRRサンプルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_SAMPLE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_SAMPLE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整の撮影設定のサンプル名編集ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_EDITSAMPLEBUTTON_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_PHOTOSET_GROUP_GRR_GROUP_EDITSAMPLEBUTTON_LABEL";
                
        /// <summary>
        /// 詳細設定の画像調整のマップ設定グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_MAP_SET_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_MAP_SET_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のマップ設定のタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_MAP_SET_GROUP_TITLE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_MAP_SET_GROUP_TITLE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のステージ設定グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_SET_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_SET_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のステージ設定のタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_SET_GROUP_STAGE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_SET_GROUP_STAGE_LABEL";

        /// <summary>
        /// 詳細設定のステージ設定自動補正のタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_AUTO_CALIBRATION_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_AUTO_CALIBRATION_GROUP_LABEL";

        /// <summary>
        /// 詳細設定のステージ設定自動補正の開始ボタンラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_AUTO_CALIBRATION_START_BUTTON = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_STAGE_AUTO_CALIBRATION_START_BUTTON";

        /// <summary>
        /// 詳細設定の画像調整のその他設定グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSLEEPグループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSLEEPの有効無効表示ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_ENEBLE_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_ENEBLE_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSLEEPのSLEEP検出時間のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_WAIT_TIME_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_WAIT_TIME_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSLEEPのSLEEP検出時間の入力単位ラベル（分）
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_TIME_UNIT_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_TIME_UNIT_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSLEEPのSLEEP設定の更新ボタンラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_APPLY_BUTTON_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SLEEP_GROUP_SLEEP_APPLY_BUTTON_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSCALE表示グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SCALE_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SCALE_GROUP_LABEL";

        /// <summary>
        /// 詳細設定の画像調整のその他設定のSCALE表示のチェックボックスのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SCALE_GROUP_CHECKBOX_LABEL = "CAP_PAGE_DETAILSETTING_IMAGEREVISION_GROUP_OTHER_SET_GROUP_SCALE_GROUP_CHECKBOX_LABEL";

        /// <summary>
        /// ILLMINATION詳細設定Pageのタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_DETAIL_TITLE_NAME = "CAP_PAGE_ILLMINATION_DETAIL_TITLE_NAME";

        /// <summary>
        /// 詳細設定の画像更新ズームのラベル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTINGS_GROUP_ZOOM_AND_UPDATE_IMAGE_MAP = "CAP_DETAIL_SETTINGS_GROUP_ZOOM_AND_UPDATE_IMAGE_MAP";

        /// <summary>
        /// 詳細設定のサンプル交換位置のラベル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTINGS_GROUP_SAMPLE_EXCHANGE_POSITION = "CAP_DETAIL_SETTINGS_GROUP_SAMPLE_EXCHANGE_POSITION";

        /// <summary>
        /// 詳細設定のステージ自動補正のラベル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTINGS_GROUP_STAGE_AUTO_CALIBRATION = "CAP_DETAIL_SETTINGS_GROUP_STAGE_AUTO_CALIBRATION";

        /// <summary>
        /// 詳細設定のマップのBFから切り替え時更新のチェックボックスのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAP_UPDATE_SWITCHING_BF_LABEL = "CAP_PAGE_DETAILSETTING_MAP_UPDATE_SWITCHING_BF_LABEL";

        /// <summary>
        /// 詳細設定のマップの自動更新グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_LABEL = "CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_LABEL";

        /// <summary>
        /// 詳細設定のマップの自動更新グループx1のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X1_LABEL = "CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X1_LABEL";

        /// <summary>
        /// 詳細設定のマップの自動更新グループx2のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X2_LABEL = "CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X2_LABEL";

        /// <summary>
        /// 詳細設定のマップの自動更新グループx5のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X5_LABEL = "CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X5_LABEL";

        /// <summary>
        /// 詳細設定のマップの自動更新グループx10のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X10_LABEL = "CAP_PAGE_DETAILSETTING_MAP_AUTO_UPDATE_X10_LABEL";

        /// <summary>
        /// 詳細設定画面のツリービューの"倍率 - 倍率指定モード"のラベル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTINGS_GROUP_MAGNIFICATION_MODE_SETTING = "CAP_DETAIL_SETTINGS_GROUP_MAGNIFICATION_MODE_SETTING";

        /// <summary>
        /// 詳細設定画面 - 倍率設定画面のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAGNIFICATION_GROUP_LABEL = "CAP_PAGE_DETAILSETTING_MAGNIFICATION_GROUP_LABEL";

        /// <summary>
        /// 詳細設定画面 - 倍率設定画面 - 倍率指定モードのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_DETAILSETTING_MAGNIFICATION_GROUP_MODE_LABEL = "CAP_PAGE_DETAILSETTING_MAGNIFICATION_GROUP_MODE_LABEL";

        /// <summary>
        /// 詳細設定画面 - 倍率設定画面 - 倍率指定モード - ズーム倍率モードラジオボタンのテキスト
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_SETTING_ZOOM_MODE_TEXT = "CAP_MAGNIFICATION_SETTING_ZOOM_MODE_TEXT";

        /// <summary>
        /// 詳細設定画面 - 倍率設定画面 - 倍率指定モード - 総合倍率モードラジオボタンのテキスト
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_SETTING_TOTAL_MODE_TEXT = "CAP_MAGNIFICATION_SETTING_TOTAL_MODE_TEXT";

        #endregion 詳細設定

        #region 詳細設定項目

        /// <summary>
        /// 詳細設定項目のZ位置タイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_Z_POSITION_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_Z_POSITION_SETTING_TITLE";

        /// <summary>
        /// 詳細設定項目の観察タイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_OBSERVATION_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_OBSERVATION_SETTING_TITLE";

        /// <summary>
        /// 詳細設定項目の画像補正タイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_IMAGE_REVISION_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_IMAGE_REVISION_SETTING_TITLE";

        /// <summary>
        /// 詳細設定項目の撮影タイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_PHOTOGRAPHY_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_PHOTOGRAPHY_SETTING_TITLE";

        /// <summary>
        /// 詳細設定項目の撮影-3D/全焦点タイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_PHOTOGRAPHY_THREE_D_FOCUSING_TITLE = "CAP_DETAIL_SETTING_LIST_PHOTOGRAPHY_THREE_D_FOCUSING_TITLE";

        /// <summary>
        /// 詳細設定項目のマップタイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_MAP_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_MAP_SETTING_TITLE";

        /// <summary>
        /// 詳細設定項目のステージタイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_STAGE_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_STAGE_SETTING_TITLE";

        /// <summary>
        /// 詳細設定画面のツリービューの"倍率"のラベル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_MAGNIFICATION_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_MAGNIFICATION_SETTING_TITLE";

        /// <summary>
        /// 詳細設定項目のその他タイトル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_LIST_OTHER_SETTING_TITLE = "CAP_DETAIL_SETTING_LIST_OTHER_SETTING_TITLE";

        #endregion 詳細設定項目

        #region 観察設定

        /// <summary>
        /// 観察設定Pageのタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_TITLE_NAME = "CAP_PAGE_ILLMINATION_SETTING_GROUP_TITLE_NAME";

        #region 照明設定

        /// <summary>
        /// 観察設定Pageの照明設定タイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP = "CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP";

        /// <summary>
        /// 観察設定Pageの照明設定の照射タイトル：明るさ（落射）
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_BRIGHTNESS_LIGHT_UP = "CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_BRIGHTNESS_LIGHT_UP";

        /// <summary>
        /// 観察設定Pageの照明設定の照射タイトル：明るさ（透過）
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_BRIGHTNESS_BACK_LIGHT = "CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_BRIGHTNESS_BACK_LIGHT";

        /// <summary>
        /// 観察設定Pageの照明設定の照明ON/OFFのトグルボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_LIGHT_ON_TOGGLEBUTTON_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_LIGHT_ON_TOGGLEBUTTON_LABEL";

        /// <summary>
        /// 観察設定Pageの照明設定の照射位置のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_ILLMINATION_POSITION_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_ILLMINATION_POSITION_LABEL";

        /// <summary>
        /// 観察設定Pageの照明設定の微分干渉プリズム調整のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_DIC_SETTING_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_ILLMINATION_SET_GROUP_DIC_SETTING_LABEL";

        #endregion 照明設定

        #region カメラ設定

        /// <summary>
        /// 観察設定Pageのカメラ設定グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_LABEL";

        /// <summary>
        /// 観察設定Pageのカメラ設定の露出時間のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_EXPOSURE_TIME_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_EXPOSURE_TIME_LABEL";

        /// <summary>
        /// 観察設定Pageのカメラ設定の自動露出のトグルボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_AUTO_EXPOSURE_TOGGLEBUTTON_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_AUTO_EXPOSURE_TOGGLEBUTTON_LABEL";

        /// <summary>
        /// 観察設定Pageのカメラ設定のISO感度設定のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_ISO_SENSITIVETY_LABEL = "CAP_PAGE_ILLMINATION_SETTING_GROUP_CAMERA_SETTING_GROUP_ISO_SENSITIVETY_LABEL";

        #endregion カメラ設定

        #endregion 観察設定

        #region 撮影設定

        /// <summary>
        /// 撮影の詳細設定のFramePageのタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_TITLE = "CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_TITLE";

        /// <summary>
        /// 撮影の詳細設定のFramePageの撮影設定タイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TITLE = "CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TITLE";

        /// <summary>
        /// 撮影の詳細設定のFramePageの撮影設定のスナップ撮影
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SNAP = "CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SNAP";

        /// <summary>
        /// 撮影の詳細設定のFramePageの撮影設定の簡易全焦点撮影
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SIMPLEOMNIFOCAL = "CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_SIMPLEOMNIFOCAL";

        /// <summary>
        /// 撮影の詳細設定のFramePageの撮影設定の３Ｄ撮影
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_3D = "CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_3D";

        /// <summary>
        /// 撮影の詳細設定のFramePageの撮影設定の動画
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_MOVIE = "CAP_PAGE_PHOTOGRAPHY_GROUP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_SETTING_TO_MOVIE";

        /// <summary>
        /// 撮影の詳細設定の撮影ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL = "CAP_PAGE_PHOTOGRAPHY_GROUP_TAKE_PHOTOGRAPH_LABEL";

        /// <summary>
        /// 撮影の詳細設定の中止ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL = "CAP_PAGE_PHOTOGRAPHY_GROUP_STOP_ACTION_LABEL";

        /// <summary>
        /// 撮影の詳細設定の完了ラベル（簡易全焦点の簡易モード）
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_COMPLETE_ACTION_LABEL = "CAP_PAGE_PHOTOGRAPHY_GROUP_COMPLETE_ACTION_LABEL";

        /// <summary>
        /// 撮影の詳細設定の録画開始ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_REC_START_LABEL = "CAP_PAGE_PHOTOGRAPHY_GROUP_REC_START_LABEL";

        /// <summary>
        /// 撮影の詳細設定の録画停止ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_PHOTOGRAPHY_GROUP_REC_STOP_LABEL = "CAP_PAGE_PHOTOGRAPHY_GROUP_REC_STOP_LABEL";

        /// <summary>
        /// 録画の状態表示の録画済み時間ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_STATUS_BAR_GROUT_RECOREDINGTIME_LABEL = "CAP_PAGE_STATUS_BAR_GROUT_RECOREDINGTIME_LABEL";

        /// <summary>
        /// 録画の状態表示のZ位置ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_STATUS_BAR_GROUT_Z_POSITION_NOW_LABEL = "CAP_PAGE_STATUS_BAR_GROUT_Z_POSITION_NOW_LABEL";

        /// <summary>
        /// 録画の状態表示の残存録画時間ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_STATUS_BAR_GROUT_REMAINING_TIME_LABEL = "CAP_PAGE_STATUS_BAR_GROUT_REMAINING_TIME_LABEL";

        /// <summary>
        /// 撮影の3D撮影設定のグループタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TITLE = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TITLE";

        /// <summary>
        /// 撮影の3D撮影設定の撮影モードのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_LABEL = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_LABEL";

        /// <summary>
        /// 撮影の3D撮影設定の撮影モード：逐次のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_FREE_PRECISE_LABEL = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_FREE_PRECISE_LABEL";

        /// <summary>
        /// 撮影の3D撮影設定の撮影モード：高精度のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGHLY_PRECISE_LABEL = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGHLY_PRECISE_LABEL";

        /// <summary>
        /// 撮影の3D撮影設定の撮影モードの高速ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGH_SPEED_LABEL = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_PHOTOGRAPHY_MODE_HIGH_SPEED_LABEL";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の範囲ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の範囲：広ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_WIDE = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_WIDE";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の範囲：標準ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NORMAL = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NORMAL";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の範囲：狭ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NARROW = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NARROW";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の範囲：手入力ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_MANUAL = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_MANUAL";
        
        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲のピッチラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_PITCH = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_PITCH";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲のステップ数ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NUM_STEP = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_NUM_STEP";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の終了位置ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_END_POS = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_END_POS";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の開始位置ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_TOP_POS = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_AREA_TAG_TOP_POS";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の上下限界ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_LIMIT = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_LIMIT";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の現在位置で設定ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CURRENT = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CURRENT";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の中央位置で設定ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CENTER = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_UP_LOW_TAG_CENTER";

        /// <summary>
        /// 撮影の3D撮影設定の撮影範囲の共通単位[μm]ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT = "CAP_PAGE_Photography_GROUT_3D_SETTING_GROUP_TARGET_AREA_GROUP_COMMON_UNIT";

        /// <summary>
        /// 詳細設定の撮影の範囲設定のラベル
        /// </summary>
        public static readonly System.String CAP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_RANGE_SETTING_LABEL = "CAP_DETAIL_SETTING_GROUP_PHOTOGRAPHY_RANGE_SETTING_LABEL";

        /// <summary>
        /// 撮影開始
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_START = "CAP_ACQUISITION_START";

        /// <summary>
        /// 撮影中止
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_STOP = "CAP_ACQUISITION_STOP";

        /// <summary>
        /// 撮影設定ﾍﾟｰｼﾞの撮影ﾓｰﾄﾞ選択用ComboBoxに登録するﾘｽﾄ1のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQSETTING_COMBOACQMODELIST1_TEXT = "CAP_ACQSETTING_COMBOACQMODELIST1_TEXT";

        /// <summary>
        /// 撮影設定ﾍﾟｰｼﾞの撮影ﾓｰﾄﾞ選択用ComboBoxに登録するﾘｽﾄ2のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQSETTING_COMBOACQMODELIST2_TEXT = "CAP_ACQSETTING_COMBOACQMODELIST2_TEXT";

        /// <summary>
        /// 撮影用設定ﾍﾟｰｼﾞのSnap撮影ﾓｰﾄﾞｷｬﾌﾟｼｮﾝ(OFF)
        /// </summary>
        public static readonly System.String CAP_ACQSETTING_RADIOSNAPMODEOFF_TEXT = "CAP_ACQSETTING_RADIOSNAPMODEOFF_TEXT";

        /// <summary>
        /// 撮影用設定ﾍﾟｰｼﾞのSnap撮影ﾓｰﾄﾞｷｬﾌﾟｼｮﾝ(HR)
        /// </summary>
        public static readonly System.String CAP_ACQSETTING_RADIOSNAPMODEHR_TEXT = "CAP_ACQSETTING_RADIOSNAPMODEHR_TEXT";

        /// <summary>
        /// 撮影用設定ﾍﾟｰｼﾞのSnap撮影ﾓｰﾄﾞｷｬﾌﾟｼｮﾝ(SuperHR)
        /// </summary>
        public static readonly System.String CAP_ACQSETTING_RADIOSNAPMODESUPERHR_TEXT = "CAP_ACQSETTING_RADIOSNAPMODESUPERHR_TEXT";

        /// <summary>
        /// 自動保存 有効/無効(ﾁｪｯｸﾎﾞｯｸｽ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVECHECK_TEXT = "CAP_ACQUISITION_AUTOSAVECHECK_TEXT";

        /// <summary>
        /// 自動保存 保存先(ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEPLACE_TEXT = "CAP_ACQUISITION_AUTOSAVEPLACE_TEXT";

        /// <summary>
        /// 自動保存 保存先(ﾌｧｲﾙﾗｼﾞｵﾎﾞﾀﾝ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEPLACEFILE_TEXT = "CAP_ACQUISITION_AUTOSAVEPLACEFILE_TEXT";

        /// <summary>
        /// 自動保存 保存先(DBﾗｼﾞｵﾎﾞﾀﾝ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEPLACEDB_TEXT = "CAP_ACQUISITION_AUTOSAVEPLACEDB_TEXT";

        /// <summary>
        /// 自動保存 保存先(ﾌｧｲﾙ＋DBﾗｼﾞｵﾎﾞﾀﾝ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEPLACEBOTH_TEXT = "CAP_ACQUISITION_AUTOSAVEPLACEBOTH_TEXT";

        /// <summary>
        /// 自動保存 ﾌｧｲﾙ設定(ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEFILESETTING_TEXT = "CAP_ACQUISITION_AUTOSAVEFILESETTING_TEXT";

        /// <summary>
        /// 自動保存 ﾌｫﾙﾀﾞ(ﾗﾍﾞﾙ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEFOLDERPATH_TEXT = "CAP_ACQUISITION_AUTOSAVEFOLDERPATH_TEXT";

        /// <summary>
        /// 自動保存 参照(ﾎﾞﾀﾝ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEREFER_TEXT = "CAP_ACQUISITION_AUTOSAVEREFER_TEXT";

        /// <summary>
        /// 自動保存 ﾌｧｲﾙ名(ﾗﾍﾞﾙ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEFILENAME_TEXT = "CAP_ACQUISITION_AUTOSAVEFILENAME_TEXT";

        /// <summary>
        /// 自動保存 ﾌｧｲﾙｶｳﾝﾀ(ﾗﾍﾞﾙ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEFILECOUNTER_TEXT = "CAP_ACQUISITION_AUTOSAVEFILECOUNTER_TEXT";

        /// <summary>
        /// 自動保存 ﾃﾞﾌｫﾙﾄﾌｧｲﾙ形式(ﾗﾍﾞﾙ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEDEFAULTFILETYPE_TEXT = "CAP_ACQUISITION_AUTOSAVEDEFAULTFILETYPE_TEXT";

        /// <summary>
        /// 自動保存 追加保存ﾌｧｲﾙ形式有効(ﾗﾍﾞﾙ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVEADDFILETYPECHECK_TEXT = "CAP_ACQUISITION_AUTOSAVEADDFILETYPECHECK_TEXT";

        /// <summary>
        /// 自動保存 ｺﾒﾝﾄ(ｸﾞﾙｰﾌﾟﾎﾞｯｸｽ)のｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_AUTOSAVECOMMENT_TEXT = "CAP_ACQUISITION_AUTOSAVECOMMENT_TEXT";

        /// <summary>
        /// 撮影設定の撮影モード：2D撮影
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_MODE_2D_LABEL = "CAP_ACQUISITION_MODE_2D_LABEL";

        /// <summary>
        /// 撮影設定の撮影モード：3D撮影
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_MODE_3D_LABEL = "CAP_ACQUISITION_MODE_3D_LABEL";

        /// <summary>
        /// 撮影設定の撮影モード：簡易全焦点撮影
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_MODE_ALF_LABEL = "CAP_ACQUISITION_MODE_ALF_LABEL";

        /// <summary>
        /// 撮影設定の撮影モード：動画
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_MODE_MOVIE_LABEL = "CAP_ACQUISITION_MODE_MOVIE_LABEL";

        /// <summary>
        /// GRR撮影用ダイアログの測定者ラベル
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_GRR_OPERATOR_LABEL_TEXT = "CAP_ACQUISITION_GRR_OPERATOR_LABEL_TEXT";

        /// <summary>
        /// GRR撮影用ダイアログのサンプルラベル
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_GRR_SAMPLE_LABEL_TEXT = "CAP_ACQUISITION_GRR_SAMPLE_LABEL_TEXT";

        /// <summary>
        /// GRR撮影用ダイアログの注意書きラベル
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_GRR_CAUTION_LABEL_TEXT = "CAP_ACQUISITION_GRR_CAUTION_LABEL_TEXT";

        /// <summary>
        /// GRR撮影用ダイアログのタイトルラベル
        /// </summary>
        public static readonly System.String CAP_ACQUISITION_GRR_ACQINFO_DIALOG_TEXT = "CAP_ACQUISITION_GRR_ACQINFO_DIALOG_TEXT";

        #endregion 撮影設定

        #region 画像補正

        /// <summary>
        /// 画像補正詳細のグループタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_DETAIL_SETTING_GROUP_TITLE = "CAP_PAGE_IMAGE_REVISION_DETAIL_SETTING_GROUP_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正グループタイトル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_TITLE = "CAP_PAGE_IMAGE_REVISION_GROUP_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正のHDRタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_HDR_TITLE = "CAP_PAGE_IMAGE_REVISION_GROUP_HDR_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正のContrastタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_CONTRAST_TITLE = "CAP_PAGE_IMAGE_REVISION_GROUP_CONTRAST_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正のAnti-Halationタイトルラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_TITLE = "CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正のAnti-Halationの標準処理のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_STANDARD_RADIO_BUTTON_TITLE = "CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_STANDARD_RADIO_BUTTON_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正のAnti-Halationの高速処理のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_HIGH_SPEED_RADIO_BUTTON_TITLE = "CAP_PAGE_IMAGE_REVISION_GROUP_ANTIHALATION_HIGH_SPEED_RADIO_BUTTON_TITLE";

        /// <summary>
        /// 画像補正詳細の画像補正の特定色強調グループのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_SPECIFIC_COLOR_GROUP_LABEL = "CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_SPECIFIC_COLOR_GROUP_LABEL";

        /// <summary>
        /// 画像補正詳細の画像補正の特定色強調の色幅のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_SPECIFIC_COLOR_GROUP_COLOR_WIDTH_LABEL = "CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_SPECIFIC_COLOR_GROUP_COLOR_WIDTH_LABEL";

        /// <summary>
        /// 画像補正パネルのFastHDRボタンのキャプション
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_FASTHDR_BUTTON_TEXT = "CAP_PAGE_IMAGE_REVISION_GROUP_FASTHDR_BUTTON_TEXT";

        /// <summary>
        /// 画像補正パネルのFineHDRボタンのキャプション
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_FINEHDR_BUTTON_TEXT = "CAP_PAGE_IMAGE_REVISION_GROUP_FINEHDR_BUTTON_TEXT";

        /// <summary>
        /// 画像補正パネルのHDRボタンのキャプション
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_HDR_BUTTON_TEXT = "CAP_PAGE_IMAGE_REVISION_GROUP_HDR_BUTTON_TEXT";

        /// <summary>
        /// 詳細設定の画像補正のHDR（テクスチャ強調）のTREEラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_TEXTURE_TREE_LABEL = "CAP_PAGE_IMAGE_REVISION_GROUP_EMPASIS_TEXTURE_TREE_LABEL";

        /// <summary>
        /// 詳細設定の画像補正のハレーション除去（標準）のTREEラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_STANDARD_HALATION_LABEL = "CAP_PAGE_IMAGE_REVISION_GROUP_STANDARD_HALATION_LABEL";

        /// <summary>
        /// 詳細設定の画像補正のハレーション除去（高速）のTREEラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_HIGH_SPEED_HALATION_LABEL = "CAP_PAGE_IMAGE_REVISION_GROUP_HIGH_SPEED_HALATION_LABEL";

        /// <summary>
        /// 特定色強調リストの未登録の文字列
        /// </summary>
        public static readonly System.String CAP_PAGE_IMAGE_REVISION_GROUP_SPECIFIC_COLOR_UNREGIST_NAME = "CAP_PAGE_IMAGE_REVISION_GROUP_SPECIFIC_COLOR_UNREGIST_NAME";
        #endregion 画像補正

        #region 露光設定

        /// <summary>
        /// 露光時間の表示単位[ms]
        /// </summary>
        public static readonly System.String CAP_EXPOSURE_SPEED_UNIT_MS = "CAP_EXPOSURE_SPEED_UNIT_MS";

        /// <summary>
        /// 露光時間の表示単位[s]
        /// </summary>
        public static readonly System.String CAP_EXPOSURE_SPEED_UNIT_S = "CAP_EXPOSURE_SPEED_UNIT_S";

        #endregion 露光設定

        #region キャリブレーション設定

        /// <summary>
        /// 実行タブのラベル表示：Execute
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIALOG_TAG_EXECUTE = "CAP_CALIBRATION_DIALOG_TAG_EXECUTE";

        /// <summary>
        /// 更新タブのラベル表示：Change
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIALOG_TAG_CHANGE = "CAP_CALIBRATION_DIALOG_TAG_CHANGE";

        /// <summary>
        /// 履歴タブのラベル表示：History
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIALOG_TAG_HISTORY = "CAP_CALIBRATION_DIALOG_TAG_HISTORY";

        /// <summary>
        /// Calibration Dialogのトップタイトル：Calibration Setting
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIALOG_TITLE_NAME = "CAP_CALIBRATION_DIALOG_TITLE_NAME";

        /// <summary>
        /// Calibration Dialogの履歴タイトル：Calibration History
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIALOG_HISTORY_NAME = "CAP_CALIBRATION_DIALOG_HISTORY_NAME";

        /// <summary>
        /// Calibration の　Current Revolver
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_CURRENT_REVOLVER_TITLE = "CAP_CALIBRATION_CHANGE_PAGE_CURRENT_REVOLVER_TITLE";

        /// <summary>
        /// Calibration の　Calibration Lens Setting List
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_CALIBRATION_LENS_SETTING_LIST = "CAP_CALIBRATION_CHANGE_PAGE_CALIBRATION_LENS_SETTING_LIST";

        /// <summary>
        /// Calibration RevolverのLens一覧のラベル：Lens Name
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_LENS_NAME_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_LENS_NAME_LABEL";

        /// <summary>
        /// Calibration RevolverのLens一覧のラベル：Default
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_LENS_DEFAULT_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_LENS_DEFAULT_LABEL";

        /// <summary>
        /// Calibration RevolverのLens一覧のラベル：User
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_LENS_USER_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_LENS_USER_LABEL";

        /// <summary>
        /// Calibration RevolverのLens一覧のラベル：maker
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_LENS_MAKER_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_LENS_MAKER_LABEL";

        /// <summary>
        /// Calibration Revolverのボタンのラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_ALL_DEFAULT_BUTTON = "CAP_CALIBRATION_CHANGE_PAGE_ALL_DEFAULT_BUTTON";

        /// <summary>
        /// Calibration Revolverのボタンのラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_ALL_USER_BUTTON = "CAP_CALIBRATION_CHANGE_PAGE_ALL_USER_BUTTON";

        /// <summary>
        /// Calibration Revolverのボタンのラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_ALL_MAKER_BUTTON = "CAP_CALIBRATION_CHANGE_PAGE_ALL_MAKER_BUTTON";

        /// <summary>
        /// Calibration Revolverのボタンのラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_APPLY_BUTTON = "CAP_CALIBRATION_CHANGE_PAGE_APPLY_BUTTON";

        /// <summary>
        /// Calibration Revolverのボタンのラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_CLOSE_BUTTON = "CAP_CALIBRATION_CHANGE_PAGE_CLOSE_BUTTON";
        
        /// <summary>
        /// Calibration Detailのレンズ名のラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_LENS_NAME_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_LENS_NAME_LABEL";

        /// <summary>
        /// Calibration Detailのレンズ倍率のラベル：
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_LENS_MAGNIFICATION_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_LENS_MAGNIFICATION_LABEL";

        /// <summary>
        /// Calibration Detailのグリッド表示の倍率ラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_MAGNIFICATION_COL_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_MAGNIFICATION_COL_LABEL";

        /// <summary>
        /// Calibration Detailのグリッド表示の現在X位置
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_X_COL_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_X_COL_LABEL";

        /// <summary>
        /// Calibration Detailのグリッド表示の現在Y位置
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_Y_COL_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_CURRENT_Y_COL_LABEL";

        /// <summary>
        /// Calibration Detailのグリッド表示の結果X位置
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_RESULT_X_COL_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_RESULT_X_COL_LABEL";

        /// <summary>
        /// Calibration Detailのグリッド表示の結果Y位置
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_DETAIL_PAGE_RESULT_Y_COL_LABEL = "CAP_CALIBRATION_CHANGE_DETAIL_PAGE_RESULT_Y_COL_LABEL";

        /// <summary>
        /// Calibration Historyのグリッド表示のRevolver列のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_REVOLVER_COL_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_REVOLVER_COL_LABEL";

        /// <summary>
        /// Calibration Historyのグリッド表示のLens名列のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_LENS_NAME_COL_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_LENS_NAME_COL_LABEL";

        /// <summary>
        /// Calibration Historyのグリッド表示のTarget列のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_TARGET_COL_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_TARGET_COL_LABEL";

        /// <summary>
        /// Calibration Historyのグリッド表示のSave名列のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_SAVE_NAME_COL_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_SAVE_NAME_COL_LABEL";

        /// <summary>
        /// Calibration Historyのグリッド表示の日付列のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_CHANGE_PAGE_DATE_COL_LABEL = "CAP_CALIBRATION_CHANGE_PAGE_DATE_COL_LABEL";

        /// <summary>
        /// Calibration MessageのRadio ButtonのMakerのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_MAKER_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_MAKER_LABEL";

        /// <summary>
        /// Calibration MessageのRadio ButtonのUserのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_USER_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_USER_LABEL";

        /// <summary>
        /// Calibration MessageのRadio ButtonのCheckのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_CHECK_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_CHECK_LABEL";

        /// <summary>
        /// Calibration MessageのRadio ButtonのUpdateのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_UPDATE_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_UPDATE_LABEL";

        /// <summary>
        /// Calibration MessageのSample Pitchのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_SAMPLE_PITCH_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_SAMPLE_PITCH_LABEL";

        /// <summary>
        /// Calibration MessageのPitch unitのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_UNIT_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_UNIT_LABEL";

        /// <summary>
        /// Calibration MessageのPitch警告のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_PITCH_NOTICE_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_PITCH_NOTICE_LABEL";

        /// <summary>
        /// Calibration MessageのXY軸のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_AXIS_XY_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_AXIS_XY_LABEL";

        /// <summary>
        /// Calibration MessageのX軸のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_AXIS_X_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_AXIS_X_LABEL";

        /// <summary>
        /// Calibration MessageのY軸のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_AXIS_Y_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_AXIS_Y_LABEL";

        /// <summary>
        /// Calibration MessageのNameのラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_NAME_LABEL = "CAP_CALIBRATION_MESSAGE_PAGE_NAME_LABEL";

        /// <summary>
        /// Calibration MessageのRetryのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_RETRY_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_RETRY_BUTTON";

        /// <summary>
        /// Calibration MessageのStopのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_STOP_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_STOP_BUTTON";

        /// <summary>
        /// Calibration MessageのNextのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_NEXT_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_NEXT_BUTTON";

        /// <summary>
        /// Calibration MessageのCancelのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_CANCEL_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_CANCEL_BUTTON";

        /// <summary>
        /// Calibration MessageのStartのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_START_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_START_BUTTON";

        /// <summary>
        /// Calibration MessageのMeasurementStartのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_MEASUREMENT_START_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_MEASUREMENT_START_BUTTON";

        /// <summary>
        /// Calibration MessageのContinueのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_CONTINUE_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_CONTINUE_BUTTON";

        /// <summary>
        /// Calibration MessageのSaveのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_SAVE_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_SAVE_BUTTON";

        /// <summary>
        /// Calibration MessageのEndのボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_END_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_END_BUTTON";

        /// <summary>
        /// Calibration MessageのLog参照のボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_MESSAGE_PAGE_REFER_LOG_BUTTON = "CAP_CALIBRATION_MESSAGE_PAGE_REFER_LOG_BUTTON";

        /// <summary>
        /// Calibration X方向最大誤差のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIFFERENCE_MAXIMUM_TARGET_X_LABEL = "CAP_CALIBRATION_DIFFERENCE_MAXIMUM_TARGET_X_LABEL";

        /// <summary>
        /// Calibration X方向最小誤差のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIFFERENCE_MINIMUM_TARGET_X_LABEL = "CAP_CALIBRATION_DIFFERENCE_MINIMUM_TARGET_X_LABEL";

        /// <summary>
        /// Calibration Y方向最大誤差のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIFFERENCE_MAXIMUM_TARGET_Y_LABEL = "CAP_CALIBRATION_DIFFERENCE_MAXIMUM_TARGET_Y_LABEL";

        /// <summary>
        /// Calibration Y方向最小誤差のラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_DIFFERENCE_MINIMUM_TARGET_Y_LABEL = "CAP_CALIBRATION_DIFFERENCE_MINIMUM_TARGET_Y_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定のボタンラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_MEASURE_MODE_BUTTON = "CAP_CALIBRATION_REPETITION_MEASURE_MODE_BUTTON";

        /// <summary>
        /// Calibration 繰り返し測定の３σタイトルラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_THREE_SIGMA_LABEL = "CAP_CALIBRATION_REPETITION_THREE_SIGMA_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定の最大誤差タイトルラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_DIFFERENCE_MAXIMUM_LABEL = "CAP_CALIBRATION_REPETITION_DIFFERENCE_MAXIMUM_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定の最小誤差タイトルラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_DIFFERENCE_MINIMUM_LABEL = "CAP_CALIBRATION_REPETITION_DIFFERENCE_MINIMUM_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定の結果タイトルラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_TITLE_LABEL = "CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_TITLE_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定の成功通知ラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_OK_LABEL = "CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_OK_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定の失敗通知ラベル
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_NG_LABEL = "CAP_CALIBRATION_REPETITION_MEASUREMENT_RESULT_NG_LABEL";

        /// <summary>
        /// Calibration 繰り返し測定回数の「n/21」の「/」
        /// </summary>
        public static readonly System.String CAP_CALIBRATION_REPETITION_FRACTION_SEPARATE_MARK_LABEL = "CAP_CALIBRATION_REPETITION_FRACTION_SEPARATE_MARK_LABEL";
        #endregion キャリブレーション設定

        #region TOOL関連

        /// <summary>
        /// 縦ToolBarの画像一覧ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_IMAGE_LIST_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_IMAGE_LIST_LABEL";

        /// <summary>
        /// 縦ToolBarの焦点ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_FOCUS_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_FOCUS_LABEL";

        /// <summary>
        /// 縦ToolBarのZ退避ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_Z_ESCAPE_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_Z_ESCAPE_LABEL";

        /// <summary>
        /// 縦ToolBarのZ近接限界未設定の警告ラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_Z_RELEASE_WARNING_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_Z_RELEASE_WARNING_LABEL";

        /// <summary>
        /// 縦ToolBarの現在Z位置のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_CURRENT_Z_POSITION_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_CURRENT_Z_POSITION_LABEL";

        /// <summary>
        /// 縦ToolBarの登録Z位置のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_REGISTERED_Z_POSITION_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_REGISTERED_Z_POSITION_LABEL";

        /// <summary>
        /// 縦ToolBarの近接限界位置のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_Z_LOWER_LIMIT_POSITION_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_Z_LOWER_LIMIT_POSITION_LABEL";

        /// <summary>
        /// 縦ToolBarの登録のラベル（領域が狭いので短い文字で定義）
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_Z_VALUES_BUTTON_REGISTRATION_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_Z_VALUES_BUTTON_REGISTRATION_LABEL";

        /// <summary>
        /// 縦ToolBarのZ退避量のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_Z_VALUES_Z_POSITION_MARGIN_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_Z_VALUES_Z_POSITION_MARGIN_LABEL";

        /// <summary>
        /// 縦ToolBarのズームのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_ZOOM_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_ZOOM_LABEL";

        /// <summary>
        /// 縦ToolBarの補助Menuのラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_SUPPORT_MENU_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_SUPPORT_MENU_LABEL";

        /// <summary>
        /// 縦ToolBarの長さ単位のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SETTING_TOOL_GROUP_UNIT_LABEL = "CAP_PAGE_SETTING_TOOL_GROUP_UNIT_LABEL";

        #endregion TOOL関連

        #region ﾌｫｰｶｽ設定
        /// <summary>
        /// 反射防止アダプタ着脱設定切替コントロールのコンテント
        /// </summary>
        public static readonly System.String CAP_FOCUS_REFRECTION_GARD_ADAPTER_SWITCH_CONTENT = "CAP_FOCUS_REFRECTION_GARD_ADAPTER_SWITCH_CONTENT";

        /// <summary>
        /// 反射防止アダプタ着脱設定(アダプタあり)の観察条件保存/再現画面のコンテント
        /// </summary>
        public static readonly System.String CAP_FOCUS_ADAPTER_ATTACHED_RADIOBUTTON_CONTENT = "CAP_FOCUS_ADAPTER_ATTACHED_RADIOBUTTON_CONTENT";

        /// <summary>
        /// 反射防止アダプタ着脱設定(アダプタなし)の観察条件保存/再現画面のコンテント
        /// </summary>
        public static readonly System.String CAP_FOCUS_ADAPTER_NOT_ATTACHED_RADIOBUTTON_CONTENT = "CAP_FOCUS_ADAPTER_NOT_ATTACHED_RADIOBUTTON_CONTENT";

        /// <summary>
        /// Z連続移動速度設定の項目ラベルのコンテント
        /// </summary>
        public static readonly System.String CAP_FOCUS_CONTINUOUS_MOVE_SPEED_LABEL_CONTENT = "CAP_FOCUS_CONTINUOUS_MOVE_SPEED_LABEL_CONTENT";

        /// <summary>
        /// Z連続移動速度設定の低速ラベルのコンテント 
        /// </summary>
        public static readonly System.String CAP_FOCUS_CONTINUOUS_MOVE_SPEED_LOW_LABEL_CONTENT = "CAP_FOCUS_CONTINUOUS_MOVE_SPEED_LOW_LABEL_CONTENT";

        /// <summary>
        /// Z連続移動速度設定の中速ラベルのコンテント 
        /// </summary>
        public static readonly System.String CAP_FOCUS_CONTINUOUS_MOVE_SPPED_MIDDLE_LABEL_CONTENT = "CAP_FOCUS_CONTINUOUS_MOVE_SPPED_MIDDLE_LABEL_CONTENT";

        /// <summary>
        /// Z連続移動速度設定の高速ラベルのコンテント 
        /// </summary>
        public static readonly System.String CAP_FOCUS_CONTINUOUS_MOVE_SPEED_HIGH_LABEL_CONTENT = "CAP_FOCUS_CONTINUOUS_MOVE_SPEED_HIGH_LABEL_CONTENT";

        /// <summary>
        /// Z連続移動速度設定のシフトアップラベルのコンテント 
        /// </summary>
        public static readonly System.String CAP_FOCUS_CONTINUOUS_MOVE_SPPED_DIRECTION_SHIFTUP_LABEL_CONTENT = "CAP_FOCUS_CONTINUOUS_MOVE_SPPED_DIRECTION_SHIFTUP_LABEL_CONTENT";

        /// <summary>
        /// Z連続移動速度設定のシフトダウンラベルのコンテント 
        /// </summary>
        public static readonly System.String CAP_FOCUS_CONTINUOUS_MOVE_SPEED_DIRECTION_SHIFTDOWN_LABEL_CONTENT = "CAP_FOCUS_CONTINUOUS_MOVE_SPEED_DIRECTION_SHIFTDOWN_LABEL_CONTENT";
        #endregion ﾌｫｰｶｽ設定

        #region 倍率設定
        /// <summary>
        /// 対物ﾚﾝｽﾞ登録ﾀﾞｲｱﾛｸﾞのﾀﾞｲｱﾛｸﾞｷｬﾌﾟｼｮﾝ
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_DIALOG_TEXT = "CAP_MAGNIFICATION_DIALOG_TEXT";

        /// <summary>
        /// 対物ﾚﾝｽﾞ登録ﾀﾞｲｱﾛｸﾞのｺﾝﾎﾞﾎﾞｯｸｽ内の表示文字列(未登録/登録解除)
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_COMBO_UNREGISTRATION_TEXT = "CAP_MAGNIFICATION_COMBO_UNREGISTRATION_TEXT";

        /// <summary>
        /// 対物ﾚﾝｽﾞ登録ﾀﾞｲｱﾛｸﾞのﾗﾍﾞﾙの表示文字列
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_LABEL_REVOLVER1_TEXT = "CAP_MAGNIFICATION_LABEL_REVOLVER1_TEXT";

        /// <summary>
        /// 対物ﾚﾝｽﾞ登録ﾀﾞｲｱﾛｸﾞのﾗﾍﾞﾙの表示文字列
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_LABEL_REVOLVER2_TEXT = "CAP_MAGNIFICATION_LABEL_REVOLVER2_TEXT";

        /// <summary>
        /// 対物ﾚﾝｽﾞ登録ﾀﾞｲｱﾛｸﾞのﾗﾍﾞﾙの表示文字列
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_LABEL_CURRENT_TEXT = "CAP_MAGNIFICATION_LABEL_CURRENT_TEXT";

        /// <summary>
        /// 対物ﾚﾝｽﾞ登録ﾀﾞｲｱﾛｸﾞのﾗﾍﾞﾙの表示文字列
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_LABEL_CENTER_TEXT = "CAP_MAGNIFICATION_LABEL_CENTER_TEXT";

        /// <summary>
        /// 対物ﾚﾝｽﾞ確認ﾀﾞｲｱﾛｸﾞのﾀｲﾄﾙﾗﾍﾞﾙの表示文字列
        /// </summary>
        public static readonly System.String CAP_OBJECTIVELENS_CONFIRM_DIALOG_TITLE = "CAP_OBJECTIVELENS_CONFIRM_DIALOG_TITLE";

        /// <summary>
        /// 対物レンズ情報ToolTipの動作距離の表示文字列
        /// </summary>
        public static readonly System.String CAP_OBJECTIVELENS__TOOLTIP_WD = "CAP_OBJECTIVELENS__TOOLTIP_WD";

        /// <summary>
        /// 対物レンズ情報ToolTipの動作距離の単位表示の表示文字列
        /// </summary>
        public static readonly System.String CAP_OBJECTIVELENS_TOOLTIP_WD_UNIT_MM = "CAP_OBJECTIVELENS_TOOLTIP_WD_UNIT_MM";

        /// <summary>
        /// 対物レンズ情報ToolTipの開口数の表示文字列
        /// </summary>
        public static readonly System.String CAP_OBJECTIVELENS_TOOLTIP_NA = "CAP_OBJECTIVELENS_TOOLTIP_NA";

        /// <summary>
        /// ROIズーム不可のラベル
        /// </summary>
        public static readonly System.String CAP_MAGNIFICATION_LABEL_CAN_NOT_ROI_ZOOM_TEXT = "CAP_MAGNIFICATION_LABEL_CAN_NOT_ROI_ZOOM_TEXT";

        #endregion 倍率設定

        #region ｽﾃｰｼﾞ設定

        /// <summary>
        /// ステージ設定ダイアログのタイトル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_NAME = "CAP_STAGE_SETTING_GROUP_NAME";

        /// <summary>
        /// ステージ設定ダイアログのTAB1タイトル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_TAB1_NAME = "CAP_STAGE_SETTING_GROUP_TAB1_NAME";

        /// <summary>
        /// ステージ設定ダイアログのTAB2タイトル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_TAB2_NAME = "CAP_STAGE_SETTING_GROUP_TAB2_NAME";

        /// <summary>
        /// ステージ設定ダイアログのTAB3タイトル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_TAB3_NAME = "CAP_STAGE_SETTING_GROUP_TAB3_NAME";

        /// <summary>
        /// ステージ設定のダイアログのCloseボタン表示プロパティ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CLOSE_BUTTON_NAME = "CAP_STAGE_SETTING_GROUP_CLOSE_BUTTON_NAME";

        /// <summary>
        /// ステージ設定のダイアログのONボタン表示プロパティ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_ON_BUTTON_NAME = "CAP_STAGE_SETTING_GROUP_ON_BUTTON_NAME";

        /// <summary>
        /// ステージ設定のダイアログのOFFボタン表示プロパティ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_OFF_BUTTON_NAME = "CAP_STAGE_SETTING_GROUP_OFF_BUTTON_NAME";

        /// <summary>
        /// ステージ設定のダイアログの2点の基準軸と1点の垂線軸のラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CROSS_LINE_2POINT_AND_1POINT_LABEL = "CAP_STAGE_SETTING_GROUP_CROSS_LINE_2POINT_AND_1POINT_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの基準位置を指定のラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_REFERENCE_POSITION_LABEL = "CAP_STAGE_SETTING_GROUP_REFERENCE_POSITION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのX軸のラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_X_AXIS_LABEL = "CAP_STAGE_SETTING_GROUP_X_AXIS_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのY軸のラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_Y_AXIS_LABEL = "CAP_STAGE_SETTING_GROUP_Y_AXIS_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの座標を指定ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_POINT_XY_LABEL = "CAP_STAGE_SETTING_GROUP_POINT_XY_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのX1ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_ALIGNMENT_X1_LABEL = "CAP_STAGE_SETTING_GROUP_ALIGNMENT_X1_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのX2ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_ALIGNMENT_X2_LABEL = "CAP_STAGE_SETTING_GROUP_ALIGNMENT_X2_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのY1ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_ALIGNMENT_Y1_LABEL = "CAP_STAGE_SETTING_GROUP_ALIGNMENT_Y1_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのY2ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_ALIGNMENT_Y2_LABEL = "CAP_STAGE_SETTING_GROUP_ALIGNMENT_Y2_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの番号ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_NUMBER_INDEX_LABEL = "CAP_STAGE_SETTING_GROUP_NUMBER_INDEX_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのX座標ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_X_POSITION_LABEL = "CAP_STAGE_SETTING_GROUP_X_POSITION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのY座標ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_Y_POSITION_LABEL = "CAP_STAGE_SETTING_GROUP_Y_POSITION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのX位置ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CURRENT_X_LABEL = "CAP_STAGE_SETTING_GROUP_CURRENT_X_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのY位置ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CURRENT_Y_LABEL = "CAP_STAGE_SETTING_GROUP_CURRENT_Y_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの位置表示単位ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CURRENT_UNIT_LABEL = "CAP_STAGE_SETTING_GROUP_CURRENT_UNIT_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの現在位置ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CURRENT_POSITION_LABEL = "CAP_STAGE_SETTING_GROUP_CURRENT_POSITION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの移動ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_CHANGE_POSITION_LABEL = "CAP_STAGE_SETTING_GROUP_CHANGE_POSITION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの格子登録ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_GRID_REGISTRATION_LABEL = "CAP_STAGE_SETTING_GROUP_GRID_REGISTRATION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの基準位置ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_SELECT_BASE_POINT_LABEL = "CAP_STAGE_SETTING_GROUP_SELECT_BASE_POINT_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの行列ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_MATRIX_POINT_LABEL = "CAP_STAGE_SETTING_GROUP_MATRIX_POINT_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのピッチラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_PITCH_STEP_LABEL = "CAP_STAGE_SETTING_GROUP_PITCH_STEP_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの登録ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_REGISTRATION_BUTTON_LABEL = "CAP_STAGE_SETTING_GROUP_REGISTRATION_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの削除ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_DELETE_BUTTON_LABEL = "CAP_STAGE_SETTING_GROUP_DELETE_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの全削除ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_ALL_DELETE_BUTTON_LABEL = "CAP_STAGE_SETTING_GROUP_ALL_DELETE_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの「No.」ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_GROUP_NUMBER_LABEL = "CAP_STAGE_SETTING_GROUP_NUMBER_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの「移動時に対物レンズを退避する」ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_Z_ESCAPE_AT_MOVEMENT_LABEL = "CAP_STAGE_SETTING_Z_ESCAPE_AT_MOVEMENT_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの「Z退避量」ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_Z_ESCAPE_DISTANCE_LABEL = "CAP_STAGE_SETTING_Z_ESCAPE_DISTANCE_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの「登録点ごとにAFを実行する」ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_AF_EACH_POINT_LABEL = "CAP_STAGE_SETTING_AF_EACH_POINT_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの「撮影後に測定を実行する」ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_MEASURE_AFTER_IMAGING_LABEL = "CAP_STAGE_SETTING_MEASURE_AFTER_IMAGING_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの選択ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_SELECT_WIZARD_LABEL = "CAP_STAGE_SETTING_SELECT_WIZARD_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの選択ウィザード説明ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_SELECT_WIZARD_EXPLAIN_LABEL = "CAP_STAGE_SETTING_SELECT_WIZARD_EXPLAIN_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの自動保存チェックボックスラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_AUTO_SAVE_CHKBOX_LABEL = "CAP_STAGE_SETTING_DIALOG_AUTO_SAVE_CHKBOX_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの保存先選択ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_SELECT_SAVE_TO_LABEL = "CAP_STAGE_SETTING_DIALOG_SELECT_SAVE_TO_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの「メイン画面の撮影条件で撮影します」ラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_IMAGING_CONDITION_LABEL = "CAP_STAGE_SETTING_DIALOG_IMAGING_CONDITION_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの撮影ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_IMAGING_BUTTON_LABEL = "CAP_STAGE_SETTING_DIALOG_IMAGING_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの中止ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_STOP_BUTTON_LABEL = "CAP_STAGE_SETTING_DIALOG_STOP_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの録画開始ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_REC_START_BUTTON_LABEL = "CAP_STAGE_SETTING_DIALOG_REC_START_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログの録画停止ボタンラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_REC_STOP_BUTTON_LABEL = "CAP_STAGE_SETTING_DIALOG_REC_STOP_BUTTON_LABEL";

        /// <summary>
        /// ステージ設定のダイアログのMovieラベル
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_DIALOG_MOVIE_LABEL = "CAP_STAGE_SETTING_DIALOG_MOVIE_LABEL";

        /// <summary>
        /// ステージ設定の移動撮影進捗状況表示ラベル（失敗座標あり時）
        /// </summary>
        public static readonly String CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS_FAILED_LABEL = "CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS_FAILED_LABEL";

        /// <summary>
        /// ステージ設定の移動撮影進捗状況表示ラベル
        /// </summary>
        public static readonly String CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS_LABEL = "CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS_LABEL";

        /// <summary>
        /// ステージ設定の移動撮影進捗状況表示ラベル（撮影完了しました。）
        /// </summary>
        public static readonly String CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS_END = "CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS_END";

        /// <summary>
        /// ステージ設定の移動撮影進捗状況表示ラベル（撮影中です。）
        /// </summary>
        public static readonly String CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS = "CAP_STAGE_SETTING_DIALOG_MOVING_ACQUISITION_PROGRESS";

        /// <summary>
        /// 座標ﾌｧｲﾙ保存ﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_COORDINATES_FILE_SAVE_DIALOG_TITLE = "CAP_STAGE_SETTING_COORDINATES_FILE_SAVE_DIALOG_TITLE";

        /// <summary>
        /// 座標ﾌｧｲﾙ読込みﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_COORDINATES_FILE_OPEN_DIALOG_TITLE = "CAP_STAGE_SETTING_COORDINATES_FILE_OPEN_DIALOG_TITLE";
        
        /// <summary>
        /// ｱﾗｲﾒﾝﾄﾌｧｲﾙ保存ﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_ALIGNMENT_FILE_SAVE_DIALOG_TITLE = "CAP_STAGE_SETTING_ALIGNMENT_FILE_SAVE_DIALOG_TITLE";

        /// <summary>
        /// ｱﾗｲﾒﾝﾄﾌｧｲﾙ読込みﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_ALIGNMENT_FILE_OPEN_DIALOG_TITLE = "CAP_STAGE_SETTING_ALIGNMENT_FILE_OPEN_DIALOG_TITLE";

        /// <summary>
        /// ｱﾗｲﾒﾝﾄ解除許可ﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ
        /// </summary>
        public static readonly System.String CAP_STAGE_SETTING_ALIGNMENT_DISABLE_DIALOG_TITLE = "CAP_STAGE_SETTING_ALIGNMENT_DISABLE_DIALOG_TITLE";
     
        #endregion ｽﾃｰｼﾞ設定

        #region ライブカラー

        /// <summary>
        /// LiveColorダイアログタイトル
        /// </summary>
        public static readonly System.String CAP_LIVE_COLOR_DIALOG_TITLE = "CAP_LIVE_COLOR_DIALOG_TITLE";

        /// <summary>
        /// LiveColorの登録名ラベル：Regist Name
        /// </summary>
        public static readonly System.String CAP_LIVE_COLOR_DIALOG_LABEL_REGIST = "CAP_LIVE_COLOR_DIALOG_LABEL_REGIST";

        /// <summary>
        /// LiveColorダイアログの登録ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_REGISTRATION = "CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_REGISTRATION";

        /// <summary>
        /// LiveColorダイアログの更新ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_UPDATE = "CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_UPDATE";

        /// <summary>
        /// LiveColorダイアログの削除ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_DELETE = "CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_DELETE";

        /// <summary>
        /// LiveColorダイアログのクローズボタンのラベル
        /// </summary>
        public static readonly System.String CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_CLOSE = "CAP_LIVE_COLOR_DIALOG_BUTTON_LABEL_CLOSE";

        #endregion ライブカラー

        #region スリープ

        /// <summary>
        /// Sleep中のダイアログのタイトル：Sleeping　・休止中
        /// </summary>
        public static readonly System.String CAP_SLEEP_DIALOG_LABEL_TITLE_NAME = "CAP_SLEEP_DIALOG_LABEL_TITLE_NAME";

        /// <summary>
        /// Sleepダイアログのスリープ解除ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_SLEEP_DIALOG_BUTTON_LABEL_RELEASE = "CAP_SLEEP_DIALOG_BUTTON_LABEL_RELEASE";

        #endregion スリープ

        #region 検鏡法設定
        /// <summary>
        /// 検鏡法切替部のタイトルキャプション
        /// </summary>
        public static readonly System.String CAP_MICROSCOPY_LABEL_TITLE = "CAP_MICROSCOPY_LABEL_TITLE";

        /// <summary>
        /// ユーセントリック位置移動制御部のタイトルキャプション
        /// </summary>
        public static readonly System.String CAP_EUCENTRIC_LABEL_TITLE = "CAP_EUCENTRIC_LABEL_TITLE";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面の原点のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_BASEPOINT_MOVE_LABEL = "CAP_PAGE_SPECULUM_GROUP_BASEPOINT_MOVE_LABEL";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面のEU（ECUCENTRIC_MOVE）のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_ECUCENTRIC_MOVE_LABEL = "CAP_PAGE_SPECULUM_GROUP_ECUCENTRIC_MOVE_LABEL";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面のBF（BrightField:明視）のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_BRIGHT_FIELD_LABEL = "CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_BRIGHT_FIELD_LABEL";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面のDF（DarkField:暗視）のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_DARK_FIELD_LABEL = "CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_DARK_FIELD_LABEL";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面のMIX（BFとDFの混合）のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_MIXED_BF_DF_LABEL = "CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_MIXED_BF_DF_LABEL";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面のDIC（微分干渉）のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_DIC_LABEL = "CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_DIC_LABEL";

        /// <summary>
        /// Speculum Pageでの検鏡法選択画面のPO（POLARIZE:偏光）のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_POLARIZE_LABEL = "CAP_PAGE_SPECULUM_GROUP_MICROSCOPY_POLARIZE_LABEL";

        /// <summary>
        /// Speculum Pageでの基準Z軸位置のラベル
        /// </summary>
        public static readonly System.String CAP_PAGE_SPECULUM_GROUP_REFERENCE_Z_POSITION_LABEL = "CAP_PAGE_SPECULUM_GROUP_REFERENCE_Z_POSITION_LABEL";

        #endregion 検鏡法設定

        #region プレビュー
        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ撮影画面ｳｨﾝﾄﾞｳのﾍｯﾀﾞﾀｲﾄﾙ(=PREVIEW)
        /// </summary>
        public static readonly System.String CAP_PREVIEW_WINDOW_ACQUISITION_HEADER_TEXT = "CAP_PREVIEW_WINDOW_ACQUISITION_HEADER_TEXT";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾕｰｻﾞｰ登録ｳｨﾝﾄﾞｳのﾍｯﾀﾞﾀｲﾄﾙ(=PREVIEW USER SETTING)
        /// </summary>
        public static readonly System.String CAP_PREVIEW_WINDOW_USERSETTING_HEADER_TEXT = "CAP_PREVIEW_WINDOW_USERSETTING_HEADER_TEXT";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾕｰｻﾞｰ設定ﾌｧｲﾙｵｰﾌﾟﾝﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ(=Open user preview file)
        /// </summary>
        public static readonly System.String CAP_PREVIEW_DIALOG_USERFILE_OPEN_HEADER_TEXT = "CAP_PREVIEW_DIALOG_USERFILE_OPEN_HEADER_TEXT";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾕｰｻﾞｰ設定ﾌｧｲﾙ保存ﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ(=Save user preview file)
        /// </summary>
        public static readonly System.String CAP_PREVIEW_DIALOG_USERFILE_SAVE_HEADER_TEXT = "CAP_PREVIEW_DIALOG_USERFILE_SAVE_HEADER_TEXT";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾒｰｶｰ提供ﾌｧｲﾙｵｰﾌﾟﾝﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ(=Open maker preview file)
        /// </summary>
        public static readonly System.String CAP_PREVIEW_DIALOG_MAKERFILE_OPEN_HEADER_TEXT = "CAP_PREVIEW_DIALOG_MAKERFILE_OPEN_HEADER_TEXT";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾕｰｻﾞｰ設定ﾎﾞﾀﾝ割付けなし時の表示ﾃｷｽﾄ(= - NON -)
        /// </summary>
        public static readonly System.String CAP_PREVIEW_LABEL_REGISTERED_SHORTCUT_NON_TEXT = "CAP_PREVIEW_LABEL_REGISTERED_SHORTCUT_NON_TEXT";

        /// <summary>
        /// プレビュー画面でのImageタグのラベル
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_IMAGE_TAG_TITLE_NAME = "CAP_PREVIEW_PAGE_IMAGE_TAG_TITLE_NAME";

        /// <summary>
        /// プレビュー画面でのObservationタグのラベル
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_CONDITION_TAG_TITLE_NAME = "CAP_PREVIEW_PAGE_OBSERVATION_CONDITION_TAG_TITLE_NAME";

        /// <summary>
        /// プレビュー画面でのPreview patternタグのラベル
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_TITLE_NAME = "CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_TITLE_NAME";

        /// <summary>
        /// プレビュー画面でのPreview patternタグのDefectボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_DEFECT_BUTTON = "CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_DEFECT_BUTTON";

        /// <summary>
        /// プレビュー画面でのPreview patternタグのFlatボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_FLAT_BUTTON = "CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_FLAT_BUTTON";

        /// <summary>
        /// プレビュー画面でのPreview patternタグのSubstrateボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_SUBSTRATE_BUTTON = "CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_SUBSTRATE_BUTTON";

        /// <summary>
        /// プレビュー画面でのPreview patternタグのContaminationボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_CONTAMINATION_BUTTON = "CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_CONTAMINATION_BUTTON";

        /// <summary>
        /// プレビュー画面でのPreview patternタグの凸凹ボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_IRREGULARITY_BUTTON = "CAP_PREVIEW_PAGE_PREVIEW_PATTERN_TAG_IRREGULARITY_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのラベル
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_TITLE_NAME = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_TITLE_NAME";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのBrightnessボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_BRIGHTNESS_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_BRIGHTNESS_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのLightingボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_LIGHTING_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_LIGHTING_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのIMEGEボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_IMAGE_ENH_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_IMAGE_ENH_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのWDRボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_WDR_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_WDR_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのShearingボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_SHEARING_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_SHEARING_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのUSER-1ボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER1_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER1_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのUSER-2ボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER2_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER2_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのUSER-3ボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER3_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER3_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグのUSER-OTHERボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_OTHER_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_OTHER_BUTTON";

        /// <summary>
        /// プレビュー画面でのObservation設定タグの新規設定ボタン
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_CREATE_SET_BUTTON = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_CREATE_SET_BUTTON";

        #region 現在のプレビュー条件

        //// _LABEL_0のような最後の0は、代入変数のインデックスを示します。 ////

        /// <summary>
        /// 現在のプレビュー条件表示のMicroscopy
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_MICROSCOPY_LABEL_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_MICROSCOPY_LABEL_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のSWITCH設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_SWITCH_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_SWITCH_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のBRIGHTNESS設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_BRIGHTNESS_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_BRIGHTNESS_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のPATTERN設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_PATTERN_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_PATTERN_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のROTATE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_ROTATE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_ROTATE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のSTATE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_STATE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_STATE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のDIC-Retardation設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_RETARDATION_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_RETARDATION_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のTEXTURE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_TEXTURE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_TEXTURE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のCONTRAST設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_CONTRAST_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_CONTRAST_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のCHROME設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_CHROME_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_CHROME_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のASYMMETRY設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_ASYMMETRY_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_ASYMMETRY_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のSATURATION設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_SATURATION_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_SATURATION_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のSTRENGTH設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_STRENGTH_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_STRENGTH_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のNOISE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_NOISE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_NOISE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のMODE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_MODE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_MODE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のAE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_AE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_AE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のAE Target設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_AE_TARGET_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_AE_TARGET_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のSPEED設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_SPEED_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_LABEL_SPEED_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のISO感度設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_ISO_SENSITIVITY_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_ISO_SENSITIVITY_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のRED設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_RED_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_RED_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のGREEN設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_GREEN_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_GREEN_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目のBLUE設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_BLUE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_BLUE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目の Gamma correction設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_GAMMA_VALUE_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_GAMMA_VALUE_0";

        /// <summary>
        /// 現在のプレビュー条件表示の設定項目の Edge enhancement設定
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_EDGE_LEVEL_0 = "CAP_PREVIEW_CURRENT_SETTING_PAGE_ITEM_EDGE_LEVEL_0";
        
        /// <summary>
        /// 現在のプレビュー条件表示のLED Annular（輪帯照明）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_ANNULAR_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_ANNULAR_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のLED Homocentric（同軸照明）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_HOMOCENTRIC_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_HOMOCENTRIC_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のLED Fiber（ファイバ照明）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_FIBER_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_FIBER_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のLED Ring（前）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_F_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_F_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のLED Ring（左）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_L_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_L_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のLED Ring（右）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_R_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_R_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のLED Ring（後）
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_B_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_LED_RING_B_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のUNIT AS
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_UNIT_AS_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_UNIT_AS_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のUNIT AN/PO
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_UNIT_AN_PO_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_UNIT_AN_PO_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のUNIT DIC
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_UNIT_DIC_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_UNIT_DIC_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE HDR[Texture] 
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_HDR_TEXTURE_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_HDR_TEXTURE_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE Fast HDR[Texture] 
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFAST_TEXTURE_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFAST_TEXTURE_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE Fine HDR[Texture] 
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFINE_TEXTURE_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFINE_TEXTURE_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE HDR[Halation]
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_HDR_HALATION_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_HDR_HALATION_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE Fast HDR[Halation]
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFAST_HALATION_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFAST_HALATION_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE Fine HDR[Halation]
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFINE_HALATION_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_HDRFINE_HALATION_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE Apical
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_APICAL_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_APICAL_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のIMAGE Contrast
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_CONTRAST_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_CONTRAST_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のCAMERA Exposure 
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_EXPOSURE_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_EXPOSURE_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のCAMERA ISO
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_ISO_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_ISO_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のCAMERA White Balance
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_WHITE_BALANCE_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_WHITE_BALANCE_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のCAMERA Gamma correction
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_GAMMA_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_GAMMA_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示のCAMERA Edge enhancement
        /// </summary>
        public static readonly System.String CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_EDGE_LABEL = "CAP_PREVIEW_CURRENT_SETTING_PAGE_CAMERA_EDGE_LABEL";

        /// <summary>
        /// 現在のプレビュー条件表示の設定：User Pattern
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER_PATTERN = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_USER_PATTERN";

        /// <summary>
        /// 現在のプレビュー条件表示の設定：Bumpiness
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_BUMPINESS = "CAP_PREVIEW_PAGE_OBSERVATION_SETTING_TAG_BUMPINESS";

        /// <summary>
        /// プレビュー画像サムネイル画像の前回画像ラベル：Previous image
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_THUMBNAIL_VIEW_PREVIOUS_IMAGE = "CAP_PREVIEW_PAGE_THUMBNAIL_VIEW_PREVIOUS_IMAGE";

        /// <summary>
        /// プレビュー画像サムネイル画像のInvalid Microscopyラベル
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_THUMBNAIL_VIEW_INVALID_MICROSCOPY = "CAP_PREVIEW_PAGE_THUMBNAIL_VIEW_INVALID_MICROSCOPY";

        /// <summary>
        /// プレビュー画像サムネイル画像のInvalid Conditionラベル
        /// </summary>
        public static readonly System.String CAP_PREVIEW_PAGE_THUMBNAIL_VIEW_INVALID_CONDITION = "CAP_PREVIEW_PAGE_THUMBNAIL_VIEW_INVALID_CONDITION";

        #endregion 現在のプレビュー条件

        #endregion プレビュー

        #region メーカープレビュー

        /// <summary>
        /// Dialog Title on Preview Maker Pattern List
        /// </summary>
        public static readonly System.String CAP_MAKER_PREVIEW_DIALOG_TITLE_NAME = "CAP_MAKER_PREVIEW_DIALOG_TITLE_NAME";

        /// <summary>
        /// Preview Maker Pattern ListでのListBoxの選択肢:DEFECT
        /// </summary>
        public static readonly System.String CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_DEFECT = "CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_DEFECT";

        /// <summary>
        /// Preview Maker Pattern ListでのListBoxの選択肢:FLAT 
        /// </summary>
        public static readonly System.String CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_FLAT = "CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_FLAT";

        /// <summary>
        /// Preview Maker Pattern ListでのListBoxの選択肢:CONTAMINATION
        /// </summary>
        public static readonly System.String CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_CONTAMINATION = "CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_CONTAMINATION";

        /// <summary>
        /// Preview Maker Pattern ListでのListBoxの選択肢:BUMPINESS
        /// </summary>
        public static readonly System.String CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_BUMPINESS = "CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_BUMPINESS";

        /// <summary>
        /// Preview Maker Pattern ListでのListBoxの選択肢:SUBSTRATE
        /// </summary>
        public static readonly System.String CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_SUBSTRATE = "CAP_MAKER_PREVIEW_DIALOG_LIST_BOX_SUBSTRATE";

        #endregion メーカープレビュー

        #region ユーザープレビュー

        /// <summary>
        /// User Preview Fileボタンラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_FILE_BUTTON = "CAP_USER_PREVIEW_FILE_BUTTON";

        /// <summary>
        /// User Preview Makerボタンラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_MAKER_BUTTON = "CAP_USER_PREVIEW_MAKER_BUTTON";

        /// <summary>
        /// User Preview Saveボタンラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_SAVE_BUTTON = "CAP_USER_PREVIEW_SAVE_BUTTON";

        /// <summary>
        /// User Preview Backボタンラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_BACK_BUTTON = "CAP_USER_PREVIEW_BACK_BUTTON";

        /// <summary>
        /// User Preview FileOpenボタンラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_FILEOPEN_BUTTON = "CAP_USER_PREVIEW_FILEOPEN_BUTTON";

        /// <summary>
        /// User Preview Deleteボタンラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_DELETE_BUTTON = "CAP_USER_PREVIEW_DELETE_BUTTON";

        /// <summary>
        /// User Preview FileNameラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_FILENAME_LABEL = "CAP_USER_PREVIEW_FILENAME_LABEL";

        /// <summary>
        /// User Preview Registerチェックボックスラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_REGISTER_CHECKBOX = "CAP_USER_PREVIEW_REGISTER_CHECKBOX";

        /// <summary>
        /// User Preview UserList Nonラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_USERLIST_NON_LABEL = "CAP_USER_PREVIEW_USERLIST_NON_LABEL";

        /// <summary>
        /// User Preview UserList User1ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_USERLIST_USER1_LABEL = "CAP_USER_PREVIEW_USERLIST_USER1_LABEL";

        /// <summary>
        /// User Preview UserList User2ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_USERLIST_USER2_LABEL = "CAP_USER_PREVIEW_USERLIST_USER2_LABEL";

        /// <summary>
        /// User Preview UserList User3ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_USERLIST_USER3_LABEL = "CAP_USER_PREVIEW_USERLIST_USER3_LABEL";

        /// <summary>
        /// User Preview Commentラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_COMMENT_LABEL = "CAP_USER_PREVIEW_COMMENT_LABEL";

        /// <summary>
        /// User Preview Observation file タイトルラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_OBSERVATIONFILE_TITLE_LABEL = "CAP_USER_PREVIEW_OBSERVATIONFILE_TITLE_LABEL";

        /// <summary>
        /// User Preview Observation mode タイトルラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_OBSERVATIONMODE_TITLE_LABEL = "CAP_USER_PREVIEW_OBSERVATIONMODE_TITLE_LABEL";

        /// <summary>
        /// User Preview Image processing タイトルラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_IMAGEPROCESSING_TITLE_LABEL = "CAP_USER_PREVIEW_IMAGEPROCESSING_TITLE_LABEL";

        /// <summary>
        /// User Preview サムネイル情報 HDR Anti-haration ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_HDR_ANTIHARATION = "CAP_USER_PREVIEW_THUMBNAILINFO_HDR_ANTIHARATION";

        /// <summary>
        /// User Preview サムネイル情報 HDR Texture enhancement ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_HDR_TEXTURE_ENHANCEMENT = "CAP_USER_PREVIEW_THUMBNAILINFO_HDR_TEXTURE_ENHANCEMENT";

        /// <summary>
        /// User Preview サムネイル情報 WiDER ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_WIDER = "CAP_USER_PREVIEW_THUMBNAILINFO_WIDER";

        /// <summary>
        /// User Preview サムネイル情報 Contrast ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_CONTRAST = "CAP_USER_PREVIEW_THUMBNAILINFO_CONTRAST";

        /// <summary>
        /// User Preview サムネイル情報 Observation BF ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_BF = "CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_BF";

        /// <summary>
        /// User Preview サムネイル情報 Observation DF ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_DF = "CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_DF";

        /// <summary>
        /// User Preview サムネイル情報 Observation DIC ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_DIC = "CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_DIC";

        /// <summary>
        /// User Preview サムネイル情報 Observation PO ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_PO = "CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_PO";

        /// <summary>
        /// User Preview サムネイル情報 Observation MIX ラベル
        /// </summary>
        public static readonly System.String CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_MIX = "CAP_USER_PREVIEW_THUMBNAILINFO_OBSERVATION_MIX";

        #endregion

        #region 観察条件再現
        /// <summary>
        /// 観察条件再現ｳｨﾝﾄﾞｳのﾍｯﾀﾞﾀｲﾄﾙ(=OBSERVATION REAPPEARANCE)
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_WINDOW_HEADER_TEXT = "CAP_REAPPEARANCE_WINDOW_HEADER_TEXT";

        /// <summary>
        /// 観察条件ﾌｧｲﾙｵｰﾌﾟﾝﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ(=Open observation file.)
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_DIALOG_FILE_OPEN_HEADER_TEXT = "CAP_REAPPEARANCE_DIALOG_FILE_OPEN_HEADER_TEXT";

        /// <summary>
        /// 観察条件ﾌｧｲﾙ保存ﾀﾞｲｱﾛｸﾞのﾍｯﾀﾞﾀｲﾄﾙ(=Save observation file.)
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_DIALOG_FILE_SAVE_HEADER_TEXT = "CAP_REAPPEARANCE_DIALOG_FILE_SAVE_HEADER_TEXT";

        /// <summary>
        /// 観察条件ﾌｧｲﾙのコメントラベル: Comment
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_DIALOG_LABEL_COMMENT = "CAP_REAPPEARANCE_DIALOG_LABEL_COMMENT";

        /// <summary>
        /// 観察条件ダイアログの保存ボタン
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_SAVE = "CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_SAVE";

        /// <summary>
        /// 観察条件ダイアログの適用ボタン
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_APPLY = "CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_APPLY";

        /// <summary>
        /// 観察条件ダイアログの中止ボタン
        /// </summary>
        public static readonly System.String CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_CANCEL = "CAP_REAPPEARANCE_DIALOG_BUTTON_LABEL_CANCEL";

        #endregion 観察条件再現

        #region LiveMeasure

        /// <summary>
        /// Title name on LiveMeasure Dialog : LiveMeasurement
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_DIALOG_LABEL_TITLE = "CAP_LIVEMEASURE_DIALOG_LABEL_TITLE";

        /// <summary>
        /// Label name on LiveMeasure Setting : Setting
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_DIALOG_LABEL_SETTING = "CAP_LIVEMEASURE_DIALOG_LABEL_SETTING";

        /// <summary>
        /// Label name on LiveMeasure Items : Measurement Items / 測定項目
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_GROUP_MEASURE_ITEMS = "CAP_LIVEMEASURE_GROUP_MEASURE_ITEMS";

        /// <summary>
        /// Label name on All Delete Button : pair strings [ALL] and [Delete]
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_BUTTON_LABEL_ALL = "CAP_LIVEMEASURE_BUTTON_LABEL_ALL";

        /// <summary>
        /// Label name on All Delete Button : pair strings [ALL] and [Delete]
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_BUTTON_LABEL_DELETE = "CAP_LIVEMEASURE_BUTTON_LABEL_DELETE";

        /// <summary>
        /// Lebel name on LineColor
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_LINECOLOR = "CAP_LIVEMEASURE_LABEL_LINECOLOR";

        /// <summary>
        /// Lebel name on TempLineColor
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_TEMPLINECOLOR = "CAP_LIVEMEASURE_LABEL_TEMPLINECOLOR";

        /// <summary>
        /// Lebel name on PointColor
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_POINTCOLOR = "CAP_LIVEMEASURE_LABEL_POINTCOLOR";

        /// <summary>
        /// Lebel name on LabelColor
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_LABELCOLOR = "CAP_LIVEMEASURE_LABEL_LABELCOLOR";

        /// <summary>
        /// Lebel name on LabelBackColorVisible
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_LABELBACKCOLORVISIBLE = "CAP_LIVEMEASURE_LABEL_LABELBACKCOLORVISIBLE";

        /// <summary>
        /// Lebel name on LabelLocation
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_LABELLOCATION = "CAP_LIVEMEASURE_LABEL_LABELLOCATION";

        /// <summary>
        /// Lebel name on LabelBackColor
        /// </summary>
        public static readonly System.String CAP_LIVEMEASURE_LABEL_LABELBACKCOLOR = "CAP_LIVEMEASURE_LABEL_LABELBACKCOLOR";

        #endregion LiveMeasure

        #region LiveStitching

        /// <summary>
        /// ライブ張り合わせ画面のタイトル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_TITLE_NAME = "CAP_LIVESTITCH_WINDOW_TITLE_NAME";

        /// <summary>
        /// ライブ張り合わせ画面の表示サイズ
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_DISPLAY_SIZE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_DISPLAY_SIZE_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の戻るボタンのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_BACKBUTTON_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_BACKBUTTON_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の明るさのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_BRIGHTNESS_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_BRIGHTNESS_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の操作ガイドのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_OPERATION_GUIDE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_OPERATION_GUIDE_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の前のページのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_PREVIOUS_PAGE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_PREVIOUS_PAGE_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の次のページのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_NEX_PAGE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_NEX_PAGE_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の2D/3Dのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_2D_3D_SETTING_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_2D_3D_SETTING_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の撮影のラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_PHOTOGRAPHY_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_PHOTOGRAPHY_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面のSTITCHのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_STITCHING_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_STITCHING_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の基準位置のラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_REFERENCE_POSITION_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_REFERENCE_POSITION_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の2D Easyのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_2D_EASY_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_2D_EASY_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の2D Standardのラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_2D_STANDARD_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_2D_STANDARD_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の「Map画像に使用する」のラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_USE_AS_MAP_IMAGE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_USE_AS_MAP_IMAGE_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の画像削除のラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_DELETE_IMAGE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_DELETE_IMAGE_LABEL";

        /// <summary>
        /// ライブ張り合わせ画面の完了のラベル
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_WINDOW_GROUP_COMPLETE_LABEL = "CAP_LIVESTITCH_WINDOW_GROUP_COMPLETE_LABEL";

        #endregion LiveStitching

        #region AutoStitching

        /// <summary>
        /// 電動貼り合わせのダイアログのタイトル名
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_TITLE_NAME = "CAP_AUTOSTITCH_DIALOG_TITLE_NAME";

        /// <summary>
        /// 電動貼り合わせのダイアログのページ指定ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_SPECIFY_PAGES = "CAP_AUTOSTITCH_DIALOG_GROUP_SPECIFY_PAGES";

        /// <summary>
        /// 電動貼り合わせのダイアログのページの長さラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_SPECIFY_SIZE = "CAP_AUTOSTITCH_DIALOG_GROUP_SPECIFY_SIZE";

        /// <summary>
        /// 電動貼り合わせのダイアログの貼り合わせ範囲指定のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_STITCH_AREA = "CAP_AUTOSTITCH_DIALOG_GROUP_STITCH_AREA";

        /// <summary>
        /// 電動貼り合わせのダイアログの横のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_ALIGN_HORIZONTAL = "CAP_AUTOSTITCH_DIALOG_GROUP_ALIGN_HORIZONTAL";

        /// <summary>
        /// 電動貼り合わせのダイアログの縦のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_ALIGN_VERTICAL = "CAP_AUTOSTITCH_DIALOG_GROUP_ALIGN_VERTICAL";

        /// <summary>
        /// 電動貼り合わせのダイアログのページ数のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_NUM_OF_SHEETS = "CAP_AUTOSTITCH_DIALOG_GROUP_NUM_OF_SHEETS";

        /// <summary>
        /// 電動貼り合わせのダイアログの基準位置のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_REFERENCE_POSITION = "CAP_AUTOSTITCH_DIALOG_GROUP_REFERENCE_POSITION";

        /// <summary>
        /// 電動貼り合わせのダイアログの貼り合わせ位置のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_STITCHING_POSITION = "CAP_AUTOSTITCH_DIALOG_GROUP_STITCHING_POSITION";

        /// <summary>
        /// 電動貼り合わせのダイアログの貼り合わせ位置番号のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_STITCHING_POSITION_NUM = "CAP_AUTOSTITCH_DIALOG_GROUP_STITCHING_POSITION_NUM";

        /// <summary>
        /// 電動貼り合わせのダイアログの左上のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_LEFT_UPPER = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_LEFT_UPPER";

        /// <summary>
        /// 電動貼り合わせのダイアログの上のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_UPPER = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_UPPER";

        /// <summary>
        /// 電動貼り合わせのダイアログの右上のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_RIGHT_UPPER = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_RIGHT_UPPER";

        /// <summary>
        /// 電動貼り合わせのダイアログの左のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_LEFT = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_LEFT";

        /// <summary>
        /// 電動貼り合わせのダイアログの中央のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_CENTER = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_CENTER";

        /// <summary>
        /// 電動貼り合わせのダイアログの右のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_RIGHT = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_RIGHT";

        /// <summary>
        /// 電動貼り合わせのダイアログの左下のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_LEFT_BOTTOM = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_LEFT_BOTTOM";

        /// <summary>
        /// 電動貼り合わせのダイアログの下のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_BOTTOM = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_BOTTOM";

        /// <summary>
        /// 電動貼り合わせのダイアログの右下のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_POS_RIGHT_BOTTOM = "CAP_AUTOSTITCH_DIALOG_GROUP_POS_RIGHT_BOTTOM";

        /// <summary>
        /// 電動貼り合わせのダイアログの広範囲貼り合わせのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX = "CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX";

        /// <summary>
        /// 電動貼り合わせのダイアログの広範囲貼り合わせの6x6ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_6X6 = "CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_6X6";

        /// <summary>
        /// 電動貼り合わせのダイアログの広範囲貼り合わせの7x7ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_7X7 = "CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_7X7";

        /// <summary>
        /// 電動貼り合わせのダイアログの広範囲貼り合わせの8x8ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_8X8 = "CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_8X8";

        /// <summary>
        /// 電動貼り合わせのダイアログの広範囲貼り合わせの9x9ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_9X9 = "CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_9X9";

        /// <summary>
        /// 電動貼り合わせのダイアログの広範囲貼り合わせの10x10ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_10X10 = "CAP_AUTOSTITCH_DIALOG_GROUP_WIDE_STITCH_MATRIX_10X10";

        /// <summary>
        /// 電動貼り合わせのダイアログの単位のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_UNIT = "CAP_AUTOSTITCH_DIALOG_GROUP_UNIT";

        /// <summary>
        /// 電動貼り合わせのダイアログのumのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_UNIT_UM = "CAP_AUTOSTITCH_DIALOG_GROUP_UNIT_UM";

        /// <summary>
        /// 電動貼り合わせのダイアログのmmのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_UNIT_MM = "CAP_AUTOSTITCH_DIALOG_GROUP_UNIT_MM";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_LABEL = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_LABEL";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせの0%ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_0 = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_0";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせの10%ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_10 = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_10";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせの20%ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_20 = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_20";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせの30%ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_30 = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_30";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせの40%ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_40 = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_40";

        /// <summary>
        /// 電動貼り合わせのダイアログの重ね合わせの50%ラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_50 = "CAP_AUTOSTITCH_DIALOG_GROUP_OVERLAP_50";

        /// <summary>
        /// 電動貼り合わせのダイアログの基準位置更新ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_ALIGNMENT_UPDATE_BUTTON = "CAP_AUTOSTITCH_DIALOG_ALIGNMENT_UPDATE_BUTTON";

        /// <summary>
        /// 電動貼り合わせのダイアログの登録ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_REGISTRATION_BUTTON = "CAP_AUTOSTITCH_REGISTRATION_BUTTON";

        /// <summary>
        /// 電動貼り合わせのダイアログの解除ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_RELEASE_BUTTON = "CAP_AUTOSTITCH_RELEASE_BUTTON";

        /// <summary>
        /// 電動貼り合わせのダイアログの移動のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_CHANGE = "CAP_AUTOSTITCH_LOCATION_CHANGE";

        /// <summary>
        /// 電動貼り合わせのダイアログの移動ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_CHANGE_BUTTON = "CAP_AUTOSTITCH_LOCATION_CHANGE_BUTTON";

        /// <summary>
        /// 電動貼り合わせのダイアログのMainMenuｎ条件を使用する文言のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_USE_CONDITION_DEFINED_IN_MAIN_MENU = "CAP_AUTOSTITCH_LOCATION_USE_CONDITION_DEFINED_IN_MAIN_MENU";

        /// <summary>
        /// 電動貼り合わせのダイアログの貼り合わせ実行順序のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_STITCH_AFTER_TAKE_PHIOTOGRAPHY = "CAP_AUTOSTITCH_LOCATION_STITCH_AFTER_TAKE_PHIOTOGRAPHY";

        /// <summary>
        /// 電動貼り合わせのダイアログの自動保存のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY = "CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY";

        /// <summary>
        /// 電動貼り合わせのダイアログの自動保存設定のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY_SETTING = "CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_PHOTOGRAPHY_SETTING";

        /// <summary>
        /// 電動貼り合わせのダイアログの保存先のラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_AS = "CAP_AUTOSTITCH_LOCATION_AUTO_SAVE_AS";

        /// <summary>
        /// 電動貼り合わせのダイアログの撮影ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_TAKE_PHOTOGRAPHY = "CAP_AUTOSTITCH_DIALOG_TAKE_PHOTOGRAPHY";

        /// <summary>
        /// 電動貼り合わせのダイアログの中止ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_DIALOG_CANCEL = "CAP_AUTOSTITCH_DIALOG_CANCEL";

        /// <summary>
        /// 電動貼り合わせ進捗状況表示ラベル（撮影完了しました。）
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_PROGRESS_END = "CAP_AUTOSTITCH_PROGRESS_END";

        /// <summary>
        /// 電動貼り合わせ進捗状況表示ラベル（撮影中です。）
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_PROGRESS = "CAP_AUTOSTITCH_PROGRESS";

        /// <summary>
        /// 貼り合わせの固定モード
        /// </summary>
        public static readonly System.String CAP_LIVESTITCH_MODE = "CAP_LIVESTITCH_MODE";

        /// <summary>
        /// 貼り合わせの自動モード
        /// </summary>
        public static readonly System.String CAP_AUTOSTITCH_MODE = "CAP_AUTOSTITCH_MODE";

        #endregion AutoStitching

        #region FullScreenMenu

        /// <summary>
        /// 全画面の戻るボタンのラベル
        /// </summary>
        public static readonly System.String CAP_FULL_SCREEN_PAGE_BACK_BUTTON_LABEL = "CAP_FULL_SCREEN_PAGE_BACK_BUTTON_LABEL";

        /// <summary>
        /// 全画面の明るさ指定のラベル
        /// </summary>
        public static readonly System.String CAP_FULL_SCREEN_PAGE_BRIGHTNESS_LABEL = "CAP_FULL_SCREEN_PAGE_BRIGHTNESS_LABEL";

        /// <summary>
        /// 全画面の中止ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_FULL_SCREEN_PAGE_ACQUISITION_CANCEL_BUTTON_LABEL = "CAP_FULL_SCREEN_PAGE_ACQUISITION_CANCEL_BUTTON_LABEL";

        /// <summary>
        /// 全画面の撮影ボタンのラベル
        /// </summary>
        public static readonly System.String CAP_FULL_SCREEN_PAGE_ACQUISITION_START_BUTTON_LABEL = "CAP_FULL_SCREEN_PAGE_ACQUISITION_START_BUTTON_LABEL";

        /// <summary>
        /// 全画面のUNITのラベル
        /// </summary>
        public static readonly System.String CAP_FULL_SCREEN_PAGE_UNIT_LABEL = "CAP_FULL_SCREEN_PAGE_UNIT_LABEL";

        #endregion FullScreenMenu

        #region ScreenPositionCommon
        /// <summary>
        /// 画面位置マトリックスの左上のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_LEFT_UPPER = "CAP_SCREEN_MATRIX_POS_LEFT_UPPER";

        /// <summary>
        /// 画面位置マトリックスの上のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_UPPER = "CAP_SCREEN_MATRIX_POS_UPPER";

        /// <summary>
        /// 画面位置マトリックスの右上のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_RIGHT_UPPER = "CAP_SCREEN_MATRIX_POS_RIGHT_UPPER";

        /// <summary>
        /// 画面位置マトリックスの左のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_LEFT = "CAP_SCREEN_MATRIX_POS_LEFT";

        /// <summary>
        /// 画面位置マトリックスの中央のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_CENTER = "CAP_SCREEN_MATRIX_POS_CENTER";

        /// <summary>
        /// 画面位置マトリックスの右のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_RIGHT = "CAP_SCREEN_MATRIX_POS_RIGHT";

        /// <summary>
        /// 画面位置マトリックスの左下のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_LEFT_BOTTOM = "CAP_SCREEN_MATRIX_POS_LEFT_BOTTOM";

        /// <summary>
        /// 画面位置マトリックスの下のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_BOTTOM = "CAP_SCREEN_MATRIX_POS_BOTTOM";

        /// <summary>
        /// 画面位置マトリックスの右下のラベル
        /// </summary>
        public static readonly System.String CAP_SCREEN_MATRIX_POS_RIGHT_BOTTOM = "CAP_SCREEN_MATRIX_POS_RIGHT_BOTTOM";

        #endregion

        #region システム構成確認変更
        /// <summary>
        /// 高倍正立システム名称
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_NAME_HRUF = "CAP_SYSCONFIGURATION_NAME_HRUF";

        /// <summary>
        /// 高倍倒立システム名称
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_NAME_HRIF = "CAP_SYSCONFIGURATION_NAME_HRIF";

        /// <summary>
        /// 低倍フレキシステム名称
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_NAME_WIZ = "CAP_SYSCONFIGURATION_NAME_WIZ";

        /// <summary>
        /// バックライト
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_BACKLIGHT = "CAP_SYSCONFIGURATION_TABLE_BACKLIGHT";

        /// <summary>
        /// ファイバー照明
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_FIBERLIGHT = "CAP_SYSCONFIGURATION_TABLE_FIBERLIGHT";

        /// <summary>
        /// ステージ
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_STAGE = "CAP_SYSCONFIGURATION_TABLE_STAGE";

        /// <summary>
        /// オプション接続
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_CONNECTED = "CAP_SYSCONFIGURATION_TABLE_CONNECTED";

        /// <summary>
        /// オプション未接続
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_DISCONNECTED = "CAP_SYSCONFIGURATION_TABLE_DISCONNECTED";

        /// <summary>
        /// オプション有効
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_AVAILABLE = "CAP_SYSCONFIGURATION_TABLE_AVAILABLE";

        /// <summary>
        /// オプション無効
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_NOTAVAILABLE = "CAP_SYSCONFIGURATION_TABLE_NOTAVAILABLE";

        /// <summary>
        /// オプション電動ステージ
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_ELEC_STAGE = "CAP_SYSCONFIGURATION_TABLE_ELEC_STAGE";

        /// <summary>
        /// オプションマニュアルステージ
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_MANUAL_STAGE = "CAP_SYSCONFIGURATION_TABLE_MANUAL_STAGE";

        /// <summary>
        /// オプションハードウェア設定
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_COLUMN_HARD = "CAP_SYSCONFIGURATION_TABLE_COLUMN_HARD";

        /// <summary>
        /// オプションソフトウェア設定
        /// </summary>
        public static readonly System.String CAP_SYSCONFIGURATION_TABLE_COLUMN_SOFT = "CAP_SYSCONFIGURATION_TABLE_COLUMN_SOFT";

        #endregion システム構成確認変更

        #region オプション
        /// <summary>
        /// バックライトオプション選択チェックボックスのラベル
        /// </summary>
        public static readonly System.String CAP_OPTIONSETTINGS_BACKLIGHT_CHECKBOX = "CAP_OPTIONSETTINGS_BACKLIGHT_CHECKBOX";

        /// <summary>
        /// ファイバー照明オプション選択チェックボックスのラベル
        /// </summary>
        public static readonly System.String CAP_OPTIONSETTINGS_FIBERLIGHT_CHECKBOX = "CAP_OPTIONSETTINGS_FIBERLIGHT_CHECKBOX";

        /// <summary>
        /// ステージ選択のラベル
        /// </summary>
        public static readonly System.String CAP_OPTIONSETTINGS_STAGE_LABEL = "CAP_OPTIONSETTINGS_STAGE_LABEL";

        /// <summary>
        /// 電動ステージ選択ラジオボタンのラベル
        /// </summary>
        public static readonly System.String CAP_OPTIONSETTINGS_XYSTAGE_RADIOBUTTON = "CAP_OPTIONSETTINGS_XYSTAGE_RADIOBUTTON";

        /// <summary>
        /// 手動ステージ選択ラジオボタンのラベル
        /// </summary>
        public static readonly System.String CAP_OPTIONSETTINGS_MANUAL_RADIOBUTTON = "CAP_OPTIONSETTINGS_MANUAL_RADIOBUTTON";

        /// <summary>
        /// 手動ステージ選択ラジオボタンのラベル
        /// </summary>
        public static readonly System.String CAP_OPTIONSETTINGS_CANCEL_BUTTON = "CAP_OPTIONSETTINGS_CANCEL_BUTTON";

        #endregion オプション

        #region カスタマイズ画面

        /// <summary>
        /// カスタマイズ画面のタイトルラベル
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_TITLE_LABEL = "CAP_DISPLAYCUSTOMIZE_TITLE_LABEL";


        /// <summary>
        /// カスタマイズ画面のMenuのヘッダーラベル
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_MENUHEADER_LABEL = "CAP_DISPLAYCUSTOMIZE_MENUHEADER_LABEL";


        /// <summary>
        /// Best imageラベル(Menu)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_BESTIMAGE_LABEL = "CAP_DISPLAYCUSTOMIZE_BESTIMAGE_LABEL";

        /// <summary>
        /// Full screenラベル(Menu)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_FULLSCREEN_LABEL = "CAP_DISPLAYCUSTOMIZE_FULLSCREEN_LABEL";

        /// <summary>
        /// Dual screenラベル(Menu)chkConditionSettings
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_DUALSCREEN_LABEL = "CAP_DISPLAYCUSTOMIZE_DUALSCREEN_LABEL";

        /// <summary>
        /// Condition settingsラベル(Menu)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_CONDITIONSETTINGS_LABEL = "CAP_DISPLAYCUSTOMIZE_CONDITIONSETTINGS_LABEL";

        /// <summary>
        /// Stitchingラベル(Menu)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_STITCHING_LABEL = "CAP_DISPLAYCUSTOMIZE_STITCHING_LABEL";

        /// <summary>
        /// Advanced settingsラベル(Menu)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_ADVANCEDSETTINGS_LABEL = "CAP_DISPLAYCUSTOMIZE_ADVANCEDSETTINGS_LABEL";

        /// <summary>
        /// Advanced acquisitionラベル(Menu)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_ADVANCEDACQUISITION_LABEL = "CAP_DISPLAYCUSTOMIZE_ADVANCEDACQUISITION_LABEL";


        /// <summary>
        /// カスタマイズ画面のPanelのヘッダーラベル
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_PANELHEADER_LABEL = "CAP_DISPLAYCUSTOMIZE_PANELHEADER_LABEL";


        /// <summary>
        /// Obsevation modeラベル(Panel)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_OBSEVATIONMODE_LABEL = "CAP_DISPLAYCUSTOMIZE_OBSEVATIONMODE_LABEL";

        /// <summary>
        /// Obsevation settingsラベル(Panel)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_OBSEVATIONSETTINGS_LABEL = "CAP_DISPLAYCUSTOMIZE_OBSEVATIONSETTINGS_LABEL";

        /// <summary>
        /// Image processingラベル(Panel)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_IMAGEPROCESSING_LABEL = "CAP_DISPLAYCUSTOMIZE_IMAGEPROCESSING_LABEL";

        /// <summary>
        /// Accessoryラベル(Panel)
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_ACCESSORY_LABEL = "CAP_DISPLAYCUSTOMIZE_ACCESSORY_LABEL";

        /// <summary>
        /// TabNameApplyCheckBox
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_TABNAME_APPLY_CHECKBOX = "CAP_DISPLAYCUSTOMIZE_TABNAME_APPLY_CHECKBOX";

        /// <summary>
        /// TabNameラベル
        /// </summary>
        public static readonly System.String CAP_DISPLAYCUSTOMIZE_TABNAME_LABEL = "CAP_DISPLAYCUSTOMIZE_TABNAME_LABEL";

        #endregion

        #region ライブ計測
        /// <summary>
        /// 計測値表示位置[自動]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_POSITION_AUTO = "CAP_MEASUREMENT_POSITION_AUTO";

        /// <summary>
        /// 計測値表示位置[開始点]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_POSITION_STARTPOINT = "CAP_MEASUREMENT_POSITION_STARTPOINT";

        /// <summary>
        /// 計測値表示位置[終了点]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_POSITION_ENDPOINT = "CAP_MEASUREMENT_POSITION_ENDPOINT";

        /// <summary>
        /// 計測結果[L]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_L = "CAP_MEASUREMENT_L";

        /// <summary>
        /// 計測結果[L1]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_L1 = "CAP_MEASUREMENT_L1";

        /// <summary>
        /// 計測結果[カウント]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_COUNT = "CAP_MEASUREMENT_COUNT";

        /// <summary>
        /// 計測結果[円弧]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_ARK = "CAP_MEASUREMENT_ARK";

        /// <summary>
        /// 計測結果[角度]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_ANGLE = "CAP_MEASUREMENT_ANGLE";

        /// <summary>
        /// 計測結果[距離]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_DISTANCE = "CAP_MEASUREMENT_DISTANCE";

        /// <summary>
        /// 計測結果[曲率]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_CURVATURE = "CAP_MEASUREMENT_CURVATURE";

        /// <summary>
        /// 計測結果[周囲長]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_CIRCUMFERENCE = "CAP_MEASUREMENT_CIRCUMFERENCE";

        /// <summary>
        /// 計測結果[対角線]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_DIAGONAL_LENGTH = "CAP_MEASUREMENT_DIAGONAL_LENGTH";

        /// <summary>
        /// 計測結果[直径]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_DIAMETER = "CAP_MEASUREMENT_DIAMETER";

        /// <summary>
        /// 計測結果[半径]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_RADIUS = "CAP_MEASUREMENT_RADIUS";

        /// <summary>
        /// 計測結果[面積]のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_AREA = "CAP_MEASUREMENT_AREA";

        /// <summary>
        /// 計測結果[L]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_L_UNIT = "CAP_MEASUREMENT_L_UNIT";

        /// <summary>
        /// 計測結果[L1]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_L1_UNIT = "CAP_MEASUREMENT_L1_UNIT";

        /// <summary>
        /// 計測結果[円弧]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_ARK_UNIT = "CAP_MEASUREMENT_ARK_UNIT";

        /// <summary>
        /// 計測結果[角度]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_ANGLE_UNIT = "CAP_MEASUREMENT_ANGLE_UNIT";

        /// <summary>
        /// 計測結果[距離]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_DISTANCE_UNIT = "CAP_MEASUREMENT_DISTANCE_UNIT";

        /// <summary>
        /// 計測結果[曲率]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_CURVATURE_UNIT = "CAP_MEASUREMENT_CURVATURE_UNIT";

        /// <summary>
        /// 計測結果[周囲長]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_CIRCUMFERENCE_UNIT = "CAP_MEASUREMENT_CIRCUMFERENCE_UNIT";

        /// <summary>
        /// 計測結果[対角線]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_DIAGONAL_LENGTH_UNIT = "CAP_MEASUREMENT_DIAGONAL_LENGTH_UNIT";

        /// <summary>
        /// 計測結果[直径]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_DIAMETER_UNIT = "CAP_MEASUREMENT_DIAMETER_UNIT";

        /// <summary>
        /// 計測結果[半径]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_RADIUS_UNIT = "CAP_MEASUREMENT_RADIUS_UNIT";

        /// <summary>
        /// 計測結果[面積]の単位のキャプション
        /// </summary>
        public static readonly System.String CAP_MEASUREMENT_AREA_UNIT = "CAP_MEASUREMENT_AREA_UNIT";
        #endregion

        #region ﾋﾞｷﾞﾅｰﾓｰﾄﾞ
        /// <summary>
        /// PositionTab
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_POSITION_TAB = "CAP_BEGINNER_AREA_POSITION_TAB";

        /// <summary>
        /// ObservationTab
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_OBSERVATION_TAB = "CAP_BEGINNER_AREA_OBSERVATION_TAB";

        /// <summary>
        /// AcquisitonTab
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_ACQUISITION_TAB = "CAP_BEGINNER_AREA_ACQUISITION_TAB";

        /// <summary>
        /// Focus Z Position
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_FOCUS_Z_POSITION_TEXT = "CAP_BEGINNER_AREA_FOCUS_Z_POSITION_TEXT";

        /// <summary>
        /// Observation location
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_OBSERVATION_LOCATION_TEXT = "CAP_BEGINNER_AREA_OBSERVATION_LOCATION_TEXT";

        /// <summary>
        /// Zoom
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_ZOOM_TEXT = "CAP_BEGINNER_AREA_ZOOM_TEXT";

        /// <summary>
        /// Bright
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_BRIGHT_TEXT = "CAP_BEGINNER_AREA_BRIGHT_TEXT";

        /// <summary>
        /// BestImage
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_BEST_IMAGE_TEXT = "CAP_BEGINNER_AREA_BEST_IMAGE_TEXT";

        /// <summary>
        /// ReadCondition
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_READ_CONDITION_TEXT = "CAP_BEGINNER_AREA_READ_CONDITION_TEXT";

        /// <summary>
        /// Restore
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_RESTORE_TEXT = "CAP_BEGINNER_AREA_RESTORE_TEXT";

        /// <summary>
        /// AcquisitionMode
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_ACQUISITION_MODE_TEXT = "CAP_BEGINNER_AREA_ACQUISITION_MODE_TEXT";

        /// <summary>
        /// ZRange
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_Z_RANGE_TEXT = "CAP_BEGINNER_AREA_Z_RANGE_TEXT";

        /// <summary>
        /// ZRangeGuideMessage(現在位置で設定)
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_Z_RANGE_GUIDE_BASE_NOW_POSITION_TEXT = "CAP_BEGINNER_AREA_Z_RANGE_GUIDE_BASE_NOW_POSITION_TEXT";

        /// <summary>
        /// ZRangeGuideMessage(中央位置で設定)
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_Z_RANGE_GUIDE_BASE_CENTER_POSITION_TEXT = "CAP_BEGINNER_AREA_Z_RANGE_GUIDE_BASE_CENTER_POSITION_TEXT";

        /// <summary>
        /// lblBtnReadCondition
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_READ_CONDITION_BUTTON_LABEL = "CAP_BEGINNER_AREA_READ_CONDITION_BUTTON_LABEL";

        /// <summary>
        /// lblBtnBack
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_BACK_BUTTON_LABEL = "CAP_BEGINNER_AREA_BACK_BUTTON_LABEL";

        /// <summary>
        /// lblBtnNext
        /// </summary>
        public static readonly System.String CAP_BEGINNER_AREA_NEXT_BUTTON_LABEL = "CAP_BEGINNER_AREA_NEXT_BUTTON_LABEL";

        /// <summary>
        /// Or
        /// </summary>
        public static readonly System.String CAP_BEGINNER_OBSERVATION_OR_LABEL = "CAP_BEGINNER_OBSERVATION_OR_LABEL";
        #endregion
    }
}
