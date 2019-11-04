package app;

import data.Edge;
import data.Node;

/**
 */
public final class MyEdge extends Edge {
	/** 説明文 */
	private String description;

	/**
	 * @param from
	 *            元ノード
	 * @param to
	 *            先ノード
	 * @param description
	 *            説明文
	 */
	public MyEdge(Node from, Node to, String description) {
		super(from, to);
		this.setDescription(description);
	}

	/**
	 * @return 説明文
	 */
	public String getDescription() {
		return description;
	}

	/**
	 * @param description
	 *            説明文
	 */
	public void setDescription(String description) {
		this.description = description;
	}
}
