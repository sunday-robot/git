package lib.pagecompactor;

import java.awt.Rectangle;

/**
 * 入力ページのレイアウト定義情報
 */
public final class PageLayout {
	/** ヘッダ領域定義情報 */
	private PageRegion header;
	/** 本文領域定義情報 */
	private PageRegion body;
	/** フッタ領域定義情報 */
	private PageRegion footer;

	/**
	 * @return ヘッダ領域定義情報
	 */
	public PageRegion getHeader() {
		return header;
	}

	/**
	 * @param header
	 *            ヘッダ領域定義情報
	 */
	public void setHeader(PageRegion header) {
		this.header = header;
	}

	/**
	 * @return 本文領域定義情報
	 */
	public PageRegion getBody() {
		return body;
	}

	/**
	 * @param body
	 *            本文領域定義情報
	 * @throws WrongPageLayoutException
	 *             WrongPageLayoutException
	 */
	public void setBody(PageRegion body) throws WrongPageLayoutException {
		if (body.getWidth() == 0 || body.getHeight() == 0) {
			throw new WrongPageLayoutException(
					"BodyのWidth、Heightに0を設定することはできません。（無指定の場合は-1を設定してください)");
		}
		this.body = body;
	}

	/**
	 * @return フッタ領域定義情報
	 */
	public PageRegion getFooter() {
		return footer;
	}

	/**
	 * @param footer
	 *            フッタ領域定義情報
	 */
	public void setFooter(PageRegion footer) {
		this.footer = footer;
	}

	/**
	 * コンストラクタ
	 * 
	 * @param header
	 *            ヘッダ領域定義情報
	 * @param body
	 *            本文領域定義情報
	 * @param footer
	 *            フッタ領域定義情報
	 */
	public PageLayout(PageRegion header, PageRegion body, PageRegion footer) {
		this.header = header;
		this.body = body;
		this.footer = footer;
	}

	/**
     */
	public PageLayout() {
	}

	/**
	 * 右ページ(奇数ページ)のヘッダ領域を返す
	 * 
	 * @param width
	 *            画像の幅
	 * @param height
	 *            画像の高さ
	 * @return 矩形領域情報(左上頂点座標、幅、高さ)
	 */
	public Rectangle getRightPageHeaderRegion(int width, int height) {
		if (header == null)
			return null;
		return getRightPageRegion(header.getRightPageSideMargin(),
				header.getY(), header.getWidth(), header.getHeight(), width,
				height);
	}

	/**
	 * 右ページ(奇数ページ)の本文領域を返す
	 * 
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 * @return 領域
	 */
	public Rectangle getRightPageBodyRegion(int width, int height) {
		return getRightPageRegion(body.getRightPageSideMargin(), body.getY(),
				body.getWidth(), body.getHeight(), width, height);
	}

	/**
	 * 右ページ(奇数ページ)のフッタ領域を返す
	 * 
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 * @return 領域
	 */
	public Rectangle getRightPageFooterRegion(int width, int height) {
		if (footer == null)
			return null;
		return getRightPageRegion(footer.getRightPageSideMargin(),
				footer.getY(), footer.getWidth(), footer.getHeight(), width,
				height);
	}

	/**
	 * 左ページ(偶数ページ)のヘッダ領域を返す
	 * 
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 * @return 領域
	 */
	public final Rectangle getLeftPageHeaderRegion(int width, int height) {
		if (header == null)
			return null;
		return getLeftPageRegion(header.getLeftPageSideMargin(), header.getY(),
				header.getWidth(), header.getHeight(), width, height);
	}

	/**
	 * 左ページ(偶数ページ)の本文領域を返す
	 * 
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 * @return 領域
	 */
	public final Rectangle getLeftPageBodyRegion(int width, int height) {
		return getLeftPageRegion(body.getLeftPageSideMargin(), body.getY(),
				body.getWidth(), body.getHeight(), width, height);
	}

	/**
	 * 左ページ(偶数ページ)のフッタ領域を返す
	 * 
	 * @param width
	 *            幅
	 * @param height
	 *            高さ
	 * @return 領域
	 */
	public final Rectangle getLeftPageFooterRegion(int width, int height) {
		if (footer == null)
			return null;
		return getLeftPageRegion(footer.getLeftPageSideMargin(), footer.getY(),
				footer.getWidth(), footer.getHeight(), width, height);
	}

	/**
	 * 右ページ(奇数ページ)の領域を返す
	 * 
	 * @param regionSideMergine
	 *            右側のマージン
	 * @param regionY
	 *            領域のY座標
	 * @param regionWidth
	 *            領域の幅
	 * @param regionHeight
	 *            領域の高さ
	 * @param pageWidth
	 *            ページの幅
	 * @param pageHeight
	 *            ページの高さ
	 * @return 領域
	 */
	private static Rectangle getRightPageRegion(int regionSideMergine,
			int regionY, int regionWidth, int regionHeight, int pageWidth,
			int pageHeight) {
		int w = getActualLength(regionWidth, pageWidth - regionSideMergine);
		int h = getActualLength(regionHeight, pageHeight - regionY);
		int x = pageWidth - regionSideMergine - w;
		return new Rectangle(x, regionY, w, h);
	}

	/**
	 * 左ページ(偶数ページ)の領域を返す
	 * 
	 * @param regionSideMergine
	 *            左側のマージン
	 * @param regionY
	 *            領域のY座標
	 * @param regionWidth
	 *            領域の幅
	 * @param regionHeight
	 *            領域の高さ
	 * @param pageWidth
	 *            ページの幅
	 * @param pageHeight
	 *            ページの高さ
	 * @return 領域
	 */
	private static Rectangle getLeftPageRegion(int regionSideMergine,
			int regionY, int regionWidth, int regionHeight, int pageWidth,
			int pageHeight) {
		int w = getActualLength(regionWidth, pageWidth - regionSideMergine);
		int h = getActualLength(regionHeight, pageHeight - regionY);
		return new Rectangle(regionSideMergine, regionY, w, h);
	}

	/**
	 * @param specifiedLength
	 *            ユーザーが指定した長さ(0未満の場合は、指定されていないとして扱う)
	 * @param maxLength
	 *            実際の画像で取り得る最大の長さ
	 * @return 実際の長さ
	 */
	private static int getActualLength(int specifiedLength, int maxLength) {
		if (specifiedLength < 0)
			return maxLength;
		return Math.min(specifiedLength, maxLength);
	}

}
