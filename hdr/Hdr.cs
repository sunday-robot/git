using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hdr
{
    public class Hdr
    {
        /// <summary>
        /// 9種類の露光時間が異なる8ビット画像の輝度値から、16ビット輝度値を求める。
        /// 各画像の露光時間は、1枚目を1とすると、2枚目は2、3枚目は4、4枚目は8、…となっている。
        /// </summary>
        /// <param name="p1">露光時間1の画像での輝度値(0-255)</param>
        /// <param name="p2">露光時間2の画像での輝度値(0-255)</param>
        /// <param name="p4"></param>
        /// <param name="p8"></param>
        /// <param name="p16"></param>
        /// <param name="p32"></param>
        /// <param name="p64"></param>
        /// <param name="p128"></param>
        /// <param name="p256"></param>
        /// <returns>16ビット輝度値(0-65535)</returns>
        int hdr(int p1, int p2, int p4, int p8, int p16, int p32, int p64, int p128, int p256)
        {
            if ((p1 != 255) || (p2 < 128))
                return p1;              //     0 -   254,   1
            if ((p2 != 255) || (p4 < 128))
                return p2 * 257 / 128;  //   257 -   509,   2.0078125
            if ((p4 != 255) || (p8 < 128))
                return p4 * 257 / 64;   //   514 -  1019,   4.015625
            if ((p8 != 255) || (p16 < 128))
                return p8 * 257 / 32;   //  1028 -  2039,   8.03125
            if ((p16 != 255) || (p32 < 128))
                return p16 * 257 / 16;  //  2056 -  4079,  16.0625
            if ((p32 != 255) || (p64 < 128))
                return p32 * 257 / 8;   //  4112 -  8159,  32.125
            if ((p64 != 255) || (p128 < 128))
                return p64 * 257 / 4;   //  8224 - 16319,  64.25
            if ((p128 != 255) || (p256 < 128))
                return p128 * 257 / 2;  // 16448 - 32639, 128.5
            return p256 * 257;          // 32896 - 65535, 257
        }

        int hdr3(int p1, int p2, int p4, int p8, int p16, int p32, int p64, int p128, int p256)
        {
            var q2 = p2 * 257 / 128;
            if (p1 > q2)
                return p1;

            var q4 = p4 * 257 / 64;
            if (q2 > q4)
                return q2;

            var q8 = p8 * 257 / 32;
            if (q4 > q8)
                return q4;

            var q16 = p16 * 257 / 16;
            if (q8 > q16)
                return q8;

            var q32 = p32 * 257 / 8;
            if (q16 > q32)
                return q16;

            var q64 = p64 * 257 / 4;
            if (q32 > q64)
                return q32;

            var q128 = p128 * 257 / 2;
            if (q64 > q128)
                return q64;

            var q256 = p256 * 257;
            if (q128 > q256)
                return q128;

            return q256;
        }
    }
}
