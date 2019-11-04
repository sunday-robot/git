package data;

import java.util.HashSet;
import java.util.Set;

/** 有向グラフ(複数のノードとそれらを結ぶエッジから成るもの) */
public abstract class DirectedGraph {
	/** ノード{@link Node}の集合(エッジが一つもないノードも存在可能である) */
	private Set<Node> nodes = new HashSet<>();

	/** エッジ{@link Edge}の集合(ノードを指していないエッジも存在可能だが、nodesに属していないエッジは存在不能) */
	private Set<Edge> edges = new HashSet<>();

	/**
	 * ノードを追加する。<br>
	 * 
	 * 以下の場合、内部エラー例外を投げる。<br>
	 * ・ノードが既に追加されている
	 * 
	 * @param node
	 *            追加するノード
	 */
	public final void addNode(Node node) {
		if (nodes.contains(node)) {
			throw new InternalError();
		}

		nodes.add(node);
	}

	/**
	 * ノードを削除する。<br>
	 * 
	 * 以下の場合、内部エラー例外を投げる。<br>
	 * ・ノードが存在しない<br>
	 * ・ノードを参照するエッジがある<br>
	 * 
	 * @param node
	 *            削除するノード
	 */
	public final void removeNode(Node node) {
		if (!nodes.contains(node)) {
			throw new InternalError();
		}

		for (Edge edge : edges) {
			if (edge.getFrom() == node)
				throw new InternalError();
			if (edge.getTo() == node)
				throw new InternalError();
		}

		nodes.remove(node);
	}

	/**
	 * エッジを追加する。<br>
	 * 
	 * 以下の場合、内部エラー例外を投げる。<br>
	 * ・エッジが既に追加されている<br>
	 * ・エッジの示すノード(fromとto)が登録されていない<br>
	 * 
	 * @param edge
	 *            エッジ
	 */
	public final void addEdge(Edge edge) {
		if (edges.contains(edge)) {
			throw new InternalError();
		}
		if ((edge.getFrom() != null) && !nodes.contains(edge.getFrom())) {
			throw new InternalError();
		}
		if ((edge.getTo() != null) && !nodes.contains(edge.getTo())) {
			throw new InternalError();
		}

		edges.add(edge);
	}

	/**
	 * エッジを削除する。<br>
	 * 
	 * 以下の場合、内部エラー例外を投げる。<br>
	 * ・エッジが登録されていない<br>
	 * 
	 * @param edge
	 *            エッジ
	 */
	public final void removeEdge(Edge edge) {
		if (!edges.contains(edge)) {
			throw new InternalError();
		}

		edges.add(edge);
	}

	/**
	 * エッジの始点として指定されたノードを設定する。
	 * 
	 * @param edge
	 *            エッジ
	 * @param node
	 *            ノード
	 */
	public final void connectFromNode(Edge edge, Node node) {
		edge.setFrom(node);
	}

	/**
	 * エッジの終点として指定されたノードを設定する。
	 * 
	 * @param edge
	 *            エッジ
	 * @param node
	 *            ノード
	 */
	public final void connectToNode(Edge edge, Node node) {
		edge.setTo(node);
	}

	/**
	 * @return ノードのIterable
	 */
	public final Iterable<Node> getNodes() {
		return nodes;
	}

	/**
	 * @return エッジのIterable
	 */
	public final Iterable<Edge> getEdges() {
		return edges;
	}
}
