// ------------------------------------------------------------------------------
// <copyright file="CstMessageResourceKey.cs" company="OLYMPUS,LI">
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
    /// ﾒｯｾｰｼﾞﾘｿｰｽｷｰの定義
    /// </summary>
    public static class UiMessageResourceKey
    {
        #region ｼｽﾃﾑ

        /// <summary>
        /// ｼｽﾃﾑ継続不可能な致命的要因の障害発生を通知し、ｱﾌﾟﾘｹｰｼｮﾝの終了を促す。
        /// </summary>
        public static readonly String MSG_E_SYSTEM_FATAL_ERROR = "MSG_E_SYSTEM_FATAL_ERROR";

        /// <summary>
        /// アプリケーションの警告メッセージ。
        /// </summary>
        public static readonly String MSG_E_SYSTEM_WARNING_ERROR = "MSG_E_SYSTEM_WARNING_ERROR";

        #endregion ｼｽﾃﾑ

        #region ﾕﾆｯﾄ喪失
        /// <summary>
        /// ﾍｯﾄﾞが取り外された
        /// </summary>
        public static readonly String MSG_E_SYSTEM_LOST_HEAD = "MSG_E_SYSTEM_LOST_HEAD";
        #endregion ﾕﾆｯﾄ喪失

        #region HW初期化
        /// <summary>
        /// 電源投入或いはｵﾌﾗｲﾝでの起動を促す
        /// </summary>
        public static readonly String MSG_Q_HWINIT_EL_POW_ON = "MSG_Q_HWINIT_EL_POW_ON";

        /// <summary>
        /// 電源投入を促す
        /// </summary>
        public static readonly String MSG_I_HWINIT_EL_POW_ON = "MSG_I_HWINIT_EL_POW_ON";

        /// <summary>
        /// 電源投入を再度促す
        /// </summary>
        public static readonly String MSG_I_HWINIT_EL_POW_ON_RETRY = "MSG_I_HWINIT_EL_POW_ON_RETRY";

        /// <summary>
        /// 電源投入失敗によるｿﾌﾄｳｪｱ終了
        /// </summary>
        public static readonly String MSG_I_HWINIT_EL_POW_ON_FAILURE = "MSG_I_HWINIT_EL_POW_ON_FAILURE";

        /// <summary>
        /// ﾊｰﾄﾞｳｪｱ初期化失敗によるｿﾌﾄｳｪｱ終了
        /// </summary>
        public static readonly String MSG_E_HWINIT_START_FAILURE = "MSG_E_HWINIT_START_FAILURE";

        /// <summary>
        /// ﾊｰﾄﾞｳｪｱ初期化失敗によるｵﾌﾗｲﾝ起動
        /// </summary>
        public static readonly String MSG_W_HWINIT_START_OFFLINE = "MSG_W_HWINIT_START_OFFLINE";

        /// <summary>
        /// ﾊｰﾄﾞｳｪｱ初期化中にｿﾌﾄｳｪｱ要因の障害発生
        /// </summary>
        public static readonly String MSG_E_HWINIT_INTERNAL_ERROR = "MSG_E_HWINIT_INTERNAL_ERROR";

        /// <summary>
        /// ｶﾒﾗ未検知によるｿﾌﾄｳｪｱ終了
        /// </summary>
        public static readonly String MSG_I_HWINIT_CAMERA_NOT_FOUND = "MSG_I_HWINIT_CAMERA_NOT_FOUND";

        /// <summary>
        /// Z位置最適化確認
        /// </summary>
        public static readonly String MSG_Q_Z_INITIALIZE_POSITION = "MSG_Q_Z_INITIALIZE_POSITION";

        /// <summary>
        /// Z位置最適化と対物レンズ確認
        /// </summary>
        public static readonly String MSG_Q_Z_INITIALIZE_POSITION_AND_LENS = "MSG_Q_Z_INITIALIZE_POSITION_AND_LENS";
        #endregion HW初期化

        #region 観察設定

        /// <summary>
        /// 観察のダイアログタイトル
        /// </summary>
        public static readonly String MSG_I_OBSERVATION_DIALOG_TITLE = "MSG_I_OBSERVATION_DIALOG_TITLE";

        /// <summary>
        /// ｱｽﾍﾟｸﾄ比の切り替え操作によりROIの表示位置･ｻｲｽﾞの変換結果がﾗｲﾌﾞ表示領域外となった場合にﾃﾞﾌｫﾙﾄの表示位置･ｻｲｽﾞに戻すことを通知する
        /// </summary>
        public static readonly String MSG_I_OBSERVATION_ROI_OUT_OF_VIEW = "MSG_I_OBSERVATION_ROI_OUT_OF_VIEW";

        #endregion 観察設定

        #region 倍率
        /// <summary>
        /// ｽﾞｰﾑ制御不能
        /// </summary>
        public static readonly String MSG_E_MAGCHG_UNCNTRL_ZOOM = "MSG_E_MAGCHG_UNCNTRL_ZOOM";

        /// <summary>
        /// 低倍ﾍｯﾄﾞ装着時のﾚﾝｽﾞ交換はｿﾌﾄｳｪｱ終了操作を促す
        /// </summary>
        public static readonly String MSG_I_MAGCHG_LENS_EXCHANGE = "MSG_I_MAGCHG_LENS_EXCHANGE";

        /// <summary>
        /// ﾚﾎﾞﾙﾊﾞに装着されたﾚﾝｽﾞ情報の登録(更新)確認(OK/CANCEL)を促す
        /// </summary>
        public static readonly String MSG_Q_MAGCHG_LENS_REGISTRATION = "MSG_Q_MAGCHG_LENS_REGISTRATION";

        /// <summary>
        /// 3D/全焦点の構築中止確認
        /// </summary>
        public static readonly String MSG_Q_MAGCHG_BUILDING_STOP_CONFIRM = "MSG_Q_MAGCHG_BUILDING_STOP_CONFIRM";

        /// <summary>
        /// ﾚﾎﾞﾙﾊﾞに装着されたﾚﾝｽﾞの情報が登録されていない
        /// </summary>
        public static readonly String MSG_W_MAGCHG_NONE_LENS_INFO = "MSG_W_MAGCHG_NONE_LENS_INFO";

        /// <summary>
        /// 起動時にレボルバが中間位置だった場合の警告メッセージ
        /// </summary>
        public static readonly String MSG_W_MAGCHG_CENTER_REVO_INITIAL = "MSG_W_MAGCHG_CENTER_REVO_INITIAL";

        /// <summary>
        /// 起動処理中に対物ﾚﾝｽﾞを切り替えてはいけない
        /// </summary>
        public static readonly String MSG_W_MAGCHG_SWITCH_REVO_INITIAL = "MSG_W_MAGCHG_SWITCH_REVO_INITIAL";

        /// <summary>
        /// 終了処理中に対物ﾚﾝｽﾞを切り替えてはいけない
        /// </summary>
        public static readonly String MSG_W_MAGCHG_SWITCH_REVO_FINAL = "MSG_W_MAGCHG_SWITCH_REVO_FINAL";

        /// <summary>
        /// AF制御中に対物ﾚﾝｽﾞを切り替えてはいけない
        /// </summary>
        public static readonly String MSG_W_MAGCHG_SWITCH_REVO_AF_CTRL = "MSG_W_MAGCHG_SWITCH_REVO_AF_CTRL";

        /// <summary>
        /// 撮像中に対物ﾚﾝｽﾞを切り替えてはいけない
        /// </summary>
        public static readonly String MSG_W_MAGCHG_SWITCH_REVO_EXEC_TAKE_PICT = "MSG_W_MAGCHG_SWITCH_REVO_EXEC_TAKE_PICT";

        /// <summary>
        /// 撮像中止中に対物ﾚﾝｽﾞを切り替えてはいけない
        /// </summary>
        public static readonly String MSG_W_MAGCHG_SWITCH_REVO_STOP_TAKE_PICT = "MSG_W_MAGCHG_SWITCH_REVO_STOP_TAKE_PICT";

        /// <summary>
        /// ﾚﾎﾞﾙﾊﾞ中間位置のため、No1又はNo2に切り替えるよう促す
        /// </summary>
        public static readonly String MSG_W_MAGCHG_REVOLVER_NEUTRAL_POSITION = "MSG_W_MAGCHG_REVOLVER_NEUTRAL_POSITION";

        /// <summary>
        /// 倍率変更中にｿﾌﾄｳｪｱ要因の障害発生
        /// </summary>
        public static readonly String MSG_E_MAGCHG_INTERNAL_ERROR = "MSG_E_MAGCHG_INTERNAL_ERROR";

        /// <summary>
        /// 対物ﾚﾝｽﾞ名（一覧）のｺﾝﾎﾞﾎﾞｯｸｽでﾚﾝｽﾞ名選択時の注意を促す
        /// </summary>
        public static readonly String MSG_I_MAGCHG_SELECT_LENS = "MSG_I_MAGCHG_SELECT_LENS";

        /// <summary>
        /// 対物ﾚﾝｽﾞ名（一覧）のｺﾝﾎﾞﾎﾞｯｸｽで未登録選択時の注意を促す
        /// </summary>
        public static readonly String MSG_I_MAGCHG_SELECT_UNREGISTERED = "MSG_I_MAGCHG_SELECT_UNREGISTERED";

        /// <summary>
        /// ROIズーム表示中にレボルバが切り替えられたのでROIを非表示にした通知
        /// </summary>
        public static readonly String MSG_I_MAGCHG_ROI_OFF_BY_REVOLVER_CHANGE = "MSG_I_MAGCHG_ROI_OFF_BY_REVOLVER_CHANGE";

        /// <summary>
        /// 指定したﾚﾝｽﾞの組み合わせが同時登録不能な時の注意を促す
        /// </summary>
        public static readonly String MSG_W_MAGCHG_MISMATCH_LENS_COMBINATION = "MSG_W_MAGCHG_MISMATCH_LENS_COMBINATION";

        /// <summary>
        /// DSX500(倒立)の場合は対物レンズが１つしか登録できないことの注意を促す
        /// </summary>
        public static readonly String MSG_W_MAGCHG_LENS_REGISTRATION_ONLY_ONE = "MSG_W_MAGCHG_LENS_REGISTRATION_ONLY_ONE";
        
        #endregion 倍率

        #region Focus

        #region AF
        /// <summary>
        /// AF実行で焦点を見つけられなかった場合の通知メッセージ
        /// </summary>
        public static readonly String MSG_I_OBSERVATION_AF_PEAK_NOT_FOUND = "MSG_I_OBSERVATION_AF_PEAK_NOT_FOUND";

        /// <summary>
        /// AF実行中に影響のあるHWを操作した場合の警告メッセージ
        /// </summary>
        public static readonly String MSG_E_OBSERV_AF_HW_ERROR = "MSG_E_OBSERV_AF_HW_ERROR";

        /// <summary>
        /// AF実行でタイムアウトになった場合の通知メッセージ
        /// </summary>
        public static readonly String MSG_E_OBSERV_AF_TIMEOUT = "MSG_E_OBSERV_AF_TIMEOUT";

        /// <summary>
        /// AF実行中のレボルバ切り替えのエラー
        /// </summary>
        public static readonly System.String MSG_E_AF_FAIL_BY_REVOLVER_CHANGE = "MSG_E_AF_FAIL_BY_REVOLVER_CHANGE";

        #endregion AF

        #region ZMove
        /// <summary>
        /// Z駆動の原点基準位置移動確認
        /// </summary>
        public static readonly String MSG_Q_FOCUS_MOVE_BASE_POSITION = "MSG_Q_FOCUS_MOVE_BASE_POSITION";

        /// <summary>
        /// Z駆動のユーセントリック位置移動確認
        /// </summary>
        public static readonly String MSG_Q_FOCUS_MOVE_EUCENTRIC_POSITION = "MSG_Q_FOCUS_MOVE_EUCENTRIC_POSITION";

        /// <summary>
        /// Z駆動の原点基準位置移動時における近接限界値の超過警告
        /// </summary>
        public static readonly String MSG_W_FOCUS_EXCEEDS_NEAR_DIRECTION_STANDARD_POSITION = "MSG_W_FOCUS_EXCEEDS_NEAR_DIRECTION_STANDARD_POSITION";

        /// <summary>
        /// ユーセントリック位置移動で近接リミットに引っかかるとき
        /// </summary>
        public static readonly String MSG_I_FOCUS_EUCENTRIC_LIMIT_OVER = "MSG_I_FOCUS_EUCENTRIC_LIMIT_OVER";

        /// <summary>
        /// 偏光アダプタを取り付け状態に設定した場合の確認
        /// </summary>
        public static readonly String MSG_I_FOCUS_SET_ADAPTER_ATTACHSTATE_ATTACHED = "MSG_I_FOCUS_SET_ADAPTER_ATTACHSTATE_ATTACHED";

        /// <summary>
        /// 偏光アダプタを取り外し状態に設定した場合の確認
        /// </summary>
        public static readonly String MSG_I_FOCUS_SET_ADAPTER_ATTACHSTATE_DETTACHED = "MSG_I_FOCUS_SET_ADAPTER_ATTACHSTATE_DETTACHED";
        #endregion ZMove

        #endregion Focus

        #region Stage
        /// <summary>
        /// ｽﾃｰｼﾞ初期化中のｽﾃｰｼﾞ原点出し確認
        /// </summary>
        public static readonly String MSG_Q_STAGE_STARTING_POSITION_PUTTINGOUT = "MSG_Q_STAGE_STARTING_POSITION_PUTTINGOUT";

        /// <summary>
        /// 座標登録上限オーバー
        /// </summary>
        public static readonly String MSG_W_STAGE_COORDINATES_MAX_REGIST_COUNT_OVER = "MSG_W_STAGE_COORDINATES_MAX_REGIST_COUNT_OVER";

        /// <summary>
        /// 登録座標削除確認
        /// </summary>
        public static readonly String MSG_Q_STAGE_COORDINATES_DELETE = "MSG_Q_STAGE_COORDINATES_DELETE";
        
        /// <summary>
        /// アライメント解除許可ﾀﾞｲｱﾛｸﾞの文言
        /// </summary>
        public static readonly System.String MSG_Q_STAGE_ALIGNMENT_DISABLE = "MSG_Q_STAGE_ALIGNMENT_DISABLE";
        
        /// <summary>
        /// Zステージ移動範囲の限界まで移動してズームを行う
        /// </summary>
        public static readonly System.String MSG_W_ZOOM_UP_MOVE_TO_Z_POSITION_LIMIT = "MSG_W_ZOOM_UP_MOVE_TO_Z_POSITION_LIMIT";

        /// <summary>
        /// ｽﾃｰｼﾞ自動補正の開始確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_STAGE_AUTO_CALIBRATION_START = "MSG_Q_STAGE_AUTO_CALIBRATION_START";

        /// <summary>
        /// ｽﾃｰｼﾞ自動補正の完了メッセージ
        /// </summary>
        public static readonly System.String MSG_I_STAGE_AUTO_CALIBRATION_END = "MSG_I_STAGE_AUTO_CALIBRATION_END";

        /// <summary>
        /// 任意ステップ移動によってステージ範囲外に移動してしまうメッセージ
        /// </summary>
        public static readonly System.String MSG_W_STAGE_STEP_MOVE_TO_OUT_OF_RANGE = "MSG_W_STAGE_STEP_MOVE_TO_OUT_OF_RANGE";

        #endregion Stage

        #region HDR
        /// <summary>
        /// HDR実行時の3CCDモード変更可否確認
        /// </summary>
        public static readonly String MSG_Q_SNAP_CONFIRM_CHANGE_3CCD_FOR_HDR = "MSG_Q_SNAP_CONFIRM_CHANGE_3CCD_FOR_HDR";

        /// <summary>
        /// HDR実行時の構築モード変更可否確認
        /// </summary>
        public static readonly String MSG_Q_EXTEND_CONFIRM_CHANGE_MODE_FOR_HDR = "MSG_Q_EXTEND_CONFIRM_CHANGE_MODE_FOR_HDR";
        #endregion HDR

        #region ライブ計測
        /// <summary>
        /// 測定結果全削除確認
        /// </summary>
        public static readonly String MSG_Q_MEASUREMENT_RESULT_ALLDELETE = "MSG_Q_MEASUREMENT_RESULT_ALLDELETE";
        
        /// <summary>
        /// アスペクト比変更時の測定結果全削除確認
        /// </summary>
        public static readonly String MSG_Q_MEASUREMENT_RESULT_ALLDELETE_ASPECTRATIO_CHANGED = "MSG_Q_MEASUREMENT_RESULT_ALLDELETE_ASPECTRATIO_CHANGED";

        /// <summary>
        /// 測定結果個別削除確認
        /// </summary>
        public static readonly String MSG_Q_MEASUREMENT_RESULT_SELECTED_DELETE = "MSG_Q_MEASUREMENT_RESULT_SELECTED_DELETE";
        #endregion

        #region 全焦点/3D撮影
        /// <summary>
        /// 撮影枚数が 2 ～ 1000 の範囲でないため、撮影できない
        /// </summary>
        public static readonly System.String MSG_W_EXTEND_STEP_COUNT_OVER = "MSG_W_EXTEND_STEP_COUNT_OVER";

        /// <summary>
        /// 撮影のためのﾊｰﾄﾞﾃﾞｨｽｸ容量が足りないため、撮影できない
        /// </summary>
        public static readonly System.String MSG_W_EXTEND_HARDDISK_SPACE_NOT_ENOUGH = "MSG_W_EXTEND_HARDDISK_SPACE_NOT_ENOUGH";

        /// <summary>
        /// 上限位置がZ移動不可能な範囲に設定されているため、撮影できない
        /// </summary>
        public static readonly System.String MSG_W_EXTEND_Z_UPPER_POSITION_INVALID = "MSG_W_EXTEND_Z_UPPER_POSITION_INVALID";

        /// <summary>
        /// 下限位置がZ移動不可能な範囲に設定されているため、撮影できない
        /// </summary>
        public static readonly System.String MSG_W_EXTEND_Z_LOWER_POSITION_INVALID = "MSG_W_EXTEND_Z_LOWER_POSITION_INVALID";

        /// <summary>
        /// 逐次ﾓｰﾄﾞ時、これ以上Zを遠方方向に移動できない
        /// </summary>
        public static readonly System.String MSG_W_EXTEND_Z_MOVE_FAR_LIMIT_OVER = "MSG_W_EXTEND_Z_MOVE_FAR_LIMIT_OVER";

        /// <summary>
        /// 簡易全焦点(高速ﾓｰﾄﾞ/逐次ﾓｰﾄﾞ)の合成に失敗
        /// </summary>
        public static readonly System.String MSG_E_EXTEND_FOCUS_IMAGE_FILTER_ERROR = "MSG_E_EXTEND_FOCUS_IMAGE_FILTER_ERROR";

        /// <summary>
        /// 撮影中にﾚﾎﾞﾙﾊﾞが切り替えられたため、撮影を中止
        /// </summary>
        public static readonly System.String MSG_E_EXTEND_CHANGED_CURRENT_REVOLVER = "MSG_E_EXTEND_CHANGED_CURRENT_REVOLVER";

        /// <summary>
        /// ALMISﾗｲｾﾝｽﾀﾞﾝｸﾞﾙが未接続のため、撮影を中止
        /// </summary>
        public static readonly System.String MSG_W_EXTEND_ALMIS_LICENSEDONGLE_ERROR = "MSG_W_EXTEND_ALMIS_LICENSEDONGLE_ERROR";

        /// <summary>
        /// ｻﾎﾟｰﾄされない画像処理が選択されているため、撮影できない
        /// </summary>
        public static readonly System.String MSG_E_EXTEND_NOTSUPPORTED_IMAGEPROCESS_ERROR = "MSG_E_EXTEND_NOTSUPPORTED_IMAGEPROCESS_ERROR";

        /// <summary>
        /// CCDモードが超高精細なので、3D・全焦点撮影できない
        /// </summary>
        public static readonly System.String MSG_W_3D_EFI_CCDMODE_ERROR = "MSG_W_3D_EFI_CCDMODE_ERROR";

        /// <summary>
        /// Zリミット無効のため、撮影できない
        /// </summary>
        public static readonly System.String MSG_W_3D_EFI_Z_LIMIT_DISABLE_ERROR = "MSG_W_3D_EFI_Z_LIMIT_DISABLE_ERROR";

        /// <summary>
        /// 現在Z位置が撮影範囲外のため、撮影するかどうかを問う
        /// </summary>
        public static readonly System.String MSG_Q_3D_EFI_Z_CURRENT_POSITION_OUT_OF_RANGE = "MSG_Q_3D_EFI_Z_CURRENT_POSITION_OUT_OF_RANGE";

        /// <summary>
        /// 簡易計測が有効で計測結果がずれる可能性がある通知
        /// </summary>
        public static readonly System.String MSG_I_3D_EFI_MESUREMENT_ENABLED = "MSG_I_3D_EFI_MESUREMENT_ENABLED";
        #endregion 全焦点/3D撮影

        #region Preview
        /// <summary>
        /// 撮影可能な検鏡法がﾌﾟﾚﾋﾞｭｰ条件に存在しないため、ﾌﾟﾚﾋﾞｭｰ撮影できない
        /// </summary>
        public static readonly System.String MSG_I_PREVIEW_NOTHING_AVAILABLE_MICROSCOPY = "MSG_I_PREVIEW_NOTHING_AVAILABLE_MICROSCOPY";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ撮影中にｴﾗｰ発生
        /// </summary>
        public static readonly System.String MSG_E_PREVIEW_OCCURED_EXECUTING_ERROR = "MSG_E_PREVIEW_OCCURED_EXECUTING_ERROR";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾌｧｲﾙﾌｫｰﾏｯﾄ不正
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_FILE_FORMAT_INVALID = "MSG_W_PREVIEW_FILE_FORMAT_INVALID";

        /// <summary>
        /// ﾕｰｻﾞｰ設定ﾊﾟﾀｰﾝの登録が無い状態でﾌﾟﾚﾋﾞｭｰ保存しようとした
        /// </summary>
        public static readonly System.String MSG_I_PREVIEW_USER_SETTING_PATTERN_NOTHING = "MSG_I_PREVIEW_USER_SETTING_PATTERN_NOTHING";

        /// <summary>
        /// ﾕｰｻﾞｰ設定画面終了確認ﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_Q_PREVIEW_USER_SETTING_MODE_CLOSE = "MSG_Q_PREVIEW_USER_SETTING_MODE_CLOSE";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ撮影時と適用時のﾚﾎﾞﾙﾊﾞ番号が異なっているため、正しく適用されないﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_APPLY_REVOLVER_CHANGED = "MSG_W_PREVIEW_APPLY_REVOLVER_CHANGED";

        /// <summary>
        /// ﾕｰｻﾞｰ設定ﾊﾟﾀｰﾝ削除時の確認ﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_Q_PREVIEW_USER_PATTERN_DELETE_CONFIRMATION = "MSG_Q_PREVIEW_USER_PATTERN_DELETE_CONFIRMATION";

        /// <summary>
        /// ﾚﾎﾞﾙﾊﾞ中間位置のためﾌﾟﾚﾋﾞｭｰ起動できないﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_REVOLVER_POSITION_NEUTRAL = "MSG_W_PREVIEW_REVOLVER_POSITION_NEUTRAL";

        /// <summary>
        /// ｶﾚﾝﾄ対物ﾚﾝｽﾞ未登録のためﾌﾟﾚﾋﾞｭｰ起動できないﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_OBJECTIVELENS_NOT_REGISTERED = "MSG_W_PREVIEW_OBJECTIVELENS_NOT_REGISTERED";

        /// <summary>
        /// ﾍｯﾄﾞ構成が異なる観察条件ﾌｧｲﾙのため、ﾕｰｻﾞｰﾊﾟﾀｰﾝ登録できないﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_MISSMATCHED_HEAD_TYPE = "MSG_W_PREVIEW_MISSMATCHED_HEAD_TYPE";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ画面をｷｬﾝｾﾙして終了する時の確認ﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_Q_PREVIEW_APPLY_CANCEL_CONFIRMATION = "MSG_Q_PREVIEW_APPLY_CANCEL_CONFIRMATION";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ撮影時の対物ﾚﾝｽﾞと異なっており、現在対物ﾚﾝｽﾞでは適用できないﾊﾟﾀｰﾝを選択して適用しようとしたﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_APPLY = "MSG_W_PREVIEW_CANNOT_APPLY";

        /// <summary>
        /// 古いﾊﾞｰｼﾞｮﾝのﾌﾟﾚﾋﾞｭｰﾌｧｲﾙであるため、読み込みできないﾒｯｾｰｼﾞ
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_FILE_OLD_VERSION_CANNOT_LOAD = "MSG_W_PREVIEW_FILE_OLD_VERSION_CANNOT_LOAD";

        /// <summary>
        /// 対物レンズが登録されていないのでプレビューファイルを読込めません。対物レンズを登録してください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_LOAD_PREVIEWFILE_OBJECTIVELENS_NOT_REGISTERED = "MSG_W_PREVIEW_CANNOT_LOAD_PREVIEWFILE_OBJECTIVELENS_NOT_REGISTERED";

        /// <summary>
        /// ノーズピースが中間位置なのでプレビューファイルを読込めません。ノーズピースを切り替えてください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_LOAD_PREVIEWFILE_REVOLVER_POSITION_NEUTRAL = "MSG_W_PREVIEW_CANNOT_LOAD_PREVIEWFILE_REVOLVER_POSITION_NEUTRAL";

        /// <summary>
        /// 対物レンズが登録されていないのでプレビューファイルを保存できません。対物レンズを登録してください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_SAVE_PREVIEWFILE_OBJECTIVELENS_NOT_REGISTERED = "MSG_W_PREVIEW_CANNOT_SAVE_PREVIEWFILE_OBJECTIVELENS_NOT_REGISTERED";

        /// <summary>
        /// ノーズピースが中間位置なのでプレビューファイルを保存できません。ノーズピースを切り替えてください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_SAVE_PREVIEWFILE_REVOLVER_POSITION_NEUTRAL = "MSG_W_PREVIEW_CANNOT_SAVE_PREVIEWFILE_REVOLVER_POSITION_NEUTRAL";

        /// <summary>
        /// 対物レンズが登録されていないので観察条件を読込めません。対物レンズを登録してください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_LOAD_CONDITION_OBJECTIVELENS_NOT_REGISTERED = "MSG_W_PREVIEW_CANNOT_LOAD_CONDITION_OBJECTIVELENS_NOT_REGISTERED";

        /// <summary>
        /// ノーズピースが中間位置なので観察条件を読込めません。ノーズピースを切り替えてください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_LOAD_CONDITION_REVOLVER_POSITION_NEUTRAL = "MSG_W_PREVIEW_CANNOT_LOAD_CONDITION_REVOLVER_POSITION_NEUTRAL";

        /// <summary>
        /// 対物レンズが登録されていないので観察条件を削除できません。対物レンズを登録してください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_DELETE_CONDITION_OBJECTIVELENS_NOT_REGISTERED = "MSG_W_PREVIEW_CANNOT_DELETE_CONDITION_OBJECTIVELENS_NOT_REGISTERED";

        /// <summary>
        /// ノーズピースが中間位置なので観察条件を削除できません。ノーズピースを切り替えてください。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_CANNOT_DELETE_CONDITION_REVOLVER_POSITION_NEUTRAL = "MSG_W_PREVIEW_CANNOT_DELETE_CONDITION_REVOLVER_POSITION_NEUTRAL";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰ撮影時と適用時のHDRｵﾌﾟｼｮﾝ構成が異なっているため、正しく反映されないﾒｯｾｰｼﾞ。
        /// </summary>
        public static readonly System.String MSG_W_PREVIEW_APPLY_HDR_OPTION_CHANGED = "MSG_W_PREVIEW_APPLY_HDR_OPTION_CHANGED";
        #endregion Preview

        #region Sleeping

        /// <summary>
        /// Sleep中のダイアログのメッセージ分：Sleep中です。操作を行う場合は、解除ボタンにて解除してください。
        /// </summary>
        public static readonly System.String MSG_I_SLEEPING_NEED_RELEASE_TO_WAKEUP = "MSG_I_SLEEPING_NEED_RELEASE_TO_WAKEUP";

        #endregion Sleping

        #region 移動撮影
       
        /// <summary>
        /// ディスク容量不足
        /// </summary>
        public static readonly String MSG_E_ACQUISITION_HARDDISK_SPACE_NOT_ENOUGH = "MSG_E_ACQUISITION_HARDDISK_SPACE_NOT_ENOUGH";

        /// <summary>
        /// 動画撮影エラー
        /// </summary>
        public static readonly String MSG_E_MOVIE_NOT_SUPPORT_ERROR = "MSG_E_MOVIE_NOT_SUPPORT_ERROR";

        /// <summary>
        /// 簡易全焦点エラー
        /// </summary>
        public static readonly String MSG_E_SIMPLE_OMNIFOCAL_ERROR = "MSG_E_SIMPLE_OMNIFOCAL_ERROR";

        /// <summary>
        /// 登録座標がない
        /// </summary>
        public static readonly String MSG_E_NONE_COORDINATES_ERROR = "MSG_E_NONE_COORDINATES_ERROR";

        /// <summary>
        /// 撮影中止確認
        /// </summary>
        public static readonly String MSG_Q_MOVING_ACQUISITION_STOP = "MSG_Q_MOVING_ACQUISITION_STOP";

        /// <summary>
        /// 対物レンズ切り替えによる移動撮影中止
        /// </summary>
        public static readonly String MSG_E_MOVING_ACQUISITION_REVO_CHANGED_STOP1 = "MSG_E_MOVING_ACQUISITION_REVO_CHANGED_STOP1";

        /// <summary>
        /// 対物レンズ切り替えによる移動撮影中止
        /// </summary>
        public static readonly String MSG_E_MOVING_ACQUISITION_REVO_CHANGED_STOP2 = "MSG_E_MOVING_ACQUISITION_REVO_CHANGED_STOP2";
        #endregion

        #region 撮影

        /// <summary>
        /// 動画ファイルを保存するダイアログのタイトル
        /// </summary>
        public static readonly String MSG_I_MOVIE_SAVE_DIALOG_MOVIE_FILE_TITLE = "MSG_I_MOVIE_SAVE_DIALOG_MOVIE_FILE_TITLE";

        /// <summary>
        /// 動画ファイルを保存するダイアログのファイルフィルタ
        /// </summary>
        public static readonly String MSG_I_MOVIE_SAVE_DIALOG_MOVIE_FILE_FILTER = "MSG_I_MOVIE_SAVE_DIALOG_MOVIE_FILE_FILTER";

        /// <summary>
        /// 画像ファイルを開くダイアログのタイトル
        /// </summary>
        public static readonly String MSG_I_IMAGE_OPEN_DIALOG_IMAGE_FILE_TITLE = "MSG_I_IMAGE_OPEN_DIALOG_IMAGE_FILE_TITLE";

        /// <summary>
        /// 画像ファイルを開くダイアログのファイルフィルタ
        /// </summary>
        public static readonly String MSG_I_IMAGE_OPEN_DIALOG_IMAGE_FILE_FILTER = "MSG_I_IMAGE_OPEN_DIALOG_IMAGE_FILE_FILTER";

        /// <summary>
        /// 画像ファイルを開くダイアログのファイルフィルタの初期値 : jpg
        /// </summary>
        public static readonly String MSG_I_IMAGE_OPEN_DIALOG_IMAGE_FILE_FILTER_DEFAULT = "MSG_I_IMAGE_OPEN_DIALOG_IMAGE_FILE_FILTER_DEFAULT";

        /// <summary>
        /// スナップ撮影の中断の通知
        /// </summary>
        public static readonly String MSG_W_SNAP_CANCELED_NOT_SAVED = "MSG_W_SNAP_CANCELED_NOT_SAVED";

        /// <summary>
        /// HDR中の動画撮影実行を抑止する際に警告するメッセージ
        /// </summary>
        public static readonly System.String MSG_W_MOVIE_CANNOT_RECORDSTART_HDR_ENABLE = "MSG_W_MOVIE_CANNOT_RECORDSTART_HDR_ENABLE";
        #endregion

        #region 観察条件再現

        /// <summary>
        /// 観察条件再現のダイアログのタイトル
        /// </summary>
        public static readonly String MSG_I_REAPPEARANCE_DIALOG_TITLE = "MSG_I_REAPPEARANCE_DIALOG_TITLE";

        /// <summary>
        /// 観察条件再現のダイアログのZを移動の表示
        /// </summary>
        public static readonly String MSG_Q_SYSTEM_MOVE_Z = "MSG_Q_SYSTEM_MOVE_Z";

        /// <summary>
        /// 観察条件再現のダイアログのZ位置が下限リミットを超えて移動失敗
        /// </summary>
        public static readonly String MSG_W_CANNOT_MOVE_TO_Z_POS_WITH_Z_LIMIT = "MSG_W_CANNOT_MOVE_TO_Z_POS_WITH_Z_LIMIT";

        /// <summary>
        /// 観察条件再現のダイアログのZリミットが範囲外で設定失敗
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_Z_LIMIT_WITH_RANGE_OVER = "MSG_W_CANNOT_SET_Z_LIMIT_WITH_RANGE_OVER";

        /// <summary>
        /// 観察条件再現のダイアログで、HDR再現でApical解除の問い合わせ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_APICAL_FOR_HDR = "MSG_Q_RELEASE_APICAL_FOR_HDR";

        /// <summary>
        /// 観察条件再現のダイアログで、特定色強調でApicalの解除の問い合わせ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_APICAL_FOR_SPECIFIC_COLOR = "MSG_Q_RELEASE_APICAL_FOR_SPECIFIC_COLOR";

        /// <summary>
        /// 観察条件再現のダイアログで、Apical再現でHDRの解除の問い合わせ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_HDR_FOR_APICAL = "MSG_Q_RELEASE_HDR_FOR_APICAL";

        /// <summary>
        /// 観察条件再現のダイアログで、特定色強調でHDRの解除の問い合わせ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_HDR_FOR_SPECIFIC_COLOR = "MSG_Q_RELEASE_HDR_FOR_SPECIFIC_COLOR";

        /// <summary>
        /// 観察条件再現のダイアログで、Apical再現で特定色強調の解除の問い合わせ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_COLOR_FOR_APICAL = "MSG_Q_RELEASE_COLOR_FOR_APICAL";

        /// <summary>
        /// 観察条件再現のダイアログで、HDR再現で特定色強調の解除の問い合わせ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_COLOR_FOR_HDR = "MSG_Q_RELEASE_COLOR_FOR_HDR";

        /// <summary>
        /// 観察条件再現のダイアログで、レンズ相違で再現不可の通知
        /// </summary>
        public static readonly String MSG_W_CANNOT_DUPLICATE_WITH_DIFFERENT_LENS = "MSG_W_CANNOT_DUPLICATE_WITH_DIFFERENT_LENS";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の縦横比でオートフォーカス用ROIが再現不可の通知
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_AEROI = "MSG_W_CANNOT_SET_AEROI";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の縦横比で自動露出用ROIが再現不可の通知
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_AFROI = "MSG_W_CANNOT_SET_AFROI";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の縦横比でホワイトバランス用ROIが再現不可の通知
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_WBROI = "MSG_W_CANNOT_SET_WBROI";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の検鏡法で同軸照明が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_COAXIALLIGHT = "MSG_W_CANNOT_SET_COAXIALLIGHT";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の検鏡法でファイバー照明が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_FIBERLIGHT = "MSG_W_CANNOT_SET_FIBERLIGHT";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の検鏡法で輪帯照明が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_DFLIGHT = "MSG_W_CANNOT_SET_DFLIGHT";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の検鏡法でリング照明が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_RINGLIGHT = "MSG_W_CANNOT_SET_RINGLIGHT";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の検鏡法でAS絞りが設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_APERTURESTOP = "MSG_W_CANNOT_SET_APERTURESTOP";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の倍率指定方法でアスペクト比が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_ASPECT_MAGNIFICATIONSPECIFYMODE = "MSG_W_CANNOT_SET_ASPECT_MAGNIFICATIONSPECIFYMODE";

        /// <summary>
        /// 観察条件再現のダイアログで、現在の２画面状態で倍率指定方法が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_MAGNIFICATIONSPECIFYMODE_DUALSCREEN = "MSG_W_CANNOT_SET_MAGNIFICATIONSPECIFYMODE_DUALSCREEN";

        /// <summary>
        /// 観察条件再現のダイアログで、現在のアスペクト比で倍率指定方法が設定できない
        /// </summary>
        public static readonly String MSG_W_CANNOT_SET_MAGNIFICATIONSPECIFYMODE_ASPECT = "MSG_W_CANNOT_SET_MAGNIFICATIONSPECIFYMODE_ASPECT";

        /// <summary>
        /// 観察条件再現のダイアログで、観察設定の条件変更問い合わせ
        /// </summary>
        public static readonly String MSG_Q_CHANGE_OBSERVATION_SETTING = "MSG_Q_CHANGE_OBSERVATION_SETTING";

        /// <summary>
        /// 条件保存のダイアログタイトル
        /// </summary>
        public static readonly String MSG_I_SAVE_CONDITION_DIALOG_TITLE = "MSG_I_SAVE_CONDITION_DIALOG_TITLE";

        /// <summary>
        /// 条件読み出しのダイアログタイトル
        /// </summary>
        public static readonly String MSG_I_READ_CONDITION_DIALOG_TITLE = "MSG_I_READ_CONDITION_DIALOG_TITLE";

        /// <summary>
        /// 観察条件再現のダイアログで、レンズ交換
        /// </summary>
        public static readonly String MSG_W_SYSTEM_CHANGE_HIGHLENS = "MSG_W_SYSTEM_CHANGE_HIGHLENS";

        /// <summary>
        /// 観察条件再現のダイアログで、レンズ装着の要求
        /// </summary>
        public static readonly String MSG_W_SYSTEM_CHANGE_LOWLENS = "MSG_W_SYSTEM_CHANGE_LOWLENS";

        /// <summary>
        /// 観察条件再現のダイアログで、再現前にHDRを解除していいかの問合せ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_HDR_FOR_INIT = "MSG_Q_RELEASE_HDR_FOR_INIT";

        /// <summary>
        /// 観察条件再現のダイアログで、再現前にWiDERを解除していいかの問合せ
        /// </summary>
        public static readonly String MSG_Q_RELEASE_WIDER_FOR_INIT = "MSG_Q_RELEASE_WIDER_FOR_INIT";

        /// <summary>
        /// 観察条件再現のダイアログで、対物レンズに合わない検鏡法のファイル読み込みで再現不可の通知
        /// </summary>
        public static readonly String MSG_W_READ_EXPORT_FILR_UNMATCH_FOR_LENS = "MSG_W_READ_EXPORT_FILR_UNMATCH_FOR_LENS";
        #endregion

        #region 画像自動保存
        /// <summary>
        /// ﾌｫﾙﾀﾞﾊﾟｽ文字数が長すぎる時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FOLEDERPATH_LONG_ERROR = "MSG_W_AUTOSAVE_FOLEDERPATH_LONG_ERROR";

        /// <summary>
        /// ﾌｫﾙﾀﾞﾊﾟｽに固定ﾄﾞﾗｲﾌﾞではないまたはﾈｯﾄﾜｰｸﾄﾞﾗｲﾌﾞとして割り当てられたﾄﾞﾗｲﾌﾞではない、ﾄﾞﾗｲﾌﾞが設定されている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FOLEDERPATH_REMOVABLE_DRIVE_ERROR = "MSG_W_AUTOSAVE_FOLEDERPATH_REMOVABLE_DRIVE_ERROR";

        /// <summary>
        /// ﾌｫﾙﾀﾞﾊﾟｽに存在しないﾌｫﾙﾀﾞﾊﾟｽが設定されている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FOLEDERPATH_NOT_EXIST_ERROR = "MSG_W_AUTOSAVE_FOLEDERPATH_NOT_EXIST_ERROR";

        /// <summary>
        /// ﾌｫﾙﾀﾞﾊﾟｽに改行文字が入っている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FOLEDERPATH_BREAK_ERROR = "MSG_W_AUTOSAVE_FOLEDERPATH_BREAK_ERROR";

        /// <summary>
        /// ﾌｫﾙﾀﾞﾊﾟｽにｱｸｾｽ権がないﾌｫﾙﾀﾞが設定されている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FOLEDERPATH_ACCESS_RIGHT_ERROR = "MSG_W_AUTOSAVE_FOLEDERPATH_ACCESS_RIGHT_ERROR";

        /// <summary>
        /// ﾌｧｲﾙ名が長すぎる時の注意を促す
        /// </summary>ファイル名が長すぎます。
        public static readonly String MSG_W_AUTOSAVE_FILENAME_LONG_ERROR = "MSG_W_AUTOSAVE_FILENAME_LONG_ERROR";

        /// <summary>
        /// ﾌｧｲﾙ名に改行文字が入っている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FILENAME_BREAK_ERROR = "MSG_W_AUTOSAVE_FILENAME_BREAK_ERROR";

        /// <summary>
        /// ﾌｧｲﾙｶｳﾝﾀに数値以外の文字が入っている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FILECOUNTER_INVALID_LETTER_ERROR = "MSG_W_AUTOSAVE_FILECOUNTER_INVALID_LETTER_ERROR";

        /// <summary>
        /// ﾌｧｲﾙｶｳﾝﾀの範囲外の数値が入っている時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_FILECOUNTER_OUT_OF_RANGE_ERROR = "MSG_W_AUTOSAVE_FILECOUNTER_OUT_OF_RANGE_ERROR";

        /// <summary>
        /// ｺﾒﾝﾄが長すぎる時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_COMMENT_LONG_ERROR = "MSG_W_AUTOSAVE_COMMENT_LONG_ERROR";

        /// <summary>
        /// 保存するﾌｧｲﾙ形式が不正時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_INVALID_FILETYPE_ERROR = "MSG_W_AUTOSAVE_INVALID_FILETYPE_ERROR";

        /// <summary>
        /// ﾌｧｲﾙへの自動保存を行わない時の注意を促す
        /// </summary>
        public static readonly String MSG_W_AUTOSAVE_NOT_SAVE_FILE_ERROR = "MSG_W_AUTOSAVE_NOT_SAVE_FILE_ERROR";
        #endregion 画像自動保存

        #region Live Stitching

        /// <summary>
        /// 貼り合せ閾値以下で失敗
        /// </summary>
        public static readonly String MSG_W_LIVE_STITCHING_FAIL_OUT_OF_BOUND = "MSG_W_LIVE_STITCHING_FAIL_OUT_OF_BOUND";

        /// <summary>
        /// 貼り合せ制限数越えで失敗
        /// </summary>
        public static readonly String MSG_W_LIVE_STITCHING_FAIL_COUNT_OVERFLOW = "MSG_W_LIVE_STITCHING_FAIL_COUNT_OVERFLOW";

        /// <summary>
        /// 追従のり代不足で失敗
        /// </summary>
        public static readonly String MSG_W_LIVE_STITCHING_FAIL_LACK_OF_MOVING_MARGIN = "MSG_W_LIVE_STITCHING_FAIL_LACK_OF_MOVING_MARGIN";

        /// <summary>
        /// 画像サイズオーバーで失敗
        /// </summary>
        public static readonly String MSG_W_LIVE_STITCHING_FAIL_OVER_MAX_IMAGE_SIZE = "MSG_W_LIVE_STITCHING_FAIL_OVER_MAX_IMAGE_SIZE";

        /// <summary>
        /// 検鏡法の設定により撮影実行出来ない
        /// </summary>
        public static readonly String MSG_W_LIVE_STITCHING_FAIL_MICROSCOPY_DARK_FIELD = "MSG_W_LIVE_STITCHING_FAIL_MICROSCOPY_DARK_FIELD";

        /// <summary>
        /// Live貼り合せ画面終了確認メッセージ
        /// </summary>
        public static readonly String MSG_Q_LIVE_STITCHING_WINDOW_CLOSE = "MSG_Q_LIVE_STITCHING_WINDOW_CLOSE";

        /// <summary>
        /// Live貼り合せ中のレボルバ切り替えのエラー
        /// </summary>
        public static readonly System.String MSG_E_LIVE_STITCHING_FAIL_BY_REVOLVER_CHANGE = "MSG_E_LIVE_STITCHING_FAIL_BY_REVOLVER_CHANGE";

        /// <summary>
        /// 低倍ヘッド時の3D貼り合せのり代量警告
        /// </summary>
        public static readonly String MSG_W_LIVE_STITCHING_PASTE_FEE_FOR_LOWLENS_3D = "MSG_W_LIVE_STITCHING_PASTE_FEE_FOR_LOWLENS_3D";
        #endregion

        #region 電動貼り合わせ

        /// <summary>
        /// 電動貼り合わせ中止確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_STITCHING_COMFIRM_STOP = "MSG_Q_STITCHING_COMFIRM_STOP";

        /// <summary>
        /// 対物レンズ切り替えによる電動貼り合わせ中止メッセージ
        /// </summary>
        public static readonly System.String MSG_E_STITCHING_HEAD_ERROR = "MSG_E_STITCHING_HEAD_ERROR";

        /// <summary>
        /// ステージ停止ボタンによる電動貼り合わせ中止確認メッセージ
        /// </summary>
        public static readonly System.String MSG_E_STITCHING_STAGE_ERROR = "MSG_E_STITCHING_STAGE_ERROR";

        /// <summary>
        /// 電動貼り合わせ撮影失敗メッセージ
        /// </summary>
        public static readonly System.String MSG_E_STITCHING_ACQUISITION_FAILURE = "MSG_E_STITCHING_ACQUISITION_FAILURE";

        /// <summary>
        /// 電動貼り合わせのり代無しエラーメッセージ
        /// </summary>
        public static readonly System.String MSG_E_STITCHING_INFEASIBLE_PASTE_FEE = "MSG_E_STITCHING_INFEASIBLE_PASTE_FEE";

        /// <summary>
        /// 電動貼り合わせのり代不足確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_STITCHING_NOT_ENOUGH_PASTE_FEE = "MSG_Q_STITCHING_NOT_ENOUGH_PASTE_FEE";

        /// <summary>
        /// ハードディスク空き容量不足警告メッセージ
        /// </summary>
        public static readonly System.String MSG_E_MERGE_HDD_NOT_ENOUGH_ERROR = "MSG_E_MERGE_HDD_NOT_ENOUGH_ERROR";

        /// <summary>
        /// 貼り合わせ領域登録時条件とのズーム不一致警告メッセージ
        /// </summary>
        public static readonly System.String MSG_W_STITCHING_ZOOM_CONDITION_ERROR = "MSG_W_STITCHING_ZOOM_CONDITION_ERROR";

        /// <summary>
        /// 貼り合わせ領域登録時条件とのレンズ不一致警告メッセージ
        /// </summary>
        public static readonly System.String MSG_W_STITCHING_LENS_CONDITION_ERROR = "MSG_W_STITCHING_LENS_CONDITION_ERROR";

        /// <summary>
        /// 貼り合わせ領域登録時条件とのアスペクト比不一致警告メッセージ
        /// </summary>
        public static readonly System.String MSG_W_STITCHING_ASPECTRATIO_CONDITION_ERROR = "MSG_W_STITCHING_ASPECTRATIO_CONDITION_ERROR";

        /// <summary>
        /// 自動保存先フォルダ未設定警告メッセージ
        /// </summary>
        public static readonly System.String MSG_W_STITCHING_AUTO_SAVE_FOLDER_EMPTY = "MSG_W_STITCHING_AUTO_SAVE_FOLDER_EMPTY";

        /// <summary>
        /// 貼り合わせ個別画像の自動保存先フォルダ未設定警告メッセージ
        /// </summary>
        public static readonly System.String MSG_W_STITCHING_SIMPLE_AUTO_SAVE_FOLDER_EMPTY = "MSG_W_STITCHING_SIMPLE_AUTO_SAVE_FOLDER_EMPTY";

        /// <summary>
        /// 貼り合わせ領域を変更して撮影を続けるかの確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_STITCHING_OUT_RANGE_CONFIRMATION = "MSG_Q_STITCHING_OUT_RANGE_CONFIRMATION";

        /// <summary>
        /// 貼り合わせ領域が広くて登録できないことを通知するメッセージ
        /// </summary>
        public static readonly System.String MSG_E_STITCHING_REGISTRATION_ERROR = "MSG_E_STITCHING_REGISTRATION_ERROR";

        #endregion

        #region GRR
        /// <summary>
        /// GRR設定文字列NG警告メッセージ
        /// </summary>
        public static readonly System.String MSG_W_GRR_REGSTR_ERROR = "MSG_W_GRR_REGSTR_ERROR";

        /// <summary>
        /// 測定者名不正警告メッセージ
        /// </summary>
        public static readonly System.String MSG_E_GRR_OPERATOR_REGISTCHECK_ERROR = "MSG_E_GRR_OPERATOR_REGISTCHECK_ERROR";

        /// <summary>
        /// サンプル名不正警告メッセージ
        /// </summary>
        public static readonly System.String MSG_E_GRR_SAMPLE_REGISTCHECK_ERROR = "MSG_E_GRR_SAMPLE_REGISTCHECK_ERROR";

        /// <summary>
        /// GRR有効での処理実行不可警告メッセージ
        /// </summary>
        public static readonly System.String MSG_E_GRR_EXECUTION_ERROR = "MSG_E_GRR_EXECUTION_ERROR";

        /// <summary>
        /// ﾌｧｲﾙ名が長すぎる時の注意を促す
        /// </summary>
        public static readonly System.String MSG_W_GRR_FOLDERPATH_LONG_ERROR = "MSG_W_GRR_FOLDERPATH_LONG_ERROR";
        #endregion GRR

        #region 特定色強調

        /// <summary>
        /// 彩度が低くて特定色強調が実行できないことを通知するメッセージ
        /// </summary>
        public static readonly System.String MSG_W_LIVE_COLOR_CHROMA_ERROR = "MSG_W_LIVE_COLOR_CHROMA_ERROR";

        #endregion 特定色強調

        #region キャリブレーション
        /// <summary>
        /// キャリブレーションピッチが範囲外
        /// </summary>
        public static readonly System.String MSG_I_CALIBRATION_PITCH_OUT_OF_RANGE = "MSG_I_CALIBRATION_PITCH_OUT_OF_RANGE";

        /// <summary>
        /// キャリブレーション開始確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_CALIBRATION_START_CONFIRM = "MSG_Q_OBSERV_CALIBRATION_START_CONFIRM";

        /// <summary>
        /// 繰り返し性測定を開始します。よろしいですか？
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_REPETITION_START_CONFIRM = "MSG_Q_OBSERV_REPETITION_START_CONFIRM";
        
        /// <summary>
        /// キャリブレーション方向切り替え確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_CALIBRATION_CHANGE_DIRECTION_CONFIRM = "MSG_Q_OBSERV_CALIBRATION_CHANGE_DIRECTION_CONFIRM";

        /// <summary>
        /// キャリブレーション中止確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_CALIBRATION_STOP_CONFIRM = "MSG_Q_OBSERV_CALIBRATION_STOP_CONFIRM";

        /// <summary>
        /// 繰り返し性測定を中止します。よろしいですか？
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_REPETITION_STOP_CONFIRM = "MSG_Q_OBSERV_REPETITION_STOP_CONFIRM";

        /// <summary>
        /// キャリブレーション未登録確認メッセージ
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_CALIBRATION_NOREGIST_CONFIRM = "MSG_Q_OBSERV_CALIBRATION_NOREGIST_CONFIRM";

        /// <summary>
        /// キャリブレーション線幅計測結果がエラー閾値を超えた時の再施行確認するメッセージ
        /// </summary>
        public static readonly System.String MSG_Q_OBSERV_CALIBRATION_OVER_VALUE_RETRY_CONFIRM = "MSG_Q_OBSERV_CALIBRATION_OVER_VALUE_RETRY_CONFIRM";

        /// <summary>
        /// 確認または更新を行う対象を選択してください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_INQUIRE_SELECT_TARGET = "MSG_Q_CALIBRATION_INQUIRE_SELECT_TARGET";

        /// <summary>
        /// 実施内容を選択してください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_INQUIRE_SELECT_FUNCTION = "MSG_Q_CALIBRATION_INQUIRE_SELECT_FUNCTION";

        /// <summary>
        /// システム設定をキャリブレーション用に最適化します。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_INQUIRE_OPTIMIZE_FOR_CALIBRATION = "MSG_Q_CALIBRATION_INQUIRE_OPTIMIZE_FOR_CALIBRATION";

        /// <summary>
        /// 以下の準備完了後、開始ボタンを押下してください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_INQUIRE_START_AF = "MSG_Q_CALIBRATION_INQUIRE_START_AF";

        /// <summary>
        /// AF実行中です。しばらくお待ちください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_INQUIRE_RUNNING_AF = "MSG_Q_CALIBRATION_INQUIRE_RUNNING_AF";

        /// <summary>
        /// AFが完了しました。\nフォーカスがあっていない場合はZ位置を調節してください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_INQUIRE_START_MEASUREMENT = "MSG_Q_CALIBRATION_INQUIRE_START_MEASUREMENT";

        /// <summary>
        /// 処理中（X方向）です。しばらくお待ちください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_WAIT_X_CALIBRATION = "MSG_Q_CALIBRATION_WAIT_X_CALIBRATION";

        /// <summary>
        /// 処理中（Y方向）です。しばらくお待ちください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_WAIT_Y_CALIBRATION = "MSG_Q_CALIBRATION_WAIT_Y_CALIBRATION";

        /// <summary>
        /// X方向の処理が完了しました。\nY方向の処理を行います。サンプルの向きを変更後、継続ボタンを押下してください。
        /// </summary>
        public static readonly System.String MSG_Q_CALIBRATION_WAIT_X_TO_Y_CALIBRATION = "MSG_Q_CALIBRATION_WAIT_X_TO_Y_CALIBRATION";

        /// <summary>
        /// キャリブレーション処理が完了しました。
        /// </summary>
        public static readonly System.String MSG_I_CALIBRATION_END = "MSG_I_CALIBRATION_END";

        /// <summary>
        /// 繰り返し性測定が完了しました。
        /// </summary>
        public static readonly System.String MSG_I_REPETITION_MEASUREMENT_END = "MSG_I_REPETITION_MEASUREMENT_END";

        /// <summary>
        /// キャリブレーション処理が完了しました。実施結果をシステム校正値として反映する場合は設定名を入力して適用ボタンを押下して下さい。
        /// </summary>
        public static readonly System.String MSG_I_CALIBRATION_END_SAVE_INFO = "MSG_I_CALIBRATION_END_SAVE_INFO";

        /// <summary>
        /// キャリブレーションの保存が完了しました。
        /// </summary>
        public static readonly System.String MSG_I_CALIBRATION_SAVE_END = "MSG_I_CALIBRATION_SAVE_END";

        /// <summary>
        /// キャリブレーション処理中のレボルバ切り替えのエラー
        /// </summary>
        public static readonly System.String MSG_E_CALIBRATION_FAIL_BY_REVOLVER_CHANGE = "MSG_E_CALIBRATION_FAIL_BY_REVOLVER_CHANGE";

        /// <summary>
        /// 繰り返し性測定中にレボルバーが切り替わりました。繰り返し性測定を中止します。
        /// </summary>
        public static readonly System.String MSG_E_REPETITION_FAIL_BY_REVOLVER_CHANGE = "MSG_E_REPETITION_FAIL_BY_REVOLVER_CHANGE";

        /// <summary>
        /// ノーズピース中間位置によるキャリブレーション画面が開けない場合のメッセージ
        /// </summary>
        public static readonly System.String MSG_W_CALIBRATION_REVOLVER_POSITION_NEUTRAL = "MSG_W_CALIBRATION_REVOLVER_POSITION_NEUTRAL";

        /// <summary>
        /// レボルバーへの対物レンズ未登録によるキャリブレーション画面が開けない場合のメッセージ
        /// </summary>
        public static readonly System.String MSG_W_CALIBRATION_OBJECTIVELENS_NOT_REGISTERED = "MSG_W_CALIBRATION_OBJECTIVELENS_NOT_REGISTERED";

        /// <summary>
        /// 検鏡法が条件に合わないことによるキャリブレーション画面が開けない場合のメッセージ
        /// </summary>
        public static readonly System.String MSG_W_CALIBRATION_DIALOG_NOT_OPEN_BY_MICROSCOPY = "MSG_W_CALIBRATION_DIALOG_NOT_OPEN_BY_MICROSCOPY";

        /// <summary>
        /// アスペクト比が合わないことによるキャリブレーション画面が開けない場合のメッセージ
        /// </summary>
        public static readonly System.String MSG_W_CALIBRATION_DIALOG_NOT_OPEN_BY_ASPECTRATIO = "MSG_W_CALIBRATION_DIALOG_NOT_OPEN_BY_ASPECTRATIO";

        #endregion キャリブレーション

        #region ビイング
        /// <summary>
        /// CCD Modeは標準ではないので、ビニングはONに設定できない。
        /// </summary>
        public static readonly System.String MSG_W_LIVE_CANNOT_SET_BINNING_ON = "MSG_W_LIVE_CANNOT_SET_BINNING_ON";

        /// <summary>
        /// ビニングはONなので、CCD Modeは高精細、超高精細に設定できない。
        /// </summary>
        public static readonly System.String MSG_W_SNAP_CANNOT_SET_FINE_SUPERFINE = "MSG_W_SNAP_CANNOT_SET_FINE_SUPERFINE";
        #endregion ビイング

        #region システム構成確認変更
        /// <summary>
        /// オプション構成変更ダイアログ・ウィンドウタイトル
        /// </summary>
        public static readonly String MSG_I_SYSCONFIGURATION_DIALOG_TITLE = "MSG_I_SYSCONFIGURATION_DIALOG_TITLE";

        /// <summary>
        /// オプション構成変更ダイアログ・ウィンドウメッセージ
        /// </summary>
        public static readonly String MSG_I_SYSCONFIGURATION_DIALOG_MESSAGE = "MSG_I_SYSCONFIGURATION_DIALOG_MESSAGE";

        /// <summary>
        /// オプション構成変更再起動ダイアログ・ウィンドウタイトル
        /// </summary>
        public static readonly String MSG_I_SYSCONFIGURATION_RESTART_DIALOG_TITLE = "MSG_I_SYSCONFIGURATION_RESTART_DIALOG_TITLE";

        /// <summary>
        /// オプション構成変更再起動ダイアログ・ウィンドウメッセージ
        /// </summary>
        public static readonly String MSG_I_SYSCONFIGURATION_RESTART_DIALOG_MESSAGE = "MSG_I_SYSCONFIGURATION_RESTART_DIALOG_MESSAGE";

        #endregion システム構成確認変更

        #region オプション
        /// <summary>
        /// オプション構成変更ダイアログ・ウィンドウタイトル
        /// </summary>
        public static readonly String MSG_I_OPTIONSETTINGS_DIALOG_TITLE = "MSG_I_OPTIONSETTINGS_DIALOG_TITLE";

        /// <summary>
        /// オプション構成変更ダイアログ・メッセージ
        /// </summary>
        public static readonly String MSG_I_OPTIONSETTINGS_DIALOG_MESSAGE = "MSG_I_OPTIONSETTINGS_DIALOG_MESSAGE";

        #endregion オプション

        #region Recipe

        /// <summary>
        /// レシピ有効時に未選択で撮影開始したときのメッセージ
        /// </summary>
        public static readonly System.String MSG_W_RECIEPE_NOSELECTED_ERROR = "MSG_W_RECIEPE_NOSELECTED_ERROR";

        #endregion

        #region マップ

        /// <summary>
        /// マップ画像取得ボタンツールチップ
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_TOOLTIP_MAP_IMAGE = "CAP_NAVIGATION_TOOLTIP_MAP_IMAGE";

        /// <summary>
        /// 原点移動ボタンツールチップ
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_TOOLTIP_ORIGIN = "CAP_NAVIGATION_TOOLTIP_ORIGIN";

        /// <summary>
        /// サンプル交換位置移動ボタンツールチップ
        /// </summary>
        public static readonly System.String CAP_NAVIGATION_TOOLTIP_SAMPLE_EXCHANGE_POSITION = "CAP_NAVIGATION_TOOLTIP_SAMPLE_EXCHANGE_POSITION";

        /// <summary>
        /// Live貼り合せ画像をマップに使用している際、上書きしていいか問合せる
        /// </summary>
        public static readonly System.String MSG_Q_LIVE_STITCHING_MAP_IMAGE_UPDATE = "MSG_Q_LIVE_STITCHING_MAP_IMAGE_UPDATE";

        /// <summary>
        /// Live貼り合せ画像をマップに使用する際の警告
        /// </summary>
        public static readonly System.String MSG_W_MAP_UPDATE_DISABLED_FROM_ZOOM_FOR_LIVE_STITCHING = "MSG_W_MAP_UPDATE_DISABLED_FROM_ZOOM_FOR_LIVE_STITCHING";
        #endregion

        #region Workflow例外
        /// <summary>
        /// 再起動を促す障害を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_NEED_RESTART = "MSG_E_EXCEPTION_NEED_RESTART";

        /// <summary>
        /// Hardware障害を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_HARDWARE = "MSG_E_EXCEPTION_HARDWARE";

        /// <summary>
        /// ｶﾒﾗのﾊｰﾄﾞｳｪｱ障害を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_CAMERA_HARDWARE = "MSG_E_EXCEPTION_CAMERA_HARDWARE";

        /// <summary>
        /// 顕微鏡のﾊｰﾄﾞｳｪｱ障害を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_HARDWARE = "MSG_E_EXCEPTION_MICROSCOPE_HARDWARE";

        /// <summary>
        /// 顕微鏡のファンロックエラーを通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_FANLOCK = "MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_FANLOCK";

        /// <summary>
        /// 顕微鏡のメンテナンスモードエラーを通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_MAINTENANCE_MODE = "MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_MAINTENANCE_MODE";

        /// <summary>
        /// 顕微鏡の組み合わせ不正(ユニット接続の組合せが異常、対象部位がない)を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_INVALID_COMBINATION = "MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_INVALID_COMBINATION";

        /// <summary>
        /// 顕微鏡の低倍ヘッド活線挿抜エラーを通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_LOWHEAD_LOST = "MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_LOWHEAD_LOST";

        /// <summary>
        /// 顕微鏡のユーザ操作による近接限界位置接触エラーを通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_STOPPED_NEAR_LIMIT = "MSG_E_EXCEPTION_MICROSCOPE_HARDWARE_STOPPED_NEAR_LIMIT";

        /// <summary>
        /// ｽﾃｰｼﾞのﾊｰﾄﾞｳｪｱ障害を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_STAGE_HARDWARE = "MSG_E_EXCEPTION_STAGE_HARDWARE";

        /// <summary>
        /// ﾊｰﾄﾞｳｪｱｺﾏﾝﾄﾞﾀｲﾑｱｳﾄ障害を通知するﾒｯｾｰｼﾞﾘｿｰｽのKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_HARDWARE_TIMEOUT = "MSG_E_EXCEPTION_HARDWARE_TIMEOUT";

        /// <summary>
        /// Workflowのﾊﾟﾗﾒｰﾀ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_WORKFLOW_PARAMETER = "MSG_E_EXCEPTION_WORKFLOW_PARAMETER";

        /// <summary>
        /// Device内包例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_DEVICEWRAPPED = "MSG_E_EXCEPTION_DEVICEWRAPPED";

        /// <summary>
        /// Workflow状態管理例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_WORKFLOWSTATUS = "MSG_E_EXCEPTION_WORKFLOWSTATUS";

        /// <summary>
        /// DeviceLayer例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_DEVICELAYER = "MSG_E_EXCEPTION_DEVICELAYER";

        /// <summary>
        /// ｶﾒﾗﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_CAMERA_DOMAIN = "MSG_E_EXCEPTION_CAMERA_DOMAIN";

        /// <summary>
        /// ｲﾒｰｼﾞﾌﾟﾛｾｽﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_IMAGEPROCESS_DOMAIN = "MSG_E_EXCEPTION_IMAGEPROCESS_DOMAIN";

        /// <summary>
        /// ALMIS3セキュリティー例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        /// <remarks>ライセンスキー未接続/初期化失敗</remarks>
        public static readonly String MSG_E_EXCEPTION_ALMIS3_SECURITY = "MSG_E_EXCEPTION_ALMIS3_SECURITY";

        /// <summary>
        /// OutOfMemory例外を通知するﾒｯｾｰｼﾞｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_OUT_OF_MEMORY = "MSG_E_EXCEPTION_OUT_OF_MEMORY";

        /// <summary>
        /// DAOﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_DAO_DOMAIN = "MSG_E_EXCEPTION_DAO_DOMAIN";

        /// <summary>
        /// 顕微鏡ﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_DOMAIN = "MSG_E_EXCEPTION_MICROSCOPE_DOMAIN";

        /// <summary>
        /// 検鏡法と装着ﾚﾝｽﾞの不整合を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_UNMATCH_FOR_LENS = "MSG_E_EXCEPTION_UNMATCH_FOR_LENS";

        /// <summary>
        /// 顕微鏡状態変更時例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MICROSCOPE_STATUS_CHANGE = "MSG_E_EXCEPTION_MICROSCOPE_STATUS_CHANGE";

        /// <summary>
        /// ﾚﾝｽﾞ未登録例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_NO_REGISTED_LENS = "MSG_E_EXCEPTION_NO_REGISTED_LENS";

        /// <summary>
        /// 近接リミット設定エラー（現在位置が近接限界位置より近接）例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_REGIST_NEARLIMIT_ERROR_BY_CURRENT_POINT = "MSG_E_EXCEPTION_REGIST_NEARLIMIT_ERROR_BY_CURRENT_POINT";

        /// <summary>
        /// レボルバー切り替えエラー
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_REVOLVER_CHANGED_ON_PROHIBITED_FUNCTION = "MSG_E_EXCEPTION_REVOLVER_CHANGED_ON_PROHIBITED_FUNCTION";

        /// <summary>
        /// ﾌﾟﾚﾋﾞｭｰﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_PREVIEW_DOMAIN = "MSG_E_EXCEPTION_PREVIEW_DOMAIN";

        /// <summary>
        /// ｽﾃｰｼﾞﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_STAGE_DOMAIN = "MSG_E_EXCEPTION_STAGE_DOMAIN";

        /// <summary>
        /// ｽﾃｰｼﾞ初期化例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_STAGE_INITIALIZE = "MSG_E_EXCEPTION_STAGE_INITIALIZE";

        /// <summary>
        /// ｽﾃｰｼﾞ緊急停止を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_EMERGENCY_STAGE_STOP = "MSG_E_EXCEPTION_EMERGENCY_STAGE_STOP";

        /// <summary>
        /// ｽﾃｰｼﾞ範囲外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_MOVE_STAGE_OUT_OF_RANGE = "MSG_E_EXCEPTION_MOVE_STAGE_OUT_OF_RANGE";

        /// <summary>
        /// サンプル交換位置登録範囲外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_REGISTER_SAMPLE_EXCHANGE_POSITION_OUT_OF_RANGE = "MSG_E_EXCEPTION_REGISTER_SAMPLE_EXCHANGE_POSITION_OUT_OF_RANGE";

        /// <summary>
        /// アライメント設定値無効のﾀﾞｲｱﾛｸﾞの文言
        /// </summary>
        public static readonly System.String MSG_E_EXCEPTION_ALIGNMENT_PARAM_ERROR = "MSG_E_EXCEPTION_ALIGNMENT_PARAM_ERROR";

        /// <summary>
        /// 予期しないライブ停止例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_UNEXPECTED_LIVE_STOP = "MSG_E_EXCEPTION_UNEXPECTED_LIVE_STOP";

        /// <summary>
        /// 低倍でレンズ未装着例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_LOW_LENS_DISCONNECTION = "MSG_E_EXCEPTION_LOW_LENS_DISCONNECTION";

        /// <summary>
        /// XMLﾌｧｲﾙﾌｫｰﾏｯﾄ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_XML_FILE_FORMAT = "MSG_E_EXCEPTION_XML_FILE_FORMAT";

        /// <summary>
        /// XMLﾌｧｲﾙｱｸｾｽ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_XML_FILE_ACCESS = "MSG_E_EXCEPTION_XML_FILE_ACCESS";

        /// <summary>
        /// オプション構成不正例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_INVALID_OPTION = "MSG_E_EXCEPTION_INVALID_OPTION";

        /// <summary>
        /// Zoom動作中のレボ切り替えエラーﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_W_REVO_CHANGED_DURING_ZOOM = "MSG_W_REVO_CHANGED_DURING_ZOOM";

        /// <summary>
        /// 後処理結合ﾄﾞﾒｲﾝ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽ
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_PROCESSJOIN_DOMAIN = "MSG_E_EXCEPTION_PROCESSJOIN_DOMAIN";

        #region ２画面
        /// <summary>ファイル読み込みエラー</summary>
        public static readonly String MSG_E_EXCEPTION_DUALPIC_LOAD_IMAGE = "MSG_E_EXCEPTION_DUAL_PIC_LOAD_IMAGE";

        /// <summary>ファイルサイズ上限エラー</summary>
        public static readonly String MSG_E_EXCEPTION_DUALPIC_SIZE_LIMIT_MAX = "MSG_E_EXCEPTION_DUALPIC_SIZE_LIMIT_MAX";
        
        /// <summary>ファイルサイズ下限エラー</summary>
        public static readonly String MSG_E_EXCEPTION_DUALPIC_SIZE_LIMIT_MIN = "MSG_E_EXCEPTION_DUALPIC_SIZE_LIMIT_MIN";
        
        /// <summary>その他のエラー</summary>
        public static readonly String MSG_E_EXCEPTION_DUALPIC_OTHER = "MSG_E_EXCEPTION_DUALPIC_OTHER";
        #endregion ２画面

        #endregion Workflow例外

        #region Application例外
        /// <summary>
        /// ｼﾅﾘｵﾊﾟﾗﾒｰﾀI/F例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_SCENARIO_PARAMETER_INTERFACE = "MSG_E_EXCEPTION_SCENARIO_PARAMETER_INTERFACE";

        /// <summary>
        /// BusinessObjectI/F例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_BUSINESS_OBJECT_INTERFACE = "MSG_E_EXCEPTION_BUSINESS_OBJECT_INTERFACE";

        /// <summary>
        /// 貼り合せ画像ｻｲｽﾞｵｰﾊﾞｰ例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_STITCHING_IMAGESIZE_OVER = "MSG_E_EXCEPTION_STITCHING_IMAGESIZE_OVER";

        /// <summary>
        /// 致命的なUI例外を通知するﾒｯｾｰｼﾞﾘｿｰｽKEY
        /// </summary>
        public static readonly String MSG_E_EXCEPTION_UI_LAYER_FATAL = "MSG_E_EXCEPTION_UI_LAYER_FATAL";
        #endregion Application例外

        /// <summary>全画面に移行する前に、総合倍率指定モードから、ズーム倍率指定モードに移行しても良いかを問い合わせる。</summary>
        public static readonly String MSG_Q_TRANSITION_TO_ZOOM_MAG_MODE_BEFORE_FULL_SCREEN = "MSG_Q_TRANSITION_TO_ZOOM_MAG_MODE_BEFORE_FULL_SCREEN";

        /// <summary>2画面に移行する前に、総合倍率指定モードから、ズーム倍率指定モードに移行しても良いかを問い合わせる。</summary>
        public static readonly String MSG_Q_TRANSITION_TO_ZOOM_MAG_MODE_BEFORE_DUAL_SCREEN = "MSG_Q_TRANSITION_TO_ZOOM_MAG_MODE_BEFORE_DUAL_SCREEN";

        /// <summary>アスペクト比を4:3に変更する前に、総合倍率指定モードから、ズーム倍率指定モードに移行しても良いかを問い合わせる。</summary>
        public static readonly String MSG_Q_TRANSITION_TO_ZOOM_MAG_MODE_BEFORE_4_3_ASPECT_RATIO = "MSG_Q_TRANSITION_TO_ZOOM_MAG_MODE_BEFORE_4_3_ASPECT_RATIO";

        /// <summary>総合倍率指定モードに移行する前に、1画面、1:1比率に切り替えても良いかを問い合わせる。</summary>
        public static readonly String MSG_Q_TRANSITION_TO_SINGLE_SCREEN_1_1_ASPECT_RATIO = "MSG_Q_TRANSITION_TO_SINGLE_SCREEN_1_1_ASPECT_RATIO";

        /// <summary>総合倍率指定モードの場合、ROIズーム機能が無効であることを通知する。</summary>
        public static readonly String MSG_I_ROI_ZOOM_FUNCTION_IS_NOT_AVAILABLE_IN_OVERALL_MAG_MODE = "MSG_I_ROI_ZOOM_FUNCTION_IS_NOT_AVAILABLE_IN_OVERALL_MAG_MODE";
    }
}
