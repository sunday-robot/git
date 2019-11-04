package data;

/** 有向グラフ構成要素の一つのエッジ */
public class Edge {
	/** 元ノード */
	private Node from;

	/** 先ノード */
	private Node to;

	/**
	 */
	public Edge() {
		this(null, null);
	}

	/**
	 * @param from
	 *            元ノード
	 * @param to
	 *            先ノード
	 */
	public Edge(Node from, Node to) {
		this.from = from;
		this.to = to;
	}

	/**
	 * @return the from
	 */
	public final Node getFrom() {
		return from;
	}

	/**
	 * @param from
	 *            the from to set
	 */
	public final void setFrom(Node from) {
		this.from = from;
	}

	/**
	 * @return the to
	 */
	public final Node getTo() {
		return to;
	}

	/**
	 * @param to
	 *            the to to set
	 */
	public final void setTo(Node to) {
		this.to = to;
	}

}
