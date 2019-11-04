package internationalization;

import java.util.Locale;
import java.util.ResourceBundle;

import minilext.log.Log;

/**
 * 多言語対応
 * 
 * ロケール注意事項<br>
 * ・ResourceBundle#getBundle()のロケール指定は省略可能。
 * プロパティファイルを用意していないロケールを指定すると、rootのリソースではなく、デフォルトロケール（日本語）のリソースが使用されてしまうらしい。
 * つまり、基本的にはアプリケーションのユーザーが任意のロケールを指定できるようにしてはいけないということ。
 * 任意のロケールをアプリケーションのユーザーが指定できるようにするなら、アプリケーション側でそのロケールのリソースファイルがあるかどうかをチェックして、
 * なければロケール指定エラーをユーザーに報告するとか、 rootロケールを使用する旨をユーザーに報告するなどの対応をしなければならない。
 * 
 * リソースファイル<br>
 * ファイル名は、以下のように設定しなければならない。(「基本名」は任意に選べる）
 * 
 * ロケール情報なし(rootというらしい)のプロパティファイル：<br>
 * 基本名 + ".properties"
 * 
 * 上記以外のプロパティファイル:<br>
 * 基本名 + "_" + ロケール文字列 + ".properties"
 * 
 * リソースファイルは、UTF8テキストファイルではなく（ごく最近UTF8もOKになったらしいが、Eclipseですら未サポート?）、ASCIIテキストファイルで、
 * 漢字などはユニコードエスケープ形式(unicode escape sequence）で表現しなければならない。
 * Eclipseでもこのファイルに対するサポートは不十分で、内臓エディタで開いても、 ユニコードエスケープ形式でしか表示されない。
 * 
 * 一応以下の最低限ともいえる機能はある。<br>
 * ・入力はIMEを利用して行える。<br>
 * ・ユニコードエスケープ形式文字列にマウスカーソルを重ねると、ツールチップで表示される。
 * 
 * ↑PropertiesEditorというサードパーティのプラグインを導入することで、通常のテキストエディタのように扱える。
 */
public final class Internationalization {
    /***/
    private Internationalization() {
    }

    /**
     * @param args
     *                 :
     */
    public static void main(String[] args) {
	// var locale = Locale.JAPAN; // ja_JP
	var locale = Locale.CHINA; // zh_CN
	// var locale = Locale.US; // en_US (あくまで英語、米国のロケールであって、rootというわけではない）
	// var locale = Locale.ENGLISH; // en (国を指定しない単に英語のロケールであって、これもrootというわけではない）
	// var locale = Locale.ROOT; // 国、言語なしのロケール
	var resourceBundle = ResourceBundle.getBundle("internationalization", locale);
	var text = resourceBundle.getString("hello.world");
	Log.p(null, "%s", text);
    }
}
