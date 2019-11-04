package minilext.data;

import java.util.ArrayList;
import java.util.List;
import minilext.type.Size;

/**
 * 多点測定の設定
 */
public final class MultiPointSettings {

	/** 各地点の座標値 */
	static final class Point {

		/** 地点のX位置[nm] */
		public int xNM;

		/** 地点のY位置[nm] */
		public int yNM;

		/** 有効か(撮影するか)どうか */
		public boolean isEnabled;
	}

	/** 各地点の座標値のリスト */
	public final List<Point> points = new ArrayList<Point>();

	/** MATLグループ間移動時にZ退避するかどうか */
	public boolean isZEscapeEnabled;

	/** Z退避移動量 */
	public enum ZEscapeDistance {
		/** 1mm */
		_1MM,
		/** 3mm */
		_3MM,
		/** 最大(Z駆動範囲の上端まで退避させる) */
		MAXIMUM
	}

	/** Z退避移動量 */
	public ZEscapeDistance zEscapeDistance;

	/** 貼り合わせ情報 */
	static final class Stitching {

		/** 有効かどうか */
		public boolean isEnabled;

		/** サイズ指定方法 */
		enum SizeType {
			/** 枚数 */
			COUNT,

			/** 長さ */
			LENGTH
		}

		/** サイズ指定方法 */
		public SizeType sizeType;

		/** サイズ(単位はSizeTypeで異なる。COUNTなら枚数、LENGTHならnmである。) */
		public Size size;
	}

	/** 貼り合わせ情報 */
	public final Stitching stitching = new Stitching();

	/**	*/
	public void dumpProperties() {
	}
}
