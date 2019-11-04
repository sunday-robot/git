
package jp.co.olympus.fluoview.core.enabler.condition;

/**
FunctionID class for FunctionEnabler
*/
@SuppressWarnings("nls")
public class FunctionID {
  /** アスペクト1:1 設定可 */
  public static String F_LSM_ASPECT_1_1 = "F_LSM_ASPECT_1_1";
  /** アスペクト4:3 設定可 */
  public static String F_LSM_ASPECT_4_3 = "F_LSM_ASPECT_4_3";
  /** Rotation 可能 */
  public static String F_LSM_ROTATION = "F_LSM_ROTATION";
  /** 設定可能なスキャンサイズ(List) */
  public static String F_LSM_SCAN_SIZE = "F_LSM_SCAN_SIZE";
  /** Pan 設定可能(不可とは0以外の設定ができないということ) */
  public static String F_LSM_PAN = "F_LSM_PAN";
  /** Zoom 設定可能(不可とは0以外の設定ができないということ) */
  public static String F_LSM_ZOOM = "F_LSM_ZOOM";
  /** lambda シリーズ設定可能 */
  public static String F_LSM_LAMBDA = "F_LSM_LAMBDA";
  /** 設定可能なLSMのスキャンスピード */
  public static String F_LSM_IMAGING_SCAN_SPEED = "F_LSM_IMAGING_SCAN_SPEED";
  /** フォーカススキャン設定の可否 */
  public static String F_FOCUS_SCAN_SETTING = "F_FOCUS_SCAN_SETTING";
  /** フォーカススキャン開始の可否 */
  public static String F_FOCUS_SCAN_START = "F_FOCUS_SCAN_START";
  /** シリーズインターバル時間設定の可否 */
  public static String F_LSM_INTERVAL_SETTING = "F_LSM_INTERVAL_SETTING";
  /** レゾナント設定可能 */
  public static String F_RESONANT = "F_RESONANT";
  /** 往復スキャン設定可能 */
  public static String F_ROUNDTRIP = "F_ROUNDTRIP";
  /** ピンホール自動設定が可能 */
  public static String F_AUTO_PINHOLE = "F_AUTO_PINHOLE";
  /** 走査方法の変更可否 */
  public static String F_ONEWAY_ROUNDTRIP_CHANGE = "F_ONEWAY_ROUNDTRIP_CHANGE";
  /** デバイスの変更可否 */
  public static String F_GALVANO_RESONANT_CHANGE = "F_GALVANO_RESONANT_CHANGE";
  /** アスペクト比の変更可否 */
  public static String F_LSM_ASPECT_CHANGE = "F_LSM_ASPECT_CHANGE";
  /** ピンホール設定が可能 */
  public static String F_PINHOLE = "F_PINHOLE";
  /** チャンネルの追加削除の可否 */
  public static String F_LSM_CHANNEL_SETTING_CHANGE = "F_LSM_CHANNEL_SETTING_CHANGE";
  /** LSMのTimeLapse有効・無効切り替え機能 */
  public static String F_LSM_TIMELAPSE_SET_ENABLE = "F_LSM_TIMELAPSE_SET_ENABLE";
  /** LSMのZ Stack有効・無効切り替え機能 */
  public static String F_LSM_ZSTACK_SET_ENABLE = "F_LSM_ZSTACK_SET_ENABLE";
  /** BI光路への切り替えが可能 */
  public static String F_BI_SETTING = "F_BI_SETTING";
  /** LSMのTシリーズパラメータが入力可能 */
  public static String F_LSM_SERIES_T_SETTINGS = "F_LSM_SERIES_T_SETTINGS";
  /** CAMERAのTシリーズパラメータが入力可能 */
  public static String F_CAMERA_SERIES_T_SETTINGS = "F_CAMERA_SERIES_T_SETTINGS";
  /** LSMフェーズ切り替え */
  public static String F_LSM_PHASE_CHANGE = "F_LSM_PHASE_CHANGE";
  /** 通常モード設定可否 */
  public static String F_LSM_VBF = "F_LSM_VBF";
  /** ScanSettingsが変更可能 */
  public static String F_LSM_SCANSETTING = "F_LSM_SCANSETTING";
  /** CELL32設定が変更可能 */
  public static String F_LSM_CELL32_SCANSETTING = "F_LSM_CELL32_SCANSETTING";
  /** PMT設定が変更可能 */
  public static String F_LSM_PMT_SCANSETTING = "F_LSM_PMT_SCANSETTING";
  /** LSMシリーズスキャンが可能 */
  public static String F_LSM_SERIES_SCAN = "F_LSM_SERIES_SCAN";
  /** LSMリピートスキャンが可能 */
  public static String F_LSM_REPEAT_SCAN = "F_LSM_REPEAT_SCAN";
  /** LSMのTかZのどちらかが絶対選択されているモード */
  public static String F_LSM_SERIES_T_OR_Z_SET_ABSOLUTELY_MODE = "F_LSM_SERIES_T_OR_Z_SET_ABSOLUTELY_MODE";
  /** 刺激スキャナ変更可能 */
  public static String F_LSM_STIMULUS_SCANNER_CHANGE = "F_LSM_STIMULUS_SCANNER_CHANGE";
  /** 設定可能なLSMのスキャンスピード */
  public static String F_LSM_STIMULATION_SCAN_SPEED = "F_LSM_STIMULATION_SCAN_SPEED";
  /** 光刺激が可能 */
  public static String F_LSM_STIMULATION_SCAN = "F_LSM_STIMULATION_SCAN";
  /** カメライシリーズイメージングが可能 */
  public static String F_CAMERA_SERIES_IMAGING = "F_CAMERA_SERIES_IMAGING";
  /** カメラリピートイメージングが可能 */
  public static String F_CAMERA_REPEAT_IMAGING = "F_CAMERA_REPEAT_IMAGING";
  /** LSM Channel のON/OFF変更可否  */
  public static String F_LSM_CHANNEL_CHANGE = "F_LSM_CHANNEL_CHANGE";
  /** 32CellPMTの分解能3nm設定可否 */
  public static String F_WAVERESOLUTION_3 = "F_WAVERESOLUTION_3";
  /** 32CellPMTの分解能設定可否10nm */
  public static String F_WAVERESOLUTION_10 = "F_WAVERESOLUTION_10";
  /** チャンネルグループ編集可能 */
  public static String F_CHANNEL_GROUP_EDIT = "F_CHANNEL_GROUP_EDIT";
  /** λレンジ編集可能 */
  public static String F_LAMBDA_RANGE_EDIT = "F_LAMBDA_RANGE_EDIT";
  /** サチュレーション埋め込み設定編集可能 */
  public static String F_CELL_SATURATION_DETECTION_CHANGE = "F_CELL_SATURATION_DETECTION_CHANGE";
  /** レーザー割付の変更可能 */
  public static String F_SP_LASER_WAVELENGTH_CHANGE = "F_SP_LASER_WAVELENGTH_CHANGE";
  /** 32CellPMTの分解能変更可否 */
  public static String F_WAVERESOLUTION_CHANGE = "F_WAVERESOLUTION_CHANGE";
  /** 32Cellの測光波長域変更可否 */
  public static String F_32CH_PMT_WAVERANGE = "F_32CH_PMT_WAVERANGE";
  /** サチュレーション埋め込み設定可能 */
  public static String F_CELL_SATURATION_DETECTION = "F_CELL_SATURATION_DETECTION";
  /** CLIP用ImagingROiの作成可能最大数 */
  public static String F_LSM_CLIP_IMAGING_ROI_MAX_COUNT = "F_LSM_CLIP_IMAGING_ROI_MAX_COUNT";
  /** Line用ImagingROIの作成可能最大数 */
  public static String F_LSM_LINE_IMAGING_ROI_MAX_COUNT = "F_LSM_LINE_IMAGING_ROI_MAX_COUNT";
  /** FreeLine用ImagingROIの作成可能最大数 */
  public static String F_LSM_FREE_LINE_IMAGING_ROI_MAX_COUNT = "F_LSM_FREE_LINE_IMAGING_ROI_MAX_COUNT";
  /** Point用ImagingROIの作成可能最大数 */
  public static String F_LSM_POINT_IMAGING_ROI_MAX_COUNT = "F_LSM_POINT_IMAGING_ROI_MAX_COUNT";
  /** MultiPoint用ImagingROIの作成可能最大数 */
  public static String F_LSM_MULTI_POINT_IMAGING_ROI_MAX_COUNT = "F_LSM_MULTI_POINT_IMAGING_ROI_MAX_COUNT";
  /** Mapping用ImagingROIの作成可能最大数 */
  public static String F_LSM_MAPPING_IMAGING_ROI_MAX_COUNT = "F_LSM_MAPPING_IMAGING_ROI_MAX_COUNT";
  /** StimulationROIの作成可能最大数 */
  public static String F_LSM_STIMULATION_ROI_MAX_COUNT = "F_LSM_STIMULATION_ROI_MAX_COUNT";
  /** AnalsysiROIの作成可能最大数 */
  public static String F_ANALYSIS_ROI_MAX_COUNT = "F_ANALYSIS_ROI_MAX_COUNT";
  /** ZoomINROIの作成可能最大数 */
  public static String F_ZOOMIN_ROI_MAX_COUNT = "F_ZOOMIN_ROI_MAX_COUNT";
  /** Annotationの作成可能最大数 */
  public static String F_ANNOTATION_MAX_COUNT = "F_ANNOTATION_MAX_COUNT";
  /** ガルバノ片道スキャンの時はCLIP用ImagingROIが複数作成できる(LIST_TYPEマージの修正完了までの暫定定義) */
  public static String F_LSM_CLIP_IMAGING_ROI_MORE_CREATED = "F_LSM_CLIP_IMAGING_ROI_MORE_CREATED";
  /** 作成 */
  public static String F_LSM_LINE_IMAGING_ROI_CREATE = "F_LSM_LINE_IMAGING_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_FREE_LINE_IMAGING_ROI_CREATE = "F_LSM_FREE_LINE_IMAGING_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_POINT_IMAGING_ROI_CREATE = "F_LSM_POINT_IMAGING_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_MULTI_POINT_IMAGING_ROI_CREATE = "F_LSM_MULTI_POINT_IMAGING_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_MAPPING_IMAGING_ROI_CREATE = "F_LSM_MAPPING_IMAGING_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_CLIP_IMAGING_RECTANGLE_ROI_CREATE = "F_LSM_CLIP_IMAGING_RECTANGLE_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_CLIP_IMAGING_OTHER_ROI_CREATE = "F_LSM_CLIP_IMAGING_OTHER_ROI_CREATE";
  /** 移動 */
  public static String F_LSM_IMAGING_ROI_MOVE = "F_LSM_IMAGING_ROI_MOVE";
  /** リサイズ */
  public static String F_LSM_IMAGING_ROI_RESIZE = "F_LSM_IMAGING_ROI_RESIZE";
  /** 回転 */
  public static String F_LSM_IMAGING_ROI_ROTATE = "F_LSM_IMAGING_ROI_ROTATE";
  /** 削除 */
  public static String F_LSM_IMAGING_ROI_DELETE = "F_LSM_IMAGING_ROI_DELETE";
  /** 作成 */
  public static String F_LSM_ZOOMIN_ROI_CREATE = "F_LSM_ZOOMIN_ROI_CREATE";
  /** 移動 */
  public static String F_LSM_ZOOMIN_ROI_MOVE = "F_LSM_ZOOMIN_ROI_MOVE";
  /** リサイズ */
  public static String F_LSM_ZOOMIN_ROI_RESIZE = "F_LSM_ZOOMIN_ROI_RESIZE";
  /** 回転 */
  public static String F_LSM_ZOOMIN_ROI_ROTATE = "F_LSM_ZOOMIN_ROI_ROTATE";
  /** 削除 */
  public static String F_LSM_ZOOMIN_ROI_DELETE = "F_LSM_ZOOMIN_ROI_DELETE";
  /** 作成 */
  public static String F_LSM_ANALYSIS_ROI_CREATE = "F_LSM_ANALYSIS_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_CLIP_STIMULATION_ROI_CREATE = "F_LSM_CLIP_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_LINE_STIMULATION_ROI_CREATE = "F_LSM_LINE_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_FREE_LINE_STIMULATION_ROI_CREATE = "F_LSM_FREE_LINE_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_POINT_STIMULATION_ROI_CREATE = "F_LSM_POINT_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_MULTIPOINT_STIMULATION_ROI_CREATE = "F_LSM_MULTIPOINT_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_MAPPING_STIMULATION_ROI_CREATE = "F_LSM_MAPPING_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_CAV_TORNADO_STIMULATION_ROI_CREATE = "F_LSM_CAV_TORNADO_STIMULATION_ROI_CREATE";
  /** 作成 */
  public static String F_LSM_CLV_TORNADO_STIMULATION_ROI_CREATE = "F_LSM_CLV_TORNADO_STIMULATION_ROI_CREATE";
  /** 移動 */
  public static String F_LSM_STIMULATION_ROI_MOVE = "F_LSM_STIMULATION_ROI_MOVE";
  /** リサイズ */
  public static String F_LSM_STIMULATION_ROI_RESIZE = "F_LSM_STIMULATION_ROI_RESIZE";
  /** 回転 */
  public static String F_LSM_STIMULATION_ROI_ROTATE = "F_LSM_STIMULATION_ROI_ROTATE";
  /** 削除 */
  public static String F_LSM_STIMULATION_ROI_DELETE = "F_LSM_STIMULATION_ROI_DELETE";
  /** 移動 */
  public static String F_LSM_ANALYSIS_ROI_MOVE = "F_LSM_ANALYSIS_ROI_MOVE";
  /** リサイズ */
  public static String F_LSM_ANALYSIS_ROI_RESIZE = "F_LSM_ANALYSIS_ROI_RESIZE";
  /** 回転 */
  public static String F_LSM_ANALYSIS_ROI_ROTATE = "F_LSM_ANALYSIS_ROI_ROTATE";
  /** 削除 */
  public static String F_LSM_ANALYSIS_ROI_DELETE = "F_LSM_ANALYSIS_ROI_DELETE";
  /** 作成 */
  public static String F_CREATE_ANNOTATION = "F_CREATE_ANNOTATION";
  /** 移動 */
  public static String F_MOVE_ANNOTATION = "F_MOVE_ANNOTATION";
  /** リサイズ */
  public static String F_RESIZE_ANNOTATION = "F_RESIZE_ANNOTATION";
  /** 回転 */
  public static String F_ROTATION_ANNOTATION = "F_ROTATION_ANNOTATION";
  /** 作成 */
  public static String F_CAMERA_IMAGING_ROI_CREATE = "F_CAMERA_IMAGING_ROI_CREATE";
  /** 移動 */
  public static String F_CAMERA_IMAGING_ROI_MOVE = "F_CAMERA_IMAGING_ROI_MOVE";
  /** リサイズ */
  public static String F_CAMERA_IMAGING_ROI_RESIZE = "F_CAMERA_IMAGING_ROI_RESIZE";
  /** 回転 */
  public static String F_CAMERA_IMAGING_ROI_ROTATE = "F_CAMERA_IMAGING_ROI_ROTATE";
  /** 削除 */
  public static String F_CAMERA_IMAGING_ROI_DELETE = "F_CAMERA_IMAGING_ROI_DELETE";
  /** 作成上限数 */
  public static String F_CAMERA_IMAGING_ROI_MAX_COUNT = "F_CAMERA_IMAGING_ROI_MAX_COUNT";
  /** 移動 */
  public static String F_MOVE_AUXILIARY = "F_MOVE_AUXILIARY";
  /** 作成 */
  public static String F_CREATE_AUXILIARY = "F_CREATE_AUXILIARY";
  /** 水平なLineImagingROIしか作成できない制約 */
  public static String F_LSM_LINE_IMAGING_ROI_HORIZONTAL_CONSTRAINT = "F_LSM_LINE_IMAGING_ROI_HORIZONTAL_CONSTRAINT";
  /** 作成 */
  public static String F_LSM_IMAGING_ROI_SET = "F_LSM_IMAGING_ROI_SET";
  /** LiveViewにImagingROIを表示する機能。(ClipROIを設定した状態でスキャンすると、OFFになる。ClipROIを設定せずにスキャンするとONになる。) */
  public static String F_LSM_DISPLAY_IMAGING_ROI_ON_LIVE_VIEW = "F_LSM_DISPLAY_IMAGING_ROI_ON_LIVE_VIEW";
  /** LiveViewにStimulationROIを表示する機能。(Lineスキャンすると、OFFになる。ImagingROIなし、あるいはClipスキャンするとONになる。) */
  public static String F_LSM_DISPLAY_STIMULATION_ROI_ON_LIVE_VIEW = "F_LSM_DISPLAY_STIMULATION_ROI_ON_LIVE_VIEW";
  /** ラインシーケンシャル設定可能 */
  public static String F_SEQUENTIAL_LINE = "F_SEQUENTIAL_LINE";
  /** フレームシーケンシャル設定可能 */
  public static String F_SEQUENTIAL_FRAME = "F_SEQUENTIAL_FRAME";
  /** グループ追加可能 */
  public static String F_GROUP_ADDABLE = "F_GROUP_ADDABLE";
  /** ラインカルマン設定可能 */
  public static String F_KALMAN_LINE = "F_KALMAN_LINE";
  /** フレームカルマン設定可能 */
  public static String F_KALMAN_FRAME = "F_KALMAN_FRAME";
  /** シーケンシャル無しを選択可能 */
  public static String F_SEQUENTIAL_NONE = "F_SEQUENTIAL_NONE";
  /** シーケンシャル設定の変更可能 */
  public static String F_SEQUENTIAL_CHANGE = "F_SEQUENTIAL_CHANGE";
  /** LSMカルマン設定変更可能 */
  public static String F_LSM_KALMAN_SETTING_CHANGE = "F_LSM_KALMAN_SETTING_CHANGE";
  /** グループ選択可能 */
  public static String F_GROUP_SELECTABLE = "F_GROUP_SELECTABLE";
  /** 開始入力トリガーでONCEが設定可能 */
  public static String F_INPUT_START_TRIGGER_ONCE = "F_INPUT_START_TRIGGER_ONCE";
  /** 開始入力トリガーでEACHTIMEが設定可能 */
  public static String F_INPUT_START_TRIGGER_EACHTIME = "F_INPUT_START_TRIGGER_EACHTIME";
  /** 開始入力トリガーでFRAMEが設定可能 */
  public static String F_INPUT_START_TRIGGER_FRAME = "F_INPUT_START_TRIGGER_FRAME";
  /** 対物レンズの変更可能 */
  public static String F_MICROSCOPE_OBJECTIVE_LENS_CHANGE = "F_MICROSCOPE_OBJECTIVE_LENS_CHANGE";
  /** DIALampのON/OFF変更可能 */
  public static String F_MICROSCOPE_DIA_LAMP_ON_OFF_CHANGE = "F_MICROSCOPE_DIA_LAMP_ON_OFF_CHANGE";
  /** DIALampの光量変更可能 */
  public static String F_MICROSCOPE_DIA_LAMP_INTENSITY_CHANGE = "F_MICROSCOPE_DIA_LAMP_INTENSITY_CHANGE";
  /** ND Filterの変更可能 */
  public static String F_MICROSCOPE_ND_FILTER_CHANGE = "F_MICROSCOPE_ND_FILTER_CHANGE";
  /** ミラー1の変更可能 */
  public static String F_MICROSCOPE_MIRROR_1_CHANGE = "F_MICROSCOPE_MIRROR_1_CHANGE";
  /** ミラー2の変更可能 */
  public static String F_MICROSCOPE_MIRROR_2_CHANGE = "F_MICROSCOPE_MIRROR_2_CHANGE";
  /** コンデンサーレンズの変更可能 */
  public static String F_MICROSCOPE_CONDENSER_LENS_CHANGE = "F_MICROSCOPE_CONDENSER_LENS_CHANGE";
  /** ASの変更可能 */
  public static String F_MICROSCOPE_AS_CHANGE = "F_MICROSCOPE_AS_CHANGE";
  /** ポラライザの変更可能 */
  public static String F_MICROSCOPE_POLARIZER_CHANGE = "F_MICROSCOPE_POLARIZER_CHANGE";
  /** シャッターの変更可能 */
  public static String F_MICROSCOPE_SHUTTER_CHANGE = "F_MICROSCOPE_SHUTTER_CHANGE";
  /** EPI EX Filterの変更可能 */
  public static String F_MICROSCOPE_EX_FILTER_CHANGE = "F_MICROSCOPE_EX_FILTER_CHANGE";
  /** EM Filterの変更可能 */
  public static String F_MICROSCOPE_EM_FILTER_CHANGE = "F_MICROSCOPE_EM_FILTER_CHANGE";
  /** DIC Prismの変更可能 */
  public static String F_MICROSCOPE_DIC_PRISM_CHANGE = "F_MICROSCOPE_DIC_PRISM_CHANGE";
  /** 透過検出器のシャッターON/OFF変更可能 */
  public static String F_MICROSCOPE_TD_SHUTTER_ON_OFF_CHANGE = "F_MICROSCOPE_TD_SHUTTER_ON_OFF_CHANGE";
  /** Zステージ移動可能 */
  public static String F_MICROSCOPE_ZSTAGE_MOVE = "F_MICROSCOPE_ZSTAGE_MOVE";
  /** Zシリーズパラメータ変更可能 */
  public static String F_LSM_SERIES_Z_SETTINGS = "F_LSM_SERIES_Z_SETTINGS";
  /** Z基準位置の移動 */
  public static String F_MICROSCOPE_Z_ORIGINPOSITION_MOVE = "F_MICROSCOPE_Z_ORIGINPOSITION_MOVE";
  /** Z駆動デバイス切り替え可能 */
  public static String F_MICROSCOPE_ZSTAGE_CHANGE = "F_MICROSCOPE_ZSTAGE_CHANGE";
  /** エスケープの実行可否 */
  public static String F_ESCAPE = "F_ESCAPE";
  /** 自動同焦、同軸補正ON/OFFの変更可能 */
  public static String F_MICROSCOPE_AUTO_PARFOCAL_ADJUSTMENT_CHANGE = "F_MICROSCOPE_AUTO_PARFOCAL_ADJUSTMENT_CHANGE";
  /** Xの同軸補正値の変更可能 */
  public static String F_MICROSCOPE_PARFOCAL_ADJUSTMENT_X_CHANGE = "F_MICROSCOPE_PARFOCAL_ADJUSTMENT_X_CHANGE";
  /** Yの同軸補正値の変更可能 */
  public static String F_MICROSCOPE_PARFOCAL_ADJUSTMENT_Y_CHANGE = "F_MICROSCOPE_PARFOCAL_ADJUSTMENT_Y_CHANGE";
  /** Zの同焦補正値の変更可能 */
  public static String F_MICROSCOPE_PARFOCAL_ADJUSTMENT_Z_CHANGE = "F_MICROSCOPE_PARFOCAL_ADJUSTMENT_Z_CHANGE";
  /** Zステージ移動の緊急停止が可能 */
  public static String F_MICROSCOPE_ZSTAGE_MOVE_URGENT_STOP_ENABLE = "F_MICROSCOPE_ZSTAGE_MOVE_URGENT_STOP_ENABLE";
  /** Zステージ移動の緊急停止コントロールの表示状態 */
  public static String F_MICROSCOPE_ZSTAGE_MOVE_URGENT_STOP_VISIBLE = "F_MICROSCOPE_ZSTAGE_MOVE_URGENT_STOP_VISIBLE";
  /** LSMのTシリーズのOn/Offが可能 */
  public static String F_LSM_SERIES_T_CHANGE = "F_LSM_SERIES_T_CHANGE";
  /** LSMのZシリーズのOn/Offが可能 */
  public static String F_LSM_SERIES_Z_CHANGE = "F_LSM_SERIES_Z_CHANGE";
  /** 励起DMターレットの設定変更可否 */
  public static String F_EX_DM_TURRET = "F_EX_DM_TURRET";
  /** ADMターレットの設定変更可否 */
  public static String F_ADM_TURRET = "F_ADM_TURRET";
  /** 蛍光DMターレットの設定変更可否 */
  public static String F_EM_DM_TURRET = "F_EM_DM_TURRET";
  /** ノッチフィルタターレットの設定変更可否 */
  public static String F_NOTCHFILTER_TURRET = "F_NOTCHFILTER_TURRET";
  /** バリアフィルタターレットの設定変更可否 */
  public static String F_BF_TURRET = "F_BF_TURRET";
  /** 蛍光ビームシフタの設定変更可否 */
  public static String F_EM_BEAM_SHIFTER = "F_EM_BEAM_SHIFTER";
  /** カメラ_画像サイズ */
  public static String F_CAMERA_IMAGESIZE = "F_CAMERA_IMAGESIZE";
  /** カメラ_冷却モード */
  public static String F_CAMERA_COOLINGMODE = "F_CAMERA_COOLINGMODE";
  /** カメラ_ファン */
  public static String F_CAMERA_FAN = "F_CAMERA_FAN";
  /** カメラ_クロック数 */
  public static String F_CAMERA_CLOCK = "F_CAMERA_CLOCK";
  /** カメラ_取り込みモード */
  public static String F_CAMERA_CAPTUREMODE = "F_CAMERA_CAPTUREMODE";
  /** カメラ_カラーモード/ビット幅 */
  public static String F_CAMERA_COLORDEPTH = "F_CAMERA_COLORDEPTH";
  /** カメラ_チャネルのON/OFF */
  public static String F_CAMERA_CHANNELSWITCH = "F_CAMERA_CHANNELSWITCH";
  /** カメラ_EM Gain */
  public static String F_CAMERA_EMGAIN = "F_CAMERA_EMGAIN";
  /** カメラ_Gain */
  public static String F_CAMERA_GAIN = "F_CAMERA_GAIN";
  /** カメラ_Offset */
  public static String F_CAMERA_OFFSET = "F_CAMERA_OFFSET";
  /** Camera_露出時間 */
  public static String F_CAMERA_EXPOSURETIME = "F_CAMERA_EXPOSURETIME";
  /** CameraのZ Stack有効・無効切り替え機能 */
  public static String F_CAMERA_ZSTACK_SET_ENABLE = "F_CAMERA_ZSTACK_SET_ENABLE";
  /** CAMERAカルマン設定変更可能 */
  public static String F_CAMERA_KALMAN_SETTING_CHANGE = "F_CAMERA_KALMAN_SETTING_CHANGE";
  /** プロトコールファイル上書き保存機能 */
  public static String F_PROTOCOL_SAVE = "F_PROTOCOL_SAVE";
  /** プロトコールファイル保存機能 */
  public static String F_PROTOCOL_SAVE_AS = "F_PROTOCOL_SAVE_AS";
  /** プロトコールファイル閉じる機能 */
  public static String F_PROTOCOL_CLOSE = "F_PROTOCOL_CLOSE";
  /** プロトコール「Prepare」機能 */
  public static String F_PROTOCOL_PREPARE = "F_PROTOCOL_PREPARE";
  /** プロトコール実行開始・停止機能 */
  public static String F_PROTOCOL_START_STOP = "F_PROTOCOL_START_STOP";
  /** プロトコール一時停止・再開機能 */
  public static String F_PROTOCOL_SUSPEND_RESUME = "F_PROTOCOL_SUSPEND_RESUME";
  /** プロトコールファイル選択機能 */
  public static String F_PROTOCOL_FILE_SELECTION = "F_PROTOCOL_FILE_SELECTION";
  /** プロトコール有効・無効切り替え機能 */
  public static String F_PROTOCOL_SET_ENABLE = "F_PROTOCOL_SET_ENABLE";
  /** プロトコールグループ選択機能 */
  public static String F_PROTOCOL_SELECT_GROUP = "F_PROTOCOL_SELECT_GROUP";
  /** プロトコール選択機能 */
  public static String F_PROTOCOL_SELECT_PROTOCOL = "F_PROTOCOL_SELECT_PROTOCOL";
  /** プロトコールグループ移動機能 */
  public static String F_PROTOCOL_MOVE_GROUP = "F_PROTOCOL_MOVE_GROUP";
  /** タスク追加機能 */
  public static String F_PROTOCOL_ADD_TASK = "F_PROTOCOL_ADD_TASK";
  /** タスク削除機能 */
  public static String F_PROTOCOL_DELETE_TASK = "F_PROTOCOL_DELETE_TASK";
  /** 選択中タスク表示機能 */
  public static String F_PROTOCOL_SHOW_CURRENT_TASK = "F_PROTOCOL_SHOW_CURRENT_TASK";
  /** タスク移動機能 */
  public static String F_PROTOCOL_MOVE_TASK = "F_PROTOCOL_MOVE_TASK";
  /** 実行時間表示機能 */
  public static String F_PROTOCOL_SHOW_EXECUTION_TIME = "F_PROTOCOL_SHOW_EXECUTION_TIME";
  /** タスクパラメーター適用機能 */
  public static String F_PROTOCOL_APPLY_TASK_PARAMETERS = "F_PROTOCOL_APPLY_TASK_PARAMETERS";
  /** タスク後処理グループ表示機能 */
  public static String F_PROTOCOL_SHOW_GROUP_POST_PROCESS_INFO = "F_PROTOCOL_SHOW_GROUP_POST_PROCESS_INFO";
  /** タスク後処理設定機能 */
  public static String F_PROTOCOL_SET_POST_PROCESS_FILE = "F_PROTOCOL_SET_POST_PROCESS_FILE";
  /** タスク後処理条件設定機能 */
  public static String F_PROTOCOL_SET_POST_PROCESS_CONDITION = "F_PROTOCOL_SET_POST_PROCESS_CONDITION";
  /** タスク後処理アクション設定機能 */
  public static String F_PROTOCOL_SET_POST_PROCESS_ACTION = "F_PROTOCOL_SET_POST_PROCESS_ACTION";
  /** タスクその他情報編集機能 */
  public static String F_PROTOCOL_SHOW_GROUP_OTHER_TASK_INFO = "F_PROTOCOL_SHOW_GROUP_OTHER_TASK_INFO";
  /** タスク有効・無効設定機能 */
  public static String F_PROTOCOL_SET_ENABLE_TASK = "F_PROTOCOL_SET_ENABLE_TASK";
  /** プロトコル編集機能 */
  public static String F_PROTOCOL_EDIT_PROTOCOL = "F_PROTOCOL_EDIT_PROTOCOL";
  /** スタンダードモード切替機能 */
  public static String F_PROTOCOL_STANDARD_MODE = "F_PROTOCOL_STANDARD_MODE";
  /** 新規プロトコールファイル作成機能 */
  public static String F_PROTOCOL_CREATE_NEW_FILE = "F_PROTOCOL_CREATE_NEW_FILE";
  /** プロトコールファイルオープン機能 */
  public static String F_PROTOCOL_OPEN = "F_PROTOCOL_OPEN";
  /** 一時停止待ちメッセージ表示 */
  public static String F_PROTOCOL_WAITING_PAUSE_MSG = "F_PROTOCOL_WAITING_PAUSE_MSG";
  /** LiveViewに表示中のLSM画像をOIF、OIB形式で保存可能 */
  public static String F_LSM_LIVE_SAVE = "F_LSM_LIVE_SAVE";
  /** ImageViewに表示中のLSM画像をOIF、OIB形式で保存可能 */
  public static String F_IMAGE_SAVE_AS = "F_IMAGE_SAVE_AS";
  /** HDR保存先選択
機能 */
  public static String F_FILE_OPERATION_SELECT_FOLDER_LOCATION = "F_FILE_OPERATION_SELECT_FOLDER_LOCATION";
  /** HDR保存先
表示機能 */
  public static String F_FILE_OPERATION_SHOW_FOLDER_LOCATION = "F_FILE_OPERATION_SHOW_FOLDER_LOCATION";
  /** HDR保存名
指定機能 */
  public static String F_FILE_OPERATION_SET_FILE_NAME = "F_FILE_OPERATION_SET_FILE_NAME";
  /** ライブ解析設定の変更可否 */
  public static String F_LIVE_ANALYSIS_SETTINGS_CHANGE = "F_LIVE_ANALYSIS_SETTINGS_CHANGE";
  /** メンテナンス ScanerDelay変更可否 */
  public static String F_MAINTENANCE_SCANNER_DELAY_SETTING = "F_MAINTENANCE_SCANNER_DELAY_SETTING";
  /** Dye and Channel Settingの選択可否 */
  public static String F_DYE_AND_CHANNEL_DIALOG = "F_DYE_AND_CHANNEL_DIALOG";
}
