using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuruKuru
{
    /// <summary>
    /// フィーバーのレベルを示す列挙型
    /// </summary>
    enum FeaverLevel
    {
        /// <summary>
        /// フィーバー状態ではない(グレーの花びらはグレーのままで、リング形成にはつながらない)
        /// </summary>
        Gray,

        /// <summary>
        /// フィーバーレベル1(グレーの花びらは白で表示され、赤、緑の花びらと同様に、リング形成につながる。リング形成に関しては、レベル1とレベル2の際はない。)
        /// </summary>
        White,

        /// <summary>
        /// フィーバーレベル2(グレーの花びらは黄色で表示されるだけで、リング形成に関しては、レベル1と同じ。)
        /// </summary>
        Yellow,

        /// <summary>
        /// フィーバーレベル3(グレーの花びらは七色(?)にアニメーション表示される。リング形成については赤もしくは緑として役立つ。)
        /// </summary>
        Rainbow
    }
}
