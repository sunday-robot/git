package app;

import data.Node;

public final class MyNode extends Node {
	private static int nextNumber = 1;
	private int number;
	private int x;
	private int y;

	public MyNode(int x, int y) {
		number = nextNumber++;
		this.x = x;
		this.y = y;
	}

	public int getNumber() {
		return number;
	}

	public int getX() {
		return x;
	}

	public int getY() {
		return y;
	}
}
