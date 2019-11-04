import java.util.ArrayList;
import java.util.List;

/**
 * 座標、大きさがdouble型の矩形
 * 
 * @author akiyama
 * 
 */
public class RectangleD {
    /** 左上の頂点の座標 */
    public PointD position;
    /** 幅と高さ */
    public PointD size;

    /**
     * コンストラクタ
     * 
     * @param x
     *            左上の頂点の座標
     * @param y
     *            左上の頂点の座標
     * @param width
     *            幅
     * @param height
     *            高さ
     */
    public RectangleD(double x, double y, double width, double height) {
	position = new PointD(x, y);
	size = new PointD(width, height);
    }

    /**
     * 中心点の座標を返す。
     * 
     * @return 中心点の座標
     */
    public final PointD getCenter() {
	return new PointD(position.x + size.x / 2, position.y + size.y / 2);
    }

    /**
     * 回転させた後の頂点の座標リストを返す。
     * 
     * @param angle
     *            回転角度
     * @return 回転後の頂点の座標リスト
     */
    public final List<PointD> rotate(double angle) {
	List<PointD> list = new ArrayList<PointD>();
	PointD c = getCenter();
	list.add(position.rotate(c, angle));
	list.add(new PointD(position.x + size.x, position.y).rotate(c, angle));
	list.add(new PointD(position.x, position.y + size.y).rotate(c, angle));
	list.add(new PointD(position.x + size.x, position.y + size.y).rotate(c,
		angle));
	return list;
    }

}
