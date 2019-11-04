
package jp.co.olympus.fluoview.core.enabler.condition;

/**
StateID class for FunctionEnabler
*/
@SuppressWarnings("nls")
public class StateID {
  /** ガルバノスキャンが設定されている */
  public static String S_GALVANO = "S_GALVANO";
  /** レゾナントスキャンが設定されている */
  public static String S_RESONANT = "S_RESONANT";
  /** 片道スキャンが設定されている */
  public static String S_ONEWAY = "S_ONEWAY";
  /** 往復スキャンが設定されている */
  public static String S_ROUNDTRIP = "S_ROUNDTRIP";
  /** LSMのスキャンサイズに64が設定されている */
  public static String S_LSM_SCAN_SIZE_64 = "S_LSM_SCAN_SIZE_64";
  /** LSMのスキャンサイズに128が設定されている */
  public static String S_LSM_SCAN_SIZE_128 = "S_LSM_SCAN_SIZE_128";
  /** LSMのスキャンサイズに256が設定されている */
  public static String S_LSM_SCAN_SIZE_256 = "S_LSM_SCAN_SIZE_256";
  /** LSMのスキャンサイズに320が設定されている */
  public static String S_LSM_SCAN_SIZE_320 = "S_LSM_SCAN_SIZE_320";
  /** LSMのスキャンサイズに512が設定されている */
  public static String S_LSM_SCAN_SIZE_512 = "S_LSM_SCAN_SIZE_512";
  /** LSMのスキャンサイズに640が設定されている */
  public static String S_LSM_SCAN_SIZE_640 = "S_LSM_SCAN_SIZE_640";
  /** LSMのスキャンサイズに800が設定されている */
  public static String S_LSM_SCAN_SIZE_800 = "S_LSM_SCAN_SIZE_800";
  /** LSMのスキャンサイズに1024が設定されている */
  public static String S_LSM_SCAN_SIZE_1024 = "S_LSM_SCAN_SIZE_1024";
  /** LSMのスキャンサイズに2048が設定されている */
  public static String S_LSM_SCAN_SIZE_2048 = "S_LSM_SCAN_SIZE_2048";
  /** LSMのスキャンサイズに4096が設定されている */
  public static String S_LSM_SCAN_SIZE_4096 = "S_LSM_SCAN_SIZE_4096";
  /** ガルバノ（往復）スキャンスピード0.25 */
  public static String S_SCAN_SPEED_0_25 = "S_SCAN_SPEED_0_25";
  /** ガルバノ（往復）スキャンスピード0.5 */
  public static String S_SCAN_SPEED_0_5 = "S_SCAN_SPEED_0_5";
  /** リファレンス画像がスキャンできる状態 */
  public static String S_LSM_REFERENCE_SCAN_MODE = "S_LSM_REFERENCE_SCAN_MODE";
  /** CLIPスキャンが行われる状態(イメージング用CLIP系 ROIがある) */
  public static String S_LSM_CLIP_SCAN_MODE = "S_LSM_CLIP_SCAN_MODE";
  /** LINEスキャンが行われる状態(イメージング用LINE ROIがある) */
  public static String S_LSM_LINE_SCAN_MODE = "S_LSM_LINE_SCAN_MODE";
  /** FREELINEスキャンが行われる状態(イメージング用FREELINE ROIがある) */
  public static String S_LSM_FREE_LINE_SCAN_MODE = "S_LSM_FREE_LINE_SCAN_MODE";
  /** POINTスキャンが行われる状態(イメージング用POINT ROIがある) */
  public static String S_LSM_POINT_SCAN_MODE = "S_LSM_POINT_SCAN_MODE";
  /** MULTI POINTスキャンが行われる状態(イメージング用MULTI POINT ROIがある) */
  public static String S_LSM_MULTI_POINT_SCAN_MODE = "S_LSM_MULTI_POINT_SCAN_MODE";
  /** MAPPINGスキャンが行われる状態(イメージング用MAPPING ROIがある) */
  public static String S_LSM_MAPPING_SCAN_MODE = "S_LSM_MAPPING_SCAN_MODE";
  /** Lambdaモードではない */
  public static String S_CELL32_VBF_MODE = "S_CELL32_VBF_MODE";
  /** Lambdaモードである */
  public static String S_CELL32_LAMBDA_MODE = "S_CELL32_LAMBDA_MODE";
  /** ImagingROI用のToolが選択されていない */
  public static String S_LSM_IMAGING_ROI_TOOL_DESELECTED = "S_LSM_IMAGING_ROI_TOOL_DESELECTED";
  /** ImagingROI用のToolが選択された */
  public static String S_LSM_IMAGING_ROI_TOOL_SELECTED = "S_LSM_IMAGING_ROI_TOOL_SELECTED";
  /** StimulationROI用のToolが選択されていない */
  public static String S_LSM_STIMULATION_ROI_TOOL_DESELECTED = "S_LSM_STIMULATION_ROI_TOOL_DESELECTED";
  /** StimulationROI用のToolが選択された */
  public static String S_LSM_STIMULATION_ROI_TOOL_SELECTED = "S_LSM_STIMULATION_ROI_TOOL_SELECTED";
  /** レボルバー停止中 */
  public static String S_REVOLVER_STOP = "S_REVOLVER_STOP";
  /** レボルバー動作中 */
  public static String S_REVOLVER_MOVING = "S_REVOLVER_MOVING";
  /** 電動デバイスアイドル中 */
  public static String S_MOTOR_DEVICE_IDLING = "S_MOTOR_DEVICE_IDLING";
  /** イメージングアイドル中 */
  public static String S_LSM_IMAGING_IDLING = "S_LSM_IMAGING_IDLING";
  /** リピートスキャン中 */
  public static String S_LSM_REPEAT_SCANNING = "S_LSM_REPEAT_SCANNING";
  /** シリーズスキャン中 */
  public static String S_LSM_SERIES_SCANNING = "S_LSM_SERIES_SCANNING";
  /** レスト中 */
  public static String S_LSM_RESTING = "S_LSM_RESTING";
  /** DIA Lampの光量、AS以外の電動デバイスが変更中 */
  public static String S_MOTOR_DEVICE_MOVING = "S_MOTOR_DEVICE_MOVING";
  /** Camera シリーズ設定がなされていない */
  public static String S_CAMERA_SERIES_NONE = "S_CAMERA_SERIES_NONE";
  /** Camera Zシリーズが設定されている */
  public static String S_CAMERA_SERIES_Z = "S_CAMERA_SERIES_Z";
  /** Camera Tシリーズが設定されている */
  public static String S_CAMERA_SERIES_T = "S_CAMERA_SERIES_T";
  /** Camera ZTシリーズが設定されている */
  public static String S_CAMERA_SERIES_ZT = "S_CAMERA_SERIES_ZT";
  /** LSM シリーズ設定がなされていない */
  public static String S_LSM_SERIES_NONE = "S_LSM_SERIES_NONE";
  /** LSM Zシリーズが設定されている */
  public static String S_LSM_SERIES_Z = "S_LSM_SERIES_Z";
  /** LSM Tシリーズが設定されている */
  public static String S_LSM_SERIES_T = "S_LSM_SERIES_T";
  /** LSM ZTシリーズが設定されている */
  public static String S_LSM_SERIES_ZT = "S_LSM_SERIES_ZT";
  /** LSM Lambda Em シリーズが設定されている */
  public static String S_LSM_SERIES_LEM = "S_LSM_SERIES_LEM";
  /** LSM Lambda Em Zシリーズが設定されている */
  public static String S_LSM_SERIES_LEMZ = "S_LSM_SERIES_LEMZ";
  /** LSM Lambda Em Tシリーズが設定されている */
  public static String S_LSM_SERIES_LEMT = "S_LSM_SERIES_LEMT";
  /** LSM Lambda Em ZTシリーズが設定されている */
  public static String S_LSM_SERIES_LEMZT = "S_LSM_SERIES_LEMZT";
  /** 全フェーズの中でSIMレーザが選択されていない */
  public static String S_NO_SIM_LASER_IN_ALL_PHASE = "S_NO_SIM_LASER_IN_ALL_PHASE";
  /** SIMレーザが1つは選択されている(全フェーズの中にひとつでも) */
  public static String S_SIM_LASER_IN_ALL_PHASE = "S_SIM_LASER_IN_ALL_PHASE";
  /** ガルバノ＜＞レゾナント切り替え中ではない */
  public static String S_LSM_IMAGING_SCANNER_NOT_CHANGING = "S_LSM_IMAGING_SCANNER_NOT_CHANGING";
  /** ガルバノ＜＞レゾナント切り替え中 */
  public static String S_LSM_IMAGING_SCANNER_CHANGING = "S_LSM_IMAGING_SCANNER_CHANGING";
  /** VBF-LAMBDAモード切替中ではない */
  public static String S_LSM_SCANMODE_NOT_CHANGING = "S_LSM_SCANMODE_NOT_CHANGING";
  /** VBF-LAMBDAモード切替中 */
  public static String S_LSM_SCANMODE_CHANGING = "S_LSM_SCANMODE_CHANGING";
  /** フォーカススキャン実行中でない */
  public static String S_LSM_FOCUS_SCAN_OFF = "S_LSM_FOCUS_SCAN_OFF";
  /** フォーカススキャン準備中 */
  public static String S_LSM_FOCUS_SCAN_PREPARING = "S_LSM_FOCUS_SCAN_PREPARING";
  /** フォーカススキャン実行中 */
  public static String S_LSM_FOCUS_SCAN_SCANNING = "S_LSM_FOCUS_SCAN_SCANNING";
  /** ZOOM IN ROIがない状態(ZOOM IN ROIを使用せずに、Pan X、Pan Y、Zoomを指定した場合は、この状態になることに注意。) */
  public static String S_LSM_ZOOM_IN_ROI_DOES_NOT_EXIST = "S_LSM_ZOOM_IN_ROI_DOES_NOT_EXIST";
  /** ZOOM IN ROIがある状態(ZOOM IN ROIを使用せずに、Pan X、Pan Y、Zoomを指定した場合は、この状態にはならないことに注意。) */
  public static String S_LSM_ZOOM_IN_ROI_EXISTS = "S_LSM_ZOOM_IN_ROI_EXISTS";
  /** 刺激アイドル中 */
  public static String S_LSM_STIMURATION_IDLING = "S_LSM_STIMURATION_IDLING";
  /** 刺激中 */
  public static String S_LSM_STIMULATING = "S_LSM_STIMULATING";
  /** 刺激が行えない状態(刺激ROIが設定されていない) */
  public static String S_LSM_NO_STIMULATION_MODE = "S_LSM_NO_STIMULATION_MODE";
  /** 刺激がCLIPスキャンで行われる状態(刺激のCLIP系ROIが設定されている) */
  public static String S_LSM_CLIP_STIMULATION_MODE = "S_LSM_CLIP_STIMULATION_MODE";
  /** 刺激がLINEスキャンで行われる状態(刺激のLINE ROIが設定されている) */
  public static String S_LSM_LINE_STIMULATION_MODE = "S_LSM_LINE_STIMULATION_MODE";
  /** 刺激がFREELINEスキャンで行われる状態(刺激のFREELINE ROIが設定されている) */
  public static String S_LSM_FREE_LINE_STIMULATION_MODE = "S_LSM_FREE_LINE_STIMULATION_MODE";
  /** 刺激がPOINTスキャンで行われる状態(刺激のPOINT ROIが設定されている) */
  public static String S_LSM_POINT_STIMULATION_MODE = "S_LSM_POINT_STIMULATION_MODE";
  /** 刺激がMULTIPOINTスキャンで行われる状態(刺激のMULTIPOINT ROIが設定されている) */
  public static String S_LSM_MULTI_POINT_STIMULATION_MODE = "S_LSM_MULTI_POINT_STIMULATION_MODE";
  /** 刺激がMAPPINGスキャンで行われる状態(刺激のMAPPING ROIが設定されている) */
  public static String S_LSM_MAPPINT_STIMULATION_MODE = "S_LSM_MAPPINT_STIMULATION_MODE";
  /** 刺激がCAV TORNADOスキャンで行われる状態(刺激のCAV TORNADO ROIが設定されている) */
  public static String S_LSM_CAV_TORNADO_STIMULATION_MODE = "S_LSM_CAV_TORNADO_STIMULATION_MODE";
  /** 刺激がCLV TORNADOスキャンで行われる状態(刺激のCLV TORNADO ROIが設定されている) */
  public static String S_LSM_CLV_TORNADO_STIMULATION_MODE = "S_LSM_CLV_TORNADO_STIMULATION_MODE";
  /** リピートスキャン中設定変更状態による一時停止 */
  public static String S_LSM_REPEAT_PAUSE = "S_LSM_REPEAT_PAUSE";
  /** BIが無効になっている */
  public static String S_BI_DISABLED = "S_BI_DISABLED";
  /** BIが有効になっている */
  public static String S_BI_ENABLED = "S_BI_ENABLED";
  /** LSM：選択されているフェーズにONのチャンネルがある */
  public static String S_LSM_CH_IN_SELECTED_PHASE = "S_LSM_CH_IN_SELECTED_PHASE";
  /** LSM：選択されているフェーズにONのチャンネルがない */
  public static String S_LSM_NO_CH_IN_SELECTED_PHASE = "S_LSM_NO_CH_IN_SELECTED_PHASE";
  /** LSM：ONのチャンネルがある(全フェーズの中にひとつでも) */
  public static String S_LSM_CH_IN_ALL_PHASE = "S_LSM_CH_IN_ALL_PHASE";
  /** LSM：全てのフェーズにONのチャンネルがない */
  public static String S_LSM_NO_CH_IN_ALL_PHASE = "S_LSM_NO_CH_IN_ALL_PHASE";
  /** Camera：選択されているフェーズにONのチャンネルがある */
  public static String S_CAMERA_CH_IN_SELECTED_PHASE = "S_CAMERA_CH_IN_SELECTED_PHASE";
  /** Camera：選択されているフェーズにONのチャンネルがない */
  public static String S_CAMERA_NO_CH_IN_SELECTED_PHASE = "S_CAMERA_NO_CH_IN_SELECTED_PHASE";
  /** Camera：ONのチャンネルがある(全フェーズの中にひとつでも) */
  public static String S_CAMERA_CH_IN_ALL_PHASE = "S_CAMERA_CH_IN_ALL_PHASE";
  /** Camera：全てのフェーズにONのチャンネルがない */
  public static String S_CAMERA_NO_CH_IN_ALL_PHASE = "S_CAMERA_NO_CH_IN_ALL_PHASE";
  /** イメージングアイドル中 */
  public static String S_CAMERA_IDLING = "S_CAMERA_IDLING";
  /** リピートイメージング中 */
  public static String S_CAMERA_REPEAT_IMAGING = "S_CAMERA_REPEAT_IMAGING";
  /** リピートスキャン中設定変更状態による一時停止 */
  public static String S_CAMERA_REPEAT_PAUSE = "S_CAMERA_REPEAT_PAUSE";
  /** シリーズイメージング中 */
  public static String S_CAMERA_SERIES_IMAGING = "S_CAMERA_SERIES_IMAGING";
  /** レスト中 */
  public static String S_CAMERA_RESTING = "S_CAMERA_RESTING";
  /** Cell32:ONのVBFチャネルがある */
  public static String S_CELL32_VBF_CH_IN_ALL_PHASE = "S_CELL32_VBF_CH_IN_ALL_PHASE";
  /** Cell32:ONのVBFチャネルがない */
  public static String S_CELL32_NO_VBF_CH_IN_ALL_PHASE = "S_CELL32_NO_VBF_CH_IN_ALL_PHASE";
  /** 単一フェーズが存在する状態 */
  public static String S_LSM_SINGLE_PHASE_MODE = "S_LSM_SINGLE_PHASE_MODE";
  /** 複数フェーズが存在する状態 */
  public static String S_LSM_MULTI_PHASE_MODE = "S_LSM_MULTI_PHASE_MODE";
  /** MAINスキャナで刺激 */
  public static String S_STIMULATION_DEVICE_MAIN = "S_STIMULATION_DEVICE_MAIN";
  /** SIMスキャナで刺激 */
  public static String S_STIMULATION_DEVICE_SIM = "S_STIMULATION_DEVICE_SIM";
  /** CAMERA : リファレンス画像がない */
  public static String S_CAMERA_NO_REFERENCE = "S_CAMERA_NO_REFERENCE";
  /** CAMERA : リファレンス画像がある */
  public static String S_CAMERA_WITH_REFERENCE = "S_CAMERA_WITH_REFERENCE";
  /** シリーズイメージング中 */
  public static String S_LSM_WITH_REFERENCE = "S_LSM_WITH_REFERENCE";
  /** レスト中 */
  public static String S_LSM_NO_REFERENCE = "S_LSM_NO_REFERENCE";
  /** リファレンス画像サイズが変更された状態 */
  public static String S_LSM_REFERENCE_SIZE_UPDATED = "S_LSM_REFERENCE_SIZE_UPDATED";
  /** リファレンス画像サイズが変更されていない状態 */
  public static String S_LSM_REFERENCE_SIZE_NOT_UPDATED = "S_LSM_REFERENCE_SIZE_NOT_UPDATED";
  /** ImagingROI設定可能状態 */
  public static String S_LSM_IMAGING_ROI_SET_ENABLE = "S_LSM_IMAGING_ROI_SET_ENABLE";
  /** ImagingROI設定不可能状態 */
  public static String S_LSM_IMAGING_ROI_SET_DISABLE = "S_LSM_IMAGING_ROI_SET_DISABLE";
  /** LSM:未スキャン時 */
  public static String S_LSM_LAST_SCAN_NO = "S_LSM_LAST_SCAN_NO";
  /** LSM:ImagingROIなしでスキャン後 */
  public static String S_LSM_LAST_SCAN_REFERENCE = "S_LSM_LAST_SCAN_REFERENCE";
  /** LSM:Clipスキャン後 */
  public static String S_LSM_LAST_SCAN_CLIP = "S_LSM_LAST_SCAN_CLIP";
  /** LSM:Pointスキャン後 */
  public static String S_LSM_LAST_SCAN_POINT = "S_LSM_LAST_SCAN_POINT";
  /** LSM:Line、FreeLineスキャン後 */
  public static String S_LSM_LAST_SCAN_LINE = "S_LSM_LAST_SCAN_LINE";
  /** LSM:Multipoint、Mappingスキャン後 */
  public static String S_LSM_LAST_SCAN_MULTIPOINT = "S_LSM_LAST_SCAN_MULTIPOINT";
  /** シーケンシャルモードOFF */
  public static String S_SEQUENTIAL_OFF = "S_SEQUENTIAL_OFF";
  /** シーケンシャルモードLINE */
  public static String S_SEQUENTIAL_LINE = "S_SEQUENTIAL_LINE";
  /** シーケンシャルモードFRAME */
  public static String S_SEQUENTIAL_FRAME = "S_SEQUENTIAL_FRAME";
  /** LSMカルマンOFF */
  public static String S_LSM_KALMAN_OFF = "S_LSM_KALMAN_OFF";
  /** LSMラインカルマン */
  public static String S_LSM_KALMAN_LINE = "S_LSM_KALMAN_LINE";
  /** LSMフレームカルマン */
  public static String S_LSM_KALMAN_FRAME = "S_LSM_KALMAN_FRAME";
  /** 同じディテクタを同じフェーズで利用しようとしている状態(シーケンシャルOFFにできない) */
  public static String S_SAME_DETECTOR_USE_IN_ONE_PHASE = "S_SAME_DETECTOR_USE_IN_ONE_PHASE";
  /** 同じディテクタを同じフェーズで利用しようとしていない状態(シーケンシャルOFFにできる) */
  public static String S_NO_SAME_DETECTOR_USE_IN_ONE_PHASE = "S_NO_SAME_DETECTOR_USE_IN_ONE_PHASE";
  /** DIA Lamp光量変更中 */
  public static String S_DIA_LAMP_INTENSITY_CHANGING = "S_DIA_LAMP_INTENSITY_CHANGING";
  /** AS変更中 */
  public static String S_AS_CHANGING = "S_AS_CHANGING";
  /** BeamShifter変更中 */
  public static String S_BSF_CHANGING = "S_BSF_CHANGING";
  /** Zステージ長距離移動中ではない */
  public static String S_Z_STAGE_NOT_LONG_MOVING = "S_Z_STAGE_NOT_LONG_MOVING";
  /** Zステージ長距離移動の最中 */
  public static String S_Z_STAGE_LONG_MOVING_NOW = "S_Z_STAGE_LONG_MOVING_NOW";
  /** 緊急停止中 */
  public static String S_Z_STAGE_URGENT_STOPPING = "S_Z_STAGE_URGENT_STOPPING";
  /** 緊急停止中ではない */
  public static String S_Z_STAGE_NOT_URGENT_STOPPING = "S_Z_STAGE_NOT_URGENT_STOPPING";
  /** 倒立顕微鏡 */
  public static String S_MICROSCOPE_IX = "S_MICROSCOPE_IX";
  /** 正立顕微鏡 */
  public static String S_MICROSCOPE_BX = "S_MICROSCOPE_BX";
  /** U_AWシャッタがあけてる状態 */
  public static String S_SHUTTER_U_AW_OPEN = "S_SHUTTER_U_AW_OPEN";
  /** U_AWシャッタが閉じてる状態 */
  public static String S_SHUTTER_U_AW_CLOSE = "S_SHUTTER_U_AW_CLOSE";
  /** 開かれているプロトコールがない */
  public static String S_PROTOCOL_NO_PROTOCOL = "S_PROTOCOL_NO_PROTOCOL";
  /** 何かしらのプロトコールが開かれている */
  public static String S_PROTOCOL_ANY_PROTOCOL = "S_PROTOCOL_ANY_PROTOCOL";
  /** アクティブなプロトコールが編集されていない（上書き保存ボタンのDisable） */
  public static String S_PROTOCOL_NOT_EDITED = "S_PROTOCOL_NOT_EDITED";
  /** アクティブなプロトコールが編集されている（上書き保存ボタンのEnable） */
  public static String S_PROTOCOL_EDITED = "S_PROTOCOL_EDITED";
  /** アクティブなプロトコールは未READY */
  public static String S_PROTOCOL_NOT_READY = "S_PROTOCOL_NOT_READY";
  /** アクティブなプロトコールはREADY済み */
  public static String S_PROTOCOL_READY = "S_PROTOCOL_READY";
  /** プロトコールファイル停止状態 */
  public static String S_PROTOCOL_STOP = "S_PROTOCOL_STOP";
  /** プロトコール準備待ち状態 */
  public static String S_PROTOCOL_WAITING_PREPARE = "S_PROTOCOL_WAITING_PREPARE";
  /** プロトコールファイル実行中状態 */
  public static String S_PROTOCOL_EXECUTING = "S_PROTOCOL_EXECUTING";
  /** プロトコールファイル開始待ち状態 */
  public static String S_PROTOCOL_WAITING_START = "S_PROTOCOL_WAITING_START";
  /** プロトコールファイル停止待ち状態 */
  public static String S_PROTOCOL_WAITING_STOP = "S_PROTOCOL_WAITING_STOP";
  /** プロトコールファイル一時停止待ち状態 */
  public static String S_PROTOCOL_WAITING_PAUSE = "S_PROTOCOL_WAITING_PAUSE";
  /** プロトコールファイル再開待ち状態 */
  public static String S_PROTOCOL_WAITING_RESUME = "S_PROTOCOL_WAITING_RESUME";
  /** プロトコールファイル一時停止状態 */
  public static String S_PROTOCOL_PAUSE = "S_PROTOCOL_PAUSE";
  /** プロトコールリセット完了待ち状態 */
  public static String S_PROTOCOL_WAITING_RESET = "S_PROTOCOL_WAITING_RESET";
}
