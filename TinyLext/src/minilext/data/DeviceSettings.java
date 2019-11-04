package minilext.data;

/**
 * このクラス多分いらない。
 * 
 * デバイス設定。具体的には以下のもの。<br>
 * ・対物レンズの穴位置<br>
 * ・ズーム倍率<br>
 * ・Z位置<br>
 * ・ライブ状態(停止/CCDのみ/LSMのみ/CCDとLSM)<br>
 * ・LSMの明るさ<br>
 * ・CCDの明るさ<br>
 * ・LSMのチャンネル混合比<br>
 * ・XY位置<br>
 */
public final class DeviceSettings {

	/** 現在の対物レンズの位置(0～5) */
	public int revolverIndex = 0;

	/** Z位置 */
	public int zNM = 0;

	/** LSMの明るさ*10 */
	public int lsmBrightnessX10 = 500;

	/** CCDの明るさ*10 */
	public int ccdBrightnessX10 = 500;

	/** LSMのチャンネル混合比(CFの比率%(0～100)) */
	public int cfPercentage = 50;

	/** X位置 */
	public int xNM = 0;

	/** Y位置 */
	public int yNM = 0;
}
